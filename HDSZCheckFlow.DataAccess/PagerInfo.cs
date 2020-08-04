using System;

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// PagerInfo ��ժҪ˵����
	/// </summary>
	public class PagerInfo 
	{
		private int firstResult; // ��ʼλ��
		private int maxResults; // ��������¼��
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
