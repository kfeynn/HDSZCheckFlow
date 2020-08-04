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
	/// ApplyOfCompanyState 的摘要说明。
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


		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//排序方式 1,升序.2降序
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
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
				// 查询银行帐号信息 

				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                       //返回参数, 记录总数
				oPageViewState.PSize=50;                   //返回参数,   页大小
				oPageViewState.PIndex=1;                  //当前查询页码
				oPageViewState.SortType=2;           //排序方式
				oPageViewState.SSort="id";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort.ToString();                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
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
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //点击审批按钮
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
			AdvancedSearchGo("v_Order_Info","id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

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
			this.dgOrder.DataSource=null;        //记录表置空
			this.dgOrder.DataBind();
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
			//1. 已经完成的审批
			//2. 未完成的审批
			//3. 被拒绝的审批

			//帮定审批信息
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
			//帮定各审批着审批记录
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

	}
}
