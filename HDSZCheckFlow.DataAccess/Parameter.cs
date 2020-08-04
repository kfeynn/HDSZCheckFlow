// ================================================================================
// 		File: Parameter.cs
// 		Desc: ���������ࡣ
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
	/// Parameter ��ժҪ˵����
	/// </summary>
	public class Parameter
	{
		public Parameter()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���ɴ洢���̵Ĳ���
		/// </summary>
		/// <param name="sName">�ֶ�����</param>
		/// <param name="sValue">�ֶ�ֵ</param>
		/// <returns></returns>
		public static IDbDataParameter GetDBParameter(string sName,object sValue)
		{
			return GetDBParameter(sName,sValue,ParameterDirection.Input);
		}

		/// <summary>
		/// ���ɴ洢���̵Ĳ���
		/// </summary>
		/// <param name="sName">�ֶ�����</param>
		/// <param name="sValue">�ֶ�ֵ</param>
		/// <param name="direction">�������</param>
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
