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

namespace xpGridTest.UI.xpGrid.HenryAdd
{
	/// <summary>
	/// MyShowImage ��ժҪ˵����
	/// </summary>
	public class MyShowImage : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Image xpGridImg;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string strImageUrl; 
			strImageUrl = Request.Url.ToString(); 
			strImageUrl = strImageUrl.Replace("MyShowImage.aspx", "Image.aspx"); 
			xpGridImg.ImageUrl = strImageUrl;

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
