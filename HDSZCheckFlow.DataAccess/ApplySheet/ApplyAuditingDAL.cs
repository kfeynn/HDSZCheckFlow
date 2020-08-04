using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.ApplySheet
{
	/// <summary>
	/// ApplyAuditingDAL 的摘要说明。
	/// 审批类
	/// </summary>
	public class ApplyAuditingDAL
	{
		public ApplyAuditingDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataSet GetMyAuditing(string myCode,string filter )
		{
			//查询属于自己的审批 and 别人转交权利给自己的审批
			string cmdStr="p_Flow_GetMyDuditingTemp";
			
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@UserCode",myCode));
			Params.Add(Parameter.GetDBParameter("@filter",filter));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);

		}

		public static DataSet GetMyAuditingForFinallyCheck(string myCode,string filter )
		{
			//查询属于自己的审批 and 别人转交权利给自己的审批
			string cmdStr="p_Flow_GetMyDuditingForFinallyPriceCheck";
			
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@UserCode",myCode));
			Params.Add(Parameter.GetDBParameter("@filter",filter));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);

		}



		/// <summary>
		/// 查询审批单据的详细信息（）
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyInfo(int applyHeadPK)
		{
//			string cmdStr="select * from  ApplySheetBody_Purchase o  where o.ApplySheetHead_Pk=" + applyHeadPK + " "; //Base_inventory.INVSPEC, 
			string cmdStr=@"SELECT Base_inventory.invCode, Base_inventory.invName,isnull(Base_inventory.Invspec ,Base_inventory.INVTYPE) AS INVSPEC, 
								Base_inventory.MEASNAME, ApplySheetBody_Purchase.Number, 
								ApplySheetBody_Purchase.RMBPrice, ApplySheetBody_Purchase.Money, 
								ApplySheetBody_Purchase.Memo, ApplySheetBody_Purchase.currTypeCode, 
								ApplySheetBody_Purchase.ExchangeRate, 
								ApplySheetBody_Purchase.originalcurrPrice
							FROM ApplySheetBody_Purchase INNER JOIN
								Base_inventory ON 
								ApplySheetBody_Purchase.InventoryCode = Base_inventory.inv_pk" + " where ApplySheetBody_Purchase.ApplySheetHead_Pk=" + applyHeadPK + " ";
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}


		/// <summary>
		/// 查询实物购买审批单据的详细信息2 (包含已经有的数量)
		/// </summary>
		/// <param name="applyHeadPk"></param>
		/// <returns></returns>
		public static DataSet GetApplyPurchaseBodyInfo(int applyHeadPk)
		{
			string cmdStr = "p_Budget_SelectApplyPurchaseBodyByApplyHeadPk";

			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@applyPk",applyHeadPk));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);


		}
			


		/// <summary>
		/// 查询报销类表体(根据表头主键)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyPayInfo(int ApplyHeadKey)
		{
			string cmdStr="select *  from  ApplySheetBody_Pay where ApplySheetHead_Pk= " + ApplyHeadKey + "";
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 查询新营类表体(根据表头主键)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetInfo(int ApplyHeadKey)
		{
			string cmdStr="select *  from  v_Asset_ApplySheet_Body  where ApplySheetHead_Pk= " + ApplyHeadKey + "";
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 查询新营类表体_价格裁决表体(根据表头主键)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetAndCheckInfo(int ApplyHeadKey,string Ids,string FId)
		{
			string cmdStr="select *  from  v_AssetBody_CheckBody where ApplySheetHead_Pk= " + ApplyHeadKey + " and FId in (" + FId + ")" + " and Id in (" + Ids + ")"  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 查询新营类表体_价格裁决表体(根据表头主键)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetFinallyBodyInfoByCheckId(int FinallyCheckId )
		{
			string cmdStr="select *  from  v_AssetBody_CheckBody where  FId in (" + FinallyCheckId + ")"  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 查询审批记录 (...)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyRecord(int applyHeadPK)
		{
//			string cmdStr=@"SELECT rec.*, case rec.IsPass when 1 then '同意' when 0 then '拒绝' end as IsAgree , ApplyType.ApplyTypeName, per.Name,
//							(SELECT name
//							FROM base_person per
//							WHERE per.personcode = rec.displayspersoncode AND isdisplays = 1) 
//								AS displaysName,CheckRole.CheckRoleName 
//							FROM applySheetCheckRecord rec INNER JOIN
//							ApplySheetHead ON 
//							rec.ApplySheetHead_Pk = ApplySheetHead.ApplySheetHead_Pk INNER JOIN
//							ApplyType ON 
//							ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
//							Base_Person per ON rec.CheckPersonCode = per.personCode  INNER JOIN
//								CheckRole ON rec.CheckRole = CheckRole.CheckRoleCode
//							where rec.ApplySheetHead_Pk=" + applyHeadPK + "  order by  rec.Checkdate asc ";

			DBAccess dbAccess=new SQLAccess();
			string  cmdStr = "p_Flow_GetNonCheckPerson";
			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@applyHeadPk",applyHeadPK));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure ,Params);
		}


		/// <summary>
		/// 查询审批记录价格裁决单 
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyRecordForFinallyCheck(int FinallyCheckId)
		{
			DBAccess dbAccess=new SQLAccess();
			string  cmdStr = "p_Flow_GetFinallyCheckRecored";
			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@FinallyCheckId",FinallyCheckId));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure ,Params);
		}



		public static DataSet GetAuditingByType(string  applyType)
		{
			try
			{
				string cmdStr=@"SELECT Base_Dept.DeptName, Base_Person.Name, ApplySheetHead.ApplyDate, 
								ApplyType.ApplyTypeName, ApplySheetHead_Budget.SheetMoney, 
								CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN '预算内' WHEN 2 THEN '预算外'
								WHEN 3 THEN '紧 急' END AS SubmitType,ApplySheetHead.ApplySheetHead_Pk,ApplySheetHead.ApplySheetNo,ApplyProcessType.ApplyProcessTypeName 
							FROM ApplySheetHead INNER JOIN
								Base_Person ON 
								ApplySheetHead.ApplyPersonCode = Base_Person.personCode INNER JOIN
								Base_Dept ON ApplySheetHead.ApplyDeptCode = Base_Dept.DeptCode INNER JOIN
								ApplyType ON 
								ApplySheetHead.ApplyTypeCode = ApplyType.ApplyTypeCode INNER JOIN
								ApplySheetHead_Budget ON 
								ApplySheetHead.ApplySheetHead_Pk = ApplySheetHead_Budget.ApplySheetHead_Pk INNER
								JOIN
								ApplyProcessType ON 
								ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode  " + applyType ;

				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.ApplySheet.ApplyAuditingDAL",ex.Message);
				return null;
			}
		}

		/// <summary>
		/// 查询属于本人的已审批记录, 通过的,和拒绝的
		/// </summary>
		/// <param name="userCode">审批者工号</param>
		/// <param name="ispass">是否通过</param>
		/// <returns></returns>
		public static DataSet GetMyAuditedApply(string query)
		{
//			string cmdStr="p_Flow_MyDuditedApply";
//			
//			DBAccess dbAccess=new SQLAccess();
//
//			DBParameterCollection Params=new DBParameterCollection();
//			Params.Add(Parameter.GetDBParameter("@UserCode",userCode));
//			Params.Add(Parameter.GetDBParameter("@isPass",ispass));
//			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);


			string cmdStr= "select * from v_DisAllowApply " + query;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);

		}

		/// <summary>
		/// 查询将要打印的单据信息
		/// </summary>
		/// <param name="view">视图或表</param>
		/// <param name="query">查询条件</param>
		/// <returns></returns>
		public static DataSet GetApplyPhuse(string view,string query)
		{
			string cmdStr = " select * from " + view + query  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 查询将要打印的单据信息
		/// </summary>
		/// <param name="view">视图或表</param>
		/// <param name="query">查询条件</param>
		/// <returns></returns>
		public static DataSet GetApplychange(int applypk)
		{
			string cmdStr = @"SELECT ApplySheetBody_EvectionCharge.*, 
									Base_CommonCode.CodeName AS CodeName
								FROM ApplySheetBody_EvectionCharge INNER JOIN
									Base_CommonCode ON 
									ApplySheetBody_EvectionCharge.ChargePro = Base_CommonCode.Code AND 
									ApplySheetBody_EvectionCharge.ApplySheetHead_Pk =" + applypk  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}


		/// <summary>
		///  查询待审批的个数
		/// </summary>
		/// <param name="personCode"></param>
		/// <returns></returns>
		public static int GetNaAuditing(string personCode)
		{
			try
			{
				string cmdStr ="p_Flow_GetNaOfAudting";
				DBAccess dbAccess=new SQLAccess();

				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@UserCode",personCode));
				return (int)dbAccess.ExecuteScalar(cmdStr,CommandType.StoredProcedure,Params);

			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("GetNaAuditing.DAL",ex.Message);
				return 0;
			}

		}
	}
}
