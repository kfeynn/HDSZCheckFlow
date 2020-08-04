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

namespace xpGridTest.UI.xpGrid
{
	/// <summary>
	/// LogOut ��ժҪ˵����
	/// </summary>
	public class LogOut : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblWelAppName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox LoadFlag;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			// �ڴ˴������û������Գ�ʼ��ҳ��
			Response.Cache.SetCacheability(HttpCacheability.NoCache); 
			Visitor MyVisitor = new Visitor(); 
			
			//lblWelAppName.Text = "��л��ʹ��" + MyVisitor.GetAppName; 
			MyVisitor.SetVisitorState(Page.Request["UserId"].Trim(), "Off"); 

		//	MyVisitor.SetVisitorState(User.Identity.Name , "Off"); 

			System.Web.Security.FormsAuthentication.SignOut(); 
			Session.Abandon(); 
			LoadFlag.Text = "1";

			// 2008-10- 16 add
			//Response.Redirect("../Login.aspx");
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
