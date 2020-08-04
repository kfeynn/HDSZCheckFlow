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


namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssetsForCompany ��ժҪ˵����
	/// </summary>
	public class SmallFixedAssetsForCompany : System.Web.UI.Page
	{


		#region 

		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.TextBox txtStorage;
		protected System.Web.UI.WebControls.TextBox txtKeeperCode;
		protected System.Web.UI.WebControls.TextBox txtInvManageCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptName;
		protected System.Web.UI.WebControls.Button btnExportExcel;
		protected System.Web.UI.WebControls.TextBox txtInv;

		#endregion 


		private void Page_Load(object sender, System.EventArgs e)
		{
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
				/*DataTable dtType=Bussiness.SmallFixedBLL.GetNCTypeInfo();
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[1].ToString();
					ddlType.DataTextField=dtType.Columns [2].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}*/

			/*	DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();;      // 0 ��ѯ���в���
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}*/



				DataTable dtDeptBySmallFixed=Bussiness.CheckFlowInDeptBLL.GetAllDeptBySmallFixed();

				if(dtDeptBySmallFixed!=null && dtDeptBySmallFixed.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptBySmallFixed;
					ddlDeptClass.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlDeptClass.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}



		
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.UI.Asset.SmallAssets.SmallFixedAssetsFlag",ex.Message );
			}

		}


		#endregion 


		private void bindGrid()
		{
			try
			{
				// ��ѯ�����ʺ���Ϣ 

				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=50;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=3;           //����ʽ
				oPageViewState.SSort=" [NC_DeptName] asc,[invCode] asc, [dbizdate] desc ";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("SmallFixedAssetsForCompany",ex.Message );
			}
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
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		//		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try

			{
				if(e.CommandName.Equals("ReMark")) //���������ť
				{
					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						//						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						//						{
						//							this.dgApply.Items[i].BackColor= color;

						string ID = e.Item.Cells[0].Text; // this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 

						Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

						if(SmFlag != null)
						{
							SmFlag.IsFlag = 0 ;

							SmFlag.Save ();
						}

						//						}
					}
					//					color=e.Item.BackColor;
					//					e.Item.BackColor=Color.Yellow;	
				}

				bindGrid();



			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.ToString());
			}
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
			AdvancedSearchGo("v_SmallFixedAssets_ForAll","Id",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState); 
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();


			if(!"".Equals(this.txtInv.Text)) //�������
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invCode like '%" + this.txtInv.Text.Trim()  + "%' " );		
			}

			if(!"".Equals(this.txtName .Text))//�������
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invName like '%" + this.txtName.Text.Trim()  + "%' " );
			}

			//txtInvManageCode
			if(!"".Equals(this.txtInvManageCode .Text))//�������
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" InvManageCode like '%" + this.txtInvManageCode.Text.Trim()  + "%' " );
			}

			//txtStorage
			if(!"".Equals(this.txtStorage .Text))//��ŵص�
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Storage like '%" + this.txtStorage.Text.Trim()  + "%' " );
			}

			//txtKeeperCode
			if(!"".Equals(this.txtKeeperCode .Text))//�����˹���
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" KeeperCode like '%" + this.txtKeeperCode.Text.Trim()  + "%' " );
			}


			if(!"".Equals(this.ddlDeptClass.SelectedValue ))//����
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptClassCode  =  '" + this.ddlDeptClass.SelectedValue  + "' " );

			}

			//����
			if(!"".Equals(this.ddlDeptName.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptCode  =  '" + this.ddlDeptName.SelectedValue  + "' " );

			}
			

			/*if(!"".Equals(this.ddlType .SelectedValue ))//����
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invClassCode  =  '" + this.ddlType.SelectedValue  + "' " );	
			}*/



			if(!"".Equals(this.txtDateFrom.Text ))//�������ڿ�ʼ
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  >=  '" + this.txtDateFrom.Text  + "' " );
			}

			if(!"".Equals(this.txtDateTo.Text ))//�������ڽ���
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  <=  '" + this.txtDateTo .Text  + "' " );
			}

			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsRetire <> 1 " );//�Ƿ񱨷�(0 �����ϣ� 1 �ѱ���)

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

			DataSet ds = paginationBLL.CommonQuery1();
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



		private void btnQuery_Click(object sender, System.EventArgs e)
		{
	
			bindGrid();
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



		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//			//�󶨸�����ť��ʾ��Ϣ
			//			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			//			{ 
			//				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
			//				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('��ȷ��ȡ����?');"); 
			//			}

		}

		/// <summary>
		/// ѡ������������ (���ſ�������)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDeptName.Items.Clear();
			string bmbh=this.ddlDeptClass.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(dtDeptClassCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptName .DataSource=dtDeptClassCode;
				ddlDeptName.DataValueField=dtDeptClassCode.Columns["bmbh"].ToString();
				ddlDeptName.DataTextField =dtDeptClassCode.Columns["bmmc"].ToString();
				ddlDeptName.DataBind();
				ddlDeptName.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDeptName.DataSource=null;
				ddlDeptName.DataBind();
			}
		}

		private void btnExportExcel_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssets_ForAll";
			string filter = GetQuerySqlString();
			if (filter.Length>0)
			{
				cmdStr = cmdStr + " where " + filter ;
			}

			DataSet ds =  Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;

			this.dgApply.DataSource=ds;
			this.dgApply.DataBind();

			Common.Util.ExcelHelper excelHelper=new HDSZCheckFlow.Common.Util.ExcelHelper();
			excelHelper.FileName="fileName";
			excelHelper.Export(this.dgApply);

			//���°�
			bindSearchResult();
		}
	}
}
