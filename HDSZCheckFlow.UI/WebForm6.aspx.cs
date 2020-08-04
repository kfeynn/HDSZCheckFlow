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
	/// WebForm6 的摘要说明。
	/// </summary>
	public class WebForm6 : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			System.Web.Security.FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(1,"666",DateTime.Now,DateTime.Now.AddMonths(1),true,"userRoles","/") ; //建立身份验证票对象
			string HashTicket = FormsAuthentication.Encrypt (Ticket) ; //加密序列化验证票为字符串
			HttpCookie UserCookie = new HttpCookie("aa", HashTicket) ; 

			UserCookie.Expires = DateTime.Now.AddMonths (1);

		//	HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket) ; 
			//生成Cookie
			Context.Response.Cookies.Add (UserCookie) ; //输出Cookie

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
