//BudgetInfoNewByMonth
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

namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// BudgetInfoNew 的摘要说明。
	/// </summary>
	public class BudgetInfoNewByMonth : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlStMonth;
		protected System.Web.UI.WebControls.DropDownList ddlEdMonth;
		protected System.Web.UI.WebControls.DropDownList ddlAccBook;
		protected System.Web.UI.WebControls.DataGrid dgBudgetInfo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			if(!Page.IsPostBack)
			{
				//绑定部门信息
				BindDept();
				BindAccBook();
			}

		}
	

		private void BindAccBook()
		{
			try
			{

				string AccBookKey = System.Configuration.ConfigurationSettings.AppSettings["AccBook"];


				DataSet ds = Bussiness.CostBLL.BindAccBook(AccBookKey);
				this.ddlAccBook.DataSource = ds.Tables[0];
				this.ddlAccBook.DataValueField = "Code";
				this.ddlAccBook.DataTextField = "CodeName";
				this.ddlAccBook.DataBind();
			}
			catch(Exception Ex)
			{
				this.lblMessage.Text = "绑定帐套出错！" + Ex.Message ;
			}
		}

		#region 查寻报表财务部门 。 Base_Runreport
		private void BindDept()
		{
			
			DataSet ds=Bussiness.CostBLL.GetAllBudgetDeptInfo();
			this.ddlDept.DataSource=ds.Tables[0];
			this.ddlDept.DataValueField =ds.Tables[0].Columns["tableCode"].ToString();
			this.ddlDept.DataTextField  =ds.Tables[0].Columns["tableName"].ToString();
			this.ddlDept.DataBind();

			this.ddlDept.Items.Insert(0,new System.Web.UI.WebControls.ListItem("All","All"));


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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.dgBudgetInfo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetInfo_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindBudgetInfo();

		
		}

		private void BindBudgetInfo()
		{
			this.lblMessage.Text ="";
			if("".Equals(this.txtDate.Text ))
			{
				this.lblMessage.Text = "请选择日期查询!";
				this.lblMessage.ForeColor=Color.Red;
				return ;
			}
			DateTime dt= DateTime.Parse(this.txtDate.Text);

			string tableCode = this.ddlDept.SelectedValue;

			int StMonth = int.Parse(this.ddlStMonth.SelectedValue);
			int EdMonth = int.Parse(this.ddlEdMonth.SelectedValue);

			string AccBook = this.ddlAccBook.SelectedValue ; 

			if(AccBook == "")
			{
				this.lblMessage .Text = "请选择帐套";
				return ;
			}



			string QueryType = this.ddlType.SelectedValue.Trim() ;
			string Proc = "";

			if(tableCode != "All")
			{

				switch ( QueryType )
				{
					case "1001":      // 预算信息一览表

						Proc = "p_GetBudgetByDeptAndMonths";
						break;
					case "1002":      // 实算信息一览表
						Proc = "p_GetCostByDeptAndMonths";
						break;
					case "1003":
						Proc = "p_GetBudgetAndCostByDeptAndMonths";
						break;
					case "1004":
						Proc = "p_GetTuisuanByDeptAndMonths";
						break;
				}
			}
			else
			{
				switch ( QueryType )
				{
					case "1001":      // 预算信息一览表
						Proc = "p_GetBudgetByDeptAndMonthsForCompany";
						break;
					case "1002":      // 实算信息一览表
						Proc = "p_GetCostByDeptAndMonthsForCompany";
						break;
					case "1003":
						Proc = "p_GetBudgetAndCostByDeptAndMonthsForCompany";
						break;
					case "1004":
						Proc = "p_GetTuisuanByDeptAndMonthsForCompany";
						break;
				}
			}

			DataSet ds = Bussiness.CostBLL.GetProcInfo(Proc,tableCode,dt.Year,StMonth,EdMonth,AccBook );

			if(ds !=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
			{
				this.lblMessage.Text ="";
				this.dgBudgetInfo.DataSource = ds;
				this.dgBudgetInfo.DataBind();
			}
			else
			{
				this.lblMessage.Text ="没有数据!";
			}

		}

		private void dgBudgetInfo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定时候 表示为 合计项目,标识为黄色,醒目
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)    //项，交替项 
			{
				DataSet ds=this.dgBudgetInfo.DataSource as DataSet ;
				if(ds!=null)
				{

					//固定样式
					e.Item.Cells[0].CssClass = "scrollRowThead";
					e.Item.Cells[1].CssClass = "scrollRowThead";
					e.Item.Cells[2].CssClass = "scrollRowThead";
					e.Item.Cells[3].CssClass = "scrollRowThead";
					
					e.Item.Cells[0].Width = new System.Web.UI.WebControls.Unit ("80");
					e.Item.Cells[1].Width = new System.Web.UI.WebControls.Unit ("200");
					e.Item.Cells[2].Width = new System.Web.UI.WebControls.Unit ("50");
					e.Item.Cells[3].Width = new System.Web.UI.WebControls.Unit ("50");

					//醒目标志
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("总计")>-1 )
					{
						e.Item.BackColor=Color.Yellow;
					}
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("合计")>-1)
					{
						e.Item.BackColor=Color.GreenYellow ;
					}
					//第三列以后的数据靠右靠齐
					if(ds.Tables[0].Columns.Count >3)
					{
						for(int i=3;i<ds.Tables[0].Columns.Count ;i++)
						{
							e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
						}
					}
				}
			}
			//固定样式.
			if(e.Item.ItemType==ListItemType.Header  )    //项，交替项 
			{
				e.Item.CssClass = "scrollColThead";
				e.Item.Cells [0].CssClass = "scrollRowThead  scrollCR";
				e.Item.Cells [1].CssClass = "scrollRowThead  scrollCR";
				e.Item.Cells [2].CssClass = "scrollRowThead  scrollCR";
				e.Item.Cells [3].CssClass = "scrollRowThead  scrollCR";

				e.Item.Cells[0].Width = new System.Web.UI.WebControls.Unit ("80");
				e.Item.Cells[1].Width = new System.Web.UI.WebControls.Unit ("200");
				e.Item.Cells[2].Width = new System.Web.UI.WebControls.Unit ("50");
				e.Item.Cells[3].Width = new System.Web.UI.WebControls.Unit ("50");

			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgBudgetInfo);
		}

		
	}
}
