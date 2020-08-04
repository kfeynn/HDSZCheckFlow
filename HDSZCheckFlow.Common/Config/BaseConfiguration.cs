// ================================================================================
// 		File: BaseConfiguration.cs
// 		Desc: 配置文件的读取。读取web.config，app.config等配置文件的内容。             
// 		Auth: 林阳
// 		Date: 2007年4月12日
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
	/// 配置的键值，个应用系统配置类从该类派生。	
	/// </summary>
	public class BaseConfigKeys
	{
		#region 成员变量和构造函数
		/// <summary>
		/// 初始化 BaseConfigKeys 类的新实例。
		/// </summary>
		protected BaseConfigKeys(){}	
		/// <summary>
		/// 管理员帐号。
		/// </summary>
		public const string AdminAccount = "HDSZCheckFlow.Administrator";
		/// <summary>
		/// 栏目存储路径
		/// </summary>
		public const string PathChannelImage = "Path.ChannelImage";
		/// <summary>
		/// 栏目预览路径
		/// </summary>
		public const string HttpChannelImage = "Http.ChannelImage";
		#endregion		

	}

	/// <summary>
	/// 系统配置类，获取系统配置的配置参数。
	/// </summary>
	public class BaseConfiguration:System.Configuration.IConfigurationSectionHandler
	{
		#region 成员变量、属性、构造函数。
		/// <summary>
		/// 数据库连接字符串。
		/// </summary>
		
		string m_strSectionName;
		static Hashtable m_htCache;

		static BaseConfiguration()
		{
			m_htCache=new Hashtable();
		}
		/// <summary>
		/// 初始化 BaseConfiguration 类的新实例。
		/// </summary>
		/// <param name="sectionName">默认读取的段的名称。</param>
		public BaseConfiguration(string sectionName)
		{
			SectionName=sectionName;
		}

		/// <summary>
		/// 初始化 BaseConfiguration 类的新实例。
		/// </summary>
		public BaseConfiguration():this(null)
		{

		}

		/// <summary>
		/// 获取或设置配置段名。
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

		#region 获取配置节中的值。

		/// <summary>
		/// 获取配置文件中键对应的值。先读本模块，若无，则读系统配置（AppSettings）。
		/// </summary>
		/// <param name="key">配置键。</param>
		/// <returns>对应值。</returns>
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
		/// 获取appSettings配置段里的内容。		
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
		/// 获取该模块配置段里的内容。
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

		#region 数据库连接字符串。
		/// <summary>
		/// 获取数据库连接字符串，用来打开到数据库的连接。
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

		#region 获取管理员帐号。
		/// <summary>
		/// 获取管理员帐号。
		/// 对应配置项为 BaseConfigKeys.AdminAccount。
		/// </summary>
		public virtual string Administrator
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.AdminAccount); 
			}
		}	
		#endregion

		#region 获取栏目存储路径
		public virtual string GetPathChannelImage
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.PathChannelImage); 
			}
		}	
		#endregion

		#region 获取栏目预览路径
		public virtual string GetHttpChannelImage
		{
			get
			{
				return GetConfigValue(BaseConfigKeys.HttpChannelImage); 
			}
		}	
		#endregion

		#region IConfigurationSectionHandler 成员

		/// <summary>
		/// 创建新的配置处理程序并将其添加到节处理程序集合中。
		/// </summary>
		/// <param name="parent">对应父配置节中的配置设置。</param>
		/// <param name="configContext">配置节处理程序为其计算配置值的虚拟路径。通常，该参数是保留参数，并为空引用（Visual Basic 中为 Nothing）。 </param>
		/// <param name="section">包含要处理的配置信息的 XmlNode。提供对配置节 XML 内容的直接访问。</param>
		/// <returns>一个 NameValueCollection。</returns>
		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
			NameValueSectionHandler handler=new NameValueSectionHandler();			
			return handler.Create(parent,configContext,section);
		}

		#endregion


		/// <summary>
		/// 获取配置文件中键对应的值。先读本模块，若无，则读系统配置（AppSettings）。
		/// </summary>
		/// <param name="key">配置键。</param>
		/// <returns>对应值。</returns>
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
