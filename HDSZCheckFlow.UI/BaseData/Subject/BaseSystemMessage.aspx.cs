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
	/// BaseSystemMessage ��ժҪ˵����
	/// </summary>
	public class BaseSystemMessage : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			this.XPGrid1.CommandText= "select * from base_systemMessage order by EndTime desc ";
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
			//�����ʱ��ϵͳά����������
//			if(updateType==XPGrid.CUpdateType.Insert)
//			{
//				try
//				{
//					DateTime dt=DateTime.Now;
//
//					ChgSql MyChgSql=new ChgSql();
//					if (!MyChgSql.ChgResultSql(ref ResultSql,"CREATETIME",dt.ToString()))
//					{
//						XPGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
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
