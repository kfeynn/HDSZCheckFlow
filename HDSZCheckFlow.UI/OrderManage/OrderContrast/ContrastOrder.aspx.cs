using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Text;

namespace HDSZCheckFlow.UI.OrderManage.OrderContrast
{
	/// <summary>
	/// ApplyOfCompanyState 的摘要说明。
	/// </summary>
	public class ContrastOrder : System.Web.UI.Page
	{
		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.LinkButton linkToPage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//排序方式 1,升序.2降序
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.DropDownList ddlIsDifference;
		protected System.Web.UI.WebControls.DropDownList ddlIsDone;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label lblHidden;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label lblHidden2;
		protected System.Web.UI.WebControls.DropDownList ddlDiffType;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		#endregion 

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//修改 ， 不采用分页存储过程。 采用区间查询 。grid自带分页 	
				InitPageForAdd();
				//BindAuditingByType("");
				bindGrid();
			}
		}

		private void bindGrid()
		{
			try
			{
				string filter = GetQuerySqlString() ; 
				DataSet ds = Bussiness.OrderManageBLL.GetJudgetNcBudOrderInfo(filter);
				this.dgApply.DataSource  = ds;
				this.dgApply.DataBind();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		#region  初始化方法

		private void InitPageForAdd()
		{
			try
			{
				DateTime dt=DateTime.Today.AddMonths(-1);
				this.txtDateFrom.Text =  dt.ToString("yyyy-MM-dd");
				//为下拉控件附值
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyType (deptClassCode);
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[0].ToString();
					ddlType.DataTextField=dtType.Columns [1].ToString();
					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}

		#endregion 

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgApply_PageIndexChanged);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //点击审批按钮
			{
				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					if(this.dgApply.Items[i].BackColor==Color.Yellow)
					{
						this.dgApply.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow;
				ShowPanel(e.Item.Cells[1].Text ,e.Item.Cells[3].Text,e.Item.Cells[4].Text) ;
			}
		}

		private void ShowPanel(string orderNo,string inventoryCode,string inventoryName)
		{
			this.Panel1.Visible = true; 
			this.Label5.Text = orderNo ; 
			this.Label2.Text = inventoryName ;
			this.lblHidden.Visible =false;
			this.lblHidden.Text = inventoryCode ;
			//若已经做过备注， 取出备注信息，是否处理信息
			Entiy.OrderDifference orderDiff = Entiy.OrderDifference.FindByOrderNoAndInventoryCode(orderNo,inventoryCode);
			if(orderDiff != null)
			{
				if(orderDiff.IsDone == 1 )
				{
					this.CheckBox1.Checked = true; 
				}
				this.TextBox1.Text = orderDiff.ReMark; 
			}
			else
			{
				this.CheckBox1.Checked = false;
				this.TextBox1.Text = "" ;
			}
		}
		
		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();
			if(!"".Equals(this.txtDateFrom.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("OrderDate >= " +" '" + this.txtDateFrom.Text+ "'" );
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" OrderDate <= " +" '" +  this.txtDateTo.Text+ "'" );
			}
			if(!"".Equals(this.ddlIsDifference.SelectedValue ) && "1".Equals(this.ddlIsDifference.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				//1.数量相等   2. 价格在一个浮动范围内
				string judge = System.Configuration.ConfigurationSettings.AppSettings["judge"];
				decimal judge1 = decimal.Parse(judge) ;
				filter.Append(" ( (isnull(number,0) <> isnull(订单数量,0))  or  (money > (1 + " + judge1 + ") * isnull(订单本币金额,0)) or (money < (1 - " +  judge1 + " ) * isnull(订单本币金额,0)))" );
			}
			if(!"".Equals(this.ddlIsDifference.SelectedValue ) && "0".Equals(this.ddlIsDifference.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				//1.数量相等   2. 价格在一个浮动范围内
				string judge = System.Configuration.ConfigurationSettings.AppSettings["judge"];
				decimal judge1 = decimal.Parse(judge) ;
				filter.Append(" ( (isnull(number,0) = isnull(订单数量,0))  and   (money <= (1 + " + judge1 + ") * isnull(订单本币金额,0)) and (money >= (1 - " +  judge1 + " ) * isnull(订单本币金额,0)))" );
			}
			if(!"".Equals(this.ddlIsDone.SelectedValue) )
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				if("1".Equals(this.ddlIsDone.SelectedValue ))
				{
					filter.Append("  IsDone = 1 " );
				}
				else
				{
					filter.Append("  IsDone = 0  or isdone is null  " );
				}
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" AOrderNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}
			if(!"".Equals(this.ddlDiffType.SelectedValue ) && "1".Equals(this.ddlDiffType.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ((申请单号 IS NOT NULL AND orderno IS NULL) or (存货编码 is not null and orderno IS NULL)) " );
			}
			if(!"".Equals(this.ddlDiffType.SelectedValue ) && "0".Equals(this.ddlDiffType.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ((orderno IS NOT NULL AND 申请单号 IS NULL) or (inventorycode is not null and 存货编码 is null )) " );
			}


			// 基础条件 ： 定单号不为空
//			if(filter.Length>0)
//			{
//				filter.Append(" and ");
//			}
//			filter.Append(" (AOrderNo  <> '')   "  );

			string returnValue = "" ; 
			if(filter.Length > 0 )
			{
				returnValue=" where " + filter.ToString();
			}
			else 
			{
				returnValue= filter.ToString();
			}
		
			return returnValue;

			#endregion  
		}
	
		private void BindAuditingByType(string sqlWhere )
		{
			//type
			//1. 已经完成的审批
			//2. 未完成的审批
			//3. 被拒绝的审批

			//帮定审批信息
			DataSet ds=Bussiness.ApplySheetHeadBLL.GetAuditingByType(sqlWhere);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				this.dgApply .DataSource=ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply .DataSource=null;
				this.dgApply.DataBind();
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			this.dgApply.CurrentPageIndex = 0 ;
			bindGrid();
		}

		private void dgApply_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgApply.CurrentPageIndex = e.NewPageIndex ;
			bindGrid();
		}

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			//添加备注
			Entiy.OrderDifference orderDiff = Entiy.OrderDifference.FindByOrderNoAndInventoryCode(this.Label5.Text.Trim(),this.lblHidden.Text.Trim());
			if(orderDiff == null )
			{
				orderDiff = new HDSZCheckFlow.Entiy.OrderDifference(); 
			}
			orderDiff.OrderNo = this.Label5.Text.Trim() ;
			orderDiff.InventoryCode = this.lblHidden.Text.Trim();
			if(this.CheckBox1.Checked )
			{
				orderDiff.IsDone = 1 ;
			}
			else
			{
				orderDiff.IsDone = 0 ;
			}
			orderDiff.ReMark = this.TextBox1.Text ;

			orderDiff.Save();
		}
	}
}
