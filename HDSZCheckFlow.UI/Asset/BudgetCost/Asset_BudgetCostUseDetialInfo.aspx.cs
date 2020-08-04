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
	/// Asset_BudgetCostUseDetialInfo 的摘要说明。
	/// </summary>
	public class Asset_BudgetCostUseDetialInfo : System.Web.UI.Page
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

		
		#region  初始化方法

		private void InitPageForAdd()
		{
			try
			{
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);

				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery("select 项目类型  from v_AssetBudgetCostDetialInfo  where  superior_Dept_pk ='"+deptClassCode+"'") ;

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
				oPageViewState.SortType=1;           //排序方式
				oPageViewState.SSort="编号";        //排序字段

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
			AdvancedSearchGo("v_AssetBudgetCostDetialInfo","编号",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			/*
			if(!"".Equals(this.ddlDeptClass.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("部门编码 = " +" '" + this.ddlDeptClass.SelectedItem.Value + "'" );
			}
			*/
			if(!"".Equals(this.txtDate.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("年份 = " +" '" + this.txtDate.Text+ "'" );
			}


			//项目类型
			if(!"".Equals(this.ddlItemType.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemType=this.ddlItemType.SelectedItem.Text;
				//string temp=ddlItemType.Substring(tempItemName.LastIndexOf("\\")+1,tempItemName.Length-(tempItemName.LastIndexOf("\\")+1));

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
				//string temp=tempItemName.Substring(tempItemName.LastIndexOf("\\")+1,tempItemName.Length-(tempItemName.LastIndexOf("\\")+1));

				filter.Append("项目内容 = " +" '" +tempItemName + "'" );
			}
				

			// 只能查询自己所在部门的单据
			string myDepeClass = Bussiness.DeptBLL.GetMyDeptClass(int.Parse(User.Identity.Name));

			if(!"".Equals(myDepeClass))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" superior_Dept_pk = " +" '" + myDepeClass + "'" );
			}

			string returnValue=filter.ToString();

//			if(returnValue.Trim().Length>0)
//			{
//				returnValue=" where "+returnValue;
//			}

			return returnValue;
			#endregion  
		}




		string budgetInMoney;//预算内金额
		string budgetOutMoney;//预算外金额
		string budgetChangeOutMoney;//调出金额
		string budgetChangeInMoney;//调入金额
		string changeAfterMoney;//调整后的金额
		string useMoney;//使用金额
		string leftMoney;//剩余金额
	
		private void BindSumInfo()
		{
			try
			{
				//绑定合计信息 
				string cmdStr = @"select 
									sum(预算内金额)预算内金额,
									sum(预算外金额)预算外金额,
									sum(调出金额)调出金额,
									sum(调入金额)调入金额,
									sum(调整后预算金额)调整后预算金额,
									sum(使用金额)使用金额,
									sum(剩余金额)剩余金额
									from v_AssetBudgetCostDetialInfo";

				string filter = GetQuerySqlString(); 
				if(filter .Length  > 0)
				{
					cmdStr = cmdStr + " where " + filter ; 
				}
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
				if(ds!=null & ds.Tables.Count>0 && ds.Tables[0].Rows.Count > 0)
				{
					budgetInMoney= decimal.Parse(ds.Tables[0].Rows[0]["预算内金额"].ToString()).ToString("N2");
					budgetOutMoney= decimal.Parse(ds.Tables[0].Rows[0]["预算外金额"].ToString()).ToString("N2");
					budgetChangeOutMoney= decimal.Parse( ds.Tables[0].Rows[0]["调出金额"].ToString()).ToString ("N2");
					budgetChangeInMoney= decimal.Parse(ds.Tables[0].Rows[0]["调入金额"].ToString()).ToString ("N2");
					changeAfterMoney= decimal.Parse(ds.Tables[0].Rows[0]["调整后预算金额"].ToString()).ToString("N2");
					useMoney = decimal.Parse(ds.Tables[0].Rows[0]["使用金额"].ToString()).ToString("N2");
					leftMoney = decimal.Parse(ds.Tables[0].Rows[0]["剩余金额"].ToString()).ToString("N2");
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
			BindSumInfo();
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
			BindSumInfo();
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			//this.dgApply.HeaderStyle.BackColor=Color.White;
			//导到Excel
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
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

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

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			
			if (e.Item.ItemType == ListItemType.Footer)
			{
				e.Item.Cells[1].ColumnSpan=5;
				e.Item.Cells[1].Text = "合计";
				e.Item.Cells[2].Text =  budgetInMoney;
				e.Item.Cells[3].Text =  budgetOutMoney;
				e.Item.Cells[4].Text = budgetChangeOutMoney;
				e.Item.Cells[5].Text = budgetChangeInMoney;
				e.Item.Cells[6].Text = changeAfterMoney;
				e.Item.Cells[7].Text = useMoney ;
				e.Item.Cells[8].Text = leftMoney;
				e.Item.Cells[9].Visible=false;
				e.Item.Cells[10].Visible=false;
				e.Item.Cells[11].Visible=false;
				e.Item.Cells[12].Visible=false;
				e.Item.CssClass = "cssFooter";
			}
		}
	}
}
