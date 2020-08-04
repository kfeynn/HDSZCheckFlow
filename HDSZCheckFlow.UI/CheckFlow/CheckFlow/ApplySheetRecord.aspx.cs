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

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ApplySheetRecord 的摘要说明。
	/// </summary>
	public class ApplySheetRecord : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgPostail;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			BindRecord();
		}

		private void BindRecord()
		{
			try
			{
				if(Request.QueryString["applyHeadPK"] !=null)
				{
					string applyHeadPk=Request.QueryString["applyHeadPK"].ToString();
					//Entiy.ApplySheetCheckRecord app
				
					//帮定各审批着审批记录
					DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecord(int.Parse(applyHeadPk));
					if(ds!=null)
					{
						this.dgPostail.DataSource=ds;
					}
					else
					{
						this.dgPostail.DataSource=null;
					}
					this.dgPostail.DataBind();
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("CheckFlow.ApplySheetRecord.BindRecord",ex.Message );
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
