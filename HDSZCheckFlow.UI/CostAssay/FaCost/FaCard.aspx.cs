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

namespace HDSZCheckFlow.UI.CostAssay.FaCost
{
	/// <summary>
	/// FaCard 的摘要说明。
	/// </summary>
	public class FaCard : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.TextBox txtStDate;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnOut;
		protected System.Web.UI.WebControls.DataGrid dgInvStore;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblMessage.Text = "" ; 
				if("".Equals(this.txtStDate.Text.Trim()))
				{
					this.lblMessage.Text = "年月不能为空!";
					this.lblMessage.ForeColor= Color.Red;
					return ;
				}

				DataSet ds=  Bussiness.CostBLL.RunFaCardbyDate(DateTime.Parse(this.txtStDate.Text).Year ,DateTime.Parse(this.txtStDate.Text).Month) ; 

				if(ds!=null )
				{
					this.dgInvStore.DataSource = ds;
					this.dgInvStore.DataBind();
				}
				else
				{
					this.dgInvStore.DataSource = null;
					this.dgInvStore.DataBind();
				}
			}
			catch
			{
				this.dgInvStore.DataSource = null;
				this.dgInvStore.DataBind();
				this.lblMessage.Text = "系统出错~!请正确输入年月，或联系MIS" ;
			}

		}

		private void btnOut_Click(object sender, System.EventArgs e)
		{
			//NCReport.BLL.Files.DataGridToExcel(this.dgInvStore); 

			Common.Util.ExcelHelper help = new HDSZCheckFlow.Common.Util.ExcelHelper();
			help.GoToExcel("excel.xls",this. dgInvStore);
		}

	
	}
}
