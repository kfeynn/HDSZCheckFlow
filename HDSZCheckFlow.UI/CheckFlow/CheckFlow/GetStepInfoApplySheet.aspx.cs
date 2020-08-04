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
	/// GetBackApplySheet 的摘要说明。
	/// </summary>
	public class GetStepInfoApplySheet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table tabFlowStep;

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


		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			BindStepInfo();
		}

		private void BindStepInfo()
		{
			try
			{
				if(Request.QueryString["ApplyHeadPK"]==null || Request.QueryString["ApplyHeadPK"].ToString() ==null)
				{
					return ;
				}
				string applyHeadPk=Request.QueryString["ApplyHeadPK"].ToString();

				if(!"".Equals(applyHeadPk))
				{
					int applyPk=int.Parse(applyHeadPk);
					
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyPk);
					if(applyHead != null)
					{

						string querydept=" WHERE (CheckFlowInDept.DeptCode = '" + applyHead.ApplyDeptCode + "') ORDER BY CheckFlowInDept.CheckSetp";
						DataTable dtDept = Bussiness.CheckFlowInDeptBLL.GetFlowInDeptByQuery(querydept);
						if(dtDept!=null && dtDept.Rows.Count>0 )
						{
							foreach(DataRow  row in dtDept.Rows )
							{
								TableRow  tr=new TableRow();
								TableCell td=new TableCell();
								TableCell tc=new TableCell();
								td.Text=row[0].ToString(); 
								tc.Text=row[1].ToString(); 
								tr.Cells.Add(td);
								tr.Cells.Add(tc);
								this.tabFlowStep.Rows.Add(tr);
								td =null;
								tc =null;
								tr =null;
							}

						}
						// 2. 公司  流程, 人员, 审批级别 : 根据流程ID决定
						//string query=" WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = " + applyHead.CheckFlowInCompanyHeadPk  + ") ORDER BY CheckFlowInCompany_Body.CheckStep";
						//DataTable dt =  Bussiness.CheckFlowInCompanyBLL.GetFlowCheckInfoByQuery(query);
						string deptCode = applyHead.ApplyDeptClassCode;
						DataTable dt =  Bussiness.CheckFlowInCompanyBLL.GetFlowCheckInfoByQuery(applyHead.CheckFlowInCompanyHeadPk,deptCode);
						if(dt != null && dt.Rows.Count>0 )
						{
							foreach(DataRow  row in dt.Rows )
							{
								TableRow  tr=new TableRow();
								TableCell td=new TableCell();
								TableCell tc=new TableCell();
								td.Text=row[0].ToString(); 
								tc.Text=row[1].ToString(); 
								tr.Cells.Add(td);
								tr.Cells.Add(tc);
								this.tabFlowStep.Rows.Add(tr);
								tc =null;
								td =null;
								tr =null;
							}
						}
					}
				}
				// 加返回按钮
				TableRow  ttr=new TableRow();
				TableCell ttc=new TableCell();
				TableCell ttd=new TableCell();
				ttc.Text="完成";
			
				ttd.Text="<font size='+2'><a href='#' titile='返回' onclick='javascript:history.go(-1);' >返回</a></font>"; 
				ttr.Cells.Add(ttc);
				ttr.Cells.Add(ttd);
				this.tabFlowStep.Rows.Add(ttr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("CheckFlow.GetStepInfoApplySheet",ex.Message );
			}
		}
	}
}
