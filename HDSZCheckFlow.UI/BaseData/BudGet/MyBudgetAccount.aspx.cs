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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// MyBudgetAccount 的摘要说明。
	/// </summary>
	public class MyBudgetAccount : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//  查询我所在部门的预算情况 
			string userCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
			string cmdStr=@"SELECT budget_account.*
FROM budget_account WHERE (deptCode IN
(SELECT budget_deptcode
FROM base_dept
WHERE superior_dept_pk =
(SELECT Base_Dept.superior_Dept_pk
FROM Base_Person INNER JOIN
Base_Dept ON 
Base_Person.DeptCode = Base_Dept.DeptCode " +
				" WHERE (Base_Person.personCode = '" + userCode + "')))) order by iyear desc,imonth desc,deptCode desc";

			this.XPGrid1.CommandText= cmdStr ;
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
