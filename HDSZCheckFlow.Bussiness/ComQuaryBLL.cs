using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ComQuaryBLL 的摘要说明。
	/// </summary>
	public class ComQuaryBLL
	{
		public ComQuaryBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static DataSet GetDataSetByViewAndQuery(string tableName,string Filter)
		{
			return DataAccess.CommonQuery.CommonQuery.GetDataSetByViewAndQuery(tableName,Filter);
		}

		public static void ExecuteProcedureNonParams(string procName)
		{
			DataAccess.CommonQuery.CommonQuery.ExecuteProcedureNonParams(procName);
		}

		public static DataSet  ExecutebyQuery(string query)
		{
			return DataAccess.CommonQuery.CommonQuery.GetDataSetByQuery (query);
		}

		public static DataSet  ExecutebyQuery(string query,string conn)
		{
			return DataAccess.CommonQuery.CommonQuery.GetDataSetByQuery (query,conn);
		}

		public static int GetExecuteScalar(string query)
		{
			return DataAccess.CommonQuery.CommonQuery.GetExecuteScalar (query);
		}

		//执行sql语句，返回是否成功（不返回值insert、、）
		public static int ExecuteStr(string query)
		{
			return DataAccess.CommonQuery.CommonQuery.ExecuteStr(query);
		}

		/// <summary>
		/// 执行带参数的存储过程(不带返回值)
		/// </summary>
		/// <returns></returns>
		public static void  ExecuteProcedureNonParams(string ProcName,DataAccess.DBParameterCollection Params)
		{

			DataAccess.CommonQuery.CommonQuery.ExecuteProcedureWithParams(ProcName,Params);
			
		}



	}
}
