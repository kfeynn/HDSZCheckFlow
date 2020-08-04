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
	/// CheckPersonInRole ��ժҪ˵����
	/// </summary>
	public class CheckPersonInRole : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from CheckPersonInRole ";
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
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			if(updateType!=XPGrid.CUpdateType.Delete)
			{

				//��鹤�������±����Ƿ����
				string personCode="";
				for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
				{
					XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
					object ob = XPGrid1.GetInputControlValue(F); 
					if (F.ColName == "PERSONCODE") 
					{ 
						personCode = System.Convert.ToString(ob); 
					} 
				}

				Entiy.BasePerson person= Entiy.BasePerson.Find(personCode);
				if(person==null)
				{
					XPGrid1.ShowMessage("�˹��������±����޼�¼,��ȷ�ϣ�",System.Drawing.Color.Red );
					continueUpdate=false;
				}
			}
		}
	}
}
