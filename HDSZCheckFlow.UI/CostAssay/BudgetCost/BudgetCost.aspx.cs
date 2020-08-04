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
	/// BudgetCost 的摘要说明。
	/// </summary>
	public class BudgetCost : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				BindCost();
			}
		}

		private void BindCost()
		{
			int iYear,iMonth;
			DateTime dt;
			if(!"".Equals(this.txtDate.Text ))
			{
				dt=DateTime.Parse(this.txtDate.Text);
			}
			else
			{
				dt=DateTime.Now;
			}
			iYear = dt.Year;
			iMonth = dt.Month;

			DataSet ds= Bussiness.CostBLL.getCost(iYear,iMonth);
			this.DataGrid1.DataSource= ds;
			this.DataGrid1.DataBind();
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
			try
			{
				this.lblMessage.Text="";
				if(!"".Equals(this.txtDate.Text ))
				{
					BindCost();
				}
				else
				{
					this.lblMessage.Text="请输入查询年月！";
					this.lblMessage.ForeColor=Color.Red;
				}
			}
			catch
			{}
		}
	}
}
