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

namespace HDSZCheckFlow.UI.CheckFlow.BaseInfo
{
	/// <summary>
	/// ApplyType ��ժҪ˵����
	/// </summary>
	public class ApplyType : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckValid;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from ApplyType";
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
			this.btnCheckValid.Click += new System.EventHandler(this.btnCheckValid_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheckValid_Click(object sender, System.EventArgs e)
		{
			//������е������ͣ��鿴�Ƿ�����������Ӧ
			Entiy.ApplyType[] applyTypes=Entiy.ApplyType.FindAll();
			foreach(Entiy.ApplyType applyType in applyTypes)
			{
				//applyType.ApplyTypeCode 
				int countOfApplyTypeInCheckFlow=Entiy.ApplyTypeInCheckFlow.SelectCountByApplyTypeCode(applyType.ApplyTypeCode);
				if(countOfApplyTypeInCheckFlow>0)
				{
					applyType.IsValid=1;
					applyType.Update();
				}
				else
				{
					applyType.IsValid=0;
					applyType.Update();
				}
			}
		}
	}
}
