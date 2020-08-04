//public class UsedMoneyListInfo_J : System.Web.UI.Page
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
	/// UsedMoneyListInfo 的摘要说明。
	/// </summary>
	public class UsedMoneyListInfo_J : System.Web.UI.Page
	{
		#region 
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Label lblBudgetDept;
		protected System.Web.UI.WebControls.Label lblYearMonth;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblCheckedMoney;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblReadypay;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.Label lblMessage;
		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//获取参数
			if(!Page.IsPostBack)
			{
				string budgetaccountpk =  getValueByParmes("budgetaccountpk");
				if(!"".Equals(budgetaccountpk))
				{
					BindBaseBudgetInfo(int.Parse(budgetaccountpk));
					BindApplyInfo(int.Parse(budgetaccountpk));
				}
			}
		}

		private void BindBaseBudgetInfo(int budgetaccountpk)
		{

			// 先取月份信息 ，然后找到对应季度信息
			Entiy.Budgetaccount budgetAccount = Entiy.Budgetaccount.Find(budgetaccountpk);
			if(budgetAccount!=null)
			{
				//绑定合计信息 
				string cmdStr = @"SELECT SUM(budgetMoney) AS budgetMoney, SUM(PlanMoney) AS PlanMoney,SUM(CheckMoney) AS CheckMoney, SUM(changeMoney) AS changeMoney,SUM(leftMoney) AS leftMoney,isnull(sum(readypay),0)  as readypay ,isnull(sum(alterMoney),0) as altermoney,isnull(sum(TotalAllowOutMoney),0) as TotalAllowOutMoney,NC_DeptName,subjectName,dispname FROM v_DeptBudgetInfo";
				
				string months = "";
				string jidu = "";
				if(budgetAccount.Imonth < 4 )
				{
					months = "(1,2,3)" ;
					jidu = "1" ; 
				}
				else if(budgetAccount.Imonth <7 && budgetAccount.Imonth >=4)
				{
					months = "(4,5,6)" ;
					jidu = "2" ; 
				}
				else if(budgetAccount.Imonth<10 && budgetAccount.Imonth >= 7)
				{
					months = "(7,8,9)" ;
					jidu = "3" ; 
				}
				else
				{
					months = "(10,11,12)" ;
					jidu = "4" ; 
				}

				string filter = " WHERE (Iyear = " + budgetAccount.Iyear + ") AND (Imonth IN " + months + ") AND (budget_DeptCode = '" + budgetAccount.DeptCode + "') AND (subjectCode = '" + budgetAccount.SubjectCode + "')" ; 

				if(filter .Length  > 0)
				{
					cmdStr = cmdStr +  filter ; 
					cmdStr = cmdStr + " group by NC_DeptName,subjectName ,dispname ";
				}
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;

				this.lblBudgetDept.Text   = ds.Tables[0].Rows[0]["NC_DeptName"].ToString(); 
				this.lblYearMonth.Text    = budgetAccount.Iyear.ToString() + " " + jidu.ToString(); 
				this.lblSubject.Text      = ds.Tables[0].Rows[0]["dispname"].ToString();
				this.lblBudget.Text       = ds.Tables[0].Rows[0]["budgetMoney"].ToString();
				this.lblPush.Text         = ds.Tables[0].Rows[0]["PlanMoney"].ToString();
				this.lblChange.Text       = ds.Tables[0].Rows[0]["changeMoney"].ToString();
				this.lblCheckedMoney.Text = ds.Tables[0].Rows[0]["CheckMoney"].ToString();
				this.lblLeft.Text         = ds.Tables[0].Rows[0]["leftMoney"].ToString();
				this.lblReadypay.Text     = ds.Tables[0].Rows[0]["readypay"].ToString();
				this.lblOutMoney.Text     = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
				this.lblAlterMoney.Text   = ds.Tables[0].Rows[0]["altermoney"].ToString();
			}

			#region 作废

			//显示预算等 信息 .
			//			DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_DeptBudgetInfo"," where budget_account_pk =" + budgetaccountpk + " ");
			//			this.lblBudgetDept.Text   = ds.Tables[0].Rows[0]["NC_DeptName"].ToString(); 
			//			this.lblYearMonth.Text    = ds.Tables[0].Rows[0]["Iyear"].ToString() + " " + ds.Tables[0].Rows[0]["Imonth"].ToString(); 
			//			this.lblSubject.Text      = ds.Tables[0].Rows[0]["subjectName"].ToString();
			//			this.lblBudget.Text       = ds.Tables[0].Rows[0]["budgetMoney"].ToString();
			//			this.lblPush.Text         = ds.Tables[0].Rows[0]["PlanMoney"].ToString();
			//			this.lblChange.Text       = ds.Tables[0].Rows[0]["changeMoney"].ToString();
			//			this.lblCheckedMoney.Text = ds.Tables[0].Rows[0]["CheckMoney"].ToString();
			//			this.lblLeft.Text         = ds.Tables[0].Rows[0]["leftMoney"].ToString();

			#endregion 
		}

		private void BindApplyInfo(int budgetaccountpk)
		{
			//显示此 科目的 单据信息 
			Entiy.Budgetaccount budgetAccount = Entiy.Budgetaccount.Find(budgetaccountpk);
			if(budgetAccount!=null)
			{
				#region 
				//				string filter = " where year(applydate) = " + budgetAccount.Iyear + " and month(applydate)=" + budgetAccount.Imonth + " and sheetsubject = '" + budgetAccount.SubjectCode + "' ";
				//				filter += " and applydeptcode in (SELECT DeptCode FROM Base_Dept WHERE (budget_DeptCode = '" + budgetAccount.DeptCode + "'))";
				//				filter += " and ApplyProcessCode not in (101,201)" ;
				//				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_ApplySheetOfCompany",filter);
				//				this.dgApply.DataSource = ds;
				//				this.dgApply.DataBind();
				#endregion 

				string filter = "" ; 
				string months = "";
				if(budgetAccount.Imonth < 4 )
				{
					months = "(1,2,3)" ;
				}
				else if(budgetAccount.Imonth <7 && budgetAccount.Imonth >=4)
				{
					months = "(4,5,6)" ;
				}
				else if(budgetAccount.Imonth<10 && budgetAccount.Imonth >= 7)
				{
					months = "(7,8,9)" ;
				}
				else
				{
					months = "(10,11,12)" ;
				}

				filter = " where year(applydate) = " + budgetAccount.Iyear + " and month(applydate)  in " + months + " and sheetsubject = '" + budgetAccount.SubjectCode + "' ";
				filter += " and applydeptcode in (SELECT DeptCode FROM Base_Dept WHERE (budget_DeptCode = '" + budgetAccount.DeptCode + "'))";
				filter += " and ApplyProcessCode not in (101,201)" ;
				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_ApplySheetOfCompany",filter);
				this.dgApply.DataSource = ds;
				this.dgApply.DataBind();

			}
			else
			{
				this.dgApply.DataSource= null;
				this.dgApply.DataBind();
			}
		}

		private string getValueByParmes(string Parmes)
		{
			if(Request.QueryString[Parmes] != null && Request.QueryString[Parmes].ToString() !="")
			{
				return Request.QueryString[Parmes].ToString();
			}
			else
			{
				return "";
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
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals("look")) //点击审批按钮
				{
					DataSet ds = Bussiness.RealMoneyAlterSheetBLL.GetRealMoneyAlterByApplyHeadPk(int.Parse(e.Item.Cells[0].Text));
					this.DataGrid1.DataSource= ds; 
					this.DataGrid1.DataBind();

					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						{
							this.dgApply.Items[i].BackColor= color;
						}
					}
					color=e.Item.BackColor;
					e.Item.BackColor=Color.Yellow;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UsedMoneyListInfo.dgApply_ItemCommand",ex.Message );
			}
		}
	}
}
