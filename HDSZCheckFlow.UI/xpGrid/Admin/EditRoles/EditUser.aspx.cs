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

namespace xpGridTest.UI.xpGrid.Admin.EditRoles
{
	/// <summary>
	/// EditUser 的摘要说明。
	/// </summary>
	public class EditUser : MyBasePage
	{
		protected System.Web.UI.WebControls.Button btnSaveUsrInfo;
		protected XPGrid.XpGrid grdUser;
		protected Microsoft.Web.UI.WebControls.TreeView trvRoleTree;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.Label Label4;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (this.IsPostBack & (grdUser.GetEditState() == XPGrid.CEditState.NotInEdit))
			{ 
				trvRoleTree.Visible = false; 
				btnSave.Visible = false; 
			}
			
		}
		private void BuildTree(int userid)
		{
			string selectedIndex = string.Empty;
			if(trvRoleTree.Nodes.Count > 0)
			{
				if(trvRoleTree.SelectedNodeIndex != string.Empty)
					selectedIndex = trvRoleTree.SelectedNodeIndex;
				trvRoleTree.Nodes.Clear();
			}
			Microsoft.Web.UI.WebControls.TreeNode node=new Microsoft.Web.UI.WebControls.TreeNode();
			node.Text ="系统角色树";
			node.NodeData="系统角色树";
			trvRoleTree.Nodes.Add(node);

			XPGrid.Public.CSysUser user = new XPGrid.Public.CSysUser(userid);
			ArrayList arrUserRole = user.GetRole();

			XPGrid.Public.CRole role = new XPGrid.Public.CRole();
			ArrayList arr = role.GetAllRoles();
			foreach(object o in arr)
			{
				XPGrid.Public.CRole r = (XPGrid.Public.CRole)o;
				node = new Microsoft.Web.UI.WebControls.TreeNode();
				node.Text = r.RoleName;
				node.NodeData = r.RoleId.ToString();
				node.CheckBox = true;
				foreach(object u in arrUserRole)
				{
					if(node.NodeData == ((int)u).ToString())
					{
						node.Checked = true;
					}
				}
				trvRoleTree.Nodes[0].Nodes.Add(node);
			}
		}

 		private void btnSave_Click(object sender, System.EventArgs e)
		{
			string[] keys = grdUser.GetSelectedKey();
			if(keys == null)return;

			if(keys.Length > 0)
			{
				ArrayList actors = new ArrayList();
				int userid = int.Parse(keys[0]);
				XPGrid.Public.CSysUser user = new XPGrid.Public.CSysUser(userid);
				foreach(Microsoft.Web.UI.WebControls.TreeNode node in trvRoleTree.Nodes[0].Nodes)
				{
					if(node.Checked)
					{
						actors.Add(int.Parse(node.NodeData));
					}
				}
				user.SetRole(actors);
			}
		}

		
		private void grdUser_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(grdUser.GetEditState() == XPGrid.CEditState.NotInEdit)
			{
				string[] keys = grdUser.GetSelectedKey();
				DBHandler.OleDBHandler dbHand=new DBHandler.OleDBHandler();
				Page CurrentPage = new Page(); 
				if(keys == null || keys.Length == 0)
				{
					trvRoleTree.Nodes.Clear();
					return;
				}
				BuildTree(int.Parse(keys[0]));
				trvRoleTree.Visible = true;
				string SelectString = "Select Max(AllowEdit) From xpGrid_ColumnsInRoles Where RoleId In (Select Distinct RoleId From xpGrid_UsersInRoles Where UserId=" + CurrentPage.User.Identity.Name + ") And ColumnId In (Select Distinct ColumnId From xpGrid_Columns Where TableName='xpGrid_User')"; 
				try 
				{ 
					if ((int)dbHand.ExecuteScalar(SelectString) == 2) 
					{ 
						btnSave.Visible = true; 
					} 
				} 
				catch
				{ 
					btnSave.Visible = false; 
				} 
				dbHand.Close(); 
			}
			else
			{
				trvRoleTree.Visible = false;
				btnSave.Visible = false;
			}
		}

		private void grdUser_BeforeDataBind() 
		{ 
			//Visitor MyVisitor = new Visitor(); 
			//string strMessage = "最大同时在线人数：" + System.Convert.ToString(MyVisitor.GetMaxOnlineVisitorNum) + "人，时间：" + MyVisitor.GetMaxOnlineDateTime + "。"; 
			//grdUser.ShowMessage(strMessage, System.Drawing.Color.Blue); 
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
			this.grdUser.BeforeDataBind += new XPGrid.XpGrid.BeforeDataBindEventHandler(this.grdUser_BeforeDataBind);
			this.grdUser.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.grdUser_SelectedIndexChanged);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	

		
	}
}
