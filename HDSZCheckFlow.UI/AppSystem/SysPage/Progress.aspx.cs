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

namespace HDSZCheckFlow.AppSystem.SysPage
{
	/// <summary>
	/// Progress ��ժҪ˵����
	/// </summary>
	public class Progress : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblPercent;
		protected System.Web.UI.WebControls.Label lblProgress;
		protected System.Web.UI.WebControls.Panel panelBarSide;
		protected System.Web.UI.WebControls.Label lblMessages;
		private int state=0;

		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Session["State"] == null)) 
			{ 
				state = (int)Session["State"]; 
			} 
			else 
			{ 
				lblPercent.Text="Session����";
				return; 
			} 
			if (state >= 0 & state < 100) 
			{ 
				lblMessages.Text = "ϵͳ���ڴ������ݣ����Ժ򡣡���"; 
				lblProgress.Width = System.Web.UI.WebControls.Unit.Pixel(state * 3); 
				lblPercent.Text = "����� " + System.Convert.ToString(state) + "%"; 
				Page.RegisterStartupScript("", "<script>window.setTimeout('window.Form1.submit()',100);</script>"); 
			} 
			if (state >= 100) 
			{ 
				lblProgress.Visible = false; 
				panelBarSide.Visible = false; 
				lblMessages.Text = "���ڽ���������"; 
				Page.RegisterStartupScript("", "<script>window.close();</script>"); 
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
