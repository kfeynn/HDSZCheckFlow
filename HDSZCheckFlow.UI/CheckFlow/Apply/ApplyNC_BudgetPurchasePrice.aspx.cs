

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
	/// ApplyNC_BudgetPurchase 的摘要说明。
	/// </summary>
	public class ApplyNC_BudgetPurchasePrice : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.LinkButton linkToPage;

		//public static string FieldSort="" ; //排序列名
		//public static int HerdSort=0;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.Button btnOutput;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.DropDownList ddlInvClass;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtInvCode;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;//排序方式 1,升序.2降序
		//	public static int pagesIndex=1;		//列标头排序时,需要记住当前的页码

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
				//参数 ，起始日期、截止日期、分类编码、存货编码  。后两项可为 空  ‘’ 

				string cmdStr = " Exec [p_Apply_NCBudgetPurchasePrice] " ; 

				StringBuilder filter =new StringBuilder();
				if(!"".Equals(this.txtDateFrom.Text ))
				{
				
					filter.Append("  '" + this.txtDateFrom .Text + "' ") ; 
				}
				else
				{
					this.lblMessage.Text = "请选择起始日期！";
					return;
				}

				if(!"".Equals(this.txtDateTo.Text ))
				{
					filter.Append(" , '" + this.txtDateTo .Text  + "' ") ; 
				}
				else
				{
					this.lblMessage.Text = "请选择截止日期！";
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
				this.lblMessage .Text = "未找到任何数据";
				//Response.Write(ex.ToString());
			}
		}



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
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	

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
			bindGrid();

		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		private void btnOutput_Click(object sender, System.EventArgs e)
		{
			//导到Excel
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
