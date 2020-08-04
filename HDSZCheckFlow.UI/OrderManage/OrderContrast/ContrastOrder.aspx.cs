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
	/// ApplyOfCompanyState ��ժҪ˵����
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

		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//����ʽ 1,����.2����
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
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
				//�޸� �� �����÷�ҳ�洢���̡� ���������ѯ ��grid�Դ���ҳ 	
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

		#region  ��ʼ������

		private void InitPageForAdd()
		{
			try
			{
				DateTime dt=DateTime.Today.AddMonths(-1);
				this.txtDateFrom.Text =  dt.ToString("yyyy-MM-dd");
				//Ϊ�����ؼ���ֵ
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			if(e.CommandName.Equals("look")) //���������ť
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
			//���Ѿ�������ע�� ȡ����ע��Ϣ���Ƿ�����Ϣ
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
			#region  �����ѯ����

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
				//1.�������   2. �۸���һ��������Χ��
				string judge = System.Configuration.ConfigurationSettings.AppSettings["judge"];
				decimal judge1 = decimal.Parse(judge) ;
				filter.Append(" ( (isnull(number,0) <> isnull(��������,0))  or  (money > (1 + " + judge1 + ") * isnull(�������ҽ��,0)) or (money < (1 - " +  judge1 + " ) * isnull(�������ҽ��,0)))" );
			}
			if(!"".Equals(this.ddlIsDifference.SelectedValue ) && "0".Equals(this.ddlIsDifference.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				//1.�������   2. �۸���һ��������Χ��
				string judge = System.Configuration.ConfigurationSettings.AppSettings["judge"];
				decimal judge1 = decimal.Parse(judge) ;
				filter.Append(" ( (isnull(number,0) = isnull(��������,0))  and   (money <= (1 + " + judge1 + ") * isnull(�������ҽ��,0)) and (money >= (1 - " +  judge1 + " ) * isnull(�������ҽ��,0)))" );
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
				filter.Append(" ((���뵥�� IS NOT NULL AND orderno IS NULL) or (������� is not null and orderno IS NULL)) " );
			}
			if(!"".Equals(this.ddlDiffType.SelectedValue ) && "0".Equals(this.ddlDiffType.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ((orderno IS NOT NULL AND ���뵥�� IS NULL) or (inventorycode is not null and ������� is null )) " );
			}


			// �������� �� �����Ų�Ϊ��
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
			//1. �Ѿ���ɵ�����
			//2. δ��ɵ�����
			//3. ���ܾ�������

			//�ﶨ������Ϣ
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
			//��ӱ�ע
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
