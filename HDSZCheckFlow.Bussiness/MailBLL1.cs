using System;
using jmail;
using System.Web;
using Dal=HDSZCheckFlow.Entiy  ;
using da=HDSZCheckFlow.DataAccess;
using System.Threading;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// MailBLL 的摘要说明。
	/// </summary>
	public class MailBLL1
	{
		public MailBLL1(){}

		public MailBLL1(int _applySheetPk)
		{
			applySheetPk = _applySheetPk ;
		}

		//外面传进来
		private int applySheetPk;	

		#region  从配置文件取出发邮件参数
		/// <summary>
		/// 邮箱账户
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerUserName()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerUserName"];
		}
		/// <summary>
		/// 邮箱密码
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerPassWord()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerPassWord"];
		}
		/// <summary>
		/// 发送邮件的服务器
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerSmtp()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerSmtp"];
		}
		/// <summary>
		/// 从哪个邮箱发出去
		/// </summary>
		/// <returns></returns>
		public static string  GetFromEMail()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_FromEMail"];
		}
		/// <summary>
		/// 以什么名字发出去
		/// </summary>
		/// <returns></returns>
		public static string  GetFromName()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_FromName"];
		}

		
		#endregion

		public bool SendMail(string _email,string title,string content)
		{
			bool rtnBool=false;
			Message msg=new Message();
			msg.Subject =title.Trim () ; 
			msg.AppendHTML(content);//设置为HTML
			//msg.Body =content;  
			
			msg.From =MailBLL.GetFromEMail();
　          msg.FromName =MailBLL.GetFromName();
			

			msg.MailServerUserName =MailBLL.GetMailServerUserName();
　          msg.MailServerPassWord =MailBLL.GetMailServerPassWord(); 
			
		
			msg.Silent=false;           //Silent属性：如果设置为true,JMail不会抛出例外错误.  
			msg.Logging=true;           //Jmail创建的日志，前提loging属性设置为true  
			msg.Charset="GB2312";       //字符集，缺省为"US-ASCII"  
   
			msg.ContentType="text/html";         //以HTML格式发送邮件,  
   
			msg.Encoding = "Base64";  
			msg.ISOEncodeHeaders = true;  
			msg.ContentTransferEncoding  = "base64";  					
			
　       

			//改写，多个收件人 以 ; 分割



			string[] sArray=_email.Split(';');

			foreach(string emailAdress in sArray)
			{
				 msg.AddRecipient(emailAdress,"收件人","");//加入一个收件人
			}



            //msg.AddRecipient(_email,"收件人","");//加入一个收件人



			string AdminEmail = System.Configuration.ConfigurationSettings.AppSettings["Administrator"]; 

			msg.AddRecipientBCC (AdminEmail,"");
			
			try
			{
				rtnBool = msg.Send(MailBLL.GetMailServerSmtp(),false);			
			}
			catch(Exception ex)
			{
				throw ex;
			}
			msg.Close();
			
			return rtnBool;
		}

		//专给资财发送邮件提醒做价格裁决
		public   void ThreadSendMail() //string checkRole,int CheckStep,int  DeptToCompany,string ApplyDeptCode)
		{
			try
			{
				//加载邮件主体
				ThreadStart myThreadDelegate = new ThreadStart(DoWork);
				Thread myThread = null;	
				myThread = new Thread(myThreadDelegate);
				myThread.Start();
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMail",ex.Message );
			}
		}

		private void DoWork()
		{
			try
			{
				// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 
				string SendCode =  System.Configuration.ConfigurationSettings.AppSettings ["FinallyPriceCheckApplyMaker"];

				string SendEmail = ""; 

				Entiy.ApplySheetHead applyHead= Entiy.ApplySheetHead.Find(applySheetPk);

				Entiy.BaseEmail BaseEmail = Entiy.BaseEmail.Find(SendCode) ; 
				if(BaseEmail != null && BaseEmail.IsAccept ==1 )
				{
					SendEmail = BaseEmail.Email;
				}

				//整理邮件内容 

				string content = "尊敬的" + BaseEmail.Name + ": <br/>  您好。单据号为：" + applyHead.ApplySheetNo +"的审批已经完成，需要您做跟进处理！";

				SendMail(SendEmail,"经费系统邮件提醒",content);


			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMail",ex.Message );
			}
		}

	}
}
