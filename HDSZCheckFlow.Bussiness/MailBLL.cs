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
	/// MailBLL ��ժҪ˵����
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


		//�ռ��˹��ţ�������ݣ�
		//public MailBLL(string _SetRecipient,string _Postail,


		//���洫����
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

		

		#region  �������ļ�ȡ�����ʼ�����
		/// <summary>
		/// �����˻�
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerUserName()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerUserName"];
		}
		/// <summary>
		/// ��������
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerPassWord()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerPassWord"];
		}

		/// <summary>
		/// �����ʼ��ķ�����
		/// </summary>
		/// <returns></returns>
		public static string  GetMailServerSmtp()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_MailServerSmtp"];
		}


		/// <summary>
		/// ���ĸ����䷢��ȥ
		/// </summary>
		/// <returns></returns>
		public static string  GetFromEMail()
		{
			return System.Configuration.ConfigurationSettings.AppSettings ["System_FromEMail"];
		}


		/// <summary>
		/// ��ʲô���ַ���ȥ
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
			msg.AppendHTML(content);//����ΪHTML
			//msg.Body =content;  
			
			msg.From =MailBLL.GetFromEMail();
��          msg.FromName =MailBLL.GetFromName();

			msg.MailServerUserName =MailBLL.GetMailServerUserName();
��          msg.MailServerPassWord =MailBLL.GetMailServerPassWord(); 
			
		
			msg.Silent=false;           //Silent���ԣ��������Ϊtrue,JMail�����׳��������.  
			msg.Logging=true;         //Jmail��������־��ǰ��loging��������Ϊtrue  
			msg.Charset="GB2312";       //�ַ�����ȱʡΪ"US-ASCII"  
   
			msg.ContentType="text/html";         //��HTML��ʽ�����ʼ�,  
		 
   
			msg.Encoding = "Base64";  
			msg.ISOEncodeHeaders = true;  
			msg.ContentTransferEncoding  = "base64";  					
			         ��        
��          msg.AddRecipient(_email,"�ռ���","");//����һ���ռ���  				��	
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
				//�����ʼ�����

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
				// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 

				string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole ,CheckStep ,DeptToCompany,applyDeptCode );
							
				//���ݹ��ŷ��ʼ�
				
				//�ж��Ƿ���Ҫ�����ʼ�
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
				//�����ʼ�����
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
				//�ж��Ƿ���Ҫ�����ʼ�
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
