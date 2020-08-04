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
using AjaxPro;

namespace HDSZCheckFlow.UI.CheckFlow.Evection
{
	/// <summary>
	/// AddApplySheet 的摘要说明。
	/// </summary>
	public class AddBanquet : System.Web.UI.Page
	{
		#region  属性
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlSubject;
		protected System.Web.UI.WebControls.TextBox txtPerson;
		protected System.Web.UI.WebControls.TextBox txtPersonName;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;//记录此次添加的表头PK
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnOutConrt;
		protected System.Web.UI.WebControls.Button btnInConrt;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.DropDownList ddlFirstSubject;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label lblAnnexMsg;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenLeft;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Panel panel1;
		protected System.Web.UI.WebControls.Button btnCCSave;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected XPGrid.XpGrid XpGrid1;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlEvection;
		protected System.Web.UI.WebControls.Button btnEditEvection;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtVisitCompany;
		protected System.Web.UI.WebControls.TextBox txtCallinPerson;
		protected System.Web.UI.WebControls.TextBox txtCallinMemo;
		protected System.Web.UI.WebControls.TextBox txtTalkPlace;
		protected System.Web.UI.WebControls.TextBox txtVisitDept;
		protected System.Web.UI.WebControls.TextBox txtVisitPerson;
		protected System.Web.UI.WebControls.TextBox txtRelationDept;
		protected System.Web.UI.WebControls.TextBox txtLookNum;
		protected System.Web.UI.WebControls.TextBox txtOtherNeed;
		protected System.Web.UI.WebControls.TextBox txtEspecialRequest;
		protected System.Web.UI.WebControls.CheckBox chbTea;
		protected System.Web.UI.WebControls.CheckBox chblookFactory;
		protected System.Web.UI.WebControls.CheckBox chbLunch;
		protected System.Web.UI.WebControls.TextBox txtvisitphone;
		protected System.Web.UI.WebControls.CheckBox  chbjie;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.Label Label10;

		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddEvection));
		
			if(!Page.IsPostBack)
			{
				darkControls() ;

				InitPageForAdd();
				bindMyYQinfo();
			}
		}

		private void darkControls()
		{				
			#region 灰掉按钮

			this.ddlApplyType.Enabled = false;
			this.ddlDept.Enabled = false ;
			this.ddlDeptClass.Enabled =false; 
			this.ddlFirstSubject.Enabled= false ;
			this.ddlSubject.Enabled = false ;
			this.txtDate.Enabled = false ;
			this.txtPerson.Enabled=false ;

			this.ddlApplyType.BackColor= Color.LightGray;
			this.ddlDept.BackColor = Color.LightGray;
			this.ddlDeptClass.BackColor = Color.LightGray;
			this.ddlFirstSubject.BackColor=  Color.LightGray;
			this.ddlSubject.BackColor =  Color.LightGray;
			this.txtDate.BackColor =  Color.LightGray;
			this.txtPerson.BackColor= Color.LightGray;
			this.txtPersonName.BackColor = Color.LightGray;

			this.btnSave.Enabled=false;
			this.btnEdit.Enabled=false;

			#endregion 

		}

		private void bindMyYQinfo()
		{
			//绑定属于我的出差单据

			// 1.单据属于本部门

			// 2.单据未提交 或者 为取回状态   

			//这里改为读配置文件，获取招待申请类型编码(2011-07-29 liyang) 
			string BanquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"];

			string personCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

			string cmdStr = "SELECT ApplySheetHead.ApplySheetNo  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode and  (ApplyTypeCode = '"+BanquetCode+"') AND (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
				" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
				" WHERE personCode = '" + personCode + "'))) AND " +
				"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL)  AND (ApplyProcessType.IsSubmit = 0)" +
				" ORDER BY ApplySheetHead.ApplyDate DESC";

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
			this.ddlEvection.DataSource= ds;
			this.ddlEvection.DataTextField  =ds.Tables[0].Columns["ApplySheetNo"].ToString();
			this.ddlEvection.DataValueField =ds.Tables[0].Columns["ApplySheetNo"].ToString();
			this.ddlEvection.DataBind();
			this.ddlEvection.Items.Insert(0,"");

		}
		
		#region  初始化下拉菜单
		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeForBanquet  (deptClassCode);
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlApplyType.DataSource =dtType;
					ddlApplyType.DataValueField=dtType.Columns[0].ToString();
					ddlApplyType.DataTextField=dtType.Columns [1].ToString();

					ddlApplyType.DataBind();
					ddlApplyType.Items.Insert(0,"");
					dtType=null;
				}

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

				string budgetDept = Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(budgetDept); //一级科目
				if(dtSubject!=null && dtSubject.Rows.Count >0)
				{
					this.ddlFirstSubject.DataSource=dtSubject;
					ddlFirstSubject.DataValueField=dtSubject.Columns[0].ToString();
					ddlFirstSubject.DataTextField =dtSubject.Columns[1].ToString();
					ddlFirstSubject.DataBind();
					ddlFirstSubject.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}
		#endregion

		#region  ajax方法,供页面查询用户姓名
		[AjaxMethod()]
		public string  GetUserNameByCode(string personCode)
		{
			try
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person!=null)
				{
					return person.Name;
				}
				else
				{
					return "";
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
				return "";
			}
		}
		#endregion 

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
			this.btnInConrt.Click += new System.EventHandler(this.btnInConrt_Click);
			this.btnOutConrt.Click += new System.EventHandler(this.btnOutConrt_Click);
			this.btnEditEvection.Click += new System.EventHandler(this.btnEditEvection_Click);
			this.ddlApplyType.SelectedIndexChanged += new System.EventHandler(this.ddlApplyType_SelectedIndexChanged);
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.ddlFirstSubject.SelectedIndexChanged += new System.EventHandler(this.ddlFirstSubject_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnCCSave.Click += new System.EventHandler(this.btnCCSave_Click);
			this.XpGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XpGrid1_BeforeUpdateData);
			this.XpGrid1.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XpGrid1_AfterUpdate);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//this.Hidden2 是否为修改
			this.Hidden2.Value= "0" ;
			this.panel1.Visible=false;
			this.btnInConrt.Enabled= false;
			this.btnOutConrt.Enabled=false;

			#region 
			this.ddlApplyType.SelectedIndex  = 0 ;
			//this.ddlDept.SelectedIndex  = 0 ;
			this.ddlDeptClass.SelectedIndex  =0; 
			this.ddlFirstSubject.SelectedIndex = 0 ;
			//this.ddlSubject.SelectedIndex  = 0 ;
			this.txtDate.Text  = "" ;
			this.txtPerson.Text ="" ;
			this.Label9.Text= "";
			this.Label10.Text="";

			this.ddlApplyType.Enabled = true ;
			this.ddlDept.Enabled = true ;
			this.ddlDeptClass.Enabled =true; 
			this.ddlFirstSubject.Enabled= true ;
			this.ddlSubject.Enabled = true ;
			this.txtDate.Enabled = true ;
			this.txtPerson.Enabled=true ;

			this.ddlApplyType.BackColor= Color.White ;
			this.ddlDept.BackColor =Color.White ;
			this.ddlDeptClass.BackColor = Color.White ;
			this.ddlFirstSubject.BackColor=  Color.White;
			this.ddlSubject.BackColor =  Color.White;
			this.txtDate.BackColor =  Color.White;
			this.txtPerson.BackColor= Color.White;

			this.lblBudget.Text="";
			this.lblPush.Text="";
			this.lblChange.Text="";
			this.lblSumCheck.Text="";
			this.lblSheetMoney.Text="";
			this.lblLeft.Text="";

			this.btnAdd.Enabled=false;
			this.btnEdit.Enabled=false;
			this.btnSave.Enabled=true;

			#endregion 
	
		}


		//显示部门科目预算情况
		private void BindBudgetInfo(int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			
			#region 
			this.Label2.Visible=true;
			this.Label3.Visible=true;
			this.Label4.Visible =true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			this.Label8.Visible=true;
			this.Label11.Visible = true;
			this.Label13.Visible =true;
			#endregion 
			// 更改为按季度为判断标准
			//1.根据申请月份，得出当前所在季度
			//2.得到季度金额合计
			//3.判断标准添加考虑待摊金额
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
						leftmoney=decimal.Parse(this.lblBudget.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)   - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text);
					}
					else if(budgetStandard == 2 ) // 推算
					{
						leftmoney=decimal.Parse(this.lblPush.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text);
					}
					this.lblLeft.Text=leftmoney.ToString("N2");
					//给全局变量 
					this.HiddenLeft.Value= leftmoney.ToString();
				}
			}

			#region  作废
			//			Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(iYear,iMonth,applyDept,Sheetsubject);
			//			if(budgetAccount!=null)
			//			{				
			//				decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(iYear,iMonth,applyDept,Sheetsubject);
			//
			//				this.lblBudget.Text=budgetAccount.BudgetMoney.ToString();
			//				this.lblPush.Text=budgetAccount.PlanMoney .ToString("#,###.##");
			//				this.lblChange.Text=ChangeMoney.ToString("#,###.##");
			//				this.lblSumCheck.Text=budgetAccount.CheckMoney.ToString("#,###.##");
			//				
			//				//费用超支标准，预算或者推算。
			//				int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
			//				decimal leftmoney = 0 ; 
			//				if (budgetStandard == 1 )  //预算
			//				{
			//					leftmoney=budgetAccount.BudgetMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				else if(budgetStandard == 2 ) // 推算
			//				{
			//					leftmoney=budgetAccount.PlanMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				this.lblLeft.Text=leftmoney.ToString("#,###.##");
			//				//leftMoney = leftmoney ;  //给全局变量 
			//				this.HiddenLeft.Value= leftmoney.ToString();
			//			}
			#endregion 
		}


		#region 绑定科组
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//绑定科组
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlDeptClass.SelectedValue;
			DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassForAdd(deptClass);
			if(dtDept!=null && dtDept.Rows.Count>0)
			{
				this.ddlDept.DataSource=dtDept;
				ddlDept.DataValueField=dtDept.Columns[0].ToString();
				ddlDept.DataTextField =dtDept.Columns[1].ToString();
				ddlDept.DataBind();
				ddlDept .Items.Insert(0,"");
			}		
			else
			{
				this.ddlDept.DataSource=null;
				ddlDept.DataBind();
			}
		}
		#endregion 

		private void SetButtonsEnable(int key)
		{			
			// 1 紧急审批可用， < 3000 
			// 2 预算内可用
			// 3 预算外可用
			// 4 紧急 and 预算内 可用
			// 5 紧急 and 预算外 可用
			// 6 已所定，全不可用
			// 7 没有表体，不可用
			// 8 出现错误
			int Na;
			int i=Bussiness.ApplySheetHeadBLL.SetButtonEnable(key,out Na);
			switch(i)
			{
				case 2:
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					break;
				case 3:
					this.btnOutConrt.Enabled=true;
					this.btnInConrt.Enabled=false;
					break;
				case 4:
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					break;
				case 5:
					this.btnOutConrt.Enabled=true;
					this.btnInConrt.Enabled=false;
					break;
				case 6:
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 7:
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 8:
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
			}
		}

		//更新申请单表头进程状态为提交
		private void updatePross(int ApplySheetHeadPk)
		{
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplySheetHeadPk);
			if(applyHead!=null)
			{
				applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.SubmitPross;
				applyHead.Update();
			}
		}


		#region 提交按钮
		private void btnPress_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);
					//紧急审批
					string pressCode=System.Configuration.ConfigurationSettings.AppSettings["PressCode"];

					Entiy.CheckFlowInCompanyhead checkFlow=Entiy.CheckFlowInCompanyhead.FindByFlowCode(pressCode); //紧急流程Code
					if(checkFlow!=null)
					{

						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{				
							//更新当前审批角色,未找到审批角色写日志, 说明部门内流程有问题
//							string Message="";
//							int CheckStep=0,DeptToCompany=0 ;
//							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//							if(!"".Equals(checkRole))
//							{

							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
							if(IsGiveUp ==1 )
							{
								//此用户放弃审批,循环调用方法本身;

								
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
								Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//								Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
							}

							else if(!"".Equals(checkRole) && IsGiveUp == 0 )
							{
								applyHead.CurrentCheckRole=checkRole;

								applyHead.CheckFlowInCompanyHeadPk =checkFlow.CheckFlowInCompanyHeadPk ;

								applyHead.CheckSetp=CheckStep;

								applyHead.Update();

								// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
								//根据工号发邮件            发邮件(方法2)
								//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								//								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
								//
								//
								//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//								mailBll.ThreadSendMail();

								updatePross(key);

								//提交既占预算，更新预算表的已占用预算额
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									decimal tempMoney=budgetAccount.CheckMoney ;
									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["PressType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急
									applyHeadBudget.Update();
								}
							}
							else
							{
								this.lblMsg.Text="未设置相关审批角色";
								HDSZCheckFlow.Common.Log.Logger.Log("提交紧急审批","没有找到相关审批角色");
							}
						}
					}
					else
					{
						this.lblMsg.Text="未设置相关流程!!!!";
					}
				
					SetButtonsEnable(key);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet",ex.Message);
			}
			
		}

		private void btnInConrt_Click(object sender, System.EventArgs e)
		{
//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
//			{

				try
				{
					if(!"".Equals(this.Hidden1.Value ))
					{
						int key =int.Parse(this.Hidden1.Value);
						//更新流程信息
						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{
							// 先看单据是否已经是提交状态
							string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

							if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
							{
								this.lblMessage .Text = "此单已经提交过!请不要重复提交";
								return ;
							}

							/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
							///

							DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
							if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
							{
								this.lblMessage.Text ="此单余额信息有误，不能提交";
								return;
							}
							

							



							///////////////////////////////////////////END////////////////////////////////////////////////////

							#region 
							string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
							decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //本次审批金额

							

							////////////////////取流程//////////////////
							
							//总经理招待费 流程固定为 72 。副总审批
							Entiy.ApplyTypeInCheckFlow TypeInFlow= null; 

							string jingliCode = System.Configuration.ConfigurationSettings.AppSettings["ZongJingLiCode"];
							string jingliCheckFlow = System.Configuration.ConfigurationSettings.AppSettings["ZongJingLiCheckFlow"];

							if(this.txtPerson.Text.Trim() == jingliCode)
							{
								TypeInFlow = Entiy.ApplyTypeInCheckFlow.Find(int.Parse(jingliCheckFlow));
							}
							else
							{
								TypeInFlow = Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
							}

//							Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
							if(TypeInFlow!=null)
							{
								//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
//								string Message="";
//								int CheckStep=0,DeptToCompany=0 ;
//								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//								if(!"".Equals(checkRole))
//								{
								string Message="",	NextCheckCode ="";
								int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
								if(!"".Equals(checkRole)  )
								{
									applyHead.CurrentCheckRole=checkRole;
									applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
									applyHead.CheckSetp=CheckStep;
							
									applyHead.Update();

									// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

									string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
									//根据工号发邮件            发邮件(方法2)
								

								
									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
//
//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//
//									mailBll.ThreadSendMail();
									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);



									updatePross(key);   //更新流程状态

									//提交既占预算，更新预算表的已占用预算额
									Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
									if(applyHeadBudget!=null )
									{
										Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
										// 以前的审计金额为季度累计审计金额
										Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
										DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

										decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
										
										decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //允许的预算外金额
										ds = null; 

										budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
										budgetAccount.Update();
										applyHeadBudget.SumCheckMoney = tempMoney ;
										string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
										applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急
										applyHeadBudget.AllowOutMoney = AllowOutMoney ; 


										applyHeadBudget.Update();
									}

													
									if(IsGiveUp ==1 )
									{
										//此用户放弃审批,循环调用方法本身;

										Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
										Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//										Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
									}
									else
									{
										//根据工号发邮件            发邮件(方法2)
								
//
//										Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//										mailBll.ThreadSendMail();
									}

								}
								else
								{
									Response.Write(Message);
									HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
								}
							}
							else
							{
								Response.Write("未设置相关流程!!!!!!!");
							}
							#endregion 

						}
//						tran.VoteCommit();
						SetButtonsEnable(key);
					}
				}
				catch(Exception ex)
				{
//					tran.VoteRollBack();
					HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet",ex.Message);
				}
//			}

		}

		private void btnOutConrt_Click(object sender, System.EventArgs e)
		{
//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
//			{

				try
				{
					if(!"".Equals(this.Hidden1.Value ))
					{
						int key =int.Parse(this.Hidden1.Value);

						//更新流程信息
						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{
							// 先看单据是否已经是提交状态
							string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

							if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
							{
								this.lblMessage .Text = "此单已经提交过!请不要重复提交";
								return ;
							}

							/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
							///

							DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
							if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
							{
								this.lblMessage.Text ="此单余额信息有误，不能提交";
								return;
							}
							

							



							///////////////////////////////////////////END////////////////////////////////////////////////////

							#region 
							Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(key);
							decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //本次审批金额


							string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);


							////////////////////////////////////
							Entiy.ApplyTypeInCheckFlow TypeInFlow= null; 


							string jingliCode = System.Configuration.ConfigurationSettings.AppSettings["ZongJingLiCode"];
							string jingliCheckFlow = System.Configuration.ConfigurationSettings.AppSettings["ZongJingLiCheckFlow"];

							if(this.txtPerson.Text.Trim() == jingliCode)
							{
								TypeInFlow = Entiy.ApplyTypeInCheckFlow.Find(int.Parse(jingliCheckFlow));
							}
							else
							{
								TypeInFlow = Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
							}

//							Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
						/////////////////////////////////////
							if(TypeInFlow!=null)
							{
								//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
//								string Message="";
//								int CheckStep=0,DeptToCompany=0 ;
//								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//								if(!"".Equals(checkRole))
//								{
								string Message="",	NextCheckCode ="";
								int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
								if(!"".Equals(checkRole) )
								{
									applyHead.CurrentCheckRole=checkRole;
									applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
									applyHead.CheckSetp=CheckStep;
									applyHead.Update();

									// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

									string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
									//根据工号发邮件            发邮件(方法2)

							
									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//									mailBll.ThreadSendMail();


									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);


									updatePross(key);

									//提交既占预算，更新预算表的已占用预算额
									Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
									if(applyHeadBudget!=null )
									{
										Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
										//decimal tempMoney=budgetAccount.CheckMoney ;
										Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
										DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

										decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
										ds = null; 

									//	decimal AllowOutMoney = budgetAccount.TotalAllowOutMoney;   //允许的预算外金额

										budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
										budgetAccount.Update();
										applyHeadBudget.SumCheckMoney = tempMoney ;
										string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
										applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急

										//applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

										applyHeadBudget.Update();
									}
									if(IsGiveUp ==1 )
									{
										//此用户放弃审批,循环调用方法本身;
										Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
										Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//										Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
									}
									else
									{
										//根据工号发邮件            发邮件(方法2)
								

//										Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//										mailBll.ThreadSendMail();
									}

								}

												
							
						
							}
							else
							{
								Response.Write("未设置相关流程!!!!!");
							}
							#endregion 
						}
//						tran.VoteCommit();
						SetButtonsEnable(key);
					}
				}
				catch(Exception ex)
				{
//					tran.VoteRollBack();
					HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet",ex.Message);
				}
//			}
		}

		#endregion  

		private void ddlFirstSubject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//选择了一级科目后,帮定子级科目

			//绑定科组
			this.ddlSubject.Items.Clear();
			string firstSubject=this.ddlFirstSubject.SelectedValue;
			string budgetDept =Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			string applyTypeCode = this.ddlApplyType.SelectedValue ;
			DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
			if(dtSubject!=null && dtSubject.Rows.Count>0)
			{
				this.ddlSubject .DataSource=dtSubject;
				ddlSubject.DataValueField=dtSubject.Columns[0].ToString();
				ddlSubject.DataTextField =dtSubject.Columns[1].ToString();
				ddlSubject.DataBind();
				ddlSubject .Items.Insert(0,"");
			}		
			else
			{
				this.ddlSubject.DataSource=null;
				ddlSubject.DataBind();
			}
		}

		private void ddlApplyType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		

			//绑定科组
			this.ddlSubject.Items.Clear();
			string firstSubject=this.ddlFirstSubject.SelectedValue;
			string budgetDept =Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			string applyTypeCode = this.ddlApplyType.SelectedValue ;
			DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
			if(dtSubject!=null && dtSubject.Rows.Count>0)
			{
				this.ddlSubject .DataSource=dtSubject;
				ddlSubject.DataValueField=dtSubject.Columns[0].ToString();
				ddlSubject.DataTextField =dtSubject.Columns[1].ToString();
				ddlSubject.DataBind();
				ddlSubject .Items.Insert(0,"");
			}		
			else
			{
				this.ddlSubject.DataSource=null;
				ddlSubject.DataBind();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			
			#region  添加功能 
			this.lblMessage.Text="";
			try
			{
				//1. 生成定单号
				string applyNo="";
				string applyType=this.ddlApplyType.SelectedValue;
				DateTime  applyDate=new DateTime();
				if(!"".Equals(txtDate.Text))
				{
					applyDate=DateTime.Parse(txtDate.Text);
					//申请日期不能小于 当前月份............
					if(applyDate.Year < DateTime.Today.Year || (applyDate.Year == DateTime.Today.Year && applyDate.Month < DateTime.Today.Month) )
					{
						this.lblMessage.Text= "申请日期不能为以前月份！";
						return ;
					}
				}
				string applyDeptClass=this.ddlDeptClass.SelectedValue;
				string applyDept=this.ddlDept.SelectedValue;
				string applySubject=this.ddlSubject.SelectedValue;
				string personCode=this.txtPerson.Text;
				string firstSubject=this.ddlFirstSubject.SelectedValue;
				string  DeliveryDate="";

				#region 
				if("".Equals(applyType))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="类型不能为空";
					return;
				}
				if("".Equals(txtDate.Text))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请日期不能为空";
					return;
				}
				if("".Equals(applyDeptClass))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请部门不能为空";
					return;
				}
				if("".Equals(applyDept))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请科组不能为空";
					return;
				}
				if("".Equals(firstSubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="一级科目不能为空";
					return;
				}
				if("".Equals(applySubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请科目不能为空";
					return;
				}


				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person==null)
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="人员不存在";
					return ;
				}
				#endregion 

				#region 生成单据号
				//1.取前缀
				Entiy.ApplyType applyTyp=Entiy.ApplyType.Find(applyType);
				if(applyTyp!=null)
				{
					applyNo=applyTyp.ApplySheetEncode ;
				}
				else
				{
					Page.RegisterClientScriptBlock("a","<scrpit language='JavaScript'>alert('生成单据号错误!');</scrpit>");
					return ;
				}
				//2.取年月
				int iYear=applyDate.Year;
				int iMonth=applyDate.Month;
				string tempMonth=iMonth.ToString();
				for(int iLength=iMonth.ToString().Length ;iLength<2;iLength++)
				{
					tempMonth="0"+tempMonth;
				}
				applyNo += iYear.ToString();
				applyNo += tempMonth;

				//3.取流水号
				string  MaxNum1=Bussiness.ApplySheetHeadBLL.GetMaxSheetNo(applyNo);
				int MaxNum=0;
				if(!"".Equals(MaxNum1))
				{
					MaxNum=int.Parse(MaxNum1.Trim());
				}
				MaxNum += 1;
				string applyMaxNum=MaxNum.ToString();

				for(int iLength=MaxNum.ToString().Length ;iLength<5;iLength++)
				{
					applyMaxNum="0"+applyMaxNum;
				}
				//4.合并单据号
				applyNo = applyNo + applyMaxNum;
				#endregion 

				string personMakerCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));

				if(!"1".Equals(this.Hidden2.Value))   // 非更新状态 
				{
					Entiy.ApplySheetHead applySheet=new HDSZCheckFlow.Entiy.ApplySheetHead();
					applySheet.ApplySheetNo=applyNo;
					applySheet.ApplyTypeCode=applyType;
					applySheet.ApplyDate=applyDate;
					applySheet.ApplyDeptClassCode =applyDeptClass;
					applySheet.ApplyDeptCode=applyDept;
					//applySheet.SheetSubject =applySubject;
					applySheet.ApplyPersonCode=personCode ;
					applySheet.ApplyMakerCode=personMakerCode;
					applySheet.DeliveryDate = DeliveryDate ;
					applySheet.SubmitDate = System.DateTime.Now;         // 提交时间为系统当前时间
					applySheet.ExpenseDate  = DateTime.Parse("1900-01-01"); //报销日期 给默认日期


					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态

					applySheet.Create();


					//添加ApplySheetHead_Budget 表
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);

					Entiy.ApplySheetHeadBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.ApplySheetHeadBudget();
					if(applyHead!=null)
					{
						ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
						ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
						ApplyHeadBudget.SheetSubject=applySubject;
						ApplyHeadBudget.Create();
					}

					this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //记录此次添加的表头PK
					
					//找到相关表体  ApplyType  申请单据类型表
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XpGrid1.CommandText="select * from ApplySheetBody_Pay  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XpGrid1.DataBind();
					
						//添加附件可用
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "../CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;

					}

					this.Label9.Text= applyNo ;                                 //显示单据号
					this.Label10.Text=System.DateTime.Now.ToString();

				}
				else                                   // 更新状态 
				{
					Entiy.ApplySheetHead applySheet=HDSZCheckFlow.Entiy.ApplySheetHead.Find(int.Parse(this.Hidden1.Value));
					//applySheet.ApplySheetNo=applyNo;
					//applySheet.ApplyTypeCode=applyType;
					applySheet.ApplyDate=applyDate;
					applySheet.ApplyDeptClassCode =applyDeptClass;
					applySheet.ApplyDeptCode=applyDept;
					applySheet.ApplyPersonCode=personCode ;
					applySheet.ApplyMakerCode=personMakerCode;

					applySheet.DeliveryDate = DeliveryDate ;
					applySheet.SubmitDate = System.DateTime.Now;         // 提交时间为系统当前时间

					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态

					applySheet.Update();


					//添加ApplySheetHead_Budget 表
					
					Entiy.ApplySheetHeadBudget ApplyHeadBudget=HDSZCheckFlow.Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(this.Hidden1.Value));

					ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
					ApplyHeadBudget.SheetSubject=applySubject;
					ApplyHeadBudget.Update ();
					
					//找到相关表体  ApplyType  申请单据类型表
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						//						this.XPGrid1.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + this.Hidden1.Value + " ";  //" + applyHead.ApplySheetHeadPk + "
						//						this.XPGrid1.DataBind();
					
						//添加附件可用
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "../CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applySheet.ApplySheetHeadPk.ToString()   ;

					}

					this.Label9.Text= applySheet.ApplySheetNo ;                                 //显示单据号
					this.Label10.Text=System.DateTime.Now.ToString();


				}

				this.lblMessage.ForeColor=Color.Blue;
				this.lblMessage.Text="添加成功";
				//若没有部门科目记录,则初始化一个空值
				string message="";
				Bussiness.BudgetAccountBLL.SaveBudgetAccount(applyDate.Year,applyDate.Month,applyDept,applySubject,out message);
				if(!"".Equals(message))
				{
					this.lblMessage.Text=message;
				}
				
				BindBudgetInfo(applyDate.Year,applyDate.Month,applyDept,applySubject);//显示部门科目预算情况

				
 
				this.Label1.Visible=true;
			
				this.btnAdd.Enabled=true;
				this.btnEdit.Enabled=true;
				this.btnSave.Enabled=false;

				this.ddlApplyType.Enabled = false;
				this.ddlDept.Enabled = false ;
				this.ddlDeptClass.Enabled =false; 
				this.ddlFirstSubject.Enabled= false ;
				this.ddlSubject.Enabled = false ;
				this.txtDate.Enabled = false ;
				this.txtPerson.Enabled=false ;

				this.ddlApplyType.BackColor= Color.LightGray;
				this.ddlDept.BackColor = Color.LightGray;
				this.ddlDeptClass.BackColor = Color.LightGray;
				this.ddlFirstSubject.BackColor=  Color.LightGray;
				this.ddlSubject.BackColor =  Color.LightGray;
				this.txtDate.BackColor =  Color.LightGray;
				this.txtPerson.BackColor= Color.LightGray;
				this.txtPersonName.BackColor = Color.LightGray;

				this.panel1.Visible= true;

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message);
			}
			#endregion 
	
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			#region 

			//this.ddlApplyType.Enabled = true ;
			this.ddlDept.Enabled = true ;
			this.ddlDeptClass.Enabled =true; 
			this.ddlFirstSubject.Enabled= true ;
			this.ddlSubject.Enabled = true ;
			this.txtDate.Enabled = true ;
			this.txtPerson.Enabled=true ;

			//this.ddlApplyType.BackColor= Color.White ;
			this.ddlDept.BackColor =Color.White ;
			this.ddlDeptClass.BackColor = Color.White ;
			this.ddlFirstSubject.BackColor=  Color.White;
			this.ddlSubject.BackColor =  Color.White;
			this.txtDate.BackColor =  Color.White;
			this.txtPerson.BackColor= Color.White;

			this.btnAdd.Enabled=false;
			this.btnEdit.Enabled=false;
			this.btnSave.Enabled=true;

			#endregion 
			//表示为修改状态
			this.Hidden2.Value = "1" ; 
		
		}

		private void btnCCSave_Click(object sender, System.EventArgs e)
		{

			Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(int.Parse(this.Hidden1.Value));
			if(applyHead!=null)
			{
				Entiy.ApplyProcessType processType =Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode );
				if(processType!=null)
				{
					if(processType.IsSubmit == 1)
					{
						this.Label12.Text = "对不起，此单处于锁定状态！";

						return;
					}
				}

				if(applyHead.IsOverBudget == 1 )
				{
					this.Label12.Text = "对不起，此单设置为预算外，处于锁定状态！";

					return;
				}



				applyHead = null;
			}
			else
			{
				this.Label12.Text = "对不起，系统错误！";
			}

			this.Label12.Text = "";

			#region  
			
			DateTime 	DateFrom = new DateTime();			  //来访日期
			DateTime	DateTo	 = new DateTime();			  //结束日期
			string 		CallinCompany= "";              	  //来宾单位
			string 		CallinPerson = "";              	  //来访人员
			string 		CallinMemo   = "";          	      //来访目的
			string 		inviteDept	 = "";                    //接待部门
			string		invitePerson = "";              	  //接待人员 
			string 		invietDeptInfo="";              	  //接待部门信息
			string 		relationDept = "";              	  //相关部门
			string 		talkplace	 = "";                    //会谈地点 
			int 		needTea	     = 0 ;                    //茶水准备
			int 		lookFactory	 = 0 ;                    //参观工厂 
			int 		numofvisit	 = 0 ;                    //参观人数
			int 		lunch	     = 0 ;                    //午餐安排（食堂非食堂）
			string 		other	     = "";                    //其他需求
			int 		carplan	     = 0 ;                    //车辆安排(接送往返)
			string 		especialRequest="";             	  //特殊要求

			#region 
			if(this.txtDateFrom.Text.Trim() != "")
			{
				DateFrom = DateTime.Parse(this.txtDateFrom.Text);
			}
			else
			{
				this.Label12.Text = "来访日期不能为空！";
				return ;
			}
			if(this.txtDateTo .Text.Trim() != "")
			{
				DateTo = DateTime.Parse(this.txtDateTo.Text);
			}
			else
			{
				this.Label12.Text = "结束日期不能为空！";
				return ;
			}
			if(this.txtVisitCompany  .Text.Trim() != "")
			{
				CallinCompany = this.txtVisitCompany.Text;
			}
			else
			{
				this.Label12.Text = "来宾单位不能为空！";
				return ;
			}
			if(this.txtCallinPerson  .Text.Trim() != "")
			{
				CallinPerson = this.txtCallinPerson.Text;
			}
			else
			{
				this.Label12.Text = "来访人员不能为空！";
				return ;
			}


			#endregion 

			CallinMemo = this.txtCallinMemo.Text ;

			inviteDept	 = this.txtVisitDept.Text   ;                  //接待部门
			invitePerson = this.txtVisitPerson.Text ;              	   //接待人员 
			invietDeptInfo=this.txtvisitphone.Text;              	   //接待部门信息
			relationDept = this.txtRelationDept.Text ;                 //相关部门
			talkplace	 = this.txtTalkPlace.Text ;                    //会谈地点 
			if(this.chbTea.Checked )                                   //茶水准备
			{
				needTea = 1 ;
			}
			if(this.chblookFactory.Checked)
			{
				lookFactory	 = 1 ;                                      //参观工厂 
			}
			if(this.txtLookNum.Text.Trim() != "")
			{
				numofvisit	 = int.Parse(this.txtLookNum.Text) ;        //参观人数
			}
			if(this.chbLunch.Checked )
			{
				lunch	     = 1 ;                                      //午餐安排（食堂非食堂）
			}
			other	     = this.txtOtherNeed.Text ;                    //其他需求
			especialRequest=this.txtEspecialRequest.Text ;             //特殊要求
			if(this.RadioButton1.Checked )
			{
				carplan	     = 1 ;                    //车辆安排(接)
			}
			else if(this.RadioButton2.Checked )
			{
				carplan	     = 2 ;                    //车辆安排(送)
			}
			else if(this.RadioButton3.Checked )
			{
				carplan	     = 3 ;                    //车辆安排(往返)
			}

			Entiy.ApplySheetBodyBanquet applyBanquet = Entiy.ApplySheetBodyBanquet.FindByApplyHeadPk(int.Parse(this.Hidden1.Value));
			if(applyBanquet == null)
			{
				applyBanquet = new HDSZCheckFlow.Entiy.ApplySheetBodyBanquet();
			}
			// 附值 
			applyBanquet.ApplySheetHeadPk = int.Parse(this.Hidden1.Value) ; 
			applyBanquet.DateFrom = DateFrom ;
			applyBanquet.DateTo   = DateTo ;
			applyBanquet.CallinCompany = CallinCompany ;
			applyBanquet.CallinPerson  = CallinPerson ;
			applyBanquet.CallinMemo    = CallinMemo ;
			applyBanquet.InviteDept    = inviteDept;
			applyBanquet.InvitePerson  = invitePerson;
			applyBanquet.InvietDeptInfo= invietDeptInfo ; 
			applyBanquet.RelationDept  = relationDept;
			applyBanquet.Talkplace     = talkplace ;
			applyBanquet.NeedTea       = needTea;
			applyBanquet.LookFactory   = lookFactory;
			applyBanquet.Numofvisit    = numofvisit ;
			applyBanquet.Lunch         = lunch;
			applyBanquet.Other         = other ;
			applyBanquet.Carplan       = carplan;
			applyBanquet.EspecialRequest= especialRequest ;

			applyBanquet.Save();

			this.Label12.Text= "保存成功！";


			#endregion 
		}

		private void XpGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			// 给applyHeadpk附值，汇率附值
			#region 添加记录时，系统维护插入的表头主键
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				if(!"".Equals(this.Hidden1.Value))
				{
					int key=int.Parse(this.Hidden1.Value); 
					Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
					if(applySheet!=null )
					{
						Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
						if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )  //已提交或为预算外 锁定
						{
							XpGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
							continueUpdate=false;
							return ;
						}
					}
				}
				else
				{
					XpGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
					continueUpdate=false;
					return ;

				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//给表头主键 赋值
				if(!"".Equals(this.Hidden1.Value))
				{
					int key=int.Parse(this.Hidden1.Value); 
					Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
					if(applySheet!=null )
					{
						Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
						if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )  //已提交或设置为预算外 锁定
						{
							XpGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
							continueUpdate=false;
							return ;
						}
					}

					ChgSql MyChgSql=new ChgSql();
					if (!MyChgSql.ChgResultSql(ref ResultSql,"APPLYSHEETHEAD_PK",key.ToString()))
					{
						XpGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
						continueUpdate=false;
					}	


					//购买类的时候,给总金额附值(用于区分报销类以及日后其他类别的处理)
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applySheet.ApplyTypeCode);   
					if(applyTypes !=null )
					{
						//报销类以及日后其他类别的处理
						#region 

						//给总金额附值，本币单价附值
				
						decimal orPrice=0;　　　　　　　　//原币金额
						string  bizhong="";				  //币种　，通过币种得到，汇率,计算本币单价，总金额


						for (int i = 0; i <= XpGrid1.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XpGrid1.FieldList[i]; 
							object ob = XpGrid1.GetInputControlValue(F); 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob);   //币种
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob);  //原币金额
							} 
						} 
						Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
						if(currType!=null)
						{
							decimal TotalMoney= currType.ExchangeRate * orPrice;          //RMB 金额

							if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
							{
								XpGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
							{
								XpGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
						}
						else                       //币种有误
						{
							XpGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
							continueUpdate=false;
						}	

						#endregion 
					}
				}
			}
			#endregion		
		}

		private void XpGrid1_AfterUpdate(object sender, XPGrid.CUpdateType updateType, string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			// 更新预算金额处
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);

					SetButtonsEnable(key);

					decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
					this.lblSheetMoney.Text=ThisMoney.ToString("#,###.##");
					
					decimal thisleft=0;           
					decimal leftMoeny = decimal.Parse(this.HiddenLeft.Value);
					thisleft=leftMoeny-ThisMoney;
					
					this.lblLeft.Text =  thisleft.ToString("#,###.##");      //剩余金额
					Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
					if(applyHeadBudget!=null)
					{
						applyHeadBudget.SheetMoney=ThisMoney; //本次累计金额
						applyHeadBudget.Update();
					}
					else
					{
						HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.Evection","找不到applyHeadBudget");
					}
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.Evection.XPGrid1_AfterUpdate",ex.Message);
			}
		}

		private void btnEditEvection_Click(object sender, System.EventArgs e)
		{
			darkControls() ;


			//根据单据号，查询出所有信息 ，附给以下各个空格

			// 1. 表头信息 
			// 2. 预算信息 
			// 3. 表体信息 
			// 4. 费用信息 

			string applyNo = this.ddlEvection.SelectedValue;
			Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);
			if(applyHead != null)
			{

				this.Hidden1.Value = applyHead.ApplySheetHeadPk.ToString();

				this.ddlApplyType.SelectedValue = applyHead.ApplyTypeCode ;                    //类型
				this.txtDate .Text              = applyHead.ApplyDate.ToString("yyyy-MM-dd") ; //日期
				this.ddlDeptClass.SelectedValue = applyHead.ApplyDeptClassCode ;               //一级部门
				this.ddlDept.SelectedValue      = applyHead.ApplyDeptCode ;                    //部门
				this.txtPerson.Text             = applyHead.ApplyPersonCode ;                  //出差人

				//科目金额信息 
				Entiy.ApplySheetHeadBudget applyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk);
				if(applyBudget!=null)
				{
					this.ddlFirstSubject.SelectedValue = applyBudget.SheetFirstClassSubject ; // 一级科目
					this.ddlSubject.SelectedValue      = applyBudget.SheetSubject ;           // 科目
				}

				//预算信息
				BindBudgetInfo(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);  

				this.panel1.Visible=true; 

				#region 表体信息
				Entiy.ApplySheetBodyBanquet  applyBanquet = Entiy.ApplySheetBodyBanquet.FindByApplyHeadPk(applyHead.ApplySheetHeadPk);
				if(applyBanquet != null)
				{
					#region  

					// 附值 
					this.txtDateFrom.Text = applyBanquet.DateFrom.ToString("yyyy-MM-dd") ;
					this.txtDateTo.Text   = applyBanquet.DateTo.ToString("yyyy-MM-dd") ;
					this.txtVisitCompany.Text=applyBanquet.CallinCompany ;
					this.txtCallinPerson.Text=applyBanquet.CallinPerson ;
					this.txtCallinMemo.Text  =applyBanquet.CallinMemo  ;
					this.txtVisitDept.Text   =applyBanquet.InviteDept ;
					this.txtVisitPerson.Text =applyBanquet.InvitePerson ;
					this.txtvisitphone.Text  =applyBanquet.InvietDeptInfo ; 
					this.txtRelationDept.Text=applyBanquet.RelationDept ;
					this.txtTalkPlace.Text   =applyBanquet.Talkplace  ;
					if(applyBanquet.NeedTea == 1)
					{
						this.chbTea.Checked =true; 
					}
					else
					{
						this.chbTea.Checked =false; 
					}
					if(applyBanquet.LookFactory==1)
					{
						this.chblookFactory.Checked=true;
					}
					else
					{
						this.chblookFactory.Checked=false;
					}
					this.txtLookNum.Text =applyBanquet.Numofvisit.ToString();
					if(applyBanquet.Lunch==1)
					{
						this.chbLunch.Checked =true;
					}
					else
					{
						this.chbLunch.Checked =false;
					}
					this.txtOtherNeed.Text = applyBanquet.Other ; 
					this.txtEspecialRequest.Text = applyBanquet.EspecialRequest ; 

					
					if(applyBanquet.Carplan == 1  )
					{
						this.RadioButton1.Checked =true;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=false;
					}
					else if(applyBanquet.Carplan == 2 )
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=true;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=false;			
					}
					else if( applyBanquet.Carplan == 3 )
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton4.Checked=false;
						this.RadioButton3.Checked=true;//车辆安排(往返)
					}
					else
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=true;
					}

					#endregion 
				}
				else
				{
					#region  没有信息

					this.txtDateFrom.Text = "" ;
					this.txtDateTo.Text   = "" ;
					this.txtVisitCompany.Text="" ;
					this.txtCallinPerson.Text="" ;
					this.txtCallinMemo.Text  =""  ;
					this.txtVisitDept.Text   ="" ;
					this.txtVisitPerson.Text ="" ;
					this.txtvisitphone.Text  ="" ; 
					this.txtRelationDept.Text="" ;
					this.txtTalkPlace.Text   =""  ;
					this.chbTea.Checked =false; 
					this.chblookFactory.Checked=false;
					this.txtLookNum.Text ="0";
					this.chbLunch.Checked =false;
					this.txtOtherNeed.Text = ""; 
					this.txtEspecialRequest.Text ="" ; 
					this.RadioButton4.Checked=true;

					#endregion 
				}
				#endregion

				this.XpGrid1.CommandText="select * from ApplySheetBody_Pay  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
				this.XpGrid1.DataBind();

				SetButtonsEnable(applyHead.ApplySheetHeadPk);

				//添加附件可用
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;


			}
		}
	}
}
