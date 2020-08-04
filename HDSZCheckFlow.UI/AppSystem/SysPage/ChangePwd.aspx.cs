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
	/// ChangePwd ��ժҪ˵����
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
							lblErr.Text = "�����޸ĳɹ������ס�����룡"; 
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
						lblErr.Text = "����������������벻����"; 
						lblErr.ForeColor = System.Drawing.Color.Red; 
					} 
				} 
				else 
				{ 
					lblErr.Text = "�������������"; 
					lblErr.ForeColor = System.Drawing.Color.Red; 
				} 
			} 
			else 
			{ 
				lblErr.Text = "�������������"; 
				lblErr.ForeColor = System.Drawing.Color.Red; 
			} 
			db.Close(); 
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
