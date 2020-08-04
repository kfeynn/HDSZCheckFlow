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
using System.Text;


namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// UnDisPass ��ժҪ˵����
	/// </summary>
	public class UnDisPass : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.DataGrid dgApply;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{				
				InitPageForAdd();

				string query=GetQuerySqlString();

				BindMyAudutedApply(query);
			}
		}

		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyType (deptClassCode);
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[0].ToString();
					ddlType.DataTextField=dtType.Columns [1].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 ��ѯ���в���
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}
//				string budgetDept = Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
//				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(budgetDept); //һ����Ŀ

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}

		private void BindMyAudutedApply(string query)
		{
			try
			{
				query= " where " + query  + " order by applydate  desc";
				DataSet ds=Bussiness.ApplyAuditingBLL.GetMyAuditedApply(query);
				this.dgApply.DataSource=ds;
				this.dgApply.DataBind();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("CheckFlow.UnDisPass.BindMyAudutedApply",ex.Message );
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			string query=GetQuerySqlString();
			BindMyAudutedApply(query);
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();
			if(!"".Equals(this.ddlType.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyTypeCode = " +" '" + this.ddlType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtDateFrom.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyDate >= " +" '" + this.txtDateFrom.Text+ "'" );
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyDate <= " +" '" +  this.txtDateTo.Text+ "'" );
			}
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyDeptClassCode = " +" '" + this.ddlDeptClass.SelectedValue+ "'" );
			}
			if(!"".Equals(this.ddlDept .SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplyDeptCode = " +" '" + this.ddlDept.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("	ApplySheetNo = " +" '" + this.txtApplyNo.Text + "'" );
			}	


			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));   //�������Լ��ĵ�

			string MyInfo= "(CheckPersonCode IN (SELECT UserName FROM xpGrid_User WHERE (displaysPerson = '" + myCode + "') AND (IsDisplays = 1) OR (UserName = '" + myCode + "' )))" ;
			filter.Append(" " + MyInfo + " " );

			string returnValue=filter.ToString();
			return returnValue;
			#endregion  
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
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if("cmd".Equals(e.CommandName))
			{
				try
				{
					// 1. ������¼��,�ҵ�������,�˴β���ʱ��״̬ 

					// 2. ���´˼�¼�� ��ʱ״̬ 

					// 3. ������ζ�ŷ����ص��� ͨ�������� .

					string applyHeadPK = e.Item.Cells[0].Text;        //��ͷ����
					string applyType = e.Item.Cells[2].Text;        //��ͷ����
					//string role        = e.Item.Cells[1].Text;        //������ɫ
					//string InCompany   = e.Item.Cells[2].Text;        //���� 0 ��˾ 1
					//string step        = e.Item.Cells[3].Text;        //������

					if(applyType == "�۸�þ�")
					{

						Entiy.AssetFinallyPriceCheck assetApply = Entiy.AssetFinallyPriceCheck.Find (int.Parse(applyHeadPK));
						if(assetApply != null)
						{
							assetApply.ApplyProcessCode=Common.Const.CompanyPross;
							
							assetApply.Update();
						}

					
					}
					else
					{

						Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(applyHeadPK));
						if(applyHead != null)
						{
							//						applyHead.CurrentCheckRole = role ;
							//						applyHead.IsCheckInCompany = int.Parse(InCompany);
							//						applyHead.CheckSetp= int.Parse(step);
							if(applyHead.IsCheckInCompany  == 0 ) //������
							{
								applyHead.ApplyProcessCode=Common.Const.DeptPross;
							}
							else if(applyHead.IsCheckInCompany  == 1 )
							{
								applyHead.ApplyProcessCode=Common.Const.CompanyPross;
							}
							applyHead.Update();
						}
					}




					string query=GetQuerySqlString();
					BindMyAudutedApply(query);
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("�����ش���",ex.Message );
				}
			}
		}

		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlDeptClass.SelectedValue;
			DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClass(deptClass);
			if(dtDept!=null && dtDept.Rows.Count>0)
			{
				this.ddlDept.DataSource=dtDept;
				ddlDept.DataValueField=dtDept.Columns[0].ToString();
				ddlDept.DataTextField =dtDept.Columns[1].ToString();
				ddlDept.DataBind();
				ddlDept.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDept.DataSource=null;
				ddlDept.DataBind();
			}

		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//�󶨸�����ť��ʾ��Ϣ
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('ȷ�Ϸ�����');"); 
			}
		}


	}
}
