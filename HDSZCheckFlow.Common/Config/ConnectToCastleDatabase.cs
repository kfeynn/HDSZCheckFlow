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
	/// ConnectToCastleDatabase ��ժҪ˵����
	/// </summary>
	public class ConnectToCastleDatabase
	{
		public ConnectToCastleDatabase()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ��ʼ��Castleʵ���ࡡ��ע��Global�ļ��һ���Գ�ʼ����һ���ļ��У��˴���ҪΪ�˷�������һ�����ݿ⣮
		/// </summary>
		/// <param name="conStr">�����ַ���</param>
		/// <param name="myType">����</param>
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
