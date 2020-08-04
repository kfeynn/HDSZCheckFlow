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

namespace HDSZCheckFlow.UI.BaseData.Subject
{
	/// <summary>
	/// updateBaseInfo 的摘要说明。
	/// </summary>
	public class updateBaseInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtData;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnUpdateRate;
		protected System.Web.UI.WebControls.Button btnInputCost;
	
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
			this.btnInputCost.Click += new System.EventHandler(this.btnInputCost_Click);
			this.btnUpdateRate.Click += new System.EventHandler(this.btnUpdateRate_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnInputCost_Click(object sender, System.EventArgs e)
		{
			// 更新实际发生费用
			if(!"".Equals(this.txtData.Text))
			{
				this.lblMessage.Text = "";
				DateTime dt = DateTime.Parse(this.txtData.Text);
				int iYear  = dt.Year ;
				int iMonth = dt.Month ;

				Bussiness.CostBLL.UpdateGl_NC_Cost(iYear,iMonth); 
//				Bussiness.GetCostBll costBll = new HDSZCheckFlow.Bussiness.GetCostBll(iYear,iMonth);
//				costBll.ThreadGetCostl();   



				this.lblMessage.Text = "更新完成！";
			}
			else
			{
				this.lblMessage.Text = "请选择查询年月" ;
			}
		}

		private void btnUpdateRate_Click(object sender, System.EventArgs e)
		{
			// 更新实际发生费用

			if(!"".Equals(this.txtData.Text))
			{
				this.lblMessage.Text = "";
				DateTime dt = DateTime.Parse(this.txtData.Text);
				int iYear  = dt.Year ;
				int iMonth = dt.Month ;

				Bussiness.CurrRateBLL.updateCurrRate (iYear,iMonth); 
				this.lblMessage.Text = "更新完成！";
			}
			else
			{
				this.lblMessage.Text = "请选择查询年月" ;
			}
		}

	
	}
}
