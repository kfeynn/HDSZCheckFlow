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

namespace HDSZCheckFlow.UI.Asset.PrintApply
{
	/// <summary>
	/// PrintPage 的摘要说明。
	/// </summary>
	public class PrintPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgHead;
		protected System.Web.UI.WebControls.DataGrid dgBudget;
		protected System.Web.UI.WebControls.DataGrid dgBody;
		protected System.Web.UI.WebControls.DataGrid dgRecord;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string applyHeadPK=GetQuery("applyPK");
				//为url解密 
				applyHeadPK = Common.Security.Cryptography.Decrypt(applyHeadPK );
				if(applyHeadPK!=null  && !"".Equals(applyHeadPK))
				{
					DataSet ds= GetApplyPrintInfo(int.Parse(applyHeadPK));//Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));

					//dgHead.DataSource=ds.Tables[2];
					//dgHead.DataBind();


					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
					Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					applyHead = null;
					//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
					Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

					//报表路径取数据库中存放的值
                    rptHelper.ExportToPDF(Server.MapPath("Report\\" + applyType.Report.Trim()/*"Report\\ReportForAssetApply_Head.rpt" + applyType.Report.Trim() + ""*/), ds, "c:\\ReportForBudget\\test.pdf");
                    // ??? // rptHelper.ExportToPDF(Server.MapPath(/*"Report\\" + applyType.Report.Trim()*/"Report\\CrystalReport1.rpt"/* + applyType.Report.Trim() + ""*/), ds, "c:\\ReportForBudget\\test.pdf");

					//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   

                    rptHelper.ReturnPDF(Server.MapPath("Report\\" + applyType.Report.Trim()/*"Report\\ReportForAssetApply_Head.rpt" + applyType.Report.Trim() + ""*/), ds, this);   
                    //  ??   //rptHelper.ReturnPDF(Server.MapPath("Report\\CrystalReport1.rpt"  /*"Report\\ReportForAssetApply_Head.rpt" + applyType.Report.Trim() + ""*/), ds, this);   


				}
			} 
		}


		/// <summary>
		/// 构造报表需要的数据集
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		private  DataSet GetApplyPrintInfo(int applyHeadPK)
		{
			DataSet ds=new DataSet();
			
			//表头信息
			DataSet ds_Head = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_Asset_ApplyHeadInfo"," where ApplySheetHead_Pk="+applyHeadPK);
			ds_Head.Tables[0].TableName = "dt1";
			//dgHead.DataSource=ds_Head;
			//dgHead.DataBind();


			//表体信息
			DataSet ds_Body = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_Asset_ApplySheet_Body"," where applysheetHead_pk="+applyHeadPK);
			ds_Body.Tables[0].TableName = "dt2";
			//dgBody.DataSource=ds_Body;
			//dgBody.DataBind();

			//预算信息
			DataSet ds_Budget = Bussiness.AssetBudgetBll.SelectAssetBudgetByApplyHeadKey(applyHeadPK);
			ds_Budget.Tables[0].TableName = "dt3";
			//dgBudget.DataSource=ds_Budget;
			//dgBudget.DataBind();

			//审批信息
			DataSet ds_Record=Bussiness.ApplyAuditingBLL.GetApplyRecord(applyHeadPK);
			ds_Record.Tables[0].TableName = "dt4";
			//dgRecord.DataSource=ds_Record;
			//dgRecord.DataBind();


			ds.Tables.Add(ds_Head.Tables["dt1"].Copy());
			ds.Tables.Add(ds_Body.Tables["dt2"].Copy());
			ds.Tables.Add(ds_Budget.Tables["dt3"].Copy());
			ds.Tables.Add(ds_Record.Tables["dt4"].Copy());

			ds.Tables[0].TableName = "ApplyHeadInfo";
			ds.Tables[1].TableName = "ApplyBodyInfo";
			ds.Tables[2].TableName = "ApplyBudgetInfo";
			ds.Tables[3].TableName = "ApplyRecordInfo";
			
			return ds;
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
