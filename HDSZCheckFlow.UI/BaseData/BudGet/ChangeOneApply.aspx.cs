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
	/// ChangeOneApply 的摘要说明。
	/// </summary>
	public class ChangeOneApply : System.Web.UI.Page
	{
		#region 
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox textYear;
		protected System.Web.UI.WebControls.TextBox txtMonth;
		protected System.Web.UI.WebControls.TextBox txtChangeMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlInputButton Button1;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.TextBox txtPosital;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack )
			{
				// 1. 此单简要信息,v_ApplySheetOfCompany , ?applyHeadPk
				int applyHeadPk = int.Parse(QueryStr("applyHeadPk"));

				// 输入月份 显示此科目金额信息
				//
				// 2. 此单所占科目金额信息
			}
		}

		private void BindApplyInfo()
		{
			int applyHeadPk = int.Parse(QueryStr("applyHeadPk"));

			// 1. 此单简要信息,v_ApplySheetOfCompany , ?applyHeadPk
			DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_ApplySheetOfCompany"," where applysheethead_pk = " + applyHeadPk + " ");




		}

		private string QueryStr(string filter)
		{

			if(Request.QueryString[filter]==null || Request.QueryString[filter].ToString() ==null)
			{
				return "";
			}
			else
			{
				return Request.QueryString[filter].ToString();
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
			this.Button1.ServerClick += new System.EventHandler(this.Button1_ServerClick);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			// 1.  根据 单据pk, 调整年月 ,查询出此科目的 预实算金额 .显示
			int applyHeadPk = int.Parse(QueryStr("applyHeadPk"));
			int month = int.Parse(this.txtMonth.Text); 

			Entiy.ApplySheetHead applySheet = Entiy.ApplySheetHead.Find(applyHeadPk);
			Entiy.ApplySheetHeadBudget applyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk) ;

			if(applySheet!=null)
			{
				BindBudgetInfo(applySheet.ApplyDate.Year ,month,applySheet.ApplyDeptCode,applyBudget.SheetSubject);//显示部门科目预算情况
			}

			// 2.  调整按钮可用
			this.btnSubmit.Enabled=true;

		}

	
		//显示部门科目预算情况
		private void BindBudgetInfo(int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			// 更改为按季度为判断标准
			//1.根据申请月份，得出当前所在季度
			//2.得到季度金额合计
			//3.判断标准添加考虑待摊金额

			this.Label2.Visible=true;
			this.Label3.Visible=true;
			//this.Label4.Visible=true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			this.Label8.Visible=true;
			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,dept.BudgetDeptCode,Sheetsubject );
				if(ds != null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(iYear,iMonth,applyDept,Sheetsubject);

					this.lblBudget.Text=ds.Tables[0].Rows[0]["budgetmoney"].ToString();
					this.lblPush.Text=ds.Tables[0].Rows[0]["planmoney"].ToString();
					this.lblChange.Text=ChangeMoney.ToString("N2") ; 
					this.lblSumCheck.Text=ds.Tables[0].Rows[0]["checkmoney"].ToString();
					this.lblready.Text  = ds.Tables[0].Rows[0]["readypay"].ToString();
					this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
					this.lblAlterMoney.Text = ds.Tables[0].Rows[0]["alterMoney"].ToString();
				
					//					//费用超支标准，预算或者推算。
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
					decimal leftmoney = 0 ; 
					if (budgetStandard == 1 )  //预算
					{
						leftmoney=decimal.Parse(this.lblBudget.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) - decimal.Parse(this.lblAlterMoney.Text) -decimal.Parse(this.lblready.Text);
					}
					else if(budgetStandard == 2 ) // 推算
					{
						leftmoney=decimal.Parse(this.lblPush.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) - decimal.Parse(this.lblAlterMoney.Text)  -decimal.Parse(this.lblready.Text);
					}
					this.lblLeft.Text=leftmoney.ToString("N2");
				}
			}
		}

		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					int applyHeadPk = int.Parse(QueryStr("applyHeadPk"));
					string userCode =  Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
					decimal thisChangeMoney = decimal.Parse(this.txtChangeMoney.Text);

					Entiy.ApplySheetHead applySheet = Entiy.ApplySheetHead.Find(applyHeadPk);
					Entiy.ApplySheetHeadBudget applyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

					Entiy.RealMoneyAlterSheet realMoneyAlert = new HDSZCheckFlow.Entiy.RealMoneyAlterSheet();
					realMoneyAlert.AlteredSheetHeadPk  = applyHeadPk ;
					realMoneyAlert.SheetDate           = DateTime.Today;
					realMoneyAlert.FirstSubjectCode    = applyBudget.SheetFirstClassSubject;
					realMoneyAlert.SubjectCode         = applyBudget.SheetSubject ;
					realMoneyAlert.BudgetDept          = applySheet.ApplyDeptCode ;
					realMoneyAlert.AlterYear           = applySheet.ApplyDate.Year;
					realMoneyAlert.AlterMonth          = int.Parse(this.txtMonth .Text);
					realMoneyAlert.AlterMoney          = thisChangeMoney;
					realMoneyAlert.Memo                = this.txtPosital.Text;
					realMoneyAlert.MarkerCode          = userCode;
					realMoneyAlert.IsSubmit            = 1 ;
					realMoneyAlert.Create();

					this.btnSubmit.Enabled= false;
					this.txtChangeMoney.Text="";
					this.txtPosital.Text="";

					//提交 占 预算 . 把此单的金额 ,加入已占预算

					//提交既占预算，更新预算表的已占用预算额
					//Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);
					if(applyBudget!=null )
					{
						Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applySheet.ApplyDate.Year ,applySheet.ApplyDate.Month ,applySheet.ApplyDeptCode,applyBudget.SheetSubject);
						decimal tempMoney=budgetAccount.CheckMoney ;
						budgetAccount.CheckMoney = budgetAccount.CheckMoney + thisChangeMoney ;
						budgetAccount.Update();
					}

					tran.VoteCommit();
					BindBudgetInfo(applySheet.ApplyDate.Year ,int.Parse(this.txtMonth.Text),applySheet.ApplyDeptCode,applyBudget.SheetSubject);//显示部门科目预算情况

				}
				catch(Exception ex)
				{
					tran.VoteRollBack();
					Common.Log.Logger.Log("ChangeOneApply.btnSubmit_Click",ex.Message );

				}
			}
		}

		private void Button1_ServerClick(object sender, System.EventArgs e)
		{
			//返回
			Response.Redirect("ChangeApplyOfBudget.aspx");
		}
	}
}
