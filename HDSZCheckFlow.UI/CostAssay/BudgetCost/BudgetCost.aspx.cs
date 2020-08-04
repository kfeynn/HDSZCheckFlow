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
	/// BudgetCost ��ժҪ˵����
	/// </summary>
	public class BudgetCost : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label Label1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				BindCost();
			}
		}

		private void BindCost()
		{
			int iYear,iMonth;
			DateTime dt;
			if(!"".Equals(this.txtDate.Text ))
			{
				dt=DateTime.Parse(this.txtDate.Text);
			}
			else
			{
				dt=DateTime.Now;
			}
			iYear = dt.Year;
			iMonth = dt.Month;

			DataSet ds= Bussiness.CostBLL.getCost(iYear,iMonth);
			this.DataGrid1.DataSource= ds;
			this.DataGrid1.DataBind();
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblMessage.Text="";
				if(!"".Equals(this.txtDate.Text ))
				{
					BindCost();
				}
				else
				{
					this.lblMessage.Text="�������ѯ���£�";
					this.lblMessage.ForeColor=Color.Red;
				}
			}
			catch
			{}
		}
	}
}
