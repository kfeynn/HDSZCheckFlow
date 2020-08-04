using System;
using System.Data;
using System.Web.UI.WebControls;
using entiy=HDSZCheckFlow.Entiy;
using HDSZCheckFlow.DataAccess.CheckFlow;
namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// MailSetUpBLL 的摘要说明。
	/// </summary>
	public class MailSetUpBLL
	{
		public MailSetUpBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 读取现在用户的邮件基本信息
		/// </summary>
		/// <returns></returns>
		public  static entiy.BaseEmail selectDuget(int PersonID)
		{
			//MailSetUpDAL.selectDuget(PersonCode);
			return MailSetUpDAL.selectDuget(PersonID);;
		}

		/// <summary>
		/// 修改Email基础信息
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
		public static int UpdateEmail(entiy.BaseEmail email)
		{
			return MailSetUpDAL.UpdateEmail(email);
		}

	}


}
