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
	/// SmallFixedAssetsForCompany 的摘要说明。
	/// </summary>
	public class SmallFixedAssetsForCompany : System.Web.UI.Page
	{


		#region 

		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.TextBox txtStorage;
		protected System.Web.UI.WebControls.TextBox txtKeeperCode;
		protected System.Web.UI.WebControls.TextBox txtInvManageCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptName;
		protected System.Web.UI.WebControls.Button btnExportExcel;
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
				/*DataTable dtType=Bussiness.SmallFixedBLL.GetNCTypeInfo();
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[1].ToString();
					ddlType.DataTextField=dtType.Columns [2].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}*/

			/*	DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();;      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}*/



				DataTable dtDeptBySmallFixed=Bussiness.CheckFlowInDeptBLL.GetAllDeptBySmallFixed();

				if(dtDeptBySmallFixed!=null && dtDeptBySmallFixed.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptBySmallFixed;
					ddlDeptClass.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlDeptClass.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
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
				oPageViewState.SSort=" [NC_DeptName] asc,[invCode] asc, [dbizdate] desc ";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("SmallFixedAssetsForCompany",ex.Message );
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
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
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
			AdvancedSearchGo("v_SmallFixedAssets_ForAll","Id",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState); 
		}

		private string GetQuerySqlString()
		{
			#region  整理查询条件

			StringBuilder filter=new StringBuilder();


			if(!"".Equals(this.txtInv.Text)) //存货编码
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invCode like '%" + this.txtInv.Text.Trim()  + "%' " );		
			}

			if(!"".Equals(this.txtName .Text))//存货名称
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invName like '%" + this.txtName.Text.Trim()  + "%' " );
			}

			//txtInvManageCode
			if(!"".Equals(this.txtInvManageCode .Text))//管理编码
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" InvManageCode like '%" + this.txtInvManageCode.Text.Trim()  + "%' " );
			}

			//txtStorage
			if(!"".Equals(this.txtStorage .Text))//存放地点
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Storage like '%" + this.txtStorage.Text.Trim()  + "%' " );
			}

			//txtKeeperCode
			if(!"".Equals(this.txtKeeperCode .Text))//责任人工号
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" KeeperCode like '%" + this.txtKeeperCode.Text.Trim()  + "%' " );
			}


			if(!"".Equals(this.ddlDeptClass.SelectedValue ))//部门
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptClassCode  =  '" + this.ddlDeptClass.SelectedValue  + "' " );

			}

			//科组
			if(!"".Equals(this.ddlDeptName.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptCode  =  '" + this.ddlDeptName.SelectedValue  + "' " );

			}
			

			/*if(!"".Equals(this.ddlType .SelectedValue ))//分类
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invClassCode  =  '" + this.ddlType.SelectedValue  + "' " );	
			}*/



			if(!"".Equals(this.txtDateFrom.Text ))//购入日期开始
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  >=  '" + this.txtDateFrom.Text  + "' " );
			}

			if(!"".Equals(this.txtDateTo.Text ))//购入日期结束
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
			filter.Append(" IsRetire <> 1 " );//是否报费(0 不报废； 1 已报废)

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



		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//			//绑定给定按钮提示信息
			//			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			//			{ 
			//				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
			//				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认取消吗?');"); 
			//			}

		}

		/// <summary>
		/// 选择部门拉出科组 (部门科组联动)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//绑定科组
			this.ddlDeptName.Items.Clear();
			string bmbh=this.ddlDeptClass.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(dtDeptClassCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptName .DataSource=dtDeptClassCode;
				ddlDeptName.DataValueField=dtDeptClassCode.Columns["bmbh"].ToString();
				ddlDeptName.DataTextField =dtDeptClassCode.Columns["bmmc"].ToString();
				ddlDeptName.DataBind();
				ddlDeptName.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDeptName.DataSource=null;
				ddlDeptName.DataBind();
			}
		}

		private void btnExportExcel_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssets_ForAll";
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

			//重新绑定
			bindSearchResult();
		}
	}
}
