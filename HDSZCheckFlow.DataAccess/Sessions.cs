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
	/// Sessions ��ժҪ˵����
	/// </summary>
	public class Sessions
	{
		private static readonly object lockObj = new object();
		private static  ISessionFactory _factory;

		public Sessions()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// �Ự����
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
		/// ��ȡһ���Ự
		/// </summary>
		/// <param name="typeEntity"></param>
		/// <returns></returns>
		public static ISession GetSession() 
		{
			return Factory.OpenSession();
		}


	}
}
