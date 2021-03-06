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

namespace HDSZCheckFlow.UI.Asset.PrintApply.PriceCheck
{
	/// <summary>
	/// PrintPage 的摘要说明。
	/// </summary>
	public class PrintPage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgHead;
		protected System.Web.UI.WebControls.DataGrid dgRecord;
		protected System.Web.UI.WebControls.DataGrid dgBody;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string applyHeadPK=GetQuery("applyPK");


				//为url解密 
				applyHeadPK =Common.Security.Cryptography.Decrypt(applyHeadPK );
				if(applyHeadPK!=null  && !"".Equals(applyHeadPK))
				{
					DataSet ds= GetApplyPrintInfo(int.Parse(applyHeadPK));//Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));

					//Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
					//Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					//applyHead = null;
					//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
					Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

					//报表路径取数据库中存放的值
					rptHelper.ExportToPDF(Server.MapPath(/*"Report\\" + applyType.Report.Trim()*/"Report\\ReporForAssetPriceCheckMain.rpt"/* + applyType.Report.Trim() + ""*/),ds,"c:\\ReportForBudget\\test.pdf");   
 
					//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   

					rptHelper.ReturnPDF(Server.MapPath(/*"Report\\" + applyType.Report.Trim()*/"Report\\ReporForAssetPriceCheckMain.rpt" /*+ applyType.Report.Trim() + ""*/),ds,this);   


				}
			} 
		}


		/// <summary>
		/// 构造报表需要的数据集
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		private  DataSet GetApplyPrintInfo(int finallyCheckId)
		{
			DataSet ds=new DataSet();
			
			//表头信息
			DataSet ds_Head = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_Asset_FinallyPriceCheck_HeadPrintInfo"," where FId="+finallyCheckId);
			ds_Head.Tables[0].TableName = "dt1";
						//dgHead.DataSource=ds_Head;
						//dgHead.DataBind();

			string fields="SubjectName2  as  SubjectName,InventoryName,InvType,FinallyPrice,FNumber,FCheckMoney,originalMoney,unitName,Offer,Remark,ExchangeRate,currTypeCode";
			//表体信息
			DataSet ds_Body = Bussiness.ComQuaryBLL.ExecutebyQuery("select " +fields+ " from v_AssetBody_CheckBody where FId="+finallyCheckId);//GetDataSetByViewAndQuery("v_AssetBody_CheckBody"," where FId="+finallyCheckId);
			ds_Body.Tables[0].TableName = "dt2";
						//dgBody.DataSource=ds_Body;
						//dgBody.DataBind();

			//审批信息
			DataSet ds_Record=Bussiness.ApplyAuditingBLL.GetApplyRecordForFinallyCheck(finallyCheckId); 
			ds_Record.Tables[0].TableName = "dt3";
						//dgRecord.DataSource=ds_Record;
						//dgRecord.DataBind();


			ds.Tables.Add(ds_Head.Tables["dt1"].Copy());
			ds.Tables.Add(ds_Body.Tables["dt2"].Copy());
			ds.Tables.Add(ds_Record.Tables["dt3"].Copy());

			ds.Tables[0].TableName = "FinallyPriceCheck_ApplyHeadInfo";
			ds.Tables[1].TableName = "FinallyPriceCheck_ApplyBodyInfo";
			ds.Tables[2].TableName = "FinallyPriceCheck_ApplyRecordInfo";
			
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
