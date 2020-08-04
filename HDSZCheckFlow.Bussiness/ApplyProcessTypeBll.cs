using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplyProcessTypeBll 的摘要说明。
	/// </summary>
	public class ApplyProcessTypeBll
	{
		public ApplyProcessTypeBll()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static DataTable   GetProssType()
		{
			return DataAccess.BaseInfo.ApplyProcessTypeDAL.getProssType();
		}
		public static DataTable   GetProssTypeAll()
		{
			return DataAccess.BaseInfo.ApplyProcessTypeDAL.getProssTypeAll();
		}

		public static DataTable GetProssTypeByTypeCode(string ProcessTypeCode)
		{
			return DataAccess.BaseInfo.ApplyProcessTypeDAL.GetProssTypeByTypeCode(ProcessTypeCode);
		}

	}
}
