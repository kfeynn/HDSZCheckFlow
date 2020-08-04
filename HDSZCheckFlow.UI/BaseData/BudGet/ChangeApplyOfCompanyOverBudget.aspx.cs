//  namespace HDSZCheckFlow.UI.BaseData.BudGet    ChangeApplyOfCompanyOverBudget
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


namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// ApplyOfCompanyState ��ժҪ˵����
	/// </summary>
	public class ChangeApplyOfCompanyOverBudget : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.DataGrid dgPostail;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblApplyNo;
		protected System.Web.UI.WebControls.Label lblApplyMoney;
		protected System.Web.UI.WebControls.TextBox tbxOverMoney;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;//����ʽ 1,����.2����

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				//				BindAuditingByType("");
				bindGrid();
			}
		}

		private void bindGrid()
		{
			try
			{
				// ��ѯ�����ʺ���Ϣ 
				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=50;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=1;           //����ʽ
				oPageViewState.SSort="applySheetHead_pk";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
		}


		#region  ��ʼ������

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
				//DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo();  //��Ŀ ?

				//����״̬
				DataTable dtProssType=Bussiness.ApplyProcessTypeBll.GetProssTypeAll();
				if(dtProssType!=null && dtProssType.Rows.Count >0 )
				{
					this.ddlApplyType.DataSource=dtProssType;
					this.ddlApplyType.DataValueField=dtProssType.Columns[0].ToString();
					this.ddlApplyType.DataTextField=dtProssType.Columns[1].ToString();
					this.ddlApplyType.DataBind();
					this.ddlApplyType.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}


		#endregion 

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
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals("look")) //���������ť
				{
					//BindApplyRecord(int.Parse(e.Item.Cells[0].Text));

					this.Panel1.Visible= false;

					

					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						{
							this.dgApply.Items[i].BackColor= color;
						}
					}
					color=e.Item.BackColor;
					e.Item.BackColor=Color.Yellow;
				}
				else if(e.CommandName.Equals("OverBudget"))  //���ÿ���Ԥ�����ύ
				{
					int applyHeadPk = int.Parse(e.Item.Cells[0].Text); 

					//�Ƿ��ύ״̬
					if(IsNewAddType(applyHeadPk))
					{
						BindSetPanel(int.Parse(e.Item.Cells[0].Text));
					}
				}

				else if (e.CommandName.Equals("CanclOverBudget")) // ȡ��Ԥ�����ύ 
				{

					int applyHeadPk = int.Parse(e.Item.Cells[0].Text); 

					//���ύ״̬
					if(IsNewAddType(applyHeadPk))
					{
						Bussiness.ApplySheetHeadBLL.CancelSetIsOverBudget(applyHeadPk,0); // ����, ����Pk, ����״̬(1Ϊ����)

						//���°�
					
						PageViewState oPageViewState=new PageViewState();
						oPageViewState.PCount=0;
						oPageViewState.PIndex=Convert.ToInt32(this.pagesIndex.Value);
						this.pagesIndex.Value =oPageViewState.PIndex.ToString();
						oPageViewState.SSort=this.FieldSort.Value ; 
						oPageViewState.SortType=int.Parse(this.HerdSort.Value ); 
						this.HerdSort.Value =oPageViewState.SortType.ToString();
						PageViewState.SetPageViewState(this.ViewState , oPageViewState);
						bindSearchResult();
					}

				}

			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("���ÿ���Ԥ�����ύ",ex.ToString());
			}
		}



		/// <summary>
		/// ////////////////////////////////////////////
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		private void BindSetPanel (int ApplyHeadKey)
		{
			this.Panel1.Visible = true; 

			//���������ʽ�ж�����
			this.btnEnter.Attributes.Add ("onclick","return checklogo();");



			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				this.lblApplyNo.Text = ApplyHead.ApplySheetNo ;
			}

			Entiy.ApplySheetHeadBudget ApplyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHeadKey);

			if(ApplyBudget != null)
			{
				this.lblApplyMoney.Text = ApplyBudget.SheetMoney.ToString() ; 
			}

			//Ĭ��Ԥ����ո�Ҳ�� ���ݽ��

			this.tbxOverMoney.Text = ApplyBudget.SheetMoney.ToString() ; 

			







		}

		private bool IsNewAddType(int ApplyHeadKey)
		{
			bool IsTrue = false;
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				Entiy.ApplyProcessType Process = Entiy.ApplyProcessType.Find(ApplyHead.ApplyProcessCode );
				if(Process != null )
				{
					if(Process.IsSubmit == 0)
					{
						IsTrue = true;
					}
				}
			}
			return IsTrue; 
		}

		#region  ��ҳ��ѯ
		string SQuery="";  //��ѯ����
		private void bindSearchResult()
		{
			//��ѯ���ֶ�, * Ϊ����
			string sFields="*";
			//��ȡ��ѯ����      
			SQuery=GetQuerySqlString();
			//�����ѯ״̬
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//��������:1.��ѯ�����ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_ApplySheetOfCompany","applySheetHead_Pk",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			//divPagesTop.InnerHtml=PageViewState.GetUrl(this.ViewState);
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
				filter.Append(" ApplyTypeCode = " +" '" + this.ddlType.SelectedValue + "'" );
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
				filter.Append(" ApplyDate <= " +" '" +  this.txtDateTo.Text+ "'" );
			}
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" + this.ddlDeptClass.SelectedValue+ "'" );
			}
			if(!"".Equals(this.ddlDept .SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptCode = " +" '" + this.ddlDept.SelectedValue + "'" );
			}
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyProcessCode= " +" '" + this.ddlApplyType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			//
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsSubmit = 0 " );



		
			string returnValue=filter.ToString();
			return returnValue;
			#endregion  
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
			this.dgPostail.DataSource=null;        //��¼���ÿ�
			this.dgPostail.DataBind();
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



		private void BindAuditingByType(string sqlWhere )
		{
			//type
			//1. �Ѿ���ɵ�����
			//2. δ��ɵ�����
			//3. ���ܾ�������

			//�ﶨ������Ϣ
			DataSet ds=Bussiness.ApplySheetHeadBLL.GetAuditingByType(sqlWhere);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				this.dgApply .DataSource=ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply .DataSource=null;
				this.dgApply.DataBind();
			}
		}


		private void BindApplyRecord(int applyHeadPk)
		{
			//�ﶨ��������������¼
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecord(applyHeadPk);
			if(ds!=null)
			{
				this.dgPostail.DataSource=ds;
			}
			else
			{
				this.dgPostail.DataSource=null;
			}
			this.dgPostail.DataBind();
		}


		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();

			//			string sqlWhere = GetQuerySqlString();
			//			BindAuditingByType(sqlWhere);
			//
			//			this.dgPostail.DataSource=null;
			//			this.dgPostail.DataBind();

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

		private void btnEnter_Click(object sender, System.EventArgs e)
		{
			this.lblMessage.Text = "";
			try
			{
				decimal overMoney = decimal.Parse(this.tbxOverMoney.Text);

				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.SelectApplySheetHeadPk(this.lblApplyNo.Text );


				if(ApplyHead!=null)
				{				
					Entiy.ApplySheetHeadBudget ApplyBudget = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK (ApplyHead.ApplySheetHeadPk) ; 

					if(ApplyBudget!=null)
					{

						if(overMoney > ApplyBudget.SheetMoney )
						{
							this.lblMessage.Text = "Ԥ������ܴ��ڵ��ݽ�";
						}
						else
						{

							//�Ƿ��ύ״̬
							if(IsNewAddType(ApplyHead.ApplySheetHeadPk))
							{
								Bussiness.ApplySheetHeadBLL.SetIsOverBudget(ApplyHead.ApplySheetHeadPk,1,overMoney); // ����, ����Pk, ����״̬(1Ϊ����)
								this.lblMessage.Text = "���óɹ���";
							}
						}
					}
				}

				//���°�

				PageViewState oPageViewState=new PageViewState();
				oPageViewState.PCount=0;
				oPageViewState.PIndex=Convert.ToInt32(this.pagesIndex.Value);
				this.pagesIndex.Value =oPageViewState.PIndex.ToString();
				oPageViewState.SSort=this.FieldSort.Value ; 
				oPageViewState.SortType=int.Parse(this.HerdSort.Value ); 
				this.HerdSort.Value =oPageViewState.SortType.ToString();
				PageViewState.SetPageViewState(this.ViewState , oPageViewState);
				bindSearchResult();

			}
			catch(Exception ex)
			{
				this.lblMessage.Text = "���� "+ ex.Message ; 
				Common.Log.Logger.Log("",ex.Message);
			}
		}

	}
}
