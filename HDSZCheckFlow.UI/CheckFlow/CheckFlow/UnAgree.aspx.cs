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


namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ApplyOfCompanyState 的摘要说明。
	/// </summary>
	public class UnAgree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//排序方式 1,升序.2降序
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//		// 在此处放置用户代码以初始化页面
				//		//0. 后悔同意
				//		//1. 审批表最后一个已经同意的 角色 （代审批？）
				//		//2. 单据状态不为驳回


				InitPageForAdd();

				//				BindAuditingByType("");
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
				oPageViewState.SSort="ApplySheetHead_Pk";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort.ToString();                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UnAgree.bindGrid()",ex.Message );
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

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
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
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //点击审批按钮
			{

				string myCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
				//拒绝
				this.lblMessage.Text = "" ; 
				if(IsAuditinged(int.Parse(e.Item.Cells[0].Text),myCode) == 1 )
				{
					int CheckRecordID = int.Parse(e.Item.Cells[1].Text) ;
					Entiy.ApplySheetCheckRecord checkRecord = Entiy.ApplySheetCheckRecord.Find(CheckRecordID);
					string disPlaysCode = ""; 
					if(checkRecord.DisplaysPersonCode != null && checkRecord.DisplaysPersonCode != "")
					{
						disPlaysCode = checkRecord.DisplaysPersonCode;
					}
					else
					{
						disPlaysCode = checkRecord.CheckPersonCode ;
					}
					 
					if(myCode == disPlaysCode)
					{
						disPlaysCode = "" ;
					}

					//最后一个参数，审批意见,标志为 同意后反悔
					//string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

					Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
					Audi.Flow_AgreeApplySheet(0,myCode,int.Parse(e.Item.Cells[0].Text),disPlaysCode,"",2 );

//					Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(0,myCode,int.Parse(e.Item.Cells[0].Text),disPlaysCode,"",2 );


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
				else
				{
					this.lblMessage.Text="单据已被同级人员审批";
				}
			}
		}

		private int IsAuditinged(int applyHeadPk,string userCode)
		{
			//单据是否已经被同角色的其他人审批过了!

			#region 

//			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
//			if(applyHead!=null && applyHead.CurrentCheckRole!=null)
//			{
//				Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//				if(prossType!=null &&  prossType.IsDisallow==0)  //先看进程状态是否为驳回
//				{
//					//判断当前审批角色里是否有自己  ,,部门内或部门外都可以
//					string UserCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
//					int i=Bussiness.UserInfoBLL.GetCountOfUserRole(applyHead.CurrentCheckRole ,UserCode,applyHead.ApplyDeptCode);
//					if(i>0)
//					{
//						return 1; //属于自己
//					}
//					else
//					{
//						return 0; //可能被别人审批了
//					}
//				}
//				else
//				{
//					return 0;                 //进程状态为null或者 为驳回状态.. 不可再审
//				}
//			}
//			else
//			{
//				return 2; //未找到单据,错误
//			}

			#endregion 

			Entiy.ApplySheetCheckRecord checkRecord= Entiy.ApplySheetCheckRecord.FindLastChecker(applyHeadPk);
			if(checkRecord != null)
			{
				//审批人工号
				string checkerCode = "" ; 

				if(checkRecord.DisplaysPersonCode == null || checkRecord.DisplaysPersonCode =="")
				{
					checkerCode =  checkRecord.CheckPersonCode;
				}
				else
				{
					checkerCode =  checkRecord.DisplaysPersonCode ;
				}

				//usercode要么等于审批人工号  要么是其替审者
				if(userCode == checkerCode )
				{
					return 1 ;
				}
				else if(Bussiness.UserInfoBLL.displaysCheckRelation(checkerCode,userCode))
				{
					return 1 ;
				}
				else
				{
					return 0 ; 
				}
			}
			else
			{
				return 0 ; 
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
			AdvancedSearchGo("v_DisAgreeApplyInfo","ApplySheetHead_Pk",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" + this.ddlDeptClass.SelectedValue+ "'" );
			}
			if(!"".Equals(this.ddlDept .SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptCode = " +" '" + this.ddlDept.SelectedValue + "'" );
			}

			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			// 基础条件 ：为自己的单据 


			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));   //找属于自己的单

			string MyInfo= "(checkperson  IN (SELECT UserName FROM xpGrid_User WHERE (displaysPerson = '" + myCode + "') AND (IsDisplays = 1) OR (UserName = '" + myCode + "' )))" ;
			filter.Append(" " + MyInfo + " " );





		
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();
		}

		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//绑定科组
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlDeptClass.SelectedValue;
			DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClass(deptClass);
			if(dtDept!=null && dtDept.Rows.Count>0)
			{
				this.ddlDept.DataSource=dtDept;
				ddlDept.DataValueField=dtDept.Columns[0].ToString();
				ddlDept.DataTextField =dtDept.Columns[1].ToString();
				ddlDept.DataBind();
				ddlDept.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDept.DataSource=null;
				ddlDept.DataBind();
			}
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
			System.Web.UI.WebControls.Button  img=(System.Web.UI.WebControls.Button )e.Item.FindControl("btnLook");   
			if(!Object.Equals(img,null))   
			{   
				img.Attributes.Add("onclick","javascript:return window.confirm('您确认驳回吗？')");   
			}   
		}

	}
}
