namespace TradeWWW.FCK
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		wuFCK ��ժҪ˵����
	/// </summary>
	public class wuFCK : System.Web.UI.UserControl
	{
		protected FredCK.FCKeditorV2.FCKeditor content;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ġ���aspx.csҳ�� 
			//1.��ֵ 

			content.Value = Server.HtmlDecode("");    //��html�ַ������н��� 
			//2.���ݿ��� 
			//���浽���ݿ��е�ֵ = Server.HtmlEncode(content.Value);   //���ַ�������html���� 
			//3.��վ 
			//�������վ�ĸ�Ŀ¼��Ҫ����һЩ����,---��ʱ����Բ������ã�����һ�¼���֪���� 
			content.BasePath = "/FCKeditor/";
			content.ImageBrowserURL = "/FCKeditor/editor/filemanager/browser/default/browser.html?Type=Image&Connector=connectors/aspx/connector.aspx";

			content.LinkBrowserURL = "/FCKeditor/editor/filemanager/browser/default/browser.html?Connector=connectors/aspx/connector.aspx";

			//�����ˣ������Ϳ�������...
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
