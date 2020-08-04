namespace TradeWWW.FCK
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		wuFCK 的摘要说明。
	/// </summary>
	public class wuFCK : System.Web.UI.UserControl
	{
		protected FredCK.FCKeditorV2.FCKeditor content;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 四、在aspx.cs页上 
			//1.赋值 

			content.Value = Server.HtmlDecode("");    //对html字符串进行解码 
			//2.数据库中 
			//保存到数据库中的值 = Server.HtmlEncode(content.Value);   //对字符串进行html编码 
			//3.网站 
			//如果在网站的根目录下要设置一些参数,---有时候可以不用设置，测试一下即可知道了 
			content.BasePath = "/FCKeditor/";
			content.ImageBrowserURL = "/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Image&Connector=connectors/aspx/connector.aspx";

			content.LinkBrowserURL = "/FCKeditor/editor/filemanager/browser/default/browser.html?Connector=connectors/aspx/connector.aspx";

			//结束了，这样就可以用了...
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
