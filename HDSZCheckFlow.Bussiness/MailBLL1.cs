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
	public class MailBLL1
	{
		public MailBLL1(){}

		public MailBLL1(int _applySheetPk)
		{
			applySheetPk = _applySheetPk ;
		}

		//���洫����
		private int applySheetPk;	

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
			msg.Logging=true;           //Jmail��������־��ǰ��loging��������Ϊtrue  
			msg.Charset="GB2312";       //�ַ�����ȱʡΪ"US-ASCII"  
   
			msg.ContentType="text/html";         //��HTML��ʽ�����ʼ�,  
   
			msg.Encoding = "Base64";  
			msg.ISOEncodeHeaders = true;  
			msg.ContentTransferEncoding  = "base64";  					
			
��       

			//��д������ռ��� �� ; �ָ�



			string[] sArray=_email.Split(';');

			foreach(string emailAdress in sArray)
			{
				 msg.AddRecipient(emailAdress,"�ռ���","");//����һ���ռ���
			}



            //msg.AddRecipient(_email,"�ռ���","");//����һ���ռ���



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

		//ר���ʲƷ����ʼ��������۸�þ�
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
				string SendCode =  System.Configuration.ConfigurationSettings.AppSettings ["FinallyPriceCheckApplyMaker"];

				string SendEmail = ""; 

				Entiy.ApplySheetHead applyHead= Entiy.ApplySheetHead.Find(applySheetPk);

				Entiy.BaseEmail BaseEmail = Entiy.BaseEmail.Find(SendCode) ; 
				if(BaseEmail != null && BaseEmail.IsAccept ==1 )
				{
					SendEmail = BaseEmail.Email;
				}

				//�����ʼ����� 

				string content = "�𾴵�" + BaseEmail.Name + ": <br/>  ���á����ݺ�Ϊ��" + applyHead.ApplySheetNo +"�������Ѿ���ɣ���Ҫ������������";

				SendMail(SendEmail,"����ϵͳ�ʼ�����",content);


			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadSendMail",ex.Message );
			}
		}

	}
}
