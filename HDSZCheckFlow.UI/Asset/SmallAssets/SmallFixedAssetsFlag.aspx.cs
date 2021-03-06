//namespace HDSZCheckFlow.UI.Asset.SmallAssets
//{
//	/// <summary>
//	/// SmallFixedAssetsFlag 的摘要说明。
//	/// </summary>
//	public class SmallFixedAssetsFlag : System.Web.UI.Page
//	{
//


//OrderList
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


namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssetsFlag 的摘要说明。
	/// </summary>
	public class SmallFixedAssetsFlag : System.Web.UI.Page
	{


		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.TextBox txtInv;

		#endregion 


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
				//为下拉控件附值

				//string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.SmallFixedBLL.GetNCTypeInfo();
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[1].ToString();
					ddlType.DataTextField=dtType.Columns [2].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}

				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();;      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

				
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsFlag",ex.Message );
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
				oPageViewState.PSize=50;                   //返回参数,   页大小
				oPageViewState.PIndex=1;                  //当前查询页码
				oPageViewState.SortType=3;           //排序方式
				oPageViewState.SSort=" [dbizdate] desc ";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_NC_InvOutStoreBySheetForFlag",ex.Message );
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
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

//		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try

			{
				if(e.CommandName.Equals("ReMark")) //点击审批按钮
				{
					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						//						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						//						{
						//							this.dgApply.Items[i].BackColor= color;

						string ID = e.Item.Cells[0].Text; // this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 

						Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

						if(SmFlag != null)
						{
							SmFlag.IsFlag = 0 ;

							SmFlag.Save ();
						}

						//						}
					}
					//					color=e.Item.BackColor;
					//					e.Item.BackColor=Color.Yellow;	
				}

				bindGrid();



			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.ToString());
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
			AdvancedSearchGo("v_NC_InvOutStoreBySheetForFlag","Id",out oPageViewState.PCount,15,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();


			if(!"".Equals(this.txtInv.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invCode like '%" + this.txtInv.Text.Trim()  + "%' " );

				
			}

			if(!"".Equals(this.txtName .Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invName like '%" + this.txtName.Text.Trim()  + "%' " );

			}

			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" cdptid  =  '" + this.ddlDeptClass.SelectedValue  + "' " );

			}

			if(!"".Equals(this.ddlType .SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invClassCode  =  '" + this.ddlType.SelectedValue  + "' " );
				
			}

			if(!"".Equals(this.txtDateFrom.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  >=  '" + this.txtDateFrom.Text  + "' " );
			}

            if(!"".Equals(this.txtDateTo.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  <=  '" + this.txtDateTo .Text  + "' " );
			}

			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append("  ( cast(rmbprice as decimal) >= 500 )  and IsFlag  in ( 1,2)     " );
		
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

			DataSet ds = paginationBLL.CommonQuery1();
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



		private void btnEnter_Click(object sender, System.EventArgs e)
		{	
//			if(!"".Equals(this.lblHidden.Text))
//			{
//				int isOrder = this.CheckBox1.Checked ? 1 : 0 ;
//				Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(this.lblHidden.Text));
//				if(applyBody != null)
//				{
//					applyBody.IsOrder   = isOrder ;
//					applyBody.OrderDate = DateTime.Now;
//					applyBody.OrderNo   = this.TextBox1.Text;
//					applyBody.Update();
//					this.lblMessage.Text = "修改成功!";
//
//					//					PageViewState oPageViewState=new PageViewState();
//					//					oPageViewState.PCount=0;
//					//
//					//					oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
//					//					oPageViewState.SSort=this.FieldSort.Value ;
//					//					oPageViewState.SortType=int.Parse(this.HerdSort.Value );
//					//
//					//					this.HerdSort.Value =oPageViewState.SortType.ToString();
//					//					PageViewState.SetPageViewState(this.ViewState , oPageViewState);
//					//					bindSearchResult();
//				}
//			}
//			else
//			{
//				this.lblMessage.Text  = "出错，找不到标注ID! " ;
//			}
		}

		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			//全选
			if(this.chbSelectAll.Checked )
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					chkCode.Checked=true;
				}
			}
			else
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					chkCode.Checked=false;

					
				}
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//批量更新

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					//
//					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(this.dgApply.Items[itm.ItemIndex].Cells[0].Text));
//					if(applyBody != null)
//					{
//						applyBody.IsOrder   = 1 ;
//						applyBody.OrderDate = DateTime.Now;
//						//applyBody.OrderNo   = this.txtOrderNumber.Text.Trim() ;
//						applyBody.Update();
//					}

					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 

					Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

					if(SmFlag != null)
					{
						SmFlag.IsFlag = 0 ;

						SmFlag.Save ();
					}

				}
			}

			this.chbSelectAll.Checked = false;
			this.Label4.Text = "更新成功";

			//重新绑定
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;

			oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
			oPageViewState.SSort=this.FieldSort.Value ;
			oPageViewState.SortType=int.Parse(this.HerdSort.Value );

			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);
			bindSearchResult();

		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认取消吗?');"); 
			}

		}
	}
}
