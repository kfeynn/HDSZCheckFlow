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
	/// Global ��ժҪ˵����
	/// </summary>
	public class Global : System.Web.HttpApplication
	{
		/// <summary>
		/// ����������������
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		public Global()
		{
			InitializeComponent();
		}

        protected void Application_Start(Object sender, EventArgs e)
        {
            //ʵ���� ʵ���༯
            log4net.Config.XmlConfigurator.Configure();

            //IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;
            IConfigurationSource source = System.Configuration.ConfigurationSettings.GetConfig("activerecord") as IConfigurationSource;

            Assembly assembly = Assembly.Load("HDSZCheckFlow.Entiy");
            ActiveRecordStarter.Initialize(assembly, source);

            //����Զ���ļ��ϴ������� 
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
			
		#region Web ������������ɵĴ���
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.components = new System.ComponentModel.Container();
		}
		#endregion
	}
}

