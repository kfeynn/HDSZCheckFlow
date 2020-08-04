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
	/// Asset_BudgetCost_Contrast 的摘要说明。
	/// </summary>
	public class Asset_BudgetCost_Contrast : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlItemName;
		protected System.Web.UI.WebControls.Button btnOutput;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
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
				//string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				Entiy.AssetBudget[] assetBudget = Entiy.AssetBudget.FindAll();

				if(assetBudget!=null)
				{
					
					for(int i=0;i<assetBudget.Length;i++)
					{
						ddlItemName.Items.Add(assetBudget[i].ItemName+"\\"+assetBudget[i].SubjectName);
					}

					ddlItemName.Items.Insert(0,"");
				}

				Entiy.BaseDept[] dept =  Entiy.BaseDept.FindAll();


				if(dept!=null)
				{
					
					for(int i=0;i<dept.Length;i++)
					{
						if(dept[i].Dr==0)
						{
							ddlDeptClass.Items.Add(new ListItem(dept[i].DeptName,dept[i].BudgetDeptCode));
						}
						
					}

					ddlDeptClass.Items.Insert(0,"");
				}

				/*
				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}
				*/
				
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("Asset.BudgetCost.Asset_BudgetCostUseDetialInfo",ex.Message );
			}

		}


		#endregion 

		private void bindGrid()
		{
			try
			{
				// 查询银行帐号信息 

				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                       //返回参数, 记录总数
				oPageViewState.PSize=5;                   //返回参数,   页大小
				oPageViewState.PIndex=1;                  //当前查询页码
				oPageViewState.SortType=2;           //排序方式
				oPageViewState.SSort="applySheetHead_pk";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString());
				Common.Log.Logger.Log("UI.Asset.BudgetCost.Asset_BudgetCostUseDetialInfo.bindGrid",ex.Message );
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
			AdvancedSearchGo("v_AssetBudgetAndCost_Contrast","编号",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		
		
		/// <summary>
		/// 获取并构造查询条件参数
		/// </summary>
		/// <returns></returns>
		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.ddlDeptClass.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("部门编码 = " +" '" + this.ddlDeptClass.SelectedItem.Value + "'" );
			}
			if(!"".Equals(this.txtDate.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("年份 = " +" '" + this.txtDate.Text+ "'" );
			}
			
			if(!"".Equals(this.ddlItemName.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemName=this.ddlItemName.SelectedItem.Text;
				string temp=tempItemName.Substring(tempItemName.LastIndexOf("\\")+1,tempItemName.Length-(tempItemName.LastIndexOf("\\")+1));

				filter.Append("项目内容 = " +" '" +temp + "'" );
			}
				
			string returnValue=filter.ToString();

			//			if(returnValue.Trim().Length>0)
			//			{
			//				returnValue=" where "+returnValue;
			//			}

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




		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();

		}

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


		private void btnOutput_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			//this.dgApply.HeaderStyle.BackColor=Color.White;
			//导到Excel
			string cmdStr = "select * from v_AssetBudgetAndCost_Contrast ";
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

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm (control);
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
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
