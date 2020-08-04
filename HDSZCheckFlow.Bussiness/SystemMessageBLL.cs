using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SystemMessageBLL ��ժҪ˵����
	/// </summary>
	public class SystemMessageBLL
	{
		public SystemMessageBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ȡϵͳ��Ϣ,��ת��Ϊ�ַ�������.
		/// </summary>
		/// <param name="dt"></param>
		/// <returns></returns>
		public static string GetSystemMessage(DateTime dt)
		{
			string SystemMessage = "";
			//1.��ȡ���� ��Ч��Ϣ
			DataSet ds = DataAccess.BaseInfo.SystemMessageDAL.GetSystemMessage(dt);

			//2.������ϢΪ�ַ�����ʽ
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
