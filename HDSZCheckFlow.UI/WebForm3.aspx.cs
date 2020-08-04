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

namespace HDSZCheckFlow.UI
{
	/// <summary>
	/// WebForm3 的摘要说明。
	/// </summary>
	public class WebForm3 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected FredCK.FCKeditorV2.FCKeditor FCKContent;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack) 
			{
				FCKContent.Value=Server.HtmlDecode("");
				FCKContent.BasePath="/HDSZCheckFlow.UI/FCKeditor/";
				FCKContent.ImageBrowserURL = "/HDSZCheckFlow.UI/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Image&Connector=connectors/aspx/connector.aspx";
				FCKContent.LinkBrowserURL = "/HDSZCheckFlow.UI/FCKeditor/editor/filemanager/browser/default/browser.html?Connector=connectors/aspx/connector.aspx";
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			this.TextBox1.Text=this.FCKContent.Value;
//			Bussiness.MailBLL mialBll=new HDSZCheckFlow.Bussiness.MailBLL();
//			mialBll.SendMail("zheng-yuanqiang@hdsz.hitachi-displays.com","中文乱",this.FCKContent.Value );


		}
	}
}
