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
	/// MyBudgetAccount ��ժҪ˵����
	/// </summary>
	public class MyBudgetAccount : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//  ��ѯ�����ڲ��ŵ�Ԥ����� 
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
