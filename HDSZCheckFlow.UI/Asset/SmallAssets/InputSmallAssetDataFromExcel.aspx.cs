
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
	/// InputBaseDataFromExcel 的摘要说明。
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
			// 在此处放置用户代码以初始化页面
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
			this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		static string DelectFileName="";            //用于记录临时文件名，将来用于删除
		private void btnLook_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lblMessage.Text = "";
				//1先将客户机上的 excel文件导入到服务器
				Bussiness.upLoadFileBLL upload=new Bussiness.upLoadFileBLL();
				if(upload.IsAllowedExtension(this.File1))
				{
					string strAbsolutePath=System.Configuration.ConfigurationSettings.AppSettings["upfileForBudget"];    //上传路径
					string strNewFileName=upload.SaveFile(this.File1,Server.MapPath(strAbsolutePath));  //上传文件并返回上传后的路径
					
					//2打开位于服务器的 excel文件，显示在DataGrid控件中
					try
					{
						string openFile=Server.MapPath(strAbsolutePath)+"\\"+strNewFileName;
						DelectFileName=openFile;                                                      //完成插入数据库后,将要删除此文件(服务器中不保存文件)
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
						//捕获错误
						HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
					}
				}
				else
				{
					this.dgGrid.DataSource = null;
					this.dgGrid.DataBind();
					this.lblMessage.Text ="上传文件格式不正确";
				}
			}
			catch(Exception ex)
			{
				//捕获错误
				HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
			}
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//1入库
			//string conStr=System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];   //连接字符串，库不同
			string items=this.DropDownList1.SelectedItem.Value ;
			string lblMessage="";
			try
			{
				switch(items)
				{
					case "0":
						this.lblMessage.Text="请选择导入类型!";
						break;
					case "1":
					{
						this.lblMessage.Text="";
						DataSet ds=(DataSet)Cache["tempDS2"];
						//小额固定资产导入
						Bussiness.BudgetAccountBLL.SmallAssetHelper(ds,out lblMessage);

						if("".Equals(lblMessage))
						{
							this.lblMessage.ForeColor=Color.Blue;
							this.lblMessage.Text="导入完毕";
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
				//2删除上传的文件
				if(System.IO.File.Exists(DelectFileName))
				{
					System.IO.File.Delete(DelectFileName);
				}
				this.lblMessage.ForeColor=Color.Red;
				this.lblMessage.Text=ex.Message;
				HDSZCheckFlow.Common.Log.Logger.Log("UI.BaseData.InputBaseDataFromExcel-->",ex.Message);
			}
			//2删除上传的文件
			if(System.IO.File.Exists(DelectFileName))
			{
				System.IO.File.Delete(DelectFileName);
			}
		}
	}
}
