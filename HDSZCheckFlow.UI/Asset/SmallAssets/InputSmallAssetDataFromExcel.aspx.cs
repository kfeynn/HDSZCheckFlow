
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
using System.Data.OleDb;

namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// InputBaseDataFromExcel ��ժҪ˵����
	/// </summary>
	public class InputSmallAssetDataFromExcel : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnLook;
		protected System.Web.UI.WebControls.DataGrid dgGrid;
		protected System.Web.UI.WebControls.DropDownList DropDownList1;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.HtmlControls.HtmlInputFile File1;

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		static string DelectFileName="";            //���ڼ�¼��ʱ�ļ�������������ɾ��
		private void btnLook_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblMessage.Text = "";
				//1�Ƚ��ͻ����ϵ� excel�ļ����뵽������
				Bussiness.upLoadFileBLL upload=new Bussiness.upLoadFileBLL();
				if(upload.IsAllowedExtension(this.File1))
				{
					string strAbsolutePath=System.Configuration.ConfigurationSettings.AppSettings["upfileForBudget"];    //�ϴ�·��
					string strNewFileName=upload.SaveFile(this.File1,Server.MapPath(strAbsolutePath));  //�ϴ��ļ��������ϴ����·��
					
					//2��λ�ڷ������� excel�ļ�����ʾ��DataGrid�ؼ���
					try
					{
						string openFile=Server.MapPath(strAbsolutePath)+"\\"+strNewFileName;
						DelectFileName=openFile;                                                      //��ɲ������ݿ��,��Ҫɾ�����ļ�(�������в������ļ�)
						this.dgGrid.DataSource=null;
						DataSet ds=new DataSet();
						string conStr=" provider= Microsoft.ACE.OLEDB.12.0;Data Source=" + openFile + ";Extended Properties=\"Excel 12.0\";Persist Security Info=False";
						OleDbConnection con=new OleDbConnection(conStr);
						OleDbDataAdapter daper=new OleDbDataAdapter("select * from [Sheet1$]",con);
						daper.Fill(ds,"tempTable");
						this.dgGrid.DataSource=ds;
						Cache["tempDS2"]=ds;
						this.dgGrid.DataBind();
					}
					catch(Exception ex )
					{
						//�������
						HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
					}
				}
				else
				{
					this.dgGrid.DataSource = null;
					this.dgGrid.DataBind();
					this.lblMessage.Text ="�ϴ��ļ���ʽ����ȷ";
				}
			}
			catch(Exception ex)
			{
				//�������
				HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//1���
			//string conStr=System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];   //�����ַ������ⲻͬ
			string items=this.DropDownList1.SelectedItem.Value ;
			string lblMessage="";
			try
			{
				switch(items)
				{
					case "0":
						this.lblMessage.Text="��ѡ��������!";
						break;
					case "1":
					{
						this.lblMessage.Text="";
						DataSet ds=(DataSet)Cache["tempDS2"];
						//С��̶��ʲ�����
						Bussiness.BudgetAccountBLL.SmallAssetHelper(ds,out lblMessage);

						if("".Equals(lblMessage))
						{
							this.lblMessage.ForeColor=Color.Blue;
							this.lblMessage.Text="�������";
						}
						else
						{
							this.lblMessage.Text=lblMessage;
						}
						break;
					}

				}
				
			}
			catch(Exception ex)
			{
				//2ɾ���ϴ����ļ�
				if(System.IO.File.Exists(DelectFileName))
				{
					System.IO.File.Delete(DelectFileName);
				}
				this.lblMessage.ForeColor=Color.Red;
				this.lblMessage.Text=ex.Message;
				HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
			}
			//2ɾ���ϴ����ļ�
			if(System.IO.File.Exists(DelectFileName))
			{
				System.IO.File.Delete(DelectFileName);
			}
		}
	}
}
