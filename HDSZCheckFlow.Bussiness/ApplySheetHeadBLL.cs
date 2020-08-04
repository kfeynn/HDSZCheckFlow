using System;
using System.Data;
using System.Text;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplySheetHeadBLL 的摘要说明。
	/// </summary>
	public class ApplySheetHeadBLL
	{
		public ApplySheetHeadBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 所有类型
		/// </summary>
		/// <param name="deptClassCode"></param>
		/// <returns></returns>
		public static DataTable  GetApplyType(string deptClassCode)
		{

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyType(deptClassCode);
		}
		/// <summary>
		/// 除了新营的所有类型
		/// </summary>
		/// <param name="deptClassCode"></param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeButAsset(string deptClassCode)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeButAsset(deptClassCode);
		}
		/// <summary>
		/// 只有新营的类型
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
			//普通购买类别
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeNon (deptClassCode);
		}
		public static DataTable  GetApplyTypeForEvection(string deptClassCode)
		{
			//出差控制科目 ，只取出差类别

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeEvection(deptClassCode);
		}
		public static DataTable  GetApplyTypeForBanquet(string deptClassCode)
		{
			//出差控制科目 ，只取出差类别

			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeBanquet (deptClassCode);
		}

		public static DataTable  GetApplyTypeByCode(string deptClassCode,string typeClass )
		{
			// 根据部门和类型 查询可用项目
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetApplyTypeByCode( deptClassCode,typeClass);

		}

		/// <summary>
		/// 取最大流水号
		/// </summary>
		/// <param name="perfix">前缀ad200805</param>
		/// <returns></returns>
		public static string  GetMaxSheetNo(string perfix)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetMaxSheetNo(perfix);
		}

		/// <summary>
		/// 取最大定单流水号
		/// </summary>
		/// <returns></returns>
		public static string GetMaxOrderNo(string perfix)
		{
			return DataAccess.ApplySheet.ApplySheetHeadDAL.GetMaxOrderNo(perfix);
		}
		/// <summary>
		/// 获取单据的状态
		/// </summary>
		/// <returns>1.可用于预算内/外/紧急</returns>
		public static int SetButtonEnable(int ApplyHeadKey,out int Bohui)
		{
			// 1 紧急审批可用， < 3000 
			// 2 预算内可用
			// 3 预算外可用
			// 4 紧急 and 预算内 可用
			// 5 紧急 and 预算外 可用
			// 6 已所定，全不可用
			// 7 没有表体，不可用
			// 8 出现错误
			// 9 驳回状态可用
			Bohui=0;
			try
			{
				
				int tempEnable=0;
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(applySheet!=null)
				{
					if(applySheet.ApplyProcessCode!=null)
					{
						Entiy.ApplyProcessType applyProcess=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode); //查看申请单进程
						#region 
						if(applyProcess!=null)
						{
							if((applyProcess.IsSubmit == 1 && applyProcess.IsCheck==0  ) || applyProcess.IsDisallow == 1)  //新建还未有人审批 or 驳回
							{
								Bohui=1;
							}
							if(applyProcess.IsSubmit == 0 && applyProcess.IsSubmitAgain==1 && applySheet.IsKeeping != 1)
							{
								Bohui=2;                          //封存可用
							}
							if(applyProcess.IsSubmit==0)
							{
								decimal ThisMoney=0;  //本次审批金额

								#region  作废
//								Entiy.ApplyType applyType = Entiy.ApplyType.Find(applySheet.ApplyTypeCode);
//								if(applyType == null)
//								{
//									return 8;
//								}
//								
//								if("ApplySheetBody_Purchase".Equals(applyType.ApplySheetBodyTableName))
//								{		
//									Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(ApplyHeadKey);
//									if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
//									{
//										
//										foreach(Entiy.ApplySheetBodyPurchase applySheetBody  in applySheetBodys)
//										{
//											ThisMoney += applySheetBody.Money;
//										}
//										string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // 紧急审批金额上限
//										if(!"".Equals(PressMoney))
//										{
//											if(ThisMoney <= decimal.Parse(PressMoney))
//											{
//												tempEnable=1;     //紧急审批可用
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
//								//--------------------报销类---------------------//
//								if("ApplySheetBody_Pay".Equals(applyType.ApplySheetBodyTableName))
//								{		
//									Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
//									if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
//									{
//										foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
//										{
//											ThisMoney += applySheetBody.Money;
//										}
//										string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // 紧急审批金额上限
//										if(!"".Equals(PressMoney))
//										{
//											if(ThisMoney <= decimal.Parse(PressMoney))
//											{
//												tempEnable=1;     //紧急审批可用
//											}
//										}
//									}
//									else
//									{
//										return 7;
//									}	
//								}
//								
//								//--------------------报销类 End---------------------//
								#endregion  

								ThisMoney = GetCheckMoneyByHeadPK(ApplyHeadKey);   //此张单据的申请金额
								if(ThisMoney > 0)
								{
									string PressMoney=System.Configuration.ConfigurationSettings.AppSettings["PressMaxMoney"];   // 紧急审批金额上限
									if(!"".Equals(PressMoney))
									{
										if(ThisMoney <= decimal.Parse(PressMoney))
										{
											tempEnable=1;     //紧急审批可用
										}
									}
									// 已经审批的金额 ,年，月，部门， 科目
									Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applySheet.ApplyDeptCode);
									Entiy.ApplySheetHeadBudget applySheetHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHeadKey);

									if(dept!=null && applySheetHeadBudget!=null)
									{
										//Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month,dept.BudgetDeptCode,applySheet.SheetSubject);
										Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month,dept.BudgetDeptCode,applySheetHeadBudget.SheetSubject);
								
										#region 
										if(budGet!=null)
										{
											//ThisMoney += budGet.CheckMoney;																		//已经审批的金额

											//decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month ,applySheet.ApplyDeptCode,applySheetHeadBudget.SheetSubject);
											
											//季度调整金额
											decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(applySheet.ApplyDate.Year,applySheet.ApplyDate.Month ,applySheet.ApplyDeptCode,applySheetHeadBudget.SheetSubject);

											//费用超支判断标准，预算或者推算
											DateTime dt = DateTime.Today; 
											int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(dt);
											decimal TotalMoney = 0 ; 
											
											DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applySheet.ApplyDate.Year ,applySheet.ApplyDate.Month ,dept.BudgetDeptCode,applySheetHeadBudget.SheetSubject );
											
											ThisMoney += decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());
											
											ThisMoney += decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());
											if (budgetStandard == 1 )  //预算
											{
												//总金额为季度合计预算金额
												TotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + ChangeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()) ;          //总金额
											}
											else if(budgetStandard == 2 ) // 推算
											{
												//总金额为季度合计推算金额
												TotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["planmoney"].ToString())  + ChangeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()) ;          //总金额
											}

											if(ThisMoney > TotalMoney)
											{
												if(tempEnable==1)
												{
													
													if(applySheet.IsOverBudget == 1 )  //控制此单是否可以进行预算外审批
													{
														return 5;//预算外， 紧急可用
													}
													else
													{
														return 8;
													}
												}
												else
												{
													// 2008-09-27 添加 ,控制此单是否可以进行预算外审批
													if(applySheet.IsOverBudget == 1 )
													{
														return 3;//预算外可用
													}
													else
													{
														return 8; //预算内外都不可用
													}
												}
											}
											else
											{
												if(applySheet.IsOverBudget == 1 )  //控制此单是否可以进行预算外审批
												{
													return 5;//预算外， 紧急可用
												}

												else if(tempEnable==1)
												{
													//预算内， 紧急可用
													return 4;
												}
												else
												{
													//预算内可用
													return 2;
												}
											}
										}
										else
										{
											//没有预算
											if(tempEnable==1)     //紧急审批可用
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
									return 7;//没有表体(申请金额为 0 )
								}
							}
							else  //已所定
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
			//	Response.Write("系统错误！有可能基础信息配置不完整，请联系管理员");
				
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
				return 8;
			}
		}




		





		/// <summary>
		/// 查看某个单据的总金额,加表体时,需要扩展此方法...
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static decimal GetCheckMoneyByHeadPK(int ApplyHeadKey )
		{
			try
			{
				decimal ThisMoney=0;  //本张单据的审批金额
				// 1. 先判断表单使用了哪张表体 
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(applyHead == null)
				{
					return ThisMoney;
				}
				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   
				if(applyTypes !=null )
				{
					//购买类表体ApplySheetBody_Purchase
					if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
						{
							foreach(Entiy.ApplySheetBodyPurchase applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money;
							}
						}
					}
					//报销类标体 ApplySheetBody_Pay
					else if("ApplySheetBody_Pay".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
						{
							foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
							{
								//ThisMoney += applySheetBody.Money;
								ThisMoney += applySheetBody.OriginalcurrPrice * applySheetBody.ExchangeRate ;

							}
						}
					}
					//报销类标体 ApplySheetBody_EvectionCharge
					else if("ApplySheetBody_EvectionCharge".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyEvectionCharge[] applySheetBodys=Entiy.ApplySheetBodyEvectionCharge.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
						{
							foreach(Entiy.ApplySheetBodyEvectionCharge applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money * applySheetBody.ExchangeRate ;
							}
						}
					}
					//宴请单表体 ApplySheetBody_Banquet
					else if("ApplySheetBody_Banquet".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.ApplySheetBodyPay[] applySheetBodys=Entiy.ApplySheetBodyPay.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
						{
							foreach(Entiy.ApplySheetBodyPay applySheetBody  in applySheetBodys)
							{
								ThisMoney += applySheetBody.Money;
							}
						}					
					}
					//新营表体 ApplySheetBody_Banquet
					else if("Asset_ApplySheet_Body".Equals(applyTypes.ApplySheetBodyTableName))
					{		
						applyHead  = null;
						applyTypes = null;

						Entiy.AssetApplySheetBody [] applySheetBodys=Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);
						if(applySheetBodys!=null && applySheetBodys.Length>0)                 //有表体
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
		/// 查询属于我的审批
		/// </summary>
		/// <param name="myCode">工号</param>
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

			//组装查询条件
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
		/// 设置单据是否可以进行预算外审批
		/// </summary>
		/// <param name="applyHeadPk">单据表头Id </param>
		/// <param name="key">是否预算外标示</param>
		/// <param name="overMoney">预算外金额</param>
		public static  void  SetIsOverBudget(int applyHeadPk,int key,decimal overMoney)//111111111111111111111
		{
			try
			{
				//如果单据已经是预算外状态 ，返回不做任何动作
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
				if(applyHead != null)
				{
					if(applyHead.IsOverBudget == 1 )
					{
						return ; 
					}
				}
				//计算出预算外可用的金额
				Entiy.ApplySheetHeadBudget applyHeadBudget =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);


				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );


				//设置预算外可用
				DataAccess.ApplySheet.ApplySheetHeadDAL.SetIsOverBudget(applyHeadPk,key,decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()),overMoney);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.SetIsOverBudget" , ex.Message );
			}


		}


		/// <summary>
		/// 取消预算外
		/// </summary>
		/// <param name="applyHeadPk">单据表头Id </param>
		public static  void  CancelSetIsOverBudget(int applyHeadPk,int key)
		{
			try
			{
				//如果单据已经是预算外状态 ，返回不做任何动作
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
				if(applyHead != null)
				{
					if(applyHead.IsOverBudget != 1 )
					{
						return ; 
					}
				}
				//计算取回预算外的金额
				Entiy.ApplySheetHeadBudget applyHeadBudget =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);


				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );


				//设置预算外可用
				DataAccess.ApplySheet.ApplySheetHeadDAL.CanclSetIsOverBudget(applyHeadPk,0,decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()));
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.SetIsOverBudget" , ex.Message );
			}


		}











	}
}
