// ================================================================================
// 		File: QueryAction.cs
// 		Desc: ͨ�ò�ѯ���ݲ����ࡣ
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
	/// PaginationBLL ��ժҪ˵����
	/// </summary>
	public class PaginationBLL
	{
		private string _Tables;				//����
		private string _PK;					//�����ֶ�(����Ϊ��)
		private string _Sort;				//������ֶ�(��: ID ASC��ID DESC)
		private int _PageNumber;			//ҳ��	
		private int _PageSize;				//ҳ�ߴ�
		private string _Fields;				//���ص���(��:*)
		private string _Filter;				//��������(ע��: ��Ҫ�� where)
		private int _PageCount;				//����������
		private int _PageSumSize;			//��ҳ��
		private int _SortType;				//������� 1:����asc 2:����desc 3:��������


		//		@TableName VARCHAR(200),     --����
		//		@PrimaryKey VARCHAR(100),    --��һ������Ψһֵ��

		//		@FieldList VARCHAR(2000),    --��ʾ����
		//		@Where VARCHAR(1000),        --��ѯ���� ����'where'�ַ�
		//		@Order VARCHAR(1000),        --���� ����'order by'�ַ�����id asc,userid desc����@SortType=3ʱ��Ч
		//		@SortType INT,               --������� 1:����asc 2:����desc 3:��������
		//		@RecorderCount INT,          --��¼���� 0:�᷵���ܼ�¼
		//		@PageSize INT,               --ÿҳ����ļ�¼��
		//		@PageIndex INT,              --��ǰҳ��
		//		@TotalCount INT OUTPUT,      --���ؼ�¼����
		//		@TotalPageCount INT OUTPUT   --������ҳ��

		public PaginationBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����
		/// </summary>
		public string Tables
		{
			get{return _Tables;}
			set{_Tables = value;}
		}

		/// <summary>
		/// �����ֶ�
		/// </summary>
		public string PK
		{
			get{return _PK;}
			set{_PK = value;}
		}

		/// <summary>
		/// ������ֶ�
		/// </summary>
		public string Sort
		{
			get{return _Sort;}
			set{_Sort = value;}
		}

		/// <summary>
		/// ҳ��
		/// </summary>
		public int PageNumber
		{
			get{return _PageNumber;}
			set{_PageNumber = value;}
		}

		/// <summary>
		/// ҳ�ߴ�
		/// </summary>
		public int PageSize
		{
			get{return _PageSize;}
			set{_PageSize = value;}
		}

		/// <summary>
		/// ���ص���
		/// </summary>
		public string Fields
		{
			get{return _Fields;}
			set{_Fields = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public string Filter
		{
			get{return _Filter;}
			set{_Filter = value;}
		}

		/// <summary>
		/// ��������
		/// </summary>
		public int SortType
		{
			get{return _SortType;}
			set{_SortType = value;}
		}

		/// <summary>
		/// ����������
		/// </summary>
		public int PageCount
		{
			get{return _PageCount;}
			
		}

		/// <summary>
		/// ��ҳ��
		/// </summary>
		public int PageSumSize
		{
			get{return _PageSumSize;}
			
		}




		//////////////////////////////////////////
		/// sql2005�洢���� 
		/// 

		/// <summary>
		/// ��ѯ
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
		/// ��ѯ
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
		/// ��ѯ
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
		/// ��ѯ
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
		/// ��ѯ
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
