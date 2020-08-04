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
	/// FuncEdit 的摘要说明。
	/// </summary>
	public class FuncEdit : MyBasePage
	{
		protected XPGrid.XpTreeView trvFunc;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if ((!(IsPostBack))) 
			{ 
				trvFunc.TableName = "xpGrid_Functions"; 
				trvFunc.DataTextField = "FuncName"; 
				trvFunc.DataValueField = "FuncCode"; 
				trvFunc.ParentField = "FuncParent"; 
				trvFunc.RootNodeData = "00"; 
				trvFunc.RootNodeText = "系统菜单列表"; 
				trvFunc.DataBind(); 
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
