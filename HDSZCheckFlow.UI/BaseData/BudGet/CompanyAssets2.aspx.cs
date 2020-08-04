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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// DeptAssets 的摘要说明。
	/// </summary>
	public class CompanyAssets2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DataGrid dgBudgetInfo;

		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblUsed;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.Label lblReadypay;
		protected System.Web.UI.WebControls.DropDownList ddlQuarter;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblLeft;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				bindGrid();
			}
		}

		private void BindSumInfo()
		{
			try
			{
				//绑定合计信息 
				string cmdStr = @"SELECT SUM(budgetMoney) AS budgetMoney, SUM(PlanMoney) AS PlanMoney, 
										SUM(CheckMoney) AS CheckMoney, SUM(changeMoney) AS changeMoney, 
										SUM(leftMoney) AS leftMoney,sum(readypay) as readypay,sum(TotalAllowOutMoney) as TotalAllowOutMoney
									FROM v_DeptBudgetInfo";
				string filter = GetQuerySqlString() ; 
				if(filter .Length  > 0)
				{
					cmdStr = cmdStr + " where " + filter ; 
				}
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
				if(ds!=null & ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
				{
					this.lblBudget.Text  = decimal.Parse(ds.Tables[0].Rows[0]["budgetMoney"].ToString()).ToString("#,###.##");
					this.lblPush.Text    = decimal.Parse(ds.Tables[0].Rows[0]["PlanMoney"].ToString()).ToString("#,###.##");
					this.lblChange.Text  = decimal.Parse( ds.Tables[0].Rows[0]["changeMoney"].ToString()).ToString ("#,###.##");
					this.lblUsed.Text    = decimal.Parse(ds.Tables[0].Rows[0]["CheckMoney"].ToString()).ToString ("#,###.##");
					this.lblLeft.Text    = decimal.Parse(ds.Tables[0].Rows[0]["leftMoney"].ToString()).ToString("#,###.##");
					this.lblReadypay.Text  = ds.Tables[0].Rows[0]["readypay"].ToString(); 
					this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
				}
			}
			catch{}
		}

		private void bindGrid()
		{
			string cmdStr = @"SELECT Iyear, Imonth, budget_DeptCode, NC_DeptName, SUM(budgetMoney) 
								AS budgetMoney, SUM(PlanMoney) AS PlanMoney, SUM(CheckMoney) 
								AS CheckMoney, SUM(InMoney) AS InMoney, SUM(OutMoney) AS OutMoney, 
								SUM(changeMoney) AS changeMoney,sum(altermoney) as alterMoney, SUM(leftMoney) AS leftMoney,sum(readypay) as readypay ,sum(TotalAllowOutMoney) as TotalAllowOutMoney 
							FROM v_DeptBudgetInfo
							GROUP BY Iyear, Imonth, budget_DeptCode, NC_DeptName
							HAVING ";
			string filter =  GetQuerySqlString() ;

			cmdStr = cmdStr + filter ;

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			this.dgBudgetInfo.DataSource = ds;
			this.dgBudgetInfo.DataBind();

			BindSumInfo();

		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtDate.Text ))
			{
				try
				{
					int iyear = int.Parse(this.txtDate.Text) ;
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append (" iyear = " + iyear + " ");
				}
				catch
				{
				}
			}

			if(this.ddlQuarter.SelectedValue != "0" )
			{
				//整理季度 
				string months = "";
				if(this.ddlQuarter.SelectedValue == "1")
				{
					months = " ( 1,2,3 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "2")
				{
					months = " ( 4,5,6 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "3")
				{
					months = " ( 7,8,9 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "4")
				{
					months = " ( 10,11,12 ) ";
				}

				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append (" imonth in    " + months + " " );		
			}





			if (filter.Length <= 0)
			{
				filter.Append ( "  iyear = " + DateTime.Now.Year  + " and imonth = " + DateTime.Now.Month  + " ");
			}

	
			string returnValue=filter.ToString();
			return returnValue;
			#endregion  
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
			bindGrid();
		}
		
	}
}
