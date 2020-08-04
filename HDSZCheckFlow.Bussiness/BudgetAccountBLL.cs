using System;
using System.Data;
using Castle.ActiveRecord; 

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// BudgetAccountBLL ��ժҪ˵����
	/// </summary>
	public class BudgetAccountBLL
	{
		public BudgetAccountBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// Ԥ�㵼��
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">������ʾ��Ϣ</param>
		public static void BudgetAccountHelper(DataSet ds,out string lblMessage)
		{
			lblMessage="";
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{		
				using( TransactionScope tran = new TransactionScope())
				{
					try
					{
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							if(!"".Equals(ds.Tables[0].Rows[i]["���"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["�·�"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["���"].ToString().Trim());
								int iMonth=int.Parse(ds.Tables[0].Rows[i]["�·�"].ToString().Trim());
								string subjectCode=ds.Tables[0].Rows[i]["��Ŀ���"].ToString().Trim();
								string deptCode=ds.Tables[0].Rows[i]["���ű��"].ToString().Trim();
								float budgetMoney=float.Parse(ds.Tables[0].Rows[i]["Ԥ����"].ToString().Trim());

								Entiy.Budgetaccount budGet=HDSZCheckFlow.Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,subjectCode);
								if(budGet==null)
								{
									budGet=new HDSZCheckFlow.Entiy.Budgetaccount();
								}
								budGet.Iyear=iYear;
								budGet.Imonth =iMonth;
								budGet.DeptCode=deptCode;
								budGet.SubjectCode=subjectCode;
								budGet.BudgetMoney=(decimal)Math.Round(budgetMoney,3);
								budGet.Save();
							}
						}
						tran.VoteCommit();
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="��������excel��ʽ�Ƿ���ȷ";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="û�����ݣ�";
			}
		}


		/// <summary>
		/// ��ӪԤ�㵼��
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">������ʾ��Ϣ</param>
		public static void AssetBudgetAccountHelper(DataSet ds,out string lblMessage)
		{
			lblMessage="";
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{		
				using( TransactionScope tran = new TransactionScope())
				{
					try
					{
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							if(!"".Equals(ds.Tables[0].Rows[i]["���"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["���ű��"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["���"].ToString().Trim());
								string deptCode= ds.Tables[0].Rows[i]["���ű��"].ToString().Trim();
								string ItemName=ds.Tables[0].Rows[i]["��Ŀ"].ToString().Trim();
								string subjectName=ds.Tables[0].Rows[i]["��������"].ToString().Trim();
								string Num=ds.Tables[0].Rows[i]["����"].ToString().Trim();
								string Price=ds.Tables[0].Rows[i]["����"].ToString().Trim();
								string RmbMoeny=ds.Tables[0].Rows[i]["���"].ToString().Trim();
								string decisionDept=ds.Tables[0].Rows[i]["���鲿�ű��"].ToString().Trim();

								Entiy.AssetBudget budGet=HDSZCheckFlow.Entiy.AssetBudget.FindByYearAndItem(iYear,ItemName,deptCode,subjectName);
								if(budGet==null)
								{
									budGet=new HDSZCheckFlow.Entiy.AssetBudget();
								}
								budGet.Iyear = iYear ;
								budGet.DeptCode = deptCode;
								budGet.ItemName = ItemName;
								budGet.SubjectName = subjectName ;
								budGet.Number =int.Parse(Num);
								budGet.UnitPrice =(decimal) Math.Round(float.Parse(Price),3) ;
								budGet.BudgetMoney =(decimal)Math.Round (float.Parse( RmbMoeny) ,3); 
								budGet.BaseDecisionDeptCode = decisionDept ; 

//								budGet.Iyear=iYear;
//								budGet.Imonth =iMonth;
//								budGet.DeptCode=deptCode;
//								budGet.SubjectCode=subjectCode;
//								budGet.BudgetMoney=(decimal)Math.Round(budgetMoney,3);
								budGet.Save();
							}
						}
						tran.VoteCommit();
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="��������excel��ʽ�Ƿ���ȷ";
						Common.Log.Logger.Log("Bussiness.AssetBudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="û�����ݣ�";
			}
		}
		/// <summary>
		/// ���㵼��
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage"></param>
		public static void BudgetTuisuanHelper(DataSet ds,out string lblMessage)
		{
			lblMessage="";
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{		
				using( TransactionScope tran = new TransactionScope())
				{
					try
					{
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							if(!"".Equals(ds.Tables[0].Rows[i]["���"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["�·�"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["���"].ToString().Trim());
								int iMonth=int.Parse(ds.Tables[0].Rows[i]["�·�"].ToString().Trim());
								string subjectCode=ds.Tables[0].Rows[i]["��Ŀ���"].ToString().Trim();
								string deptCode=ds.Tables[0].Rows[i]["���ű��"].ToString().Trim();
								float PlanMoney=float.Parse(ds.Tables[0].Rows[i]["������"].ToString().Trim());

								Entiy.Budgetaccount budGet=HDSZCheckFlow.Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,subjectCode);
								if(budGet==null)
								{
									budGet=new HDSZCheckFlow.Entiy.Budgetaccount();
								}
								budGet.Iyear=iYear;
								budGet.Imonth =iMonth;
								budGet.DeptCode=deptCode;
								budGet.SubjectCode=subjectCode;
								budGet.PlanMoney =(decimal)Math.Round(PlanMoney,3);
								budGet.Save();
							}
						}
						tran.VoteCommit();
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="��������excel��ʽ�Ƿ���ȷ";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="û�����ݣ�";
			}
		}


		/// <summary>
		/// Ԥ���������
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">���ص���ʾ��Ϣ</param>
		public static void BudgetChangeHelper(DataSet ds,out string lblMessage)
		{
			lblMessage="";
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{
				using( TransactionScope tran = new TransactionScope())
				{
					try
					{
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							int iYear=int.Parse(ds.Tables[0].Rows[i]["�������"].ToString().Trim());
							int iMonth=int.Parse(ds.Tables[0].Rows[i]["�����·�"].ToString().Trim());
							DateTime sheetDate=DateTime.Parse(ds.Tables[0].Rows[i]["����������"].ToString().Trim());
							string deptCode=ds.Tables[0].Rows[i]["���ű��"].ToString().Trim();
							string sheetType=ds.Tables[0].Rows[i]["����������"].ToString().Trim();
							string outSubject=ds.Tables[0].Rows[i]["ת����Ŀ"].ToString().Trim();
							string inSubject=ds.Tables[0].Rows[i]["ת���Ŀ"].ToString().Trim();
							float money=float.Parse(ds.Tables[0].Rows[i]["���"].ToString().Trim());

							if("0".Equals(sheetType))  //0 = ����
							{
								#region 
								Entiy.BudgetchangeSheet budGetChange=HDSZCheckFlow.Entiy.BudgetchangeSheet.FindByYearAndMonth(iYear,iMonth);
								if(budGetChange==null)
								{
									Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,outSubject);
									if(budGet!=null && budGet.BudgetMoney>(decimal)money)
									{
										//��¼��������
										budGetChange=new HDSZCheckFlow.Entiy.BudgetchangeSheet();
										budGetChange.Iyear=iYear;
										budGetChange.Imonth=iMonth;
										budGetChange.SheetDate=sheetDate;
										budGetChange.DeptCode=deptCode;
										budGetChange.SheetTypeCode =sheetType;
										budGetChange.OutSubject=outSubject;
										budGetChange.InSubject=inSubject;
										budGetChange.Money=(decimal)Math.Round(money,3);
										budGetChange.Create();
										//����Ԥ���
										budGet.BudgetChangeMoney= budGet.BudgetChangeMoney - (decimal)Math.Round(money,3);
										budGet.Update();
										Entiy.Budgetaccount budGetin=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,inSubject);
										if(budGetin==null)
										{
											budGetin=new HDSZCheckFlow.Entiy.Budgetaccount();
										}
										budGetin.BudgetChangeMoney = budGetin.BudgetChangeMoney +  (decimal)Math.Round(money,3);
										budGetin.Save();
									}
									else
									{
										lblMessage=lblMessage + "ת������";
									}
								}
								else
								{
									lblMessage=iMonth + "���Ѿ��������ˣ������ٵ���";
								}
								#endregion 
							}
							else if("1".Equals(sheetType))  // 1= ׷��
							{
								#region 
								Entiy.BudgetchangeSheet budGetChange=HDSZCheckFlow.Entiy.BudgetchangeSheet.FindByYearAndMonth(iYear,iMonth);
								if(budGetChange==null)
								{
									//��¼��������
									budGetChange=new HDSZCheckFlow.Entiy.BudgetchangeSheet();
									budGetChange.Iyear=iYear;
									budGetChange.Imonth=iMonth;
									budGetChange.SheetDate=sheetDate;
									budGetChange.DeptCode=deptCode;
									budGetChange.SheetTypeCode =sheetType;
									budGetChange.OutSubject=outSubject;
									budGetChange.InSubject=inSubject;
									budGetChange.Money=(decimal)Math.Round(money,3);
									budGetChange.Create();
									//����Ԥ���
									Entiy.Budgetaccount budGetin=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,inSubject);
									if(budGetin==null)
									{
										budGetin=new HDSZCheckFlow.Entiy.Budgetaccount();
									}
									budGetin.BudgetAddMoney = budGetin.BudgetAddMoney  +  (decimal)Math.Round(money,3);
									budGetin.Save();
								}
								else
								{
									lblMessage=iMonth + "���Ѿ��������ˣ������ٵ���";
								}
								#endregion 
							}
						}
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="��������excel��ʽ�Ƿ���ȷ";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="û�����ݣ�";
			}
		}


		/// <summary>
		/// С��̶��ʲ�����
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage"></param>
		public static void SmallAssetHelper(DataSet ds,out string lblMessage)
		{
			lblMessage="";
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{		
				using( TransactionScope tran = new TransactionScope())
				{
					try
					{
						for(int i=0;i<ds.Tables[0].Rows.Count ;i++)
						{
							//if(!"".Equals(ds.Tables[0].Rows[i]["���"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["�·�"].ToString()))
							//{

							//�ֶ� �� NO	������	��������	����	���ű���	�������	�������	�������	��������	����	����	�۸�	��ע	��ŵص�	����������	�����˹���
								
							//[ID]
							//,[InvSheetId]
							//,[vbillcode]
							//,[cinventoryid]
							//,[dbizdate]
							//,[noutnum]
							//,[ninnum]
							//,[cwarehouseid]
							//,[cdispatcherid]
							//,[cdptid]
							//,[ccustomerid]
							//,[coperatorid]
							//,[period]
							//,[RetireNum]
							//,[Price]
							//,[CurrTypeCode]
							//,[IsRetire]
							//,[RetireDate]
							//,[ReMark]
							//,[InvManageCode]
							//,[DeptClassCode]
							//,[DeptCode]
							//,[KeeperCode]
							//,[storage]
							//,[iNum]
							//,[invname]
							string InvManageCode = ds.Tables[0].Rows[i]["������"].ToString().Trim();
							string InvCode = ds.Tables[0].Rows[i]["�������"].ToString().Trim();
							string DeptClassCode = ds.Tables[0].Rows[i]["���ű���"].ToString().Trim();
							string DeptCode  =  ds.Tables[0].Rows[i]["�������"].ToString().Trim();
							string invPk = "";
							//��InvPk
							Entiy.Baseinventory Inv = HDSZCheckFlow.Entiy.Baseinventory.FindByCode(InvCode);
							if(Inv != null)
							{
								invPk = Inv.InvPk ; 
							}
							string dbizdate =  ds.Tables[0].Rows[i]["��������"].ToString().Trim();
							string iNum = ds.Tables[0].Rows[i]["����"].ToString().Trim();
							string CurrTypeCode =  ds.Tables[0].Rows[i]["����"].ToString().Trim();
							string Price =  ds.Tables[0].Rows[i]["�۸�"].ToString().Trim();
							string ReMark = ds.Tables[0].Rows[i]["��ע"].ToString().Trim();
							string storage = ds.Tables[0].Rows[i]["��ŵص�"].ToString().Trim();
							string KeeperCode = ds.Tables[0].Rows[i]["�����˹���"].ToString().Trim();

							//Entiy.Budgetaccount budGet=HDSZCheckFlow.Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,subjectCode);
							Entiy.SmallFixedAsset FixedAsset = new HDSZCheckFlow.Entiy.SmallFixedAsset();

							FixedAsset.InvManageCode = InvManageCode ;
							FixedAsset.Cinventoryid = invPk ; 
							FixedAsset.DeptClassCode = DeptClassCode;
							FixedAsset.DeptCode = DeptCode ;
							FixedAsset.Dbizdate = dbizdate ;
							FixedAsset.INum = int.Parse(iNum);
							FixedAsset.CurrTypeCode = CurrTypeCode;
							FixedAsset.Price = Price ;
							FixedAsset.ReMark = ReMark ;
							FixedAsset.Storage = storage ;
							FixedAsset.KeeperCode = KeeperCode ; 


							FixedAsset.Save();




							//int iYear=int.Parse(ds.Tables[0].Rows[i]["���"].ToString().Trim());
							//int iMonth=int.Parse(ds.Tables[0].Rows[i]["�·�"].ToString().Trim());
							//string subjectCode=ds.Tables[0].Rows[i]["��Ŀ���"].ToString().Trim();
							//string deptCode=ds.Tables[0].Rows[i]["���ű��"].ToString().Trim();
							//float PlanMoney=float.Parse(ds.Tables[0].Rows[i]["������"].ToString().Trim());
							//
							//Entiy.Budgetaccount budGet=HDSZCheckFlow.Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,subjectCode);
							//if(budGet==null)
							//{
							//budGet=new HDSZCheckFlow.Entiy.Budgetaccount();
							//}
							//budGet.Iyear=iYear;
							//budGet.Imonth =iMonth;
							//budGet.DeptCode=deptCode;
							//budGet.SubjectCode=subjectCode;
							//budGet.PlanMoney =(decimal)Math.Round(PlanMoney,3);
							//budGet.Save();
							//}
						}
						tran.VoteCommit();
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="��������excel��ʽ�Ƿ���ȷ";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="û�����ݣ�";
			}
		}


		/// <summary>
		/// �����û����ŵõ����ڲ��ŵ�Ԥ�����
		/// </summary>
		/// <param name="UserCode">applyDept</param>
		/// <param name="SheetSubject">��Ŀ����</param>
		public static Entiy.Budgetaccount GetBudgetInfoByUserCode(int iYear,int iMonth,string applyDept,string SheetSubject)
		{
			#region
//			//�� UserCode ������Ԥ�㲿��
//			Entiy.BasePerson basePerson=Entiy.BasePerson.Find(UserCode);
//			if(basePerson!=null)
//			{
//				//��������Ԥ�㲿��
//				Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(basePerson.DeptCode);
//				if(dept!=null)
//				{
//					return Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,dept.BudgetDeptCode,SheetSubject);
//				}
//				else
//				{
//					return null;
//				}
//			}
//			else
//			{
//				return null;
//			}
			#endregion 

			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				return Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,dept.BudgetDeptCode,SheetSubject);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// ������Ԥ��Ϊnullʱ,��ʼ��һ����ֵ
		/// </summary>
		/// <param name="iYear">��</param>
		/// <param name="iMonth">��</param>
		/// <param name="applyDept">���²��ţ���ת��ΪԤ�㲿�ţ�</param>
		/// <param name="SheetSubject">��Ŀ</param>
		public static void  SaveBudgetAccount(int iYear,int iMonth,string applyDept,string SheetSubject,out string lblMessage)
		{
			lblMessage="";
			try
			{
				Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
				if(dept!=null && dept.BudgetDeptCode!=null)
				{
					Entiy.Budgetaccount account = Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,dept.BudgetDeptCode,SheetSubject);
					if(account == null)
					{
						account=new HDSZCheckFlow.Entiy.Budgetaccount();
						account.Iyear= iYear ;
						account.Imonth = iMonth;
						account.SubjectCode= SheetSubject ;
						account.DeptCode = dept.BudgetDeptCode ;
						account.BudgetAddMoney= 0;
						account.BudgetChangeMoney=0;
						account.BudgetMoney= 0 ;
						account.CheckMoney= 0 ;
						account.PlanMoney= 0 ;
						account.RealMoney=0 ;
						account.Save();
					}
				}
				else if(dept.BudgetDeptCode==null)
				{
					lblMessage="δָ������Ԥ�㲿��";

				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("BudgetAccountBLL.SaveBudgetAccount",ex.Message );
			}
			
		}


		/// <summary>
		/// ������Ԥ��Ϊnullʱ,��ʼ��һ����ֵ,����Ԥ���ʱ��
		/// </summary>
		/// <param name="iYear">��</param>
		/// <param name="iMonth">��</param>
		/// <param name="budgetDept">Ԥ�㲿��</param>
		/// <param name="SheetSubject">��Ŀ</param>
		public static void  SaveBudgetAccountBydeptCode(int iYear,int iMonth,string budgetDept,string SheetSubject)
		{
			try
			{
				Entiy.Budgetaccount account = Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,budgetDept,SheetSubject);
				if(account == null)
				{
					account=new HDSZCheckFlow.Entiy.Budgetaccount();
					account.Iyear= iYear ;
					account.Imonth = iMonth;
					account.SubjectCode= SheetSubject ;
					account.DeptCode = budgetDept;
					account.BudgetAddMoney= 0;
					account.BudgetChangeMoney=0;
					account.BudgetMoney= 0 ;
					account.CheckMoney= 0 ;
					account.PlanMoney= 0 ;
					account.RealMoney=0 ;
					account.Save();
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("BudgetAccountBLL.SaveBudgetAccountBydeptCode",ex.Message );
			}
			
		}








		/// <summary>
		/// �����Ŀ�ĵ������
		/// </summary>
		/// <param name="iYear">���</param>
		/// <param name="iMonth">�·�</param>
		/// <param name="deptCode">���²���</param>
		/// <param name="subject">��Ŀ</param>
		/// <returns></returns>
		public static decimal GetSubjectChangeMoney(int iYear,int iMonth,string deptCode,string subject)
		{
			// 1.  �˿�Ŀת��Ľ�� + �˿�Ŀת���Ľ��  
			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(deptCode);
			decimal ChangeMoney=0, InMoney=0,OutMoney=0;
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				
				Entiy.BudgetchangeSheet[] IbudgetchangeSheets=Entiy.BudgetchangeSheet.FindChangeSheetIn(iYear,iMonth,dept.BudgetDeptCode,subject);
				if(IbudgetchangeSheets!=null && IbudgetchangeSheets.Length>0)
				{
					foreach(Entiy.BudgetchangeSheet IBChange in  IbudgetchangeSheets)
					{
						InMoney += IBChange.Money;
					}
				}

				Entiy.BudgetchangeSheet[] ObudgetchangeSheets=Entiy.BudgetchangeSheet.FindChangeSheetOut(iYear,iMonth,dept.BudgetDeptCode,subject);
				if(ObudgetchangeSheets!=null && ObudgetchangeSheets.Length>0)
				{
					foreach(Entiy.BudgetchangeSheet OBChange in  ObudgetchangeSheets)
					{
						InMoney -= OBChange.Money;
					}
				}
				ChangeMoney= InMoney + OutMoney;
				
			}
			return ChangeMoney;

		}

		/// <summary>
		/// �����Ŀ�ĵ������
		/// </summary>
		/// <param name="iYear">���</param>
		/// <param name="iMonth">�·�</param>
		/// <param name="deptCode">Ԥ�㲿��</param>
		/// <param name="subject">��Ŀ</param>
		/// <returns></returns>
		public static decimal GetAccountChangeMoney(int iYear,int iMonth,string deptCode,string subject)
		{
			// 1.  �˿�Ŀת��Ľ�� + �˿�Ŀת���Ľ��  
			decimal ChangeMoney=0, InMoney=0,OutMoney=0;

				
			Entiy.BudgetchangeSheet[] IbudgetchangeSheets=Entiy.BudgetchangeSheet.FindChangeSheetIn(iYear,iMonth,deptCode,subject);
			if(IbudgetchangeSheets!=null && IbudgetchangeSheets.Length>0)
			{
				foreach(Entiy.BudgetchangeSheet IBChange in  IbudgetchangeSheets)
				{
					InMoney += IBChange.Money;
				}
			}

			Entiy.BudgetchangeSheet[] ObudgetchangeSheets=Entiy.BudgetchangeSheet.FindChangeSheetOut(iYear,iMonth,deptCode,subject);
			if(ObudgetchangeSheets!=null && ObudgetchangeSheets.Length>0)
			{
				foreach(Entiy.BudgetchangeSheet OBChange in  ObudgetchangeSheets)
				{
					InMoney -= OBChange.Money;
				}
			}
			ChangeMoney= InMoney + OutMoney;
				
			
			return ChangeMoney;

		}

		/// <summary>
		/// ��Ŀ�ļ��ȵ������
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="deptcode"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static decimal GetAccountQuarterChange(int iYear,int iMonth,string deptcode,string subject)
		{
			// 1.  �˿�Ŀת��Ľ�� + �˿�Ŀת���Ľ��  
			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(deptcode);
			decimal ChangeMoney = 0 ;  
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				//1.�жϵ�ǰ�·����ڼ���
				int quarter=0;
				if (iMonth <=3 && iMonth >=1)
				{
					quarter = 1 ;
				}
				if (iMonth <=6 && iMonth >3)
				{
					quarter = 2 ;
				}
				if (iMonth <=9 && iMonth >6)
				{
					quarter = 3 ;
				}
				if (iMonth <=12 && iMonth >9)
				{
					quarter = 4 ;
				}
				ChangeMoney = DataAccess.Budget.budgetAccountDAL.getQuarterBudgetChange(iYear,quarter,dept.BudgetDeptCode ,subject);			
				
			}
			return ChangeMoney;

		}

		/// <summary>
		/// ��Ŀ�ļ��ȵ������2
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="deptcode"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static decimal GetAccountQuarterChangeForBudDept(int iYear,int iMonth,string deptcode,string subject)
		{
			// 1.  �˿�Ŀת��Ľ�� + �˿�Ŀת���Ľ��  
			//Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(deptcode);
			decimal ChangeMoney = 0 ;  
			
				//1.�жϵ�ǰ�·����ڼ���
				int quarter=0;
				if (iMonth <=3 && iMonth >=1)
				{
					quarter = 1 ;
				}
				if (iMonth <=6 && iMonth >3)
				{
					quarter = 2 ;
				}
				if (iMonth <=9 && iMonth >6)
				{
					quarter = 3 ;
				}
				if (iMonth <=12 && iMonth >9)
				{
					quarter = 4 ;
				}
				ChangeMoney = DataAccess.Budget.budgetAccountDAL.getQuarterBudgetChange(iYear,quarter,deptcode ,subject);			
				
			
			return ChangeMoney;

		}


		/// <summary>
		/// ����Ԥ���,��������ֶ�.(�������Ա�鿴 , �����������ж�)
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		public static void UpdateAccountChange(int iYear,int iMonth)
		{
			// ���в��� ,���п�Ŀ, �������
			Entiy.Budgetaccount []Accounts=Entiy.Budgetaccount.FindAccountByYearAndMonth(iYear,iMonth);
			if(Accounts!=null && Accounts.Length>0)
			{
				foreach(Entiy.Budgetaccount Account in Accounts)
				{
					decimal changeMoney = GetAccountChangeMoney(Account.Iyear,Account.Imonth,Account.DeptCode,Account.SubjectCode);
					Account.BudgetChangeMoney= changeMoney ;
					Account.Update();
				}
			}
		}

		public static int budgetStandard(DateTime dt)
		{
			#region
			//��֧�жϱ�׼�� Ԥ��/����
//			Entiy.BaseCommonCode commonCode = Entiy.BaseCommonCode.FindByCodeType("BudgetStandard");
//			if(commonCode!=null)
//			{
//				if(commonCode.Code == "tuisuan" )
//				{
//					return 2 ;  // ����
//				}
//				else if(commonCode.Code == "yusuan" )
//				{
//					return 1 ;  // Ԥ��
//				}
//				else
//				{
//					return 3 ;  //����
//				}
//			}
//			else
//			{
//				return 3 ;      //something wrong 
//			}

//			DateTime dt = System.DateTime.Today;   // �жϱ�׼Ϊϵͳʱ��
			#endregion 

			//Entiy.BaseBudgetStandard budgetStandard = Entiy.BaseBudgetStandard.FindByDateTime(dt.ToString("yyyyMMdd"));
			Entiy.BaseBudgetStandard budgetStandard = Entiy.BaseBudgetStandard.FindByDateTime(dt);

			if(budgetStandard!=null)
			{
				if(budgetStandard.BudgetStandard  == "tuisuan" )
				{
					return 2 ;  // ����
				}
				else if(budgetStandard.BudgetStandard == "yusuan" )
				{
					return 1 ;  // Ԥ��
				}
				else
				{
					return 3 ;  //����
				}
			}
			else
			{
				return 3 ;      //something wrong 
			}
		}

		/// <summary>
		/// ��ȡ���ſ�Ŀ����Ԥ����Ϣ
		/// </summary>
		/// <param name="year">��</param>
		/// <param name="month">��</param>
		/// <param name="dept">����</param>
		/// <param name="subjectCode">��Ŀ</param>
		/// <returns></returns>
		public static DataSet getQuarterBudgetInfo(int year, int month ,string dept,string subjectCode)
		{
			//1.�жϵ�ǰ�·����ڼ���
			int quarter=0;
			if (month <=3 && month >=1)
			{
				quarter = 1 ;
			}
			if (month <=6 && month >3)
			{
				quarter = 2 ;
			}
			if (month <=9 && month >6)
			{
				quarter = 3 ;
			}
			if (month <=12 && month >9)
			{
				quarter = 4 ;
			}
			return DataAccess.Budget.budgetAccountDAL.getQuarterBudgetInfo(year,quarter,dept,subjectCode);
		}


		/// <summary>
		/// ��ȡ�̶��ʲ�һ����Ŀ�µ�Ԥ����Ϣ������Ŀ��Ԥ����Ϣ��
		/// </summary>
		/// <param name="iYear">��</param>
		/// <param name="BudgetDeptCode">Ԥ�㲿��</param>
		/// <param name="itemName">��Ŀ����</param>
		/// <returns></returns>
		public static DataSet getAssetBudgetInfo(int iYear , string BudgetDeptCode ,string itemName)
		{
			return DataAccess.Budget.budgetAccountDAL.getAssetBudgetInfo(iYear,BudgetDeptCode,itemName);
		}

		/// <summary>
		/// ��ѯδ�ύ����Ԥ����Ϣ
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		/// <returns></returns>
		public static DataSet getLeftMoneyForUnSubmitApply(int applySheetHeadPk)
		{
			return  DataAccess.Budget.budgetAccountDAL.getLeftMoneyForUnSubmitApply(applySheetHeadPk);


		}

		/// <summary>
		/// ���� ʵ�ﹺ���ͱ����� ���� �۸���Ϣ��p_ApplyForPurchasePriceNull
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static DataSet IsNullApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			//ֻ��ʵ�ﹺ���ͱ��������ͲŽ���

			try
			{
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find (applySheetHeadPk) ;


				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   

				//���������ApplySheetBody_Purchase
				if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
				{
					//ִ�и��´洢���� ,���±���۸�

					return DataAccess.Budget.budgetAccountDAL.IsNullApplyPriceFromApplyHeadPk(applySheetHeadPk);


				}
				else
				{
					return null;
				}

			}
			catch(Exception Ex)
			{
				throw Ex;//���ִ����׻���һ�㣬��ֹ��һ���ύ
				
			}
		}


		/// <summary>
		/// ���� ʵ�ﹺ���ͱ����� ���� �۸���Ϣ��p_Apply_AutoUpdatePrice
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static void UpdateApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			//ֻ��ʵ�ﹺ���ͱ��������ͲŽ���

			try
			{
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find (applySheetHeadPk) ;


				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   

					//���������ApplySheetBody_Purchase
				if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
				{
					//ִ�и��´洢���� ,���±���۸�

					DataAccess.Budget.budgetAccountDAL.UpdateApplyPriceFromApplyHeadPk(applySheetHeadPk);


				}

			}
			catch(Exception Ex)
			{
				throw Ex;//���ִ����׻���һ�㣬��ֹ��һ���ύ
			}
		}

	}
}
