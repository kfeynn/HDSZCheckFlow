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
	/// BudgetCostCompare 的摘要说明。
	/// </summary>
	public class BudgetCostCompare : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnButton;
		protected System.Web.UI.WebControls.DropDownList ddlQuarter;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtYear;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				int type = 5 ;
				int iYear = DateTime.Now.Year;        // 默认当年
                int Querter = int.Parse(System.Math.Floor((double)(DateTime.Now.Month + 2) / 3).ToString());  
				BindBudgetDept() ;

				GetBudgetCompare(iYear,Querter,type,"");
			}
		}

		private void BindBudgetDept()
		{
			DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("Base_Budget_Dept","");
			this.ddlDept.DataSource = ds;
			this.ddlDept.DataValueField   = ds.Tables[0].Columns["budget_DeptCode"].ToString();
			this.ddlDept.DataTextField    = ds.Tables[0].Columns["budget_DeptName"].ToString();
			this.ddlDept.DataBind();
			this.ddlDept.Items.Insert(0,"");

		}

		private void  GetBudgetCompare(int iYear ,int Querter,int type,string budgetDept)
		{
			DataSet ds = Bussiness.CostBLL.GetBudgetCostCompare2(iYear,Querter,type,budgetDept);
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
			this.btnButton.Click += new System.EventHandler(this.btnButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnButton_Click(object sender, System.EventArgs e)
		{
			int type = 5 ;
			int iYear = DateTime.Now.Year;        // 默认当年
            int Querter = int.Parse(Math.Floor((double)(DateTime.Now.Month + 2) / 3).ToString()); 
			string budgetDept = "" ;

			if(!"".Equals(this.ddlType.SelectedValue) )
			{
				type = int.Parse(this.ddlType.SelectedValue);
			}
			budgetDept = this.ddlDept.SelectedValue ;

			if(this.txtYear.Text != "")
			{
				iYear = int.Parse(this.txtYear.Text);
			}
			if(this.ddlQuarter.SelectedValue !="")
			{
				Querter = int.Parse(this.ddlQuarter.SelectedValue);
			}
			GetBudgetCompare(iYear,Querter,type,budgetDept);

		}


	}
}
