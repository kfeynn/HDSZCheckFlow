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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// BudgetAccount ��ժҪ˵����
	/// </summary>
	public class BudgetAccount : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				//this.XPGrid1.CommandText="select * from budget_account order by  Iyear desc, Imonth desc,deptCode asc";
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//��ѯ , ����������,
			//��ҳ���㹫˾ȫ����Ϣ 
			string strData=this.txtData.Text;
			if("".Equals(strData))
			{
				this.lblMessage.Text="��ѡ�����²�ѯ!";
				return ;
			}
			DateTime date = DateTime.Parse(strData);

			//���µ����ֶε�ֵ
			Bussiness.BudgetAccountBLL.UpdateAccountChange(date.Year,date.Month);

			this.XPGrid1.CommandText="select * from budget_account where Iyear= " + date.Year  + " and Imonth= " + date.Month  + " order by  deptCode asc";
			this.XPGrid1.DataBind();

		}
	}
}
