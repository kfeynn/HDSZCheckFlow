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
	/// WebForm2 ��ժҪ˵����
	/// </summary>
	public class WebForm2 : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button Button2;
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.Button Button3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hd_Msn_Name_And_Mail;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;

		

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			//this.Button3.Attributes.Add("onclick","checkall(Form1)");
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Button1_Click(object sender, System.EventArgs e)
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

		protected void check(object sender,EventArgs e)
		{
//			foreach(DataGridItem   dgi   in   this.DataGrid1.Items)   
//			{   
//				for(int   i=0;i<dgi.Cells[0].Controls.Count;i++)   
//				{   
//					if(dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")   
//					{   
//						((CheckBox)dgi.Cells[0].Controls[i]).Checked =true;//�ж�CheckBox�Ƿ�ѡ��   
//					}   
//				}   
//			}
			

			foreach(DataGridItem itm in DataGrid1.Items)
			{
				CheckBox chkCode=itm.FindControl("Check5") as CheckBox;
				chkCode.Checked=true;
				
			}
		
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			try
			{
				string selectedstring="";
				foreach(DataGridItem   dgi   in   this.DataGrid1.Items)   
				{   
					for(int   i=0;i<dgi.Cells[0].Controls.Count;i++)   
					{   
						if(dgi.Cells[0].Controls[i].GetType().ToString()=="System.Web.UI.WebControls.CheckBox")   
						{   
							if(((CheckBox)dgi.Cells[0].Controls[i]).Checked==true)//�ж�CheckBox�Ƿ�ѡ��   
							{   
								//selectedstring   +=   DataGrid1.DataKeys[dgi.ItemIndex].ToString()   +   ",";   
								selectedstring  += this.DataGrid1.Items[dgi.ItemIndex].Cells[1].Text + "," ;
							}   
						}   
					}   
				}
				this.TextBox1.Text=selectedstring;
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			this.TextBox1.Text=this.hd_Msn_Name_And_Mail.Value;
		}



	}
}
