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

namespace HDSZCheckFlow.UI.CheckFlow.BaseInfo
{
	/// <summary>
	/// ApplyType 的摘要说明。
	/// </summary>
	public class ApplyType : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Button btnCheckValid;
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from ApplyType";
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
			this.btnCheckValid.Click += new System.EventHandler(this.btnCheckValid_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCheckValid_Click(object sender, System.EventArgs e)
		{
			//检测所有单据类型，查看是否与流程名对应
			Entiy.ApplyType[] applyTypes=Entiy.ApplyType.FindAll();
			foreach(Entiy.ApplyType applyType in applyTypes)
			{
				//applyType.ApplyTypeCode 
				int countOfApplyTypeInCheckFlow=Entiy.ApplyTypeInCheckFlow.SelectCountByApplyTypeCode(applyType.ApplyTypeCode);
				if(countOfApplyTypeInCheckFlow>0)
				{
					applyType.IsValid=1;
					applyType.Update();
				}
				else
				{
					applyType.IsValid=0;
					applyType.Update();
				}
			}
		}
	}
}
