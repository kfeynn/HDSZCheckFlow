using System;
using System.Data;
using System.Data.SqlClient;

namespace HDSZCheckFlow.DataAccess.CommonQuery
{
	/// <summary>
	/// CommonQuery ��ժҪ˵����
	/// </summary>
	public class CommonQuery
	{
		public CommonQuery()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���ݴ��������strֱ���������
		/// </summary>
		/// <param name="cmdStr">�����еĲ�ѯ�ַ���</param>
		/// <returns></returns>
		public static DataSet GetDataSetByQuery(string cmdStr)
		{
			try
			{
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CommonQuery.GetDataSetByQuery",cmdStr + ex.Message);
				return null;
			}
		}

		/// <summary>
		/// ���ݴ��������strֱ���������
		/// </summary>
		/// <param name="cmdStr">�����еĲ�ѯ�ַ���</param>
		/// <returns></returns>
		public static DataSet GetDataSetByQuery(string cmdStr,string conn)
		{
			try
			{
				DBAccess dbAccess = new SQLAccess(conn);
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CommonQuery.GetDataSetByQuery",cmdStr + ex.Message);
				return null;
			}
		}

		//
		public static int ExecuteStr(string cmdStr)
		{
			
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteNonQuery (cmdStr);
			

		}


		public static int GetExecuteScalar(string cmdStr)
		{
			try
			{
				DBAccess dbAccess = new SQLAccess();
				return (int)dbAccess.ExecuteScalar(cmdStr);
			}
			catch(Exception Ex)
			{
				throw Ex;
			}


		}

		/// <summary>
		/// ���ݱ�����������ѯ ���
		/// </summary>
		/// <param name="tableName">�����ͼ</param>
		/// <param name="Filter">����,�� where </param>
		/// <returns></returns>
		public static DataSet GetDataSetByViewAndQuery(string tableName,string Filter)
		{
			try
			{
				string cmdStr = "select * from " + tableName +  Filter ; 
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr); 
			}
			catch(Exception ex)
			{
				string cmdStr = "select * from " + tableName +  Filter ; 
				Common.Log.Logger.Log("DataAccess.CommonQuery.GetDataSetByViewAndQuery",cmdStr + ex.Message);
				return null;			
			}

		}


		/// <summary>
		/// ִ�в��������Ĵ洢����
		/// </summary>
		/// <returns></returns>
		public static void  ExecuteProcedureNonParams(string ProcName)
		{
			try
			{
				SqlConnection sqlCon ; //= new SqlConnection();

				string conStr = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];//ConnectionString  xpGridConnectionString
				
				if(conStr.Length>0)
				{
					sqlCon = new SqlConnection(conStr);
				}
				else
				{
					sqlCon = new SqlConnection();
				}

				DBAccess dbAccess=new SQLAccess(sqlCon);

				dbAccess.CommandTimeout = 1200 ;

				dbAccess.ExecuteNonQuery(ProcName);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CommonQuery.ExecuteProcedureNonParams",ex.Message );
			}
		}

		
		/// <summary>
		/// ִ�д������Ĵ洢����(��������ֵ)
		/// </summary>
		/// <returns></returns>
		public static void  ExecuteProcedureWithParams(string ProcName,DBParameterCollection Params)
		{
			try
			{
//				DBParameterCollection Params=new DBParameterCollection();
//				Params.Add(Parameter.GetDBParameter("@deptCode",deptCode));
//				Params.Add(Parameter.GetDBParameter("@result",result,ParameterDirection.Output));


				DBAccess dbAccess=new SQLAccess();
				dbAccess.ExecuteNonQuery(ProcName,Params);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CommonQuery.ExecuteProcedureNonParams",ex.Message );
			}
		}


	}
}
