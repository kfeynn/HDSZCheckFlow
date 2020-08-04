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
	/// Progress 的摘要说明。
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
				lblPercent.Text="Session错误！";
				return; 
			} 
			if (state >= 0 & state < 100) 
			{ 
				lblMessages.Text = "系统正在处理数据，请稍候。。。"; 
				lblProgress.Width = System.Web.UI.WebControls.Unit.Pixel(state * 3); 
				lblPercent.Text = "已完成 " + System.Convert.ToString(state) + "%"; 
				Page.RegisterStartupScript("", "<script>window.setTimeout('window.Form1.submit()',100);</script>"); 
			} 
			if (state >= 100) 
			{ 
				lblProgress.Visible = false; 
				panelBarSide.Visible = false; 
				lblMessages.Text = "正在结束。。。"; 
				Page.RegisterStartupScript("", "<script>window.close();</script>"); 
			} 
		}


		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
