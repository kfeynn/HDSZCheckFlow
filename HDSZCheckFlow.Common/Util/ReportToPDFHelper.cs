using System; 
using System.IO; 
using System.Data; 
using System.Web; 
using System.Web.UI; 
using System.Web.UI.WebControls; 
using System.Text; 
using System.Globalization; 
using System.Collections; 
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports.Engine;

namespace HDSZCheckFlow.Common.Util
{
	/// <summary>
	/// ReportToPDFHelper ��ժҪ˵����
	/// </summary>
	public class ReportToPDFHelper
	{

		private CrystalDecisions.CrystalReports.Engine.ReportDocument ReportDoc;   
		private TableLogOnInfo logOnInfo;   
		private DiskFileDestinationOptions FileOPS;
		private ExportOptions ExOPS;  

		public ReportToPDFHelper()
		{
			ReportDoc = new ReportDocument();   
			logOnInfo = new TableLogOnInfo();   
			FileOPS   = new DiskFileDestinationOptions();   
		}

		///   <summary>   
		///   ���������ļ�ΪPDF��ʽ   
		///   </summary>   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="PDFFileName">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>   
		///   <returns>bool�ɹ�����true,ʧ�ܷ���false</returns>   
		public bool ExportToPDF(string ReportFile,object ReportDataSource,string PDFFileName)   
		{   
			try   
			{   

				ReportDoc.Load(ReportFile);   
				ReportDoc.SetDataSource(ReportDataSource);   

				FileOPS.DiskFileName=PDFFileName;   
				ExOPS=ReportDoc.ExportOptions;   
				ExOPS.DestinationOptions=FileOPS;   
				ExOPS.ExportDestinationType=CrystalDecisions.Shared.ExportDestinationType.DiskFile;   
				ExOPS.ExportFormatType=CrystalDecisions.Shared.ExportFormatType.PortableDocFormat;   
				ReportDoc.Export();   
			
				return   true;   
			}   
			catch (Exception  ex )
			{   
				Common.Log.Logger.Log("Common.UtilExportToPDF",ex.Message ); 	
				return false;   
			}
		}   

		///   <summary>   
		///   ����PDF�ļ����û���IE�������   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="page">������ʾPDF   WebForm</param>   
		///   <returns></returns>   
		public bool ReturnPDF(string ReportFile,object ReportDataSource,System.Web.UI.Page page)   
		{   
			int temp;   
			temp=System.Convert.ToInt32(System.DateTime.Now.Millisecond.ToString());   
			System.Random ra=new System.Random(temp);   
			int TmpNumber=ra.Next();
            string TmpPDFFileName = "c:\\ReportForBudget\\" + System.Convert.ToString(TmpNumber) + ".pdf";   
			if (ExportToPDF(ReportFile,ReportDataSource,TmpPDFFileName)==true)   
			{ 
				page.Response.ClearContent();   
				page.Response.ClearHeaders();   
				page.Response.ContentType="application/pdf";   
				page.Response.WriteFile(TmpPDFFileName);   
				page.Response.Flush();   
				page.Response.Close();   
				System.IO.File.Delete(TmpPDFFileName);   
				return true;   
			}   
			else   
			{   
				return false;   
			}   
		}   

		///   <summary>   
		///   ���������ļ���Excel��ʽ   
		///   </summary>   
		///   <param   name="ReportFile">�����ļ�����,����ʱ��ʹ��Server.MapPath("�����ļ�.rpt")���������������</param>   
		///   <param   name="ReportDataSource">�����ļ���ʹ�õ�����Դ,��һ��Dataset</param>   
		///   <param   name="ExcelFileName">��Ҫ���ɵ�Ŀ���ļ�����,ע�ⲻҪ����wwwroot��Ŀ¼��,iis�᲻���㵼����</param>   
		///   <returns>�ɹ�����trueʧ�ܷ���false</returns>   
		public bool ExportToExcel(string ReportFile,object ReportDataSource,string ExcelFileName)   
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
				return true;   
			}   
			catch(Exception ex)
			{ 
				Common.Log.Logger.Log("Common.ExportToExcel",ex.Message ); 	

				return false;   
			}
		} 

		///   <summary>   
		///   ����Excel�ļ����û���IE�������   
		///   </summary>   
		///   <param   name="ReportFile"></param>   
		///   <param   name="ReportDataSource"></param>   
		///   <param   name="page"></param>   
		///   <returns></returns>   
		public bool ReturnExcel(string ReportFile,object ReportDataSource,System.Web.UI.Page page)   
		{   
			int temp;   
			temp=System.Convert.ToInt32(System.DateTime.Now.Millisecond.ToString());   
			System.Random ra=new System.Random(temp);   
			int TmpNumber=ra.Next();   
			string TmpExcelFileName="c:\\"+System.Convert.ToString(TmpNumber)+".xls";   
			if (ExportToExcel(ReportFile,ReportDataSource,TmpExcelFileName)==true)   
			{ 
				page.Response.ClearContent();   
				page.Response.ClearHeaders();   
				page.Response.ContentType="application/xls";   
				page.Response.WriteFile(TmpExcelFileName);   
				page.Response.Flush();   
				page.Response.Close();   
				System.IO.File.Delete(TmpExcelFileName);   
				return true;   
			}   
			else   
			{   
				return false;   
			}  
		}  



	}
}
