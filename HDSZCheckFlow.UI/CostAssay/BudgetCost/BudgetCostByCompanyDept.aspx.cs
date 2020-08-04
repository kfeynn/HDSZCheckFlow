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
	/// BudgetCostByCompanyDept 的摘要说明。
	/// </summary>
	public class BudgetCostByCompanyDept : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnOutPrint;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnOutPrint.Click += new System.EventHandler(this.btnOutPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			
			//获取预实算信息（按部门区分）
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="请输入查询年月";
				return ;
			}
			DateTime dt=DateTime.Parse(this.txtDate.Text);

			if(dt.Month <=6 )
			{
				this.DataGrid1.Columns[1].HeaderText="1Q预算";
				this.DataGrid1.Columns[2].HeaderText="2Q预算";
				this.DataGrid1.Columns[3].HeaderText="1H预算";
			}
			else
			{
				this.DataGrid1.Columns[1].HeaderText="3Q预算";
				this.DataGrid1.Columns[2].HeaderText="4Q预算";
				this.DataGrid1.Columns[3].HeaderText="2H预算";
			}

			DataSet ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();
			this.Button1.Visible=true;

		
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定时候,判断unionType 为 1时.表示为 合计项目,标识为黄色,醒目
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)    //项，交替项 
			{
				DataSet ds=this.DataGrid1.DataSource as DataSet ;
				if(ds!=null)
				{
					if("1".Equals(ds.Tables[0].Rows[e.Item.ItemIndex]["unionType"].ToString()))
					{
						//this.DataGrid1.Items[e.Item.ItemIndex-1].BackColor=Color.Yellow;
						e.Item.BackColor=Color.Yellow;
					}
				}
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.DataGrid1);
		}

		private void btnOutPrint_Click(object sender, System.EventArgs e)
		{

			//获取预实算信息（按部门区分）
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="请输入查询年月";
				return ;
			}

			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=1&QueryDate=" + this.txtDate.Text + " ');</script>");

			#region 
//			DateTime dt=DateTime.Parse(this.txtDate.Text);
//
//
//			DataSet ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
//			ds.Tables[0].TableName = "BudgetCostInfoMation";
//
//
//			//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
//			Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
//
//			//报表路径取数据库中存放的值
//			rptHelper.ExportToPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,"c:\\test.pdf");   
//
//			//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   
//
//			rptHelper.ReturnPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,this);   
			#endregion 
		
		}
	}
}
