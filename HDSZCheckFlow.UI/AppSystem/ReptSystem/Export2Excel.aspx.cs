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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace HDSZCheckFlow.AppSystem.ReptSystem
{
	/// <summary>
	/// Export2Excel 的摘要说明。
	/// </summary>
	public class Export2Excel : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
	
		//private MyReptBasePage SourcePage; 
		private string ReptFileName; 
		private string ReptFilePath; 
		private DataSet innerReptData; 
		private DataView DsView;
		protected CrystalDecisions.CrystalReports.Engine.ReportDocument MyReptDoc; 
		private string CacheName; 

		private bool ReBindRept 
		{ 
			get 
			{ 
				innerReptData = (DataSet)Cache[CacheName]; 
				if (innerReptData == null) 
				{ 
					return false; 
				} 
				else 
				{ 
					DsView = innerReptData.Tables["Rept_info"].DefaultView; 
					ReptFileName=DsView.Table.Rows[0]["FileName"].ToString().Trim();
					ReptFileName = ReptFileName.Replace(".rpt","");
					ReptFilePath = DsView.Table.Rows[0]["FilePath"].ToString().Trim() + DsView.Table.Rows[0]["FileName"].ToString().Trim();
					MyReptDoc.Load(ReptFilePath); 
					MyReptDoc.SetDataSource(innerReptData); 
					return true; 
				} 
			} 
		} 

		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			CacheName = Request["CacheName"].Trim(); 
			if (CacheName != "") 
			{ 
				if (ReBindRept) 
				{ 
					Cache.Remove(CacheName); 
					DiskFileDestinationOptions MyDestFile = new DiskFileDestinationOptions(); 
					string MyDestFileName = System.IO.Path.GetTempPath() + "MisSystemTempRept.xls"; 
					MyDestFile.DiskFileName = MyDestFileName; 
					MyReptDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
					MyReptDoc.ExportOptions.DestinationOptions = MyDestFile; 
					MyReptDoc.ExportOptions.ExportFormatType = ExportFormatType.Excel; 
					try 
					{ 
						MyReptDoc.Export(); 
						string strYMD = System.DateTime.Now.Year.ToString() + (System.DateTime.Now.Month < 10 ? "0" +System.DateTime.Now.Month.ToString():System.DateTime.Now.Month.ToString()) + (System.DateTime.Now.Day < 10 ? "0" + System.DateTime.Now.Day.ToString():System.DateTime.Now.Day.ToString()); 
						string FileName = ReptFileName + strYMD + ".Xls"; 
						System.IO.FileStream FileStream = new System.IO.FileStream(MyDestFileName, System.IO.FileMode.Open); 
						long FileSize = FileStream.Length; 
						Response.ContentType = "application/octet-stream"; 
						Response.AddHeader("Content-Disposition", "attachment; filename=\"" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8) + "\""); 
						Response.AddHeader("Content-Length", FileSize.ToString()); 
						byte[] fileBuffer = new byte[FileSize]; 
						FileStream.Read(fileBuffer, 0, ((int)(FileSize))); 
						FileStream.Close();  
						Response.Clear(); 
						Response.BinaryWrite(fileBuffer); 
						Response.End(); 
						System.IO.File.Delete(MyDestFile.DiskFileName); 
						return; 
					} 
					catch{}
				} 
			} 
			else 
			{ 
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
			this.MyReptDoc = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			// 
			// MyReptDoc
			// 
			this.MyReptDoc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.DefaultPaperOrientation;
			this.MyReptDoc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize;
			this.MyReptDoc.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
			this.MyReptDoc.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
