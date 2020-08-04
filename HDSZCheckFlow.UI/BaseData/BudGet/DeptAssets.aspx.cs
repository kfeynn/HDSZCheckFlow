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
	/// DeptAssets 的摘要说明。
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
				// 查询银行帐号信息 

				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                                   //返回参数, 记录总数
				oPageViewState.PSize=50;                                   //返回参数,   页大小
				oPageViewState.PIndex=1;                                   //当前查询页码
				oPageViewState.SortType=2;                                 //排序方式
				oPageViewState.SSort="subjectcode";                        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		#region  分页查询
		string SQuery="";  //查询条件
		private void bindSearchResult()
		{
			//查询的字段, * 为所有
			string sFields="*";
			//获取查询条件      
			SQuery=GetQuerySqlString();
			//保存查询状态
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//参数意义:1.查询表或视图,必须有唯一列, 2.指明主键(唯一列) 3.输出参数 页大小 4.页尺寸(一页多少记录) 5.当前查询页码 6.排序字段 7.排序方式 8.查询条件 9.查询字段
			AdvancedSearchGo("v_DeptBudgetInfo","budget_account_pk",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

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


			//基础查询条件 , 查询本部门的预算 

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
				//整理季度 
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

		//控制翻页
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
			//绑定 预算科目   根据部门,显示其有预推算金额的 , 选择了年份就按其年月 , 没有选择就按当前年月 
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

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
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
			//标头排序
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
