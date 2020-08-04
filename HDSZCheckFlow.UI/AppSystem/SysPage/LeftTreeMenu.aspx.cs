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
	/// LeftTreeMenu 的摘要说明。
	/// </summary>
	public class LeftTreeMenu : MyBasePage
	{
		protected Microsoft.Web.UI.WebControls.TreeView MyTreeView;
		public DataSet Data;
	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Page.IsPostBack)) 
			{ 
				Data=CreateDataSet(); 
				InitTree(MyTreeView.Nodes, "00"); 
			} 
		} 

		private DataSet CreateDataSet() 
		{ 
			DBHandler.OleDBHandler dbHand = new DBHandler.OleDBHandler(); 
			string TempId = Page.User.Identity.Name; 
			string Query;
			if (Page.User.Identity.Name == "1") 
			{ 
				Query = "Select * From xpGrid_Functions Where Enable=0 Or Enable=2 Order By DisplayOrder,FuncCode"; 
			} 
			else 
			{ 
				Query = "Select * From xpGrid_Functions Where FuncCode In (Select DisTinct FuncCode From xpGrid_FuncsInRoles Where RoleId In (Select RoleId From xpGrid_UsersInRoles Where UserId=" + TempId + ")) and Enable=0 Order By DisplayOrder,FuncCode"; 
			} 
			DataSet Data = new DataSet(); 
			Data = dbHand.ExecuteWithQuery(Query); 
			dbHand.Close(); 
			return Data; 
		} 

	private void InitTree(Microsoft.Web.UI.WebControls.TreeNodeCollection Nds, string parentId) 
		{ 
			Microsoft.Web.UI.WebControls.TreeNode tmpNd; 
			
    		DataRow[] rows = Data.Tables[0].Select("FuncParent='" + parentId + "'"); 
	        foreach (DataRow row in rows) 
			{ 
				tmpNd = new Microsoft.Web.UI.WebControls.TreeNode(); 
				tmpNd.ID = row["FuncCode"].ToString(); 
				tmpNd.Text = row["FuncName"].ToString(); 
				tmpNd.NavigateUrl = row["FuncUrl"].ToString().Trim(); 
				Nds.Add(tmpNd); 
				InitTree(tmpNd.Nodes, tmpNd.ID); 
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
