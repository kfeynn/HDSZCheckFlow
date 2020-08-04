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
	/// LogOut 的摘要说明。
	/// </summary>
	public class LogOut : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblWelAppName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.TextBox LoadFlag;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			// 在此处放置用户代码以初始化页面
			Response.Cache.SetCacheability(HttpCacheability.NoCache); 
			Visitor MyVisitor = new Visitor(); 
			
			//lblWelAppName.Text = "感谢您使用" + MyVisitor.GetAppName; 
			MyVisitor.SetVisitorState(Page.Request["UserId"].Trim(), "Off"); 

		//	MyVisitor.SetVisitorState(User.Identity.Name , "Off"); 

			System.Web.Security.FormsAuthentication.SignOut(); 
			Session.Abandon(); 
			LoadFlag.Text = "1";

			// 2008-10- 16 add
			//Response.Redirect("../Login.aspx");
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
