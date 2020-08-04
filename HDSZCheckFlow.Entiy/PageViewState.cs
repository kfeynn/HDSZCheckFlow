using System;

namespace HDSZCheckFlow.Entiy
{
	/// <summary>
	/// PageViewState ��ժҪ˵����
	/// </summary>
	public class PageViewState
	{
		public PageViewState()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		
//		@tblName     nvarchar(200),        ----Ҫ��ʾ�ı�����������  
//		 @fldName     nvarchar(500) = '*',    ----Ҫ��ʾ���ֶ��б�
//  @pageSize    int = 10,        ----ÿҳ��ʾ�ļ�¼���� 
//		@page        int = 1,        ----Ҫ��ʾ��һҳ�ļ�¼  
//@fldSort    nvarchar(200) = null,    ----�����ֶ��б������  
//       @Sort        bit = 0,        ----���򷽷���1Ϊ����0Ϊ����(����Ƕ��ֶ�����Sortָ�����һ�������ֶε�����˳��(���һ�������ֶβ���������)--���򴫲��磺' SortA Asc,SortB Desc,SortC ')  
//		@strCondition    nvarchar(1000) = null,    ----��ѯ����,����where  
//	@ID        nvarchar(150),        ----���������  
//@Dist      bit = 0,          ----�Ƿ���Ӳ�ѯ�ֶε� DISTINCT Ĭ��0�����/1���  
//@pageCount    int = 1 output,            ----��ѯ�����ҳ�����ҳ��  
//@Counts    int = 1 output                ----��ѯ���ļ�¼��  


		/// <summary>
		/// Ҫ��ʾ�ı����������� 
		/// </summary>
		 private string _tblName;
	
		public string TblName
		{
			get
			{
				return this._tblName;
			}
			set
			{
				this._tblName = value;
			}
		}


		/// <summary>
		/// Ҫ��ʾ���ֶ��б�
		/// </summary>
		private string _fldName;
		
		public string FldName
		{
			get
			{
				return this._fldName;
			}
			set
			{
				this._fldName = value;
			}
		}

		
		/// <summary>
		/// ÿҳ��ʾ�ļ�¼���� 
		/// </summary>
		private int _pageSize;

		public int PageSize
		{
			get
			{
				return this._pageSize;
			}
			set
			{
				this._pageSize = value;
			}
		}


		/// <summary>
		/// Ҫ��ʾ��һҳ�ļ�¼
		/// </summary>
		private int _page;
	
		public int Page
		{
			get
			{
				return this._page;
			}
			set
			{
				this._page = value;
			}
		}
	

		/// <summary>
		/// �����ֶ��б������ 
		/// </summary>
		private string _fldSort;
	
		public string FldSort
		{
			get
			{
				return this._fldSort;
			}
			set
			{
				this._fldSort = value;
			}
		}


		/// <summary>
		/// ���򷽷���1Ϊ����0Ϊ����(����Ƕ��ֶ�����Sortָ�����һ�������ֶε�����˳��(���һ�������ֶβ���������)--���򴫲��磺' SortA Asc,SortB Desc,SortC ')  
		/// </summary>
		private int _sort;
	
		public int Sort
		{
			get
			{
				return this._sort;
			}
			set
			{
				this._sort = value;
			}
		}


		/// <summary>
		/// ��ѯ����,����where  
		/// </summary>
		private string _strCondition;
	
		public string StrCondition
		{
			get
			{
				return this._strCondition;
			}
			set
			{
				this._strCondition = value;
			}
		}


		/// <summary>
		/// ���������  
		/// </summary>
		private string _iD;
		
		public string ID
		{
			get
			{
				return   this._iD.ToString();
			}
			set
			{
				this._iD = value;
			}
		}
		

		/// <summary>
		/// �Ƿ���Ӳ�ѯ�ֶε� DISTINCT Ĭ��0�����/1���  
		/// </summary>
		private int _dist;
		
		public int Dist
		{
			get
			{
				return this._dist;
			}
			set
			{
				this._dist = value;
			}

		}


		/// <summary>
		/// ��ѯ�����ҳ�����ҳ�� 
		/// </summary>
		private int _pageCount;

		public int PageCount
		{
			get
			{
				return this._pageCount;
			}
			set
			{
				this._pageCount = value;
			}

		}

		
		/// <summary>
		/// ��ѯ���ļ�¼��  
		/// </summary>
		private int _counts;

		public int Counts
		{
			get
			{
				return this._counts;
			}
			set
			{
				this._counts = value;
			}

		}
		

	}
}
