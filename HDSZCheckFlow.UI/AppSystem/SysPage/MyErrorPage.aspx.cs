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
	/// MyErrorPage 的摘要说明。
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
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
