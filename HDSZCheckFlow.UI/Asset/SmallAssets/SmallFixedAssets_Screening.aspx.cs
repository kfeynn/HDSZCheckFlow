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
using HDSZCheckFlow.DataAccess;
using HDSZCheckFlow.Bussiness;


namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssets_Screening 的摘要说明。
	/// </summary>
	public class SmallFixedAssets_Screening : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnEntryOK;
		protected System.Web.UI.WebControls.Button btnFail;
		protected System.Web.UI.WebControls.Label lblMsg;
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
				Common.Log.Logger.Log("v_SmallFixedAssets_Screening",ex.Message );
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
			this.dgApply.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemCreated);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.btnEntryOK.Click += new System.EventHandler(this.btnEntryOK_Click);
			this.btnFail.Click += new System.EventHandler(this.btnFail_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



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
			AdvancedSearchGo("v_SmallFixedAssets_Screening","Id",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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

			//			if(filter.Length>0)
			//			{
			//				filter.Append(" and ");
			//			}
			//			filter.Append("  ( cast(rmbprice as decimal) >= 500 )     " );
		
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



		

		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox chbAll=(CheckBox)sender;
			//全选
			if(chbAll.Checked )
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

		

		/// <summary>
		/// 确实为小额固定资产 (liyang 2013-10-31)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEntryOK_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text= "" ; 
			bool flag=false;

			try
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					if( chkCode.Checked )
					{
						flag=true;
						string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
						Entiy.SmallFixedAsset sfa=new Entiy.SmallFixedAsset();
						Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

						string sql="select * from v_SmallFixedAssets_Screening where id='"+ID+"'";
						DBAccess dbAccess=new SQLAccess();				
						DataSet ds = dbAccess.ExecuteDataset(sql);
						if(sfa != null && ds.Tables[0].Rows.Count>0)
						{ 
							sfa.InvSheetId=ID;
							sfa.Vbillcode=ds.Tables[0].Rows[0]["vbillcode"].ToString();
							sfa.Cinventoryid=ds.Tables[0].Rows[0]["cinventoryid"].ToString();
							sfa.Dbizdate=ds .Tables[0].Rows[0]["dbizdate"].ToString();
							sfa.Price=ds.Tables[0].Rows[0]["OriginalcurPrice"].ToString();
							sfa.CurrTypeCode=ds.Tables[0].Rows[0]["CurrTypeCode"].ToString();
							sfa.Noutnum=Common.Util.CommonUtil.MySubString(ds.Tables[0].Rows[0]["noutnum"].ToString());//去除小数点
                            sfa.INum = int.Parse(Common.Util.CommonUtil.MySubString(ds.Tables[0].Rows[0]["noutnum"].ToString()));
							sfa.Ninnum=ds.Tables[0].Rows[0]["ninnum"].ToString();
							sfa.Cwarehouseid=ds.Tables[0].Rows[0]["cwarehouseid"].ToString();
							sfa.Cdispatcherid=ds.Tables[0].Rows[0]["cdispatcherid"].ToString();
							sfa.Cdptid=ds.Tables[0].Rows[0]["cdptid"].ToString();
							SmallFixedBLL.Save(sfa);

							lblMsg.Text= "添加成功！";

							//暂时屏蔽
//							//修改过滤表(将选为小固定资产的数据从过滤表里置为2，不再出现在可选数据里，过滤表的1和2不出现在可选数据里)
//							if(SmFlag != null)
//							{
//								SmFlag.IsFlag = 2 ;
//								SmFlag.Save ();	
//							}
//							else//解决SmallFixedAssetsFlag表没有该数据，就记录这数据，以免再次出现在可选数据里。
//							{							
//								Entiy.SmallFixedAssetsFlag SmFlag_new = new Entiy.SmallFixedAssetsFlag();
//								SmFlag_new.InvSheetId=ID;
//								SmFlag_new.IsFlag = 2 ;
//								SmallFixedAssetsFlagBLL.Save(SmFlag_new);	 	
//								//SmFlag_new.Create();
//							}
						}
					}
				}
				if(!flag)
				{
					lblMsg.Text="请选择以上数据再操作！";
					return;
				}
//				else
//				{
//					lblMsg.Text="";
//				}
				
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("btnEntryOK_Click",ex.Message );
			}

			//重新绑定
			//bindSearchResult();
		}

		/// <summary>(liyang 2013-10-31)
		/// 不是小额固定资产(在可选数据里去除不是小额固定资产做法是将标志置为1，让数据不出现在可选数据里)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFail_Click(object sender, System.EventArgs e)
		{
			bool flag=false;
			try
			{
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					flag=true;
					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 

					Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

					if(SmFlag != null)
					{
						SmFlag.IsFlag = 1 ;

						SmFlag.Save ();
					}
					else
					{
						//新曾加实例

//						string cmdStr = " insert into SmallFixedAssetsFlag(invsheetid,isflag) values ('" + ID + "', 1 ) ";
//						Bussiness.ComQuaryBLL.ExecuteStr(cmdStr);

						Entiy.SmallFixedAssetsFlag SmFlag_new = new Entiy.SmallFixedAssetsFlag();
						SmFlag_new.InvSheetId=ID;
						SmFlag_new.IsFlag = 1 ;
						SmallFixedAssetsFlagBLL.Save(SmFlag_new);	 


					}

				}
			}
			if(!flag)
			{
				lblMsg.Text="请选择以上数据再操作！";
				return;
			}
			else
			{
				lblMsg.Text="";
			}
				
		}
		catch(Exception ex)
		{
			Common.Log.Logger.Log("btnFail_Click",ex.Message );
		}


			//重新绑定
			bindSearchResult();
		}

		private void dgApply_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				CheckBox chbAll=(CheckBox)e.Item.FindControl("chbAll");
				if(chbAll!=null)
				{
					chbAll.CheckedChanged+=new EventHandler(chbSelectAll_CheckedChanged);
				}
			}
		}

		private void btnExportExcel_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssets_Screening";
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

		/// <summary>
		/// 避免导入Excel出现的异常
		/// </summary>
		/// <param name="control"></param>
		public override void VerifyRenderingInServerForm(Control control)
		{
		}



	}
}
