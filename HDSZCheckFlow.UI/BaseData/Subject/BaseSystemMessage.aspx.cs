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
	/// BaseSystemMessage 的摘要说明。
	/// </summary>
	public class BaseSystemMessage : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			this.XPGrid1.CommandText= "select * from base_systemMessage order by EndTime desc ";
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
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			//插入的时候系统维护创建日期
//			if(updateType==XPGrid.CUpdateType.Insert)
//			{
//				try
//				{
//					DateTime dt=DateTime.Now;
//
//					ChgSql MyChgSql=new ChgSql();
//					if (!MyChgSql.ChgResultSql(ref ResultSql,"CREATETIME",dt.ToString()))
//					{
//						XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
//						continueUpdate=false;
//					}
//				}
//				catch(Exception ex)
//				{
//					ex.ToString();
//				}
//			}
		}
	}
}
