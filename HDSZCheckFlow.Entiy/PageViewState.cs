using System;

namespace HDSZCheckFlow.Entiy
{
	/// <summary>
	/// PageViewState 的摘要说明。
	/// </summary>
	public class PageViewState
	{
		public PageViewState()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		
//		@tblName     nvarchar(200),        ----要显示的表或多个表的连接  
//		 @fldName     nvarchar(500) = '*',    ----要显示的字段列表
//  @pageSize    int = 10,        ----每页显示的记录个数 
//		@page        int = 1,        ----要显示那一页的记录  
//@fldSort    nvarchar(200) = null,    ----排序字段列表或条件  
//       @Sort        bit = 0,        ----排序方法，1为升序，0为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')  
//		@strCondition    nvarchar(1000) = null,    ----查询条件,不需where  
//	@ID        nvarchar(150),        ----主表的主键  
//@Dist      bit = 0,          ----是否添加查询字段的 DISTINCT 默认0不添加/1添加  
//@pageCount    int = 1 output,            ----查询结果分页后的总页数  
//@Counts    int = 1 output                ----查询到的记录数  


		/// <summary>
		/// 要显示的表或多个表的连接 
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
		/// 要显示的字段列表
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
		/// 每页显示的记录个数 
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
		/// 要显示那一页的记录
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
		/// 排序字段列表或条件 
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
		/// 排序方法，1为升序，0为降序(如果是多字段排列Sort指代最后一个排序字段的排列顺序(最后一个排序字段不加排序标记)--程序传参如：' SortA Asc,SortB Desc,SortC ')  
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
		/// 查询条件,不需where  
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
		/// 主表的主键  
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
		/// 是否添加查询字段的 DISTINCT 默认0不添加/1添加  
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
		/// 查询结果分页后的总页数 
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
		/// 查询到的记录数  
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
