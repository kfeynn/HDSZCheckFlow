using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.ApplySheet
{
	/// <summary>
	/// ApplyAuditingDAL ��ժҪ˵����
	/// ������
	/// </summary>
	public class ApplyAuditingDAL
	{
		public ApplyAuditingDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static DataSet GetMyAuditing(string myCode,string filter )
		{
			//��ѯ�����Լ������� and ����ת��Ȩ�����Լ�������
			string cmdStr="p_Flow_GetMyDuditingTemp";
			
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@UserCode",myCode));
			Params.Add(Parameter.GetDBParameter("@filter",filter));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);

		}

		public static DataSet GetMyAuditingForFinallyCheck(string myCode,string filter )
		{
			//��ѯ�����Լ������� and ����ת��Ȩ�����Լ�������
			string cmdStr="p_Flow_GetMyDuditingForFinallyPriceCheck";
			
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@UserCode",myCode));
			Params.Add(Parameter.GetDBParameter("@filter",filter));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);

		}



		/// <summary>
		/// ��ѯ�������ݵ���ϸ��Ϣ����
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
		/// ��ѯʵ�ﹺ���������ݵ���ϸ��Ϣ2 (�����Ѿ��е�����)
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
		/// ��ѯ���������(���ݱ�ͷ����)
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
		/// ��ѯ��Ӫ�����(���ݱ�ͷ����)
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
		/// ��ѯ��Ӫ�����_�۸�þ�����(���ݱ�ͷ����)
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
		/// ��ѯ��Ӫ�����_�۸�þ�����(���ݱ�ͷ����)
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
		/// ��ѯ������¼ (...)
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyRecord(int applyHeadPK)
		{
//			string cmdStr=@"SELECT rec.*, case rec.IsPass when 1 then 'ͬ��' when 0 then '�ܾ�' end as IsAgree , ApplyType.ApplyTypeName, per.Name,
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
		/// ��ѯ������¼�۸�þ��� 
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
								CASE ApplySheetHead_Budget.SubmitType WHEN 1 THEN 'Ԥ����' WHEN 2 THEN 'Ԥ����'
								WHEN 3 THEN '�� ��' END AS SubmitType,ApplySheetHead.ApplySheetHead_Pk,ApplySheetHead.ApplySheetNo,ApplyProcessType.ApplyProcessTypeName 
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
		/// ��ѯ���ڱ��˵���������¼, ͨ����,�;ܾ���
		/// </summary>
		/// <param name="userCode">�����߹���</param>
		/// <param name="ispass">�Ƿ�ͨ��</param>
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
		/// ��ѯ��Ҫ��ӡ�ĵ�����Ϣ
		/// </summary>
		/// <param name="view">��ͼ���</param>
		/// <param name="query">��ѯ����</param>
		/// <returns></returns>
		public static DataSet GetApplyPhuse(string view,string query)
		{
			string cmdStr = " select * from " + view + query  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// ��ѯ��Ҫ��ӡ�ĵ�����Ϣ
		/// </summary>
		/// <param name="view">��ͼ���</param>
		/// <param name="query">��ѯ����</param>
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
		///  ��ѯ�������ĸ���
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
