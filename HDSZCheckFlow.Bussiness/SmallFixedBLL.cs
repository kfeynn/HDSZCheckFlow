using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SmallFixedBLL 的摘要说明。
	/// </summary>
	public class SmallFixedBLL
	{
		public SmallFixedBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataTable GetNCDeptInfo()
		{
			 
			return DataAccess.SmallFixed.SmallFixedDAL.GetNCDeptInfo();

		}

		/// <summary>
		/// 检查是否存在管理编码
		/// </summary>
		/// <param name="InvManageCode"></param>
		/// <returns></returns>
		public static bool CheckExistsInvManageCode(string invManageCode)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.CheckExistsInvManageCode(invManageCode);
		}

		//物料信息
		public static DataTable   GetInvInfo( )
		{
			return DataAccess.SmallFixed.SmallFixedDAL.GetInvInfo();
		}

		public static DataTable GetNCTypeInfo()
		{
			 
			return DataAccess.SmallFixed.SmallFixedDAL.GetNCTypeInfo();

		}
		/// <summary> 
		/// SmallFixedAsset表数据插入(目前只插入部份字段的数据)
		/// </summary>
		/// <param name="sfa"></param>
		/// <returns></returns>
		public static int Save(Entiy.SmallFixedAsset sfa)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.Save(sfa); 
		}

		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="sfa"></param>
		/// <returns></returns>
		public static int Update(Entiy.SmallFixedAsset sfa)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.Update(sfa);
		}





	}
}
