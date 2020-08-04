using System;
using HDSZCheckFlow.Common.Config;

namespace HDSZCheckFlow.Common.Log
{
	/// <summary>
	/// ������־��¼�ࡣ
	/// </summary>
	public class Logger
	{

		#region ��Ա���������캯����
		private static log4net.ILog log;

		static Logger()
		{

		}
		#endregion

		#region ����־��log4net�Զ���ķ�ʽ��¼��
		public static void Log(string loggerName,string msg)
		{
			log = log4net.LogManager.GetLogger(loggerName);
			Log(loggerName,LogType.Error,msg); 
		}
		public static void Log(string loggerName,Exception ex)
		{
			string err=ex.Message+"\n"+ex.TargetSite+"\n"+ex.StackTrace;
			if( ex!=null && ex.InnerException!=null )
			{
				err+="\n\n\n"+ex.InnerException.Message;
				err+="\n"+ex.InnerException.TargetSite;
				err+="\n"+ex.InnerException.StackTrace;
				
			}
			log = log4net.LogManager.GetLogger(loggerName);
			Log(loggerName,LogType.Error,err); 
		}
		/// <summary>
		/// ����־��log4net�Զ���ķ�ʽ��¼��
		/// </summary>
		/// <param name="loggerName">��־��¼�ߣ�һ��Ϊ��������log4net�ڲ����˻��棬����logger����Ψһ��Ӧһ������ʵ������</param>
		/// <param name="type">��־�ȼ����͡�Ĭ��ΪInfo��</param>
		/// <param name="msg">��־��Ϣ��</param>
		public static void Log(string loggerName,LogType type,string msg)
		{
			log = log4net.LogManager.GetLogger(loggerName);
			
			
			switch(type)
			{
				case LogType.Debug : 
					log.Debug(msg);
					break;
				case LogType.Info:
					log.Info(msg);
					break;
				case LogType.Warn:
					log.Warn(msg);
					break;
				case LogType.Error:
					log.Error(msg);
					break;
				case LogType.Fatal:
					log.Fatal(msg);
					break;
				default:
					log.Info(msg);
					break;
			}
		}
		#endregion
	}

	#region ����ȼ�����ö�١�
	/// <summary>
	/// ����ȼ�����ö�١�
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// ��ʽ����
		/// </summary>
		Debug = 0x01,
		/// <summary>
		/// ��Ϣ����
		/// </summary>
		Info = 0x02,
		/// <summary>
		/// ���漶��
		/// </summary>
		Warn = 0x03,
		/// <summary>
		/// ���󼶱�
		/// </summary>
		Error = 0x04,
		/// <summary>
		/// �������󼶱�
		/// </summary>
		Fatal = 0x05
	}
	#endregion
}
