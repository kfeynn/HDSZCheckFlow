using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// SystemMessageDAL ��ժҪ˵����
	/// </summary>
	public class SystemMessageDAL
	{
		public SystemMessageDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static DataSet GetSystemMessage(DateTime dt)
		{
			//�������ڽ��ڿ�ʼ����֮�ڵ�ϵͳ��Ϣ
			string cmdStr="select Content from Base_SystemMessage where issueTime<='" + dt + "' and endTime >='" + dt + "' "  ;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr);
		}
	}
}
