using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.CostAssay
{
	/// <summary>
	/// CostDAL ��ժҪ˵����
	/// </summary>
	public class CostDAL
	{
		public CostDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
		/// �������²�ѯԤʵ����
		/// </summary>
		/// <param name="iYear">���</param>
		/// <param name="iMonth">�·�</param>
		/// <returns>���ؽ����</returns>
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
		/// ��ѯ����Ԥ�㱨���� 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetBudgetDept(string filter)
		{
			string cmdStr="select tableCode,tableName from Base_Runreport " + filter;// where  classtype='budget' and type='dept'
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}


		/// <summary>
		/// ��ȡ���б���ͳ�Ʋ���
		/// </summary>
		/// <returns></returns>
		public static DataSet GetAllBudgetDeptInfo ()
		{
			string cmdStr = " select  tableCode,tableName from Base_Runreport  group by  tableCode,tableName ,[type] order by [type] desc ";
			DBAccess dbAccess = new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);

		}

		/// <summary>
		/// ����Ԥ�㱨���� ��ѯ��Ԥʵ����Ϣ
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
		/// ����Ԥ�㱨���� ��ѯ��Ԥʵ����ϢClassDept 
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


		//��������Ϣ
		public static DataSet BindAccBook (string key)
		{
			string cmdStr = " select * from Base_CommonCode where codetype = '" + key + "'" ;
			DBAccess dbAccess = new SQLAccess();

			return dbAccess.ExecuteDataset(cmdStr);

		}


		/// <summary>
		/// ����Ԥ�㱨���� ��ѯ��Ԥʵ����ϢClassDept 
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
		/// ��ѯԤ�Ʋ���
		/// </summary>
		/// <param name="iYear">���</param>
		/// <param name="Quarter">����</param>
		/// <param name="type">���,0 �в���, 1 ����</param>
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
		/// ��ѯԤ�Ʋ���
		/// </summary>
		/// <param name="iYear">���</param>
		/// <param name="Quarter">����</param>
		/// <param name="type">���,0 �в���, 1 ����</param>
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
			//����ʵ��ʹ�ý��
			string cmdStr ="PImportGLNCCost";

			DBAccess dbAccess = new SQLAccess();
			dbAccess.CommandTimeout = 180 ; //����ʱ�� 

			DBParameterCollection Params = new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@IYear",iYear));
			Params.Add(Parameter.GetDBParameter("@IMonth",iMonth));

			dbAccess.ExecuteNonQuery(cmdStr,CommandType.StoredProcedure,Params);

		}


		public static DataSet GetProcInfo(string ProcName,int iYear,int iMonth,string AccBook)
		{

			//����ʵ��ʹ�ý��
		
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
		/// ����̶��ʲ��۾���Ϣ
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
