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
using AjaxPro;
using System.Text;
using System.Text.RegularExpressions;

namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// EditPriceCheckApply 的摘要说明。
	/// </summary>
	public class EditPriceCheckApply : System.Web.UI.Page
	{
		#region

		protected System.Web.UI.WebControls.Panel pAddItem;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyCheckHead;
		protected System.Web.UI.WebControls.Panel PBudgetInfo;
		protected System.Web.UI.WebControls.Label lbBudget;
		protected System.Web.UI.WebControls.Label lbOutMoney;
		protected System.Web.UI.WebControls.Label lbSumCheck;
		protected System.Web.UI.WebControls.Label lbready;
		protected System.Web.UI.WebControls.Label lbSheetMoney;
		protected System.Web.UI.WebControls.Label lbLeft;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.Button btnInBudget;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddPriceCheckApply_Setp2));

			//在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				//绑定可以编辑的单据 。 新建/取回
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

		#region  分页查询
		string SQuery="";  //查询条件
		private void bindSearchResult()
		{
			//查询的字段, * 为所有
			string sFields="*";
			//获取查询条件      
			SQuery= GetQuerySqlString();
			//保存查询状态
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//参数意义:1.查询表或视图,必须有唯一列, 2.指明主键(唯一列) 3.输出参数 页大小 4.页尺寸(一页多少记录) 5.当前查询页码 6.排序字段 7.排序方式 8.查询条件 9.查询字段
			AdvancedSearchGo("v_FinallyPriceCheckList","Id",out oPageViewState.PCount,5,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();

			// 基础条件 ： 提交状态为 1 。.暂时固定为 ApplyProcessCode 非 101  ， 201 。以后做活

			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsSubmit = 0  "  );

		
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
			//this.dgPostail.DataSource=null;        //记录表置空
			//this.dgPostail.DataBind();
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
					Common.Log.Logger.Log("UI.Asset.PriceCheck.linkToPage_Click",ex.Message );
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
				Common.Log.Logger.Log("UI.Asset.PriceCheck.linkToPage_Click",ex.Message );
			}
		}

		#endregion

		
		/// <summary>
		/// 绑定表体信息
		/// </summary>
		/// <param name="ApplyHeadPk"></param>
		private void BindApplyBodyInfo(int FinallyCheckId)
		{

			//表体详细信息
			DataSet ds= Bussiness.ApplyAuditingBLL.GetFinallyBodyInfoByCheckId(FinallyCheckId);
			if(ds!=null)
			{
				this.dgApplyBody.DataSource=ds;
			}
			else
			{
				this.dgApplyBody.DataSource=null;
			}
			this.dgApplyBody.DataBind();
			
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
			this.btnInBudget.Click += new System.EventHandler(this.btnInBudget_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private static  Color color;
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//选择按钮
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

				this.hideApplyCheckHead.Value = e.Item.Cells[0].Text ; 
				//3. 绑定表体信息
				BindApplyBodyInfo(int.Parse(e.Item.Cells[0].Text));

				//添加附件可用
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../../Asset/PriceCheck/ApplySheetAnnexForFinallyCheck.aspx?FinallyCheckId=" + e.Item.Cells[0].Text;			
			}
			//删除按钮
			else if (e.CommandName.Equals("delete")) 
			{
				//1.判断是可以删除状态 ，新建/取回 
				//2.删除价格裁决单表头，对应sqlserver会删除子表

				int FinallyCheckId = int.Parse(e.Item.Cells[0].Text);

				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId); 

				if(FinallyCheck != null )
				{
					FinallyCheck.Delete();
				}
				//重新绑定
				//bindGrid();

				PageViewState oPageViewState=new PageViewState();
				oPageViewState.PCount=0;
				oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );

				//this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			
				oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
				oPageViewState.SortType=int.Parse(this.HerdSort.Value) ;//1;

				this.HerdSort.Value =oPageViewState.SortType.ToString();
				PageViewState.SetPageViewState(this.ViewState , oPageViewState);
				bindSearchResult();
			}
		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[2].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认删除吗?');"); 
			}

		
		}

		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			//价格超过原单据价格 阻止
			//数量超过原单据数量 阻止
			//更新已价格裁决数量

			int FinallyCheckKey = int.Parse(this.hideApplyCheckHead.Value);

			//检测是否数据完整（是否有合同号等） 

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

			if(FinallyCheck != null && FinallyCheck.BargainNo.Length <= 0 ) 
			{
				this.lbMsg.Text = "合同号不能为空";
				return ;
			}

			//检测提交
			int i = Bussiness.AssetFinallyCheckPrice.CheckFinallyApplyAndBody(FinallyCheckKey);

			if(i==1)
			{
				//价格 数量合格 ，提交审批 
				int Flag = Bussiness.AssetCheckFlowBLL.StartFinallyPriceCheckFlow(FinallyCheckKey) ; 
				if(Flag == 1 )
				{
					this.lbMsg.Text = "单据已经提交！";
					//提交即占已提交数量 ， 已审批金额 
					//价格裁决表头
					//更新已经价格裁决表体数量
					Bussiness.AssetCheckFlowBLL.AddFinallyCheckNumber(FinallyCheck.Id);
				}
				else
				{
					switch(Flag)
					{
							//返回值： 1正常 2已经提交 3未找到流程 。4未找到单据。5已经提交。
						case 1:
							this.lbMsg.Text = "已成功提交！";
							break;
						case 2:
							this.lbMsg.Text ="单据已经提交！请不要重复操作";
							break;
						case 3:
							this.lbMsg.Text ="未找到流程！";
							break;
						case 4:
							this.lbMsg.Text ="未找到单据！";
							break;
					}
				}
			}
			else
			{
				switch (i)
				{
					case 2:
						this.lbMsg.Text = "价格超出";
						break;
					case 3:
						this.lbMsg.Text = "数量超出";
						break;
					case 4:
						this.lbMsg.Text ="系统出错";
						break;
				}
			}

			//重新绑定
			//bindGrid();
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;
			oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );			
			oPageViewState.SSort=this.FieldSort.Value ; 
			oPageViewState.SortType=int.Parse(this.HerdSort.Value) ; 
			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);
			bindSearchResult();
		}

	}
}
