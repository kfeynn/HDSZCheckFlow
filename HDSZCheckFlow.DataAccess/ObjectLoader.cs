// ================================================================================
// 		File: ObjectLoader.cs
// 		Desc: ���ݲ�ѯ�����ࡣ
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
using NHibernate;
using NHibernate.Expression;
using System.Collections;
using System.Data; 

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// ObjectLoader ��ժҪ˵����
	/// </summary>
	public class ObjectLoader
	{
		/// <summary>
		/// ��ȡ���󼯺�
		/// </summary>
		/// <param name="crit"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IList Find(ICriterion crit, Type type) 
		{
			return Find(crit, type, null);
		}

		/// <summary>
		/// ��ȡ���󼯺�
		/// </summary>
		/// <param name="crit"></param>
		/// <param name="type"></param>
		/// <param name="pi"></param>
		/// <returns></returns>
		public static IList Find(ICriterion crit, Type type, PagerInfo pi) 
		{
			ISession s = Sessions.GetSession();
			try 
			{
				
				ICriteria c = s.CreateCriteria(type); 
				if (crit != null ) c.Add(crit);
				if (pi != null ) 
				{
					c.SetFirstResult(pi.FirstResult);
					c.SetMaxResults(pi.MaxResults);
				}
				return c.List();
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			finally 
			{
				s.Close();
			}
		}
		/// <summary>
		/// ��ȡ���󼯺�
		/// </summary>
		/// <param name="query"></param>
		/// <param name="paramInfos"></param>
		/// <param name="Entity"></param>
		/// <returns></returns>
		public static IList Find( string query, ICollection paramInfos ,Type Entity) 
		{
			return Find( query, paramInfos,Entity, null );
		}
		/// <summary>
		/// ��ȡ���󼯺�
		/// </summary>
		/// <param name="query"></param>
		/// <param name="paramInfos"></param>
		/// <param name="Entity"></param>
		/// <param name="pi"></param>
		/// <returns></returns>
		public static IList Find(string query, ICollection paramInfos,Type Entity, PagerInfo pi) 
		{
			ISession s = Sessions.GetSession();
			try 
			{
				IQuery q = s.CreateQuery( query );
				if ( paramInfos != null ) 
				{
					foreach (ParamInfo info in paramInfos) 
					{
						if (info.Value is ICollection)
							q.SetParameterList(info.Name, (ICollection)info.Value, info.Type);
						else
							q.SetParameter(info.Name, info.Value, info.Type);
					} 
				}
				if (pi != null ) 
				{
					q.SetFirstResult( pi.FirstResult );
					q.SetMaxResults( pi.MaxResults );
				}
				return q.List();
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			finally 
			{
				s.Close();
			}
		}

		/// <summary>
		/// ��ȡ���ݼ���
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static DataSet Find(string query)
		{
			DBAccess dbAccess = null;
			DataSet  ds = null;
			try
			{
				dbAccess = new SQLAccess();
				ds = dbAccess.ExecuteDataset(query);
				
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return ds;
		}
		/// <summary>
		/// ��ȡ���ݼ���
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="colParameter"></param>
		/// <returns></returns>
		public static DataSet Find(string spName,DBParameterCollection colParameter)
		{
			DBAccess dbAccess = null;
			DataSet  ds = null;
			try
			{
				dbAccess = new SQLAccess();
				ds = dbAccess.ExecuteDataset(spName,colParameter);
				
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return ds;
		}/// <summary>
		/// ��ȡ���ݼ���
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="colParameter"></param>
		/// <returns></returns>
		public static DataSet Find(string spName,DBParameterCollection colParameter,int _connectionTimeOut)
		{
			DBAccess dbAccess = null;
			DataSet  ds = null;
			try
			{
				dbAccess = new SQLAccess();
				dbAccess.CommandTimeout=_connectionTimeOut;
				ds = dbAccess.ExecuteDataset(spName,colParameter);
				
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return ds;
		}
		/// <summary>
		/// ��ȡ���ݼ���
		/// </summary>
		/// <param name="spName"></param>
		/// <param name="colParameter"></param>
		/// <returns></returns>
		public static DataSet Find(string spName,DBParameterCollection colParameter,string conStr)
		{
			DBAccess dbAccess = null;
			DataSet  ds = null;
			try
			{
				dbAccess = new SQLAccess(conStr);
				ds = dbAccess.ExecuteDataset(spName,colParameter);
				
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return ds;
		}
		/// <summary>
		/// ��ȡScalar��ֵ
		/// </summary>
		/// <param name="commandText"></param>
		/// <returns></returns>
		public static object GetScalar(string commandText)
		{
			DBAccess dbAccess = null;
			object obj = null;
			try
			{
				dbAccess = new SQLAccess();
				obj = dbAccess.ExecuteScalar(commandText);
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return obj;
		}

		/// <summary>
		/// ��ȡScalar��ֵ
		/// </summary>
		/// <param name="commandText"></param>
		/// <returns></returns>
		public static object GetScalar(string commandText,DBParameterCollection colParameters)
		{
			DBAccess dbAccess = null;
			object obj = null;
			try
			{
				dbAccess = new SQLAccess();
				obj = dbAccess.ExecuteScalar(commandText,CommandType.StoredProcedure,colParameters);
			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			return obj;
		}
		/// <summary>
		/// ִ��SQL����
		/// </summary>
		/// <param name="commandText"></param>
		/// <returns></returns>
		public static int ExecuteNonQuery(string commandText)
		{
			DBAccess dbAccess = null;
			int count;
			try
			{
				dbAccess = new SQLAccess(); 
				dbAccess.BeginTransaction(); 
				count = dbAccess.ExecuteNonQuery(commandText); 
				dbAccess.CommitTransaction(); 
			}
			catch(Exception Ex)
			{
				dbAccess.RollbackTransaction();
				throw Ex;
			}
			return count;
		}

		/// <summary>
		/// ͨ�ò�ѯ����
		/// </summary>
		/// <param name="sTables">����</param>
		/// <param name="sPK">�����ֶ�</param>
		/// <param name="sSort">������ֶ�</param>
		/// <param name="iPageNumber">ҳ��</param>
		/// <param name="iPageSize">ҳ�ߴ�</param>
		/// <param name="sFields">���ص���</param>
		/// <param name="sFilter">��������(ע��: ��Ҫ�� where)</param>
		/// <param name="sGroup">��������(ע��:GROUP BY)</param>
		/// <param name="iPageCount">����������</param>
		/// <returns></returns>
		public static DataSet CommonQuery(string sTables,string sPK,string sFields,string sOrderField,string sSqlWhere,int iPageSize,int ipageIndex,int sSortType,out int iTotalPage,out int iTotalRecord)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				DBParameterCollection Params=new DBParameterCollection();
				
				Params.Add(Parameter.GetDBParameter("@TableName",sTables));
				Params.Add(Parameter.GetDBParameter("@FieldList",sFields));
				if(sOrderField == null || sOrderField.Trim() =="")
				{
					Params.Add(Parameter.GetDBParameter("@Order",sPK));
				}
				else
				{
					Params.Add(Parameter.GetDBParameter("@Order",sOrderField));
				}
				Params.Add(Parameter.GetDBParameter("@PrimaryKey",sPK));
				Params.Add(Parameter.GetDBParameter("@SortType",sSortType));
				Params.Add(Parameter.GetDBParameter("@RecorderCount",0));
				Params.Add(Parameter.GetDBParameter("@Where",sSqlWhere));
				Params.Add(Parameter.GetDBParameter("@PageSize",iPageSize));
				Params.Add(Parameter.GetDBParameter("@PageIndex",ipageIndex));

				Params.Add(Parameter.GetDBParameter("@TotalPageCount",iTotalPage,ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@TotalCount",iTotalRecord,ParameterDirection.Output));
				
				ds = ObjectLoader.Find("P_viewPage",Params);   //p_Paging_RowCount
				
				iTotalPage = Convert.ToInt32(Params[Params.Count-2].Value);
				iTotalRecord = Convert.ToInt32(Params[Params.Count-1].Value);

			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			
			return ds;
		}





//////////////////////////////////////////////////////////
/// sql2005 ��ҳ�洢���� ������Ҫ��ʾΨһ��



		/// <summary>
		/// ͨ�ò�ѯ����
		/// </summary>
		/// <param name="sTables">����</param>
		/// <param name="sPK">�����ֶ�</param>
		/// <param name="sSort">������ֶ�</param>
		/// <param name="iPageNumber">ҳ��</param>
		/// <param name="iPageSize">ҳ�ߴ�</param>
		/// <param name="sFields">���ص���</param>
		/// <param name="sFilter">��������(ע��: ��Ҫ�� where)</param>
		/// <param name="sGroup">��������(ע��:GROUP BY)</param>
		/// <param name="iPageCount">����������</param>
		/// <returns></returns>
		public static DataSet CommonQuery1(string sTables, string sPK, string sFields, string sOrderField, string sSqlWhere, int iPageSize, int ipageIndex, out int iTotalPage, out int iTotalRecord)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				DBParameterCollection Params = new DBParameterCollection();

				Params.Add(Parameter.GetDBParameter("@TableName", sTables));
				Params.Add(Parameter.GetDBParameter("@Fields", sFields));
				if (sOrderField == null || sOrderField.Trim() == "")
				{
					Params.Add(Parameter.GetDBParameter("@OrderField", sPK));
				}
				else
				{
					Params.Add(Parameter.GetDBParameter("@OrderField", sOrderField));
				}
				Params.Add(Parameter.GetDBParameter("@sqlWhere", sSqlWhere));
				Params.Add(Parameter.GetDBParameter("@pageSize", iPageSize));
				Params.Add(Parameter.GetDBParameter("@pageIndex", ipageIndex));

				Params.Add(Parameter.GetDBParameter("@TotalPage", iTotalPage, ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@TotalRecord", iTotalRecord, ParameterDirection.Output));

				ds = ObjectLoader.Find("p_Paging_RowCount", Params);

				iTotalPage = Convert.ToInt32(Params[Params.Count - 2].Value);
				iTotalRecord = Convert.ToInt32(Params[Params.Count - 1].Value);

			}
			catch (Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}

		/// <summary>
		/// ͨ�ò�ѯ����
		/// </summary>
		/// <param name="sTables">����</param>
		/// <param name="sPK">�����ֶ�</param>
		/// <param name="sSort">������ֶ�</param>
		/// <param name="iPageNumber">ҳ��</param>
		/// <param name="iPageSize">ҳ�ߴ�</param>
		/// <param name="sFields">���ص���</param>
		/// <param name="sFilter">��������(ע��: ��Ҫ�� where)</param>
		/// <param name="sGroup">��������(ע��:GROUP BY)</param>
		/// <param name="iPageCount">����������</param>
		/// <returns></returns>
		public static DataSet CommonQuery1(string sTables, string sPK, string sFields, string sOrderField, string sSqlWhere, int iPageSize, int ipageIndex, out int iTotalPage, out int iTotalRecord, int _connectionTimeOut)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				DBParameterCollection Params = new DBParameterCollection();

				Params.Add(Parameter.GetDBParameter("@TableName", sTables));
				Params.Add(Parameter.GetDBParameter("@Fields", sFields));
				if (sOrderField == null || sOrderField.Trim() == "")
				{
					Params.Add(Parameter.GetDBParameter("@OrderField", sPK));
				}
				else
				{
					Params.Add(Parameter.GetDBParameter("@OrderField", sOrderField));
				}
				Params.Add(Parameter.GetDBParameter("@sqlWhere", sSqlWhere));
				Params.Add(Parameter.GetDBParameter("@pageSize", iPageSize));
				Params.Add(Parameter.GetDBParameter("@pageIndex", ipageIndex));

				Params.Add(Parameter.GetDBParameter("@TotalPage", iTotalPage, ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@TotalRecord", iTotalRecord, ParameterDirection.Output));

				ds = ObjectLoader.Find("p_Paging_RowCount", Params, _connectionTimeOut);

				iTotalPage = Convert.ToInt32(Params[Params.Count - 2].Value);
				iTotalRecord = Convert.ToInt32(Params[Params.Count - 1].Value);

			}
			catch (Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}

















///////////////////////////////////////































		/// <summary>
		/// ͨ�ò�ѯ����
		/// </summary>
		/// <param name="sTables">����</param>
		/// <param name="sPK">�����ֶ�</param>
		/// <param name="sSort">������ֶ�</param>
		/// <param name="iPageNumber">ҳ��</param>
		/// <param name="iPageSize">ҳ�ߴ�</param>
		/// <param name="sFields">���ص���</param>
		/// <param name="sFilter">��������(ע��: ��Ҫ�� where)</param>
		/// <param name="sGroup">��������(ע��:GROUP BY)</param>
		/// <param name="iPageCount">����������</param>
		/// <returns></returns>
		public static DataSet CommonQuery(string sTables,string sPK,string sFields,string sOrderField,string sSqlWhere,int iPageSize,int ipageIndex,int sSortType,out int iTotalPage,out int iTotalRecord,int _connectionTimeOut)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				DBParameterCollection Params=new DBParameterCollection();
				
				Params.Add(Parameter.GetDBParameter("@TableName",sTables));
				Params.Add(Parameter.GetDBParameter("@FieldList",sFields));
				if(sOrderField == null || sOrderField.Trim() =="")
				{
					Params.Add(Parameter.GetDBParameter("@Order",sPK));
				}
				else
				{
					Params.Add(Parameter.GetDBParameter("@Order",sOrderField));
				}
				Params.Add(Parameter.GetDBParameter("@PrimaryKey",sPK));
				Params.Add(Parameter.GetDBParameter("@SortType",sSortType));
				Params.Add(Parameter.GetDBParameter("@RecorderCount",0));
				Params.Add(Parameter.GetDBParameter("@Where",sSqlWhere));
				Params.Add(Parameter.GetDBParameter("@PageSize",iPageSize));
				Params.Add(Parameter.GetDBParameter("@PageIndex",ipageIndex));

				Params.Add(Parameter.GetDBParameter("@TotalPageCount",iTotalPage,ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@TotalCount",iTotalRecord,ParameterDirection.Output));
				
				ds = ObjectLoader.Find("P_viewPage",Params,_connectionTimeOut); 
				
				iTotalPage = Convert.ToInt32(Params[Params.Count-2].Value);
				iTotalRecord = Convert.ToInt32(Params[Params.Count-1].Value);

			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			
			return ds;
		}

		/// <summary>
		/// ͨ�ò�ѯ����
		/// </summary>
		/// <param name="sTables">����</param>
		/// <param name="sPK">�����ֶ�</param>
		/// <param name="sSort">������ֶ�</param>
		/// <param name="iPageNumber">ҳ��</param>
		/// <param name="iPageSize">ҳ�ߴ�</param>
		/// <param name="sFields">���ص���</param>
		/// <param name="sFilter">��������(ע��: ��Ҫ�� where)</param>
		/// <param name="sGroup">��������(ע��:GROUP BY)</param>
		/// <param name="iPageCount">����������</param>
		/// <returns></returns>
		public static DataSet CommonQuery(string sTables,string sPK,string sFields,string sOrderField,string sSqlWhere,int iPageSize,int ipageIndex,int sSortType,out int iTotalPage,out int iTotalRecord,string conStr)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				//    @TableName VARCHAR(200),     --����
				//    @FieldList VARCHAR(2000),    --��ʾ����
				//    @PrimaryKey VARCHAR(100),    --��һ������Ψһֵ��
				//    @Where VARCHAR(1000),        --��ѯ���� ����'where'�ַ�
				//    @Order VARCHAR(1000),        --���� ����'order by'�ַ�����id asc,userid desc����@SortType=3ʱ��Ч
				//    @SortType INT,               --������� 1:����asc 2:����desc 3:��������
				//    @RecorderCount INT,          --��¼���� 0:�᷵���ܼ�¼
				//    @PageSize INT,               --ÿҳ����ļ�¼��
				//    @PageIndex INT,              --��ǰҳ��
				//    @TotalCount INT OUTPUT,      --���ؼ�¼����
				//    @TotalPageCount INT OUTPUT   --������ҳ��
				DBParameterCollection Params=new DBParameterCollection();
				
				Params.Add(Parameter.GetDBParameter("@TableName",sTables));
				Params.Add(Parameter.GetDBParameter("@FieldList",sFields));
				if(sOrderField == null || sOrderField.Trim() =="")
				{
					Params.Add(Parameter.GetDBParameter("@Order",sPK));
				}
				else
				{
					Params.Add(Parameter.GetDBParameter("@Order",sOrderField));
				}
				Params.Add(Parameter.GetDBParameter("@PrimaryKey",sPK));
				Params.Add(Parameter.GetDBParameter("@SortType",sSortType));
				Params.Add(Parameter.GetDBParameter("@RecorderCount",0));
				Params.Add(Parameter.GetDBParameter("@Where",sSqlWhere));
				Params.Add(Parameter.GetDBParameter("@PageSize",iPageSize));
				Params.Add(Parameter.GetDBParameter("@PageIndex",ipageIndex));

				Params.Add(Parameter.GetDBParameter("@TotalPageCount",iTotalPage,ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@TotalCount",iTotalRecord,ParameterDirection.Output));
				
				ds = ObjectLoader.Find("P_viewPage",Params,conStr);   
				
				iTotalPage = Convert.ToInt32(Params[Params.Count-2].Value);
				iTotalRecord = Convert.ToInt32(Params[Params.Count-1].Value);

			}
			catch(Exception Ex)
			{
				throw Ex;
			}
			
			return ds;
		}





	}
}
