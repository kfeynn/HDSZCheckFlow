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

namespace HDSZCheckFlow.UI.Asset.BudgetCost
{
	/// <summary>
	/// Asset_BudgetCostDetialInfo ��ժҪ˵����
	/// ��ӪԤʵ����
	/// 2011-10-27 liyang
	/// </summary>
	public class Asset_BudgetCostDetialInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgBudetInfo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlItemName;
		protected System.Web.UI.WebControls.ImageButton imgBtnQuery;
		protected System.Web.UI.WebControls.TextBox txtDate;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!IsPostBack)
			{
				InitPageForAdd();
				bindGrid();
			}
		}
		 

		private void bindGrid()
		{
			try
			{
				//���ò�ѯ����
				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_AssetBudgetCostDetialInfo",GetQuerySqlString());

				//������
				this.dgBudetInfo.DataSource = ds;
				this.dgBudetInfo.DataBind();

				
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}

		

		#region  ��ʼ������
		
		/// <summary>
		/// ��ʼ���������ֵ
		/// </summary>
		private void InitPageForAdd()
		{
			try
			{
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				Entiy.AssetBudget[] assetBudget = Entiy.AssetBudget.FindAll();

				if(assetBudget!=null)
				{
					
					for(int i=0;i<assetBudget.Length;i++)
					{
						ddlItemName.Items.Add(assetBudget[i].ItemName+"\\"+assetBudget[i].SubjectName);
					}

					ddlItemName.Items.Insert(0,"");
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
				
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("Asset.BudgetCost.Asset_BudgetCostDetialInfo",ex.Message );
			}

		}


		#endregion 


		/// <summary>
		/// ��ȡ�������ѯ��������
		/// </summary>
		/// <returns></returns>
		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.ddlDeptClass.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("���ű��� = " +" '" + this.ddlDeptClass.SelectedItem.Value + "'" );
			}
			if(!"".Equals(this.txtDate.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append("��� = " +" '" + this.txtDate.Text+ "'" );
			}
			
			if(!"".Equals(this.ddlItemName.SelectedItem.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				string tempItemName=this.ddlItemName.SelectedItem.Text;
				string temp=tempItemName.Substring(tempItemName.LastIndexOf("\\")+1,tempItemName.Length-(tempItemName.LastIndexOf("\\")+1));

				filter.Append("��Ŀ���� = " +" '" +temp + "'" );
			}

			// HDSZCheckFlow.Entiy.BaseDept.FindByBudgetDeptCode();
		
		
			string returnValue=filter.ToString();

			if(returnValue.Trim().Length>0)
			{
				returnValue=" where "+returnValue;
			}

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
			this.imgBtnQuery.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void dgBudetInfo_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			dgBudetInfo.CurrentPageIndex=e.NewPageIndex;
			bindGrid();
		}


		/// <summary>
		/// ��ѯ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imgBtnQuery_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			bindGrid();
		}
	}
}
