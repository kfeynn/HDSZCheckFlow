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


namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// GetBackPriceCheckApply 的摘要说明。
	/// </summary>
	public class GetBackPriceCheckApply : System.Web.UI.Page
	{
		#region
		protected System.Web.UI.WebControls.DataGrid dgApply;
//		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
//		protected System.Web.UI.WebControls.Button btnQuery;
//		protected System.Web.UI.WebControls.DropDownList ddlType;
//		protected System.Web.UI.WebControls.TextBox txtDateFrom;
//		protected System.Web.UI.WebControls.TextBox txtDateTo;
//		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
//		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.DataGrid dgPostail;//排序方式 1,升序.2降序
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.Label lbMsg;
		protected System.Web.UI.WebControls.Button btnGetBack;
		protected System.Web.UI.WebControls.Button btnKeep;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyHead;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
//		protected System.Web.UI.WebControls.TextBox txtApplyNo;
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
				PageViewState oPageViewState=new PageViewState();          //保存状态
				oPageViewState.PCount=0;                                   //返回参数, 记录总数
				oPageViewState.PSize=5;                                   //返回参数,   页大小
				oPageViewState.PIndex=1;                                   //当前查询页码
				oPageViewState.SortType=2;                                 //排序方式
				oPageViewState.SSort="Id";                                 //排序字段
				this.HerdSort.Value =oPageViewState.SortType.ToString();   //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort.ToString();     //同上,排序字段

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
			this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
			this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
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
				//审批记录
				GetApplyRecordForFinallyCheck(int.Parse(e.Item.Cells[0].Text));

				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					if(this.dgApply.Items[i].BackColor==Color.Yellow)
					{
						this.dgApply.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow;

				//将价格裁决主键 保存到隐藏域 
				this.hideApplyHead.Value = e.Item.Cells[0].Text ; 
			}
		}

		#region  分页查询
		string SQuery="";  //查询条件
		private void bindSearchResult()
		{
			//查询的字段, * 为所有
			string sFields="*";
			//获取查询条件      
			SQuery=" IsDisallow = 1 or (IsSubmit = 1 and IsCheck = 0 ) or issubmitAgain = 1 ";
			//保存查询状态
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//参数意义:1.查询表或视图,必须有唯一列, 2.指明主键(唯一列) 3.输出参数 页大小 4.页尺寸(一页多少记录) 5.当前查询页码 6.排序字段 7.排序方式 8.查询条件 9.查询字段
			AdvancedSearchGo("v_FinallyPriceCheckList","Id",out oPageViewState.PCount,5,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			this.dgPostail.DataSource=null;        //记录表置空
			this.dgPostail.DataBind();
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

		private void GetApplyRecordForFinallyCheck(int FinallyCheckId)
		{
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecordForFinallyCheck(FinallyCheckId);
			if(ds!=null)
			{
				this.dgPostail.DataSource=ds;
			}
			else
			{
				this.dgPostail.DataSource=null;
			}
			this.dgPostail.DataBind();
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

		private void btnGetBack_Click(object sender, System.EventArgs e)
		{
			//取回单据

			//取回表单, 1,若是还没有人审批的取回, 更新为新建状态, 2.被驳回的取回,更新为取回状态

			int FinallyCheckId = int.Parse(this.hideApplyHead.Value);

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId);

			if(FinallyCheck != null )
			{
				Entiy.ApplyProcessType ApplyProcess=Entiy.ApplyProcessType.Find(FinallyCheck.ApplyProcessCode); //查看申请单进程
				if(ApplyProcess!=null)
				{
					if((ApplyProcess.IsSubmit == 1 && ApplyProcess.IsCheck==0 ) )  //新建还未有人审批 or 驳回
					{
						//更新为新建状态, 更新所采用流程pk为 0
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;
						FinallyCheck.CheckFlowInCompanyHeadPk=0;
						FinallyCheck.CurrentCheckRole="";
						FinallyCheck.IsCheckInCompany=0;
						FinallyCheck.CheckSetp=0;                                  //审批级设置为0
						FinallyCheck.Update();
						//RemoveBudget(FinallyCheck.ApplySheetHeadPk);
						//冲减已价格裁决数量
						Bussiness.AssetCheckFlowBLL.RemoveFinallyCheckNumber(FinallyCheck.Id);
					}
					else if(ApplyProcess.IsDisallow == 1)
					{
						//更新为取回状态, 更新所采用流程pk为 0
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.GetBackPross;
						FinallyCheck.CheckFlowInCompanyHeadPk=0;
						FinallyCheck.CurrentCheckRole="";
						FinallyCheck.IsCheckInCompany=0;
						FinallyCheck.CheckSetp=0;                                  //审批级设置为0
						FinallyCheck.Update();
						//RemoveBudget(FinallyCheck.ApplySheetHeadPk);
						//冲减已价格裁决数量
						Bussiness.AssetCheckFlowBLL.RemoveFinallyCheckNumber(FinallyCheck.Id);
					}
					//重新绑定
					bindGrid();
				}
				else
				{
					this.lbMsg.Text = "系统错误，没有找到单据！";
				}
			}
		}

		private void btnKeep_Click(object sender, System.EventArgs e)
		{
			//封存单据（价格裁决单暂时没有封存设置）
		}

	}
}
