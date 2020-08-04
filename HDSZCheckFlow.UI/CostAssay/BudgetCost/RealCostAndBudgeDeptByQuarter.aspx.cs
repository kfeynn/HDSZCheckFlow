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
using HDSZCheckFlow.DataAccess;//引入了数据访问层

namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// RealCostAndBudgeDeptByQuarter 的摘要说明。
	/// </summary>
	public class RealCostAndBudgeDeptByQuarter : System.Web.UI.Page
	{

		DateTime dt;

		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.LinkButton lbOneQuarter;
		protected System.Web.UI.WebControls.LinkButton lbTwoQuarter;
		protected System.Web.UI.WebControls.LinkButton lbThirdQuarter;
		protected System.Web.UI.WebControls.LinkButton lbFourQuarter;
		protected System.Web.UI.WebControls.Button btnOutPrint;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				BindDept();
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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnOutPrint.Click += new System.EventHandler(this.btnOutPrint_Click);
			this.lbOneQuarter.Click += new System.EventHandler(this.lbOneQuarter_Click);
			this.lbTwoQuarter.Click += new System.EventHandler(this.lbTwoQuarter_Click);
			this.lbThirdQuarter.Click += new System.EventHandler(this.lbThirdQuarter_Click);
			this.lbFourQuarter.Click += new System.EventHandler(this.lbFourQuarter_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		#region 查寻报表财务部门 。 Base_Runreport
		private void BindDept()
		{
			
			DataSet ds=Bussiness.CostBLL.GetBudgetDept();
			this.ddlDept.DataSource=ds.Tables[0];
			this.ddlDept.DataValueField =ds.Tables[0].Columns["tableCode"].ToString();
			this.ddlDept.DataTextField  =ds.Tables[0].Columns["tableName"].ToString();
			this.ddlDept.DataBind();
		}
		#endregion 



		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,1,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		
		//导出
		private void Button1_Click(object sender, System.EventArgs e)
		{
			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.DataGrid1 );
		}

		//打印
		private void btnOutPrint_Click(object sender, System.EventArgs e)
		{
			//获取预实算信息（按部门区分）
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="请输入查询年月";
				return ;
			}
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="请输入查询部门";
				return ;
			}

			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=3&QueryDate=" + this.txtDate.Text + "&TableCode=" + this.ddlDept.SelectedValue + " ');</script>");

		}

		
		

		//第一季
		private void lbOneQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,1,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}

		//第二季
		private void lbTwoQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,2,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}

		//第三季
		private void lbThirdQuarter_Click(object sender, System.EventArgs e)
		{
			CheckEmpty();
			


			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,3,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		//第四季
		private void lbFourQuarter_Click(object sender, System.EventArgs e)
		{
			
			
			CheckEmpty();

			DataSet ds=GetBudgetCostAndRealCostByClassDept(dt.Year,4,this.ddlDept.SelectedValue);

			this.DataGrid1.DataSource=ds;
			this.DataGrid1.DataBind();

			this.Button1.Visible=true;
		}
		

		/// <summary>
		/// 根据年份 查询某年季度的预实算信息
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostAndRealCostByClassDept(int iYear,int iMonth,string tableCode)
		{
			string cmdStr="Proc_Sub_RealCostAndBudgeDeptByQuarter";//存储过程
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
            Params.Add(DataAccess.Parameter.GetDBParameter("@iYear", iYear));
            Params.Add(DataAccess.Parameter.GetDBParameter("@Quarter", iMonth));
            Params.Add(DataAccess.Parameter.GetDBParameter("@tableCode", tableCode));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}



		//检查空值
		private void CheckEmpty()
		{
			//获取预实算信息（按部门区分）
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="请输入查询年份";
				return ;
			}
			dt=DateTime.Parse(this.txtDate.Text);
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="请输入查询部门";
				return ;
			}
			Entiy.BaseRunreport runReport=Entiy.BaseRunreport.FindBytableCode(this.ddlDept.SelectedValue);
			if(runReport == null)
			{
				this.lblMessage.Text="系统出错，请联系管理员！(Entiy.BaseRunreport runReport 未找到)";
				return ;
			}
		}
		

	}
}
