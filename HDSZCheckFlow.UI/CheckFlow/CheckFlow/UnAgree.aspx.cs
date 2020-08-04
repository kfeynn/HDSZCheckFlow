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
	/// ApplyOfCompanyState ��ժҪ˵����
	/// </summary>
	public class UnAgree : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;//����ʽ 1,����.2����
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				//		// �ڴ˴������û������Գ�ʼ��ҳ��
				//		//0. ���ͬ��
				//		//1. ���������һ���Ѿ�ͬ��� ��ɫ ������������
				//		//2. ����״̬��Ϊ����


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
				oPageViewState.SortType=2;           //����ʽ
				oPageViewState.SSort="ApplySheetHead_Pk";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort.ToString();                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UnAgree.bindGrid()",ex.Message );
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
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //���������ť
			{

				string myCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
				//�ܾ�
				this.lblMessage.Text = "" ; 
				if(IsAuditinged(int.Parse(e.Item.Cells[0].Text),myCode) == 1 )
				{
					int CheckRecordID = int.Parse(e.Item.Cells[1].Text) ;
					Entiy.ApplySheetCheckRecord checkRecord = Entiy.ApplySheetCheckRecord.Find(CheckRecordID);
					string disPlaysCode = ""; 
					if(checkRecord.DisplaysPersonCode != null && checkRecord.DisplaysPersonCode != "")
					{
						disPlaysCode = checkRecord.DisplaysPersonCode;
					}
					else
					{
						disPlaysCode = checkRecord.CheckPersonCode ;
					}
					 
					if(myCode == disPlaysCode)
					{
						disPlaysCode = "" ;
					}

					//���һ���������������,��־Ϊ ͬ��󷴻�
					//string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

					Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
					Audi.Flow_AgreeApplySheet(0,myCode,int.Parse(e.Item.Cells[0].Text),disPlaysCode,"",2 );

//					Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(0,myCode,int.Parse(e.Item.Cells[0].Text),disPlaysCode,"",2 );


					//���°�
					PageViewState oPageViewState=new PageViewState();
					oPageViewState.PCount=0;

					oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
					oPageViewState.SSort=this.FieldSort.Value ;
					oPageViewState.SortType=int.Parse(this.HerdSort.Value );

					this.HerdSort.Value =oPageViewState.SortType.ToString();
					PageViewState.SetPageViewState(this.ViewState , oPageViewState);
					bindSearchResult();
					
				}
				else
				{
					this.lblMessage.Text="�����ѱ�ͬ����Ա����";
				}
			}
		}

		private int IsAuditinged(int applyHeadPk,string userCode)
		{
			//�����Ƿ��Ѿ���ͬ��ɫ����������������!

			#region 

//			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
//			if(applyHead!=null && applyHead.CurrentCheckRole!=null)
//			{
//				Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//				if(prossType!=null &&  prossType.IsDisallow==0)  //�ȿ�����״̬�Ƿ�Ϊ����
//				{
//					//�жϵ�ǰ������ɫ���Ƿ����Լ�  ,,�����ڻ����ⶼ����
//					string UserCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
//					int i=Bussiness.UserInfoBLL.GetCountOfUserRole(applyHead.CurrentCheckRole ,UserCode,applyHead.ApplyDeptCode);
//					if(i>0)
//					{
//						return 1; //�����Լ�
//					}
//					else
//					{
//						return 0; //���ܱ�����������
//					}
//				}
//				else
//				{
//					return 0;                 //����״̬Ϊnull���� Ϊ����״̬.. ��������
//				}
//			}
//			else
//			{
//				return 2; //δ�ҵ�����,����
//			}

			#endregion 

			Entiy.ApplySheetCheckRecord checkRecord= Entiy.ApplySheetCheckRecord.FindLastChecker(applyHeadPk);
			if(checkRecord != null)
			{
				//�����˹���
				string checkerCode = "" ; 

				if(checkRecord.DisplaysPersonCode == null || checkRecord.DisplaysPersonCode =="")
				{
					checkerCode =  checkRecord.CheckPersonCode;
				}
				else
				{
					checkerCode =  checkRecord.DisplaysPersonCode ;
				}

				//usercodeҪô���������˹���  Ҫô����������
				if(userCode == checkerCode )
				{
					return 1 ;
				}
				else if(Bussiness.UserInfoBLL.displaysCheckRelation(checkerCode,userCode))
				{
					return 1 ;
				}
				else
				{
					return 0 ; 
				}
			}
			else
			{
				return 0 ; 
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
			AdvancedSearchGo("v_DisAgreeApplyInfo","ApplySheetHead_Pk",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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

			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			// �������� ��Ϊ�Լ��ĵ��� 


			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));   //�������Լ��ĵ�

			string MyInfo= "(checkperson  IN (SELECT UserName FROM xpGrid_User WHERE (displaysPerson = '" + myCode + "') AND (IsDisplays = 1) OR (UserName = '" + myCode + "' )))" ;
			filter.Append(" " + MyInfo + " " );





		
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
		}

		//���Ʒ�ҳ
		private void linkToPage_Click(object sender, System.EventArgs e)
		{
			try
			{
				string pageIndex="1";
				try
				{
					if( Request.Form["__EVENTARGUMENT"]!=null && Request.Form["__EVENTARGUMENT"].ToString()!="")
					{
						pageIndex=Request.Form["__EVENTARGUMENT"].ToString() ;
					}

					int aTest = Convert.ToInt32(pageIndex); 


				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("UI.CheckFlow.ApplyOfCompanyState.linkToPage_Click_1",ex.Message );
				}
				PageViewState oPageViewState=new PageViewState();
				oPageViewState.PCount=0;
				oPageViewState.PIndex=Convert.ToInt32(pageIndex);

				this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			
				oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
				oPageViewState.SortType=int.Parse(this.HerdSort.Value) ;//1;

				this.HerdSort.Value =oPageViewState.SortType.ToString();
				PageViewState.SetPageViewState(this.ViewState , oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UI.CheckFlow.ApplyOfCompanyState.linkToPage_Click",ex.Message );
			}
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			bindGrid();
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

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			System.Web.UI.WebControls.Button  img=(System.Web.UI.WebControls.Button )e.Item.FindControl("btnLook");   
			if(!Object.Equals(img,null))   
			{   
				img.Attributes.Add("onclick","javascript:return window.confirm('��ȷ�ϲ�����')");   
			}   
		}

	}
}
