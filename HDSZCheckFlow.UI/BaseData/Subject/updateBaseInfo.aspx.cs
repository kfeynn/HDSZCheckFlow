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

namespace HDSZCheckFlow.UI.BaseData.Subject
{
	/// <summary>
	/// updateBaseInfo ��ժҪ˵����
	/// </summary>
	public class updateBaseInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnUpdateRate;
		protected System.Web.UI.WebControls.Button btnInputCost;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		
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
			this.btnInputCost.Click += new System.EventHandler(this.btnInputCost_Click);
			this.btnUpdateRate.Click += new System.EventHandler(this.btnUpdateRate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnInputCost_Click(object sender, System.EventArgs e)
		{
			// ����ʵ�ʷ�������
			if(!"".Equals(this.txtData.Text))
			{
				this.lblMessage.Text = "";
				DateTime dt = DateTime.Parse(this.txtData.Text);
				int iYear  = dt.Year ;
				int iMonth = dt.Month ;

				Bussiness.CostBLL.UpdateGl_NC_Cost(iYear,iMonth); 
//				Bussiness.GetCostBll costBll = new HDSZCheckFlow.Bussiness.GetCostBll(iYear,iMonth);
//				costBll.ThreadGetCostl();   



				this.lblMessage.Text = "������ɣ�";
			}
			else
			{
				this.lblMessage.Text = "��ѡ���ѯ����" ;
			}
		}

		private void btnUpdateRate_Click(object sender, System.EventArgs e)
		{
			// ����ʵ�ʷ�������

			if(!"".Equals(this.txtData.Text))
			{
				this.lblMessage.Text = "";
				DateTime dt = DateTime.Parse(this.txtData.Text);
				int iYear  = dt.Year ;
				int iMonth = dt.Month ;

				Bussiness.CurrRateBLL.updateCurrRate (iYear,iMonth); 
				this.lblMessage.Text = "������ɣ�";
			}
			else
			{
				this.lblMessage.Text = "��ѡ���ѯ����" ;
			}
		}

	
	}
}
