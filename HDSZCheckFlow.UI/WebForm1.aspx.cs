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
	/// WebForm1 ��ժҪ˵����
	/// </summary>
	public class WebForm1 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.WebControls.Button Button4;
		protected XPGrid.XpGrid XPGrid1;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			this.XPGrid1.CommandText="SELECT *  FROM Log  order by [Date] desc";
			this.XPGrid1.DataBind();

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
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
		{
			try
			{
				int i=0;
				int j=1;
				int a=j/i;
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.UI.WebForm1-->",ex.Message); //��¼����
				
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				DataSet ds= Bussiness.Class1.getDataSet();
				this.DataGrid1.DataSource=ds;
				this.DataGrid1.DataBind();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			Entiy.Log log=Entiy.Log.Find(1);
			if(log!=null )
			{
				Response.Write(log.Date.ToString());
			}
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			
			//this.XPGrid1.CommandText="SELECT  *  FROM xpGrid_User";
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
//			int iUserID=1; 
//			System.Web.Security.FormsAuthentication.SetAuthCookie(iUserID.ToString(), false); 
//			System.Web.Security.FormsAuthentication.RedirectFromLoginPage(iUserID.ToString(), false); 
		}
	}
}
