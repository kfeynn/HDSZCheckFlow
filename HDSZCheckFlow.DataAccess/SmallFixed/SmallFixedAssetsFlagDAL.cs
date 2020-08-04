using System;
using HDSZCheckFlow.Entiy;
using System.Data;

namespace HDSZCheckFlow.DataAccess.SmallFixed
{
	/// <summary>
	/// SmallFixedAssetsFlagDAL 的摘要说明。
	/// </summary>
	public class SmallFixedAssetsFlagDAL
	{
		public static int Save(SmallFixedAssetsFlag sfaf)
		{
			string sql=" insert into SmallFixedAssetsFlag  (InvSheetId,IsFlag)  values(@InvSheetId,@IsFlag) ";

			DBAccess dbAccess = new SQLAccess();
			DBParameterCollection param=new DBParameterCollection(); 
			param.Add(Parameter.GetDBParameter("@InvSheetId",sfaf.InvSheetId));
			param.Add(Parameter.GetDBParameter("@IsFlag",sfaf.IsFlag));
			return dbAccess.ExecuteNonQuery(sql,CommandType.Text,param);
		}
	}
}
