using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
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
		public static DataSet getDataSet()
		{
			return DataAccess.Test.Class1.GetLog();


		}
	}
}
