using System;
using System.Threading;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SendEmailTimer 的摘要说明。
	/// 定时检查数据库的未审批单据，发送给相关审批人员，用于提醒。暂定一天执行一次。
	/// 由WinForm端控制
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
				//加载邮件主体
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
			
			// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 


			string cmdStr = "select * from base_email where personcode = '" + SendCode +"'";

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

			if(ds!=null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0 )
			{				
				string Name = ds.Tables[0].Rows[0]["NickName"].ToString()=="" ?ds.Tables[0].Rows[0]["Name"].ToString() : ds.Tables[0].Rows[0]["NickName"].ToString() ;
				//整理邮件内容 
				string content = Name + "　殿： <br/>     経費の未承認 <font color='red'>" + budgetApplyCount.ToString() + "</font> 件、価格決裁の未承認 <font color='red'>" + priceApplyCount.ToString() + " </font> 件,ご承認願います";

				//发送邮件
				Bussiness.MailBLL1 mail = new MailBLL1();

				//string cmdEmail = (string)ds.Tables[0].Rows[0]["Email"];
				string cmdEmail = ds.Tables[0].Rows[0]["Email"].ToString();


				mail.SendMail(cmdEmail,"经费系统审批提醒",content );

			}

		
		}


		public static void BTestEmail()
		{
 
			 
			//测试发邮件到管理员帐户

			string AdminEmail = System.Configuration.ConfigurationSettings.AppSettings["Administrator"]; 

			string content = "提醒：请运行 exec [查询所有单据预算信息] 查看余额为负数单据并处理"   +  System.DateTime.Now.ToString() ;


			Bussiness.MailBLL1 mail = new MailBLL1();

			mail.SendMail (AdminEmail,"Test", content);
			 



		}





		public static void ATestEmail()
		{

			 
				//测试发邮件到管理员帐户

				string AdminEmail = System.Configuration.ConfigurationSettings.AppSettings["Administrator"]; 

				string content = "测试邮件："   +  System.DateTime.Now.ToString() ;


				Bussiness.MailBLL1 mail = new MailBLL1();

				mail.SendMail (AdminEmail,"Test", content);
			 



		}





		public static DataSet   TestConn(string conn)
		{
			//1。找到发送列表
			string cmdStr = "select top 10 * from xpGrid_User  ";

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

			return ds;


		}

		public static DataSet GetListTest(string conn)
		{
			try
			{
				//1。找到发送列表
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
		/// 检测 “[查询所有单据预算信息]” 出现余额负数提醒 zyq
		/// </summary>
		public static void SendEmailForApplyBudget(string conn)
		{

			string cmdStr = "exec [查询所有单据预算信息] ";

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
				//1。找到发送列表
				string cmdStr = "exec [p_QueryForCurrentCheckCount] ";

				DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr,conn);

				if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
				{
					//循环发送邮件
					for(int i= 0;i < ds.Tables[0].Rows.Count ;i++)
					{
						string MailTo = ds.Tables[0].Rows[i]["checkpersoncode"].ToString();
						string applycount = ds.Tables[0].Rows[i]["applycount"].ToString();
						string assetcount = ds.Tables[0].Rows[i]["assetcount"].ToString();

						SendEmailTimer sendTimer = new SendEmailTimer(MailTo,int.Parse(applycount),int.Parse(assetcount),conn);

						sendTimer.ThreadSendMail();

					}
				}

				//调用检查单据余额信息
				SendEmailForApplyBudget(conn);



			}
			catch(Exception Ex)
			{
				throw Ex;
			}

		}

	}
}
