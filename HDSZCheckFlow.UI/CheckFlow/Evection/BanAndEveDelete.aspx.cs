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

namespace HDSZCheckFlow.UI.CheckFlow.Evection
{
	/// <summary>
	/// BanAndEveDelete 的摘要说明。
	/// </summary>
	public class BanAndEveDelete : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//这里改为读配置文件，获取招待申请类型编码(2011-09-09 liyang) 
			string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"]; //出差
			string banquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"]; //宴请

			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
			if( !"".Equals(personCode))
			{
				//	查询属于本人的未提交的申请,或者提交没审批的申请

				string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
					" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
					" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
					" WHERE personCode = '" + personCode + "'))) AND " +
					"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL) AND (ApplyProcessType.IsSubmit = 0) and applytypecode  in ('"+evectionCode+"','"+banquetCode+"') " +
					" ORDER BY ApplySheetHead.ApplyDate DESC";
				this.XPGrid1.CommandText=cmdStr;
					
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
