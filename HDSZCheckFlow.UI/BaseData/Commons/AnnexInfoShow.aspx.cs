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

namespace HDSZCheckFlow.UI.BaseData.Commons
{
	/// <summary>
	/// AnnexInfoShow 的摘要说明。
	/// </summary>
	public class AnnexInfoShow : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblFileTitle;
		public string savePath;
		private ArrayList arr=new ArrayList();
		private static int num = 0;

		private void Page_Load(object sender, System.EventArgs e)
		{
			string ApplyHeadPk=Request.QueryString["applyHeadPk"];

			string fileName=Request.QueryString["FileName"];


			if(ApplyHeadPk!=null && ApplyHeadPk.Trim().Length>0)
			{
				arr.Clear();
				GetAnnexInfo(int.Parse(ApplyHeadPk)); 
			}
			else
			{			
				arr.Add("");
			}
			

			if(!Page.IsPostBack)
			{	
				num=0;
				if(fileName==null)
				{
					ViewState["savePath"] = arr[num].ToString();
					GetFileTitle(arr[num].ToString());
				}

				//2011-11-18 liyang
				if(arr.Count>0)
				{
					for(int i=0;i<arr.Count;i++)
					{
						string tmp=arr[i].ToString();
						string tempFileName=tmp.Substring(tmp.LastIndexOf(@"\")+1,tmp.Length-(tmp.LastIndexOf(@"\")+1));
						if(tempFileName==fileName)
						{
							ViewState["savePath"] = arr[i].ToString();
							GetFileTitle(arr[i].ToString());
						}
					}
				}
			}
		}

		
		/// <summary>
		/// 获取单号里的附件，并放入ArrayList
		/// </summary>
		/// <param name="applyHeadPk"></param>
		private void GetAnnexInfo(int applyHeadPk)
		{
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByApplyHeadPk(applyHeadPk);
			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{

				foreach(Entiy.ApplySheetAnnex applyAnnex in applyAnnexs)
				{				
					string path=Bussiness.upLoadFileBLL.getAnnexPath(applyAnnex.ApplySheetHeadPk);
					arr.Add(path + applyAnnex.FileName);
				}
			}
			else
			{
				arr.Add("");
			}

		}



		/// <summary>
		/// 上一页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void imgbtnPrevious_Click(object sender, ImageClickEventArgs e)
		{
			num--;
			if (num < 0)
			{
				num = 0;
			}

			ViewState["savePath"] = arr[num].ToString();
			GetFileTitle(arr[num].ToString());
		}

		/// <summary>
		/// 下一页
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void imgbtnNext_Click(object sender, ImageClickEventArgs e)
		{
			num++;
			if (num >= arr.Count)
			{
				num = arr.Count - 1;
			}

			ViewState["savePath"] = arr[num].ToString();
			GetFileTitle(arr[num].ToString());

		}

		/// <summary>
		/// 截取附件名称
		/// </summary>
		/// <param name="filePath"></param>
		private void GetFileTitle(string filePath)
		{
			int n = filePath.LastIndexOf("\\") + 1;
			int m = filePath.Length;
			lblFileTitle.Text =filePath.Substring(n, m - n);
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
