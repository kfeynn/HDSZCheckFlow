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
using System.Text;

	public class MyBasePage : System.Web.UI.Page
	{
		private string _pageTitle;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			Visitor MyVisitor = new Visitor(); 
			if(MyVisitor.GetUserId  != null)
			{
				MyVisitor.UpDateLastOpationTime(MyVisitor.GetUserName); 
			}
		} 

		public string PageTitle
		{ 
			get 
			{ 
				return _pageTitle; 
			} 
			set 
			{ 
				_pageTitle = value; 
			} 
		} 

		protected override void Render(System.Web.UI.HtmlTextWriter writer) 
		{ 
			string MyString = ""; 
			Visitor MyVisitor = new Visitor(); 
			string SystemRootPath = MyVisitor.GetWebSiteRootPath; 
			char HuiChe=(char)13;
			char HuanHang=(char)10;
			string EnterStr=HuiChe.ToString() +HuanHang.ToString() ;
			string CssFile = SystemRootPath + "AppSystem/style.css"; 
			string JsFile1 = SystemRootPath + "AppSystem/JsLib/MyScript.js"; 
			string JsFile2 = SystemRootPath + "AppSystem/JsLib/date.js"; 
			MyString = "<html>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "<head>"; 
			MyString = MyString + "<title>" + PageTitle + "</title>"; 
			MyString = MyString + EnterStr; 
			//MyString = MyString + "<LINK href=" + "\"" + CssFile + "\"" + " type=" + "\"" + "text/css" + "\"" + " rel=" + "\"" + "stylesheet" + "\"" + ">"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "<script language=" + "\"" + "javascript" + "\"" + " src=" + "\"" + JsFile1 + "\"" + " ></script>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "</head>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "<body"; 
			MyString = MyString + " onload=" + "\"" + "FirstInputCtrl();SetFormSize();" + "\""; 
			MyString = MyString + " oncontextmenu=" + "\"" + "NoRightMenu();" + "\""; 
			MyString = MyString + " onselectstart=" + "\"" + "NoSelect();" + "\""; 
			MyString = MyString + " onmousemove=" + "\"" + "SetState();" + "\""; 
			MyString = MyString + " onmousedown=" + "\"" + "SetState();" + "\""; 
			MyString = MyString + " onkeydown=" + "\"" + "setenter();SetState()" + "\""; 
			MyString = MyString + " > "; 
			MyString = MyString + EnterStr; 
			//MyString = MyString + "<!--<img src=" + "\"" + SystemRootPath + "AppSystem/Images/gradtop.jpg" + "\"" + " style=" + "\"" + "border-style:None;height:7px;width:250px;Z-INDEX: 999; LEFT: 10px; POSITION: absolute; TOP: 8px" + "\"" + "/>-->"; 
			MyString = MyString + EnterStr; 
			//MyString = MyString + "<!--<img src=" + "\"" + SystemRootPath + "AppSystem/Images/gradleft.jpg" + "\"" + " style=" + "\"" + "border-style:None;height:500px;width:7px;Z-INDEX: 998; LEFT: 7px; POSITION: absolute; TOP: 8px" + "\"" + "/>-->"; 
			MyString = MyString + EnterStr; 
			writer.Write(MyString); 
			base.Render(writer); 
			MyString = "</body>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "</html>"; 
			writer.Write(MyString); 
			Response.Write(MyString);
			
		 
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


