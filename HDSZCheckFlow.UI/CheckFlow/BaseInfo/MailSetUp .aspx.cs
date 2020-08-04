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
using entiy=HDSZCheckFlow.Entiy;
namespace HDSZCheckFlow.UI.CheckFlow.BaseInfo
{
	/// <summary>
	/// MailSetUp_ 的摘要说明。
	/// </summary>
	public class MailSetUp_ : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtNickName;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.Button btnDetermine;
		protected System.Web.UI.WebControls.CheckBox Checkbox2;
		protected System.Web.UI.WebControls.Button btnClose;
		protected System.Web.UI.WebControls.Button btnUpdate;
		protected System.Web.UI.WebControls.TextBox txtCode1;
		protected System.Web.UI.WebControls.TextBox txtName1;
		protected System.Web.UI.WebControls.TextBox txtAddress1;
		protected System.Web.UI.WebControls.TextBox txtNickName1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl UpShow;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Up;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtCode;
		protected System.Web.UI.WebControls.Table Table1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//Response.Write(User.Identity.Name );获取xpGrid_User ID
			// 在此处放置用户代码以初始化页面
			//初始化基本数据
			if(!Page.IsPostBack)
			{
				loadMain();
			}
			
			
		}

		private void loadMain(){
			int CodeId = Convert.ToInt32( User.Identity.Name);
			entiy.BaseEmail email =	HDSZCheckFlow.Bussiness.MailSetUpBLL.selectDuget(CodeId);
			if(email != null)
			{
				this.txtCode1.Text = email.PersonCode;
				this.txtAddress1.Text = email.Email;
				this.txtNickName1.Text = email.NickName;
				this.txtName1.Text = email.Name;
				//根据现有的数据进行显示
				this.Checkbox2.Checked =Convert.ToInt32( email.IsAccept) == 0 ? false : true ;
				CloseMain();
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
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			this.btnDetermine.Click += new System.EventHandler(this.btnDetermine_Click);
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
		
		/// <summary>
		/// 修改邮件信息
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDetermine_Click(object sender, System.EventArgs e)
		{

			

			entiy.BaseEmail email = new HDSZCheckFlow.Entiy.BaseEmail();
			email.PersonCode =this.txtCode.Text;
			email.Email =this.txtAddress.Text ;
			email.NickName =this.txtNickName.Text ;
			email.Name =this.txtName.Text ;
			//根据现有的数据进行显示
			email.IsAccept =  this.Checkbox2.Checked == true ?  0 : 1 ;
			int i = HDSZCheckFlow.Bussiness.MailSetUpBLL.UpdateEmail(email);
			if(i <= 0)
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text = "修改失败！";
				CloseMain();
			}
			else
			{
				this.lblMessage.Visible = true;
				this.lblMessage.Text = "修改成功！";
				loadMain();
			
			}
			
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnUpdate_Click(object sender, System.EventArgs e)
		{
			this.txtCode.Text =	this.txtCode1.Text;
			this.txtAddress.Text =  this.txtAddress1.Text;
			this.txtNickName.Text= this.txtNickName1.Text;
			this.txtName.Text=	this.txtName1.Text;
			this.CheckBox1.Checked = this.Checkbox2.Checked; 
			UpdateMain();
		}
		
		private void UpdateMain()
		{
			this.UpShow.Visible = false;
			this.Up.Visible = true;
			
			
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{
			CloseMain();
			this.lblMessage.Text = "";
		}

		private void CloseMain()
		{
			this.UpShow.Visible = true;
			this.Up.Visible =false ;
			
		}

		
	}
}
