using System;
using System.Data;
using System.Web.UI.WebControls;
using entiy=HDSZCheckFlow.Entiy;
using HDSZCheckFlow.DataAccess.CheckFlow;
namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// MailSetUpBLL ��ժҪ˵����
	/// </summary>
	public class MailSetUpBLL
	{
		public MailSetUpBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ȡ�����û����ʼ�������Ϣ
		/// </summary>
		/// <returns></returns>
		public  static entiy.BaseEmail selectDuget(int PersonID)
		{
			//MailSetUpDAL.selectDuget(PersonCode);
			return MailSetUpDAL.selectDuget(PersonID);;
		}

		/// <summary>
		/// �޸�Email������Ϣ
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static int UpdateEmail(entiy.BaseEmail email)
		{
			return MailSetUpDAL.UpdateEmail(email);
		}

	}


}
