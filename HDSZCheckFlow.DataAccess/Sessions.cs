using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection; 
using System.Reflection;
using Castle.ActiveRecord; 
using Castle.ActiveRecord.Framework; 
using Castle.ActiveRecord.Framework.Config;   

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// Sessions 的摘要说明。
	/// </summary>
	public class Sessions
	{
		private static readonly object lockObj = new object();
		private static  ISessionFactory _factory;

		public Sessions()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 会话工厂
		/// </summary>
		public static ISessionFactory Factory 
		{
			get 
			{ 

				if ( _factory == null ) 
				{
					lock ( lockObj ) 
					{
						if ( _factory == null ) 
						{
							Configuration cfg = new Configuration();
							
							cfg.AddAssembly("HDSZCheckFlow.Entity");
							
							_factory = cfg.BuildSessionFactory(); 
						}
					} 
				}
				return _factory;
			}
		}
		/// <summary>
		/// 获取一个会话
		/// </summary>
		/// <param name="typeEntity"></param>
		/// <returns></returns>
		public static ISession GetSession() 
		{
			return Factory.OpenSession();
		}


	}
}
