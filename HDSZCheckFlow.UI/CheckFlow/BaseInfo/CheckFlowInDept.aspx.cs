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

namespace HDSZCheckFlow.UI.CheckFlow.BaseInfo
{
	/// <summary>
	/// CheckFlowInDept 的摘要说明。
	/// </summary>
	public class CheckFlowInDept : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckValid;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from  CheckFlowInDept order by DeptClassCode asc ,DeptCode asc ,CheckSetp asc ";
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
			this.btnCheckValid.Click += new System.EventHandler(this.btnCheckValid_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheckValid_Click(object sender, System.EventArgs e)
		{
			//检测所有科组的流程信息
			DataTable dtMessage=new DataTable();
			Bussiness.CheckFlowInDeptBLL.CheckAllFlowInDept(out dtMessage);
			this.DataGrid1.DataSource=dtMessage.DefaultView ;
			this.DataGrid1.DataBind();
		}
	}
}
