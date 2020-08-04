//DeptAssets
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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// DeptAssets ��ժҪ˵����
	/// </summary>
	public class DeptAssets : System.Web.UI.Page
	{
		#region 
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlSubject;
		protected System.Web.UI.WebControls.TextBox txtSubjectCode;
		protected System.Web.UI.WebControls.DataGrid dgBudgetInfo;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblUsed;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.TextBox txtLeftMoney;
		protected System.Web.UI.WebControls.Label lblReadypay;
		protected System.Web.UI.WebControls.DropDownList ddlQuarter;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				BindSubjectCode();
				bindGrid();
				BindSumInfo();
			}
		}

		private void BindSumInfo()
		{
			string cmdStr = @"SELECT SUM(budgetMoney) AS budgetMoney, SUM(PlanMoney) AS PlanMoney, 
										SUM(CheckMoney) AS CheckMoney, SUM(changeMoney) AS changeMoney, 
										SUM(leftMoney) AS leftMoney,sum(readypay) as readypay,sum(TotalAllowOutMoney) as  TotalAllowOutMoney
									FROM v_DeptBudgetInfo";
			string filter = GetQuerySqlString() ; 
			if(filter .Length  > 0)
			{
				cmdStr = cmdStr + " where " + filter ; 
			}
			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
			if(ds!=null & ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
			{
				this.lblBudget.Text  =string.Format("{0:N}",ds.Tables[0].Rows[0]["budgetMoney"].ToString());
				this.lblPush.Text    = ds.Tables[0].Rows[0]["PlanMoney"].ToString();
				this.lblChange.Text  = ds.Tables[0].Rows[0]["changeMoney"].ToString();
				this.lblUsed.Text    = ds.Tables[0].Rows[0]["CheckMoney"].ToString();
				this.lblLeft.Text    = ds.Tables[0].Rows[0]["leftMoney"].ToString();
				this.lblReadypay.Text =ds.Tables[0].Rows[0]["readypay"].ToString();
				this.lblOutMoney.Text = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
			}
		}


		private void bindGrid()
		{
			try
			{
				// ��ѯ�����ʺ���Ϣ 

				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                                   //���ز���, ��¼����
				oPageViewState.PSize=50;                                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                                   //��ǰ��ѯҳ��
				oPageViewState.SortType=2;                                 //����ʽ
				oPageViewState.SSort="subjectcode";                        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
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
			AdvancedSearchGo("v_DeptBudgetInfo","budget_account_pk",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtDate.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				int iyear = int.Parse(this.txtDate.Text) ;
				
				filter.Append (" iyear = " + iyear + " ");
			}

			if(!"".Equals(this.ddlSubject.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append (" subjectcode = '" + this.ddlSubject.SelectedValue + "'" );

			}
			if(!"".Equals(this.txtSubjectCode.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append (" subjectcode like '%" + this.txtSubjectCode.Text + "%'" );	
			}


			//������ѯ���� , ��ѯ�����ŵ�Ԥ�� 

			string deptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
			if(deptCode!=null)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" budget_DeptCode in ( select budget_DeptCode from Base_Dept where superior_Dept_pk = '" + deptCode + "') "   );
	
			}

			if(!"".Equals(this.txtLeftMoney.Text ))
			{
				try
				{
					int leftMoney = int.Parse(this.txtLeftMoney.Text );
					string sign = this.DropDownList1.SelectedValue ;

					if (!"".Equals(sign))
					{
						if(filter.Length>0)
						{
							filter.Append(" and ");
						}
						filter.Append (" leftmoney   " + sign + leftMoney + "" );		
					}
				}
				catch{}
			}

			if(this.ddlQuarter.SelectedValue != "0" )
			{
				//������ 
				string months = "";
				if(this.ddlQuarter.SelectedValue == "1")
				{
					months = " ( 1,2,3 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "2")
				{
					months = " ( 4,5,6 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "3")
				{
					months = " ( 7,8,9 ) ";
				}
				if(this.ddlQuarter.SelectedValue == "4")
				{
					months = " ( 10,11,12 ) ";
				}

				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append (" imonth in    " + months + " " );		
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
				this.dgBudgetInfo  .DataSource=ds;
				this.dgBudgetInfo.DataBind();
			}
			else
			{
				this.dgBudgetInfo.DataSource=null;
				this.dgBudgetInfo.DataBind();
			}
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
				oPageViewState.SortType=int.Parse(this.HerdSort.Value );//1;

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

		private void BindSubjectCode()
		{
			//�� Ԥ���Ŀ   ���ݲ���,��ʾ����Ԥ������� , ѡ������ݾͰ������� , û��ѡ��Ͱ���ǰ���� 
			string deptCode = Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name );

			DateTime dt = DateTime.Today;
			if(!"".Equals(this.txtDate.Text))
			{
				dt = DateTime.Parse(this.txtDate.Text) ;
			}
			int iYear  = dt.Year;
			int iMonth = dt.Month ;

			DataSet ds= Bussiness.BaseAccountSubjectBLL.QuerySubjectByDeptAndDate(deptCode,iYear,iMonth);
			this.ddlSubject.DataSource=ds;
			this.ddlSubject.DataValueField=ds.Tables[0].Columns[0].ToString();
			this.ddlSubject.DataTextField =ds.Tables[0].Columns[1].ToString();
			this.ddlSubject.DataBind();
			this.ddlSubject.Items.Insert(0,"");
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
			this.dgBudgetInfo.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgBudgetInfo_SortCommand);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgBudgetInfo_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();
			BindSumInfo();

		
		}
		
	}
}
