using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// CurrRateDAL ��ժҪ˵����
	/// </summary>
	public class CurrRateDAL
	{
		public CurrRateDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ���»��ʱ�
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		public static void updateCurrRate(int iYear,int iMonth)
		{
			string cmdStr="p_DataBase_UpdateCurrRate";
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@iYear",iYear));
			Params.Add(Parameter.GetDBParameter("@iMonth",iMonth));
	
			dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);


		}

	}
}
