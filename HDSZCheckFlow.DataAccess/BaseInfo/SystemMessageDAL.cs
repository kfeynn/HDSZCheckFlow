using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// SystemMessageDAL 的摘要说明。
	/// </summary>
	public class SystemMessageDAL
	{
		public SystemMessageDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public static DataSet GetSystemMessage(DateTime dt)
		{
			//返回日期介于开始结束之内的系统消息
			string cmdStr="select Content from Base_SystemMessage where issueTime<='" + dt + "' and endTime >='" + dt + "' "  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}
	}
}
