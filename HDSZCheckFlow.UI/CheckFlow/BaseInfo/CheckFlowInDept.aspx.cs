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

namespace HDSZCheckFlow.UI.CheckFlow.BaseInfo
{
	/// <summary>
	/// CheckFlowInDept ��ժҪ˵����
	/// </summary>
	public class CheckFlowInDept : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckValid;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from  CheckFlowInDept order by DeptClassCode asc ,DeptCode asc ,CheckSetp asc ";
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
			this.btnCheckValid.Click += new System.EventHandler(this.btnCheckValid_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheckValid_Click(object sender, System.EventArgs e)
		{
			//������п����������Ϣ
			DataTable dtMessage=new DataTable();
			Bussiness.CheckFlowInDeptBLL.CheckAllFlowInDept(out dtMessage);
			this.DataGrid1.DataSource=dtMessage.DefaultView ;
			this.DataGrid1.DataBind();
		}
	}
}
