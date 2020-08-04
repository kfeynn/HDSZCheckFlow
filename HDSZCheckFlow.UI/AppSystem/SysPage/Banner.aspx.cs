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
using System.Threading;
using System.Globalization;

namespace HDSZCheckFlow.AppSystem.SysPage
{
	/// <summary>
	/// Banner 的摘要说明。
	/// </summary>
	public class Banner : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox starttime;
		protected System.Web.UI.WebControls.TextBox TxtSecond;
		protected System.Web.UI.WebControls.Label TxtLoginTime;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblSystemRootPath;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblUserId;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblAppName;
		protected System.Web.UI.HtmlControls.HtmlImage ImgLogout;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Page.IsPostBack)) 
			{ 
				TxtLoginTime.Text = System.DateTime.Now.ToString(); 
				Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US"); 
				DateTimeFormatInfo myDTFI = new CultureInfo( "en-US", false ).DateTimeFormat;
				System.DateTime currentTime=System.DateTime.Now;
				starttime.Text = myDTFI.MonthNames[currentTime.Month-1].ToString()+" "+currentTime.Day.ToString()+","+currentTime.Year.ToString()+" "+currentTime.Hour.ToString()+":"+currentTime.Minute.ToString()+":"+currentTime.Second.ToString();
				Thread.CurrentThread.CurrentCulture = new CultureInfo(""); 
				Visitor MyVisitor = new Visitor(); 
				lblUserId.InnerText = MyVisitor.GetUserId; 
//				lblAppName.InnerText = MyVisitor.GetAppName; 
				lblSystemRootPath.InnerText = MyVisitor.GetWebSiteRootPath; 
				//Session.Timeout = 500; 


				
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
