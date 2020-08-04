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
	/// BudgetCostPrintPage 的摘要说明。
	/// </summary>
	public class BudgetCostPrintPage : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面

			try
			{
				string ComType = GetQuery("ComType");
				string QueryDate = GetQuery("QueryDate");
				DateTime dt=DateTime.Parse(QueryDate);

				DataSet ds= new DataSet();

				string AccBook = "100101";

				if(ComType == "1")
				{
					//公司
					ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
				}
				else if	(ComType == "2")
				{
					//大部门
					string tableCode = GetQuery("TableCode");
					ds=Bussiness.CostBLL.GetBudgetCostByClassDept(dt.Year,dt.Month,tableCode,AccBook); 
				}
				else if	(ComType == "3")
				{
					//部门
					string tableCode = GetQuery("TableCode");
					ds=Bussiness.CostBLL.GetBudgetCostByClassDept(dt.Year,dt.Month,tableCode,AccBook);
				}

				int iMonth = dt.Month;

				//处理ds ,添加，实/预 比例， 实/推 比例
				ds.Tables[0].Columns.Add("oneSeason");         //实/预 比
				ds.Tables[0].Columns.Add("twoSeason");         //实/推 比
				ds.Tables[0].Columns.Add("oneHSeason");         //实/推 比

				ds.Tables[0].Columns.Add("PrintDateInfo");          //打印日期信息
				ds.Tables[0].Columns.Add("PrintTitleInfo");         //打印标题 

				if(ComType == "1")
				{
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy年MM月"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]="HDSZ公司预实分析" ; 
					}
				}
				else if	(ComType == "2")
				{
					string tableCode = GetQuery("TableCode");
					Entiy.BaseRunreport baseRunreportInfo = Entiy.BaseRunreport.FindBytableCode(tableCode);
					
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy年MM月"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]=baseRunreportInfo.TableName + "预实分析" ; 
					}
				}
				else if	(ComType == "3")
				{
					string tableCode = GetQuery("TableCode");
					Entiy.BaseRunreport baseRunreportInfo = Entiy.BaseRunreport.FindBytableCode(tableCode);
					
					for(int i=0;i<ds.Tables[0].Rows.Count; i++)
					{
						ds.Tables[0].Rows[i]["PrintDateInfo"]= dt.ToString("yyyy年MM月"); 
						ds.Tables[0].Rows[i]["PrintTitleInfo"]=baseRunreportInfo.TableName + "预实分析" ; 
					}
				}

				for(int i=0;i<ds.Tables[0].Rows.Count; i++)
				{
					if(iMonth <= 6 )  //用 1 q的比较
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

				//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
				//报表路径取数据库中存放的值
				rptHelper.ExportToPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,"c:\\test.pdf");   
				//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
