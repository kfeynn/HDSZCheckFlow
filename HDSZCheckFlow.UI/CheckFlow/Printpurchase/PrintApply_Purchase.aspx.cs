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


namespace HDSZCheckFlow.UI.CheckFlow.Printpurchase
{
	/// <summary>
	/// ApplyOfCompanyState 的摘要说明。
	/// </summary>
	public class PrintApply : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;

		protected System.Web.UI.WebControls.LinkButton linkToPage;

		//public static string FieldSort="" ; //排序列名
		//public static int HerdSort=0;//排序方式 1,升序.2降序
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.TextBox txtApplySheetNo;
		//public static int pagesIndex=1;		//列标头排序时,需要记住当前的页码

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
				// 查询银行帐号信息 

				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                       //返回参数, 记录总数
				oPageViewState.PSize=50;                   //返回参数,   页大小
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
				Common.Log.Logger.Log("UI.CheckFlow.PrintApply.bindGrid",ex.Message );
			}
		}


		#region  初始化方法

		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
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
				//给url参数加密，防止偷窥,Common.Security.Cryptography.Encode
				Response.Write("<script language='javascript'>window.open('PrintPage.aspx?applyPK=" + Common.Security.Cryptography.Encode(e.Item.Cells[0].Text) + " ');</script>");

				#region 
//				Response.Redirect("PrintPage.aspx?applyPK=" + e.Item.Cells[0].Text + "");
//				DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyPhuse(int.Parse(e.Item.Cells[0].Text ));
//				DataTable ApplySheetPurchase=ds.Tables[0];
//
//				//此处生成PDF文件，list.GetView方法返回一个查询后的DataView数据集   
//				Common.Util.ReportToPDFHelper rptHelper =new HDSZCheckFlow.Common.Util.ReportToPDFHelper();
//
//				rptHelper.ExportToPDF(Server.MapPath("Report\\ReporeForPurchase.rpt"),ApplySheetPurchase,"c:\\test.pdf");   
//
//				//此处返回PDF文件，到客户端的IE中，客户端必须要安装Acrobat才可浏览   
//
//				rptHelper.ReturnPDF(Server.MapPath("Report\\ReporeForPurchase.rpt"),ApplySheetPurchase,this);   
				#endregion 
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
			AdvancedSearchGo("v_ApplySheetOfCompany","applySheetHead_Pk",out oPageViewState.PCount,12,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

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
			// 只能查询自己所在部门的单据
			string myDepeClass = Bussiness.DeptBLL.GetMyDeptClass(int.Parse(User.Identity.Name));

			if(!"".Equals(myDepeClass))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" + myDepeClass + "'" );
			}
//			//查询基本条件： 单据已经通过审批
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


		#region 
//
//		private void BindAuditingByType(string sqlWhere )
//		{
//
//			//帮定审批信息
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
