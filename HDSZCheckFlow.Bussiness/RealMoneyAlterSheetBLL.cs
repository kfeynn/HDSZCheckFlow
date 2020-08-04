using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// RealMoneyAlterSheetBLL 的摘要说明。
	/// </summary>
	public class RealMoneyAlterSheetBLL
	{
		public RealMoneyAlterSheetBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataSet GetRealMoneyAlterByApplyHeadPk(int ApplyHeadPk)
		{
			string cmdStr = " select * from RealMoneyAlterSheet where AlteredSheetHead_pk= " + ApplyHeadPk + "" ;
			return DataAccess.CommonQuery.CommonQuery.GetDataSetByQuery(cmdStr);
		}

	}
}
