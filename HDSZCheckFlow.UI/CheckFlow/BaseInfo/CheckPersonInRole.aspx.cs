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
	/// CheckPersonInRole 的摘要说明。
	/// </summary>
	public class CheckPersonInRole : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from CheckPersonInRole ";
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
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			if(updateType!=XPGrid.CUpdateType.Delete)
			{

				//检查工号在人事表中是否存在
				string personCode="";
				for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
				{
					XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
					object ob = XPGrid1.GetInputControlValue(F); 
					if (F.ColName == "PERSONCODE") 
					{ 
						personCode = System.Convert.ToString(ob); 
					} 
				}

				Entiy.BasePerson person= Entiy.BasePerson.Find(personCode);
				if(person==null)
				{
					XPGrid1.ShowMessage("此工号在人事表里无记录,请确认！",System.Drawing.Color.Red );
					continueUpdate=false;
				}
			}
		}
	}
}
