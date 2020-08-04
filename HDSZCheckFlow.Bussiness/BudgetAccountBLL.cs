using System;
using System.Data;
using Castle.ActiveRecord; 

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// BudgetAccountBLL 的摘要说明。
	/// </summary>
	public class BudgetAccountBLL
	{
		public BudgetAccountBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 预算导入
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">返回提示信息</param>
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
							if(!"".Equals(ds.Tables[0].Rows[i]["年份"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["月份"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["年份"].ToString().Trim());
								int iMonth=int.Parse(ds.Tables[0].Rows[i]["月份"].ToString().Trim());
								string subjectCode=ds.Tables[0].Rows[i]["科目编号"].ToString().Trim();
								string deptCode=ds.Tables[0].Rows[i]["部门编号"].ToString().Trim();
								float budgetMoney=float.Parse(ds.Tables[0].Rows[i]["预算金额"].ToString().Trim());

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
						lblMessage="出错，请检查excel格式是否正确";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="没有数据！";
			}
		}


		/// <summary>
		/// 新营预算导入
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">返回提示信息</param>
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
							if(!"".Equals(ds.Tables[0].Rows[i]["年份"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["部门编号"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["年份"].ToString().Trim());
								string deptCode= ds.Tables[0].Rows[i]["部门编号"].ToString().Trim();
								string ItemName=ds.Tables[0].Rows[i]["项目"].ToString().Trim();
								string subjectName=ds.Tables[0].Rows[i]["具体内容"].ToString().Trim();
								string Num=ds.Tables[0].Rows[i]["数量"].ToString().Trim();
								string Price=ds.Tables[0].Rows[i]["单价"].ToString().Trim();
								string RmbMoeny=ds.Tables[0].Rows[i]["金额"].ToString().Trim();
								string decisionDept=ds.Tables[0].Rows[i]["合议部门编号"].ToString().Trim();

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
						lblMessage="出错，请检查excel格式是否正确";
						Common.Log.Logger.Log("Bussiness.AssetBudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="没有数据！";
			}
		}
		/// <summary>
		/// 推算导入
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
							if(!"".Equals(ds.Tables[0].Rows[i]["年份"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["月份"].ToString()))
							{
								int iYear=int.Parse(ds.Tables[0].Rows[i]["年份"].ToString().Trim());
								int iMonth=int.Parse(ds.Tables[0].Rows[i]["月份"].ToString().Trim());
								string subjectCode=ds.Tables[0].Rows[i]["科目编号"].ToString().Trim();
								string deptCode=ds.Tables[0].Rows[i]["部门编号"].ToString().Trim();
								float PlanMoney=float.Parse(ds.Tables[0].Rows[i]["推算金额"].ToString().Trim());

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
						lblMessage="出错，请检查excel格式是否正确";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="没有数据！";
			}
		}


		/// <summary>
		/// 预算调整导入
		/// </summary>
		/// <param name="ds"></param>
		/// <param name="lblMessage">返回的提示信息</param>
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
							int iYear=int.Parse(ds.Tables[0].Rows[i]["调整年份"].ToString().Trim());
							int iMonth=int.Parse(ds.Tables[0].Rows[i]["调整月份"].ToString().Trim());
							DateTime sheetDate=DateTime.Parse(ds.Tables[0].Rows[i]["调整单日期"].ToString().Trim());
							string deptCode=ds.Tables[0].Rows[i]["部门编号"].ToString().Trim();
							string sheetType=ds.Tables[0].Rows[i]["调整单类型"].ToString().Trim();
							string outSubject=ds.Tables[0].Rows[i]["转出科目"].ToString().Trim();
							string inSubject=ds.Tables[0].Rows[i]["转入科目"].ToString().Trim();
							float money=float.Parse(ds.Tables[0].Rows[i]["金额"].ToString().Trim());

							if("0".Equals(sheetType))  //0 = 调整
							{
								#region 
								Entiy.BudgetchangeSheet budGetChange=HDSZCheckFlow.Entiy.BudgetchangeSheet.FindByYearAndMonth(iYear,iMonth);
								if(budGetChange==null)
								{
									Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,deptCode,outSubject);
									if(budGet!=null && budGet.BudgetMoney>(decimal)money)
									{
										//纪录到调整表
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
										//更新预算表
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
										lblMessage=lblMessage + "转出金额超出";
									}
								}
								else
								{
									lblMessage=iMonth + "月已经有数据了，不能再导入";
								}
								#endregion 
							}
							else if("1".Equals(sheetType))  // 1= 追加
							{
								#region 
								Entiy.BudgetchangeSheet budGetChange=HDSZCheckFlow.Entiy.BudgetchangeSheet.FindByYearAndMonth(iYear,iMonth);
								if(budGetChange==null)
								{
									//纪录到调整表
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
									//更新预算表
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
									lblMessage=iMonth + "月已经有数据了，不能再导入";
								}
								#endregion 
							}
						}
					}
					catch(Exception ex)
					{
						tran.VoteRollBack();
						lblMessage="出错，请检查excel格式是否正确";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="没有数据！";
			}
		}


		/// <summary>
		/// 小额固定资产导入
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
							//if(!"".Equals(ds.Tables[0].Rows[i]["年份"].ToString()) && !"".Equals(ds.Tables[0].Rows[i]["月份"].ToString()))
							//{

							//字段 ： NO	管理编号	部门名称	科组	部门编码	科组编码	存货编码	存货名称	购入日期	数量	币种	价格	备注	存放地点	管理责任人	责任人工号
								
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
							string InvManageCode = ds.Tables[0].Rows[i]["管理编号"].ToString().Trim();
							string InvCode = ds.Tables[0].Rows[i]["存货编码"].ToString().Trim();
							string DeptClassCode = ds.Tables[0].Rows[i]["部门编码"].ToString().Trim();
							string DeptCode  =  ds.Tables[0].Rows[i]["科组编码"].ToString().Trim();
							string invPk = "";
							//找InvPk
							Entiy.Baseinventory Inv = HDSZCheckFlow.Entiy.Baseinventory.FindByCode(InvCode);
							if(Inv != null)
							{
								invPk = Inv.InvPk ; 
							}
							string dbizdate =  ds.Tables[0].Rows[i]["购入日期"].ToString().Trim();
							string iNum = ds.Tables[0].Rows[i]["数量"].ToString().Trim();
							string CurrTypeCode =  ds.Tables[0].Rows[i]["币种"].ToString().Trim();
							string Price =  ds.Tables[0].Rows[i]["价格"].ToString().Trim();
							string ReMark = ds.Tables[0].Rows[i]["备注"].ToString().Trim();
							string storage = ds.Tables[0].Rows[i]["存放地点"].ToString().Trim();
							string KeeperCode = ds.Tables[0].Rows[i]["责任人工号"].ToString().Trim();

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




							//int iYear=int.Parse(ds.Tables[0].Rows[i]["年份"].ToString().Trim());
							//int iMonth=int.Parse(ds.Tables[0].Rows[i]["月份"].ToString().Trim());
							//string subjectCode=ds.Tables[0].Rows[i]["科目编号"].ToString().Trim();
							//string deptCode=ds.Tables[0].Rows[i]["部门编号"].ToString().Trim();
							//float PlanMoney=float.Parse(ds.Tables[0].Rows[i]["推算金额"].ToString().Trim());
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
						lblMessage="出错，请检查excel格式是否正确";
						Common.Log.Logger.Log("Bussiness.BudgetAccountBLL-->",ex.Message);
					}
				}
			}
			else
			{
				lblMessage="没有数据！";
			}
		}


		/// <summary>
		/// 根据用户工号得到所在部门的预算情况
		/// </summary>
		/// <param name="UserCode">applyDept</param>
		/// <param name="SheetSubject">科目名称</param>
		public static Entiy.Budgetaccount GetBudgetInfoByUserCode(int iYear,int iMonth,string applyDept,string SheetSubject)
		{
			#region
//			//找 UserCode 所属的预算部门
//			Entiy.BasePerson basePerson=Entiy.BasePerson.Find(UserCode);
//			if(basePerson!=null)
//			{
//				//找所属的预算部门
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
		/// 当所查预算为null时,初始化一个空值
		/// </summary>
		/// <param name="iYear">年</param>
		/// <param name="iMonth">月</param>
		/// <param name="applyDept">人事部门（再转化为预算部门）</param>
		/// <param name="SheetSubject">科目</param>
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
					lblMessage="未指定所属预算部门";

				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("BudgetAccountBLL.SaveBudgetAccount",ex.Message );
			}
			
		}


		/// <summary>
		/// 当所查预算为null时,初始化一个空值,调整预算表时用
		/// </summary>
		/// <param name="iYear">年</param>
		/// <param name="iMonth">月</param>
		/// <param name="budgetDept">预算部门</param>
		/// <param name="SheetSubject">科目</param>
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
		/// 计算科目的调整金额
		/// </summary>
		/// <param name="iYear">年分</param>
		/// <param name="iMonth">月份</param>
		/// <param name="deptCode">人事部门</param>
		/// <param name="subject">科目</param>
		/// <returns></returns>
		public static decimal GetSubjectChangeMoney(int iYear,int iMonth,string deptCode,string subject)
		{
			// 1.  此科目转入的金额 + 此科目转出的金额  
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
		/// 计算科目的调整金额
		/// </summary>
		/// <param name="iYear">年分</param>
		/// <param name="iMonth">月份</param>
		/// <param name="deptCode">预算部门</param>
		/// <param name="subject">科目</param>
		/// <returns></returns>
		public static decimal GetAccountChangeMoney(int iYear,int iMonth,string deptCode,string subject)
		{
			// 1.  此科目转入的金额 + 此科目转出的金额  
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
		/// 科目的季度调整金额
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="deptcode"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static decimal GetAccountQuarterChange(int iYear,int iMonth,string deptcode,string subject)
		{
			// 1.  此科目转入的金额 + 此科目转出的金额  
			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(deptcode);
			decimal ChangeMoney = 0 ;  
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				//1.判断当前月份所在季度
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
		/// 科目的季度调整金额2
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="deptcode"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static decimal GetAccountQuarterChangeForBudDept(int iYear,int iMonth,string deptcode,string subject)
		{
			// 1.  此科目转入的金额 + 此科目转出的金额  
			//Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(deptcode);
			decimal ChangeMoney = 0 ;  
			
				//1.判断当前月份所在季度
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
		/// 更新预算表,调整金额字段.(给相关人员查看 , 不参与流程判断)
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		public static void UpdateAccountChange(int iYear,int iMonth)
		{
			// 所有部门 ,所有科目, 调整金额
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
			//超支判断标准。 预算/推算
//			Entiy.BaseCommonCode commonCode = Entiy.BaseCommonCode.FindByCodeType("BudgetStandard");
//			if(commonCode!=null)
//			{
//				if(commonCode.Code == "tuisuan" )
//				{
//					return 2 ;  // 推算
//				}
//				else if(commonCode.Code == "yusuan" )
//				{
//					return 1 ;  // 预算
//				}
//				else
//				{
//					return 3 ;  //出错
//				}
//			}
//			else
//			{
//				return 3 ;      //something wrong 
//			}

//			DateTime dt = System.DateTime.Today;   // 判断标准为系统时间
			#endregion 

			//Entiy.BaseBudgetStandard budgetStandard = Entiy.BaseBudgetStandard.FindByDateTime(dt.ToString("yyyyMMdd"));
			Entiy.BaseBudgetStandard budgetStandard = Entiy.BaseBudgetStandard.FindByDateTime(dt);

			if(budgetStandard!=null)
			{
				if(budgetStandard.BudgetStandard  == "tuisuan" )
				{
					return 2 ;  // 推算
				}
				else if(budgetStandard.BudgetStandard == "yusuan" )
				{
					return 1 ;  // 预算
				}
				else
				{
					return 3 ;  //出错
				}
			}
			else
			{
				return 3 ;      //something wrong 
			}
		}

		/// <summary>
		/// 获取部门科目季度预算信息
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="month">月</param>
		/// <param name="dept">部门</param>
		/// <param name="subjectCode">科目</param>
		/// <returns></returns>
		public static DataSet getQuarterBudgetInfo(int year, int month ,string dept,string subjectCode)
		{
			//1.判断当前月份所在季度
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
		/// 获取固定资产一级科目下的预算信息（按项目查预算信息）
		/// </summary>
		/// <param name="iYear">年</param>
		/// <param name="BudgetDeptCode">预算部门</param>
		/// <param name="itemName">项目名称</param>
		/// <returns></returns>
		public static DataSet getAssetBudgetInfo(int iYear , string BudgetDeptCode ,string itemName)
		{
			return DataAccess.Budget.budgetAccountDAL.getAssetBudgetInfo(iYear,BudgetDeptCode,itemName);
		}

		/// <summary>
		/// 查询未提交单据预算信息
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		/// <returns></returns>
		public static DataSet getLeftMoneyForUnSubmitApply(int applySheetHeadPk)
		{
			return  DataAccess.Budget.budgetAccountDAL.getLeftMoneyForUnSubmitApply(applySheetHeadPk);


		}

		/// <summary>
		/// 更新 实物购买、劳保购买 币种 价格信息，p_ApplyForPurchasePriceNull
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static DataSet IsNullApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			//只有实物购买、劳保购买类型才进行

			try
			{
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find (applySheetHeadPk) ;


				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   

				//购买类表体ApplySheetBody_Purchase
				if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
				{
					//执行更新存储过程 ,更新表体价格。

					return DataAccess.Budget.budgetAccountDAL.IsNullApplyPriceFromApplyHeadPk(applySheetHeadPk);


				}
				else
				{
					return null;
				}

			}
			catch(Exception Ex)
			{
				throw Ex;//出现错误，抛回上一层，阻止进一步提交
				
			}
		}


		/// <summary>
		/// 更新 实物购买、劳保购买 币种 价格信息，p_Apply_AutoUpdatePrice
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static void UpdateApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			//只有实物购买、劳保购买类型才进行

			try
			{
				Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find (applySheetHeadPk) ;


				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   

					//购买类表体ApplySheetBody_Purchase
				if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
				{
					//执行更新存储过程 ,更新表体价格。

					DataAccess.Budget.budgetAccountDAL.UpdateApplyPriceFromApplyHeadPk(applySheetHeadPk);


				}

			}
			catch(Exception Ex)
			{
				throw Ex;//出现错误，抛回上一层，阻止进一步提交
			}
		}

	}
}
