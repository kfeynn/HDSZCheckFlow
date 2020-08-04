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
	/// BudgetInfoNew ��ժҪ˵����
	/// </summary>
	public class BudgetInfoNew : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.DropDownList ddlAccBook;
		protected System.Web.UI.WebControls.DataGrid dgBudgetInfo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//������
			if(!Page.IsPostBack)
			{
				BindAccBook();
			}

		}
	

		private void BindAccBook()
		{
			try
			{

				string AccBookKey = System.Configuration.ConfigurationSettings.AppSettings["AccBook"];


				DataSet ds = Bussiness.CostBLL.BindAccBook(AccBookKey);
				this.ddlAccBook.DataSource = ds.Tables[0];
				this.ddlAccBook.DataValueField = "Code";
				this.ddlAccBook.DataTextField = "CodeName";
				this.ddlAccBook.DataBind();
			}
			catch(Exception Ex)
			{
				this.lblMessage.Text = "�����׳���" + Ex.Message ;
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.dgBudgetInfo.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgBudgetInfo_ItemDataBound);
			this.dgBudgetInfo.SelectedIndexChanged += new System.EventHandler(this.dgBudgetInfo_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindBudgetInfo();

		
		}

		private void BindBudgetInfo()
		{
			this.lblMessage.Text ="";
			if("".Equals(this.txtDate.Text ))
			{
				this.lblMessage.Text = "��ѡ�����ڲ�ѯ!";
				this.lblMessage.ForeColor=Color.Red;
				return ;
			}
			DateTime dt= DateTime.Parse(this.txtDate.Text);

			string AccBook = this.ddlAccBook.SelectedValue ; 

			if(AccBook == "")
			{
				this.lblMessage .Text = "��ѡ������";
				return ;
			}




			string QueryType = this.ddlType.SelectedValue.Trim() ;
			string Proc = "";

			switch ( QueryType )
			{
				case "1001":      // Ԥ����Ϣһ����

					Proc = "p_GetBudgetByQuerter";

					break;

				case "1002":      // ʵ����Ϣһ����
					Proc = "p_GetCostByMonth";

					break;
				case "1003":      // ʵ���ۼ�һ����
					Proc ="p_GetCostByMonthAddUp";

					break;
				case "1004":
					Proc = "p_GetBudgetByMonth_Cost";

					break;
			}


			DataSet ds = Bussiness.CostBLL.GetProcInfo(Proc,dt.Year,dt.Month,AccBook );
			this.dgBudgetInfo.DataSource = ds;
			this.dgBudgetInfo.DataBind();







		}

		private void dgBudgetInfo_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//��ʱ�� ��ʾΪ �ϼ���Ŀ,��ʶΪ��ɫ,��Ŀ
			if(e.Item.ItemType==ListItemType.Item  || e.Item.ItemType==ListItemType.AlternatingItem)    //������� 
			{
				DataSet ds=this.dgBudgetInfo.DataSource as DataSet ;
				if(ds!=null)
				{

					//�̶���ʽ
					e.Item.Cells[0].CssClass = "scrollRowThead";
					e.Item.Cells[1].CssClass = "scrollRowThead";


					//��Ŀ��־
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("�ܼ�")>-1 )
					{
						e.Item.BackColor=Color.Yellow;
					}
					if(ds.Tables[0].Rows[e.Item.ItemIndex][1].ToString().IndexOf("�ϼ�")>-1)
					{
						e.Item.BackColor=Color.GreenYellow ;
					}
					//�������Ժ�����ݿ��ҿ���
					if(ds.Tables[0].Columns.Count >3)
					{
						for(int i=3;i<ds.Tables[0].Columns.Count ;i++)
						{
							e.Item.Cells[i].HorizontalAlign = HorizontalAlign.Right;
						}
					}






				}
			}
			//�̶���ʽ.
			if(e.Item.ItemType==ListItemType.Header  )    //������� 
			{
				e.Item.CssClass = "scrollColThead";
				e.Item.Cells [0].CssClass = "scrollRowThead  scrollCR";
				e.Item.Cells [1].CssClass = "scrollRowThead  scrollCR";

			}




		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgBudgetInfo);
		}

		private void dgBudgetInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		
	}
}
