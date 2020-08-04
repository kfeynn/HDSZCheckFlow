using System;
using System.Text;

	/// <summary>
	/// PageViewState 的摘要说明。
	/// </summary>

[Serializable()]
public class PageViewState
{
	public static string S_PageViewState="S_PageViewState";
	public int PCount=0;
	public int PIndex=1;
	public int PSize=5;        
	public string SGroup="";		
	public string SSort="";    //排序字段
	public string Msg="";        
	public int RunPageCount=1000;        //总页数

	// @SortType INT,               --排序规则 1:正序asc 2:倒序desc 3:多列排序
	public int SortType=1;
	

	public static string GetUrl(System.Web.UI.StateBag _stateBag)
	{
		#region 分页
		string rtnUrl="";
		int maxPageCount=21;
		StringBuilder sb=new StringBuilder();
		try
		{
			PageViewState oPageViewState=GetPageViewState(_stateBag);
			if(oPageViewState.PCount>oPageViewState.RunPageCount)
			{
				oPageViewState.PCount=oPageViewState.RunPageCount;
			}
			sb.Append("<UL class=PagNum>");
			if(oPageViewState.PCount>1)
			{
				if(oPageViewState.PIndex>1)
				{
					//						sb.Append("<LI><a href='#' onclick=\"toPageIndex(1)\" class=backnext>首页</a></LI>");
					sb.Append("<LI><a href='#p' onclick=\"if(CheckForm()==true){__doPostBack('linkToPage','"+(oPageViewState.PIndex-1)+"');}\">上一页</a></LI>");
				}
				int sPage=0;
				int ePage=0;
				if(oPageViewState.PCount<=maxPageCount)
				{
					sPage=1;
					ePage=oPageViewState.PCount;
				}
				else
				{
					sPage=oPageViewState.PIndex-(int)maxPageCount/2;
					if(sPage<=0)
					{
						sPage=1;
						ePage=maxPageCount;
					}
					else
					{
						ePage=oPageViewState.PIndex+(int)maxPageCount/2;
						//控制翻页oPageViewState.RunPageCount
						if(ePage>oPageViewState.PCount)
						{
							sPage=oPageViewState.PCount-maxPageCount+1;
							ePage=oPageViewState.PCount;
						}
					}
				}
				for(int i=sPage;i<=ePage;i++)
				{
					if(oPageViewState.PIndex==i)
					{
						sb.Append("<LI class=now><A href=\"#p\" target=_self>"+i.ToString()+"</A> </LI>");							 
					}
					else
					{
						sb.Append("<LI><a href='#p' onclick=\"if(CheckForm()==true){__doPostBack('linkToPage','"+i.ToString()+"');}\">"+i.ToString()+"</a></LI>");							
					}
				}
				if(oPageViewState.PIndex<oPageViewState.PCount)
				{
					sb.Append("<LI><a href='#p' onclick=\"if(CheckForm()==true){__doPostBack('linkToPage','"+(oPageViewState.PIndex+1)+"');}\">下一页</a></LI>");
					//						sb.Append("<LI><a href='#' onclick=\"toPageIndex("+pageCount+")\" class=backnext>末页</a></LI>");
				}
			}
			sb.Append("</UL>");
			rtnUrl=sb.ToString();
			//labelUrl.Text=sb.ToString();
			if(sb.Length>0)
			{
				sb.Remove(0,sb.Length-1);
			}
			sb=null;
		}
		catch
		{
			sb.Remove(0,sb.Length-1);
			sb=null;
		}
			
		return rtnUrl;
		#endregion
	}

	public static void SetPageViewState(System.Web.UI.StateBag _stateBag,int _PCount,int _PIndex,int _PSize,string _SSort)		
	{
		PageViewState oPageVS=new PageViewState();
		oPageVS.PCount=_PCount;
		oPageVS.PIndex=_PIndex;
		oPageVS.PSize=_PSize;
		oPageVS.SSort=_SSort;

		PageViewState.SetPageViewState(_stateBag,oPageVS);
	}

	public static void SetPageViewState(System.Web.UI.StateBag _stateBag,PageViewState _PageViewState)
	{
		object obj=_stateBag[PageViewState.S_PageViewState];
		if(obj==null)
		{
			_stateBag.Add(PageViewState.S_PageViewState,_PageViewState);
		}
		else
		{
			_stateBag[PageViewState.S_PageViewState]=_PageViewState;
		}
	}

	public static PageViewState GetPageViewState(System.Web.UI.StateBag _stateBag)
	{
		object obj=_stateBag[PageViewState.S_PageViewState];
		if(obj!=null)
		{
			return obj as PageViewState;
		}
		else
		{
			return null;
		}
	}
}

