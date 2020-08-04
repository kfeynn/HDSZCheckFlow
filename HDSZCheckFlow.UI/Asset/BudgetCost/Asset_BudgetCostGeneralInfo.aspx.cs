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
using System.Text;

namespace HDSZCheckFlow.UI.Asset.BudgetCost
{
	/// <summary>
	/// Asset_BudgetCostDetialInfo ��ժҪ˵����
	/// ��ӪԤ��ʹ�øſ�
	/// 2011-12-15 liyang
	/// </summary>
	public class Asset_BudgetCostGeneralInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnOutput;
		protected System.Web.UI.WebControls.DropDownList ddlItemType;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				BindSumInfo();
				bindGrid();
			}
		}

		
		#region  ��ʼ������

		private void InitPageForAdd()
		{
			try
			{
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery("select ��Ŀ����  from v_Asset_BudgetCostGeneralInfo") ;

				ddlItemType.DataSource=ds;
				ddlItemType.DataTextField=ds.Tables[0].Columns["��Ŀ����"].ToString();
				ddlItemType.DataBind();
				ddlItemType.Items.Insert(0,"");

				
				DataSet dtDeptClass=Bussiness.ComQuaryBLL.ExecutebyQuery("select budget_deptcode,budget_DeptName from dbo.Base_Budget_Dept") ;
				if(dtDeptClass!=null && dtDeptClass.Tables[0].Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Tables[0].Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Tables[0].Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}
		
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("Asset.BudgetCost.Asset_BudgetCostGeneralInfo",ex.Message );
			}

		}


		#endregion 

		private void bindGrid()
		{
			try
			{
				// ��ѯ�����ʺ���Ϣ 

				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=5;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=1;           //����ʽ
				oPageViewState.SSort="���";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.Asset.BudgetCost.Asset_BudgetCostUseDetialInfo.bindGrid",ex.Message );
			}
		}


		#region  ��ҳ��ѯ
		string SQuery="";  //��ѯ����
		private void bindSearchResult()
		{
			//��ѯ���ֶ�, * Ϊ����
			string sFields="*";
			//��ȡ��ѯ����      
			SQuery=GetQuerySqlString();
			//�����ѯ״̬
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//��������:1.��ѯ�����ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_Asset_BudgetCostGeneralInfo","���",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		
		
		/// <summary>
		/// ��ȡ�������ѯ��������
		/// </summary>
		/// <returns></returns>
		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			//���
			if(!"".Equals(this.txtDate.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("��� = " +" '" + this.txtDate.Text+ "'" );
			}


			//����
			if(!"".Equals(this.ddlDeptClass.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("���� = " +" '" + this.ddlDeptClass.SelectedItem.Text+ "'" );
			}


			//��Ŀ����
			if(!"".Equals(this.ddlItemType.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemType=this.ddlItemType.SelectedItem.Text;

				filter.Append("��Ŀ���� = " +" '" +tempItemType + "'" );
			}
				
			string returnValue=filter.ToString();


			return returnValue;

			#endregion  
		}




		string budgetInMoney;//Ԥ���ڽ��
		string budgetOutMoney;//Ԥ������
		string budgetChangeOutMoney;//�������
		string budgetChangeInMoney;//������
		string changeAfterMoney;//������Ľ��
		string useMoney;//ʹ�ý��
		string leftMoney;//ʣ����
	


		/// <summary>
		/// ����ϼ�
		/// </summary>
		private void BindSumInfo()
		{
			try
			{
				//�󶨺ϼ���Ϣ 
				string cmdStr = @"select 
									sum(Ԥ���ڽ��)Ԥ���ڽ��,
									sum(Ԥ������)Ԥ������,
									sum(�������)�������,
									sum(������)������,
									sum(������Ԥ����)������Ԥ����,
									sum(ʹ�ý��)ʹ�ý��,
									sum(ʣ����)ʣ����
									from v_Asset_BudgetCostGeneralInfo";

				string filter = GetQuerySqlString(); 
				if(filter .Length  > 0)
				{
					cmdStr = cmdStr + " where " + filter ; 
				}
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
				if(ds!=null & ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
				{
					budgetInMoney= decimal.Parse(ds.Tables[0].Rows[0]["Ԥ���ڽ��"].ToString()).ToString("N2");
					budgetOutMoney= decimal.Parse(ds.Tables[0].Rows[0]["Ԥ������"].ToString()).ToString("N2");
					budgetChangeOutMoney= decimal.Parse( ds.Tables[0].Rows[0]["�������"].ToString()).ToString ("N2");
					budgetChangeInMoney= decimal.Parse(ds.Tables[0].Rows[0]["������"].ToString()).ToString ("N2");
					changeAfterMoney= decimal.Parse(ds.Tables[0].Rows[0]["������Ԥ����"].ToString()).ToString("N2");
					useMoney = decimal.Parse(ds.Tables[0].Rows[0]["ʹ�ý��"].ToString()).ToString("N2");
					leftMoney = decimal.Parse(ds.Tables[0].Rows[0]["ʣ����"].ToString()).ToString("N2");
				}
			}
			catch{}
		}


		private void AdvancedSearchGo(string sTabel,string sPK,out int pageCount,int pageSize,int pageIndex,string sSort,int sSortType, string sFilter,string sFields)
		{	
			pageCount=0;
			Bussiness.PaginationBLL paginationBLL=new Bussiness.PaginationBLL();
			paginationBLL.Tables=sTabel;
			paginationBLL.Sort=sSort;
			paginationBLL.SortType=sSortType;
			paginationBLL.PK=sPK;
			paginationBLL.Fields=sFields;
			paginationBLL.Filter=sFilter;
			paginationBLL.PageSize=pageSize;
			paginationBLL.PageNumber=pageIndex;	

			DataSet ds = paginationBLL.CommonQuery();
			pageCount=paginationBLL.PageSumSize;

			
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{
				this.dgApply .DataSource=ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply.DataSource=null;
				this.dgApply.DataBind();
			}
		}

		//���Ʒ�ҳ
		private void linkToPage_Click(object sender, System.EventArgs e)
		{
			string pageIndex="";
			if( Request.Form["__EVENTARGUMENT"]!=null && Request.Form["__EVENTARGUMENT"].ToString()!="")
			{
				pageIndex=Request.Form["__EVENTARGUMENT"].ToString() ;
			}
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;
			oPageViewState.PIndex=Convert.ToInt32(pageIndex);


			this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
			oPageViewState.SortType=int.Parse(this.HerdSort.Value );//1;

			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);

			BindSumInfo();
			bindSearchResult();
		}

		#endregion




		/// <summary>
		/// ��ѯ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			BindSumInfo();
			bindGrid();
			
		}

		private void dgApply_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			//��ͷ����
			this.FieldSort.Value =e.SortExpression ;
			if(int.Parse(this.HerdSort.Value ) ==0 || int.Parse(this.HerdSort.Value )==2)
			{
				this.HerdSort.Value ="1";
			}
			else if(int.Parse(this.HerdSort.Value )==1)
			{
				this.HerdSort.Value ="2";
			}
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;

			oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
			oPageViewState.SSort=this.FieldSort.Value ;
			oPageViewState.SortType=int.Parse(this.HerdSort.Value );

			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);
			bindSearchResult();
		}


		/// <summary>
		/// ����Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOutput_Click(object sender, System.EventArgs e)
		{ 
			BindSumInfo();
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			string cmdStr = "select * from v_Asset_BudgetCostGeneralInfo ";
			string filter = GetQuerySqlString();
			if (filter.Length>0)
			{
				cmdStr = cmdStr + " where " + filter ;
			}

			DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;

			this.dgApply.DataSource=ds;
			this.dgApply.DataBind();

			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgApply);

			this.dgApply.DataSource=null;
			this.dgApply.DataBind();
		}

		/// <summary>
		/// ���⵼��Excel���ֵ��쳣
		/// </summary>
		/// <param name="control"></param>
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm (control);
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
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// ��ע �ϼ�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].ColumnSpan=3;
				e.Item.Cells[1].Text = "�ϼ�";
				e.Item.Cells[2].Text =  budgetInMoney;
				e.Item.Cells[3].Text =  budgetOutMoney;
				e.Item.Cells[4].Text = budgetChangeOutMoney;
				e.Item.Cells[5].Text = budgetChangeInMoney;
				e.Item.Cells[6].Text = changeAfterMoney;
				e.Item.Cells[7].Text = useMoney ;
				e.Item.Cells[8].Text = leftMoney;
				e.Item.Cells[9].Visible=false;
				e.Item.Cells[10].Visible=false;
				//e.Item.Cells[11].Visible=false;
				//e.Item.Cells[12].Visible=false;
				e.Item.CssClass = "cssFooter";
			}
		}
	}
}
