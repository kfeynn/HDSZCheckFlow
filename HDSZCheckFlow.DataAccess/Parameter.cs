// ================================================================================
// 		File: Parameter.cs
// 		Desc: 参数操作类。
//  
// 		Called by:   
//               
// 		Auth: Andy Lee
// 		Date: 2007-04-24
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2007 FCKJ Corporation
// ================================================================================
using System;
using System.Data;  
using HDSZCheckFlow.Common.Config;
 
namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// Parameter 的摘要说明。
	/// </summary>
	public class Parameter
	{
		public Parameter()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 生成存储过程的参数
		/// </summary>
		/// <param name="sName">字段名称</param>
		/// <param name="sValue">字段值</param>
		/// <returns></returns>
		public static IDbDataParameter GetDBParameter(string sName,object sValue)
		{
			return GetDBParameter(sName,sValue,ParameterDirection.Input);
		}

		/// <summary>
		/// 生成存储过程的参数
		/// </summary>
		/// <param name="sName">字段名称</param>
		/// <param name="sValue">字段值</param>
		/// <param name="direction">输出类型</param>
		/// <returns></returns>
		public static IDbDataParameter GetDBParameter(string sName,object sValue,ParameterDirection direction)
		{
			DBAccess dbAccess = null;
			IDbDataParameter param = null;
			
			try
			{				
				dbAccess = new SQLAccess();
				dbAccess.BeginTransaction();
				param = dbAccess.CreateParameter(sName,sValue);
				param.Direction = direction;
				dbAccess.CommitTransaction();
			}
			catch(Exception Ex)
			{
				dbAccess.RollbackTransaction();
				throw Ex;
			}
			
			return param;
		}
		public static IDbDataParameter GetDBParameter(string sName,DbType dbType,object sValue,ParameterDirection direction)
		{
			DBAccess dbAccess = null;
			IDbDataParameter param = null;
			
			try
			{				
				dbAccess = new SQLAccess();
				dbAccess.BeginTransaction();
				param = dbAccess.CreateParameter(sName,sValue);
				param.Direction = direction;
				param.DbType=dbType;
				dbAccess.CommitTransaction();
			}
			catch(Exception Ex)
			{
				dbAccess.RollbackTransaction();
				throw Ex;
			}
			
			return param;
		}
	}
}
