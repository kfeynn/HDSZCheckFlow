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

namespace HDSZCheckFlow.UI.CheckFlow.PrintApply
{
	/// <summary>
	/// PrintPage ��ժҪ˵����
	/// </summary>
	public class PrintPage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				string applyHeadPK=GetQuery("applyPK");
				//Ϊurl���� 
				applyHeadPK = Common.Security.Cryptography.Decrypt(applyHeadPK );
				if(applyHeadPK!=null  && !"".Equals(applyHeadPK))
				{
					DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(applyHeadPK));

					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
					Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					applyHead = null;
					//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
					Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

					//����·��ȡ���ݿ��д�ŵ�ֵ
					rptHelper.ExportToPDF(Server.MapPath("Report\\" + applyType.Report.Trim() + ""),ds,"c:\\ReportForBudget\\test.pdf");   

					//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   

					rptHelper.ReturnPDF(Server.MapPath("Report\\" + applyType.Report.Trim() + ""),ds,this);   
//
//					//test.rpt
//
					//����·��ȡ���ݿ��д�ŵ�ֵ
//					rptHelper.ExportToPDF(Server.MapPath("Report\\test.rpt"),ds,"c:\\test.pdf");   
//
//					//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   
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
