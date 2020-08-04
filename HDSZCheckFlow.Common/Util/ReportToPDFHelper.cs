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
	/// ReportToPDFHelper 的摘要说明。
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
		///   导出报表文件为PDF格式   
		///   </summary>   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="PDFFileName">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>   
		///   <returns>bool成功返回true,失败返回false</returns>   
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
		///   返回PDF文件到用户的IE浏览器中   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="page">用于显示PDF   WebForm</param>   
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
		///   导出报表文件到Excel格式   
		///   </summary>   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="ExcelFileName">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>   
		///   <returns>成功返回true失败返回false</returns>   
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
		///   返回Excel文件到用户的IE浏览器中   
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
