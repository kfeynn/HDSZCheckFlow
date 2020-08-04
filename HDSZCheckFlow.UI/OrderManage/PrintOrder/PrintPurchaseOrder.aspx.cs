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

namespace HDSZCheckFlow.UI.OrderManage.PrintOrder
{
	/// <summary>
	/// PrintPurchaseOrder 的摘要说明。
	/// </summary>
	public class PrintPurchaseOrder : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string OrderId=GetQuery("OrderId");
			//为url解密 
			OrderId = Common.Security.Cryptography.Decrypt(OrderId );
			if(OrderId!=null  && !"".Equals(OrderId))
			{
				DataSet ds=Bussiness.OrderManageBLL.GetOrderInfoForReport(int.Parse(OrderId));

				//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

				//报表路径取数据库中存放的值
				rptHelper.ExportToPDF(Server.MapPath("Report\\ReportForPuchaseOrder.rpt"),ds,"c:\\ReportForBudget\\order.pdf");   

				//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   

				rptHelper.ReturnPDF(Server.MapPath("Report\\ReportForPuchaseOrder.rpt"),ds,this);   

			}
		}

		private string GetQuery(string colString)
		{
			if(Request.QueryString[colString] != null)
			{
				return Request.QueryString[colString].ToString();
			}
			else
			{
				return "";
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
