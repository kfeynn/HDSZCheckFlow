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
using   System.Web.Services;
    

namespace HDSZCheckFlow.UI
{
	/// <summary>
	/// WebForm7 的摘要说明。
	/// </summary>
	public class WebForm7 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//			Response.Write(Request.Cookies["aa"].Value );
			//			Response.Write(DateTime.Now.ToString());

			Utility.RegisterTypeForAjax(typeof(WebForm7));

			if(!Page.IsPostBack)
			{
				BindGrid();
			}

		}

		#region  ajax方法,供页面查询用户姓名

		[AjaxMethod()]
		public void   UpdateValue(string Id,string Value)
		{
			try
			{
				Entiy.Log Log = Entiy.Log.Find(int.Parse(Id));

				if(Log != null )
				{
					Log.Thread = Value ; 
					Log.Save();
				}
			}
			catch
			{
//				HDSZCheckFlow.Common.Log.Logger.Log("UI.Asset.CheckFlow.AddAssetApply",ex.Message );
//				return "";
			}
		}

		#endregion 





		private void BindGrid()
		{
			string cmdStr = "select * from Log";
			DataSet Ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			if(Ds!= null )
			{
				this.DataGrid1.DataSource = Ds;
				this.DataGrid1.DataBind();
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
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{

			//EditType="TextBox"   添加属性 
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
//				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
//				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认删除吗?');"); 
				e.Item.Cells[1].Attributes.Add("EditType","TextBox");
				e.Item.Cells[2].Attributes.Add("EditType","TextBox");

				//设置为编辑状态

				//this.DataGrid1.EditItemIndex = e.Item.ItemIndex ; 


			}

		
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
//			string Str2="";
//			for(int i= 0 ;i<2 ;i++)
//			{
//				if(Str2.Length > 0 )
//				{
//					Str2 += "," ;
//				}
//				Str2 += this.DataGrid1.Items[i].Cells[2].Text ;
//			}
//			Response.Write(Str2);

		}


		[WebMethod]     
		public static string SayHello2()     
		{     
			return "Hello Ajax!";     
		} 

	
	}
}
