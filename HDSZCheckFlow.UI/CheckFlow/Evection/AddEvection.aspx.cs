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
	/// AddApplySheet ��ժҪ˵����
	/// </summary>
	public class AddEvection : System.Web.UI.Page
	{
		#region  ����
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlSubject;
		protected System.Web.UI.WebControls.TextBox txtPerson;
		protected System.Web.UI.WebControls.TextBox txtPersonName;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;//��¼�˴���ӵı�ͷPK
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
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Button btnCCSave;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtGocity;
		protected System.Web.UI.WebControls.DropDownList ddlCCType;
		protected System.Web.UI.WebControls.TextBox txtAppclass;
		protected System.Web.UI.WebControls.TextBox txtwithapps;
		protected System.Web.UI.WebControls.TextBox txtWithwho;
		protected System.Web.UI.WebControls.TextBox txtCCMemo;
		protected System.Web.UI.WebControls.TextBox txtPreabound;
		protected System.Web.UI.WebControls.TextBox txtPreback;
		protected System.Web.UI.WebControls.CheckBox chbVisa;
		protected System.Web.UI.WebControls.TextBox txtVisaDate;
		protected System.Web.UI.WebControls.CheckBox chkPassport;
		protected System.Web.UI.WebControls.TextBox txtPassportno;
		protected System.Web.UI.WebControls.TextBox txtpassportdate;
		protected System.Web.UI.WebControls.CheckBox chbbacterin;
		protected System.Web.UI.WebControls.TextBox txtbacterindate;
		protected System.Web.UI.WebControls.TextBox txtabountMemo;
		protected System.Web.UI.WebControls.CheckBox chblimit;
		protected System.Web.UI.WebControls.CheckBox chblimits;
		protected System.Web.UI.WebControls.CheckBox chbcheckup;
		protected System.Web.UI.WebControls.CheckBox chbmeet;
		protected System.Web.UI.WebControls.TextBox txtcheckupplan;
		protected XPGrid.XpGrid XpGrid1;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.DropDownList ddlEvection;
		protected System.Web.UI.WebControls.Button btnEditEvection;
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
		protected System.Web.UI.WebControls.Label Label13;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label14;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.Label Label10;

		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddEvection));
					
			if(!Page.IsPostBack)
			{
				darkControls();

				InitPageForAdd();
				bindMyCCinfo();
			}
		}

		private void darkControls()
		{				
			#region 

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

		private void bindMyCCinfo()
		{
			//�������ҵĳ����

			// 1.�������ڱ�����

			// 2.����δ�ύ ���� Ϊȡ��״̬
	        

			//�����Ϊ�������ļ�����ȡ�д��������ͱ���(2011-09-09 liyang) 
			string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"];

			string personCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

			string cmdStr = "SELECT ApplySheetHead.ApplySheetNo  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode and  (ApplyTypeCode = '"+evectionCode+"') AND (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
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
		
		#region  ��ʼ�������˵�
		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeForEvection (deptClassCode);
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
				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(budgetDept); //һ����Ŀ
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

		#region  ajax����,��ҳ���ѯ�û�����
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
			//this.Hidden2 �Ƿ�Ϊ�޸�
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


		//��ʾ���ſ�ĿԤ�����
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
			this.Label14.Visible =true;
			#endregion 
			// ����Ϊ������Ϊ�жϱ�׼
			//1.���������·ݣ��ó���ǰ���ڼ���
			//2.�õ����Ƚ��ϼ�
			//3.�жϱ�׼��ӿ��Ǵ�̯���
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
				    this.lblAlterMoney.Text  = ds.Tables[0].Rows[0]["alterMoney"].ToString();

					//					//���ó�֧��׼��Ԥ��������㡣
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
					decimal leftmoney = 0 ; 
					if (budgetStandard == 1 )  //Ԥ��
					{
						leftmoney=decimal.Parse(this.lblBudget.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text);
					}
					else if(budgetStandard == 2 ) // ����
					{
						leftmoney=decimal.Parse(this.lblPush.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text);
					}
					this.lblLeft.Text=leftmoney.ToString("N2");
					//��ȫ�ֱ��� 
					this.HiddenLeft.Value= leftmoney.ToString();
				}
			}

			#region  ����
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
			//				//���ó�֧��׼��Ԥ��������㡣
			//				int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
			//				decimal leftmoney = 0 ; 
			//				if (budgetStandard == 1 )  //Ԥ��
			//				{
			//					leftmoney=budgetAccount.BudgetMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				else if(budgetStandard == 2 ) // ����
			//				{
			//					leftmoney=budgetAccount.PlanMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				this.lblLeft.Text=leftmoney.ToString("#,###.##");
			//				//leftMoney = leftmoney ;  //��ȫ�ֱ��� 
			//				this.HiddenLeft.Value= leftmoney.ToString();
			//			}
			#endregion 
		}



		#region �󶨿���
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
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
			// 1 �����������ã� < 3000 
			// 2 Ԥ���ڿ���
			// 3 Ԥ�������
			// 4 ���� and Ԥ���� ����
			// 5 ���� and Ԥ���� ����
			// 6 ��������ȫ������
			// 7 û�б��壬������
			// 8 ���ִ���
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

		//�������뵥��ͷ����״̬Ϊ�ύ
		private void updatePross(int ApplySheetHeadPk)
		{
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplySheetHeadPk);
			if(applyHead!=null)
			{
				applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.SubmitPross;
				applyHead.Update();
			}
		}


		#region �ύ��ť
		private void btnPress_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);
					//��������
					string pressCode=System.Configuration.ConfigurationSettings.AppSettings["PressCode"];

					Entiy.CheckFlowInCompanyhead checkFlow=Entiy.CheckFlowInCompanyhead.FindByFlowCode(pressCode); //��������Code
					if(checkFlow!=null)
					{

						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{				
							//���µ�ǰ������ɫ,δ�ҵ�������ɫд��־, ˵������������������
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
								//���û���������,ѭ�����÷�������;
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

								// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
								//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
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

								//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									decimal tempMoney=budgetAccount.CheckMoney ;
									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["PressType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// ����
									applyHeadBudget.Update();
								}
							}
							else
							{
								this.lblMsg.Text="δ�������������ɫ";
								HDSZCheckFlow.Common.Log.Logger.Log("�ύ��������","û���ҵ����������ɫ");
							}
						}
					}
					else
					{
						this.lblMsg.Text="δ�����������!!!!";
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
						//����������Ϣ
						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{
							// �ȿ������Ƿ��Ѿ����ύ״̬
							string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

							if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
							{
								this.lblMessage .Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
								return ;
							}

							/////////2014-01-07 ��� ����һ���ж�  p_getBudgetInfobySheetHeadPk   �����Ϊ�������ֹ�ύ  /////
							///

							DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
							if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
							{
								this.lblMessage.Text ="�˵������Ϣ���󣬲����ύ";
								return;
							}
							

							



							///////////////////////////////////////////END////////////////////////////////////////////////////

							#region 
							string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
							decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //�����������
							Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
							if(TypeInFlow!=null)
							{
								//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
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

									// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

									string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
									//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
								

								
									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
//
//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//
//									mailBll.ThreadSendMail();
									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);



									updatePross(key);   //��������״̬

									//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
									Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
									if(applyHeadBudget!=null )
									{
										Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
										// ��ǰ����ƽ��Ϊ�����ۼ���ƽ��
										Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
										DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

										decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
										
										budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;

										decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //�����Ԥ������
										
										ds = null; 
										
										budgetAccount.Update();
										applyHeadBudget.SumCheckMoney = tempMoney ;
										string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
										applyHeadBudget.SubmitType = int.Parse(submitType) ;// ����

										applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

										applyHeadBudget.Update();
									}
									if(IsGiveUp ==1 )
									{
										//���û���������,ѭ�����÷�������;

										Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
										Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//										Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
									}
									else
									{
										//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
								

//										Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//										mailBll.ThreadSendMail();
									}

								}
								else
								{
									Response.Write(Message);
									HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
								}
							}
							else
							{
								Response.Write("δ�����������!!!!!!!");
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

						//����������Ϣ
						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
						if(applyHead!=null)
						{
							// �ȿ������Ƿ��Ѿ����ύ״̬
							string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

							if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
							{
								this.lblMessage .Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
								return ;
							}

							/////////2014-01-07 ��� ����һ���ж�  p_getBudgetInfobySheetHeadPk   �����Ϊ�������ֹ�ύ  /////
							///

							DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
							if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
							{
								this.lblMessage.Text ="�˵������Ϣ���󣬲����ύ";
								return;
							}
							

							



							///////////////////////////////////////////END////////////////////////////////////////////////////
							#region 
							Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(key);
							decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //�����������


							string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
							Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
						
							if(TypeInFlow!=null)
							{
								//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
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

									// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

									string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
									//���ݹ��ŷ��ʼ�            ���ʼ�(����2)

							
									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
//
//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//									mailBll.ThreadSendMail();


									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

									//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);


									updatePross(key);

									//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
									Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
									if(applyHeadBudget!=null )
									{
										Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
										//decimal tempMoney=budgetAccount.CheckMoney ;
										Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
										DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

										decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
										ds = null; 

										budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
										budgetAccount.Update();
										applyHeadBudget.SumCheckMoney = tempMoney ;
										string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
										applyHeadBudget.SubmitType = int.Parse(submitType) ;// ����
										applyHeadBudget.Update();
									}
									if(IsGiveUp ==1 )
									{
										//���û���������,ѭ�����÷�������;
										Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
										Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//										Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
									}
									else
									{
										//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
								

//										Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//										mailBll.ThreadSendMail();
									}

								}
						
							}
							else
							{
								Response.Write("δ�����������!!!!!");
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
			//ѡ����һ����Ŀ��,�ﶨ�Ӽ���Ŀ

			//�󶨿���
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
		

			//�󶨿���
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
			
			#region  ��ӹ��� 
			this.lblMessage.Text="";
			try
			{
				//1. ���ɶ�����
				string applyNo="";
				string applyType=this.ddlApplyType.SelectedValue;
				DateTime  applyDate=new DateTime();
				if(!"".Equals(txtDate.Text))
				{
					applyDate=DateTime.Parse(txtDate.Text);
					//�������ڲ���С�� ��ǰ�·�............
					if(applyDate.Year < DateTime.Today.Year || (applyDate.Year == DateTime.Today.Year && applyDate.Month < DateTime.Today.Month) )
					{
						this.lblMessage.Text= "�������ڲ���Ϊ��ǰ�·ݣ�";
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
					this.lblMessage.Text="���Ͳ���Ϊ��";
					return;
				}
				if("".Equals(txtDate.Text))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="�������ڲ���Ϊ��";
					return;
				}
				if("".Equals(applyDeptClass))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="���벿�Ų���Ϊ��";
					return;
				}
				if("".Equals(applyDept))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="������鲻��Ϊ��";
					return;
				}
				if("".Equals(firstSubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="һ����Ŀ����Ϊ��";
					return;
				}
				if("".Equals(applySubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="�����Ŀ����Ϊ��";
					return;
				}


				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person==null)
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="��Ա������";
					return ;
				}
				#endregion 

				#region ���ɵ��ݺ�
				//1.ȡǰ׺
				Entiy.ApplyType applyTyp=Entiy.ApplyType.Find(applyType);
				if(applyTyp!=null)
				{
					applyNo=applyTyp.ApplySheetEncode ;
				}
				else
				{
					Page.RegisterClientScriptBlock("a","<scrpit language='JavaScript'>alert('���ɵ��ݺŴ���!');</scrpit>");
					return ;
				}
				//2.ȡ����
				int iYear=applyDate.Year;
				int iMonth=applyDate.Month;
				string tempMonth=iMonth.ToString();
				for(int iLength=iMonth.ToString().Length ;iLength<2;iLength++)
				{
					tempMonth="0"+tempMonth;
				}
				applyNo += iYear.ToString();
				applyNo += tempMonth;

				//3.ȡ��ˮ��
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
				//4.�ϲ����ݺ�
				applyNo = applyNo + applyMaxNum;
				#endregion 

				string personMakerCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));

				if(!"1".Equals(this.Hidden2.Value))   // �Ǹ���״̬ 
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
					applySheet.SubmitDate = System.DateTime.Now;         // �ύʱ��Ϊϵͳ��ǰʱ��
					applySheet.ExpenseDate  = DateTime.Parse("1900-01-01"); //�������� ��Ĭ������


					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //�½�״̬

					applySheet.Create();


					//���ApplySheetHead_Budget ��
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);

					Entiy.ApplySheetHeadBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.ApplySheetHeadBudget();
					if(applyHead!=null)
					{
						ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
						ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
						ApplyHeadBudget.SheetSubject=applySubject;
						ApplyHeadBudget.Create();
					}

					this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //��¼�˴���ӵı�ͷPK
					
					//�ҵ���ر���  ApplyType  ���뵥�����ͱ�
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XpGrid1.CommandText="select * from ApplySheetBody_EvectionCharge  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XpGrid1.DataBind();
					
						//��Ӹ�������
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "../CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;

					}

					this.Label9.Text= applyNo ;                                 //��ʾ���ݺ�
					this.Label10.Text=System.DateTime.Now.ToString();

				}
				else                                   // ����״̬ 
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
					applySheet.SubmitDate = System.DateTime.Now;         // �ύʱ��Ϊϵͳ��ǰʱ��

					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //�½�״̬

					applySheet.Update();


					//���ApplySheetHead_Budget ��
					
					Entiy.ApplySheetHeadBudget ApplyHeadBudget=HDSZCheckFlow.Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(this.Hidden1.Value));

					ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
					ApplyHeadBudget.SheetSubject=applySubject;
					ApplyHeadBudget.Update ();
					
					//�ҵ���ر���  ApplyType  ���뵥�����ͱ�
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
//						this.XPGrid1.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + this.Hidden1.Value + " ";  //" + applyHead.ApplySheetHeadPk + "
//						this.XPGrid1.DataBind();
					
						//��Ӹ�������
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + this.Hidden1.Value   ;

					}

					this.Label9.Text= applySheet.ApplySheetNo ;                                 //��ʾ���ݺ�
					this.Label10.Text=System.DateTime.Now.ToString();


				}

				this.lblMessage.ForeColor=Color.Blue;
				this.lblMessage.Text="��ӳɹ�";
				//��û�в��ſ�Ŀ��¼,���ʼ��һ����ֵ
				string message="";
				Bussiness.BudgetAccountBLL.SaveBudgetAccount(applyDate.Year,applyDate.Month,applyDept,applySubject,out message);
				if(!"".Equals(message))
				{
					this.lblMessage.Text=message;
				}
				
				BindBudgetInfo(applyDate.Year,applyDate.Month,applyDept,applySubject);//��ʾ���ſ�ĿԤ�����

				
 
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
			//��ʾΪ�޸�״̬
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
						this.Label12.Text = "�Բ��𣬴˵���������״̬��";

						return;
					}
				}

				if(applyHead.IsOverBudget == 1 )
				{
					this.Label12.Text = "�Բ��𣬴˵�����ΪԤ���⣬��������״̬��";

					return;
				}

				applyHead = null;
			}
			else
			{
				this.Label12.Text = "�Բ���ϵͳ����";
			}

			this.Label12.Text = "";
			#region  
			//����������ϸ��Ϣ
			string dateFrom = "" ; //��ʼ����
			string dateTo   = "" ; //��������
			string goCity   = "" ; //�������
			string ccType   = "" ; //��������
			string appClass = "" ; //���÷ѵȼ�
			int    withapps = 0  ; //ͬ������
			string withwho  = "" ; //ͬ����
			string ccMemo   = "" ; //��������

			// ���������Ϣ
			string perdatefrom  = "" ;  //�ϴγ�������
			string perbackdate  = "" ;  //�ϴλع���ǰ
			int    haveVisa     = 0  ;  //�Ƿ���visa
			string visadate     = "" ;  //visa��Ч��
			int    havepassport = 0  ;  //�Ƿ��л���
			string passportdate = "" ;  //������Ч��
			int    bacterin     = 0  ;  //�Ƿ�ע������
			string bacterindate = "" ;  //����ʱ��
			string abountMemo   = "" ;  //������ע
			int    limit        = 0  ;  //�Ƿ�Я��������Ʒ
			int    limits       = 0  ;  //�Ƿ������Ƽ�����
			int    checkup      = 0  ;  //�Ƿ�Ҫ���
			int    meet         = 0  ;  //�Ƿ���ϳ�������
			string checkupplan  = "" ;  //���ƻ���

			if(!"".Equals(this.txtDateFrom.Text))
			{
				dateFrom = this.txtDateFrom.Text;
			}
			else
			{
				this.lblMessage.Text = "�������ڲ���Ϊ�գ�";
				return ;
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				dateTo  = this.txtDateTo.Text;
			}
			else
			{
				this.lblMessage.Text = "�������ڲ���Ϊ�գ�";
				return ;
			}
			if(!"".Equals(this.txtGocity.Text))
			{
				goCity   = this.txtGocity.Text;
			}
			else
			{
				this.lblMessage.Text = "������в���Ϊ�գ�";
				return ;
			}
			ccType = this.ddlCCType.SelectedValue ;
			appClass = this.txtAppclass.Text  ;         //���÷ѵȼ�
			if(!"".Equals(this.txtwithapps.Text))
			{
				withapps = int.Parse(this.txtwithapps.Text)   ; //ͬ������
			}
			withwho  = this.txtWithwho.Text           ; //ͬ����
			ccMemo   = this.txtCCMemo.Text            ; //��������

			// ���������Ϣ
			perdatefrom  = this.txtPreabound.Text     ;  //�ϴγ�������
			perbackdate  = this.txtPreback.Text       ;  //�ϴλع���ǰ
			if(this.chbVisa.Checked)
			{
				haveVisa = 1 ;         //�Ƿ���visa
			}
			visadate     = this.txtVisaDate.Text      ;  //visa��Ч��
			if(this.chkPassport.Checked )
			{			
				havepassport = 1  ;    //�Ƿ��л���
			} 
			passportdate = this.txtpassportdate.Text  ;  //������Ч��
			if(this.chbbacterin.Checked )
			{
				bacterin     =  1 ;    //�Ƿ�ע������
			}  
			bacterindate = this.txtbacterindate.Text  ;  //����ʱ��
			abountMemo   = this.txtabountMemo.Text    ;  //������ע
			if(this.chblimit.Checked )
			{
				limit        = 1   ;   //�Ƿ�Я��������Ʒ
			}  
			if(this.chblimits.Checked)
			{
				limits       =  1    ; //�Ƿ������Ƽ�����
			} 
			if(this.chbcheckup.Checked  )
			{
				checkup      =  1 ;    //�Ƿ�Ҫ���
			}
			if(this.chbmeet.Checked  )
			{
				meet         =    1  ; //�Ƿ���ϳ�������
			} 
			checkupplan  = this.txtcheckupplan.Text   ;  //���ƻ���

			Entiy.ApplySheetBodyEvection applyEvection  = Entiy.ApplySheetBodyEvection.FindByApplyHeadPk(int.Parse(this.Hidden1.Value));
			if(applyEvection == null)
			{
				applyEvection = new HDSZCheckFlow.Entiy.ApplySheetBodyEvection();
			}
			// ��ֵ 
			applyEvection.ApplySheetHeadPk = int.Parse(this.Hidden1.Value) ; 
			applyEvection.DateFrom = DateTime.Parse(dateFrom);
			applyEvection.DateTo  = DateTime.Parse(dateTo);
			applyEvection.GoCity  = goCity ;
			applyEvection.EvecionType  =ccType ;         //��������
			applyEvection.AppClass  = appClass ;         //���÷ѵȼ�
			applyEvection.Withapps = withapps ;          //ͬ������
			applyEvection.Withwho = withwho ;            //ͬ����
			applyEvection.Appduty = ccMemo ;             //��������

			// ���������ϢapplyEvection
			applyEvection.Preabroaddate = perdatefrom ;  //�ϴγ�������
			applyEvection.Prebackdate   = perbackdate;   //�ϴλع���ǰ
			applyEvection.Visa          = haveVisa ;     //�Ƿ���visa
			applyEvection.Visadate      = visadate ;     //visa��Ч��
			applyEvection.Passport = havepassport ;      //�Ƿ��л���
			applyEvection.Passportdate = passportdate ;  //������Ч��
			applyEvection.Bacterin = bacterin ;          //�Ƿ�ע������
			applyEvection.Bacterindate = bacterindate ;  //����ʱ��
			applyEvection.Memo = abountMemo ;            //������ע
			applyEvection.Limitdartcle = limit ;         //�Ƿ�Я��������Ʒ
			applyEvection.Limittech = limits ;           //�Ƿ������Ƽ�����
			applyEvection.Checkup = checkup ;            //�Ƿ�Ҫ���
			applyEvection.Meetcondition = meet ;         //�Ƿ���ϳ�������
			applyEvection.Checkupdate = checkupplan ;    //���ƻ���

			applyEvection.Save();

			this.Label12.Text= "����ɹ���";

			#endregion 

			Page.RegisterStartupScript(Guid.NewGuid().ToString(),"<script language='javascript'>window.location.href = '#p';</script>");

		}

		private void XpGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			// ��applyHeadpk��ֵ�����ʸ�ֵ
			#region ��Ӽ�¼ʱ��ϵͳά������ı�ͷ����
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				if(!"".Equals(this.Hidden1.Value))
				{
					int key=int.Parse(this.Hidden1.Value); 
					Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
					if(applySheet!=null )
					{
						Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
						if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget ==1 ) //���ύ������ΪԤ���� ����
						{
							XpGrid1.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
							continueUpdate=false;
							return ;
						}
					}
				}
				else
				{
					XpGrid1.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
					continueUpdate=false;
					return ;
				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//����ͷ���� ��ֵ
				if(!"".Equals(this.Hidden1.Value))
				{
					int key=int.Parse(this.Hidden1.Value); 
					Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
					if(applySheet!=null )
					{
						Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
						if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 ) //���ύ������ΪԤ���� ����
						{
							XpGrid1.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
							continueUpdate=false;
							return ;
						}
					}

					ChgSql MyChgSql=new ChgSql();
					if (!MyChgSql.ChgResultSql(ref ResultSql,"APPLYSHEETHEAD_PK",key.ToString()))
					{
						XpGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
						continueUpdate=false;
					}	

					//�������Լ��պ��������Ĵ���

					//���ܽ�ֵ�����ҵ��۸�ֵ
				
					string  bizhong="";				  //���֡���ͨ�����ֵõ�������,���㱾�ҵ��ۣ��ܽ��

					for (int i = 0; i <= XpGrid1.FieldList.Count - 1; i++) 
					{ 
						XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XpGrid1.FieldList[i]; 
						object ob = XpGrid1.GetInputControlValue(F); 
						if (F.ColName == "CURRCODE") 
						{ 
							bizhong = System.Convert.ToString(ob);   //����
						} 
					} 
					Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
					if(currType!=null)
					{
						if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
						{
							XpGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
							continueUpdate=false;
						}
					}
					else                       //��������
					{
						XpGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
						continueUpdate=false;
					}	
				}
			}
			#endregion
		}

		private void XpGrid1_AfterUpdate(object sender, XPGrid.CUpdateType updateType, string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			// ����Ԥ���
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
					
					this.lblLeft.Text =  thisleft.ToString("#,###.##");      //ʣ����
					Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
					if(applyHeadBudget!=null)
					{
						applyHeadBudget.SheetMoney=ThisMoney; //�����ۼƽ��
						applyHeadBudget.Update();
					}
					else
					{
						HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.Evection","�Ҳ���applyHeadBudget");
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
			darkControls();
			//���ݵ��ݺţ���ѯ��������Ϣ ���������¸����ո�

			// 1. ��ͷ��Ϣ 
			// 2. Ԥ����Ϣ 
			// 3. ������Ϣ 
			// 4. ������Ϣ 

			string applyNo = this.ddlEvection.SelectedValue;
			Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);
			if(applyHead != null)
			{

				this.Hidden1.Value = applyHead.ApplySheetHeadPk.ToString();

				this.ddlApplyType.SelectedValue = applyHead.ApplyTypeCode ;                    //����
				this.txtDate .Text              = applyHead.ApplyDate.ToString("yyyy-MM-dd") ; //����
				this.ddlDeptClass.SelectedValue = applyHead.ApplyDeptClassCode ;               //һ������
				this.ddlDept.SelectedValue      = applyHead.ApplyDeptCode ;                    //����          .............
				this.txtPerson.Text             = applyHead.ApplyPersonCode ;                  //������

				//��Ŀ�����Ϣ 
				Entiy.ApplySheetHeadBudget applyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk);
				if(applyBudget!=null)
				{
					this.ddlFirstSubject.SelectedValue = applyBudget.SheetFirstClassSubject ; // һ����Ŀ
					this.ddlSubject.SelectedValue      = applyBudget.SheetSubject ;           // ��Ŀ
				}

				//Ԥ����Ϣ
				BindBudgetInfo(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);  

				this.panel1.Visible=true; 

				#region ������Ϣ
				Entiy.ApplySheetBodyEvection applyEvection = Entiy.ApplySheetBodyEvection.FindByApplyHeadPk(applyHead.ApplySheetHeadPk);
				if(applyEvection != null)
				{
					this.txtDateFrom.Text=applyEvection.DateFrom.ToString("yyyy-MM-dd");//��������
					this.txtDateTo.Text =  applyEvection.DateTo.ToString("yyyy-MM-dd") ;//�����������
					this.txtGocity.Text=applyEvection.GoCity ;
					this.ddlCCType.SelectedValue  = applyEvection.EvecionType ;         //��������
					this.txtAppclass.Text =	applyEvection.AppClass ;                    //���÷ѵȼ�
					this.txtwithapps.Text = applyEvection.Withapps.ToString();          //ͬ������
					this.txtWithwho.Text   = applyEvection.Withwho ;                    //ͬ����
					this.txtCCMemo.Text  = applyEvection.Appduty ;                      //��������
					// ���������ϢapplyEvection
					this.txtPreabound.Text =applyEvection.Preabroaddate ;               //�ϴγ�������
					this.txtPreback.Text=applyEvection.Prebackdate  ;                   //�ϴλع���ǰ
					if( applyEvection.Visa  == 1)                                       //�Ƿ���visa
					{
						this.chbVisa.Checked=true;
					}
					else{this.chbVisa.Checked =false;}
					this.txtVisaDate.Text  =applyEvection.Visadate ;                    //visa��Ч��
					if(applyEvection.Passport == 1)                                     //�Ƿ��л���
					{
						this.chkPassport.Checked = true;
					}
					else
					{	this.chkPassport.Checked = false;}
					this.txtpassportdate.Text = applyEvection.Passportdate ;            //������Ч��
					if(applyEvection.Bacterin == 1)                                     //�Ƿ�ע������
					{
						this.chbbacterin .Checked =true; 
					}
					else{this.chbbacterin.Checked=false;}
					this.txtbacterindate.Text = applyEvection.Bacterindate;             //����ʱ��
					this.txtabountMemo.Text  = applyEvection.Memo ;                     //������ע
					if(applyEvection.Limitdartcle == 1)                                 //�Ƿ�Я��������Ʒ
					{
						this.chblimit .Checked= true;
					}
					else{this.chblimit.Checked=false;}
					if(applyEvection.Limittech == 1)                                    //�Ƿ������Ƽ�����
					{
						this.chblimits.Checked=true;
					}
					else{this.chblimits.Checked=false;}
					if(applyEvection.Checkup == 1)                                      //�Ƿ�Ҫ���
					{
						this.chbcheckup.Checked =true;
					}
					else{this.chbcheckup.Checked=false;}
					if(applyEvection.Meetcondition == 1)                                //�Ƿ���ϳ�������
					{
						this.chbmeet.Checked= true;
					}
					else{this.chbmeet.Checked=false;}

					this.txtcheckupplan.Text = applyEvection.Checkupdate ;              //���ƻ���

				}
				#endregion

				//��Ӹ�������
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;


				this.XpGrid1.CommandText="select * from ApplySheetBody_EvectionCharge  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
				this.XpGrid1.DataBind();

				SetButtonsEnable(applyHead.ApplySheetHeadPk);

			}
		}
	}
}
