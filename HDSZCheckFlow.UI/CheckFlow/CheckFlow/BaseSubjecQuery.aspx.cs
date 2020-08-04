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

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// BaseSubjecQuery 的摘要说明。
	/// </summary>
	public class BaseSubjecQuery : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtCode;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack )
			{
//				string query = " WHERE (LEFT(Base_InvClass.invClassCode, 1) = 'E' or LEFT(Base_InvClass.invClassCode, 1) = 'F') ORDER BY   invclasscode asc , orderdate desc , Base_inventory.invName asc ";
//				DataSet ds = Bussiness.BaseAccountSubjectBLL.BaseSubjectTypeQuery(query);
//				this.DataGrid1.DataSource= ds; 
//				this.DataGrid1.DataBind();
				BindInfo();
			}
		}

		private void BindInfo()
		{
			DataSet ds= Bussiness.BaseAccountSubjectBLL.BaseSubjectType();
			this.ddlType.DataSource=ds;
			this.ddlType.DataTextField = ds.Tables[0].Columns[1].ToString();
			this.ddlType.DataValueField = ds.Tables[0].Columns[1].ToString() ;
			this.ddlType.DataBind();
			this.ddlType.Items.Insert(0,"");

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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			StringBuilder filter =new StringBuilder();
			if(!"".Equals(this.ddlType.SelectedValue))
			{
				filter.Append(" and Base_InvClass.InvClassName = '" + this.ddlType.SelectedValue + "' ") ; 
			}
			if(!"".Equals(this.txtCode.Text ))
			{
				filter.Append(" and Base_inventory.invCode like '%" + this.txtCode.Text + "%' ") ; 
			}
			if(!"".Equals(this.txtName.Text ))
			{
				filter.Append(" and Base_inventory.invName like  '%" + this.txtName.Text  + "%' ") ; 
			}


			string query = " WHERE (LEFT(Base_InvClass.invClassCode, 1) = 'E'  or LEFT(Base_InvClass.invClassCode, 1) = 'F' ) ";// AND (Base_inventory.INVTYPE IS NOT NULL) ";

			query = query +  filter .ToString() + " ORDER BY Base_inventory.invName";

			DataSet ds = Bussiness.BaseAccountSubjectBLL.BaseSubjectTypeQuery(query);
			this.DataGrid1.DataSource= ds; 
			this.DataGrid1.DataBind();

		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			string cmdStr = "PImportBasencNCDoc" ;
			Bussiness.ComQuaryBLL.ExecuteProcedureNonParams(cmdStr);
			this.Label1.Text="更新成功";
		}
	}
}
