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
using HDSZCheckFlow.DataAccess;


using System.IO; 




using System.Text; 
using System.Globalization; 
 



namespace HDSZCheckFlow.UI.CostAssay.BudgetCost
{
	/// <summary>
	/// RealCostAndExplanation 的摘要说明。
	/// </summary>
	public class RealCostAndExplanation : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Repeater repDataBind;
		protected System.Web.UI.WebControls.Button btnOutPrint;
		protected string _fileName;
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

		//查询
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//获取预实算信息（按部门区分）
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="请输入查询年份";
				return ;
			}
			DateTime dt=DateTime.Parse(this.txtDate.Text);
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
			

			//
			DataSet ds=GetRealCostAndExplanation(dt.Year,dt.Month,this.ddlDept.SelectedValue);

			//this.DataGrid1.DataSource=ds;
			//this.DataGrid1.DataBind();
			this.repDataBind.DataSource=ds;
			this.repDataBind.DataBind();
			//this.Button1.Visible=true;
		}
		
		//导出
		private void Button1_Click(object sender, System.EventArgs e)
		{
			//Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			//excelHelper.FileName="fileName";
			//excelHelper.Export(this.DataGrid1 );
			//RenderExcel(repDataBind);

//			try
//			{
//				HttpContext.Current.Response.AppendHeader("Content-Disposition","attachment;filename=Excel.xls");
//				HttpContext.Current.Response.Charset   ="UTF-8";
//				HttpContext.Current.Response.ContentEncoding   =System.Text.Encoding.Default;
//				HttpContext.Current.Response.ContentType   ="application/ms-excel";//image/JPEG;text/HTML;image/GIF;vnd.ms-excel/msword   excel instance
//				repDataBind.Page.EnableViewState   =false;
//				System.IO.StringWriter tw = new System.IO.StringWriter();
//				System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter (tw);
//				repDataBind.RenderControl(hw); 
//				HttpContext.Current.Response.Write(tw.ToString()); 
//				HttpContext.Current.Response.End(); 
//			}
//			catch
//			{
//				throw new Exception("数据无法导出!");
//			}



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




		/// <summary>
		/// 根据年份月份部门 查询部门实算摘要查询
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetRealCostAndExplanation(int iYear,int iMonth,string tableCode)
		{
			string cmdStr="Proc_Sub_RealCostAndExplanation";//存储过程
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
            Params.Add(DataAccess.Parameter.GetDBParameter("@iYear", iYear));
            Params.Add(DataAccess.Parameter.GetDBParameter("@iMonth", iMonth));
            Params.Add(DataAccess.Parameter.GetDBParameter("@tableCode", tableCode));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}



		//输出Excel文件(暂无用2009-12-24)
		private void RenderExcel(Control c) 
		{ 
			// 确保有一个合法的输出文件名 
			if (_fileName == null || _fileName == string.Empty || !(_fileName.ToLower().EndsWith(".xls"))) 
				_fileName = GetRandomFileName(); 
 
			HttpResponse response = HttpContext.Current.Response; 
             
			response.Charset = "GB2312"; 
			response.ContentEncoding = Encoding.GetEncoding("GB2312"); 
			response.ContentType = "application/ms-excel/msword"; 
			response.AppendHeader("Content-Disposition", "attachment;filename=" +  
				HttpUtility.UrlEncode(_fileName)); 
 
			CultureInfo cult = new CultureInfo("zh-CN", true); 
			StringWriter sw = new StringWriter(cult);             
			HtmlTextWriter writer = new HtmlTextWriter(sw); 
 
			writer.WriteLine("<meta http-equiv=\"Content-Type\" content=\"text/html;charset=GB2312\">"); 
 
			Repeater rep = c as Repeater; 
             
			if (rep != null) 
			{ 
				rep.RenderControl(writer); 
			} 

			c.Dispose(); 
 
			response.Write(sw.ToString()); 
			response.End(); 
		} 


		/// <summary> 
		/// 得到一个随意的文件名 
		/// </summary> 
		/// <returns></returns> 
		private string GetRandomFileName() 
		{ 
			Random rnd = new Random((int) (DateTime.Now.Ticks)); 
			string s = rnd.Next(Int32.MaxValue).ToString(); 
			return DateTime.Now.ToShortDateString() + "_" + s + ".xls"; 
		} 

	}
}
