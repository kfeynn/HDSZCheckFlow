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
	/// BanAndEveDelete ��ժҪ˵����
	/// </summary>
	public class BanAndEveDelete : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//�����Ϊ�������ļ�����ȡ�д��������ͱ���(2011-09-09 liyang) 
			string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"]; //����
			string banquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"]; //����

			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
			if( !"".Equals(personCode))
			{
				//	��ѯ���ڱ��˵�δ�ύ������,�����ύû����������

				string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
					" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
					" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
					" WHERE personCode = '" + personCode + "'))) AND " +
					"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL) AND (ApplyProcessType.IsSubmit = 0) and applytypecode  in ('"+evectionCode+"','"+banquetCode+"') " +
					" ORDER BY ApplySheetHead.ApplyDate DESC";
				this.XPGrid1.CommandText=cmdStr;
					
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
