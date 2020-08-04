// ================================================================================
// 		File: ObjectLoader.cs
// 		Desc: 数据查询操作类。
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
	/// ObjectLoader 的摘要说明。
	/// </summary>
	public class ObjectLoader
	{
		/// <summary>
		/// 获取对象集合
		/// </summary>
		/// <param name="crit"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static IList Find(ICriterion crit, Type type) 
		{
			return Find(crit, type, null);
		}

		/// <summary>
		/// 获取对象集合
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
		/// 获取对象集合
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
		/// 获取对象集合
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
		/// 获取数据集合
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
		/// 获取数据集合
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
		/// 获取数据集合
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
		/// 获取数据集合
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
		/// 获取Scalar的值
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
		/// 获取Scalar的值
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
		/// 执行SQL命令
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
		/// 通用查询函数
		/// </summary>
		/// <param name="sTables">表名</param>
		/// <param name="sPK">主键字段</param>
		/// <param name="sSort">排序的字段</param>
		/// <param name="iPageNumber">页码</param>
		/// <param name="iPageSize">页尺寸</param>
		/// <param name="sFields">返回的列</param>
		/// <param name="sFilter">过滤条件(注意: 不要加 where)</param>
		/// <param name="sGroup">分组条件(注意:GROUP BY)</param>
		/// <param name="iPageCount">数据总行数</param>
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
/// sql2005 分页存储过程 ，不需要标示唯一列



		/// <summary>
		/// 通用查询函数
		/// </summary>
		/// <param name="sTables">表名</param>
		/// <param name="sPK">主键字段</param>
		/// <param name="sSort">排序的字段</param>
		/// <param name="iPageNumber">页码</param>
		/// <param name="iPageSize">页尺寸</param>
		/// <param name="sFields">返回的列</param>
		/// <param name="sFilter">过滤条件(注意: 不要加 where)</param>
		/// <param name="sGroup">分组条件(注意:GROUP BY)</param>
		/// <param name="iPageCount">数据总行数</param>
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
		/// 通用查询函数
		/// </summary>
		/// <param name="sTables">表名</param>
		/// <param name="sPK">主键字段</param>
		/// <param name="sSort">排序的字段</param>
		/// <param name="iPageNumber">页码</param>
		/// <param name="iPageSize">页尺寸</param>
		/// <param name="sFields">返回的列</param>
		/// <param name="sFilter">过滤条件(注意: 不要加 where)</param>
		/// <param name="sGroup">分组条件(注意:GROUP BY)</param>
		/// <param name="iPageCount">数据总行数</param>
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
		/// 通用查询函数
		/// </summary>
		/// <param name="sTables">表名</param>
		/// <param name="sPK">主键字段</param>
		/// <param name="sSort">排序的字段</param>
		/// <param name="iPageNumber">页码</param>
		/// <param name="iPageSize">页尺寸</param>
		/// <param name="sFields">返回的列</param>
		/// <param name="sFilter">过滤条件(注意: 不要加 where)</param>
		/// <param name="sGroup">分组条件(注意:GROUP BY)</param>
		/// <param name="iPageCount">数据总行数</param>
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
		/// 通用查询函数
		/// </summary>
		/// <param name="sTables">表名</param>
		/// <param name="sPK">主键字段</param>
		/// <param name="sSort">排序的字段</param>
		/// <param name="iPageNumber">页码</param>
		/// <param name="iPageSize">页尺寸</param>
		/// <param name="sFields">返回的列</param>
		/// <param name="sFilter">过滤条件(注意: 不要加 where)</param>
		/// <param name="sGroup">分组条件(注意:GROUP BY)</param>
		/// <param name="iPageCount">数据总行数</param>
		/// <returns></returns>
		public static DataSet CommonQuery(string sTables,string sPK,string sFields,string sOrderField,string sSqlWhere,int iPageSize,int ipageIndex,int sSortType,out int iTotalPage,out int iTotalRecord,string conStr)
		{
			DataSet ds = null;
			iTotalPage = 0;
			iTotalRecord = 0;
			try
			{
				//    @TableName VARCHAR(200),     --表名
				//    @FieldList VARCHAR(2000),    --显示列名
				//    @PrimaryKey VARCHAR(100),    --单一主键或唯一值键
				//    @Where VARCHAR(1000),        --查询条件 不含'where'字符
				//    @Order VARCHAR(1000),        --排序 不含'order by'字符，如id asc,userid desc，当@SortType=3时生效
				//    @SortType INT,               --排序规则 1:正序asc 2:倒序desc 3:多列排序
				//    @RecorderCount INT,          --记录总数 0:会返回总记录
				//    @PageSize INT,               --每页输出的记录数
				//    @PageIndex INT,              --当前页数
				//    @TotalCount INT OUTPUT,      --返回记录总数
				//    @TotalPageCount INT OUTPUT   --返回总页数
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
