using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ComQuaryBLL ��ժҪ˵����
	/// </summary>
	public class ComQuaryBLL
	{
		public ComQuaryBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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

		//ִ��sql��䣬�����Ƿ�ɹ���������ֵinsert������
		public static int ExecuteStr(string query)
		{
			return DataAccess.CommonQuery.CommonQuery.ExecuteStr(query);
		}

		/// <summary>
		/// ִ�д������Ĵ洢����(��������ֵ)
		/// </summary>
		/// <returns></returns>
		public static void  ExecuteProcedureNonParams(string ProcName,DataAccess.DBParameterCollection Params)
		{

			DataAccess.CommonQuery.CommonQuery.ExecuteProcedureWithParams(ProcName,Params);
			
		}



	}
}
