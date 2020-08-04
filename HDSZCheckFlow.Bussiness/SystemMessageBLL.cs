using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SystemMessageBLL 的摘要说明。
	/// </summary>
	public class SystemMessageBLL
	{
		public SystemMessageBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 获取系统消息,并转化为字符串类型.
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetSystemMessage(DateTime dt)
		{
			string SystemMessage = "";
			//1.获取所有 有效消息
			DataSet ds = DataAccess.BaseInfo.SystemMessageDAL.GetSystemMessage(dt);

			//2.整理消息为字符串形式
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					SystemMessage += "<br><br><li>"+ds.Tables[0].Rows[i][0].ToString();
				}
			}
			return SystemMessage;
		}
	}
}
