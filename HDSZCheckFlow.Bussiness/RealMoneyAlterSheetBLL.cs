using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// RealMoneyAlterSheetBLL ��ժҪ˵����
	/// </summary>
	public class RealMoneyAlterSheetBLL
	{
		public RealMoneyAlterSheetBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static DataSet GetRealMoneyAlterByApplyHeadPk(int ApplyHeadPk)
		{
			string cmdStr = " select * from RealMoneyAlterSheet where AlteredSheetHead_pk= " + ApplyHeadPk + "" ;
			return DataAccess.CommonQuery.CommonQuery.GetDataSetByQuery(cmdStr);
		}

	}
}
