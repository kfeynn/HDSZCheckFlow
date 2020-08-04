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
using AjaxPro;

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ChangeMyFlowRole 的摘要说明。
	/// </summary>
	public class ChangeMyFlowRole_J : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnSure;
		protected System.Web.UI.WebControls.TextBox txtPerson;
		protected System.Web.UI.WebControls.TextBox txtPersonName;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblRoleState;
		protected System.Web.UI.WebControls.Button btnGetBackRole;
		protected System.Web.UI.WebControls.Button btnGiveUp;
		protected System.Web.UI.WebControls.Table tblMyRole;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(ChangeMyFlowRole));

			MyRoleState();

			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				BindMyRole();
			}
		}

		#region  ajax方法,供页面查询用户姓名
		[AjaxMethod()]
		public string  GetUserNameByCode(string personCode)
		{
			try
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person!=null)
				{
					return person.Name;
				}
				else
				{
					return "";
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
				return "";
			}
		}
		#endregion 

		private void BindMyRole()
		{
			try
			{
				//将用户角色取得后,加载到 服务端Table

				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

				//2. 公司内有关角色
				Entiy.CheckPersonInRole[] PersonInRoles=Entiy.CheckPersonInRole.FindByUserCode(myCode);
				if(PersonInRoles!=null && PersonInRoles.Length>0)
				{
					foreach(Entiy.CheckPersonInRole personInRole in PersonInRoles)
					{
						TableRow  tr = new TableRow ();
						TableCell tc = new TableCell();
						Entiy.CheckRole checkRole=Entiy.CheckRole.Find(personInRole.CheckRoleCode);
						if(checkRole!=null && checkRole.CheckRoleName!=null)
						{
							tc.Text =checkRole.CheckRoleName;
						}
						tr.Cells.Add(tc);
						this.tblMyRole.Rows.Add(tr);
						tc = null;
						tr = null;
					}
				}
				else
				{
					//1. 部门内有关角色
					Entiy.CheckFlowInDept[] flowInDepts=Entiy.CheckFlowInDept.FindCheckFlowInDeptByUserCode(myCode);
					if(flowInDepts !=null && flowInDepts.Length>0)
					{
						foreach(Entiy.CheckFlowInDept flowInDept in flowInDepts)
						{
							TableRow  tr = new TableRow ();
							TableCell tc = new TableCell();
							Entiy.CheckRole checkRole=Entiy.CheckRole.Find(flowInDept.CheckRoleCode);
							if(checkRole!=null && checkRole.CheckRoleName!=null)
							{
								tc.Text =checkRole.CheckRoleName;
							}
							tr.Cells.Add(tc);
							this.tblMyRole.Rows.Add(tr);
							tc = null;
							tr = null;
						}
					}
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.ChangeMyFlowRole.BindMyRole",ex.Message );
			}
		}



		private void MyRoleState()
		{
			string myCode =Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

			string myRoleState=Bussiness.UserInfoBLL.MyRoleState(myCode);
			this.lblRoleState.Text= myRoleState;
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
			this.btnSure.Click += new System.EventHandler(this.btnSure_Click);
			this.btnGiveUp.Click += new System.EventHandler(this.btnGiveUp_Click);
			this.btnGetBackRole.Click += new System.EventHandler(this.btnGetBackRole_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnSure_Click(object sender, System.EventArgs e)
		{
			this.lblMessage.Text="";
			if("".Equals(this.txtPerson.Text))
			{
				this.lblMessage.Text="请填写转交给何人";
			}
			else
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(this.txtPerson.Text);
				if(person!=null && person.Name!=null)
				{
					string myCode =Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
					string youCode=this.txtPerson.Text;
					Bussiness.UserInfoBLL.GetSetChangeRoles(myCode,youCode,1);

					Bussiness.UserInfoBLL.SetUserGiveUp(myCode,0);

					this.lblMessage.Text="OK!转交权限成功";
					this.lblMessage.ForeColor=Color.Blue;
					MyRoleState();
				}
				else
				{
					this.lblMessage.Text="NO.转交人员不存在!";
				}
			}

			BindMyRole();
		}

		private void btnGetBackRole_Click(object sender, System.EventArgs e)
		{
			string myCode =Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
			Bussiness.UserInfoBLL.GetSetChangeRoles(myCode,"",0);

			Bussiness.UserInfoBLL.SetUserGiveUp(myCode,0);


			this.lblMessage.Text="OK.收回权限成功";
			this.lblMessage.ForeColor=Color.Blue;
			MyRoleState();

			BindMyRole();
		}

		private void btnGiveUp_Click(object sender, System.EventArgs e)
		{
			try
			{
				//选择放弃权限

				//先收回权限
				string myCode =Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
				Bussiness.UserInfoBLL.GetSetChangeRoles(myCode,"",0);

				//设置放弃
				Bussiness.UserInfoBLL.SetUserGiveUp(myCode,1);

				this.lblMessage.Text="OK.设置放弃权限成功";

				MyRoleState();
				BindMyRole();

			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ChangeMyFlowRole.GiveUp",ex.Message );
				this.lblMessage.Text = "NO.设置错误,请联系Mis";
			}

		}




	}
}
