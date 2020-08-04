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

namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// BudgetInfoNew 的摘要说明。
	/// </summary>
	public class BudgetInfoNew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlAccBook;
		protected System.Web.UI.WebControls.DataGrid dgBudgetInfo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			//绑定帐套
			if(!Page.IsPostBack)
			{
				BindAccBook();
			}

		}
	

		private void BindAccBook()
		{
			try
			{

				string AccBookKey = System.Configuration.ConfigurationSettings.AppSettings["AccBook"];


				DataSet ds = Bussiness.CostBLL.BindAccBook(AccBookKey);
				this.ddlAccBook.DataSource = ds.Tables[0];
				this.ddlAccBook.DataValueField = "Code";
				this.ddlAccBook.DataTextField = "CodeName";
				this.ddlAccBook.DataBind();
			}
			catch(Exception Ex)
			{
				this.lblMessage.Text = "绑定帐套出错！" + Ex.Message ;
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.dgBudgetInfo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetInfo_ItemDataBound);
			this.dgBudgetInfo.SelectedIndexChanged += new System.EventHandler(this.dgBudgetInfo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindBudgetInfo();

		
		}

		private void BindBudgetInfo()
		{
			this.lblMessage.Text ="";
			if("".Equals(this.txtDate.Text ))
			{
				this.lblMessage.Text = "请选择日期查询!";
				this.lblMessage.ForeColor=Color.Red;
				return ;
			}
			DateTime dt= DateTime.Parse(this.txtDate.Text);

			string AccBook = this.ddlAccBook.SelectedValue ; 

			if(AccBook == "")
			{
				this.lblMessage .Text = "请选择帐套";
				return ;
			}




			string QueryType = this.ddlType.SelectedValue.Trim() ;
			string Proc = "";

			switch ( QueryType )
			{
				case "1001":      // 预算信息一览表

					Proc = "p_GetBudgetByQuerter";

					break;

				case "1002":      // 实算信息一览表
					Proc = "p_GetCostByMonth";

					break;
				case "1003":      // 实算累计一览表
					Proc ="p_GetCostByMonthAddUp";

					break;
				case "1004":
					Proc = "p_GetBudgetByMonth_Cost";

					break;
			}


			DataSet ds = Bussiness.CostBLL.GetProcInfo(Proc,dt.Year,dt.Month,AccBook );
			this.dgBudgetInfo.DataSource = ds;
			this.dgBudgetInfo.DataBind();







		}

		private void dgBudgetInfo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定时候 表示为 合计项目,标识为黄色,醒目
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)    //项，交替项 
			{
				DataSet ds=this.dgBudgetInfo.DataSource as DataSet ;
				if(ds!=null)
				{

					//固定样式
					e.Item.Cells[0].CssClass = "scrollRowThead";
					e.Item.Cells[1].CssClass = "scrollRowThead";


					//醒目标志
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("总计")>-1 )
					{
						e.Item.BackColor=Color.Yellow;
					}
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("合计")>-1)
					{
						e.Item.BackColor=Color.GreenYellow ;
					}
					//第三列以后的数据靠右靠齐
					if(ds.Tables[0].Columns.Count >3)
					{
						for(int i=3;i<ds.Tables[0].Columns.Count ;i++)
						{
							e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
						}
					}






				}
			}
			//固定样式.
			if(e.Item.ItemType==ListItemType.Header  )    //项，交替项 
			{
				e.Item.CssClass = "scrollColThead";
				e.Item.Cells [0].CssClass = "scrollRowThead  scrollCR";
				e.Item.Cells [1].CssClass = "scrollRowThead  scrollCR";

			}




		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgBudgetInfo);
		}

		private void dgBudgetInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
