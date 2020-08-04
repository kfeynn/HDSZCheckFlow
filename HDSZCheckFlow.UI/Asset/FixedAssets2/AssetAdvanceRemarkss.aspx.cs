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

namespace HDSZCheckFlow.UI.Asset.FixedAssets2
{
	/// <summary>
	/// AssetAdvanceRemarkss 的摘要说明。
	/// </summary>
	public class AssetAdvanceRemarkss : System.Web.UI.Page
	{

		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Label lblHidden;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.RadioButton rbtMark1;
		protected System.Web.UI.WebControls.RadioButton rbtMark2;
		protected System.Web.UI.WebControls.RadioButton rbtMark3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtBargainNo;
		//排序方式 1,升序.2降序
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
				oPageViewState.PSize=10;                   //返回参数,   页大小
				oPageViewState.PIndex=1;                  //当前查询页码
				oPageViewState.SortType=3;           //排序方式
				oPageViewState.SSort=" BargainNo desc,applysheetno desc ";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.Message );
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
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals("ReMark")) //点击审批按钮
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

					// ..initial Panel

					this.Panel1.Visible=true;
					HyperLink hl = (HyperLink)e.Item.Cells[3].Controls[0];   
					this.Label5.Text= hl.Text;
					
					Entiy.AssetFinallyPriceCheckBody applyBody = Entiy.AssetFinallyPriceCheckBody.Find(int.Parse(e.Item.Cells[0].Text));
					if(applyBody!=null)
					{
						if(applyBody.Earnest == 1)
						{
							this.CheckBox1.Checked =true;
						}
						else
						{
							this.CheckBox1.Checked =false;
						}
						this.txtDate.Text = applyBody.EarnestDatetime ;

						this.TextBox1.Text = applyBody.EarnestRemark ;
					}
					applyBody =  null;

					this.lblHidden.Visible=false;
					this.lblHidden.Text = e.Item.Cells[0].Text;

					this.lblMessage.Text = "";
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("预付款备注",ex.ToString());
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
			AdvancedSearchGo("v_Asset_FinallyCheckBody","id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				//整理 this.txtApplyNo.Text ,逗号分隔    前后添加上 单引号
				string querySheetNoStr = "";
				string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
				foreach(string aaStr in tempStr)
				{
					if(querySheetNoStr.Length > 0 )
					{
						querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
					}
					else
					{
						querySheetNoStr =  "'" + aaStr + "'" ; 
					}
				}

				filter.Append(" ApplySheetNo in  " +" (" + querySheetNoStr + ")" );
			}
			if(!"".Equals(this.txtBargainNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				filter.Append(" BargainNo  like '%"  + this.txtBargainNo.Text + "%'" );
			}
			if(!this.rbtMark3.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				if(this.rbtMark1.Checked )
				{
					filter.Append(" Earnest = 1 " );
				}
				else
				{
					filter.Append(" (Earnest = 0 or Earnest is null) " );
				}
			}

			//非新建状态
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsCheckInCompany = 1  " );
		
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

			//隐藏 底栏 

			this.Panel1.Visible = false;
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
			this.Panel1.Visible = false;
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

		private void btnEnter_Click(object sender, System.EventArgs e)
		{	
			if(!"".Equals(this.lblHidden.Text))
			{
				int isOrder = this.CheckBox1.Checked ? 1 : 0 ;

				string username = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name) );

				Entiy.AssetFinallyPriceCheckBody AFBody = Entiy.AssetFinallyPriceCheckBody.Find(int.Parse(this.lblHidden.Text));
				if(AFBody != null )
				{
					AFBody.Earnest = isOrder ;
					AFBody.EarnestDatetime = this.txtDate.Text ;
					AFBody.EarnestRemark   = this.TextBox1.Text ;
					AFBody.EarnestSigner  = username ; 
					AFBody.Update();

					this.lblMessage.Text = "修改成功!";

					//重新查询 

					PageViewState oPageViewState=new PageViewState();

					oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
					oPageViewState.SSort=this.FieldSort.Value ;
					oPageViewState.SortType=int.Parse(this.HerdSort.Value );

					this.HerdSort.Value =oPageViewState.SortType.ToString();
					PageViewState.SetPageViewState(this.ViewState , oPageViewState);
					bindSearchResult();
				}
			}
			else
			{
				this.lblMessage.Text  = "出错，找不到标注ID! " ;
			}
		}

	}
}
