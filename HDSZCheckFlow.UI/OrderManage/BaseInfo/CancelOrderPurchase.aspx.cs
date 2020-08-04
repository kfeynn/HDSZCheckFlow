// CancelOrderPurchase
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

namespace HDSZCheckFlow.UI.OrderManage.BaseInfo
{
	/// <summary>
	/// ApplyOfCompanyState 的摘要说明。
	/// </summary>
	public class CancelOrderPurchase : System.Web.UI.Page
	{
		#region 

		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//列标头排序时,需要记住当前的页码
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//排序列名
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtProduct;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.ImageButton imgBtnUp;
		protected System.Web.UI.WebControls.ImageButton imgBtnDown;
		protected System.Web.UI.WebControls.DataGrid dgOrder;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnSaveOrder;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IsEdit;
		protected System.Web.UI.WebControls.DropDownList ddlInvClass;
		//排序方式 1,升序.2降序
		protected System.Web.UI.WebControls.TextBox txtApplyNo;

		#endregion 

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				
				bindGrid();

				this.dgOrder.DataSource= Bussiness.OrderManageBLL.GetNormalTable() ;
				this.dgOrder.DataBind();
			}
		}

		private void InitPageForAdd()
		{
			try
			{
				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 查询所有部门
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

				string cmdStr = "SELECT invClass_pk, InvClassName FROM Base_InvClass where (LEN(invclasscode) > 1)  and (LEFT(invclasscode, 1) in  ('E','F'))  ORder by invclasscode";
				DataTable dt = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr).Tables[0];
				if(dt!=null && dt.Rows.Count>0)
				{
					this.ddlInvClass .DataSource=dt;
					ddlInvClass.DataValueField=dt.Columns[0].ToString();
					ddlInvClass.DataTextField =dt.Columns[1].ToString();
					ddlInvClass.DataBind();
					ddlInvClass.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("HDSZCheckFlow.UI.OrderManage.BaseInfo.PickPurchase",ex.Message);
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
				oPageViewState.SortType=3;           //排序方式
				oPageViewState.SSort="ApplySheetNo desc ,InventoryCode";        //排序字段

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
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.imgBtnUp.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnUp_Click);
			this.imgBtnDown.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnDown_Click);
			this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
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

					HyperLink hl = (HyperLink)e.Item.Cells[3].Controls[0];   
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(e.Item.Cells[0].Text));
					if(applyBody!=null)
					{
					}
					applyBody =  null;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.Message );
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
			AdvancedSearchGo("v_BaseApplyPurchase","ApplySheetBody_Purchase_pk",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			if(!"".Equals(this.txtProduct.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				//整理 this.txtProduct.Text ,逗号分隔    前后添加上 单引号
				string queryProductStr = "";
				string []testStr = this.txtProduct.Text.Split(new char[] {','});
				foreach(string aaaStr in testStr)
				{
					if(queryProductStr.Length > 0 )
					{
						queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
					}
					else
					{
						queryProductStr =  "'" + aaaStr + "'" ; 
					}
				}

				filter.Append(" InventoryCode in   " +"(" + queryProductStr + ")" );
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

			if(!"".Equals(this.ddlDeptClass.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" +  this.ddlDeptClass.SelectedValue + "'" );
			}
			if(!"".Equals(this.ddlDept.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyDeptCode = " +" '" +  this.ddlDept.SelectedValue + "'" );
			}
			if(!"".Equals(this.ddlInvClass.SelectedValue ))
			{
				//"SELECT invCode FROM Base_inventory WHERE (InvClass_pk = '0001AA00000000001ANM')";
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" InventoryCode in  (  SELECT invCode FROM Base_inventory WHERE (InvClass_pk = '" + this.ddlInvClass.SelectedValue + "') )" );
			}

			//未下定单
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" (IsOrder = 0 or IsOrder is null) " );
				
			//单据状态为审批完成
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" ApplyProcessCode = 106 " );

		
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

		private  void bindOrderInfo()
		{
			if(!"".Equals(this.txtOrderNo.Text ))
			{
				//绑定此定单的信息
				//1.先查看有无此输入的定单
				//2.查找此定单的信息并绑定到dgorder
				
				//3.标识为更新
				Entiy.OrderSheet orderSheet = Entiy.OrderSheet.FindByOrderNo(this.txtOrderNo.Text.Trim());
				if(orderSheet != null )
				{
					//
					string cmdStr = "select * from v_BaseApplyPurchase where orderno = '" + this.txtOrderNo.Text.Trim() + "'" ;
					DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
					this.dgOrder.DataSource = ds;
					this.dgOrder.DataBind();

					this.IsEdit.Value = this.txtOrderNo.Text.Trim() ;

				}
				else
				{
					this.lblMessage.Text = "定单编号有误！";
				}
			}
		}
	
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			
			bindGrid();
			bindOrderInfo();
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
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(this.dgApply.Items[itm.ItemIndex].Cells[0].Text));
					if(applyBody != null)
					{
						applyBody.IsOrder   = 1 ;
						applyBody.OrderDate = DateTime.Now;
						applyBody.OrderNo   = "" ;
						applyBody.Update();
					}
				}
			}
			this.lblMessage.Text = "更新成功";

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

		private void imgBtnDown_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblMessage.Text  = "";
			//把选中的项目添加到下面的DataGrid

			// 1. 若已经存在，则不允许添加。若已下定单，则不能添加。 参照  ApplySheetBody_Purchase_pk。

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string purchasepk = this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					string IsOrder    = this.dgApply.Items[itm.ItemIndex].Cells[11].Text ;

					int IsShouldAdd = 1 ; 

					foreach(DataGridItem itme in this.dgOrder.Items )
					{
						if(purchasepk.Equals(this.dgOrder.Items[itme.ItemIndex].Cells[0].Text))
						{
							IsShouldAdd  = 0  ;
						}
					}

					if("1".Equals(IsOrder))
					{
						IsShouldAdd  = 2  ;
					}

					if(IsShouldAdd == 0) 
					{
						this.lblMessage.Text = "已经存在，不能重复添加！" ;
					}
					else if(IsShouldAdd  == 2 )
					{
						this.lblMessage.Text = "已经下过定单，不能重复！" ;
					}
					else
					{
						//添加
						DataTable dt = new DataTable() ; 

						if(this.dgOrder.Items.Count >0 )
						{
							dt = Bussiness.OrderManageBLL.MakeTableFromDataGrid(this.dgOrder );
						}
						else
						{
							dt = Bussiness.OrderManageBLL.GetNormalTable();
						}

						DataRow dr = dt.NewRow(); 
						dr["ApplySheetBody_Purchase_pk"] = this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
						dr["ApplySheetHead_Pk"] = this.dgApply.Items[itm.ItemIndex].Cells[15].Text ; 

						HyperLink hl = (HyperLink)this.dgApply.Items[itm.ItemIndex].Cells[2].Controls[0];   
						dr["ApplySheetNo"] = hl.Text  ; 

						dr["DeptName"] = this.dgApply.Items[itm.ItemIndex].Cells[3].Text ; 
						dr["ApplyTypeName"] = this.dgApply.Items[itm.ItemIndex].Cells[4].Text ; 
						dr["ApplyDate"] = this.dgApply.Items[itm.ItemIndex].Cells[5].Text ; 
						dr["InventoryCode"] = this.dgApply.Items[itm.ItemIndex].Cells[6].Text ; 
						dr["invName"] = this.dgApply.Items[itm.ItemIndex].Cells[7].Text ; 
						dr["Number"] = this.dgApply.Items[itm.ItemIndex].Cells[8].Text ; 
						dr["RMBPrice"] = this.dgApply.Items[itm.ItemIndex].Cells[9].Text ; 
						dr["money"] = this.dgApply.Items[itm.ItemIndex].Cells[10].Text ; 
						
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()))
						{
//							dr["IsOrder"] = 0 ; 
						}
						else
						{
							dr["IsOrder"] = int.Parse(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) ; 
						}

						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()))
						{
							//dr["orderDate"] = "" ; 
						}
						else
						{
							dr["orderDate"] = DateTime.Parse(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()) ; 
						}

						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()))
						{
//							dr["OrderNo"] = "" ; 
						}
						else
						{
							dr["OrderNo"] = this.dgApply.Items[itm.ItemIndex].Cells[13].Text ; 
						}
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()))
						{
//							dr["IsGiveUp"] = 0 ; 
						}
						else
						{
							dr["IsGiveUp"] =int.Parse( this.dgApply.Items[itm.ItemIndex].Cells[14].Text) ; 
						}
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()))
						{
						}
						else
						{
							dr["memo"] = this.dgApply.Items[itm.ItemIndex].Cells[16].Text ; 
						}
					
						dt.Rows.Add(dr);

						this.dgOrder.DataSource = dt ;
						this.dgOrder.DataBind();

						
					}
				}
			}
		}

		private void imgBtnUp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//从定单记录datagrid中移除选中的记录

			DataTable dt = new DataTable() ; 

			if(this.dgOrder.Items.Count >0 )
			{
				dt = Bussiness.OrderManageBLL.MakeTableFromDataGrid(this.dgOrder );
			}
			else
			{
				return ; 
			}

			foreach(DataGridItem itm in this.dgOrder.Items )
			{
				CheckBox chkCode=itm.FindControl("Checkbox1") as CheckBox;
				if( chkCode.Checked )
				{
					string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 

					dt.AcceptChanges(); 
					foreach(DataRow dr in dt.Rows )
					{
						if(dr["ApplySheetBody_Purchase_pk"].ToString().Equals(PurchasePk))
						{
							dr.Delete();
							
						}
					}
				}
			}
			this.dgOrder.DataSource = dt;
			this.dgOrder.DataBind();
		}

		private void btnSaveOrder_Click(object sender, System.EventArgs e)
		{
			//判断是新增还是修改
			//1 新增已有方法
			//2 修改记录原有定单号，对原来的数据晴空，标识所有在选择grid里的数据 
			if(this.IsEdit.Value  != "0" )
			{
				#region 修改
				this.btnSaveOrder.Enabled = false; 

				this.lblMessage.Text = "";
			
				//合成号
				string OrderNo  = this.IsEdit.Value ; 
				DateTime dt = DateTime.Now;
				string perCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); 

				Entiy.OrderSheet orderSheet =   HDSZCheckFlow.Entiy.OrderSheet.FindByOrderNo(OrderNo) ; 
				
				orderSheet.OrderNo = OrderNo;
				orderSheet.OrderDate = dt ;
				orderSheet.IsKeep = 0 ;
				orderSheet.MakerCode = perCode ; 

				orderSheet.Save();

				Bussiness.OrderManageBLL.UpdatePurchase(OrderNo);

				foreach(DataGridItem itm in this.dgOrder.Items )
				{
					string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 
					//添加 PurchasePk ， 和 OrderNo 
					//Entity 实例化 
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(PurchasePk));
					if(applyBody != null && applyBody.IsOrder != 1 )
					{
						//更新Purchase 表
						applyBody.IsOrder   = 1 ; 
						applyBody.OrderDate = dt ;
						applyBody.OrderNo   = OrderNo ;
						applyBody.Update();

						this.lblMessage.Text = "生成定单成功！  " + OrderNo ;
					}
					else
					{
						this.lblMessage .Text = "已经下过定单，不能再次下定单！";
					}
				}
				#endregion 
			}
			else
			{
				#region 新增
				this.btnSaveOrder.Enabled = false; 

				this.lblMessage.Text = "";
				//往定单表中添加记录 ， 1.生成不重复的定单号  dd2009040200001 
				//2. 记录定单号，购买物品主键 。

				#region 生成定单号
				//定单前缀
				string perFix= System.Configuration.ConfigurationSettings.AppSettings["dingdan"];
				if("".Equals(perFix))
				{
					this.lblMessage.Text  = "没有找到系统前缀名。";
					return ;
				}
				//取系统当前年月
				string date =   DateTime.Today.ToString("yyyyMMdd");
				//取当前数据库最大流水号
				string OrderNo = perFix + date ; 
				string  MaxNum1=Bussiness.ApplySheetHeadBLL.GetMaxOrderNo(OrderNo);
				int MaxNum=0;
				if(!"".Equals(MaxNum1))
				{
					MaxNum=int.Parse(MaxNum1.Trim());
				}
				MaxNum += 1;
				string applyMaxNum=MaxNum.ToString();

				for(int iLength=MaxNum.ToString().Length ;iLength<5;iLength++)
				{
					applyMaxNum="0"+applyMaxNum;
				}
				#endregion 

				//合成号
				OrderNo  += applyMaxNum ; 
				DateTime dt = DateTime.Now;
				string perCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); 

				Entiy.OrderSheet orderSheet =   new HDSZCheckFlow.Entiy.OrderSheet();
				orderSheet = new HDSZCheckFlow.Entiy.OrderSheet();
				orderSheet.OrderNo = OrderNo;
				orderSheet.OrderDate = dt ;
				orderSheet.IsKeep = 0 ;
				orderSheet.MakerCode = perCode ; 
				orderSheet.Create();

				foreach(DataGridItem itm in this.dgOrder.Items )
				{
					try
					{
						//多个增删改方法。

						string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 
						//添加 PurchasePk ， 和 OrderNo 
						//Entity 实例化 
						Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(PurchasePk));
						if(applyBody != null && applyBody.IsOrder != 1 )
						{
							//更新Purchase 表
							applyBody.IsOrder   = 1 ; 
							applyBody.OrderDate = dt ;
							applyBody.OrderNo   = OrderNo ;
							applyBody.Update();

							this.lblMessage.Text = "生成定单成功！  " + OrderNo ;
						}
						else
						{
							this.lblMessage .Text = "已经下过定单，不能再次下定单！";
						}

						//无错误 ，提交
					}
					catch(Exception ex)
					{
						Common.Log.Logger.Log("UI.OrderManage.BaseInfo.btnSaveOrder_Click",ex.Message );
						this.lblMessage.Text = "生成定单错误 ！ " ;
					}
				}
				#endregion  
			}
			//重新绑定
			bindGrid();
			
		}




	}
}
