using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.CostAssay
{
	/// <summary>
	/// CostDAL 的摘要说明。
	/// </summary>
	public class CostDAL
	{
		public CostDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public  static DataSet  temp()
		{
			string cmdStr="tempGetCost";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
//			Params.Add(Parameter.GetDBParameter("@deptCode",deptCode));
//			Params.Add(Parameter.GetDBParameter("@result",result,ParameterDirection.Output));
//
//			dbAccess.ExecuteDataset(("p_Flow_CheckFlowInDeptValid",CommandType.StoredProcedure,Params);

			return dbAccess.ExecuteDataset(cmdStr);
		}

		/// <summary>
		/// 根据年月查询预实数据
		/// </summary>
		/// <param name="iYear">年份</param>
		/// <param name="iMonth">月份</param>
		/// <returns>返回结果集</returns>
		public static DataSet getCost(int iYear,int iMonth)
		{
			string cmdStr="GetCostByYearAndMonth";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);


		}

		/// <summary>
		/// 查询所有预算报表部门 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetBudgetDept(string filter)
		{
			string cmdStr="select tableCode,tableName from Base_Runreport " + filter;// where  classtype='budget' and type='dept'
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}


		/// <summary>
		/// 获取所有报表统计部门
		/// </summary>
		/// <returns></returns>
		public static DataSet GetAllBudgetDeptInfo ()
		{
			string cmdStr = " select  tableCode,tableName from Base_Runreport  group by  tableCode,tableName ,[type] order by [type] desc ";
			DBAccess dbAccess = new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);

		}

		/// <summary>
		/// 根据预算报表部门 查询其预实算信息
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByDept(int iYear,int iMonth,string budGetDept ,string subject)
		{
			string cmdStr="GetCostByYearMonthAndBudgetDept";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));
			Params.Add(Parameter.GetDBParameter("@budGetDept",budGetDept));
			Params.Add(Parameter.GetDBParameter("@subject",subject));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}



		/// <summary>
		/// 根据预算报表部门 查询其预实算信息ClassDept 
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByClassDept(int iYear,int iMonth,string tableCode,string AccBook)
		{
			string cmdStr="GetCostByClassDept";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));
			Params.Add(Parameter.GetDBParameter("@tableCode",tableCode));
			Params.Add(Parameter.GetDBParameter("@AccBook",AccBook));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}


		//绑定帐套信息
		public static DataSet BindAccBook (string key)
		{
			string cmdStr = " select * from Base_CommonCode where codetype = '" + key + "'" ;
			DBAccess dbAccess = new SQLAccess();

			return dbAccess.ExecuteDataset(cmdStr);

		}


		/// <summary>
		/// 根据预算报表部门 查询其预实算信息ClassDept 
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByCompanyDept(int iYear,int iMonth)
		{
			string cmdStr="GetCostByCompanyDept";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}

		/// <summary>
		/// 查询预推差异
		/// </summary>
		/// <param name="iYear">年份</param>
		/// <param name="Quarter">季度</param>
		/// <param name="type">类别,0 有差异, 1 所有</param>
		/// <returns></returns>
		public static DataSet GetBudgetCostCompare(int iYear , int Quarter, int type )
		{
			string cmdStr="P_Budget_CompareBugetToPan";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@IYear",iYear));
			Params.Add(Parameter.GetDBParameter("@Quarter",Quarter));
			Params.Add(Parameter.GetDBParameter("@Type",type));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}

		/// <summary>
		/// 查询预推差异
		/// </summary>
		/// <param name="iYear">年份</param>
		/// <param name="Quarter">季度</param>
		/// <param name="type">类别,0 有差异, 1 所有</param>
		/// <returns></returns>
		public static DataSet GetBudgetCostCompare2(int iYear , int Quarter, int type ,string budgetDept)
		{
			string cmdStr="P_Budget_CompareBugetToPan_1";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@IYear",iYear));
			Params.Add(Parameter.GetDBParameter("@Quarter",Quarter));
			Params.Add(Parameter.GetDBParameter("@Type",type));
			Params.Add(Parameter.GetDBParameter("@deptcode",budgetDept));

			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}

		public static void UpdateGl_NC_Cost(int iYear,int iMonth )
		{
			//更新实际使用金额
			string cmdStr ="PImportGLNCCost";

			DBAccess dbAccess = new SQLAccess();
			dbAccess.CommandTimeout = 180 ; //过期时间 

			DBParameterCollection Params = new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@IYear",iYear));
			Params.Add(Parameter.GetDBParameter("@IMonth",iMonth));

			dbAccess.ExecuteNonQuery(cmdStr,CommandType.StoredProcedure,Params);

		}


		public static DataSet GetProcInfo(string ProcName,int iYear,int iMonth,string AccBook)
		{

			//更新实际使用金额
		
			DBAccess dbAccess = new SQLAccess();

			DBParameterCollection Params = new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@IYear",iYear));
			Params.Add(Parameter.GetDBParameter("@IMonth",iMonth));
			Params.Add(Parameter.GetDBParameter("@AccBook",AccBook));

			return dbAccess.ExecuteDataset(ProcName,CommandType.StoredProcedure,Params);


		}

		
		public static DataSet GetProcInfo(string ProcName,string tablename,int iYear,int StMonth,int EdMonth,string AccBook)
		{

			//		@deptTableCode = N'zhizao',
			//		@iYear = 2010,
			//		@StartMonth = 1,
			//		@EndMonth = 3
		
			DBAccess dbAccess = new SQLAccess();

			DBParameterCollection Params = new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@deptTableCode",tablename));
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@StartMonth",StMonth));
			Params.Add(Parameter.GetDBParameter("@EndMonth",EdMonth));
			Params.Add(Parameter.GetDBParameter("@AccBook",AccBook));


			return dbAccess.ExecuteDataset(ProcName,CommandType.StoredProcedure,Params);


		}

		/// <summary>
		/// 计算固定资产折旧信息
		/// </summary>
		/// <returns></returns>
		public static DataSet RunFaCardbyDate(int iYear ,int iMonth)
		{
			DBAccess dbAccess = new SQLAccess();

			DBParameterCollection Params = new DBParameterCollection();

			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));

			return dbAccess.ExecuteDataset("p_run_facard",CommandType.StoredProcedure,Params);
			 
			
		}


	}
}
