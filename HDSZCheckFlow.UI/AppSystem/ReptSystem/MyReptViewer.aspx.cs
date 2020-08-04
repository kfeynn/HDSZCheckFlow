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
	/// MyReptViewer 的摘要说明。
	/// </summary>
	public class MyReptViewer : MyBasePage
	{
		protected System.Web.UI.WebControls.Button btnPrint;
		protected System.Web.UI.WebControls.Button btnLastPage;
		protected System.Web.UI.WebControls.Button btnGotoPage;
		protected System.Web.UI.WebControls.TextBox txtGotoPage;
		protected System.Web.UI.WebControls.Button btnFirstPage;
		protected System.Web.UI.WebControls.Button btnPrevPage;
		protected System.Web.UI.WebControls.Button btnNextPage;
		protected CrystalDecisions.Web.CrystalReportViewer MyViewer;
		protected System.Web.UI.WebControls.Label Message;
		protected System.Web.UI.WebControls.Button BtnBack2About;
		protected System.Web.UI.HtmlControls.HtmlInputText GoStep;
		protected System.Web.UI.HtmlControls.HtmlInputText CacheName;
		protected System.Web.UI.HtmlControls.HtmlInputText NeedCleanCache;

		private MyReptBasePage SourcePage; 
		private string ReptFileName; 
		private string ReptFilePath; 
		private DataSet innerReptData; 
		private DataView DsView;
		protected CrystalDecisions.CrystalReports.Engine.ReportDocument MyReptDoc; 
		private int intExportExcel;
		private bool ReBindRept 
		{ 
			get 
			{ 
				innerReptData = (DataSet)Cache[CacheName.Value] ; 
				if (innerReptData == null) 
				{ 
					MyViewer.Visible = false; 
					Message.Visible = true; 
					return false; 
				} 
				else 
				{ 
					DsView = innerReptData.Tables["Rept_info"].DefaultView; 
					ReptFileName=DsView.Table.Rows[0]["FileName"].ToString().Trim();
					//txtGotoPage.Text=DsView.Table.Rows[0]["Author"].ToString().Trim();
					ReptFileName = ReptFileName.Replace(".rpt","");
					ReptFilePath = DsView.Table.Rows[0]["FilePath"].ToString().Trim() + DsView.Table.Rows[0]["FileName"].ToString().Trim();
					intExportExcel = (int)DsView.Table.Rows[0]["id"]; 
					MyReptDoc.Load(ReptFilePath); 
					MyReptDoc.SetDataSource(innerReptData); 
					if (ReptFileName == "StatcDetlRept_rpt" & intExportExcel == 2) 
					{ 
						DiskFileDestinationOptions MyDestFile = new DiskFileDestinationOptions(); 
						string MyDestFileName = System.IO.Path.GetTempPath() + "tmpPrdtRate.xls"; 
						MyDestFile.DiskFileName = MyDestFileName; 
						MyReptDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
						MyReptDoc.ExportOptions.DestinationOptions = MyDestFile; 
						MyReptDoc.ExportOptions.ExportFormatType = ExportFormatType.Excel; 
						try 
						{ 
							MyReptDoc.Export(); 
						} 
						catch 
						{ 
						} 
					} 
					MyViewer.ReportSource = MyReptDoc; 
					MyViewer.DataBind(); 
					return true; 
				} 
			} 
		} 

		private void DisableAll() 
		{ 
			btnFirstPage.Enabled = false; 
			btnPrevPage.Enabled = false; 
			btnNextPage.Enabled = false; 
			btnLastPage.Enabled = false; 
			txtGotoPage.Enabled = false; 
			btnGotoPage.Enabled = false; 
			btnPrint.Enabled = false; 
		}

	
		private void Page_Load(object sender, System.EventArgs e) 
		{ 
			if (!(Page.IsPostBack)) 
			{ 
				SourcePage = (MyReptBasePage)(Context.Handler); 
				System.Random Rnd=new System.Random();
				CacheName.Value = "ccReptData" + System.Convert.ToString(Rnd.NextDouble() * 10000000); 
				Cache[CacheName.Value] = SourcePage.ReptData; 
				if (!(ReBindRept)) 
				{ 
				} 
			} 
			else 
			{ 
				NeedCleanCache.Value = "1"; 
			} 
			//btnPrint.Attributes["onclick"] = "return HaveAcrobat();"; 
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
			this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
			this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
			this.btnGotoPage.Click += new System.EventHandler(this.btnGotoPage_Click);
			this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
			this.btnPrevPage.Click += new System.EventHandler(this.btnPrevPage_Click);
			this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
			this.BtnBack2About.Click += new System.EventHandler(this.BtnBack2About_Click);
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

		private void btnFirstPage_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				MyViewer.ShowFirstPage(); 
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
		}

		private void btnPrevPage_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				MyViewer.ShowPreviousPage();
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
		}

		private void btnNextPage_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				MyViewer.ShowNextPage();
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
		}

		private void btnLastPage_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				MyViewer.ShowLastPage();
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
		}

		private void btnGotoPage_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				if (txtGotoPage.Text.Trim() != "" & System.Convert.ToInt16(txtGotoPage.Text) > 0) 
				{ 
					MyViewer.ShowNthPage(Convert.ToInt16(txtGotoPage.Text)); 
				} 
				GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
			}

		}

		private void btnPrint_Click(object sender, System.EventArgs e)
		{
			if (ReBindRept) 
			{ 
				DiskFileDestinationOptions MyDestFile = new DiskFileDestinationOptions(); 
				MyDestFile.DiskFileName = System.IO.Path.GetTempPath() + "MisSystemTempRept.pdf"; 
				MyReptDoc.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile; 
				MyReptDoc.ExportOptions.DestinationOptions = MyDestFile; 
				MyReptDoc.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat; 
				try 
				{ 
					MyReptDoc.Export(); 
					Cache.Remove(CacheName.Value); 
					CacheName.Value = ""; 
					Response.ClearContent(); 
					Response.ClearHeaders(); 
					Response.ContentType = "application/pdf"; 
					Response.WriteFile(MyDestFile.DiskFileName); 
					Response.Flush(); 
					Response.End(); 
					System.IO.File.Delete(MyDestFile.DiskFileName); 
				} 
				catch 
				{ 
				} 
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);

		}
		private void BtnBack2About_Click(object sender, System.EventArgs e)
		{
			Visitor MyVisitor = new Visitor(); 
			Response.Redirect(MyVisitor.GetWebSiteRootPath + "AppSystem/SysPage/About.Aspx");
		}

		private void ExportToExcel_Click(object sender, System.EventArgs e) 
		{ 
			Visitor MyVisitor = new Visitor(); 
			if (ReBindRept) 
			{ 
				Response.Redirect(MyVisitor.GetWebSiteRootPath + "AppSystem\\ReptSystem\\Export2Excel.Aspx?CacheName=" + CacheName.Value.Trim()); 
			} 
			GoStep.Value = Convert.ToString(Convert.ToInt16(GoStep.Value) - 1);
		}

   }
}
