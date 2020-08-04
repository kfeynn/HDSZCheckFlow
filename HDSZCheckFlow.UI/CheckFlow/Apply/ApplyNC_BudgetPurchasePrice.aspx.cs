

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

namespace HDSZCheckFlow.UI.CheckFlow.Apply
{
	/// <summary>
	/// ApplyNC_BudgetPurchase ��ժҪ˵����
	/// </summary>
	public class ApplyNC_BudgetPurchasePrice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.LinkButton linkToPage;

		//public static string FieldSort="" ; //��������
		//public static int HerdSort=0;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.Button btnOutput;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.DropDownList ddlInvClass;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtInvCode;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;//����ʽ 1,����.2����
		//	public static int pagesIndex=1;		//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)			
			{
				BindInfo();
			}
		}

		private void BindInfo()
		{
			DataSet ds= Bussiness.BaseAccountSubjectBLL.BaseSubjectType();
			this.ddlInvClass.DataSource=ds;
			this.ddlInvClass.DataTextField = ds.Tables[0].Columns[1].ToString();
			this.ddlInvClass.DataValueField = ds.Tables[0].Columns[0].ToString() ;
			this.ddlInvClass.DataBind();
			this.ddlInvClass.Items.Insert(0,"");

		}



		private void bindGrid()
		{
			try
			{
				this.lblMessage.Text  = ""; 
				//���� ����ʼ���ڡ���ֹ���ڡ�������롢�������  ���������Ϊ ��  ���� 

				string cmdStr = " Exec [p_Apply_NCBudgetPurchasePrice] " ; 

				StringBuilder filter =new StringBuilder();
				if(!"".Equals(this.txtDateFrom.Text ))
				{
				
					filter.Append("  '" + this.txtDateFrom .Text + "' ") ; 
				}
				else
				{
					this.lblMessage.Text = "��ѡ����ʼ���ڣ�";
					return;
				}

				if(!"".Equals(this.txtDateTo.Text ))
				{
					filter.Append(" , '" + this.txtDateTo .Text  + "' ") ; 
				}
				else
				{
					this.lblMessage.Text = "��ѡ���ֹ���ڣ�";
					return;
				}

				filter.Append(" , '" + this.ddlInvClass.SelectedValue.Trim()  + "' ") ; 

				filter.Append(" , '" + this.txtInvCode.Text.Trim()  + "' ") ; 
			

				
				cmdStr  +=   filter.ToString();

				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
				if(ds!=null)
				{
					this.dgApply .DataSource= ds; 
				}
				else
				{
					this.dgApply.DataSource = null;
				}
				this.dgApply.DataBind();

			}
			catch(Exception )
			{
				this.lblMessage .Text = "δ�ҵ��κ�����";
				//Response.Write(ex.ToString());
			}
		}



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
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	

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
			bindGrid();

		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		private void btnOutput_Click(object sender, System.EventArgs e)
		{
			//����Excel
			//			string cmdStr = "select * from v_ApplySheetOfCompany ";
			//			string filter = GetQuerySqlString();
			//			if (filter.Length>0)
			//			{
			//				cmdStr = cmdStr + " where " + filter ;
			//			}
			//
			//			DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
			//
			//			this.Datagrid1.DataSource=ds;
			//			this.Datagrid1.DataBind();

			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgApply);

			//			excelHelper.GoToExcel("filename",this.dgApply );


		
		}
	}
}
