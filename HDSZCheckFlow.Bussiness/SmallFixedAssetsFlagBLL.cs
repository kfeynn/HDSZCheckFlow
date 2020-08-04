using System;
using HDSZCheckFlow.Entiy;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SmallFixedAssetsFlagBLL 的摘要说明。
	/// </summary>
	public class SmallFixedAssetsFlagBLL
	{
		public static int Save(SmallFixedAssetsFlag sfaf)
		{
			return DataAccess.SmallFixed.SmallFixedAssetsFlagDAL.Save(sfaf);
		}
	}
}
