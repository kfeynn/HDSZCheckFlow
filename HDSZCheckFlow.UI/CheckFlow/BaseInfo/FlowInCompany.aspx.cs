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
	/// FlowInCompany 的摘要说明。
	/// </summary>
	public class FlowInCompany : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPFlowHead;
		protected System.Web.UI.WebControls.Button btnCheckValid;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected XPGrid.XpGrid XPFlowBody;
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			this.XPFlowHead.CommandText="select * from CheckFlowInCompany_head ";
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
			this.XPFlowHead.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.XPFlowHead_SelectedIndexChanged);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPFlowHead_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//选中一个流程名
			if(XPFlowHead.GetEditState() == XPGrid.CEditState.NotInEdit)
			{
				string[] keys = this.XPFlowHead.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					return;
				}

				this.XPFlowBody.Visible=true;
				this.XPFlowBody.CommandText="select  *  from CheckFlowInCompany_Body where CheckFlowInCompany_Head_pk=" + keys[0] + " order by CheckStep asc";
				this.XPFlowBody.DataBind();
			}
			else
			{
				this.XPFlowBody.Visible=false;
			}
		}

		private void btnCheckValid_Click(object sender, System.EventArgs e)
		{
			this.XPFlowBody.Visible=false;
			//检测所有流程,更新其有效性字段. 不有效,返回原因. table 
			DataTable dt=new DataTable();
			Bussiness.CheckFlowInCompanyBLL.CheckFlowHeadValid(out dt);
			this.DataGrid1.DataSource=dt.DefaultView;
			this.DataGrid1.DataBind();
			
		}
	}
}
