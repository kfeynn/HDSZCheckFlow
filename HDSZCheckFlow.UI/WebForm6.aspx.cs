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
using System.Web.Security;

namespace HDSZCheckFlow.UI
{
	/// <summary>
	/// WebForm6 ��ժҪ˵����
	/// </summary>
	public class WebForm6 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			System.Web.Security.FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1,"666",DateTime.Now,DateTime.Now.AddMonths(1),true,"userRoles","/") ; //���������֤Ʊ����
			string HashTicket = FormsAuthentication.Encrypt (Ticket) ; //�������л���֤ƱΪ�ַ���
			HttpCookie UserCookie = new HttpCookie("aa", HashTicket) ; 

			UserCookie.Expires = DateTime.Now.AddMonths (1);

		//	HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket) ; 
			//����Cookie
			Context.Response.Cookies.Add (UserCookie) ; //���Cookie

			int i = 2;



			if(1==0 || ++i == 1 )
			{
				Response.Write("asdf" + i );
			}
			else
			{
				Response.Write(i);
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(304);

            if (applyHead != null)
            {
                if (applyHead.IsExpense > 0)
                {
                    int b = 0;
                }
                int a = 0;
            }




        }
	}
}
