using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.Budget
{
	/// <summary>
	/// budgetAccountDAL 的摘要说明。
	/// </summary>
	public class budgetAccountDAL
	{
		public budgetAccountDAL(){}

		/// <summary>
		/// 获取季度预算信息
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="quarter">季度</param>
		/// <param name="dept">部门</param>
		/// <param name="subjectCode">科目</param>
		/// <returns></returns>
		public static DataSet getQuarterBudgetInfo(int year, int quarter ,string dept,string subjectCode)
		{
			try
			{
				string cmdStr = "b_getQuarterBudgetInfo" ;

				DBAccess dbAccess=new SQLAccess();

				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@year",year));
				Params.Add(Parameter.GetDBParameter("@quarter",quarter));
				Params.Add(Parameter.GetDBParameter("@dept",dept));
				Params.Add(Parameter.GetDBParameter("@subjectcode",subjectCode));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.budgetAccountDAL.getQuarterBudgetInfo",ex.Message );
				return null;
			}
		}

		public static DataSet getAssetBudgetInfo(int iYear , string BudgetDeptCode ,string itemName)
		{

			try
			{
				string cmdStr = "p_Asset_BudgetInfo" ;

				DBAccess dbAccess=new SQLAccess();

				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@iYear",iYear));
				Params.Add(Parameter.GetDBParameter("@DeptCode",BudgetDeptCode));
				Params.Add(Parameter.GetDBParameter("@ItemName",itemName));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.budgetAccountDAL.getAssetBudgetInfo",ex.Message );
				return null;
			}

		}

		/// <summary>
		/// 获取科目季度调整金额
		/// </summary>
		/// <param name="year">年</param>
		/// <param name="quarter">季度</param>
		/// <param name="dept">部门</param>
		/// <param name="subjectcode">科目</param>
		/// <returns></returns>
		public static decimal getQuarterBudgetChange(int year,int quarter,string dept,string subjectcode)
		{
			string cmdStr = "b_getQuarterBudgetChange";

			DBAccess dbAccess = new SQLAccess();

			decimal changemoney = 0.00m ;

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@year",year));
			Params.Add(Parameter.GetDBParameter("@quarter",quarter));
			Params.Add(Parameter.GetDBParameter("@dept",dept));
			Params.Add(Parameter.GetDBParameter("@subjectcode",subjectcode));
			Params.Add(Parameter.GetDBParameter("@changemoney",changemoney,ParameterDirection.Output));

			dbAccess.ExecuteNonQuery(cmdStr,CommandType.StoredProcedure,Params);

			changemoney = Convert.ToDecimal(Params[Params.Count-1].Value);

			return changemoney; 
		}

		/// <summary>
		/// 查询未提交单据预算信息
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		/// <returns></returns>
		public static DataSet getLeftMoneyForUnSubmitApply(int applySheetHeadPk)
		{
			try
			{
				string cmdStr= "[p_getBudgetInfobySheetHeadPk]";

				DBAccess dbAccess = new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@ApplySheetHead_Pk",applySheetHeadPk));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.budgetAccountDAL.getLeftMoneyForUnSubmitApply",ex.Message );
				return null;
			}



		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static DataSet IsNullApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			try
			{
				string cmdStr= "[p_ApplyForPurchasePriceNull]";

				DBAccess dbAccess = new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@ApplySheetHead_Pk",applySheetHeadPk));

				return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.budgetAccountDAL.getLeftMoneyForUnSubmitApply",ex.Message );
				throw ex;
			}



		}



		/// <summary>
		/// 
		/// </summary>
		/// <param name="applySheetHeadPk"></param>
		public static void UpdateApplyPriceFromApplyHeadPk(int applySheetHeadPk)
		{
			try
			{
				string cmdStr= "[p_Apply_AutoUpdatePrice]";

				DBAccess dbAccess = new SQLAccess();
				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@applyHeadPk",applySheetHeadPk));

				dbAccess.ExecuteNonQuery(cmdStr,CommandType.StoredProcedure,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.Budget.budgetAccountDAL.getLeftMoneyForUnSubmitApply",ex.Message );
				throw ex;
			}



		}

	}
}
