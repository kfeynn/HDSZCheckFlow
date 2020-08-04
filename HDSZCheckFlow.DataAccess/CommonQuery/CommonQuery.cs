using System;
using System.Data;
using System.Data.SqlClient;

namespace HDSZCheckFlow.DataAccess.CommonQuery
{
	/// <summary>
	/// CommonQuery 的摘要说明。
	/// </summary>
	public class CommonQuery
	{
		public CommonQuery()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据传入近来的str直接运行输出
		/// </summary>
		/// <param name="cmdStr">可运行的查询字符串</param>
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
		/// 根据传入近来的str直接运行输出
		/// </summary>
		/// <param name="cmdStr">可运行的查询字符串</param>
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
		/// 根据表名和条件查询 输出
		/// </summary>
		/// <param name="tableName">表或视图</param>
		/// <param name="Filter">条件,带 where </param>
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
		/// 执行不带参数的存储过程
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
		/// 执行带参数的存储过程(不带返回值)
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
