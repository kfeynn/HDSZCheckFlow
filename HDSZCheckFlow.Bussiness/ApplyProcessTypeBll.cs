using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplyProcessTypeBll ��ժҪ˵����
	/// </summary>
	public class ApplyProcessTypeBll
	{
		public ApplyProcessTypeBll()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
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
