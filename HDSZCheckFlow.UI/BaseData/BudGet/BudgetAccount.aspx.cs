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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// BudgetAccount 的摘要说明。
	/// </summary>
	public class BudgetAccount : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//this.XPGrid1.CommandText="select * from budget_account order by  Iyear desc, Imonth desc,deptCode asc";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//查询 , 计算调整金额,
			//此页计算公司全部信息 
			string strData=this.txtData.Text;
			if("".Equals(strData))
			{
				this.lblMessage.Text="请选择年月查询!";
				return ;
			}
			DateTime date = DateTime.Parse(strData);

			//更新调整字段的值
			Bussiness.BudgetAccountBLL.UpdateAccountChange(date.Year,date.Month);

			this.XPGrid1.CommandText="select * from budget_account where Iyear= " + date.Year  + " and Imonth= " + date.Month  + " order by  deptCode asc";
			this.XPGrid1.DataBind();

		}
	}
}
