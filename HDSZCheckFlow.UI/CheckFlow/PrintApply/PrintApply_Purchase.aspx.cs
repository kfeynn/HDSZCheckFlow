//namespace HDSZCheckFlow.UI.CheckFlow.PrintApply

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


namespace HDSZCheckFlow.UI.CheckFlow.PrintApply
{
	/// <summary>
	/// ApplyOfCompanyState ��ժҪ˵����
	/// </summary>
	public class PrintApply : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;

		protected System.Web.UI.WebControls.LinkButton linkToPage;

		//public static string FieldSort="" ; //��������
		//public static int HerdSort=0;//����ʽ 1,����.2����
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.TextBox txtApplySheetNo;
		//public static int pagesIndex=1;		//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				
				InitPageForAdd();

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
				oPageViewState.SSort="applySheetHead_pk";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString());
				Common.Log.Logger.Log("UI.CheckFlow.PrintApply.bindGrid",ex.Message );
			}
		}


		#region  ��ʼ������

		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyType (deptClassCode);
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[0].ToString();
					ddlType.DataTextField=dtType.Columns [1].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

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
			if(e.CommandName.Equals("look")) 
			{
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
			else if(e.CommandName.Equals("Print")) 
			{
				//��url�������ܣ���ֹ͵��,Common.Security.Cryptography.Encode
				Response.Write("<script language='javascript'>window.open('PrintPage.aspx?applyPK=" + Common.Security.Cryptography.Encode(e.Item.Cells[0].Text) + " ');</script>");

				#region 
//				Response.Redirect("PrintPage.aspx?applyPK=" + e.Item.Cells[0].Text + "");
//				DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(e.Item.Cells[0].Text ));
//				DataTable ApplySheetPurchase=ds.Tables[0];
//
//				//�˴�����PDF�ļ���list.GetView��������һ����ѯ���DataView���ݼ�   
//				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
//
//				rptHelper.ExportToPDF(Server.MapPath("Report\\ReporeForPurchase.rpt"),ApplySheetPurchase,"c:\\test.pdf");   
//
//				//�˴�����PDF�ļ������ͻ��˵�IE�У��ͻ��˱���Ҫ��װAcrobat�ſ����   
//
//				rptHelper.ReturnPDF(Server.MapPath("Report\\ReporeForPurchase.rpt"),ApplySheetPurchase,this);   
				#endregion 
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
			//��������:1.��ѯ������ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_ApplySheetOfCompany","applySheetHead_Pk",out oPageViewState.PCount,12,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  ������ѯ����

			StringBuilder filter=new StringBuilder();
			if(!"".Equals(this.ddlType.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyTypeCode = " +" '" + this.ddlType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtDateFrom.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyDate >= " +" '" + this.txtDateFrom.Text+ "'" );
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDate <= " +" '" +  this.txtDateTo.Text+ "'" );
			}
			if(!"".Equals(this.txtApplySheetNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplySheetNo = " +" '" +  this.txtApplySheetNo.Text+ "'" );
			}
			// ֻ�ܲ�ѯ�Լ����ڲ��ŵĵ���
			string myDepeClass = Bussiness.DeptBLL.GetMyDeptClass(int.Parse(User.Identity.Name));

			if(!"".Equals(myDepeClass))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" + myDepeClass + "'" );
			}
//			//��ѯ���������� �����Ѿ�ͨ������
//			if(filter.Length>0)
//			{
//				filter.Append(" and ");
//			}
//			filter.Append(" IsFinishInCompany = 1 ");


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
			bindSearchResult();
		}

		#endregion


		#region 
//
//		private void BindAuditingByType(string sqlWhere )
//		{
//
//			//�ﶨ������Ϣ
//			DataSet ds=Bussiness.ApplySheetHeadBLL.GetAuditingByType(sqlWhere);
//			if(ds!=null && ds.Tables[0].Rows.Count>0)
//			{
//				this.dgApply .DataSource=ds;
//				this.dgApply.DataBind();
//			}
//			else
//			{
//				this.dgApply .DataSource=null;
//				this.dgApply.DataBind();
//			}
//		}

		#endregion  

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