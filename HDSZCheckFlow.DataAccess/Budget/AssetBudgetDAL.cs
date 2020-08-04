using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.Budget
{
	/// <summary>
	/// AssetBudgetDAL 的摘要说明
	/// </summary>
	public class AssetBudgetDAL
	{
		public AssetBudgetDAL(){}

		/// <summary>
		/// 查找固定资产一级科目
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public static DataSet SelectFirstClassSubjectByYearAndClassDept(int iYear,string DeptCode )
		{
			try
			{
				string cmdStr = "p_Asset_SelectBudgetItemByYearAndClassDept";

				
				DBAccess dbAccess=new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@Iyear",iYear));
				Params.Add(Parameter.GetDBParameter("@DeptCode",DeptCode));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.AssetBudgetDAL->",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 查找固定资产一级科目
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="DeptCode"></param>
		/// <returns></returns>
		public static DataSet SelectFirstClassSubjectByYearAndDept(int iYear,string DeptCode )
		{
			try
			{
				string cmdStr = "p_Asset_SelectBudgetItemByYearAndDept";

				
				DBAccess dbAccess=new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@Iyear",iYear));
				Params.Add(Parameter.GetDBParameter("@DeptCode",DeptCode));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.AssetBudgetDAL->",ex.Message );
				return null;
			}
		}

        //根据年份和新营预算一级科目查询其对应二级科目
		public static DataSet SelectSubItemByYearAndFirstItem(int iYear,string DeptCode,string ItemName)
		{
			//p_Asset_SelectBudgetSubItemByYearAndFirstItem

			try
			{
				string cmdStr = "p_Asset_SelectBudgetSubItemByYearAndFirstItem";

				
				DBAccess dbAccess=new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@Iyear",iYear));
				Params.Add(Parameter.GetDBParameter("@DeptCode",DeptCode));
				Params.Add(Parameter.GetDBParameter("@ItemName",ItemName));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.AssetBudgetDAL.SelectSubItemByYearAndFirstItem->",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 一键维护审批提交金额 2011-12-16 liyang
		/// </summary>
		/// <param name="Iyear"></param>
		/// <param name="DeptCode"></param>
		/// <param name="ItemName"></param>
		/// <param name="SubjectName"></param>
		public static void ConsistencyCheckMoney(string Iyear,string DeptCode,string ItemName,string SubjectName)
		{
			try
			{
				string cmdStr = "p_Asset_ConsistencyCheckMoney";

				DBAccess dbAccess=new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@Iyear",Iyear));
				Params.Add(Parameter.GetDBParameter("@DeptCode",DeptCode));
				Params.Add(Parameter.GetDBParameter("@ItemName",ItemName));
				Params.Add(Parameter.GetDBParameter("@SubjectName",SubjectName));

				dbAccess.ExecuteNonQuery(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.AssetBudgetDAL.ConsistencyCheckMoney()->",ex.Message );
			}
		}


		/// <summary>
		/// 设置新营申请单据可预算外提交
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		public static void SetAssetApplyOverBudget(int ApplyHeadKey)
		{

		}

	}
}
