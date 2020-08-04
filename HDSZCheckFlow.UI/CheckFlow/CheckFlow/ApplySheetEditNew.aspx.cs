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
	public class ApplySheetEditNew : System.Web.UI.Page
	{
		#region  ����
		protected XPGrid.XpGrid XPGrid2;
		protected System.Web.UI.WebControls.Button btnOutConrt;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblAnnexMsg;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.Button btnInConrt;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected XPGrid.XpGrid XPGrid1;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
                //XPGrid.DBStruct.CDBField field = new XPGrid.DBStruct.CDBField(111);


//				//�����Ϊ�������ļ�����ȡ�д��������ͱ���(2011-09-09 liyang) 
//				string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"]; //����
//				string banquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"]; //����
//				string assetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //��Ӫ
//
//				Utility.RegisterTypeForAjax(typeof(ApplySheet));
//				string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
//				if( !"".Equals(personCode))
//				{
//					//					��ѯ���ڱ��˵�δ�ύ������,�����ύû����������  , �ų� ������룬��Ӫ 
//					string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
//						" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
//						" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
//						" WHERE personCode = '" + personCode + "'))) AND " +
//						"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL)  AND (ApplyProcessType.IsSubmit = 0) and applytypecode not in ('"+evectionCode+"','"+banquetCode+"','" + assetCode + "') " +
//						" ORDER BY ApplySheetHead.ApplyDate DESC";
//					this.XPGrid1.CommandText=cmdStr;
//					
//					//					else
//					//					{
//					//						this.XPGrid1.CommandText="select * from ApplySheetHead where  (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
//					//						this.XPGrid1.DataBind();
//					//					}
//				}

				if(!Page.IsPostBack)
				{

					//Ŀǰ����Ҫ��Ӳ���
					//InitPageForAdd();

					 BindMyFileView();
				}
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString());
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}

		private void BindMyFileView()
		{
			//�����Ϊ�������ļ�����ȡ�д��������ͱ���(2011-09-09 liyang) 
			string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"]; //����
			string banquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"]; //����
			string assetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //��Ӫ

			Utility.RegisterTypeForAjax(typeof(ApplySheet));
			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
			if( !"".Equals(personCode))
			{
				//					��ѯ���ڱ��˵�δ�ύ������,�����ύû����������  , �ų� ������룬��Ӫ 
				string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
					" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
					" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
					" WHERE personCode = '" + personCode + "'))) AND " +
					"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL)  AND (ApplyProcessType.IsSubmit = 0) and applytypecode not in ('"+evectionCode+"','"+banquetCode+"','" + assetCode + "') " +
					" ORDER BY ApplySheetHead.ApplyDate DESC";
				this.XPGrid1.CommandText=cmdStr;
					
				//					else
				//					{
				//						this.XPGrid1.CommandText="select * from ApplySheetHead where  (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
				//						this.XPGrid1.DataBind();
				//					}
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
			this.btnInConrt.Click += new System.EventHandler(this.btnInConrt_Click);
			this.btnOutConrt.Click += new System.EventHandler(this.btnOutConrt_Click);
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.XPGrid1.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.XPGrid1_SelectedIndexChanged);
			this.XPGrid2.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid2_BeforeUpdateData);
			this.XPGrid2.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XPGrid2_AfterUpdate);
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

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


		#region ��ʾ���ſ�ĿԤ�����
		private void BindBudgetInfo(int  key,int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			this.Label2.Visible=true;
			this.Label3.Visible=true;
			this.Label4.Visible=true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			this.Label8.Visible =true;
			this.Label9.Visible =true; 	
			this.Label12.Visible =true;

			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,dept.BudgetDeptCode,Sheetsubject );
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
				if(ds != null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(iYear,iMonth,applyDept,Sheetsubject);

					this.lblBudget.Text=ds.Tables[0].Rows[0]["budgetmoney"].ToString();
					this.lblPush.Text=ds.Tables[0].Rows[0]["planmoney"].ToString();
					this.lblChange.Text=ChangeMoney.ToString("N2");
					this.lblSumCheck.Text=ds.Tables[0].Rows[0]["checkmoney"].ToString();
					this.lblready.Text  = ds.Tables[0].Rows[0]["readypay"].ToString();
					this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
					this.lblAlterMoney.Text =  ds.Tables[0].Rows[0]["alterMoney"].ToString();
					
				
					//���ó�֧��׼��Ԥ��������㡣
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
					decimal leftmoney = 0 ; 
					if (budgetStandard == 1 )  //Ԥ��
					{
						leftmoney=decimal.Parse(this.lblBudget.Text) + ChangeMoney + decimal.Parse(this.lblOutMoney.Text) - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text)-ThisMoney ;	
					}
					else if(budgetStandard == 2 ) // ����
					{
						leftmoney=decimal.Parse(this.lblPush.Text) + ChangeMoney + decimal.Parse(this.lblOutMoney.Text) - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text)-ThisMoney ;	
					}
					this.lblSheetMoney.Text=ThisMoney.ToString("N2");			

					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
					if(applyHead!=null)
					{
						Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
						if(prossType!=null)
						{
							if(prossType.IsSubmit==0)
							{
								this.lblLeft.Text=leftmoney.ToString("N2");
							}
						}
					}
				}
			}

			#region ����
			//			Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(iYear,iMonth,applyDept,Sheetsubject);
			//			decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
			//			if(budgetAccount!=null)
			//			{
			//				decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(iYear,iMonth,applyDept,Sheetsubject);
			//
			//				this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");
			//				this.lblPush.Text = budgetAccount.PlanMoney.ToString("#,###.##");
			//				this.lblChange.Text=ChangeMoney.ToString("#,###.##");
			//				this.lblAdd.Text=budgetAccount.BudgetAddMoney.ToString("#,###.##");
			//				this.lblSumCheck.Text=budgetAccount.CheckMoney.ToString("#,###.##");
			//				
			//				int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today );
			//				decimal leftmoney = 0 ; 
			//				if (budgetStandard == 1 )  //Ԥ��
			//				{
			//					leftmoney=budgetAccount.BudgetMoney + ChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;	
			//				}
			//				else if(budgetStandard == 2 ) // ����
			//				{
			//					leftmoney=budgetAccount.PlanMoney + ChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;	
			//				}
			//
			//
			//				this.lblSheetMoney.Text=ThisMoney.ToString("#,###.##");
			//				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
			//				if(applyHead!=null)
			//				{
			//					Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
			//					if(prossType!=null)
			//					{
			//						if(prossType.IsSubmit==0)
			//						{
			//							this.lblLeft.Text=leftmoney.ToString("#,###.##");
			//						}
			//						else
			//						{
			//							Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
			//							if(applyBudget!=null)
			//							{
			//								//decimal left=budgetAccount.BudgetMoney + budgetAccount.BudgetChangeMoney + budgetAccount.BudgetAddMoney-applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
			//								decimal left=budgetAccount.PlanMoney + ChangeMoney -applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
			//								this.lblLeft.Text=left.ToString("#,###.##");
			//								this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");
			//							}
			//						}
			//					}
			//				}
			//			}
			#endregion 
		}

		#endregion 

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
					//					this.XPGrid2 .Visible=true;
					//					this.XPGrid2.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk =" + keys[0] + " order by InventoryName asc";
					//					this.XPGrid2.DataBind();

					//�ж���ͷ��Щ��ť���� ,������ť���жϣ�Ԥ�����жϽ�Ԥ�����жϣ�ȡ�ص����ж��Ƿ񱻲��� or ��δ��������
					SetButtonEnable(int.Parse(keys[0]));
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
					Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));

					if(applyHead!=null && applyBudget!=null)
					{
						BindBudgetInfo(int.Parse(keys[0]),applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);//��ʾ���ſ�ĿԤ�����

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

					//��Ӹ�������
					this.hyLindToAnnex.Visible=true;
					this.hyLindToAnnex.Target = "_blank";
					this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=ApplySheetEdit.aspx&ApplyHeadPk=" + keys[0]   ;
				}
				else
				{
					this.XPGrid2.Visible=false;
					this.hyLindToAnnex.Visible=false;
				}
				#endregion 
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}


		#region �ж���Щ��ť����
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

		#endregion 

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
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )  //�����½�״̬  ���� ����Ԥ�������� ����������׼
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
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )   //�����½�״̬  ���� ����Ԥ�������� ����������׼
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

				
				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applySheet.ApplyTypeCode);   
				if(applyTypes !=null )
				{
					//�������ʱ��,���ܽ�ֵ(�������ֱ������Լ��պ��������Ĵ���)
					if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
					{
						#region 
						//���ܽ�ֵ�����ҵ��۸�ֵ
						decimal number=0;                 //����
						decimal orPrice=0;����������������//ԭ�ҵ���
						string  bizhong="";				  //���֡���ͨ�����ֵõ�������,���㱾�ҵ��ۣ��ܽ��
						string inventycode = "";          //�������

						for (int i = 0; i <= XPGrid2.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid2.FieldList[i]; 
							object ob = XPGrid2.GetInputControlValue(F); 
							if (F.ColName == "NUMBER") 
							{ 
								number = System.Convert.ToDecimal(ob); 

								if(number==0) //��������Ϊ0
								{
									XPGrid2.ShowMessage("��������Ϊ�ջ�0��",System.Drawing.Color.Red);
									continueUpdate=false;
									return;
								}

							} 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob); 
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob); 
							} 
							if (F.ColName == "INVENTORYCODE")           //������� InventoryCode
							{ 
								inventycode  = System.Convert.ToString(ob); 
							} 
						} 


						//2014-03-21 ���ġ��ɴ������ ���� ���֡��۸� ��Ϣ����������������������������������


						// ��ȡ�˴������� ���֡��۸� 
						//string cmdStrPrice = "select ISNULL(RealCurrTypeCode,CurrTypeCode ) as currTypeCode,ISNULL(RealOriginalcurPrice,OriginalcurPrice ) as OriginalcurPrice   from dbo.Base_inventory where inv_pk = '" + inventycode.Trim() + "'";
						//string cmdStrPrice = "select ISNULL(RealCurrTypeCode,CurrTypeCode ) as currTypeCode,ISNULL(RealOriginalcurPrice,OriginalcurPrice ) as OriginalcurPrice   from dbo.Base_inventory where inv_pk = '" + inventycode.Trim() + "'";
						string cmdStrPrice = "select RealCurrTypeCode as currTypeCode,RealOriginalcurPrice  as OriginalcurPrice   from dbo.Base_inventory where inv_pk = '" + inventycode.Trim() + "'";




						DataSet dsPrice = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStrPrice) ;

						if(dsPrice != null && dsPrice.Tables.Count > 0 && dsPrice.Tables[0].Rows.Count > 0 )
						{
							//-------------------------- (liyang 2014-08-08)-----����ԭ�ҵ���Ϊ0������----------------------
							string orPriceStr=dsPrice.Tables[0].Rows[0]["OriginalcurPrice"].ToString();
							if(orPriceStr=="" || orPriceStr.Trim().Length==0) //ԭ�ҵ��۲���Ϊ0
							{
								XPGrid2.ShowMessage("������û��ά�����ۣ�",System.Drawing.Color.Red);
								continueUpdate=false;
								return;
							}
							else
							{
							   orPrice = decimal.Parse(dsPrice.Tables[0].Rows[0]["OriginalcurPrice"].ToString().Trim());
							}
							//--------------------------------------------------------------------------------
							bizhong = dsPrice.Tables[0].Rows[0]["currTypeCode"].ToString();
							
						}
						else    //û�ҵ�������Ϣ
						{
							XPGrid2.ShowMessage("�Բ��𣬴����ϱ��뵥����Ϣ����",System.Drawing.Color.Red);
							continueUpdate=false;
						}		
						//����������������������������������������������������������������������������������




						Entiy.ApplySheetHeadBudget applyBudget  = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
						if(applyBudget!=null)
						{
							string budgetSubject = applyBudget.SheetSubject ;    // Ԥ���Ŀ
							int nums = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubject(budgetSubject);  //Ԥ���Ŀ�����˿���
							if (nums > 0 )
							{
								// ȡǰ��λ
								//								int nums2 = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubjectAndAccount(budgetSubject,inventycode.Substring(0,3));      // �Ҳ������ƵĴ������

								//2012-07-06 ��д�� p_Apply_ControlPurchaseCode���ſ�����λ��
								string cmdStr = "exec p_Apply_ControlPurchaseCode  '" + budgetSubject + "','" + inventycode +"'" ;
								int nums2 = Bussiness.ComQuaryBLL.GetExecuteScalar(cmdStr); 

								if (nums2 == 0 )
								{
									XPGrid2.ShowMessage("�Բ��𣬹�����Ʒ�����������Ŀ��",System.Drawing.Color.Red);
									continueUpdate=false;							
								}
							}
						}
						else
						{
							XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
							continueUpdate=false;								
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
							if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
							{
								XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							//originalcurrPrice
							if (!MyChgSql.ChgResultSql(ref ResultSql,"CURRTYPECODE","'" + bizhong.ToString() + "'")) // ����
							{
								XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							if (!MyChgSql.ChgResultSql(ref ResultSql,"ORIGINALCURRPRICE",RmbMoney.ToString())) //ԭ�ҵ���
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
					else if("ApplySheetBody_Pay".Equals(applyTypes.ApplySheetBodyTableName))
					{
						//�������Լ��պ��������Ĵ���
						#region 

						//���ܽ�ֵ�����ҵ��۸�ֵ
				
						decimal orPrice=0;����������������//ԭ�ҽ��
						string  bizhong="";				  //���֡���ͨ�����ֵõ�������,���㱾�ҵ��ۣ��ܽ��


						for (int i = 0; i <= XPGrid2.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid2.FieldList[i]; 
							object ob = XPGrid2.GetInputControlValue(F); 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob);   //����
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob);  //ԭ�ҽ��
							} 
						} 
						Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
						if(currType!=null)
						{
							decimal TotalMoney= currType.ExchangeRate * orPrice;          //RMB ���

							if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
							{
								XPGrid2.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
							{
								XPGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
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


		#region �ύԤ��������
		private void btnInConrt_Click(object sender, System.EventArgs e)
		{
			//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			//			{
			try
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
					// �ȿ������Ƿ��Ѿ����ύ״̬
					string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

					if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
					{
						this.lblMessage .Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
						return ;
					}
					///////////2014-03-20 ʵ���ͱ����͵� �ύǰ ���±��֡������Ϣ [p_Apply_AutoUpdatePrice] ���ύʱ�̷�ֹ�۸�䶯  //////////////////////////

					Bussiness.BudgetAccountBLL.UpdateApplyPriceFromApplyHeadPk(int.Parse(keys[0]));

					// 2014-08-25  �����жϣ������º�ʵ�������б��嵥��Ϊ0����NULL�Ȳ�����ֵ����ܾ��ύ 
					//p_ApplyForPurchasePriceNull

					DataSet DsIsNullPrice =  Bussiness.BudgetAccountBLL.IsNullApplyPriceFromApplyHeadPk(int.Parse(keys[0]));
					if(DsIsNullPrice != null && DsIsNullPrice.Tables.Count >0 && DsIsNullPrice.Tables[0].Rows.Count >0 )
					{
						this.lblMessage.Text ="�˵���������Ϣ���󣬲����ύ";
						return;

					}


					/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

					/////////2014-01-07 ��� ����һ���ж�  p_getBudgetInfobySheetHeadPk   �����Ϊ�������ֹ�ύ  /////
					///

					DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));
					if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
					{
						this.lblMessage.Text ="�˵������Ϣ���󣬲����ύ";
						this.lblMessage.ForeColor = Color.Red;
						return;
					} 


					//************************���۸������ʱ���ܳ��ֵ�ʵ�ʵ���Ϊ��ʱҲ���ύ��BUG��������Ҫ��ֹ��������ύ��liyang 2014-08-13��**************************************
					//DataSet leftds = Bussiness.BudgetAccountBLL .getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));		
					/*Entiy.ApplySheetBodyPurchase[] applySheetBodyPurchase=Entiy.ApplySheetBodyPurchase. FindByApplyHeadPk(int.Parse(keys[0]));
							
					for(int i=0;i<applySheetBodyPurchase.Length;i++)
					{
						decimal orprice=applySheetBodyPurchase[i].OriginalcurrPrice;
						if(orpice==null || orpice=="")
						{
							this.lblMessage.Text ="�����ϵ���Ϊ�յ�";
							this.lblMessage.ForeColor = Color.Red;
							//return;
							break;
						}
					}*/

						 ///////////////////////////////////////////END////////////////////////////////////////////////////

						 #region 
						 decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //�����������


					string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
					Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
					if(TypeInFlow!=null)
					{
						//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
						//							string Message="";
						//							int CheckStep=0,DeptToCompany=0 ;
						//							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);

						string Message="",	NextCheckCode ="";
						int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
						if(!"".Equals(checkRole))
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

							//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
							//
							//								//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
							//								mailBll.ThreadSendMail();

							updatePross(int.Parse(keys[0]));   //��������״̬

							//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
							Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
							if(applyHeadBudget!=null )
							{
								Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
								//decimal tempMoney=budgetAccount.CheckMoney ;
								Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
								DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

								decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;


								decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //�����Ԥ������
								//ds = null; 

								budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
						
								budgetAccount.Update();
								applyHeadBudget.SumCheckMoney = tempMoney ;
								string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
								applyHeadBudget.SubmitType = int.Parse(submitType) ;// InCorntType
								applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

								applyHeadBudget.Update();
							}
						}
						else
						{
							this.lblMsg.Text="û���ҵ����������ɫ";
							HDSZCheckFlow.Common.Log.Logger.Log("�ύԤ��������","û���ҵ����������ɫ");
						}

										
						if(IsGiveUp ==1 )
						{
							//���û���������,ѭ�����÷�������;
							Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
							Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);


							//								Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
						}
						else
						{
							//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
								

								
//							Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
//							Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

							//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
							//
							//
							//								mailBll.ThreadSendMail();
						}
					
					}
					else
					{
						this.lblMsg.Text="δ�����������!!!!!";
					}
					#endregion 
				}
				//					tran.VoteCommit();
				SetButtonEnable(int.Parse(keys[0]));
			}
			catch(Exception ex)
			{
				//					tran.VoteRollBack();
				Common.Log.Logger.Log("applyedit.btnInConrt_Click",ex.Message );
			}
			//			}

		}
		#endregion  

		#region  �ύԤ�������� 
		private void btnOutConrt_Click(object sender, System.EventArgs e)
		{
			//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			//			{
			try
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
					// �ȿ������Ƿ��Ѿ����ύ״̬
					string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

					if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
					{
						this.lblMessage .Text = "�˵��Ѿ��ύ��!�벻Ҫ�ظ��ύ";
						return ;
					}

					///////////2014-03-20 ʵ���ͱ����͵� �ύǰ ���±��֡������Ϣ [p_Apply_AutoUpdatePrice] ���ύʱ�̷�ֹ�۸�䶯  //////////////////////////
						
					Bussiness.BudgetAccountBLL.UpdateApplyPriceFromApplyHeadPk(int.Parse(keys[0]));


					// 2014-08-25  �����жϣ������º�ʵ�������б��嵥��Ϊ0����NULL�Ȳ�����ֵ����ܾ��ύ 
					//p_ApplyForPurchasePriceNull

					DataSet DsIsNullPrice =  Bussiness.BudgetAccountBLL.IsNullApplyPriceFromApplyHeadPk(int.Parse(keys[0]));
					if(DsIsNullPrice != null && DsIsNullPrice.Tables.Count >0 && DsIsNullPrice.Tables[0].Rows.Count >0 )
					{
						this.lblMessage.Text ="�˵���������Ϣ���󣬲����ύ";
						return;

					}


					/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
					


					/////////2014-01-07 ��� ����һ���ж�  p_getBudgetInfobySheetHeadPk   �����Ϊ�������ֹ�ύ  /////
					///

					DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));
					if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
					{
						this.lblMessage.Text ="�˵������Ϣ���󣬲����ύ";
						return;
					}
							

					//************************���۸������ʱ���ܳ��ֵ�ʵ�ʵ���Ϊ��ʱҲ���ύ��BUG��������Ҫ��ֹ��������ύ��liyang 2014-08-13��**************************************
					//DataSet leftds = Bussiness.BudgetAccountBLL .getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));		
					/*Entiy.ApplySheetBodyPurchase[] applySheetBodyPurchase=Entiy.ApplySheetBodyPurchase. FindByApplyHeadPk(int.Parse(keys[0]));
							
					for(int i=0;i<applySheetBodyPurchase.Length;i++)
					{
						decimal orprice=applySheetBodyPurchase[i].OriginalcurrPrice;
						if(orprice==0 )
						{
							this.lblMessage.Text ="�����ϵ���Ϊ�յ�";
							this.lblMessage.ForeColor = Color.Red;
							//return;
							break;
						}
					}*/

							



					///////////////////////////////////////////END////////////////////////////////////////////////////

					#region 
					Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(int.Parse(keys[0]));
			
					decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //�����������


					string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
					Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
					if(TypeInFlow!=null)
					{
						//���µ�ǰ������ɫ		,δ�ҵ�������ɫд��־, ˵������������������
						//							string Message="";
						//							int CheckStep=0,DeptToCompany=0 ;
						//							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
						string Message="",	NextCheckCode ="";
						int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
						if(!"".Equals(checkRole) )
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

							//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
							//
							//								//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
							//								mailBll.ThreadSendMail();


							updatePross(int.Parse(keys[0]));

							//�ύ��ռԤ�㣬����Ԥ������ռ��Ԥ���
							Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
							if(applyHeadBudget!=null )
							{
								Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
								//decimal tempMoney=budgetAccount.CheckMoney ;
								Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
								DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );
								

								decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
								//ds = null; 
								//dept = null;
								//decimal AllowOutMoney = budgetAccount.TotalAllowOutMoney;   //�����Ԥ������
								decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //�����Ԥ������

								budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
								budgetAccount.Update();
								applyHeadBudget.SumCheckMoney = tempMoney ;
								string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
								applyHeadBudget.SubmitType = int.Parse(submitType) ;// OutCorntType

								applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

								applyHeadBudget.Update();
							}

											
							if(IsGiveUp ==1 )
							{
								//���û���������,ѭ�����÷�������;

								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
								Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

								//									Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
								//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
								
								//
								//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
								//
								//									mailBll.ThreadSendMail();
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
					#endregion 
				}
				//	tran.VoteCommit();
				SetButtonEnable(int.Parse(keys[0]));
			}
			catch(Exception ex)
			{
				//tran.VoteRollBack();
				Common.Log.Logger.Log("applyedit.btnOutConrt_Click",ex.Message );
			}
			//}

		}
		#endregion  

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
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet","�Ҳ���applyHeadBudget" + keys[0].ToString() );
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
					if(applyPross.IsSubmit!=0 || applyPross.IsSubmitAgain==1 || applySheet.IsOverBudget ==1 )
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
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )
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

		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			//���±�������Ϣ

			this.lblMessage.Text = "";

			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}

			///////////2014-03-20 ʵ���ͱ����͵� �ύǰ ���±��֡������Ϣ [p_Apply_AutoUpdatePrice] ���ύʱ�̷�ֹ�۸�䶯  //////////////////////////
						
			Bussiness.BudgetAccountBLL.UpdateApplyPriceFromApplyHeadPk(int.Parse(keys[0]));

			this.lblMessage.Text = "�޸ĳɹ�";








		}

 



   



 






	
	
		
	

	

	}
}
