using System;
using System.Data;
using System.Collections;

using Castle.ActiveRecord; 
using Castle.ActiveRecord.Framework.Config; 
using System.Reflection;
using System.IO;
using Castle.Model;
using HDSZCheckFlow.Entiy;

namespace HDSZCheckFlow.Common.Config
{
	/// <summary>
	/// ConnectToCastleDatabase 的摘要说明。
	/// </summary>
	public class ConnectToCastleDatabase
	{
		public ConnectToCastleDatabase()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 初始化Castle实体类　　注：Global文件里　一次性初始化了一个文件夹，此处主要为了访问另外一个数据库．
		/// </summary>
		/// <param name="conStr">连接字符串</param>
		/// <param name="myType">类型</param>
		public static void RegisterCastleClass(string conStr,Type myType)
		{
            //try
            //{
            //    //string conStr=System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
			
            //    InPlaceConfigurationSource source = new InPlaceConfigurationSource();

            //    Hashtable properties = new Hashtable();

            //    properties.Add("hibernate.connection.driver_class", "NHibernate.Driver.SqlClientDriver");

            //    properties.Add("hibernate.dialect", "NHibernate.Dialect.MsSql2000Dialect");

            //    properties.Add("hibernate.connection.provider", "NHibernate.Connection.DriverConnectionProvider");

            //    properties.Add("hibernate.connection.connection_string", conStr);

            //    source.Add(typeof(Castle.ActiveRecord.ActiveRecordBase),properties);

            //    //Type myType=className.GetType();

            //    ActiveRecordStarter.Initialize(source, myType);
            //}
            //catch(Exception ex)
            //{
            //    Log.Logger.Log("HDSZCheckFlow.Common.Config.RegisterCastleClass-->",ex.Message);
            //}
		}
	}
}
