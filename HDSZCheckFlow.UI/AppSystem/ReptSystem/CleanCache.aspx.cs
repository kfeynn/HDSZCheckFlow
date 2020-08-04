using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HDSZCheckFlow.AppSystem.ReptSystem
{
	/// <summary>
	/// CleanCache ��ժҪ˵����
	/// </summary>
	public class CleanCache : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblWelAppName;
		protected System.Web.UI.WebControls.Label Label2;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			Visitor MyVisitor = new Visitor(); 
			lblWelAppName.Text = "��л��ʹ��" + MyVisitor.GetAppName; 
			string innerCacheName = Request["CacheName"].Trim(); 
			if (!(innerCacheName == "")) 
			{ 
				Cache.Remove(innerCacheName); 
			} 
		}


		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
