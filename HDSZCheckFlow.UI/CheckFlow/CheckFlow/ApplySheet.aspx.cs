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
using System.Threading;

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ApplySheet ��ժҪ˵����
	/// </summary>
	public class ApplySheet : System.Web.UI.Page
	{
		#region  ����
		protected XPGrid.XpGrid XPGrid2;
		protected System.Web.UI.WebControls.Button btnPress;
		protected System.Web.UI.WebControls.Button btnInConrt;
		protected System.Web.UI.WebControls.Button btnOutConrt;
		protected System.Web.UI.WebControls.Button btnGetBack;
		protected System.Web.UI.WebControls.DropDownList ddlSubmitType;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.TextBox txtPersonName;
		protected System.Web.UI.WebControls.TextBox txtPerson;
		protected System.Web.UI.WebControls.DropDownList ddlSubject;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblAdd;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Button btnKeep;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected XPGrid.XpGrid XPGrid1;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				Utility.RegisterTypeForAjax(typeof(ApplySheet));
				string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
				if( !"".Equals(personCode))
				{
					if(!"Test".Equals(personCode) && !"Admin".Equals(personCode))
					{
						this.XPGrid1.CommandText="select * from ApplySheetHead WHERE (ApplyDeptClassCode = (SELECT superior_Dept_pk FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person WHERE personCode = '" + personCode + "'))) and (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
					}
					else
					{
						this.XPGrid1.CommandText="select * from ApplySheetHead where  (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
					}
				}

				if(!Page.IsPostBack)
				{

					InitPageForAdd();
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}

		#region  ��ʼ�������˵�
		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyType (deptClassCode);
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
					this.ddlSubject.DataSource=dtSubject;
					ddlSubject.DataValueField=dtSubject.Columns[0].ToString();
					ddlSubject.DataTextField =dtSubject.Columns[1].ToString();
					ddlSubject.DataBind();
					ddlSubject.Items.Insert(0,"");
				}
				DataTable dtProssType=Bussiness.ApplyProcessTypeBll.GetProssType();
				if(dtProssType!=null && dtProssType.Rows.Count >0 )
				{
					this.ddlSubmitType.DataSource=dtProssType;
					this.ddlSubmitType.DataValueField=dtProssType.Columns[0].ToString();
					this.ddlSubmitType.DataTextField=dtProssType.Columns[1].ToString();
					this.ddlSubmitType.DataBind();
					this.ddlSubmitType.Items.Insert(0,"");
				}
		
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
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
			this.ddlSubmitType.SelectedIndexChanged += new System.EventHandler(this.ddlSubmitType_SelectedIndexChanged);
			this.btnPress.Click += new System.EventHandler(this.btnPress_Click);
			this.btnInConrt.Click += new System.EventHandler(this.btnInConrt_Click);
			this.btnOutConrt.Click += new System.EventHandler(this.btnOutConrt_Click);
			this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
			this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.XPGrid1.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.XPGrid1_SelectedIndexChanged);
			this.XPGrid2.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid2_BeforeUpdateData);
			this.XPGrid2.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XPGrid2_AfterUpdate);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region  �󶨿���
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlDeptClass.SelectedValue;
			DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClass(deptClass);
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

		#region  ��Ӱ�ť
		private void btnAdd_Click(object sender, System.EventArgs e)
		{
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
				}
				string applyDeptClass=this.ddlDeptClass.SelectedValue;
				string applyDept=this.ddlDept.SelectedValue;
				string applySubject=this.ddlSubject.SelectedValue;
				string personCode=this.txtPerson.Text;

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

					
				Entiy.ApplySheetHead applySheet=new HDSZCheckFlow.Entiy.ApplySheetHead();
				applySheet.ApplySheetNo=applyNo;
				applySheet.ApplyTypeCode=applyType;
				applySheet.ApplyDate=applyDate;
				applySheet.ApplyDeptClassCode =applyDeptClass;
				applySheet.ApplyDeptCode=applyDept;
				//applySheet.SheetSubject =applySubject;
				applySheet.ApplyPersonCode=personCode ;
				applySheet.ApplyMakerCode=personMakerCode;

				applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //�½�״̬

				applySheet.Create();

				//���ApplySheetHead_Budget ��
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);

				Entiy.ApplySheetHeadBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.ApplySheetHeadBudget();
				if(applyHead!=null)
				{
					ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
					ApplyHeadBudget.SheetSubject=applySubject;
					ApplyHeadBudget.Create();
				}
				//this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //��¼�˴���ӵı�ͷPK

				this.lblMessage.ForeColor=Color.Blue;
				this.lblMessage.Text="��ӳɹ�";

				//��û�в��ſ�Ŀ��¼,���ʼ��һ����ֵ
				string message="";
				Bussiness.BudgetAccountBLL.SaveBudgetAccount(applyDate.Year,applyDate.Month,applyDept,applySubject,out message);
				if(!"".Equals(message))
				{
					this.lblMessage.Text=message;
				}

							
				//this.XPGrid1.Visible=true;
				this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message);
			}
		}
		#endregion 

		//��ʾ���ſ�ĿԤ�����
		private void BindBudgetInfo(int  key,int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			this.Label2.Visible=true;
			this.Label3.Visible=true;
			//this.Label4.Visible=true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(iYear,iMonth,applyDept,Sheetsubject);
			decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
			if(budgetAccount!=null)
			{
				decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(iYear,iMonth,applyDept,Sheetsubject);

				//this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");
				this.lblBudget.Text=budgetAccount.PlanMoney.ToString("#,###.##");
				//this.lblChange.Text=budgetAccount.BudgetChangeMoney.ToString("#,###.##");
				this.lblChange.Text=ChangeMoney.ToString("#,###.##");
				this.lblAdd.Text=budgetAccount.BudgetAddMoney.ToString("#,###.##");
				this.lblSumCheck.Text=budgetAccount.CheckMoney.ToString("#,###.##");
				//decimal leftmoney=budgetAccount.BudgetMoney + budgetAccount.BudgetChangeMoney + budgetAccount.BudgetAddMoney - budgetAccount.CheckMoney-ThisMoney ;
				
				//decimal leftmoney=budgetAccount.PlanMoney + budgetAccount.BudgetChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;		

				decimal leftmoney=budgetAccount.PlanMoney + ChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;	
		

				this.lblSheetMoney.Text=ThisMoney.ToString("#,###.##");
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
				if(applyHead!=null)
				{
					Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
					if(prossType!=null)
					{
						if(prossType.IsSubmit==0)
						{
							this.lblLeft.Text=leftmoney.ToString("#,###.##");
						}
						else
						{
							Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
							if(applyBudget!=null)
							{
								//decimal left=budgetAccount.BudgetMoney + budgetAccount.BudgetChangeMoney + budgetAccount.BudgetAddMoney-applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
								decimal left=budgetAccount.PlanMoney + ChangeMoney -applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
								this.lblLeft.Text=left.ToString("#,###.##");
								this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");
							}
						}
					}
				}
			}

		}


		private void XPGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				#region ѡ�е���ͷ����д������Ϣ

				if(XPGrid1.GetEditState() == XPGrid.CEditState.NotInEdit)
				{
					string[] keys = this.XPGrid1.GetSelectedKey();
					if(keys == null || keys.Length == 0)
					{
						return;
					}
					
//					this.XPGrid2.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk =" + keys[0] + " order by InventoryName asc";
//					this.XPGrid2.DataBind();

					//�ж���ͷ��Щ��ť���� ,������ť���жϣ�Ԥ�����жϽ�Ԥ�����жϣ�ȡ�ص����ж��Ƿ񱻲��� or ��δ��������
					SetButtonEnable(int.Parse(keys[0]));
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
					Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));

					if(applyHead!=null && applyBudget!=null)
					{
						BindBudgetInfo(int.Parse(keys[0]),applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);//��ʾ���ſ�ĿԤ�����
					
						//
						// �������뵫����, �жϱ�����õı� , ��������ʵ����,��ʵ��������
						//
						//�ҵ���ر���  ApplyType  ���뵥�����ͱ�
						Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						if(applyTypes !=null )
						{
							this.XPGrid2 .Visible=true;
							this.XPGrid2.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
							this.XPGrid2.DataBind();
						}
					}
				}
				else
				{
					this.XPGrid2.Visible=false;
				}
				#endregion 
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}

		
		private void SetButtonEnable(int key)
		{			
			// 1 �����������ã� < 3000 
			// 2 Ԥ���ڿ���
			// 3 Ԥ�������
			// 4 ���� and Ԥ���� ����
			// 5 ���� and Ԥ���� ����
			// 6 ��������ȫ������
			// 7 û�б��壬������
			// 8 ���ִ���
			// Na==1 ���ؿ��� Na==2  ������
			int Na;
			int i=Bussiness.ApplySheetHeadBLL.SetButtonEnable(key,out Na);

			switch(i)
			{
				case 2:
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					this.btnPress.Enabled=false;
					break;
				case 3:
					this.btnOutConrt.Enabled=true;
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					break;
				case 4:
					this.btnPress.Enabled=true;
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					break;
				case 5:
					this.btnPress.Enabled=true;
					this.btnOutConrt.Enabled=true;
					this.btnInConrt.Enabled=false;
					break;
				case 6:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 7:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 8:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
			}
			if(Na==1)
			{
				this.btnGetBack.Enabled=true;
			}
			else
			{
				this.btnGetBack.Enabled=false;
			}
			if(Na==2)
			{
				this.btnKeep.Enabled=true;
			}
			else
			{
				this.btnKeep.Enabled=false;
			}
		}

	
		private void XPGrid2_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			#region ��Ӽ�¼ʱ��ϵͳά������ı�ͷ����
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0)
					{
						XPGrid2.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//����ͷ���� ��ֵ
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0)
					{
						XPGrid2.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql,"APPLYSHEETHEAD_PK",keys[0]))
				{
					XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
					continueUpdate=false;
				}	

				//�������ʱ��,���ܽ�ֵ(�������ֱ������Լ��պ��������Ĵ���)
				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applySheet.ApplyTypeCode);   
				if(applyTypes !=null )
				{
					if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
					{
						#region 

						//���ܽ�ֵ�����ҵ��۸�ֵ
						decimal number=0;                 //����
				
						decimal orPrice=0;����������������//ԭ�ҵ���
						string  bizhong="";				  //���֡���ͨ�����ֵõ�������,���㱾�ҵ��ۣ��ܽ��


						for (int i = 0; i <= XPGrid2.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid2.FieldList[i]; 
							object ob = XPGrid2.GetInputControlValue(F); 
							if (F.ColName == "NUMBER") 
							{ 
								number = System.Convert.ToDecimal(ob); 
							} 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob); 
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob); 
							} 
						} 
						Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
						if(currType!=null)
						{
							decimal TotalMoney=number * currType.ExchangeRate * orPrice;          //�ܽ��

							if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
							{
								XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							decimal RmbMoney=currType.ExchangeRate * orPrice ;                     //���ҵ���
							if (!MyChgSql.ChgResultSql(ref ResultSql,"RMBPRICE",RmbMoney.ToString()))
							{
								XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
								continueUpdate=false;
							}
						}
						else                       //��������
						{
							XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
							continueUpdate=false;
						}	

						#endregion 
					}
				}
			}
			#endregion
		}
	
		private void btnPress_Click(object sender, System.EventArgs e)
		{
			//��������
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			
			Entiy.CheckFlowInCompanyhead checkFlow=Entiy.CheckFlowInCompanyhead.FindByFlowCode("jinji"); //��������Code ,,��Ϊ�ж����̱�ʶ 3 !!!!!
			if(checkFlow!=null)
			{
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applyHead!=null)
				{				
					//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
					#region  
//					string Message="";
//					int CheckStep=0,DeptToCompany=0 ;
//					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//
//				
//					if(!"".Equals(checkRole))
//					{
					string Message="",	NextCheckCode ="";
					int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
					if(IsGiveUp ==1 )
					{
						//���û���������,ѭ�����÷�������;
						Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
						Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//						Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
					}

					else if(!"".Equals(checkRole) && IsGiveUp == 0 )
					{
						applyHead.CurrentCheckRole=checkRole;

						applyHead.CheckFlowInCompanyHeadPk =checkFlow.CheckFlowInCompanyHeadPk ;

						applyHead.CheckSetp=CheckStep;
						
						applyHead.Update();

//						// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 
//
//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//								
//						//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//
//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

						//�����ʼ�
//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
						Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//						//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//						mailBll.ThreadSendMail();
						

						updatePross(int.Parse(keys[0]));

						//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
						Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
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
						this.lblMsg.Text="û���������������ɫ";
						HDSZCheckFlow.Common.Log.Logger.Log("�ύ��������","û���ҵ����������ɫ");
					}
					#endregion  
				}
			}
			else
			{
				this.lblMsg.Text="δ���������������!!!!";
			}

			SetButtonEnable(int.Parse(keys[0]));

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


		private void btnInConrt_Click(object sender, System.EventArgs e)
		{
			//Ԥ�������� , ����״̬
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}

			//����������Ϣ
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			if(applyHead!=null)
			{
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //�����������


				string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
				Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
				if(TypeInFlow!=null)
				{
					//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
//					string Message="";
//					int CheckStep=0,DeptToCompany=0 ;
//					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//
//					if(!"".Equals(checkRole))
//					{

					string Message="",	NextCheckCode ="";
					int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
					if(IsGiveUp ==1 )
					{
						//���û���������,ѭ�����÷�������;
						Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
						Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//						Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
					}

					else if(!"".Equals(checkRole) && IsGiveUp == 0 )
					{
						applyHead.CurrentCheckRole=checkRole;
						applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
						applyHead.CheckSetp=CheckStep;
						applyHead.Update();

//						// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 
//
//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//							
//						//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//
//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

						//�����ʼ�
//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
						Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//						//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//						mailBll.ThreadSendMail();

						updatePross(int.Parse(keys[0]));   //��������״̬

						//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
						Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
						if(applyHeadBudget!=null )
						{
							Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
							decimal tempMoney=budgetAccount.CheckMoney ;
							budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
						
							budgetAccount.Update();
							applyHeadBudget.SumCheckMoney = tempMoney ;
							string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
							applyHeadBudget.SubmitType = int.Parse(submitType) ;// InCorntType
							applyHeadBudget.Update();
						}
					}
					else
					{
						this.lblMsg.Text="û���ҵ����������ɫ";
						HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
					}
				}
				else
				{
					this.lblMsg.Text="δ�����������!!!!!";
				}
			}
			SetButtonEnable(int.Parse(keys[0]));

		}


		private void btnOutConrt_Click(object sender, System.EventArgs e)
		{
			//Ԥ��������
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}

			//����������Ϣ
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			if(applyHead!=null)
			{
				Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(int.Parse(keys[0]));
			
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //�����������


				string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
				Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
				if(TypeInFlow!=null)
				{
					//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
//					string Message="";
//					int CheckStep=0,DeptToCompany=0 ;
//					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
//					if(!"".Equals(checkRole))
//					{
					string Message="",	NextCheckCode ="";
					int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
					if(IsGiveUp ==1 )
					{
						//���û���������,ѭ�����÷�������;
						Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
						Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//						Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
					}

					else if(!"".Equals(checkRole) && IsGiveUp == 0 )
					{
						applyHead.CurrentCheckRole=checkRole;
					
						applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;

						applyHead.CheckSetp=CheckStep;

						applyHead.Update();

//						// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 
//
//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//							
//						//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//
//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

						//�����ʼ�
//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
						Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//						//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//						mailBll.ThreadSendMail();


						updatePross(int.Parse(keys[0]));

						//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
						Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
						if(applyHeadBudget!=null )
						{
							Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
							decimal tempMoney=budgetAccount.CheckMoney ;
							budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
							budgetAccount.Update();
							applyHeadBudget.SumCheckMoney = tempMoney ;
							string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
							applyHeadBudget.SubmitType = int.Parse(submitType) ;// OutCorntType
							applyHeadBudget.Update();
						}
					}
					else
					{
						this.lblMsg.Text="û���ҵ����������ɫ";
						HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
					}
				}
				else
				{
					this.lblMsg.Text="δ�����������!!!!!";
				}
			}
			SetButtonEnable(int.Parse(keys[0]));

		}


		private void btnGetBack_Click(object sender, System.EventArgs e)
		{
			//ȡ�ر�, 1,���ǻ�û����������ȡ��, ����Ϊ�½�״̬, 2.�����ص�ȡ��,����Ϊȡ��״̬

			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			
			if(applySheet!=null)
			{
				if(applySheet.ApplyProcessCode!=null)
				{
					Entiy.ApplyProcessType applyProcess=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode); //�鿴���뵥����
					if(applyProcess!=null)
					{
						if((applyProcess.IsSubmit == 1 && applyProcess.IsCheck==0 ) )  //�½���δ�������� or ����
						{
							//����Ϊ�½�״̬, ��������������pkΪ 0
							applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;
							applySheet.CheckFlowInCompanyHeadPk=0;
							applySheet.CurrentCheckRole="";
							applySheet.CheckSetp=-1;                                  //����������Ϊ-1
							RemoveBudget(applySheet.ApplySheetHeadPk);
							applySheet.Update();
						}
						else if(applyProcess.IsDisallow == 1)
						{
							//����Ϊȡ��״̬, ��������������pkΪ 0
							applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.GetBackPross;
							applySheet.CheckFlowInCompanyHeadPk=0;
							applySheet.CurrentCheckRole="";
							applySheet.CheckSetp=-1;                                  //����������Ϊ-1
							RemoveBudget(applySheet.ApplySheetHeadPk);
							applySheet.Update();
						
						}
					}
				}
			}
			SetButtonEnable(int.Parse(keys[0]));
		}


		private void RemoveBudget(int key)
		{
			//����Ԥ������ռ��Ԥ���,
			Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
			Entiy.ApplySheetHead  applyHead=Entiy.ApplySheetHead.Find(key);
			if(applyHeadBudget!=null &&  applyHead!=null)
			{
				Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
				budgetAccount.CheckMoney = budgetAccount.CheckMoney - applyHeadBudget.SheetMoney;
				budgetAccount.Update();
				applyHeadBudget.SumCheckMoney = 0 ;
			
				applyHeadBudget.SubmitType = 0 ;// OutCorntType
				applyHeadBudget.Update();
			}
		}


		private void XPGrid2_AfterUpdate(object sender, XPGrid.CUpdateType updateType, string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			SetButtonEnable(int.Parse(keys[0]));

			//���±��ŵ����
			decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));
			Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
			if(applyHeadBudget!=null)
			{
				applyHeadBudget.SheetMoney=ThisMoney; //�����ۼƽ��
				applyHeadBudget.Update();
			}
			else
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet","�Ҳ���applyHeadBudget");
			}
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));

			if(applyHead!=null && applyBudget!=null)
			{
				BindBudgetInfo(int.Parse(keys[0]),applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);//��ʾ���ſ�ĿԤ�����
			}
		}


		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0 || applyPross.IsSubmitAgain==1)
					{
						XPGrid1.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//�жϵ���״̬���Ƿ��ܱ༭
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0)
					{
						XPGrid1.ShowMessage("�Բ��𣬴˵���������״̬��",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}

				#region ά�����ݺ�
				string applyNo="";
				string applyType="";
				DateTime  applyDate=new DateTime();

				for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
				{ 
					XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
					object ob = XPGrid1.GetInputControlValue(F); 
					if (F.ColName == "APPLYTYPECODE") 
					{ 
						applyType = System.Convert.ToString (ob); 
					} 
					if (F.ColName == "APPLYDATE") 
					{ 
						applyDate = System.Convert.ToDateTime(ob); 
					} 
				} 
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

				//���޸ĺ��ǰ׺,��֮ǰ��ǰ׺��ͬʱ,��ˮ�Ų��� 
				string sheetNO=applySheet.ApplySheetNo ;
				string per=sheetNO.Substring(0,sheetNO.Length-5);
				if(applyNo.Equals(per))
				{
					applyNo=applySheet.ApplySheetNo;
				}
				else
				{
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
				}
				#endregion 

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql," APPLYSHEETNO","'" + applyNo.ToString() + "'"))
				{
					XPGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
					continueUpdate=false;
				}	
				#endregion 
			}
		}

	

	
		private void ddlSubmitType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string ddlValue=this.ddlSubmitType.SelectedValue;

			this.XPGrid2.CommandText="";
			this.XPGrid2.DataBind();
			this.Label2.Visible=false;
			this.Label3.Visible=false;
			this.Label4.Visible=false;
			this.Label5.Visible=false;
			this.Label6.Visible=false;
			this.Label7.Visible=false;

			this.lblBudget.Text="";
			this.lblChange.Text="";
			this.lblAdd.Text="";
			this.lblSumCheck.Text="";
			this.lblSheetMoney.Text="";
			this.lblLeft.Text="";

			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));

			if(!"".Equals(ddlValue))
			{
				//ApplyProcessCode
				this.XPGrid1.CommandText="select * from ApplySheetHead WHERE ApplyProcessCode='" + ddlValue + "' and  (ApplyDeptClassCode = (SELECT superior_Dept_pk FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person WHERE personCode = '" + personCode + "'))) and (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
				this.XPGrid1.DataBind();
			}
			else
			{
				this.XPGrid1.CommandText="select * from ApplySheetHead WHERE   (ApplyDeptClassCode = (SELECT superior_Dept_pk FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person WHERE personCode = '" + personCode + "'))) and (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
				this.XPGrid1.DataBind();		
			}

		}

		private void btnKeep_Click(object sender, System.EventArgs e)
		{
			//��浥��
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			if(applyHead!=null)
			{
				applyHead.IsKeeping=1;    //��������Ϊ���״̬
				applyHead.Update();
			}
			SetButtonEnable(int.Parse(keys[0]));

		}
	}
}
