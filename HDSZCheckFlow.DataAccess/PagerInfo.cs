using System;

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// PagerInfo 的摘要说明。
	/// </summary>
	public class PagerInfo 
	{
		private int firstResult; // 起始位置
		private int maxResults; // 返回最大记录数
		public PagerInfo( int firstResult, int maxResults ) 
		{
			this.firstResult = firstResult;
			this.maxResults = maxResults;
		}
		public int FirstResult 
		{
			get { return firstResult; }
		}
		public int MaxResults 
		{
			get { return maxResults; }
		}
	}

}
