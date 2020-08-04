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
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace HDSZCheckFlow.UI
{
	/// <summary>
	/// WebForm5 ��ժҪ˵����
	/// </summary>
	public class WebForm5 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected CrystalDecisions.Web.CrystalReportViewer CrystalReportViewer1;
		private   CrystalDecisions.CrystalReports.Engine.ReportDocument   ReportDoc;   
		private   TableLogOnInfo   logOnInfo;   
		private   DiskFileDestinationOptions   FileOPS;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button2;   
		private   ExportOptions   ExOPS;  

		public   WebForm5()   
		{   
			//   
			//   TODO:   �ڴ˴���ӹ��캯���߼�   
			//   
			ReportDoc=new   ReportDocument();   
			logOnInfo=new   TableLogOnInfo();   
			FileOPS=new   DiskFileDestinationOptions();   
		} 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		///   <summary>   
		///   ���������ļ�ΪPDF��ʽ   
		///   </summary>   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="PDFFileName">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>   
		///   <returns>bool�ɹ�����true,ʧ�ܷ���false</returns>   
		public   bool   ExportToPDF(string   ReportFile,object   ReportDataSource,string   PDFFileName)   
		{   
			try   
			{   
				DataSet  dss = (DataSet)ReportDataSource ; 

				Response.Write(dss.Tables[0].Rows.Count.ToString());
				ReportDoc.Load(ReportFile);   
				//ReportDoc.SetDataSource(ReportDataSource);   


				logOnInfo.ConnectionInfo.ServerName = "localhost"; 
				logOnInfo.ConnectionInfo.DatabaseName = "checkFlowData"; 
				logOnInfo.ConnectionInfo.UserID = "sa"; 
				logOnInfo.ConnectionInfo.Password = "dirrid"; 
				ReportDoc.Database.Tables [0].ApplyLogOnInfo(logOnInfo); 


				//				FileOPS.DiskFileName=PDFFileName;   
				//				ExOPS=ReportDoc.ExportOptions;   
				//				ExOPS.DestinationOptions=FileOPS;   
				//				ExOPS.ExportDestinationType=CrystalDecisions.Shared.ExportDestinationType.DiskFile;   
				//				ExOPS.ExportFormatType=CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;   
				//				ReportDoc.Export();   

				
				this.CrystalReportViewer1.ReportSource= ReportDoc ;
				this.CrystalReportViewer1.DataBind();
				
				return   true;   
			}   
			catch   (Exception ex)
			{   
				Response.Write(ex.ToString());
				return   false;   
			}   
		}   
		///   <summary>   
		///   ���������ļ���Excel��ʽ   
		///   </summary>   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="ExcelFileName">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>   
		///   <returns>�ɹ�����trueʧ�ܷ���false</returns>   
		public   bool   ExportToExcel(string   ReportFile,object   ReportDataSource,string   ExcelFileName)   
		{   
			try   
			{   
				ReportDoc.Load(ReportFile);   
				ReportDoc.SetDataSource(ReportDataSource);   


				logOnInfo.ConnectionInfo.ServerName = "localhost"; 
				logOnInfo.ConnectionInfo.DatabaseName = "flowSystem"; 
				logOnInfo.ConnectionInfo.UserID = "sa"; 
				logOnInfo.ConnectionInfo.Password = "dirrid"; 
				ReportDoc.Database.Tables [0].ApplyLogOnInfo(logOnInfo); 

				FileOPS.DiskFileName=ExcelFileName;   
				ExOPS=ReportDoc.ExportOptions;   
				ExOPS.DestinationOptions=FileOPS;   
				ExOPS.ExportDestinationType=CrystalDecisions.Shared.ExportDestinationType.DiskFile;   
				ExOPS.ExportFormatType=CrystalDecisions.Shared.ExportFormatType.Excel;   
				ReportDoc.Export();   
				return   true;   
			}   
			catch   
			{   
				return   false;   
			}   
		}   
		///   <summary>   
		///   ����PDF�ļ����û���IE�������   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="page">������ʾPDF   WebForm</param>   
		///   <returns></returns>   
		public   bool   ReturnPDF(string   ReportFile,object   ReportDataSource,System.Web.UI.Page   page)   
		{   
			int   temp;   
			temp=System.Convert.ToInt32(System.DateTime.Now.Millisecond.ToString());   
			System.Random   ra=new   System.Random(temp);   
			int   TmpNumber=ra.Next();   
			string   TmpPDFFileName="c:\\"+System.Convert.ToString(TmpNumber)+".pdf";   
			if   (ExportToPDF(ReportFile,ReportDataSource,TmpPDFFileName)==true)   
			{   
				page.Response.ClearContent();   
				page.Response.ClearHeaders();   
				page.Response.ContentType="application/pdf";   
				page.Response.WriteFile(TmpPDFFileName);   
				page.Response.Flush();   
				page.Response.Close();   
				System.IO.File.Delete(TmpPDFFileName);   
				return   true;   
			}   
			else   
			{   
				return   false;   
			}   
		}   
		///   <summary>   
		///   ����Excel�ļ����û���IE�������   
		///   </summary>   
		///   <param   name="ReportFile"></param>   
		///   <param   name="ReportDataSource"></param>   
		///   <param   name="page"></param>   
		///   <returns></returns>   
		public   bool   ReturnExcel(string   ReportFile,object   ReportDataSource,System.Web.UI.Page   page)   
		{   
			int   temp;   
			temp=System.Convert.ToInt32(System.DateTime.Now.Millisecond.ToString());   
			System.Random   ra=new   System.Random(temp);   
			int   TmpNumber=ra.Next();   
			string   TmpExcelFileName="c:\\"+System.Convert.ToString(TmpNumber)+".xls";   
			if   (ExportToExcel(ReportFile,ReportDataSource,TmpExcelFileName)==true)   
			{   
				page.Response.ClearContent();   
				page.Response.ClearHeaders();   
				page.Response.ContentType="application/xls";   
				page.Response.WriteFile(TmpExcelFileName);   
				page.Response.Flush();   
				page.Response.Close();   
				System.IO.File.Delete(TmpExcelFileName);   
				return   true;   
			}   
			else   
			{   
				return   false;   
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.CrystalReportViewer1.Search += new CrystalDecisions.Web.SearchEventHandler(this.CrystalReportViewer1_Search);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				
				DataSet ds=Bussiness.Class1.getDataSet();

				this.DataGrid1.DataSource=ds;
				this.DataGrid1.DataBind();


				//				ReportDoc.Load(Server.MapPath("CrystalReport1.rpt"));   
				//				ReportDoc.SetDataSource(ds);   
				//				ReportDoc.Refresh();

				ReportDoc =new ReportDocument();

				ReportDoc.Load(Server.MapPath("CrystalReport1.rpt"));


				DataTable CheckRole = ds.Tables[0];
				DataTable CheckRoleInPerson =ds.Tables[1];


				ReportDoc.SetDataSource(CheckRole);
				ReportDoc.SetDataSource(CheckRoleInPerson);

				//				CrystalReport1 ocr=new CrystalReport1();   
				//				ocr.SetDataSource(ds);   
				//				ocr.Refresh();

				this.CrystalReportViewer1.ReportSource=ReportDoc; 
				this.CrystalReportViewer1.DataBind();

				//
				//				CrystalReport1 crp=new CrystalReport1();
				//				//crp.Load("CrystalReport1.rpt");   
				//				crp.SetDataSource(ds);
				//				
				//
				//				this.CrystalReportViewer1.ReportSource=crp ;
				//				this.CrystalReportViewer1.DataBind();

		
				//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
				//ExportToPDF(Server.MapPath("CrystalReport1.rpt"),ds,"c:\\test.pdf");   
				//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   
				//	ReturnPDF(Server.MapPath("Report1.rpt"),ds,this);   
				//------����Excel�����ص�IE�еķ�����������ͬ���ֱ����ExportToExcel��ReturnExcel����--------   
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		private void CrystalReportViewer1_Search(object source, CrystalDecisions.Web.SearchEventArgs e)
		{
		
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				string applyHeadPK = "163";
				//DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));\
				DataSet ds=Bussiness.ApplyAuditingBLL.GetBudgetInfoByApplyHeadPk(int.Parse(applyHeadPK));

				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
				Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
				applyHead = null;
				//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

				//����·��ȡ���ݿ��д�ŵ�ֵ
				rptHelper.ExportToPDF(Server.MapPath("CrystalReport1.rpt"),ds,"c:\\test.pdf");   

				//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   

				rptHelper.ReturnPDF(Server.MapPath("CrystalReport1.rpt"),ds,this);   
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}

		}
	}
}
