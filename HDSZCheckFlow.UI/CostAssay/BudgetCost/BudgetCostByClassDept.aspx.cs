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
	/// BudgetCostByClassDept ��ժҪ˵����
	/// </summary>
	public class BudgetCostByClassDept : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button btnOutPrint;
		protected System.Web.UI.WebControls.DropDownList ddlAccBook;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				BindDept();

				//������
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



		#region ��Ѱ��������� �� Base_Runreport
		private void BindDept()
		{
			
			DataSet ds=Bussiness.CostBLL.GetBudgetClassDept();
			this.ddlDept.DataSource=ds.Tables[0];
			this.ddlDept.DataValueField =ds.Tables[0].Columns["tableCode"].ToString();
			this.ddlDept.DataTextField  =ds.Tables[0].Columns["tableName"].ToString();
			this.ddlDept.DataBind();
		}
		#endregion 


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

			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			DateTime dt=DateTime.Parse(this.txtDate.Text);
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}

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

			string accBook = this.ddlAccBook.SelectedValue ; 

			if(accBook == "")
			{
				this.lblMessage .Text = "��ѡ������";
				return ;
			}

			DataSet ds=Bussiness.CostBLL.GetBudgetCostByClassDept(dt.Year,dt.Month,this.ddlDept.SelectedValue,accBook);
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
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=2&QueryDate=" + this.txtDate.Text + "&TableCode=" + this.ddlDept.SelectedValue + " ');</script>");

		}
	}
}
