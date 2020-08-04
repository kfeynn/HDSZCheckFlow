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
	/// Asset_BudgetConsistencyCheckMoney ��ժҪ˵����
	/// </summary>
	public class Asset_BudgetConsistencyCheckMoney : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.Button btnConsistency;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.RadioButton radion_exception;
		protected System.Web.UI.WebControls.RadioButton radio_normal;
		protected System.Web.UI.WebControls.RadioButton radio_all;
		protected System.Web.UI.WebControls.TextBox txtDate_Year;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			btnConsistency.Attributes.Add( "onclick ", "return  IsExistSelect();"); 
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				bindGrid();
			}
		}

		
		#region  ��ʼ������

		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
				//string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);



				//this.ddlDept.Items.Clear();
				//string deptClass=this.ddlDeptClass.SelectedValue;
				/*DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClass(0);
				if(dtDept!=null && dtDept.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDept;
					ddlDeptClass.DataValueField=dtDept.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDept.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}	*/	

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
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.UI.Asset.BudgetCost.Asset_BudgetConsistencyCheckMoney",ex.Message );
			}

		}


		#endregion 

		private void bindGrid()
		{
			try
			{
				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=5;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=1;           //����ʽ
				oPageViewState.SSort="rum";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.Asset.BudgetCost.Asset_BudgetCostUseDetialInfo.bindGrid",ex.Message );
			}
		}


		#region  ��ҳ��ѯ
		string SQuery="";  //��ѯ����
		private void bindSearchResult()
		{
			//��ѯ���ֶ�, * Ϊ����
			string sFields="*";
			SQuery=GetQuerySqlString();
			//�����ѯ״̬
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//��������:1.��ѯ�����ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_Asset_Budget_Compare_CheckMoney","rum",out oPageViewState.PCount,15,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		

		private void AdvancedSearchGo(string sTabel,string sPK,out int pageCount,int pageSize,int pageIndex,string sSort,int sSortType, string sFilter,string sFields)
		{	
			pageCount=0;
			Bussiness.PaginationBLL paginationBLL=new Bussiness.PaginationBLL();
			paginationBLL.Tables=sTabel;
			paginationBLL.Sort=sSort;
			paginationBLL.SortType=sSortType;
			paginationBLL.PK=sPK;
			paginationBLL.Fields=sFields;
			paginationBLL.Filter=sFilter;
			paginationBLL.PageSize=pageSize;
			paginationBLL.PageNumber=pageIndex;	

			DataSet ds = paginationBLL.CommonQuery();
			pageCount=paginationBLL.PageSumSize;

			
			if(ds!=null && ds.Tables.Count>0 && ds.Tables[0].Rows.Count>0)
			{
				this.dgApply .DataSource=ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply.DataSource=null;
				this.dgApply.DataBind();
			}
		}

		//���Ʒ�ҳ
		private void linkToPage_Click(object sender, System.EventArgs e)
		{
			string pageIndex="";
			if( Request.Form["__EVENTARGUMENT"]!=null && Request.Form["__EVENTARGUMENT"].ToString()!="")
			{
				pageIndex=Request.Form["__EVENTARGUMENT"].ToString() ;
			}
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;
			oPageViewState.PIndex=Convert.ToInt32(pageIndex);


			this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
			oPageViewState.SortType=int.Parse(this.HerdSort.Value );//1;

			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);

			bindSearchResult();
		}

		#endregion


		#region ��ѯ����
		private string GetQuerySqlString()
		{
			StringBuilder filter=new StringBuilder();

			//���
			if(!"".Equals(this.txtDate_Year.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Iyear = " +" '" + this.txtDate_Year.Text+ "'" );
			}

			//����
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				

				Entiy.BaseDept[] baseDept=Entiy.BaseDept.FindByBudgetSuperiorDeptPk(this.ddlDeptClass.SelectedValue);
				
				string deptStr="";
				foreach(Entiy.BaseDept dept in baseDept)
				{	
					deptStr+=dept.BudgetDeptCode+",";
				}
				//���ݲ��ű�����Ӧ�Ŀ�
				if(deptStr.Length>0)
				{
					int len=deptStr.LastIndexOf(",");
					deptStr=deptStr.Substring(0,len);
				}

					 filter.Append(" DeptCode in(" + deptStr+ ")");
			}

			//������
			if(this.radio_normal.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" asset_budget_checkMoney=asset_applySheet_body_checkMoney" );
			}

			//�쳣��(����web.config���õĲ�����Ƚ�) 
			if(this.radion_exception.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				//��ȡweb.config���õ�ֵ
				string checkMoney = System.Configuration.ConfigurationSettings.AppSettings["CheckMoney"];
				filter.Append(" asset_budget_checkMoney<>asset_applySheet_body_checkMoney AND ABS(asset_budget_checkMoney-asset_applySheet_body_checkMoney)>"+checkMoney );
			}

			string returnValue=filter.ToString();
			return returnValue;

		}

		#endregion
		

		private void dgApply_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			//��ͷ����
			this.FieldSort.Value =e.SortExpression ;
			if(int.Parse(this.HerdSort.Value ) ==0 || int.Parse(this.HerdSort.Value )==2)
			{
				this.HerdSort.Value ="1";
			}
			else if(int.Parse(this.HerdSort.Value )==1)
			{
				this.HerdSort.Value ="2";
			}
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;

			oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
			oPageViewState.SSort=this.FieldSort.Value ;
			oPageViewState.SortType=int.Parse(this.HerdSort.Value );

			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);
			bindSearchResult();
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnConsistency.Click += new System.EventHandler(this.btnConsistency_Click);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// һ��ά��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnConsistency_Click(object sender, System.EventArgs e)
		{
			foreach (DataGridItem dgItem in dgApply.Items)
			{
				Control con= dgItem.Cells[0].FindControl("chkSelect");

				if(con!=null)
				{
					if(((CheckBox)con).Checked)
					{
						string Iyear=dgItem.Cells[2].Text;
						string DeptCode=dgItem.Cells[3].Text;
						//string DeptName=dgItem.Cells[4].Text;
						string ItemName=dgItem.Cells[5].Text;
						string SubjectName=dgItem.Cells[6].Text;

						Bussiness.AssetBudgetBll.ConsistencyCheckMoney(Iyear,DeptCode,ItemName,SubjectName);

						
					}
				}
			}

			bindGrid();
		}



	

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{
				string checkMoney1= e.Item.Cells[7].Text;//Ԥ������¼��ʹ�ý��
				string checkMoney2= e.Item.Cells[8].Text;//�ύ�����뵥ͳ�Ƶ�ʹ�ý��

				if(!checkMoney1.Equals(checkMoney2))//����ȸ�����ɫ����ʾ
				{
					e.Item.Cells[7].ForeColor=Color.Red;
				}
				
			}
		}

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();
		}





	}
}

