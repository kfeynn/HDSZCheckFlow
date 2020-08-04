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
	/// BudgetCostByCompanyDept ��ժҪ˵����
	/// </summary>
	public class BudgetCostByCompanyDept : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnOutPrint;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnOutPrint.Click += new System.EventHandler(this.btnOutPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//
			
			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			DateTime dt=DateTime.Parse(this.txtDate.Text);

			if(dt.Month <=6 )
			{
				this.DataGrid1.Columns[1].HeaderText="1QԤ��";
				this.DataGrid1.Columns[2].HeaderText="2QԤ��";
				this.DataGrid1.Columns[3].HeaderText="1HԤ��";
			}
			else
			{
				this.DataGrid1.Columns[1].HeaderText="3QԤ��";
				this.DataGrid1.Columns[2].HeaderText="4QԤ��";
				this.DataGrid1.Columns[3].HeaderText="2HԤ��";
			}

			DataSet ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();
			this.Button1.Visible=true;

		
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//��ʱ��,�ж�unionType Ϊ 1ʱ.��ʾΪ �ϼ���Ŀ,��ʶΪ��ɫ,��Ŀ
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)    //������� 
			{
				DataSet ds=this.DataGrid1.DataSource as DataSet ;
				if(ds!=null)
				{
					if("1".Equals(ds.Tables[0].Rows[e.Item.ItemIndex]["unionType"].ToString()))
					{
						//this.DataGrid1.Items[e.Item.ItemIndex-1].BackColor=Color.Yellow;
						e.Item.BackColor=Color.Yellow;
					}
				}
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.DataGrid1);
		}

		private void btnOutPrint_Click(object sender, System.EventArgs e)
		{

			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}

			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=1&QueryDate=" + this.txtDate.Text + " ');</script>");

			#region 
//			DateTime dt=DateTime.Parse(this.txtDate.Text);
//
//
//			DataSet ds=Bussiness.CostBLL.GetBudgetCostByCompanyDept(dt.Year,dt.Month);
//			ds.Tables[0].TableName = "BudgetCostInfoMation";
//
//
//			//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
//			Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
//
//			//����·��ȡ���ݿ��д�ŵ�ֵ
//			rptHelper.ExportToPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,"c:\\test.pdf");   
//
//			//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   
//
//			rptHelper.ReturnPDF(Server.MapPath("BudgetCostRpt.rpt"),ds,this);   
			#endregion 
		
		}
	}
}
