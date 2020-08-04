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

namespace HDSZCheckFlow.UI
{
	/// <summary>
	/// WebForm4 的摘要说明。
	/// </summary>
	public class WebForm4 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
//			try
//			{
//				
//				string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
//				if( !"".Equals(personCode))
//				{
//					if(!"Test".Equals(personCode) && !"Admin".Equals(personCode))
//					{
//						this.XPGrid1.CommandText="select * from ApplySheetHead WHERE (ApplyDeptClassCode = (SELECT superior_Dept_pk FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person WHERE personCode = '" + personCode + "'))) and (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
//						this.XPGrid1.DataBind();
//					}
//					else
//					{
//						this.XPGrid1.CommandText="select * from ApplySheetHead where  (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
//						this.XPGrid1.DataBind();
//					}
//				}
//
//			}
//			catch(Exception ex)
//			{
//				Response.Write(ex.ToString());
//				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
//			}

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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//

			int applySheetPk = 8788   ;

			HDSZCheckFlow.Bussiness.MailBLL1 mail = new HDSZCheckFlow.Bussiness.MailBLL1(applySheetPk);

			mail.ThreadSendMail();
		}
	}
}
