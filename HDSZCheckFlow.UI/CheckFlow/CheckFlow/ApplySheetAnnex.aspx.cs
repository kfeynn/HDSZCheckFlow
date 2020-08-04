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
	/// ApplySheetAnnex 的摘要说明。
	/// </summary>
	public class ApplySheetAnnex : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUploadMsg;
		protected System.Web.UI.WebControls.Button btnUpLoad;
		protected System.Web.UI.WebControls.Table tbAnnex;
		protected System.Web.UI.WebControls.LinkButton LinkButton1;
		//protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.HtmlControls.HtmlInputFile file1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			string applyHeadPk = GetQuery("ApplyHeadPk");
			if(!Page.IsPostBack)
			{
				if(!"".Equals(applyHeadPk))
				{
					BindAnnexInfo(int.Parse(applyHeadPk));
				}
			}
			
		}

		private string GetQuery(string colString)
		{
			if(Request.QueryString[colString] != null)
			{
				return Request.QueryString[colString].ToString();
			}
			else
			{
				return "";
			}

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
			this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region  上传附件
		private void btnUpLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
				//查看是否选中
				if(Request.QueryString["ApplyHeadPk"]==null || Request.QueryString["ApplyHeadPk"].ToString() ==null)
				{
					return ;
				}
				string applyHeadPk=Request.QueryString["ApplyHeadPk"].ToString();
				if(!"".Equals(applyHeadPk))
				{
					Bussiness.upLoadFileBLL upload=new Bussiness.upLoadFileBLL();

					if(upload.IsAllowString(this.file1 ))
					{

						if(upload.IsAllowedExtension(this.file1))  //上传类型合法(txt,doc,xls,pdf,jpg,bmp)
						{
							if(upload.IsAllowedLength(this.file1))
							{
								//1.准备上传路径
								string Name = "" ;
								string fileName = upload.getuploadFileName(applyHeadPk,this.file1.PostedFile.FileName,out Name);
								//2.上传文件,若文件存在则删除文件重新上传
								upload.SaveFileKeepName(this.file1,fileName);
								//3 .上传后记录到数据库, 单据pk,附件路径
								HDSZCheckFlow.Entiy.ApplySheetAnnex  applySheetAnnex = Entiy.ApplySheetAnnex.FindByApplyHeadPkAndFileName(int.Parse(applyHeadPk),Name);
								if(applySheetAnnex == null)
								{
									applySheetAnnex=new Entiy.ApplySheetAnnex();
								}
								applySheetAnnex.ApplySheetHeadPk  = int.Parse(applyHeadPk) ;
								applySheetAnnex.FileName          = Name ;
								applySheetAnnex.Save();
							}
							else
							{
								this.lblUploadMsg.Text="上传的文件不能超过5M!";
								this.lblUploadMsg.ForeColor=Color.Red;
							}
						}
						else
						{
							this.lblUploadMsg.Text="上传文件格式不正确!";
							this.lblUploadMsg.ForeColor=Color.Red;
						}	
					}
					else
					{
						this.lblUploadMsg.Text="上传文件中包含特殊字符!";
						this.lblUploadMsg.ForeColor=Color.Red;
					}
					BindAnnexInfo(int.Parse(applyHeadPk));

				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log ("ApplySheetEdit.btnUpLoad_Click",ex.Message );
			}
		}
		#endregion  

		#region  查看附件

		private void BindAnnexInfo(int applyHeadPk)
		{
			// .根据单据头,在数据库里找到相应链接
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByApplyHeadPk(applyHeadPk);
			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{
				
				
				//. 生成规则 , 1行一条记录
				foreach(Entiy.ApplySheetAnnex applyAnnex in applyAnnexs)
				{
					TableRow  tr=new TableRow();
					TableCell td=new TableCell();
					TableCell tc=new TableCell();
					
					string path=Bussiness.upLoadFileBLL.getAnnexPath(applyAnnex.ApplySheetHeadPk);
					if(!"".Equals(path))
					{
						string tdURL  = path + applyAnnex.FileName;
						string xsText = "<a href='http:" + tdURL + "'   target='_blank' >" + applyAnnex.FileName + "</a>";
						td.Text= xsText ;
						tc.Text="<a href='#' onclick=\"if(confirm(\'您确定要删除吗?\')){__doPostBack(\'LinkButton2\',\'"+ applyAnnex.ApplySheetAnnexPk  +"\')}\"> 删 除 </a>";
					}
					else
					{
						td.Text=""; 
					}
					tr.Cells.Add(td);
					tr.Cells.Add(tc);
					this.tbAnnex .Rows.Add(tr);
					td =null;
					tc =null;
					tr =null;
				}
			}
			else
			{
				//没有找到 ,table 打印出 ,未找到提示信息.....
				TableRow  tr=new TableRow();
				TableCell td=new TableCell();
				td.Text="<font color='red'>没有附件信息</font>"; 
				tr.Cells.Add(td);
				this.tbAnnex .Rows.Add(tr);
				td =null;
				tr =null;
			}
		}

		#endregion

		#region 删除文件
		private void LinkButton2_Click(object sender, System.EventArgs e)
		{
			//删除选定的文件
			//1 ,数据库里删除文件记录
			if(Request["__EVENTARGUMENT"] !=null)
			{
				string applyAnnexPk=Request["__EVENTARGUMENT"];
				if("".Equals(applyAnnexPk))
				{
					return;
				}
				
				Entiy.ApplySheetAnnex applyAnnex=Entiy.ApplySheetAnnex.Find(int.Parse(applyAnnexPk));
				if(applyAnnex!=null)
				{
					int  applyHeadPk= applyAnnex.ApplySheetHeadPk;

					//2.删除文件夹里对应的文件
					Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  

					string path= Bussiness.upLoadFileBLL.getAnnexPath(applyAnnex.ApplySheetHeadPk);
					string strAbsolutePath= path + applyAnnex.FileName;
	
					if(fso.FileExists(strAbsolutePath))
					{
						fso.DeleteFile(strAbsolutePath,false);   //删除附件
					}
					applyAnnex.Delete();
					BindAnnexInfo(applyHeadPk);

				}
			}
		}
		#endregion 

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			//returnurl,,返回
			string returnURL=GetQuery("returnurl");
			if(!"".Equals(returnURL))
			{
				Response.Redirect(returnURL);
			}
		}




	}
}
