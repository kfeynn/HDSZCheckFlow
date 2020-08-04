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

namespace HDSZCheckFlow.UI.CostAssay.FaCost
{
	/// <summary>
	/// FaCard ��ժҪ˵����
	/// </summary>
	public class FaCard : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtStDate;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnOut;
		protected System.Web.UI.WebControls.DataGrid dgInvStore;
	
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
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblMessage.Text = "" ; 
				if("".Equals(this.txtStDate.Text.Trim()))
				{
					this.lblMessage.Text = "���²���Ϊ��!";
					this.lblMessage.ForeColor= Color.Red;
					return ;
				}

				DataSet ds=  Bussiness.CostBLL.RunFaCardbyDate(DateTime.Parse(this.txtStDate.Text).Year ,DateTime.Parse(this.txtStDate.Text).Month) ; 

				if(ds!=null )
				{
					this.dgInvStore.DataSource = ds;
					this.dgInvStore.DataBind();
				}
				else
				{
					this.dgInvStore.DataSource = null;
					this.dgInvStore.DataBind();
				}
			}
			catch
			{
				this.dgInvStore.DataSource = null;
				this.dgInvStore.DataBind();
				this.lblMessage.Text = "ϵͳ����~!����ȷ�������£�����ϵMIS" ;
			}

		}

		private void btnOut_Click(object sender, System.EventArgs e)
		{
			//NCReport.BLL.Files.DataGridToExcel(this.dgInvStore); 

			Common.Util.ExcelHelper help = new HDSZCheckFlow.Common.Util.ExcelHelper();
			help.GoToExcel("excel.xls",this. dgInvStore);
		}

	
	}
}
