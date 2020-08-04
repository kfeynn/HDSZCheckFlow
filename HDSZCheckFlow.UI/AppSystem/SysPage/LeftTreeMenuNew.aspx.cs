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


namespace HDSZCheckFlow.UI.AppSystem.SysPage
{
	/// <summary>
	/// LeftTreeMenuNew 的摘要说明。
	/// </summary>
	public class LeftTreeMenuNew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Repeater rptParent;
	    protected System.Web.UI.WebControls.Repeater rptChildren;


		public int count = 0;
		

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			
			if(!Page.IsPostBack )
			{

				MyDataBind();
			}
		}


		//数据绑定
		public void MyDataBind()
		{
			DataSet ds = CreateDataSet();
			DataTable dt = ds.Tables[0];
			
			DataView dv = new DataView(dt);
			dv.RowFilter = "FuncParent='00'";
			rptParent.DataSource = dv  ;

			rptParent.DataBind();

		}

		
		public DataSet CreateDataSet()
		{
 
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

			Data = Bussiness.ComQuaryBLL.ExecutebyQuery (Query);

			return Data;
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
			this.rptParent.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptParent_ItemDataBound);
			//this.rptChildren.ItemDataBound += new System.Web.UI.WebControls.RepeaterItemEventHandler(this.rptChildren_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		//string sTempList="";
		//父类绑定事件
		protected void rptParent_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{

			//项，交替项 
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)   
			{
				DataRowView row = (DataRowView)e.Item.DataItem;
				DataSet ds = CreateDataSet();
				DataTable dt = ds.Tables[0];
				DataView dv = new DataView(dt);
				dv.RowFilter = "FuncParent='" + row["FuncCode"] + "'";
				Repeater rptChildren = (Repeater)e.Item.FindControl("rptChildren");
				rptChildren.DataSource = dv;
				rptChildren.DataBind();
				count = rptChildren.Items.Count + count;

			}

		}

		//子类绑定事件
		protected void rptChildren_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
		{			
			if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
			{
				//index = e.Item.ItemIndex + count + 1;
			}
		
		}

	


	}
}
