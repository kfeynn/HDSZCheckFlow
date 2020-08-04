using System;
using System.Threading;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SendEmailTimer ��ժҪ˵����
	/// ��ʱ������ݿ��δ�������ݣ����͸����������Ա���������ѡ��ݶ�һ��ִ��һ�Ρ�
	/// ��WinForm�˿���
	/// </summary>
	public class SendEmailTimer
	{
		public SendEmailTimer(){}

		public SendEmailTimer(string _sendCode,int _budgetApplyCount,int _priceApplyCount ,string _conn)
		{
			SendCode = _sendCode ; 
			budgetApplyCount = _budgetApplyCount;
			priceApplyCount = _priceApplyCount ; 
			conn=_conn;
		}
		private string SendCode ;
		private int budgetApplyCount;
		private int priceApplyCount ; 
		private string conn;

		public   void ThreadSendMail()
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
				throw ex;
			}
		}

		private void DoWork()
		{
			
			// ����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 


			string cmdStr = "select * from base_email where personcode = '" + SendCode +"'";

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

			if(ds!=null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
			{				
				string Name = ds.Tables[0].Rows[0]["NickName"].ToString()=="" ?ds.Tables[0].Rows[0]["Name"].ToString() : ds.Tables[0].Rows[0]["NickName"].ToString() ;
				//�����ʼ����� 
				string content = Name + "��� <br/>     �U�M��δ���J <font color='red'>" + budgetApplyCount.ToString() + "</font> ��������Q�ä�δ���J <font color='red'>" + priceApplyCount.ToString() + " </font> ��,�����J��ޤ�";

				//�����ʼ�
				Bussiness.MailBLL1 mail = new MailBLL1();

				//string cmdEmail = (string)ds.Tables[0].Rows[0]["Email"];
				string cmdEmail = ds.Tables[0].Rows[0]["Email"].ToString();


				mail.SendMail(cmdEmail,"����ϵͳ��������",content );

			}

		
		}


		public static void BTestEmail()
		{
 
			 
			//���Է��ʼ�������Ա�ʻ�

			string AdminEmail = System.Configuration.ConfigurationSettings.AppSettings["Administrator"]; 

			string content = "���ѣ������� exec [��ѯ���е���Ԥ����Ϣ] �鿴���Ϊ�������ݲ�����"   +  System.DateTime.Now.ToString() ;


			Bussiness.MailBLL1 mail = new MailBLL1();

			mail.SendMail (AdminEmail,"Test", content);
			 



		}





		public static void ATestEmail()
		{

			 
				//���Է��ʼ�������Ա�ʻ�

				string AdminEmail = System.Configuration.ConfigurationSettings.AppSettings["Administrator"]; 

				string content = "�����ʼ���"   +  System.DateTime.Now.ToString() ;


				Bussiness.MailBLL1 mail = new MailBLL1();

				mail.SendMail (AdminEmail,"Test", content);
			 



		}





		public static DataSet   TestConn(string conn)
		{
			//1���ҵ������б�
			string cmdStr = "select top 10 * from xpGrid_User  ";

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

			return ds;


		}

		public static DataSet GetListTest(string conn)
		{
			try
			{
				//1���ҵ������б�
				string cmdStr = "exec [p_QueryForCurrentCheckCount] ";

				DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

				return ds;
			}
			catch(Exception ex)
			{
				
				throw ex;
			}


		}

		/// <summary>
		/// ��� ��[��ѯ���е���Ԥ����Ϣ]�� ������������ zyq
		/// </summary>
		public static void SendEmailForApplyBudget(string conn)
		{

			string cmdStr = "exec [��ѯ���е���Ԥ����Ϣ] ";

			DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

//			if(ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
//			{
				HDSZCheckFlow.Bussiness.SendEmailTimer.BTestEmail();

//			}

		}




		//////////////////////////////
		
		public static void SendEmail(string conn)
		{
			try
			{
				//1���ҵ������б�
				string cmdStr = "exec [p_QueryForCurrentCheckCount] ";

				DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

				if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
				{
					//ѭ�������ʼ�
					for(int i= 0;i < ds.Tables[0].Rows.Count ;i++)
					{
						string MailTo = ds.Tables[0].Rows[i]["checkpersoncode"].ToString();
						string applycount = ds.Tables[0].Rows[i]["applycount"].ToString();
						string assetcount = ds.Tables[0].Rows[i]["assetcount"].ToString();

						SendEmailTimer sendTimer = new SendEmailTimer(MailTo,int.Parse(applycount),int.Parse(assetcount),conn);

						sendTimer.ThreadSendMail();

					}
				}

				//���ü�鵥�������Ϣ
				SendEmailForApplyBudget(conn);



			}
			catch(Exception Ex)
			{
				throw Ex;
			}

		}

	}
}
