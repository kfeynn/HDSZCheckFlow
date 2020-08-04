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
using HDSZCheckFlow.DataAccess;//���������ݷ��ʲ�

namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// RealCostAndBudgeDeptByQuarter ��ժҪ˵����
	/// </summary>
	public class RealCostAndBudgeDeptByQuarter : System.Web.UI.Page
	{

		DateTime dt;

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.LinkButton lbOneQuarter;
		protected System.Web.UI.WebControls.LinkButton lbTwoQuarter;
		protected System.Web.UI.WebControls.LinkButton lbThirdQuarter;
		protected System.Web.UI.WebControls.LinkButton lbFourQuarter;
		protected System.Web.UI.WebControls.Button btnOutPrint;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				BindDept();
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
			this.btnOutPrint.Click += new System.EventHandler(this.btnOutPrint_Click);
			this.lbOneQuarter.Click += new System.EventHandler(this.lbOneQuarter_Click);
			this.lbTwoQuarter.Click += new System.EventHandler(this.lbTwoQuarter_Click);
			this.lbThirdQuarter.Click += new System.EventHandler(this.lbThirdQuarter_Click);
			this.lbFourQuarter.Click += new System.EventHandler(this.lbFourQuarter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		#region ��Ѱ��������� �� Base_Runreport
		private void BindDept()
		{
			
			DataSet ds=Bussiness.CostBLL.GetBudgetDept();
			this.ddlDept.DataSource=ds.Tables[0];
			this.ddlDept.DataValueField =ds.Tables[0].Columns["tableCode"].ToString();
			this.ddlDept.DataTextField  =ds.Tables[0].Columns["tableName"].ToString();
			this.ddlDept.DataBind();
		}
		#endregion 



		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,1,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		
		//����
		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.DataGrid1 );
		}

		//��ӡ
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

			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=3&QueryDate=" + this.txtDate.Text + "&TableCode=" + this.ddlDept.SelectedValue + " ');</script>");

		}

		
		

		//��һ��
		private void lbOneQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,1,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}

		//�ڶ���
		private void lbTwoQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,2,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}

		//������
		private void lbThirdQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,3,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		//���ļ�
		private void lbFourQuarter_Click(object sender, System.EventArgs e)
		{
			
			
			CheckEmpty();

			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,4,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		

		/// <summary>
		/// ������� ��ѯĳ�꼾�ȵ�Ԥʵ����Ϣ
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostAndRealCostByClassDept(int iYear,int iMonth,string tableCode)
		{
			string cmdStr="Proc_Sub_RealCostAndBudgeDeptByQuarter";//�洢����
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
            Params.Add(DataAccess.Parameter.GetDBParameter("@iYear", iYear));
            Params.Add(DataAccess.Parameter.GetDBParameter("@Quarter", iMonth));
            Params.Add(DataAccess.Parameter.GetDBParameter("@tableCode", tableCode));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}



		//����ֵ
		private void CheckEmpty()
		{
			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ���";
				return ;
			}
			dt=DateTime.Parse(this.txtDate.Text);
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			Entiy.BaseRunreport runReport=Entiy.BaseRunreport.FindBytableCode(this.ddlDept.SelectedValue);
			if(runReport == null)
			{
				this.lblMessage.Text="ϵͳ��������ϵ����Ա��(Entiy.BaseRunreport runReport δ�ҵ�)";
				return ;
			}
		}
		

	}
}
