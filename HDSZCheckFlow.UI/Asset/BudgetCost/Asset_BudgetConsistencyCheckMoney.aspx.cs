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
	/// Asset_BudgetConsistencyCheckMoney 的摘要说明。
	/// </summary>
	public class Asset_BudgetConsistencyCheckMoney : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnConsistency;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.RadioButton radion_exception;
		protected System.Web.UI.WebControls.RadioButton radio_normal;
		protected System.Web.UI.WebControls.RadioButton radio_all;
		protected System.Web.UI.WebControls.TextBox txtDate_Year;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnConsistency.Attributes.Add( "onclick ", "return  IsExistSelect();"); 
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				bindGrid();
			}
		}

		
		#region  初始化方法

		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
				//string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);



				//this.ddlDept.Items.Clear();
				//string deptClass=this.ddlDeptClass.SelectedValue;
				/*DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClass(0);
				if(dtDept!=null && dtDept.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDept;
					ddlDeptClass.DataValueField=dtDept.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDept.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}	*/	

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetConsistencyCheckMoney",ex.Message );
			}

		}


		#endregion 

		private void bindGrid()
		{
			try
			{
				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                       //返回参数, 记录总数
				oPageViewState.PSize=5;                   //返回参数,   页大小
				oPageViewState.PIndex=1;                  //当前查询页码
				oPageViewState.SortType=1;           //排序方式
				oPageViewState.SSort="rum";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.Asset.BudgetCost.Asset_BudgetCostUseDetialInfo.bindGrid",ex.Message );
			}
		}


		#region  分页查询
		string SQuery="";  //查询条件
		private void bindSearchResult()
		{
			//查询的字段, * 为所有
			string sFields="*";
			SQuery=GetQuerySqlString();
			//保存查询状态
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//参数意义:1.查询表或视图,必须有唯一列, 2.指明主键(唯一列) 3.输出参数 页大小 4.页尺寸(一页多少记录) 5.当前查询页码 6.排序字段 7.排序方式 8.查询条件 9.查询字段
			AdvancedSearchGo("v_Asset_Budget_Compare_CheckMoney","rum",out oPageViewState.PCount,15,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
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

		//控制翻页
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


		#region 查询条件
		private string GetQuerySqlString()
		{
			StringBuilder filter=new StringBuilder();

			//年份
			if(!"".Equals(this.txtDate_Year.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Iyear = " +" '" + this.txtDate_Year.Text+ "'" );
			}

			//部门
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				

				Entiy.BaseDept[] baseDept=Entiy.BaseDept.FindByBudgetSuperiorDeptPk(this.ddlDeptClass.SelectedValue);
				
				string deptStr="";
				foreach(Entiy.BaseDept dept in baseDept)
				{	
					deptStr+=dept.BudgetDeptCode+",";
				}
				//根据部门编码查对应的科
				if(deptStr.Length>0)
				{
					int len=deptStr.LastIndexOf(",");
					deptStr=deptStr.Substring(0,len);
				}

					 filter.Append(" DeptCode in(" + deptStr+ ")");
			}

			//正常的
			if(this.radio_normal.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" asset_budget_checkMoney=asset_applySheet_body_checkMoney" );
			}

			//异常的(根据web.config配置的差额来比较) 
			if(this.radion_exception.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				//获取web.config配置的值
				string checkMoney = System.Configuration.ConfigurationSettings.AppSettings["CheckMoney"];
				filter.Append(" asset_budget_checkMoney<>asset_applySheet_body_checkMoney AND ABS(asset_budget_checkMoney-asset_applySheet_body_checkMoney)>"+checkMoney );
			}

			string returnValue=filter.ToString();
			return returnValue;

		}

		#endregion
		

		private void dgApply_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
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
			this.btnConsistency.Click += new System.EventHandler(this.btnConsistency_Click);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// 一键维护
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConsistency_Click(object sender, System.EventArgs e)
		{
			foreach (DataGridItem dgItem in dgApply.Items)
			{
				Control con= dgItem.Cells[0].FindControl("chkSelect");

				if(con!=null)
				{
					if(((CheckBox)con).Checked)
					{
						string Iyear=dgItem.Cells[2].Text;
						string DeptCode=dgItem.Cells[3].Text;
						//string DeptName=dgItem.Cells[4].Text;
						string ItemName=dgItem.Cells[5].Text;
						string SubjectName=dgItem.Cells[6].Text;

						Bussiness.AssetBudgetBll.ConsistencyCheckMoney(Iyear,DeptCode,ItemName,SubjectName);

						
					}
				}
			}

			bindGrid();
		}



	

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{
				string checkMoney1= e.Item.Cells[7].Text;//预算表里记录的使用金额
				string checkMoney2= e.Item.Cells[8].Text;//提交的申请单统计的使用金额

				if(!checkMoney1.Equals(checkMoney2))//不相等给出红色字提示
				{
					e.Item.Cells[7].ForeColor=Color.Red;
				}
				
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();
		}





	}
}

