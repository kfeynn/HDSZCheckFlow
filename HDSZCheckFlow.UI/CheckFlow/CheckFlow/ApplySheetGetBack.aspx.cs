//public class ApplySheetGetBack : System.Web.UI.Page
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
	public class ApplySheetGetBack : System.Web.UI.Page
	{
		#region  ����
		protected XPGrid.XpGrid XPGrid2;
		protected System.Web.UI.WebControls.Button btnGetBack;
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
		protected System.Web.UI.WebControls.Label Label1;
		protected XPGrid.XpGrid XPGrid1;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				BindMyFileView() ; 
				
			
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}


		private void BindMyFileView()
		{
			
			string AssetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //�ų���Ӫ��

				string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
				if( !"".Equals(personCode))
				{
					string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
						" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
						" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
						" WHERE personCode = '" + personCode + "'))) AND  ApplySheetHead.ApplyTypeCode <> " + AssetCode + " and " +
						"(((ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL)) AND (ApplyProcessType.IsDisallow = 1) or (ApplyProcessType.IsSubmitAgain=1 and ApplyProcessType.IsSubmit= 0 and  ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL ) or (ApplyProcessType.IsSubmit=1 and ApplyProcessType.IsCheck=0 and ApplyProcessType.IsSubmitAgain=0) )" +
						" ORDER BY ApplySheetHead.ApplyDate DESC";
					this.XPGrid1.CommandText=cmdStr;				
				}

		}

	
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
			this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
			this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.XPGrid1.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.XPGrid1_SelectedIndexChanged);
			this.XPGrid2.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid2_BeforeUpdateData);
			this.XPGrid2.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XPGrid2_AfterUpdate);
			this.Load += new System.EventHandler(this.Page_Load);

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
								decimal left=budgetAccount.PlanMoney + budgetAccount.BudgetChangeMoney -applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
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
							applySheet.IsCheckInCompany=0;
							applySheet.CheckSetp=0;                                  //����������Ϊ0
							RemoveBudget(applySheet.ApplySheetHeadPk);
							applySheet.Update();
						}
						else if(applyProcess.IsDisallow == 1)
						{
							//����Ϊȡ��״̬, ��������������pkΪ 0
							applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.GetBackPross;
							applySheet.CheckFlowInCompanyHeadPk=0;
							applySheet.CurrentCheckRole="";
							applySheet.IsCheckInCompany=0;
							applySheet.CheckSetp=0;                                  //����������Ϊ0
							RemoveBudget(applySheet.ApplySheetHeadPk);
							applySheet.Update();
						
						}
					}
				}
			}
			//BindMyFileView() ; 
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
				applyHeadBudget.SumCheckMoney = 0 ; // �˿��ۼƽ������Ϊ0

				
				applyHeadBudget.AllowOutMoney = 0 ;  //Ԥ����������Ϊ0
			
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
