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
	/// MyAuditingForFinallyCheck 的摘要说明。
	/// </summary>
	public class MyAuditingForFinallyCheck : System.Web.UI.Page
	{		
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDateFromD;
		protected System.Web.UI.WebControls.TextBox txtDateToD;

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//绑定属于登陆ID的所有待审批单,union 别人转移权限的待审批单
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				string filter = "" ;
				if(Request.Cookies["SearchConditionAsset"]!=null )
				{
					filter = GetQuerySqlByCookie();
				}
				else
				{
					filter = GetQuerySqlString();
				}
				
				BindMyAuditing(int.Parse(User.Identity.Name),filter);
		
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
				//DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo();  //科目 ?

				//单据状态
				DataTable dtProssType=Bussiness.ApplyProcessTypeBll.GetProssType();
				if(dtProssType!=null && dtProssType.Rows.Count >0 )
				{
					this.ddlApplyType.DataSource=dtProssType;
					this.ddlApplyType.DataValueField=dtProssType.Columns[0].ToString();
					this.ddlApplyType.DataTextField=dtProssType.Columns[1].ToString();
					this.ddlApplyType.DataBind();
					this.ddlApplyType.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}


		#endregion 


		//根据登陆用户ID号，查询其待审批单据
		private void BindMyAuditing(int UserID,string filter)
		{
			//1.自己的待审批单以及别人转移权限的待审批单.

			//进程表 提交状态为1 ，驳回为 0 ，公司内结束为 0 的表单

			//单据表中分部门内(查看申请科组)，部门外, 审批角色

			//通过角色与人员对照表，查找属于自己的审批单

			string myCode=Bussiness.UserInfoBLL.GetUserName(UserID);
			DataSet ds=Bussiness.AssetCheckFlowBLL.GetMyAuditingForFinallyCheck(myCode,filter);
			if(ds!=null && ds.Tables[0].Rows.Count >0)
			{
				this.lblMessage.Text="";
				this.DataGrid1.DataSource=ds;
				this.DataGrid1.DataBind();
			}
			else
			{
				this.DataGrid1.DataSource=null;
				this.DataGrid1.DataBind();
				this.lblMessage.ForeColor=Color.Red;
				this.lblMessage.Text="目前没有属于您的审批";
			}

		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Apply")) //点击审批按钮
			{

				//跳转方向
				Response.Redirect("../../Asset/PriceCheck/AuditingFinallyCheckForOneApply.aspx?FinallyCheckId=" + e.Item.Cells[0].Text + "&disCode=" + e.Item.Cells[6].Text + "");
				
			
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			string filter = GetQuerySqlString();
			BindMyAuditing(int.Parse(User.Identity.Name),filter);
		
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//记录Session 或者Cookie 用户选择的查询条件
			HttpCookie cookie = new HttpCookie("SearchConditionAsset");   

			#region 
//			if(!"".Equals(this.ddlType.SelectedValue))
//			{
//				cookie.Values.Add("ApplyTypeCode",this.ddlType.SelectedValue);   
//			}
//			else
//			{
//				cookie.Values.Add("ApplyTypeCode","");   
//			}
//			if(!"".Equals(this.txtDateFrom.Text))
//			{
//				cookie.Values.Add("ApplyDateFrom",this.txtDateFrom.Text);   
//			}
//			else
//			{
//				cookie.Values.Add("ApplyDateFrom","");   
//			}
//			if(!"".Equals(this.txtDateTo.Text))
//			{
//				cookie.Values.Add("ApplyDateTo",this.txtDateTo.Text);   
//			}
//			else
//			{
//				cookie.Values.Add("ApplyDateTo","");   
//			}
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				cookie.Values.Add("ApplyDeptClassCode",this.ddlDeptClass.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("ApplyDeptClassCode","");   
			}
			if(!"".Equals(this.ddlDept .SelectedValue ))
			{
				cookie.Values.Add("ApplyDeptCode",this.ddlDept.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("ApplyDeptCode","");   
			}
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				cookie.Values.Add("applyProcessCode",this.ddlApplyType.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("applyProcessCode","");   
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				cookie.Values.Add("applySheetNo",this.txtApplyNo.Text);   
			}
			else
			{
				cookie.Values.Add("applySheetNo","");   
			}
			#endregion 

			Response.AppendCookie(cookie);
			

			this.DataGrid1.CurrentPageIndex = 0 ;
			string filter = GetQuerySqlString();
			BindMyAuditing(int.Parse(User.Identity.Name),filter);
		
		}

		private string GetQuerySqlString()
		{

			#region  整理查询条件

			StringBuilder filter=new StringBuilder();
//			if(!"".Equals(this.ddlType.SelectedValue))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" ApplyTypeCode = " +" '" + this.ddlType.SelectedValue + "'" );
//			}
//			if(!"".Equals(this.txtDateFrom.Text))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append("	ApplyDate >= " +" '" + this.txtDateFrom.Text+ "'" );
//			}
//			if(!"".Equals(this.txtDateTo.Text))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" ApplyDate <= " +" '" +  this.txtDateTo.Text+ "'" );
//			}
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
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyProcessCode= " +" '" + this.ddlApplyType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			// 基础条件 ： 提交状态为 1 。.暂时固定为 ApplyProcessCode 非 101  ， 201 。以后做活

	
		

			string returnValue=filter.ToString();


			if(returnValue.Length > 0 )
			{
				returnValue = " where " + returnValue;
			}

			return returnValue;
			#endregion  
		}

		private string GetQuerySqlByCookie()
		{
			if(Request.Cookies["SearchConditionAsset"]!=null )
			{
				#region  整理查询条件,（从Cookie中，并给对应附值）

				StringBuilder filter=new StringBuilder();
//				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["ApplyTypeCode"].ToString()))
//				{
//					if(filter.Length>0)
//					{
//						filter.Append(" and ");
//					}
//					filter.Append(" ApplyTypeCode = " +" '" + Request.Cookies["SearchConditionAsset"]["ApplyTypeCode"].ToString()  + "'" );
//					this.ddlType.SelectedValue = Request.Cookies["SearchConditionAsset"]["ApplyTypeCode"].ToString() ; 
//				}
//				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["ApplyDateFrom"].ToString()))
//				{
//					if(filter.Length>0)
//					{
//						filter.Append(" and ");
//					}
//					filter.Append("	ApplyDate >= " +" '" + Request.Cookies["SearchConditionAsset"]["ApplyDateFrom"].ToString() + "'" );
//					this.txtDateFrom.Text = Request.Cookies["SearchConditionAsset"]["ApplyDateFrom"].ToString() ;
//				}
//				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["ApplyDateTo"].ToString()))
//				{
//					if(filter.Length>0)
//					{
//						filter.Append(" and ");
//					}
//					filter.Append(" ApplyDate <= " +" '" + Request.Cookies["SearchConditionAsset"]["ApplyDateTo"].ToString() + "'" );
//					this.txtDateTo.Text = Request.Cookies["SearchConditionAsset"]["ApplyDateTo"].ToString() ;
//				}
				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["ApplyDeptClassCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyDeptClassCode = " +" '" + Request.Cookies["SearchConditionAsset"]["ApplyDeptClassCode"].ToString() + "'" );
					this.ddlDeptClass.SelectedValue =  Request.Cookies["SearchConditionAsset"]["ApplyDeptClassCode"].ToString() ; 
				}
				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["ApplyDeptCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyDeptCode = " +" '" + Request.Cookies["SearchConditionAsset"]["ApplyDeptCode"].ToString() + "'" );
					this.ddlDept.SelectedValue = Request.Cookies["SearchConditionAsset"]["ApplyDeptCode"].ToString();
				}
				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["applyProcessCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" applyProcessCode= " +" '" + Request.Cookies["SearchConditionAsset"]["applyProcessCode"].ToString() + "'" );
					this.ddlApplyType.SelectedValue = Request.Cookies["SearchConditionAsset"]["applyProcessCode"].ToString() ;
				}
				if(!"".Equals(Request.Cookies["SearchConditionAsset"]["applySheetNo"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" applySheetNo like  " +" '%" + Request.Cookies["SearchConditionAsset"]["applySheetNo"].ToString() + "%'" );
					this.txtApplyNo.Text = Request.Cookies["SearchConditionAsset"]["applySheetNo"].ToString();
				}

				// 基础条件 ： 提交状态为 1 。.暂时固定为 ApplyProcessCode 非 101  ， 201 。以后做活

				string returnValue=filter.ToString();
				if(returnValue.Length > 0 )
				{
					returnValue = " where " + returnValue;
				}
				return returnValue;
				#endregion  
			}
			else
			{
				return "";
			}
		}
	
	}
}
