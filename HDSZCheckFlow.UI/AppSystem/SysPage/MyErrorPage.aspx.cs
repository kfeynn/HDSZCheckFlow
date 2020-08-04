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
	/// MyErrorPage ��ժҪ˵����
	/// </summary>
	public class MyErrorPage : MyBasePage
	{
		protected System.Web.UI.WebControls.Panel Panel;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.HtmlControls.HtmlImage ImgLogout;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			Visitor MyVisitor = new Visitor(); 
			string TempCommand; 
			DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
			TempCommand = "Insert Into xpGrid_ErrorRecord Values('" + MyVisitor.GetUserName + "','" + Application["MyErrorCode"] + "','" + System.DateTime.Now.ToString() + "','0')"; 
			dbHand.ExecuteNonQuery(TempCommand); 
			dbHand.Close(); 
			Server.ClearError(); 
		} 

		private void btnSave_Click(object sender, System.EventArgs e) 
		{ 
			Response.Redirect("About.Aspx"); 
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
