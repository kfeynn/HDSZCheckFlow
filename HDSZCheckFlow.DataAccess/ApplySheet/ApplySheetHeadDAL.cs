using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.ApplySheet
{
	/// <summary>
	/// ApplySheetHeadDAL 的摘要说明。
	/// </summary>
	public class ApplySheetHeadDAL
	{
		public ApplySheetHeadDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyType(string deptClassCode)
		{
			try
			{
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType where ApplyType.IsStop = 0 and ApplyType.IsValid = 1  ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 返回所有有效的申请单据类型(除开新营)  
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeButAsset(string deptClassCode)
		{
			try
			{
				//新营类型
				string AssetTypeCode = System.Configuration.ConfigurationSettings.AppSettings["Asset"];

				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType where ApplyType.IsStop = 0 and ApplyType.IsValid = 1 and  ApplyType.ApplyTypeCode <> '" + AssetTypeCode + "' ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 返回所有有效的申请单据类型(只有新营)  
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeOfAsset(string deptClassCode)
		{
			try
			{
				//新营类型
				string AssetTypeCode = System.Configuration.ConfigurationSettings.AppSettings["Asset"];

				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType where ApplyType.IsStop = 0 and ApplyType.IsValid = 1 and  ApplyType.ApplyTypeCode = '" + AssetTypeCode + "' ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}



		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeCom(string deptClassCode)
		{
			try
			{
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType inner join  base_deptcanusetype 
								on ApplyType.ApplyTypeCode = base_deptcanusetype.applytype 
								where base_deptcanusetype.deptcode = '" + deptClassCode + "'  ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}
		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeNon(string deptClassCode)
		{
			try
			{
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType inner join  base_deptcanusetype 
								on ApplyType.ApplyTypeCode = base_deptcanusetype.applytype 
								where base_deptcanusetype.deptcode = '" + deptClassCode + "' and  ApplyType.applysheetbody_tablename not in ('ApplySheetBody_EvectionCharge','ApplySheetBody_Banquet') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}
		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeEvection(string deptClassCode)
		{
			try
			{

				string EvectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"];
				//出差类别
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType inner join  base_deptcanusetype 
								on ApplyType.ApplyTypeCode = base_deptcanusetype.applytype 
								where base_deptcanusetype.deptcode = '" + deptClassCode + "' and  ApplyType.ApplyTypeCode = '" + EvectionCode + "'"; // ApplyType.applysheetbody_tablename in ('ApplySheetBody_EvectionCharge') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}
		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeBanquet(string deptClassCode)
		{
			try
			{
				string BanquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"];
				//出差类别
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType inner join  base_deptcanusetype 
								on ApplyType.ApplyTypeCode = base_deptcanusetype.applytype 
								where base_deptcanusetype.deptcode = '" + deptClassCode + "' and  ApplyType.ApplyTypeCode = '" + BanquetCode + "'"; // ApplyType.applysheetbody_tablename in ('ApplySheetBody_EvectionCharge') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 返回所有有效的申请单据类型
		/// </summary>
		/// <param name="deptClassCode">一级部门</param>
		/// <returns></returns>
		public static DataTable  GetApplyTypeByCode(string deptClassCode,string typeClass)
		{
			try
			{
				string BanquetCode = System.Configuration.ConfigurationSettings.AppSettings[typeClass];
				//出差类别
				string cmdStr=@"select ApplyTypeCode,ApplyTypeName from  ApplyType inner join  base_deptcanusetype 
								on ApplyType.ApplyTypeCode = base_deptcanusetype.applytype 
								where base_deptcanusetype.deptcode = '" + deptClassCode + "' and  ApplyType.ApplyTypeCode = '" + BanquetCode + "'"; // ApplyType.applysheetbody_tablename in ('ApplySheetBody_EvectionCharge') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return null;
			}
		}



		/// <summary>
		/// 取最大流水号
		/// </summary>
		/// <param name="perfix">前缀ad200805</param>
		/// <returns></returns>
		public static string GetMaxSheetNo(string perfix)
		{
			try
			{
//				string cmdStr="select Max(RIGHT(ApplySheetNo,5)) AS MaxNum from applysheethead where substring(applysheetno,0,len(applysheetno)-4)='" + perfix + "'";
				
				DBAccess dbAccess=new SQLAccess();
				string cmdStr="p_Apply_GetMaxApplyNo";
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@perFix",perfix));		
				Object o= dbAccess.ExecuteScalar(cmdStr,CommandType.StoredProcedure,Params);
				if(o==null)
				{
					return "";
				}
				else
				{
					return o.ToString();
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplySheetHeadDAL",ex.Message );
				return "";
			}
		}
		//
		/// <summary>
		/// 取最大流水号
		/// </summary>
		/// <returns></returns>
		public static string GetMaxOrderNo(string perfix)
		{
			try
			{
				
				DBAccess dbAccess=new SQLAccess();
				string cmdStr="p_Order_GetMaxOrderNo";
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@perFix",perfix));		
				Object o= dbAccess.ExecuteScalar(cmdStr,CommandType.StoredProcedure,Params);

//				Object o= dbAccess.ExecuteScalar(cmdStr);
				if(o==null)
				{
					return "";
				}
				else
				{
					return o.ToString();
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("存储过程GetMaxOrderNo",ex.Message );
				return "";
			}
		}


		/// <summary>
		/// 设置预算外
		/// </summary>
		/// <param name="applyHeadPk"></param>
		/// <param name="key"></param>
		/// <param name="TotalAllowOutMoney"></param>
		public static void SetIsOverBudget(int applyHeadPk,int key,decimal TotalAllowOutMoney,decimal overMoney )
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					//string cmdStr = "update ApplySheetHead set IsOverBudget=" + key + " where ApplySheetHead_Pk= " + applyHeadPk + "" ;
					//DBAccess dbAccess = new SQLAccess();
					//dbAccess.ExecuteNonQuery(cmdStr); 
					decimal sheetMoney = 0 ; 
					Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
					if(applyHead != null )
					{
						Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
						Entiy.ApplySheetHeadBudget applyBud = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

						if(dept != null && applyBud != null )
						{
							//更新累计已审批预算外金额, 单据的本次累计预算外金额
							Entiy.Budgetaccount budget = Entiy.Budgetaccount.FindByYearAndMonth(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,dept.BudgetDeptCode,applyBud.SheetSubject);
							
							TotalAllowOutMoney = TotalAllowOutMoney + overMoney ; 

							sheetMoney = budget.TotalAllowOutMoney + overMoney ; 
							budget.TotalAllowOutMoney = sheetMoney ; 
							budget.Update(); 
							//此单可预算外金额为 ，季度可预算外金额  

							
							applyBud.AllowOutMoney = TotalAllowOutMoney ;  
							applyBud.Update();
//
//							applyHead.OverMoney = overMoney ; 
//
//							applyHead.Update();

						}
//						applyHead.IsOverBudget = 1 ;
//						applyHead.Update();
						string cmdStr = "update ApplySheetHead set OverMoney = " + overMoney + ",   IsOverBudget=" + key + " where ApplySheetHead_Pk= " + applyHeadPk + "" ;
						DBAccess dbAccess = new SQLAccess();
						dbAccess.ExecuteNonQuery(cmdStr); 

						tran.VoteCommit();
					}
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("ApplySheetHeadDAL.SetIsOverBudget",ex.Message);
					tran.VoteRollBack();
				}
			}
		}



		/// <summary>
		/// 取消设置预算外
		/// </summary>
		/// <param name="applyHeadPk"></param>
		/// <param name="key"></param>
		/// <param name="TotalAllowOutMoney"></param>
		public static void CanclSetIsOverBudget(int applyHeadPk,int key,decimal TotalAllowOutMoney )
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					decimal sheetMoney = 0 ; 
					Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
					//decimal overMoney = 
					if(applyHead != null )
					{
						Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
						Entiy.ApplySheetHeadBudget applyBud = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

						if(dept != null && applyBud != null )
						{
							//更新累计已审批预算外金额, 单据的本次累计预算外金额
							Entiy.Budgetaccount budget = Entiy.Budgetaccount.FindByYearAndMonth(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,dept.BudgetDeptCode,applyBud.SheetSubject);
							
							TotalAllowOutMoney = TotalAllowOutMoney - applyHead.OverMoney ; 

							sheetMoney = budget.TotalAllowOutMoney - applyHead.OverMoney ; 

							budget.TotalAllowOutMoney = sheetMoney ; 
							budget.Update(); 
							//此单可预算外金额为 ，季度可预算外金额  
							
							applyBud.AllowOutMoney = TotalAllowOutMoney ;  
							applyBud.Update();

						}
			
						string cmdStr = "update ApplySheetHead set  OverMoney =0 , IsOverBudget=" + key + " where ApplySheetHead_Pk= " + applyHeadPk + "" ;
						DBAccess dbAccess = new SQLAccess();
						dbAccess.ExecuteNonQuery(cmdStr); 

						tran.VoteCommit();
					}
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("ApplySheetHeadDAL.SetIsOverBudget",ex.Message);
					tran.VoteRollBack();
				}
			}
		}







	}
}
