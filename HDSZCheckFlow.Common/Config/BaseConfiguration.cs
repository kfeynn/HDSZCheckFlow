// ================================================================================
// 		File: BaseConfiguration.cs
// 		Desc: �����ļ��Ķ�ȡ����ȡweb.config��app.config�������ļ������ݡ�             
// 		Auth: ����
// 		Date: 2007��4��12��
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//		
// ================================================================================
// Copyright (C) 2007-2008 FCKJ Corporation
// ================================================================================
using System;
using System.Xml;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Collections;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Connection;  
using Castle.ActiveRecord;
using Castle.ActiveRecord.Framework;   
using Castle.Model.Configuration;
  
namespace HDSZCheckFlow.Common.Config
{
	/// <summary>
	/// ���õļ�ֵ����Ӧ��ϵͳ������Ӹ���������	
	/// </summary>
	public class BaseConfigKeys
	{
		#region ��Ա�����͹��캯��
		/// <summary>
		/// ��ʼ�� BaseConfigKeys �����ʵ����
		/// </summary>
		protected BaseConfigKeys(){}	
		/// <summary>
		/// ����Ա�ʺš�
		/// </summary>
		public const string AdminAccount = "HDSZCheckFlow.Administrator";
		/// <summary>
		/// ��Ŀ�洢·��
		/// </summary>
		public const string PathChannelImage = "Path.ChannelImage";
		/// <summary>
		/// ��ĿԤ��·��
		/// </summary>
		public const string HttpChannelImage = "Http.ChannelImage";
		#endregion		

	}

	/// <summary>
	/// ϵͳ�����࣬��ȡϵͳ���õ����ò�����
	/// </summary>
	public class BaseConfiguration:System.Configuration.IConfigurationSectionHandler
	{
		#region ��Ա���������ԡ����캯����
		/// <summary>
		/// ���ݿ������ַ�����
		/// </summary>
		
		string m_strSectionName;
		static Hashtable m_htCache;

		static BaseConfiguration()
		{
			m_htCache=new Hashtable();
		}
		/// <summary>
		/// ��ʼ�� BaseConfiguration �����ʵ����
		/// </summary>
		/// <param name="sectionName">Ĭ�϶�ȡ�Ķε����ơ�</param>
		public BaseConfiguration(string sectionName)
		{
			SectionName=sectionName;
		}

		/// <summary>
		/// ��ʼ�� BaseConfiguration �����ʵ����
		/// </summary>
		public BaseConfiguration():this(null)
		{

		}

		/// <summary>
		/// ��ȡ���������ö�����
		/// </summary>
		protected virtual string SectionName
		{
			get
			{
				return m_strSectionName;
			}
			set
			{
				m_strSectionName=value;				
			}
		}
		#endregion

		#region ��ȡ���ý��е�ֵ��

		/// <summary>
		/// ��ȡ�����ļ��м���Ӧ��ֵ���ȶ���ģ�飬���ޣ����ϵͳ���ã�AppSettings����
		/// </summary>
		/// <param name="key">���ü���</param>
		/// <returns>��Ӧֵ��</returns>
		protected virtual string GetConfigValue(string key)
		{
			if(this.SectionName==null || this.SectionName==string.Empty)
			{
				return AppSettings[key];
			}
			else
			{
				string strTmp=SectionSettings[key];
				if (strTmp==null || strTmp=="")
				{
					return AppSettings[key];
				} 
				else
				{
					return strTmp;
				}
			}
		}

		/// <summary>
		/// ��ȡappSettings���ö�������ݡ�		
		/// </summary>
		protected NameValueCollection AppSettings
		{
			get
			{		
				if(!m_htCache.Contains("AppSettings"))
				{
					m_htCache.Add("AppSettings",System.Configuration.ConfigurationSettings.AppSettings);
				}
				return (NameValueCollection)m_htCache["AppSettings"];
			}
		}

		/// <summary>
		/// ��ȡ��ģ�����ö�������ݡ�
		/// </summary>
		protected virtual NameValueCollection SectionSettings
		{
			get
			{
				if(!m_htCache.Contains(SectionName))
				{
					m_htCache.Add(SectionName,System.Configuration.ConfigurationSettings.GetConfig(SectionName));
				}
				return (NameValueCollection)m_htCache[SectionName];
			}
		}
		#endregion

		#region ���ݿ������ַ�����
		/// <summary>
		/// ��ȡ���ݿ������ַ����������򿪵����ݿ�����ӡ�
		/// </summary>
		public  virtual string ConnectionString
		{
			get 
			{ 
				string _conString = null;
				IConfigurationSource config = System.Configuration.ConfigurationSettings.GetConfig(SectionName) as IConfigurationSource;
	
				IConfiguration db2 = config.GetConfiguration( typeof(ActiveRecordBase) );
				foreach(IConfiguration child in db2.Children)
				{
					if (child.Name == NHibernate.Cfg.Environment.ConnectionString)
					{
						_conString = child.Value;
						break;
					}
				}
				return _conString;
			}
		}	
		#endregion		

		#region ��ȡ����Ա�ʺš�
		/// <summary>
		/// ��ȡ����Ա�ʺš�
		/// ��Ӧ������Ϊ BaseConfigKeys.AdminAccount��
		/// </summary>
		public virtual string Administrator
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.AdminAccount); 
			}
		}	
		#endregion

		#region ��ȡ��Ŀ�洢·��
		public virtual string GetPathChannelImage
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.PathChannelImage); 
			}
		}	
		#endregion

		#region ��ȡ��ĿԤ��·��
		public virtual string GetHttpChannelImage
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.HttpChannelImage); 
			}
		}	
		#endregion

		#region IConfigurationSectionHandler ��Ա

		/// <summary>
		/// �����µ����ô�����򲢽�����ӵ��ڴ�����򼯺��С�
		/// </summary>
		/// <param name="parent">��Ӧ�����ý��е��������á�</param>
		/// <param name="configContext">���ýڴ������Ϊ���������ֵ������·����ͨ�����ò����Ǳ�����������Ϊ�����ã�Visual Basic ��Ϊ Nothing���� </param>
		/// <param name="section">����Ҫ�����������Ϣ�� XmlNode���ṩ�����ý� XML ���ݵ�ֱ�ӷ��ʡ�</param>
		/// <returns>һ�� NameValueCollection��</returns>
		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
			NameValueSectionHandler handler=new NameValueSectionHandler();			
			return handler.Create(parent,configContext,section);
		}

		#endregion


		/// <summary>
		/// ��ȡ�����ļ��м���Ӧ��ֵ���ȶ���ģ�飬���ޣ����ϵͳ���ã�AppSettings����
		/// </summary>
		/// <param name="key">���ü���</param>
		/// <returns>��Ӧֵ��</returns>
		public string GetConfigByKey(string key)
		{
			if(this.SectionName==null || this.SectionName==string.Empty)
			{
				return AppSettings[key];
			}
			else
			{
				string strTmp=SectionSettings[key];
				if (strTmp==null || strTmp=="")
				{
					return AppSettings[key];
				} 
				else
				{
					return strTmp;
				}
			}
		}
	}
}
