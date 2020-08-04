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
	/// About ��ժҪ˵����
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
				LblUserNumber.Text = Convert.ToString(MyVisitor.GetOnlineVisitorNum) + " ��"; 


				//Response.Write(Session.Timeout.ToString());

				//Response.Write();
				
			} 
		} 

		private void BindSystemMessage()
		{
			// ��ϵͳ��Ϣ
			DateTime dt=DateTime.Now ;
			string SystemMessage = Bussiness.SystemMessageBLL.GetSystemMessage(dt);
			this.MessageDiv.InnerHtml = SystemMessage ;
		}

		private void BindRemindAffair()
		{
			//��������, ��������,�����ж��ٵ��ݴ�����

			string personCode= Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); //��ȡ�û�����
			int NumOfNaAuditing = Bussiness.ApplyAuditingBLL.GetNaOfAuditing(personCode);
			if(NumOfNaAuditing > 0)
			{
				RemindAffair.InnerHtml = "����<a href='../../CheckFlow/CheckFlow/MyAuditing.aspx'><font color='red' >"+NumOfNaAuditing.ToString() + "</font></a>�����������뵥��" ;
			}

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
