using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.Test
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
		public static DataSet GetLog()
		{
			DBAccess dbAccess=new SQLAccess();

//			string cmdStr="select *  from [Log]";
			string cmdStr="select top  3  *  from  checkrole ";

			return dbAccess.ExecuteDataset(cmdStr);

		}
	}
}
