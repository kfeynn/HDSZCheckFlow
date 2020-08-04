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
using System.Text.RegularExpressions;

namespace HDSZCheckFlow.UI.Asset.CheckFlow
{
	/// <summary>
	/// AddAssetApply ��ժҪ˵����
	/// </summary>
	public class EditAssetApply : System.Web.UI.Page
	{
		#region
		protected System.Web.UI.WebControls.Button btnInBudget;
		protected System.Web.UI.WebControls.Button btnOutBudget;
		protected System.Web.UI.WebControls.DropDownList ddlSubjectCode;
		protected System.Web.UI.WebControls.TextBox tbInvName;
		protected System.Web.UI.WebControls.TextBox tbInvType;
		protected System.Web.UI.WebControls.TextBox tbOriginalcurrPrice;
		protected System.Web.UI.WebControls.DropDownList ddlUnit;
		protected System.Web.UI.WebControls.DropDownList ddlcurrTypeCode;
		protected System.Web.UI.WebControls.TextBox tbNumber;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Button btnAddBody;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.Panel PBudgetInfo;
		protected System.Web.UI.WebControls.Label lbBudget;
		protected System.Web.UI.WebControls.Label lbOutMoney;
		protected System.Web.UI.WebControls.Label lbSumCheck;
		protected System.Web.UI.WebControls.Label lbready;
		protected System.Web.UI.WebControls.Label lbSheetMoney;
		protected System.Web.UI.WebControls.Label lbLeft;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.DataGrid dgApplyHead;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyHead;
		protected System.Web.UI.WebControls.Panel pAddItem;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				this.btnInBudget.Enabled = false; 
				this.btnOutBudget.Enabled = false;

				//this.dgApplyHead.CurrentPageIndex = 1 ;
				BindEditAssetApply() ; 
			}
		}

		private void BindEditAssetApply()
		{
			string AssetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //��Ӫ
			
			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
			if( !"".Equals(personCode))
			{
				//��ѯ���ڱ����ŵ�δ�ύ������,�����ύû����������  , ֻȡ ��Ӫ���뵥

				string cmdStr = "SELECT *  FROM dbo.v_AssetApplyList  INNER JOIN ApplyProcessType ON v_AssetApplyList.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
					" where (v_AssetApplyList.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
					" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
					" WHERE personCode = '" + personCode + "'))) AND " +
					"(v_AssetApplyList.IsKeeping <> 1 OR IsKeeping IS NULL)  AND (ApplyProcessType.IsSubmit = 0) and applytypecode  in ('" + AssetCode + "') " +
					" ORDER BY v_AssetApplyList.ApplyDate DESC";

				DataSet ds= Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
				if(ds!= null && ds.Tables.Count > 0)
				{
					this.dgApplyHead.DataSource = ds;
					this.dgApplyHead.DataBind();
				}

			}

		}
	

		#region  ��һ����Ŀ  

		//		private void BindFirstClassSubject()
		//		{
		//			//ϵͳ��ǰ�� �� ��ǰ��¼��Ա���� 
		//			int iYear = DateTime.Today.Year ;
		//			DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
		//
		//			string ClassDept = "";
		//
		//			if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
		//			{
		//				ClassDept = dtDeptClass.Rows[0][0].ToString();
		//			}
		//			if(!ClassDept.Equals(""))
		//			{
		//
		//				DataSet ds = Bussiness.AssetBudgetBll.SelectFirstClassSubjectByYearAndDept(iYear,ClassDept);
		//				if (ds!=null && ds.Tables.Count > 0 ) 
		//				{
		//
		//
		//				}
		//
		//			}
		//
		//		}

		#endregion

		#region �ؼ����� 
		private void openControlEnable()
		{
//			this.ddlType.Enabled = true;
//			this.tbApplyDate.Enabled = true;
//			this.ddlClassDept.Enabled = true;
//			this.ddlDept.Enabled = true;
//			this.ddlFirstSubject.Enabled = true;
//			this.tbPerson.Enabled = true;
//			this.tbDeliveryDate.Enabled = true;
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
			this.btnInBudget.Click += new System.EventHandler(this.btnInBudget_Click);
			this.btnOutBudget.Click += new System.EventHandler(this.btnOutBudget_Click);
			this.dgApplyHead.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApplyHead_ItemCommand);
			this.dgApplyHead.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgApplyHead_PageIndexChanged);
			this.dgApplyHead.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApplyHead_ItemDataBound);
			this.btnAddBody.Click += new System.EventHandler(this.btnAddBody_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			//Ԥ�����ύ
			//����������ύ ����ֹ
			//�ҵ���Ӧ�������� ���±�ͷ
			//���±�Ԥ��״̬ 
			//�����ύ��ť״̬ 
			try
			{
				this.lbMsg.Text = "" ; 
				if(!"".Equals(this.hideApplyHead.Value ))
				{
					int ApplyHeadKey =int.Parse(this.hideApplyHead.Value);
					//����������Ϣ
					Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead!=null)
					{
						#region �Ƿ�Ϊ�ύ״̬

						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
						{
							this.lbMsg.Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
							return ;
						}
						#endregion

						//���ݽ�� 
						decimal AssetApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

						Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						if(AssetBudget == null )
						{
							this.lbMsg.Text ="û�ж�ӦԤ�����Ϣ������ϵ�����ң�";
							return ;
						}
						//Ԥ�㲿��
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
						if(BaseDept == null || BaseDept.BudgetDeptCode.Length <=0 )
						{
							this.lbMsg.Text ="û������Ԥ�㲿�š�����ϵ�����ң�";
							return ;
						}
						//Ԥ����Ϣ
						DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BaseDept.BudgetDeptCode ,AssetBudget.ItemName);
						
						if(DsBudget == null || DsBudget.Tables .Count <=0 )
						{
							this.lbMsg.Text ="û�ж�ӦԤ����Ϣ������ϵ�����ң�";
							return ;
						}

						if(decimal.Parse(DsBudget.Tables[0].Rows[0]["LeftMoney"].ToString()) < AssetApplyMoney )
						{
							//ʣ�����
							this.lbMsg.Text = "ʣ����㣬�����ύ��";
							return; 
						}

						#region 

						//ƥ����������

						//��ǰ�û����ڲ���
						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						//�������
						decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);  //�����������
						//�����ں��鲿��
						string DecisionDept = Bussiness.AssetCheckFlowBLL.FindDecisionDeptByApplyHeadPk(ApplyHeadKey);

						


						//ƥ����������
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindAssetByCodeAndType(ApplyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ApplyMoney,MydeptCode,DecisionDept); 
						if(TypeInFlow!=null)
						{
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );

							if(!"".Equals(checkRole))
							{
								ApplyHead.CurrentCheckRole=checkRole;
								ApplyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								ApplyHead.CheckSetp=CheckStep;
								ApplyHead.Update();

								// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode);

								updatePross(ApplyHeadKey);   //��������״̬

								//								//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���

								//Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
								if(AssetBudget != null )
								{
									//									ά������ 4���ֶ� 

									//									���뵥���ҽ��	SheetRmbMoney
									//									����Ԥ��		SumCheckMoney
									//									����Ԥ������	AllowOutMoney
									//									�Ƿ�Ԥ����/��	SubmitType

									//���ݽ�� 
									AssetBudget.SheetRmbMoney = AssetApplyMoney ;
									//���������
									AssetBudget.SumCheckMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["CheckMoney"].ToString()) ; 
									//Ԥ������
									AssetBudget.AllowOutMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["TotalOutMoney"].ToString());
									//�ύ����Ԥ����
									AssetBudget.SubmitType = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["InCorntType"]); 

									AssetBudget.Update();

									//����Ԥ���� ��������� 

									Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply(ApplyHeadKey);
								}

							}
							else
							{
								Response.Write(Message);
								HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
							}

							if(IsGiveUp == 1 )
							{
								//���û���������,ѭ�����÷�������;
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();

								Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
								//ȡ�������ʼ�
//								//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//								mailBll.ThreadSendMail();
							}
						}
						else
						{
							this.lbMsg.Text = "δ���������������!����ϵ������ ";
						}
						#endregion 
					}
					SetButtonsEnable(ApplyHeadKey);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddAssetApply.SubmitInBudget",ex.Message);
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




		private void btnOutBudget_Click(object sender, System.EventArgs e)
		{
			//Ԥ�����ύ

			try
			{
				this.lbMsg.Text = "" ; 
				if(!"".Equals(this.hideApplyHead.Value ))
				{
					int ApplyHeadKey =int.Parse(this.hideApplyHead.Value);
					//����������Ϣ
					Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead!=null)
					{
						#region �Ƿ�Ϊ�ύ״̬

						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
						{
							this.lbMsg.Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
							return ;
						}
						#endregion


						//���ݽ�� 
						decimal AssetApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

						Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						if(AssetBudget == null )
						{
							this.lbMsg.Text ="û�ж�ӦԤ�����Ϣ������ϵ�����ң�";
							return ;
						}
						//Ԥ�㲿��
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);

						if(BaseDept == null || BaseDept.BudgetDeptCode.Length <=0 )
						{
							this.lbMsg.Text ="û��Ԥ�㲿�š�����ϵ�����ң�";
							return ;
						}

						//Ԥ����Ϣ
						DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BaseDept.BudgetDeptCode,AssetBudget.ItemName);
						
						if(DsBudget == null || DsBudget.Tables .Count <=0 )
						{
							this.lbMsg.Text ="û�ж�ӦԤ����Ϣ������ϵ�����ң�";
							return ;
						}


						#region 

						//ƥ����������

						//��ǰ�û����ڲ���
						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						//�������
						decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);  //�����������
						//�����ں��鲿��
						string DecisionDept = Bussiness.AssetCheckFlowBLL.FindDecisionDeptByApplyHeadPk(ApplyHeadKey);

						//ƥ����������
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindAssetByCodeAndType(ApplyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ApplyMoney,MydeptCode,DecisionDept); 
						if(TypeInFlow!=null)
						{
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );

							if(!"".Equals(checkRole))
							{
								ApplyHead.CurrentCheckRole=checkRole;
								ApplyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								ApplyHead.CheckSetp=CheckStep;
								ApplyHead.Update();

								// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode);

								updatePross(ApplyHeadKey);   //��������״̬

								if(AssetBudget != null )
								{
									//ά��4���ֶ� 

									//���ݽ�� 
									AssetBudget.SheetRmbMoney = AssetApplyMoney ;
									//���������
									AssetBudget.SumCheckMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["CheckMoney"].ToString()) ; 
									//Ԥ������
									AssetBudget.AllowOutMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["TotalOutMoney"].ToString());
									//�ύ����Ԥ����
									AssetBudget.SubmitType = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"]); 
									//�ύ����
									AssetBudget.Update();

									//����Ԥ���� ��������� 
									Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply(ApplyHeadKey);
								}
							}
							else
							{
								Response.Write(Message);
								HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
							}
							if(IsGiveUp == 1 )
							{
								//���û���������,ѭ�����÷�������;
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();

								Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
								//ȡ�������ʼ�
//								//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//								mailBll.ThreadSendMail();
							}
						}
						else
						{
							this.lbMsg.Text = "δ���������������!����ϵ������ ";
						}
						#endregion 
					}
					SetButtonsEnable(ApplyHeadKey);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddAssetApply.SubmitInBudget",ex.Message);
			}

		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{

			openControlEnable();
		}

	


		private void btnSave_Click(object sender, System.EventArgs e)
		{
			#region ��ӱ�ͷ��ť 
//			//�����ͷ��Ϣ
//			string applyNo="";
//			string applyType=this.ddlType.SelectedValue;
//			DateTime  applyDate=new DateTime();
//			if(!"".Equals(this.tbApplyDate.Text))
//			{
//				applyDate=DateTime.Parse(tbApplyDate.Text);
//				//�������ڲ���С�� ��ǰ�·�............
//				if(applyDate.Year < DateTime.Today.Year || (applyDate.Year == DateTime.Today.Year && applyDate.Month < DateTime.Today.Month) )
//				{
//					this.lbMsg.Text= "�������ڲ���Ϊ��ǰ�·ݣ�";
//					return ;
//				}
//			}
//			string applyDeptClass=this.ddlClassDept.SelectedValue;
//			string applyDept=this.ddlDept.SelectedValue;
//			//string applySubject=this.ddlSubject.SelectedValue;
//			string personCode=this.tbPerson.Text;
//			string firstSubject=this.ddlFirstSubject.SelectedValue;
//			string  DeliveryDate="";
//			if(!"".Equals(tbDeliveryDate.Text))
//			{
//				DeliveryDate=tbDeliveryDate.Text;
//			}
//
//			#region ����ǿ�����
//			if("".Equals(applyType))
//			{
//				this.lbMsg .ForeColor=Color.Red;
//				this.lbMsg.Text="���Ͳ���Ϊ��";
//				return;
//			}
//			if("".Equals(tbApplyDate.Text))
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="�������ڲ���Ϊ��";
//				return;
//			}
//			if("".Equals(applyDeptClass))
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="���벿�Ų���Ϊ��";
//				return;
//			}
//			if("".Equals(applyDept))
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="������鲻��Ϊ��";
//				return;
//			}
//			if("".Equals(firstSubject))
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="һ����Ŀ����Ϊ��";
//				return;
//			}
//			//			if("".Equals(applySubject))
//			//			{
//			//				this.lbMsg.ForeColor=Color.Red;
//			//				this.lbMsg.Text="�����Ŀ����Ϊ��";
//			//				return;
//			//			}
//
//
//			Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
//			if(person==null)
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="��Ա������";
//				return ;
//			}
//			#endregion 
//
//			#region ���ɵ��ݺ�
//			//1.ȡǰ׺
//			Entiy.ApplyType applyTyp=Entiy.ApplyType.Find(applyType);
//			if(applyTyp!=null)
//			{
//				applyNo=applyTyp.ApplySheetEncode ;
//			}
//			else
//			{
//				this.lbMsg.Text="���ɵ��ݺŴ���!";
//				return ;
//			}
//			//2.ȡ����
//			int iYear=applyDate.Year;
//			int iMonth=applyDate.Month;
//			string tempMonth=iMonth.ToString();
//			for(int iLength=iMonth.ToString().Length ;iLength<2;iLength++)
//			{
//				tempMonth="0"+tempMonth;
//			}
//			applyNo += iYear.ToString();
//			applyNo += tempMonth;
//
//			//3.ȡ��ˮ��
//			string  MaxNum1=Bussiness.ApplySheetHeadBLL.GetMaxSheetNo(applyNo);
//			int MaxNum=0;
//			if(!"".Equals(MaxNum1))
//			{
//				MaxNum=int.Parse(MaxNum1.Trim());
//			}
//			MaxNum += 1;
//			string applyMaxNum=MaxNum.ToString();
//
//			for(int iLength=MaxNum.ToString().Length ;iLength<5;iLength++)
//			{
//				applyMaxNum="0"+applyMaxNum;
//			}
//			//4.�ϲ����ݺ�
//			applyNo = applyNo + applyMaxNum;
//
//			#endregion 
//
//			
//			string personMakerCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
//
//			//���浥�ݱ�ͷ��Ϣ 
//
//			Entiy.ApplySheetHead applySheet=new HDSZCheckFlow.Entiy.ApplySheetHead();
//			applySheet.ApplySheetNo=applyNo;
//			applySheet.ApplyTypeCode=applyType;
//			applySheet.ApplyDate=applyDate;
//			applySheet.ApplyDeptClassCode =applyDeptClass;
//			applySheet.ApplyDeptCode=applyDept;
//			//applySheet.SheetSubject =applySubject;
//			applySheet.ApplyPersonCode=personCode ;
//			applySheet.ApplyMakerCode=personMakerCode;
//			applySheet.DeliveryDate = DeliveryDate ;
//			applySheet.SubmitDate = System.DateTime.Now;         // �ύʱ��Ϊϵͳ��ǰʱ��
//			applySheet.ExpenseDate  = DateTime.Parse("1900-01-01"); //�������� ��Ĭ������
//
//			applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //�½�״̬
//
//			applySheet.Create();
//
//			//��� Asset_ApplySheet_Budget
//			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);
//
//			Entiy.AssetApplySheetBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.AssetApplySheetBudget();
//
//			if(applyHead!=null)
//			{
//				ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
//				ApplyHeadBudget.ItemName=firstSubject;
//				//ApplyHeadBudget.SheetSubject=applySubject;
//				ApplyHeadBudget.Create();
//			}
//
//			//			this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //��¼�˴���ӵı�ͷPK
//
//
//
//			//��Ӹ�������
//			this.hyLindToAnnex.Visible=true;
//			this.hyLindToAnnex.Target = "_blank";
//			this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;
//
//
//
//			//��Ӹ�������
//			this.hyLindToAnnex.Visible=true;
//			this.hyLindToAnnex.Target = "_blank";
//			this.hyLindToAnnex.NavigateUrl= "../../CheckFlow/CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;
//
//			//��ʾ���ſ�ĿԤ�����
//
//			Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(applyDept);
//			if(BaseDept != null )
//			{
//				BindBudgetInfo(applyDate.Year,BaseDept.BudgetDeptCode,firstSubject);
//			}
//
//			this.lblApplyNo.Text = applyNo; 
//
//			this.lblMakeDate.Text = DateTime.Now.ToString();
//
//			//��ʾ���� 
//
//			this.pAddItem.Visible = true;
//			this.dgApply.Visible= true;
//
//			//��ʾ��ǰ����ӦԤ����Ϣ
//			//��ť״̬
//			this.btnSave.Enabled = false;
//			this.btnEdit.Enabled = true;
//			this.btnAdd.Enabled = true;
//
//			//��ʼ����ӱ����
//			
//			BindInitAddBody();
//
//			BindAssetBody(applyHead.ApplySheetHeadPk);
//
//			//ȫ�ֱ�����¼��ͷֵ
//			this.hideApplyHead.Value = applyHead.ApplySheetHeadPk.ToString()  ; 
//
//
			#endregion 
		}

		private void BindBudgetInfo (int ApplyHeadKey)
		{
			#region ��ʾԤ����Ϣ

			this.lbMsg.Text = "";

			this.PBudgetInfo.Visible = true;
			// ����Ϊ������Ϊ�жϱ�׼
			//1.���������·ݣ��ó���ǰ���ڼ���
			//2.�õ����Ƚ��ϼ�
			//3.�жϱ�׼��ӿ��Ǵ�̯���

			this.lblSheetMoney .Visible = true;

			DataSet ds = Bussiness.AssetBudgetBll.SelectAssetBudgetByApplyHeadKey(ApplyHeadKey);

			if(ds != null)
			{
				this.lblBudget.Text = ds.Tables[0].Rows[0]["BudgetMoney"].ToString();
				this.lblSumCheck.Text=ds.Tables[0].Rows[0]["CheckMoney"].ToString();
				this.lblready.Text  = ds.Tables[0].Rows[0]["ReadyPay"].ToString();
				this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalOutMoney"].ToString();
				this.lblSheetMoney.Text = ds.Tables[0].Rows[0]["ApplyMoney"].ToString();
				this.lblLeft.Text=ds.Tables[0].Rows[0]["LeftMoney"].ToString();

				//����Ԥ��ʱ�������û�������
				if(ds.Tables[0].Rows[0]["LeftMoney"].ToString() !="" &&  decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString().ToString())  < 0 )
				{
					this.lbMsg.Text = "Ԥ�㳬��������д��Ԥ����������";
				}
			}		
			#endregion 

			//�������
			decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);  //�����������
			Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(AssetBudget != null )
			{
				AssetBudget.SheetRmbMoney = ApplyMoney;
				AssetBudget.Update();
			}

			if(this.lblLeft.Text != "")
			{
				decimal NowLeftMoney = decimal.Parse(this.lblLeft.Text) - ApplyMoney ; 

				this.lblLeft.Text = NowLeftMoney.ToString("N2");

			}

			//this.lblLeft.Text = 

			


		}

		private void BindInitAddBody(string ItemName)
		{
			#region ��ʼ����ӱ���������ؼ�

			//ѡ��һ����Ŀ��Ӧ���ӿ�Ŀ��Ϣ || ��ʱ�޶�����Ŀ 
//			string ItemName = this.ddlFirstSubject.SelectedValue;
			int iYear  = DateTime.Today.Year;
			DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));

			string ClassDept = "";

			if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
			{
				ClassDept = dtDeptClass.Rows[0][0].ToString();
			}
			if(!ClassDept.Equals(""))
			{
				DataSet ds = Bussiness.AssetBudgetBll.SelectSubItemByYearAndFirstItem (iYear,ClassDept,ItemName);
				if(ds!=null && ds.Tables.Count > 0 )
				{
					this.ddlSubjectCode.DataSource=ds.Tables[0];
					ddlSubjectCode.DataValueField=ds.Tables[0].Columns["SubjectName"].ToString();
					ddlSubjectCode.DataTextField =ds.Tables[0].Columns["SubjectName"].ToString();
					ddlSubjectCode.DataBind();
					ddlSubjectCode .Items.Insert(0,"");
				}
			}


			//��λ

			string cmdStr = "select  * from Base_Unit where isStop <> 1  order by unitName ";

			DataSet Dunits = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			if(Dunits!=null && Dunits.Tables.Count > 0 )
			{
				this.ddlUnit.DataSource = Dunits.Tables[0];
				this.ddlUnit.DataValueField = "id";
				this.ddlUnit.DataTextField = "unitName";
				this.ddlUnit.DataBind();
				this.ddlUnit.Items.Insert(0,"");

			}

			//����

			string cmdStrcurrency = "select currtypecode,currtypeName  from Base_currencyType group by currtypecode,currtypeName";
			DataSet Dcurr = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStrcurrency);
			if(Dcurr != null && Dcurr .Tables.Count > 0 )
			{

				this.ddlcurrTypeCode .DataSource = Dcurr.Tables[0];
				this.ddlcurrTypeCode.DataValueField = "currtypecode";
				this.ddlcurrTypeCode.DataTextField = "currtypeName";
				this.ddlcurrTypeCode.DataBind();
				this.ddlcurrTypeCode.Items.Insert(0,"");
			}

			#endregion 
		}

		private void BindAssetBody(int applyHeadPk)
		{
			#region �󶨱�����Ϣ

			this.pAddItem.Visible = true;

			string cmdStr = "select * from dbo.v_Asset_ApplySheet_Body where applySheetHead_pk = " +  applyHeadPk.ToString()  + " order by id desc "  ; 

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			if(ds!=null && ds.Tables.Count >0 )
			{
				this.dgApply.DataSource = ds ;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply.DataSource = null;
				this.dgApply.DataBind();
			}
			#endregion 
		}




		private void btnAddBody_Click(object sender, System.EventArgs e)
		{
			// ��ӱ���
			// this.hideApplyHead.Value  ��ͷֵ 
			// �������ֵ�Ƿ���ȷ
			// ��� 
			this.lbMsg.Text = "";

			if(!IsNumeric(this.tbNumber.Text.Trim()))
			{
				this.lbMsg.Text = "������������";
				return;
			}
			if(!IsNumeric(this.tbOriginalcurrPrice.Text.Trim()))
			{
				this.lbMsg.Text = "���۲�������";
				return;
			}
			if(this.ddlUnit.SelectedItem.Text == "")
			{
				this.lbMsg.Text = "��λ����Ϊ��";
				return ;
			}
			if(this.ddlcurrTypeCode.SelectedItem.Text == "")
			{
				this.lbMsg.Text = "���ֲ���Ϊ��";
				return ;
			}

			//���ݲ����½�״̬�������

			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
			if(ApplyHead == null )
			{
				this.lbMsg.Text = "ϵͳ�����Ҳ������ݣ�";
				return ;
			}

			string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

			if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
			{
				this.lbMsg.Text = "�˵������½�״̬��������ӣ�";
				return ;
			}

			if(ApplyHead.IsOverBudget == 1 )
			{
				this.lbMsg.Text = "�˵����ΪԤ���ⵥ����������";
				return ;
			}

			Entiy.AssetApplySheetBody AssetBody = new HDSZCheckFlow.Entiy.AssetApplySheetBody();
			AssetBody.ApplySheetHeadPk = int.Parse(this.hideApplyHead.Value);
			AssetBody.SubjectName      = this.ddlSubjectCode.SelectedItem.Text.Trim();
			AssetBody.InventoryName    = this.tbInvName.Text;
			AssetBody.InvType          = this.tbInvType.Text;
			AssetBody.BaseUnitId       = int.Parse(this.ddlUnit.SelectedValue);
			AssetBody.Number           = int.Parse(this.tbNumber.Text.Trim());
			AssetBody.OriginalcurrPrice= decimal.Parse(this.tbOriginalcurrPrice.Text.Trim());
			AssetBody.OriginalMoney    = int.Parse(this.tbNumber.Text.Trim()) * decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) ;
			AssetBody.CurrTypeCode     = this.ddlcurrTypeCode.SelectedValue ;
			AssetBody.ExchangeRate     = SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim());			//����
			AssetBody.RmbPrice         = decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) *   SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim()) ;    //���ҵ���
			AssetBody.RmbMoney         = int.Parse(this.tbNumber.Text.Trim()) * decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) * SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim()) ;           //���ҽ��

			AssetBody.Create();
		
			//�󶨵�������ʾ
			BindAssetBody(int.Parse(this.hideApplyHead.Value));

			//���㱾������¼�����Ϣ
			BindBudgetInfo(int.Parse(this.hideApplyHead.Value));

			//��������ύ״̬

			//int.Parse(this.hideApplyHead.Value)
			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));

		}

		private void SetButtonsEnable(int ApplyHeadPk)
		{
			// 1 ȫ������
			// 2 Ԥ���ڿ���
			// 3 Ԥ�������
			int i=Bussiness.ApplySheetHeadForAssetBLL.SetButtonEnableForAsset(ApplyHeadPk);
			switch(i)
			{
				case 1:
					this.btnInBudget.Enabled=false;
					this.btnOutBudget.Enabled=false;
					break;
				case 2:
					this.btnInBudget.Enabled=true;
					this.btnOutBudget.Enabled=false;
					break;
				case 3:
					this.btnInBudget.Enabled=false;
					this.btnOutBudget.Enabled=true;
					break;
			}
		}




		#region ���������Ƿ�Ϊ����

		/// <summary>
		/// ���������Ƿ�Ϊ����
		/// </summary>
		/// <param name="Mail_One">�����ַ���</param>
		/// <returns>bool</returns>
		private  bool IsNumeric(string num)
		{
			//bool Validate_result = true;

			//Validate_result = Regex.IsMatch(num.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,3})$");

			string a = "^(-?[0-9]*[.]*[0-9]{0,3})$" ;  //������ 

			string b = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"  ;  //��������

			if(Regex.IsMatch(num.Trim(), @a) || Regex.IsMatch(num.Trim(), @b))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

		#region ��ѯ���ֵĻ�׼����(1������)
		private decimal SelectRateByCurrCode(string CurrCode)
		{
			//��ѯ���ֵĻ�׼���ʡ� ��׼����Ϊ����1������

			//Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.FindByYearAndMonth(CurrCode,DateTime.Today.Year,1);
			//�����������ʡ� ͳһ���ʡ�
			Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.Find(CurrCode);
			if(CurrType != null )
			{
				return CurrType.ExchangeRate ;
			}
			else
			{
				return  0 ;
			}
		}
		#endregion

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("delete")) //���������ť
			{
				this.lbMsg.Text = "";
				
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
				if(ApplyHead == null )
				{
					this.lbMsg.Text = "ϵͳ�����Ҳ������ݣ�";
					return ;
				}

				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
				{
					this.lbMsg.Text = "�˵������½�״̬������ɾ����";
					return ;
				}

				if(ApplyHead.IsOverBudget == 1 )
				{
					this.lbMsg.Text = "�˵����ΪԤ���ⵥ����������";
					return ;
				}

				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(int.Parse(e.Item.Cells[0].Text.Trim()));
					if(AssetBody != null ) 
					{
						AssetBody.Delete();
					}
				}
				//���¼��㱾����� && ʣ����
				BindBudgetInfo(int.Parse(this.hideApplyHead.Value));
				//�󶨵�������ʾ
				BindAssetBody(int.Parse(this.hideApplyHead.Value));
			}

			//���º����°󶨰�ť����״̬
			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));
		}

	

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//�󶨸�����ť��ʾ��Ϣ
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('��ȷ��ɾ����?');"); 
			}

		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			//ȡ����ť
			this.ddlSubjectCode.SelectedIndex = -1 ;
			this.ddlUnit.SelectedIndex = -1 ;
			this.ddlcurrTypeCode.SelectedIndex = -1 ;

			this.tbInvName.Text = "";
			this.tbNumber.Text = "";
			this.tbInvType.Text = "";
			this.tbOriginalcurrPrice.Text = "";

		}

		private static  Color color;

		private void dgApplyHead_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//��� ѡ�� / ɾ��

			if(e.CommandName.Equals("delete")) 
			{
				#region ɾ��

				this.hyLindToAnnex.Visible = false;

				this.lbMsg.Text = "";

				//��ͷId
				int ApplyHeadKey = int.Parse(e.Item.Cells[0].Text) ;
				
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(ApplyHead == null )
				{
					this.lbMsg.Text = "ϵͳ�����Ҳ������ݣ�";
					return ;
				}

				if(ApplyHead.IsOverBudget == 1 )
				{
					this.lbMsg.Text = "�˵����ΪԤ���ⵥ����������";
					return ;
				}

				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
				{
					this.lbMsg.Text = "�˵������½�״̬������ɾ����";
					return ;
				}

				//ɾ����
				ApplyHead.Delete();

				//���°ﶨ��ͷ
				BindEditAssetApply() ; 

				//ʣ���� && ���� ����

				this.PBudgetInfo.Visible = false;

				this.dgApply.DataSource = null;
				this.dgApply.DataBind();

				this.pAddItem.Visible = false;

				#endregion 
			}
			if(e.CommandName.Equals("select"))
			{
				#region ѡ��

				this.lbMsg.Text  = "";

				#region �б�ɫ
				for(int i=0;i<this.dgApplyHead.Items.Count ;i++)
				{
					if(this.dgApplyHead.Items[i].BackColor== Color.Yellow)
					{
						this.dgApplyHead.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow; //Color.Yellow;
				e.Item.ForeColor = Color.FromArgb(0,51,153);    //��ϵͳ��ɫ�����ѯrgbֵ
				#endregion 

				int ApplyHeadKey = int.Parse(e.Item.Cells[0].Text) ;

				//��¼��������
				this.hideApplyHead.Value = ApplyHeadKey.ToString();

				#region  �󶨴˱���Ӧ����

				//��ʾԤ����Ϣ
				BindBudgetInfo(ApplyHeadKey);

				//�󶨵�������ʾ
				this.pAddItem.Visible = true;
				BindAssetBody(ApplyHeadKey);

				//��ʼ����ӱ���������ؼ�
				Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
				if(AssetBudget !=null)
				{
					BindInitAddBody(AssetBudget.ItemName);
				}
				
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../../CheckFlow/CheckFlow/ApplySheetAnnex.aspx?returnurl=EditAssetApply.aspx&ApplyHeadPk=" + ApplyHeadKey.ToString()   ;


				#endregion

				#region �жϿ��ύ��ť

				SetButtonsEnable(ApplyHeadKey);

				#endregion 

				#endregion 
			}

		}



		private void dgApplyHead_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//�󶨸�����ť��ʾ��Ϣ
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[2].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('��ȷ��ɾ����?');"); 
			}
		}

		private void dgApplyHead_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			//��ͷ��ҳ
			this.dgApplyHead.CurrentPageIndex = e.NewPageIndex;

			BindEditAssetApply() ; 

			//����Ԥ�� && ���� ��Ϣ
			
			this.PBudgetInfo.Visible = false;
			this.pAddItem.Visible = false;

		}
	
	}
}
