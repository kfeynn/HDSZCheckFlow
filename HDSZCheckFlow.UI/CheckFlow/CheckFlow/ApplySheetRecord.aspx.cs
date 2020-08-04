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
	/// ApplySheetRecord ��ժҪ˵����
	/// </summary>
	public class ApplySheetRecord : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgPostail;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
				
					//�ﶨ��������������¼
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
