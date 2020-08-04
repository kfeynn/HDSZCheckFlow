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

namespace HDSZCheckFlow.UI.OrderManage.PrintOrder
{
	/// <summary>
	/// PrintPurchaseOrder ��ժҪ˵����
	/// </summary>
	public class PrintPurchaseOrder : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string OrderId=GetQuery("OrderId");
			//Ϊurl���� 
			OrderId = Common.Security.Cryptography.Decrypt(OrderId );
			if(OrderId!=null  && !"".Equals(OrderId))
			{
				DataSet ds=Bussiness.OrderManageBLL.GetOrderInfoForReport(int.Parse(OrderId));

				//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();

				//����·��ȡ���ݿ��д�ŵ�ֵ
				rptHelper.ExportToPDF(Server.MapPath("Report\\ReportForPuchaseOrder.rpt"),ds,"c:\\ReportForBudget\\order.pdf");   

				//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   

				rptHelper.ReturnPDF(Server.MapPath("Report\\ReportForPuchaseOrder.rpt"),ds,this);   

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
