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
	/// GetBackApplySheet ��ժҪ˵����
	/// </summary>
	public class GetStepInfoApplySheet : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Table tabFlowStep;

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


		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
						// 2. ��˾  ����, ��Ա, �������� : ��������ID����
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
				// �ӷ��ذ�ť
				TableRow  ttr=new TableRow();
				TableCell ttc=new TableCell();
				TableCell ttd=new TableCell();
				ttc.Text="���";
			
				ttd.Text="<font size='+2'><a href='#' titile='����' onclick='javascript:history.go(-1);' >����</a></font>"; 
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
