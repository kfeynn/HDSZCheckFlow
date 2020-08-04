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
	/// Login ��ժҪ˵����
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
//			System.Web.Security.FormsAuthentication.SetAuthCookie(iUserId.ToString(),true); // �д����Ĺ���ʱ�� ,�ο�http://topic.csdn.net/t/20050816/21/4212709.html

//			Dim   tick   As   FormsAuthenticationTicket   =   New   FormsAuthenticationTicket("��֤ͨ�����û���",False,DateTime.Now.AddMinutes(30))     ''���Լ����Կ�����֤�ؼ��ģ����й��������Ĺ��캯��   
//            objcookie   =   New   HttpCookie(".UserInfo")     ''����.UserInfoΪ��<forms   name=".UserInfo"   �������name���Լ���   
//            objcookie.Value   =   FormsAuthentication.Encrypt(tick)   
//            Response.Cookies.Add(objcookie)   
//			System.Web.Security.FormsAuthenticationTicket tick = new System.Web.Security.FormsAuthenticationTicket(iUserId.ToString(),true,5000);
//			HttpCookie objcookie = new HttpCookie("iUserId");
//			objcookie.Value = System.Web.Security.FormsAuthentication .Encrypt(tick);
//			Response.Cookies.Add(objcookie);


//			System.Web.Security.FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1,iUserId.ToString(),DateTime.Now,DateTime.Now.AddMonths(1),true,"userRoles","/") ; //���������֤Ʊ����
//			string HashTicket = FormsAuthentication.Encrypt (Ticket) ; //�������л���֤ƱΪ�ַ���
//			HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket) ; 
//
//			UserCookie.Expires = DateTime.Now.AddMonths (1);
//			//����Cookie
//			Context.Response.Cookies.Add (UserCookie) ; //���Cookie
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
				Message.Text = "�Բ���ϵͳά���У���ͣʹ�ã�"; 
				return; 
			} 
			iUser = new XPGrid.Public.CSysUser(0); 
			iUserID = iUser.Login(InputUserName, edtPassWord.Text); 
			if ((iUserID <= -1)) 
			{ 
				Message.Text = "�Բ����û������������"; 
				return; 
			} 
//			if (MyVisitor.VisitorOnLine(InputUserName) & InputUserName.ToUpper() != "ADMIN" & InputUserName.ToUpper()!="TEST") 
//			{ 
//				Message.Text = "�Բ��𣬴��û����ڱ𴦵�½�� " + "��Ƿ��˳�����10���Ӻ����ԣ�"; 
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
			this.ImgBtnLogin.Click += new System.Web.UI.ImageClickEventHandler(this.ImgBtnLogin_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
