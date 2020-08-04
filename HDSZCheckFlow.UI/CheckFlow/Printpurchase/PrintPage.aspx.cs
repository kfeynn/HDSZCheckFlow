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

namespace HDSZCheckFlow.UI.CheckFlow.Printpurchase
{
	/// <summary>
	/// PrintPage 的摘要说明。
	/// </summary>
	public class PrintPage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string applyHeadPK=GetQuery("applyPK");
				//为url解密 
				applyHeadPK = Common.Security.Cryptography.Decrypt(applyHeadPK );
				if(applyHeadPK!=null  && !"".Equals(applyHeadPK))
				{
					DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));

					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
					Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					applyHead = null;
					//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
					Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

					//报表路径取数据库中存放的值
					rptHelper.ExportToPDF(Server.MapPath("Report\\" + applyType.ReportForPurshase.Trim() + ""),ds,"c:\\ReportForBudget\\test.pdf");   

					//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   

					rptHelper.ReturnPDF(Server.MapPath("Report\\" + applyType.ReportForPurshase.Trim() + ""),ds,this);   

//					//test.rpt
//
					//报表路径取数据库中存放的值
//					rptHelper.ExportToPDF(Server.MapPath("Report\\test.rpt"),ds,"c:\\test.pdf");   
//
//					//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   
//
//					rptHelper.ReturnPDF(Server.MapPath("Report\\test.rpt"),ds,this);   


				}
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
