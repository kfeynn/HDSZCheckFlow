using System;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CurrRateBLL ��ժҪ˵����
	/// </summary>
	public class CurrRateBLL
	{
		public CurrRateBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static void updateCurrRate(int iYear,int iMonth)
		{
			DataAccess.BaseInfo.CurrRateDAL.updateCurrRate(iYear,iMonth);
		}
	}
}
