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
	/// PrintPage ��ժҪ˵����
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
				//Ϊurl���� 
				applyHeadPK = Common.Security.Cryptography.Decrypt(applyHeadPK );
				if(applyHeadPK!=null  && !"".Equals(applyHeadPK))
				{
					DataSet ds= GetApplyPrintInfo(int.Parse(applyHeadPK));//Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));

					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
					Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					applyHead = null;
					//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
					Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

					//����·��ȡ���ݿ��д�ŵ�ֵ
					rptHelper.ExportToPDF(Server.MapPath("Report\\" + applyType.Report.Trim()/*"Report\\ReportForAssetApply_Head.rpt" + applyType.Report.Trim() + ""*/),ds,"c:\\test.pdf");   

					//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   

					rptHelper.ReturnPDF(Server.MapPath("Report\\" + applyType.Report.Trim()/*"Report\\ReportForAssetApply_Head.rpt" + applyType.Report.Trim() + ""*/),ds,this);   


				}
			} 
		}


		/// <summary>
		/// ���챨����Ҫ�����ݼ�
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		private  DataSet GetApplyPrintInfo(int applyHeadPK)
		{
			DataSet ds=new DataSet();
			
			//��ͷ��Ϣ
			DataSet ds_Head = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_Asset_ApplyHeadInfo"," where ApplySheetHead_Pk="+applyHeadPK);
			ds_Head.Tables[0].TableName = "dt1";
//			dgHead.DataSource=ds_Head;
//			dgHead.DataBind();


			//������Ϣ
			DataSet ds_Body = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_Asset_ApplySheet_Body"," where applysheetHead_pk="+applyHeadPK);
			ds_Body.Tables[0].TableName = "dt2";
//			dgBody.DataSource=ds_Body;
//			dgBody.DataBind();

			//Ԥ����Ϣ
			DataSet ds_Budget = Bussiness.AssetBudgetBll.SelectAssetBudgetByApplyHeadKey(applyHeadPK);
			ds_Budget.Tables[0].TableName = "dt3";
//			dgBudget.DataSource=ds_Budget;
//			dgBudget.DataBind();

			//������Ϣ
			DataSet ds_Record=Bussiness.ApplyAuditingBLL.GetApplyRecord(applyHeadPK);
			ds_Record.Tables[0].TableName = "dt4";
//			dgRecord.DataSource=ds_Record;
//			dgRecord.DataBind();


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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
