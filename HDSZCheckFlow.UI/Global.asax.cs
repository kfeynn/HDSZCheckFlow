using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using System.Configuration;

using Castle.ActiveRecord; 
using Castle.ActiveRecord.Framework; 
using System.Reflection;
using System.IO;

namespace HDSZCheckFlow.UI 
{
	/// <summary>
	/// Global 的摘要说明。
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

        protected void Application_Start(Object sender, EventArgs e)
        {
            //实例化 实体类集
            log4net.Config.XmlConfigurator.Configure();

            //IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;
            IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;

            Assembly assembly = Assembly.Load("HDSZCheckFlow.Entiy");
            ActiveRecordStarter.Initialize(assembly, source);

            //访问远程文件上传服务器 
            System.Diagnostics.Process.Start("net.exe", "use \\\\192.168.2.17\\HDSZCheckFlow\\ApplyAnnexUpFiles \"missrv2016\" /user:\"Administrator\"");
            System.Diagnostics.Process.Start("net.exe", "use \\\\192.168.2.17\\HDSZCheckFlow\\FinallyCheckAnnexUpFiles \"missrv2016\" /user:\"Administrator\"");

        }
 
		protected void Session_Start(Object sender, EventArgs e)
		{

		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{

		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

