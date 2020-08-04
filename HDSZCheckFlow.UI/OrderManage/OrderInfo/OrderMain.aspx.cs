//namespace HDSZCheckFlow.UI.OrderManage.OrderInfo
//{
//	public class OrderMain : System.Web.UI.Page
//	{
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


namespace HDSZCheckFlow.UI.OrderManage.OrderInfo
{
	/// <summary>
	/// ApplyOfCompanyState ��ժҪ˵����
	/// </summary>
	public class OrderMain : System.Web.UI.Page
	{

		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.DataGrid dgPostail;


		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//����ʽ 1,����.2����
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.DataGrid dgOrder;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		#endregion  


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{

				bindGrid();
			}
		}

		private void bindGrid()
		{
			try
			{
				// ��ѯ�����ʺ���Ϣ 

				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=50;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=2;           //����ʽ
				oPageViewState.SSort="id";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort.ToString();                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
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
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //���������ť
			{
				BindApplyRecord(int.Parse(e.Item.Cells[0].Text));

				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					if(this.dgApply.Items[i].BackColor==Color.Yellow)
					{
						this.dgApply.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow;
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
			AdvancedSearchGo("v_Order_Info","id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtDateFrom.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	orderDate >= " +" '" + this.txtDateFrom.Text+ "'" );
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" orderDate <= " +" '" +  this.txtDateTo.Text+ "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" OrderNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}
				
			string returnValue=filter.ToString();
			return returnValue;
			#endregion  
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
			this.dgOrder.DataSource=null;        //��¼���ÿ�
			this.dgOrder.DataBind();
		}

		//���Ʒ�ҳ
		private void linkToPage_Click(object sender, System.EventArgs e)
		{
			try
			{
				string pageIndex="1";
				try
				{
					if( Request.Form["__EVENTARGUMENT"]!=null && Request.Form["__EVENTARGUMENT"].ToString()!="")
					{
						pageIndex=Request.Form["__EVENTARGUMENT"].ToString() ;
					}

					int aTest = Convert.ToInt32(pageIndex); 


				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("UI.CheckFlow.ApplyOfCompanyState.linkToPage_Click_1",ex.Message );
				}
				PageViewState oPageViewState=new PageViewState();
				oPageViewState.PCount=0;
				oPageViewState.PIndex=Convert.ToInt32(pageIndex);

				this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			
				oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
				oPageViewState.SortType=int.Parse(this.HerdSort.Value) ;//1;

				this.HerdSort.Value =oPageViewState.SortType.ToString();
				PageViewState.SetPageViewState(this.ViewState , oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.CheckFlow.ApplyOfCompanyState.linkToPage_Click",ex.Message );
			}
		}
		#endregion


		private void BindAuditingByType(string sqlWhere )
		{
			//type
			//1. �Ѿ���ɵ�����
			//2. δ��ɵ�����
			//3. ���ܾ�������

			//�ﶨ������Ϣ
			DataSet ds=Bussiness.ApplySheetHeadBLL.GetAuditingByType(sqlWhere);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				this.dgApply .DataSource=ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply .DataSource=null;
				this.dgApply.DataBind();
			}
		}


		private void BindApplyRecord(int OrderId)
		{
			//�ﶨ��������������¼
			DataSet ds=Bussiness.OrderManageBLL.GetOrderBodyByOrderId(OrderId);



			if(ds!=null)
			{
				this.dgOrder.DataSource=ds;
			}
			else
			{
				this.dgOrder.DataSource=null;
			}
			this.dgOrder.DataBind();
		}


		private void btnQuery_Click(object sender, System.EventArgs e)
		{
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

	}
}
