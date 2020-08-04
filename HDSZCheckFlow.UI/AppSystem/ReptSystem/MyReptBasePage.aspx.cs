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

namespace HDSZCheckFlow.AppSystem.ReptSystem
{
	public class MyReptBasePage : MyBasePage
	{
		private DataSet MyDataSet; 

		public DataSet ReptData 
		{ 
			get 
			{ 
				return MyDataSet; 
			} 
			set 
			{ 
				MyDataSet = value; 
			} 
		}

		private void Page_Load(object sender, System.EventArgs e) 
		{ 
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
			//MyString = MyString + "<!--<LINK href=" + "\"" + CssFile + "\"" + " type=" + "\"" + "text/css" + "\"" + " rel=" + "\"" + "stylesheet" + "\"" + ">-->"; 
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
			MyString = MyString + "<img src=" + "\"" + SystemRootPath + "AppSystem/Images/gradbottom.jpg" + "\"" + " style=" + "\"" + "border-style:None;height:7px;width:250px;Z-INDEX: 997; LEFT: 589px; POSITION: absolute; TOP: 522px" + "\"" + "/>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "<img src=" + "\"" + SystemRootPath + "AppSystem/Images/gradright.jpg" + "\"" + " style=" + "\"" + "border-style:None;height:500px;width:7px;Z-INDEX: 996; LEFT: 836px; POSITION: absolute; TOP: 29px" + "\"" + "/>"; 
			MyString = MyString + EnterStr; 
			writer.Write(MyString); 
			base.Render(writer); 
			MyString = "</body>"; 
			MyString = MyString + EnterStr; 
			MyString = MyString + "</html>"; 
			writer.Write(MyString); 
			Response.Write(MyString);
			
			
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
