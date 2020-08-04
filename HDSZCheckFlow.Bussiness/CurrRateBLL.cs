using System;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CurrRateBLL 的摘要说明。
	/// </summary>
	public class CurrRateBLL
	{
		public CurrRateBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static void updateCurrRate(int iYear,int iMonth)
		{
			DataAccess.BaseInfo.CurrRateDAL.updateCurrRate(iYear,iMonth);
		}
	}
}
