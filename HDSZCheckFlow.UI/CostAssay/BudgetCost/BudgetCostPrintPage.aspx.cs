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

namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// BudgetCostPrintPage ��ժҪ˵����
	/// </summary>
	public class BudgetCostPrintPage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��

			try
			{
				string ComType = GetQuery("ComType");
				string QueryDate = GetQuery("QueryDate");
				DateTime dt=DateTime.Parse(QueryDate);

				DataSet ds= new DataSet();

				string AccBook = "100101";

				if(ComType == "1")
				{
					//��˾
					ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
				}
				else if	(ComType == "2")
				{
					//����
					string tableCode = GetQuery("TableCode");
					ds=Bussiness.CostBLL.GetBudgetCostByClassDept(dt.Year,dt.Month,tableCode,AccBook); 
				}
				else if	(ComType == "3")
				{
					//����
					string tableCode = GetQuery("TableCode");
					ds=Bussiness.CostBLL.GetBudgetCostByClassDept(dt.Year,dt.Month,tableCode,AccBook);
				}

				int iMonth = dt.Month;

				//����ds ,��ӣ�ʵ/Ԥ ������ ʵ/�� ����
				ds.Tables[0].Columns.Add("oneSeason");         //ʵ/Ԥ ��
				ds.Tables[0].Columns.Add("twoSeason");         //ʵ/�� ��
				ds.Tables[0].Columns.Add("oneHSeason");         //ʵ/�� ��

				ds.Tables[0].Columns.Add("PrintDateInfo");          //��ӡ������Ϣ
				ds.Tables[0].Columns.Add("PrintTitleInfo");         //��ӡ���� 

				if(ComType == "1")
				{
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy��MM��"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]="HDSZ��˾Ԥʵ����" ; 
					}
				}
				else if	(ComType == "2")
				{
					string tableCode = GetQuery("TableCode");
					Entiy.BaseRunreport baseRunreportInfo = Entiy.BaseRunreport.FindBytableCode(tableCode);
					
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy��MM��"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]=baseRunreportInfo.TableName + "Ԥʵ����" ; 
					}
				}
				else if	(ComType == "3")
				{
					string tableCode = GetQuery("TableCode");
					Entiy.BaseRunreport baseRunreportInfo = Entiy.BaseRunreport.FindBytableCode(tableCode);
					
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy��MM��"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]=baseRunreportInfo.TableName + "Ԥʵ����" ; 
					}
				}

				for(int i=0;i<ds.Tables[0].Rows.Count; i++)
				{
					if(iMonth <= 6 )  //�� 1 q�ıȽ�
					{
						ds.Tables[0].Rows[i]["oneSeason"]="1Q" ; 
						ds.Tables[0].Rows[i]["twoSeason"]="2Q" ; 
						ds.Tables[0].Rows[i]["oneHSeason"]="1H" ; 
					}
					else
					{
						ds.Tables[0].Rows[i]["oneSeason"]="3Q" ; 
						ds.Tables[0].Rows[i]["twoSeason"]="4Q" ; 
						ds.Tables[0].Rows[i]["oneHSeason"]="2H" ; 					
					}
				}

				ds.Tables[0].TableName = "BudgetCostInfoMation";

				//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
				//����·��ȡ���ݿ��д�ŵ�ֵ
				rptHelper.ExportToPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,"c:\\test.pdf");   
				//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   
				rptHelper.ReturnPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,this);   
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("BudgetCostPrintPage",ex.Message );
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
