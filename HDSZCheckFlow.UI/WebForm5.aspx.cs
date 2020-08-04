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
	/// WebForm5 的摘要说明。
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
			//   TODO:   在此处添加构造函数逻辑   
			//   
			ReportDoc=new   ReportDocument();   
			logOnInfo=new   TableLogOnInfo();   
			FileOPS=new   DiskFileDestinationOptions();   
		} 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		///   <summary>   
		///   导出报表文件为PDF格式   
		///   </summary>   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="PDFFileName">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>   
		///   <returns>bool成功返回true,失败返回false</returns>   
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
		///   导出报表文件到Excel格式   
		///   </summary>   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="ExcelFileName">你要导成的目标文件名称,注意不要放在wwwroot等目录中,iis会不让你导出的</param>   
		///   <returns>成功返回true失败返回false</returns>   
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
		///   返回PDF文件到用户的IE浏览器中   
		///   <param   name="ReportFile">报表文件名称,调用时请使用Server.MapPath("报表文件.rpt")这样来给这个参数</param>   
		///   <param   name="ReportDataSource">报表文件所使用的数据源,是一个Dataset</param>   
		///   <param   name="page">用于显示PDF   WebForm</param>   
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
		///   返回Excel文件到用户的IE浏览器中   
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

		
				//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
				//ExportToPDF(Server.MapPath("CrystalReport1.rpt"),ds,"c:\\test.pdf");   
				//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   
				//	ReturnPDF(Server.MapPath("Report1.rpt"),ds,this);   
				//------生成Excel并返回到IE中的方法和上面相同，分别调用ExportToExcel和ReturnExcel方法--------   
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
				//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

				//报表路径取数据库中存放的值
				rptHelper.ExportToPDF(Server.MapPath("CrystalReport1.rpt"),ds,"c:\\test.pdf");   

				//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   

				rptHelper.ReturnPDF(Server.MapPath("CrystalReport1.rpt"),ds,this);   
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}

		}
	}
}
