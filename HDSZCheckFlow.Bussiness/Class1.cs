using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// Class1 ��ժҪ˵����
	/// </summary>
	public class Class1
	{
		public Class1()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public static DataSet getDataSet()
		{
			return DataAccess.Test.Class1.GetLog();


		}
	}
}
