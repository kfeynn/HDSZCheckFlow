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

namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// ApplySheetAnnexForFinallyCheck ��ժҪ˵����
	/// </summary>
	public class ApplySheetAnnexForFinallyCheck : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblUploadMsg;
		protected System.Web.UI.WebControls.Button btnUpLoad;
		protected System.Web.UI.WebControls.Table tbAnnex;
		//protected System.Web.UI.HtmlControls.HtmlInputFile File1;
		protected System.Web.UI.HtmlControls.HtmlInputFile file1;
		protected System.Web.UI.WebControls.LinkButton LinkButton2;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			string FinallyCheckId = GetQuery("FinallyCheckId");
			if(!Page.IsPostBack)
			{
				if(!"".Equals(FinallyCheckId))
				{
					BindAnnexInfo(int.Parse(FinallyCheckId));
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
			this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
			this.LinkButton2.Click += new System.EventHandler(this.LinkButton2_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		#region  �ϴ�����
		private void btnUpLoad_Click(object sender, System.EventArgs e)
		{
			try
			{
				//
				if(Request.QueryString["FinallyCheckId"]==null || Request.QueryString["FinallyCheckId"].ToString() ==null)
				{
					return ;
				}
				string FinallyCheckId=Request.QueryString["FinallyCheckId"].ToString();
				if(!"".Equals(FinallyCheckId))
				{
					Bussiness.upLoadFileBLL upload=new Bussiness.upLoadFileBLL();
					if(upload.IsAllowedExtension(this.file1))  //�ϴ����ͺϷ�(txt,doc,xls,pdf,jpg,bmp)
					{
						if(upload.IsAllowedLength(this.file1))
						{
							//1.׼���ϴ�·��
							string Name = "" ;
							string fileName = upload.getuploadFileNameForFinallyCheck(FinallyCheckId,this.file1.PostedFile.FileName,out Name);
							//2.�ϴ��ļ�,���ļ�������ɾ���ļ������ϴ�
							upload.SaveFileKeepName(this.file1,fileName);
							//3 .�ϴ����¼�����ݿ�, ����pk,����·��
							HDSZCheckFlow.Entiy.ApplySheetAnnex  applySheetAnnex = Entiy.ApplySheetAnnex.FindByApplyHeadPkAndFileNameForFinallyCheck(int.Parse(FinallyCheckId),Name);
							if(applySheetAnnex == null)
							{
								applySheetAnnex=new Entiy.ApplySheetAnnex();
							}
							applySheetAnnex.FinallyCheckPk  = int.Parse(FinallyCheckId) ;
							applySheetAnnex.FileName        = Name ;
							applySheetAnnex.Save();			
	
							BindAnnexInfo(int.Parse(FinallyCheckId));
						}
						else
						{
							this.lblUploadMsg.Text="�ϴ����ļ����ܳ���5M!";
							this.lblUploadMsg.ForeColor=Color.Red;
						}
					}
					else
					{
						this.lblUploadMsg.Text="�ϴ��ļ���ʽ����ȷ!";
						this.lblUploadMsg.ForeColor=Color.Red;
					}	
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log ("ApplySheetEdit.btnUpLoad_Click",ex.Message );
			}
		}
		#endregion  

		#region  �鿴����

		private void BindAnnexInfo(int FinallyCheckId)
		{
			// .���ݵ���ͷ,�����ݿ����ҵ���Ӧ����
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByFinallyCheckId(FinallyCheckId);
			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{
				
				//. ���ɹ��� , 1��һ����¼
				foreach(Entiy.ApplySheetAnnex applyAnnex in applyAnnexs)
				{
					TableRow  tr=new TableRow();
					TableCell td=new TableCell();
					TableCell tc=new TableCell();
					
					string path=Bussiness.upLoadFileBLL.getAnnexPathForFinallyCheck(applyAnnex.FinallyCheckPk);
					if(!"".Equals(path))
					{
						string tdURL  = path + applyAnnex.FileName;
						string xsText = "<a href='http:" + tdURL + "'   target='_blank' >" + applyAnnex.FileName + "</a>";
						td.Text= xsText ;
						tc.Text="<a href='#' onclick=\"if(confirm(\'��ȷ��Ҫɾ����?\')){__doPostBack(\'LinkButton2\',\'"+ applyAnnex.ApplySheetAnnexPk  +"\')}\"> ɾ �� </a>";
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
				//û���ҵ� ,table ��ӡ�� ,δ�ҵ���ʾ��Ϣ.....
				TableRow  tr=new TableRow();
				TableCell td=new TableCell();
				td.Text="<font color='red'>û�и�����Ϣ</font>"; 
				tr.Cells.Add(td);
				this.tbAnnex .Rows.Add(tr);
				td =null;
				tr =null;
			}
		}

		#endregion

		#region ɾ���ļ�
		private void LinkButton2_Click(object sender, System.EventArgs e)
		{
			//ɾ��ѡ�����ļ�
			//1 ,���ݿ���ɾ���ļ���¼
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
					int  FinallyCheckId= applyAnnex.FinallyCheckPk;

					//2.ɾ���ļ������Ӧ���ļ�
					Scripting.FileSystemObject  fso=new  Scripting.FileSystemObjectClass();  

					string path= Bussiness.upLoadFileBLL.getAnnexPathForFinallyCheck(applyAnnex.FinallyCheckPk);
					string strAbsolutePath= path + applyAnnex.FileName;
	
					if(fso.FileExists(strAbsolutePath))
					{
						fso.DeleteFile(strAbsolutePath,false);   //ɾ������
					}
					applyAnnex.Delete();
					BindAnnexInfo(FinallyCheckId);

				}
			}
		}
		#endregion 

		private void LinkButton1_Click(object sender, System.EventArgs e)
		{
			//returnurl,,����
			string returnURL=GetQuery("returnurl");
			if(!"".Equals(returnURL))
			{
				Response.Redirect(returnURL);
			}
		}



	}
}
