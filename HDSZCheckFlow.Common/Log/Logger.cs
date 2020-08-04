using System;
using HDSZCheckFlow.Common.Config;

namespace HDSZCheckFlow.Common.Log
{
	/// <summary>
	/// 错误日志记录类。
	/// </summary>
	public class Logger
	{

		#region 成员变量、构造函数。
		private static log4net.ILog log;

		static Logger()
		{

		}
		#endregion

		#region 将日志以log4net自定义的方式记录。
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
		/// 将日志以log4net自定义的方式记录。
		/// </summary>
		/// <param name="loggerName">日志记录者（一般为方法名，log4net内部做了缓存，根据logger名来唯一对应一个对象实例）。</param>
		/// <param name="type">日志等级类型。默认为Info。</param>
		/// <param name="msg">日志信息。</param>
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

	#region 错误等级类型枚举。
	/// <summary>
	/// 错误等级类型枚举。
	/// </summary>
	public enum LogType
	{
		/// <summary>
		/// 调式级别。
		/// </summary>
		Debug = 0x01,
		/// <summary>
		/// 信息级别。
		/// </summary>
		Info = 0x02,
		/// <summary>
		/// 警告级别。
		/// </summary>
		Warn = 0x03,
		/// <summary>
		/// 错误级别。
		/// </summary>
		Error = 0x04,
		/// <summary>
		/// 致命错误级别。
		/// </summary>
		Fatal = 0x05
	}
	#endregion
}
