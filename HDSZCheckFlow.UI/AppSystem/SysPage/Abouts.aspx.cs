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
	/// About 的摘要说明。
	/// </summary>
	public class Abouts : MyBasePage
	{
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label Label10;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblUserNumber;
		protected System.Web.UI.WebControls.TextBox Message;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label LblUserName;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label LblRoleName;
		protected System.Web.UI.HtmlControls.HtmlGenericControl MessageDiv;
		protected System.Web.UI.HtmlControls.HtmlGenericControl RemindAffair;
		protected System.Web.UI.WebControls.Label Label9;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Page.IsPostBack)) 
			{ 
				BindSystemMessage();
				BindRemindAffair();

				Visitor MyVisitor = new Visitor(); 
				LblUserName.Text = MyVisitor.GetUserName; 
				LblRoleName.Text = MyVisitor.GetUserRole; 
				LblUserNumber.Text = Convert.ToString(MyVisitor.GetOnlineVisitorNum) + " 人"; 


				//Response.Write(Session.Timeout.ToString());

				//Response.Write();
				
			} 
		} 

		private void BindSystemMessage()
		{
			// 绑定系统消息
			DateTime dt=DateTime.Now ;
			string SystemMessage = Bussiness.SystemMessageBLL.GetSystemMessage(dt);
			this.MessageDiv.InnerHtml = SystemMessage ;
		}

		private void BindRemindAffair()
		{
			//提醒事物, 对审批者,提醒有多少单据待审批

			string personCode= Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); //获取用户工号
			int NumOfNaAuditing = Bussiness.ApplyAuditingBLL.GetNaOfAuditing(personCode);
			if(NumOfNaAuditing > 0)
			{
				RemindAffair.InnerHtml = "您有<a href='../../CheckFlow/CheckFlow/MyAuditing.aspx'><font color='red' >"+NumOfNaAuditing.ToString() + "</font></a>个待审批申请单据" ;
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
