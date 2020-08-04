using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.Test
{
	/// <summary>
	/// Class1 的摘要说明。
	/// </summary>
	public class Class1
	{
		public Class1()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public static DataSet GetLog()
		{
			DBAccess dbAccess=new SQLAccess();

//			string cmdStr="select *  from [Log]";
			string cmdStr="select top  3  *  from  checkrole ";

			return dbAccess.ExecuteDataset(cmdStr);

		}
	}
}
