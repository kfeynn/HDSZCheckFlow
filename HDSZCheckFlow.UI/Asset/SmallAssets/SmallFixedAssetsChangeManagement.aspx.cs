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
	/// SmallFixedAssetsChangeManagement 的摘要说明。
	/// </summary>
	public class SmallFixedAssetsChangeManagement : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Button btnExport;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label lblInvName;
		protected System.Web.UI.WebControls.TextBox txtPeriod;
		protected System.Web.UI.WebControls.TextBox txtRetireNum;
		protected System.Web.UI.WebControls.TextBox txtReMark;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtPrice;
		protected System.Web.UI.WebControls.TextBox txtCurrTypeCode;
		protected System.Web.UI.WebControls.TextBox txtNoutnum;
		protected System.Web.UI.WebControls.Label lblID;
		protected System.Web.UI.WebControls.TextBox txtInv;

		#endregion 
		protected System.Web.UI.WebControls.Label lblBApplyDeptClassCode;
		protected System.Web.UI.WebControls.TextBox txtDatetime;
		protected System.Web.UI.WebControls.TextBox txtImporterCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlBDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlAClassDept;
		protected System.Web.UI.WebControls.DropDownList ddlClassDeptCode;
		
		DBAccess dbAccess=new SQLAccess();		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.btnDel.Attributes.Add("onclick","javascript:return confirm('您确认取消吗?');"); 
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

				DataTable dtDeptBySmallFixed=Bussiness.CheckFlowInDeptBLL.GetAllDeptBySmallFixed();

				if(dtDeptBySmallFixed!=null && dtDeptBySmallFixed.Rows.Count>0)
				{
					// 表头部门
					this.ddlBDeptClass.DataSource=dtDeptBySmallFixed;
					ddlBDeptClass.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlBDeptClass.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlBDeptClass.DataBind();
					ddlBDeptClass.Items.Insert(0,"");

				
					
					this.ddlAClassDept.DataSource = dtDeptBySmallFixed;
					ddlAClassDept.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlAClassDept.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlAClassDept.DataBind();
					ddlAClassDept.Items.Insert(0,"");


					/////////////////////
					

						// 表头部门
					this.ddlClassDeptCode.DataSource=dtDeptBySmallFixed;
					ddlClassDeptCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlClassDeptCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlClassDeptCode.DataBind();
					ddlClassDeptCode.Items.Insert(0,"");

				
//				
//					this.ddlDeptCode.DataSource = dtDeptBySmallFixed;
//					ddlDeptCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
//					ddlDeptCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
//					ddlDeptCode.DataBind();
//					ddlDeptCode.Items.Insert(0,"");


				}

			


//				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();      // 0 查询所有部门
//				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
//				{
//					//转移前部门
//					this.ddlDeptClass.DataSource=dtDeptClass;
//					ddlDeptClass.DataValueField= dtDeptClass.Columns[0].ToString(); 
//					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlDeptClass.DataBind();
//					ddlDeptClass.Items.Insert(0,"");
//					
//					//转移后部门
//					this.ddlOut_NC_DeptName.DataSource=dtDeptClass;
//					ddlOut_NC_DeptName.DataValueField=dtDeptClass.Columns[0].ToString();
//					ddlOut_NC_DeptName.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlOut_NC_DeptName.DataBind();
//					ddlOut_NC_DeptName.Items.Insert(0,"");
//
//					
//
//
//					//转移部门
//					this.ddlDeptClassCode.DataSource=dtDeptClass;
//					this.ddlDeptClassCode.DataValueField=dtDeptClass.Columns[0].ToString();
//					this.ddlDeptClassCode.DataTextField =dtDeptClass.Columns["DeptCode_DeptName"].ToString();
//					this.ddlDeptClassCode.DataBind();
//					this.ddlDeptClassCode.Items.Insert(0,"");
//				}

				
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
				oPageViewState.SSort=" [ID] desc ";        //排序字段

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //记录到全局变量,表头排序规则
				this.FieldSort.Value =oPageViewState.SSort;                  //同上,排序字段

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_SmallFixedAssetsChangeManagement",ex.Message ); 
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
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.ddlClassDeptCode.SelectedIndexChanged += new System.EventHandler(this.ddlClassDeptCode_SelectedIndexChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
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
			AdvancedSearchGo("v_SmallFixedAssetsChange","Id",out oPageViewState.PCount,15,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//脚标
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			lblMsg.Text="";
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

//			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" cdptid  =  '" + this.ddlDeptClass.SelectedValue  + "' " );
//			}

			if(!"".Equals(this.ddlBDeptClass.SelectedValue ))//转移前的部门
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" BApplyDeptClassCode  =  '" + this.ddlBDeptClass.SelectedValue  + "' " );

			}

			if(!"".Equals(this.ddlAClassDept.SelectedValue ))//转移后的部门
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" AApplyDeptClassCode  =  '" + this.ddlAClassDept.SelectedValue  + "' " );

			}


			if(!"".Equals(this.txtImporterCode.Text ))//录入员工号
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ImporterCode  =  '" + this.txtImporterCode.Text  + "' " );
				
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
				filter.Append(" Datetime  >=  '" + this.txtDateFrom.Text  + "' " );
			}

			if(!"".Equals(this.txtDateTo.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Datetime  <=  '" + this.txtDateTo .Text  + "' " );
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

		/// <summary>
		/// 编辑 (liyang 2013-11-05)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			this.ddlClassDeptCode.SelectedIndex=0;
			this.txtDatetime.Text="";
			this.txtReMark.Text="";

			int count=0;
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked)
				{
					count++;
				}
			}
			if(count!=1)
			{
				this.lblMsg.Text="请选择一条记录编辑";
				return;
			}
			else
			{
				this.lblMsg.Text="";
			}

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					Entiy.SmallFixedAsset sfa=new Entiy.SmallFixedAsset();
					Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

					string sql="select * from v_SmallFixedAssetsChange where id='"+ID+"'";
							
					DataSet ds = dbAccess.ExecuteDataset(sql);
					if(ds.Tables[0].Rows.Count>0)
					{
						this.lblID.Text=ds.Tables[0].Rows[0]["ID"].ToString();//隐藏字段
						this.lblInvName.Text="品种名称: "+ds.Tables[0].Rows[0]["InvName"].ToString();
						this.lblBApplyDeptClassCode.Text=ds.Tables[0].Rows[0]["bdeptclassname"].ToString() + ds.Tables[0].Rows[0]["bdeptname"].ToString(); 
						this.txtDatetime.Text=String.Format("{0:yyyy-MM-dd}",ds.Tables[0].Rows[0]["Datetime"]);
						this.txtReMark.Text=ds.Tables[0].Rows[0]["ReMark"].ToString(); 
					}
				}
			}
		}


		/// <summary>
		/// 转移数据提交
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(this.lblID.Text==null || this.lblID.Text=="")
			{
				this.lblMsg.Text="请选择要转移的数据";
				return;
			}

			if(this.ddlClassDeptCode.SelectedIndex==0)
			{
				this.lblMsg.Text="请选择转移到哪个部门";
				return;
			}
			if(this.txtDatetime.Text==null || this.txtDatetime.Text=="")
			{
				this.lblMsg.Text="请选择日期";
				return;
			}
			
			Visitor MyVisitor = new Visitor(); 
			Entiy.SmallFixedAssetsChange sfac=Entiy.SmallFixedAssetsChange.Find(Int32.Parse(this.lblID.Text));
//			sfac.Bdptid=sfac.Bdptid;//转移前部门
//			sfac.Adptid=this.ddlAApplyDeptClassCode.SelectedValue;//转移后部门 

			sfac.AApplyDeptClassCode = this.ddlClassDeptCode.SelectedValue;
			sfac.AApplyDeptCode      = this.ddlDeptCode.SelectedValue;

			sfac.Datetime=DateTime.Parse( this.txtDatetime.Text);
			sfac.ReMark=this.txtReMark.Text;
			sfac.ImporterCode=MyVisitor.GetUserName;//操作员
			
			sfac.Save(); 

			Entiy.SmallFixedAsset sfa=Entiy.SmallFixedAsset.Find(sfac.SmallFixedAssetsId);
			//更改SmallFixedAsset的部门
			//sfa.Cdptid=this.ddlClassDeptCode.SelectedValue;//转移后部门

			sfa.DeptClassCode =  this.ddlClassDeptCode.SelectedValue;
			sfa.DeptCode =  this.ddlDeptCode.SelectedValue;



			sfa.Save();

			//重新绑定
			bindSearchResult();
			this.ddlClassDeptCode.SelectedIndex=0;
			this.lblInvName.Text="&nbsp;";
			this.lblBApplyDeptClassCode.Text="";
			this.txtDatetime.Text="";
			this.txtReMark.Text="";
		}

		/// <summary>
		/// 删除
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					if(ID!=null || ID!="")
					{
						string sql="delete from SmallFixedAssetsChange where ID="+ID;
						dbAccess.ExecuteNonQuery(sql);
					}
				}
			}

			//重新绑定
			bindSearchResult();
		}


		/// <summary>
		/// 导出Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssetsChange";
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

		private void ddlClassDeptCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//绑定科组
			this.ddlDeptCode.Items.Clear();
			string bmbh=this.ddlClassDeptCode.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(ddlDeptCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptCode .DataSource=dtDeptClassCode;
				ddlDeptCode.DataValueField=dtDeptClassCode.Columns["bmbh"].ToString();
				ddlDeptCode.DataTextField =dtDeptClassCode.Columns["bmmc"].ToString();
				ddlDeptCode.DataBind();
				ddlDeptCode.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDeptCode.DataSource=null;
				ddlDeptCode.DataBind();
			}
		}

	
	}
}
