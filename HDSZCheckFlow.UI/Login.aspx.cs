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
using System.Web.Security;

namespace HDSZCheckFlow
{
	/// <summary>
	/// Login 的摘要说明。
	/// </summary>
	public class Login : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.ImageButton ImgBtnLogin;
		protected System.Web.UI.WebControls.TextBox edtPassWord;
		protected System.Web.UI.WebControls.TextBox edtUserName;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.HtmlControls.HtmlImage IMG1;
		protected System.Web.UI.HtmlControls.HtmlImage IMG4;
		protected System.Web.UI.HtmlControls.HtmlImage IMG2;
		protected System.Web.UI.HtmlControls.HtmlGenericControl lblAppName;
		protected System.Web.UI.HtmlControls.HtmlImage IMG3;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Page.IsPostBack)) 
			{ 
                //edtUserName.Attributes["onfocus"] = "selectText();"; 
                //Form1.Attributes["oncontextmenu"] = "NoRightMenu();"; 
                //Form1.Attributes["onselectstart"] = "NoSelect();"; 
			} 
		} 

		private void MyLogin(int iUserId) 
		{ 
			Visitor MyVisitor = new Visitor(); 

			#region 
//			System.Web.Security.FormsAuthentication.SetAuthCookie(iUserId.ToString(),true); // 有待更改过期时间 ,参看http://topic.csdn.net/t/20050816/21/4212709.html

//			Dim   tick   As   FormsAuthenticationTicket   =   New   FormsAuthenticationTicket("验证通过的用户名",False,DateTime.Now.AddMinutes(30))     ''你自己可以看看验证控件的，还有关于这个类的构造函数   
//            objcookie   =   New   HttpCookie(".UserInfo")     ''这里.UserInfo为你<forms   name=".UserInfo"   根据你的name来自己定   
//            objcookie.Value   =   FormsAuthentication.Encrypt(tick)   
//            Response.Cookies.Add(objcookie)   
//			System.Web.Security.FormsAuthenticationTicket tick = new System.Web.Security.FormsAuthenticationTicket(iUserId.ToString(),true,5000);
//			HttpCookie objcookie = new HttpCookie("iUserId");
//			objcookie.Value = System.Web.Security.FormsAuthentication .Encrypt(tick);
//			Response.Cookies.Add(objcookie);


//			System.Web.Security.FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1,iUserId.ToString(),DateTime.Now,DateTime.Now.AddMonths(1),true,"userRoles","/") ; //建立身份验证票对象
//			string HashTicket = FormsAuthentication.Encrypt (Ticket) ; //加密序列化验证票为字符串
//			HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket) ; 
//
//			UserCookie.Expires = DateTime.Now.AddMonths (1);
//			//生成Cookie
//			Context.Response.Cookies.Add (UserCookie) ; //输出Cookie
			#endregion 

			System.Web.Security.FormsAuthentication.RedirectFromLoginPage(iUserId.ToString(), false); 
		} 

		private void ImgBtnLogin_Click(object sender, System.Web.UI.ImageClickEventArgs e) 
		{ 
			int iUserID; 
			XPGrid.Public.CSysUser iUser; 
			Visitor MyVisitor = new Visitor(); 
			string InputUserName; 
			InputUserName = edtUserName.Text.Trim(); 
			if ((!(MyVisitor.GetSystemEnable)) & (InputUserName.ToUpper() != "ADMIN")) 
			{ 
				Message.Text = "对不起，系统维护中，暂停使用！"; 
				return; 
			} 
			iUser = new XPGrid.Public.CSysUser(0); 
			iUserID = iUser.Login(InputUserName, edtPassWord.Text); 
			if ((iUserID <= -1)) 
			{ 
				Message.Text = "对不起，用户名或密码错误！"; 
				return; 
			} 
//			if (MyVisitor.VisitorOnLine(InputUserName) & InputUserName.ToUpper() != "ADMIN" & InputUserName.ToUpper()!="TEST") 
//			{ 
//				Message.Text = "对不起，此用户已在别处登陆。 " + "如非法退出，请10分钟后再试！"; 
//				return; 
//			} 
			if (InputUserName.ToUpper() == "ADMIN") 
			{ 
				MyVisitor.SetVisitorState(InputUserName.Trim(), "On"); 
				MyLogin(iUserID); 
				return; 
			} 
			MyVisitor.SetVisitorState(InputUserName.Trim(), "On"); 
			MyLogin(iUserID); 
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
			this.ImgBtnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.ImgBtnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
