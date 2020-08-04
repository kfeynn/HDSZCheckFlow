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
	/// ChangePwd 的摘要说明。
	/// </summary>
	public class ChangePwd : MyBasePage
	{
		protected System.Web.UI.WebControls.TextBox txtOld;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label LblUserName;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.TextBox txtNew;
		protected System.Web.UI.WebControls.TextBox txtNew2;
		protected System.Web.UI.WebControls.Label lblErr;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.Panel Panel3;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			Visitor MyVisitor = new Visitor(); 
			LblUserName.Text = MyVisitor.GetUserName; 
		} 

		private void btnSave_Click(object sender, System.EventArgs e) 
		{ 
			DBHandler.OleDBHandler db = new DBHandler.OleDBHandler(); 
			object o = db.ExecuteScalar("select Password from xpGrid_User where UserID = " + User.Identity.Name); 
			if (!((o == null)) & !((o == DBNull.Value))) 
			{ 
				if (o.ToString() == txtOld.Text) 
				{ 
					if (txtNew.Text == txtNew2.Text) 
					{ 
						if (db.ExecuteNonQuery("update xpGrid_User set Password = '" + txtNew.Text.Replace("'", "''") + "' where userid = " + User.Identity.Name)) 
						{ 
							lblErr.Text = "密码修改成功，请记住新密码！"; 
							lblErr.ForeColor = System.Drawing.Color.Blue; 
							txtOld.Enabled = false; 
							txtNew.Enabled = false; 
							txtNew2.Enabled = false; 
							btnSave.Enabled = false; 
						} 
						else 
						{ 
							lblErr.Text = db.LastException.Message; 
							lblErr.ForeColor = System.Drawing.Color.Red; 
						} 
					} 
					else 
					{ 
						lblErr.Text = "您两次输入的新密码不符！"; 
						lblErr.ForeColor = System.Drawing.Color.Red; 
					} 
				} 
				else 
				{ 
					lblErr.Text = "旧密码输入错误！"; 
					lblErr.ForeColor = System.Drawing.Color.Red; 
				} 
			} 
			else 
			{ 
				lblErr.Text = "旧密码输入错误！"; 
				lblErr.ForeColor = System.Drawing.Color.Red; 
			} 
			db.Close(); 
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
