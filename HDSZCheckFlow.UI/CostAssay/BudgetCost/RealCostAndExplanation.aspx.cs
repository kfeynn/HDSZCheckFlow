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
	/// RealCostAndExplanation ��ժҪ˵����
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
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				BindDept();
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.btnOutPrint.Click += new System.EventHandler(this.btnOutPrint_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region ��Ѱ��������� �� Base_Runreport
		private void BindDept()
		{
			
			DataSet ds=Bussiness.CostBLL.GetBudgetDept();
			this.ddlDept.DataSource=ds.Tables[0];
			this.ddlDept.DataValueField =ds.Tables[0].Columns["tableCode"].ToString();
			this.ddlDept.DataTextField  =ds.Tables[0].Columns["tableName"].ToString();
			this.ddlDept.DataBind();
		}
		#endregion 

		//��ѯ
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ���";
				return ;
			}
			DateTime dt=DateTime.Parse(this.txtDate.Text);
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			Entiy.BaseRunreport runReport=Entiy.BaseRunreport.FindBytableCode(this.ddlDept.SelectedValue);
			if(runReport == null)
			{
				this.lblMessage.Text="ϵͳ��������ϵ����Ա��(Entiy.BaseRunreport runReport δ�ҵ�)";
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
		
		//����
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
//				throw new Exception("�����޷�����!");
//			}



		}
	
		//��ӡ
		private void btnOutPrint_Click(object sender, System.EventArgs e)
		{
			//��ȡԤʵ����Ϣ�����������֣�
			this.lblMessage.Text="";
			if("".Equals(this.txtDate.Text))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}
			if("".Equals(this.ddlDept.SelectedValue ))
			{
				this.lblMessage.Text="�������ѯ����";
				return ;
			}

			Response.Write("<script language='javascript'>window.open('BudgetCostPrintPage.aspx?ComType=3&QueryDate=" + this.txtDate.Text + "&TableCode=" + this.ddlDept.SelectedValue + " ');</script>");
		}




		/// <summary>
		/// ��������·ݲ��� ��ѯ����ʵ��ժҪ��ѯ
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetRealCostAndExplanation(int iYear,int iMonth,string tableCode)
		{
			string cmdStr="Proc_Sub_RealCostAndExplanation";//�洢����
			DBAccess dbAccess=new SQLAccess();

			DBParameterCollection Params=new DBParameterCollection();
            Params.Add(DataAccess.Parameter.GetDBParameter("@iYear", iYear));
            Params.Add(DataAccess.Parameter.GetDBParameter("@iMonth", iMonth));
            Params.Add(DataAccess.Parameter.GetDBParameter("@tableCode", tableCode));
	
			return dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
		}



		//���Excel�ļ�(������2009-12-24)
		private void RenderExcel(Control c) 
		{ 
			// ȷ����һ���Ϸ�������ļ��� 
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
		/// �õ�һ��������ļ��� 
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
