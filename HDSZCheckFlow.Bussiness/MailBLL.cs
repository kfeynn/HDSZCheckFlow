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
	public class MailBLL
	{
		public MailBLL()
		{
		}
		
		public MailBLL(string _checkRole,int  _CheckStep,int _DeptToCompany,string _applyDeptCode,string _applyType,string _applyMoney,string _appSheetNo )
		{
			checkRole=_checkRole;
			CheckStep=_CheckStep;
			DeptToCompany=_DeptToCompany;
			applyDeptCode=_applyDeptCode;
			applyType = _applyType ;
			applyMoney = _applyMoney ;
			appSheetNo=_appSheetNo;


		}

		public MailBLL(string _youCode,string  _myCode,string _postail,string _appSheetNo )
		{
			youCode=_youCode;
			myCode=_myCode;
			postail=_postail;
			appSheetNo=_appSheetNo;
		}


		//收件人工号，意见内容，
		//public MailBLL(string _SetRecipient,string _Postail,


		//外面传进来
		private  int CheckStep;
		private  int  DeptToCompany;
		private  string checkRole;
		private  string applyDeptCode;
		private string applyType;
		private  string applyMoney; 

		private string youCode;
		private string myCode;
		private string postail;
		private string appSheetNo;

		

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
			msg.Logging=true;         //Jmail创建的日志，前提loging属性设置为true  
			msg.Charset="GB2312";       //字符集，缺省为"US-ASCII"  
   
			msg.ContentType="text/html";         //以HTML格式发送邮件,  
		 
   
			msg.Encoding = "Base64";  
			msg.ISOEncodeHeaders = true;  
			msg.ContentTransferEncoding  = "base64";  					
			         　        
　          msg.AddRecipient(_email,"收件人","");//加入一个收件人  				　	
			try
			{
				rtnBool = msg.Send(MailBLL.GetMailServerSmtp(),false);			
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log(this.GetType().ToString(),"SendMail,"+ex.Message);
			}
			msg.Close();
			
			return rtnBool;
		}

		
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

				string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole ,CheckStep ,DeptToCompany,applyDeptCode );
							
				//根据工号发邮件
				
				//判断是否需要发送邮件
				Entiy.BaseEmail BaseEmail = Entiy.BaseEmail.Find(UserCode);

				if(BaseEmail != null && BaseEmail.IsAccept == 1)
				{
					Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType,applyMoney,appSheetNo);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMail",ex.Message );
			}
		}

		public   void ThreadSendMailForUnAgree() 
		{
			try
			{
				//加载邮件主体
				ThreadStart myThreadDelegate = new ThreadStart(DoWorkForUnAgree);
				Thread myThread = null;	
				myThread = new Thread(myThreadDelegate);
				myThread.Start();
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMailForUnAgree",ex.Message );
			}
		}
		
		private void DoWorkForUnAgree()
		{
			try
			{
				//判断是否需要发送邮件
				Entiy.BaseEmail BaseEmail = Entiy.BaseEmail.Find(youCode);

				if(BaseEmail != null && BaseEmail.IsAccept == 1)
				{
					Bussiness.ApplyAuditingBLL.SendEmailForUnAgree(youCode,myCode,postail,appSheetNo);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMail",ex.Message );
			}
		}
	}
}
