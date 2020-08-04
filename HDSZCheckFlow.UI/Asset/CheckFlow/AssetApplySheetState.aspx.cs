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

namespace HDSZCheckFlow.UI.Asset.CheckFlow
{
	/// <summary>
	/// AssetApplySheetState 的摘要说明。
	/// </summary>
	public class AssetApplySheetState : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList ddlItemName;
		protected System.Web.UI.WebControls.TextBox txtBargainNo;
		protected System.Web.UI.WebControls.TextBox txtInventoryName;
		protected System.Web.UI.WebControls.DataGrid dgStateBody;
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
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);

				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery("select 项目类型  from v_AssetBudgetCostDetialInfo") ;

				ddlItemType.DataSource=ds;
				ddlItemType.DataTextField=ds.Tables[0].Columns["项目类型"].ToString();
				ddlItemType.DataBind();
				ddlItemType.Items.Insert(0,"");

				ddlItemName.Items.Insert(0,"");
		
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
			AdvancedSearchGo("v_Asset_ApplySheetState","ApplySheetNo",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		
		
		/// <summary>
		/// 获取并构造查询条件参数
		/// </summary>
		/// <returns></returns>
		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtBargainNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("BargainNo like " +" '%" + this.txtBargainNo.Text+ "%'" );
			}


			//项目类型
			if(!"".Equals(this.ddlItemType.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemType=this.ddlItemType.SelectedItem.Text;

				filter.Append("项目类型 = " +" '" +tempItemType + "'" );
			}

			object obj=ddlItemName.SelectedItem;

			
			//项目内容
			if(this.ddlItemName!=null && !"".Equals(this.ddlItemName.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemName=this.ddlItemName.SelectedItem.Text;

				filter.Append("项目内容 = " +" '" +tempItemName + "'" );
			}

			//物品名称
			if(!"".Equals(this.txtInventoryName.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("InventoryName like " +" '%" + this.txtInventoryName.Text+ "%'" );
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




		/// <summary>
		/// 查询
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
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


		/// <summary>
		/// 导出Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOutput_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			string cmdStr = "select * from v_AssetBudgetCostDetialInfo ";
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
		/// 避免导入Excel出现的异常
		/// </summary>
		/// <param name="control"></param>
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
			this.ddlItemType.SelectedIndexChanged += new System.EventHandler(this.ddlItemType_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.SelectedIndexChanged += new System.EventHandler(this.dgApply_SelectedIndexChanged);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// 项目类型联动项目内容
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ddlItemType_SelectedIndexChanged(object sender, System.EventArgs e)
		{

			ddlItemName.Items.Clear();
			string itemName=ddlItemType.SelectedItem.Text;

			Entiy.AssetBudget[] assetBudget = Entiy.AssetBudget.FindByItemName(itemName);

			if(assetBudget!=null)
			{
					
				for(int i=0;i<assetBudget.Length;i++)
				{
					ddlItemName.Items.Add(assetBudget[i].SubjectName);
				}

				ddlItemName.Items.Insert(0,"");
			}



		}

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			
			if (e.CommandName == "SELECT") 
			{ 
				string bargainNo=e.CommandArgument.ToString();
				string cmdStr = "select * from v_Asset_ApplySheetState_Body  where BargainNo='"+bargainNo+"'";

				DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;

				this.dgStateBody.DataSource=ds;
				this.dgStateBody.DataBind();

			} 
		}

		private void dgApply_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


	}
}
