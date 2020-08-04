using System;
using System.Data;
using System.Text;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplySheetHeadBLL ��ժҪ˵����
	/// </summary>
	public class ApplySheetHeadBLL
	{
		public ApplySheetHeadBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="deptClassCode"></param>
		/// <returns></returns>
		public static DataTable  GetApplyType(string deptClassCode)
		{

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyType(deptClassCode);
		}
		/// <summary>
		/// ������Ӫ����������
		/// </summary>
		/// <param name="deptClassCode"></param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeButAsset(string deptClassCode)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeButAsset(deptClassCode);
		}
		/// <summary>
		/// ֻ����Ӫ������
		/// </summary>
		/// <param name="deptClassCode"></param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeOfAsset(string deptClassCode)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeOfAsset(deptClassCode);

		}
		public static DataTable  GetApplyTypeCom(string deptClassCode)
		{

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeCom(deptClassCode);
		}
		public static DataTable  GetApplyTypeNon(string deptClassCode)
		{
			//��ͨ�������
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeNon (deptClassCode);
		}
		public static DataTable  GetApplyTypeForEvection(string deptClassCode)
		{
			//������ƿ�Ŀ ��ֻȡ�������

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeEvection(deptClassCode);
		}
		public static DataTable  GetApplyTypeForBanquet(string deptClassCode)
		{
			//������ƿ�Ŀ ��ֻȡ�������

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeBanquet (deptClassCode);
		}

		public static DataTable  GetApplyTypeByCode(string deptClassCode,string typeClass )
		{
			// ���ݲ��ź����� ��ѯ������Ŀ
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeByCode( deptClassCode,typeClass);

		}

		/// <summary>
		/// ȡ�����ˮ��
		/// </summary>
		/// <param name="perfix">ǰ׺ad200805</param>
		/// <returns></returns>
		public static string  GetMaxSheetNo(string perfix)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetMaxSheetNo(perfix);
		}

		/// <summary>
		/// ȡ��󶨵���ˮ��
		/// </summary>
		/// <returns></returns>
		public static string GetMaxOrderNo(string perfix)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetMaxOrderNo(perfix);
		}
		/// <summary>
		/// ��ȡ���ݵ�״̬
		/// </summary>
		/// <returns>1.������Ԥ����/��/����</returns>
		public static int SetButtonEnable(int ApplyHeadKey,out int Bohui)
		{
			// 1 �����������ã� < 3000 
			// 2 Ԥ���ڿ���
			// 3 Ԥ�������
			// 4 ���� and Ԥ���� ����
			// 5 ���� and Ԥ���� ����
			// 6 ��������ȫ������
			// 7 û�б��壬������
			// 8 ���ִ���
			// 9 ����״̬����
			Bohui=0;
			try
			{
				
				int tempEnable=0;
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(applySheet!=null)
				{
					if(applySheet.ApplyProcessCode!=null)
					{
						Entiy.ApplyProcessType applyProcess=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode); //�鿴���뵥����
						#region 
						if(applyProcess!=null)
						{
							if((applyProcess.IsSubmit == 1 && applyProcess.IsCheck==0  ) || applyProcess.IsDisallow == 1)  //�½���δ�������� or ����
							{
								Bohui=1;
							}
							if(applyProcess.IsSubmit == 0 && applyProcess.IsSubmitAgain==1 && applySheet.IsKeeping != 1)
							{
								Bohui=2;                          //������
							}
							if(applyProcess.IsSubmit==0)
							{
								decimal ThisMoney=0;  //�����������

								#region  ����
//								Entiy.ApplyType applyType = Entiy.ApplyType.Find(applySheet.ApplyTypeCode);
//								if(applyType == null)
//								{
//									return 8;
//								}
//								
//								if("ApplySheetBody_Purchase".Equals(applyType.ApplySheetBodyTableName))
//								{		
//									Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(ApplyHeadKey);
//									if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
//									{
//										
//										foreach(Entiy.ApplySheetBodyPurchase applySheetBody  in applySheetBodys)
//										{
//											ThisMoney += applySheetBody.Money;
//										}
//										string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // ���������������
//										if(!"".Equals(PressMoney))
//										{
//											if(ThisMoney <= decimal.Parse(PressMoney))
//											{
//												tempEnable=1;     //������������
//											}
//										}
//									}
//									else
//									{
//										return 7;
//									}	
//								}
//
//
//								//--------------------������---------------------//
//								if("ApplySheetBody_Pay".Equals(applyType.ApplySheetBodyTableName))
//								{		
//									Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
//									if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
//									{
//										foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
//										{
//											ThisMoney += applySheetBody.Money;
//										}
//										string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // ���������������
//										if(!"".Equals(PressMoney))
//										{
//											if(ThisMoney <= decimal.Parse(PressMoney))
//											{
//												tempEnable=1;     //������������
//											}
//										}
//									}
//									else
//									{
//										return 7;
//									}	
//								}
//								
//								//--------------------������ End---------------------//
								#endregion  

								ThisMoney = GetCheckMoneyByHeadPK(ApplyHeadKey);   //���ŵ��ݵ�������
								if(ThisMoney > 0)
								{
									string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // ���������������
									if(!"".Equals(PressMoney))
									{
										if(ThisMoney <= decimal.Parse(PressMoney))
										{
											tempEnable=1;     //������������
										}
									}
									// �Ѿ������Ľ�� ,�꣬�£����ţ� ��Ŀ
									Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applySheet.ApplyDeptCode);
									Entiy.ApplySheetHeadBudget applySheetHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHeadKey);

									if(dept!=null && applySheetHeadBudget!=null)
									{
										//Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month,dept.BudgetDeptCode,applySheet.SheetSubject);
										Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month,dept.BudgetDeptCode,applySheetHeadBudget.SheetSubject);
								
										#region 
										if(budGet!=null)
										{
											//ThisMoney += budGet.CheckMoney;																		//�Ѿ������Ľ��

											//decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month ,applySheet.ApplyDeptCode,applySheetHeadBudget.SheetSubject);
											
											//���ȵ������
											decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month ,applySheet.ApplyDeptCode,applySheetHeadBudget.SheetSubject);

											//���ó�֧�жϱ�׼��Ԥ���������
											DateTime dt = DateTime.Today; 
											int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(dt);
											decimal TotalMoney = 0 ; 
											
											DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applySheet.ApplyDate.Year ,applySheet.ApplyDate.Month ,dept.BudgetDeptCode,applySheetHeadBudget.SheetSubject );
											
											ThisMoney += decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());
											
											ThisMoney += decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());
											if (budgetStandard == 1 )  //Ԥ��
											{
												//�ܽ��Ϊ���Ⱥϼ�Ԥ����
												TotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + ChangeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()) ;          //�ܽ��
											}
											else if(budgetStandard == 2 ) // ����
											{
												//�ܽ��Ϊ���Ⱥϼ�������
												TotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["planmoney"].ToString())  + ChangeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()) ;          //�ܽ��
											}

											if(ThisMoney > TotalMoney)
											{
												if(tempEnable==1)
												{
													
													if(applySheet.IsOverBudget == 1 )  //���ƴ˵��Ƿ���Խ���Ԥ��������
													{
														return 5;//Ԥ���⣬ ��������
													}
													else
													{
														return 8;
													}
												}
												else
												{
													// 2008-09-27 ��� ,���ƴ˵��Ƿ���Խ���Ԥ��������
													if(applySheet.IsOverBudget == 1 )
													{
														return 3;//Ԥ�������
													}
													else
													{
														return 8; //Ԥ�����ⶼ������
													}
												}
											}
											else
											{
												if(applySheet.IsOverBudget == 1 )  //���ƴ˵��Ƿ���Խ���Ԥ��������
												{
													return 5;//Ԥ���⣬ ��������
												}

												else if(tempEnable==1)
												{
													//Ԥ���ڣ� ��������
													return 4;
												}
												else
												{
													//Ԥ���ڿ���
													return 2;
												}
											}
										}
										else
										{
											//û��Ԥ��
											if(tempEnable==1)     //������������
											{
												return 5;
											}
											else
											{
												return 3;
											}
										}
										#endregion 
									}
									else
									{
										return 8;
									}
								}
								else
								{
									return 7;//û�б���(������Ϊ 0 )
								}
							}
							else  //������
							{
								return 6;
							}
						}
						else
						{
							return 8;
						}
						#endregion 
					}
					else
					{
						return 8;
					}
				}
				else
				{
					return 8;
				}
			}
			catch(Exception ex)
			{
			//	Response.Write("ϵͳ�����п��ܻ�����Ϣ���ò�����������ϵ����Ա");
				
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
				return 8;
			}
		}




		





		/// <summary>
		/// �鿴ĳ�����ݵ��ܽ��,�ӱ���ʱ,��Ҫ��չ�˷���...
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static decimal GetCheckMoneyByHeadPK(int ApplyHeadKey )
		{
			try
			{
				decimal ThisMoney=0;  //���ŵ��ݵ��������
				// 1. ���жϱ�ʹ�������ű��� 
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(applyHead == null)
				{
					return ThisMoney;
				}
				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   
				if(applyTypes !=null )
				{
					//���������ApplySheetBody_Purchase
					if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
						{
							foreach(Entiy.ApplySheetBodyPurchase applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money;
							}
						}
					}
					//��������� ApplySheetBody_Pay
					else if("ApplySheetBody_Pay".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
						{
							foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
							{
								//ThisMoney += applySheetBody.Money;
								ThisMoney += applySheetBody.OriginalcurrPrice * applySheetBody.ExchangeRate ;

							}
						}
					}
					//��������� ApplySheetBody_EvectionCharge
					else if("ApplySheetBody_EvectionCharge".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyEvectionCharge[] applySheetBodys=Entiy.ApplySheetBodyEvectionCharge.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
						{
							foreach(Entiy.ApplySheetBodyEvectionCharge applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money * applySheetBody.ExchangeRate ;
							}
						}
					}
					//���뵥���� ApplySheetBody_Banquet
					else if("ApplySheetBody_Banquet".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
						{
							foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money;
							}
						}					
					}
					//��Ӫ���� ApplySheetBody_Banquet
					else if("Asset_ApplySheet_Body".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.AssetApplySheetBody [] applySheetBodys=Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //�б���
						{
							foreach(Entiy.AssetApplySheetBody applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.RmbMoney ;
							}
						}
					}
				}
				return ThisMoney;
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.GetCheckMoneyByHeadPK",ex.Message );
				return 0;			
			}
		}

		/// <summary>
		/// ��ѯ�����ҵ�����
		/// </summary>
		/// <param name="myCode">����</param>
		/// <returns></returns>
		public static DataSet GetMyAuditing(string myCode,string filter)
		{
			try
			{
				DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetMyAuditing(myCode,filter);
				if(ds!=null && ds.Tables.Count>0)
				{
					ds.Tables[0].Columns.Add("DisplaysPerson");
					for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
					{
						if(!myCode.Equals(ds.Tables[0].Rows[i]["PersonCode"].ToString()))
						{
							ds.Tables[0].Rows[i]["DisplaysPerson"]=ds.Tables[0].Rows[i]["PersonCode"].ToString();
							ds.Tables[0].Rows[i]["PersonCode"]=String.Empty;
						}
						else
						{
							ds.Tables[0].Rows[i]["UserName"]=String.Empty;
						}
					}
				}
				return ds;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.GetMyAuditing",ex.Message );
				return null;
			}
		}


		public static DataSet GetAuditingByType(string sqlWhere)
		{

			//��װ��ѯ����
			#region  
//			StringBuilder filter=new StringBuilder() ;
//		
//			if(!"".Equals(sqlWhere))
//			{
//				filter.Append(" where  ");
//				filter.Append(sqlWhere);	
//			}
//			 
//			string sqlWhere2="";
//
//			if("1".Equals(applyType))
//			{
//				sqlWhere2 = " where ApplyProcessType.IsFinishInCompany=1";
//			}
//			else if("2".Equals(applyType))
//			{
//				sqlWhere2 = " where ApplyProcessType.IsCheck=1 and ApplyProcessType.IsFinishInCompany=0";
//			}
//			else if("3".Equals(applyType))
//			{
//				sqlWhere2 = " where ApplyProcessType.IsDisallow=1 ";
//			}
//
//			if(!"".Equals(sqlWhere2))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//					filter.Append(sqlWhere2);
//				}
//				else
//				{
//					filter.Append( " where ");
//					filter.Append(sqlWhere2);
//				}
//			}
//			sqlWhere=filter.ToString();
			#endregion 
			StringBuilder filter=new StringBuilder();

			filter.Append ("  WHERE ApplyProcessType.IsSubmit = 1 ");
			
			if(!"".Equals(sqlWhere))
			{
				filter.Append(" and " + sqlWhere);
			}

			return DataAccess.ApplySheet.ApplyAuditingDAL.GetAuditingByType(filter.ToString());
		}


		/// <summary>
		/// ���õ����Ƿ���Խ���Ԥ��������
		/// </summary>
		/// <param name="applyHeadPk">���ݱ�ͷId </param>
		/// <param name="key">�Ƿ�Ԥ�����ʾ</param>
		/// <param name="overMoney">Ԥ������</param>
		public static  void  SetIsOverBudget(int applyHeadPk,int key,decimal overMoney)//111111111111111111111
		{
			try
			{
				//��������Ѿ���Ԥ����״̬ �����ز����κζ���
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
				if(applyHead != null)
				{
					if(applyHead.IsOverBudget == 1 )
					{
						return ; 
					}
				}
				//�����Ԥ������õĽ��
				Entiy.ApplySheetHeadBudget applyHeadBudget =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);


				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );


				//����Ԥ�������
				DataAccess.ApplySheet.ApplySheetHeadDAL.SetIsOverBudget(applyHeadPk,key,decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()),overMoney);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.SetIsOverBudget" , ex.Message );
			}


		}


		/// <summary>
		/// ȡ��Ԥ����
		/// </summary>
		/// <param name="applyHeadPk">���ݱ�ͷId </param>
		public static  void  CancelSetIsOverBudget(int applyHeadPk,int key)
		{
			try
			{
				//��������Ѿ���Ԥ����״̬ �����ز����κζ���
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
				if(applyHead != null)
				{
					if(applyHead.IsOverBudget != 1 )
					{
						return ; 
					}
				}
				//����ȡ��Ԥ����Ľ��
				Entiy.ApplySheetHeadBudget applyHeadBudget =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);


				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );


				//����Ԥ�������
				DataAccess.ApplySheet.ApplySheetHeadDAL.CanclSetIsOverBudget(applyHeadPk,0,decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()));
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.SetIsOverBudget" , ex.Message );
			}


		}











	}
}
