// ================================================================================
// 		File: QueryAction.cs
// 		Desc: 通用查询数据操作类。
//  
// 		Called by:   
//               
// 		Auth: Andy Lee
// 		Date: 2007-04-29
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
using HDSZCheckFlow.DataAccess;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// PaginationBLL 的摘要说明。
	/// </summary>
	public class PaginationBLL
	{
		private string _Tables;				//表名
		private string _PK;					//主键字段(可以为空)
		private string _Sort;				//排序的字段(例: ID ASC或ID DESC)
		private int _PageNumber;			//页码	
		private int _PageSize;				//页尺寸
		private string _Fields;				//返回的列(例:*)
		private string _Filter;				//过滤条件(注意: 不要加 where)
		private int _PageCount;				//数据总行数
		private int _PageSumSize;			//总页数
		private int _SortType;				//排序规则 1:正序asc 2:倒序desc 3:多列排序


		//		@TableName VARCHAR(200),     --表名
		//		@PrimaryKey VARCHAR(100),    --单一主键或唯一值键

		//		@FieldList VARCHAR(2000),    --显示列名
		//		@Where VARCHAR(1000),        --查询条件 不含'where'字符
		//		@Order VARCHAR(1000),        --排序 不含'order by'字符，如id asc,userid desc，当@SortType=3时生效
		//		@SortType INT,               --排序规则 1:正序asc 2:倒序desc 3:多列排序
		//		@RecorderCount INT,          --记录总数 0:会返回总记录
		//		@PageSize INT,               --每页输出的记录数
		//		@PageIndex INT,              --当前页数
		//		@TotalCount INT OUTPUT,      --返回记录总数
		//		@TotalPageCount INT OUTPUT   --返回总页数

		public PaginationBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 表名
		/// </summary>
		public string Tables
		{
			get{return _Tables;}
			set{_Tables = value;}
		}

		/// <summary>
		/// 主键字段
		/// </summary>
		public string PK
		{
			get{return _PK;}
			set{_PK = value;}
		}

		/// <summary>
		/// 排序的字段
		/// </summary>
		public string Sort
		{
			get{return _Sort;}
			set{_Sort = value;}
		}

		/// <summary>
		/// 页码
		/// </summary>
		public int PageNumber
		{
			get{return _PageNumber;}
			set{_PageNumber = value;}
		}

		/// <summary>
		/// 页尺寸
		/// </summary>
		public int PageSize
		{
			get{return _PageSize;}
			set{_PageSize = value;}
		}

		/// <summary>
		/// 返回的列
		/// </summary>
		public string Fields
		{
			get{return _Fields;}
			set{_Fields = value;}
		}

		/// <summary>
		/// 过滤条件
		/// </summary>
		public string Filter
		{
			get{return _Filter;}
			set{_Filter = value;}
		}

		/// <summary>
		/// 过滤条件
		/// </summary>
		public int SortType
		{
			get{return _SortType;}
			set{_SortType = value;}
		}

		/// <summary>
		/// 数据总行数
		/// </summary>
		public int PageCount
		{
			get{return _PageCount;}
			
		}

		/// <summary>
		/// 总页数
		/// </summary>
		public int PageSumSize
		{
			get{return _PageSumSize;}
			
		}




		//////////////////////////////////////////
		/// sql2005存储过程 
		/// 

		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public DataSet CommonQuery1()
		{
			DataSet ds = null;
			try
			{
				ds = ObjectLoader.CommonQuery1(this._Tables, this._PK, this._Fields, this._Sort, this._Filter, this._PageSize, this._PageNumber, out this._PageSumSize, out this._PageCount);
				if (this._PageSumSize <= 0)
				{
					this._PageSumSize = 1;
				}
			}
			catch (Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}

		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public DataSet CommonQuery1(int _connectionTimeOut)
		{
			DataSet ds = null;
			try
			{
				ds = ObjectLoader.CommonQuery1(this._Tables, this._PK, this._Fields, this._Sort, this._Filter, this._PageSize, this._PageNumber, out this._PageSumSize, out this._PageCount, _connectionTimeOut);
				if (this._PageSumSize <= 0)
				{
					this._PageSumSize = 1;
				}
			}
			catch (Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}








		////////////////////////////////////////////



		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public DataSet CommonQuery()
		{
			DataSet ds = null;
			try
			{
				ds = ObjectLoader.CommonQuery(this._Tables,this._PK,this._Fields,this._Sort,this._Filter,this._PageSize,this._PageNumber,this._SortType,out this._PageSumSize,out this._PageCount); 
				if(this._PageSumSize <= 0 )
				{
					this._PageSumSize = 1;
				}
			}
			catch(Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}
	
		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public DataSet CommonQuery(int _connectionTimeOut)
		{
			DataSet ds = null;
			try
			{
				ds = ObjectLoader.CommonQuery(this._Tables,this._PK,this._Fields,this._Sort,this._Filter,this._PageSize,this._PageNumber,this._SortType,out this._PageSumSize,out this._PageCount,_connectionTimeOut); 
				if(this._PageSumSize <= 0 )
				{
					this._PageSumSize = 1;
				}
			}
			catch(Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}

		/// <summary>
		/// 查询
		/// </summary>
		/// <returns></returns>
		public DataSet CommonQuery(string conStr)
		{
			DataSet ds = null;
			try
			{
				ds = ObjectLoader.CommonQuery(this._Tables,this._PK,this._Fields,this._Sort,this._Filter,this._PageSize,this._PageNumber,this._SortType,out this._PageSumSize,out this._PageCount,conStr); 
				if(this._PageSumSize <= 0 )
				{
					this._PageSumSize = 1;
				}
			}
			catch(Exception Ex)
			{
				throw Ex;
			}

			return ds;
		}

	
	}
}
