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
using HDSZCheckFlow.DataAccess;

namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssetsChange ��ժҪ˵����
	/// </summary>
	public class SmallFixedAssetsChange : System.Web.UI.Page
	{
		#region 

		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtName;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnDel;
		protected System.Web.UI.WebControls.Button btnExport;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label lblInvName;
		protected System.Web.UI.WebControls.TextBox txtPeriod;
		protected System.Web.UI.WebControls.TextBox txtRetireNum;
		protected System.Web.UI.WebControls.TextBox txtReMark;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtPrice;
		protected System.Web.UI.WebControls.TextBox txtCurrTypeCode;
		protected System.Web.UI.WebControls.TextBox txtNoutnum;
		protected System.Web.UI.WebControls.Label lblID;
		protected System.Web.UI.WebControls.TextBox txtInv;

		#endregion 
		protected System.Web.UI.WebControls.Label lblBApplyDeptClassCode;
		protected System.Web.UI.WebControls.TextBox txtDatetime;
		protected System.Web.UI.WebControls.DropDownList ddlClassDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptentCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClassCode;
		protected System.Web.UI.WebControls.DropDownList Dropdownlist1;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.TextBox txtManageCode;
		
		DBAccess dbAccess=new SQLAccess();		

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetNoStore(); 
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
				DataTable dtType=Bussiness.SmallFixedBLL.GetNCTypeInfo();
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType.DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[1].ToString();
					ddlType.DataTextField=dtType.Columns [2].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}

//				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();      // 0 ��ѯ���в���
//				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
//				{
//					this.ddlDeptClass.DataSource=dtDeptClass;
//					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
//					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlDeptClass.DataBind();
//					ddlDeptClass.Items.Insert(0,"");
//
////
////					//ת�Ʋ���
////					this.ddlAApplyDeptClassCode.DataSource=dtDeptClass;
////					this.ddlAApplyDeptClassCode.DataValueField=dtDeptClass.Columns[0].ToString();
////					this.ddlAApplyDeptClassCode.DataTextField =dtDeptClass.Columns["DeptCode_DeptName"].ToString();
////					this.ddlAApplyDeptClassCode.DataBind();
////					this.ddlAApplyDeptClassCode.Items.Insert(0,"");
//				}

				DataTable dtDeptBySmallFixed=Bussiness.CheckFlowInDeptBLL.GetAllDeptBySmallFixed();

				if(dtDeptBySmallFixed!=null && dtDeptBySmallFixed.Rows.Count>0)
				{

					this.ddlDeptClassCode.DataSource=dtDeptBySmallFixed;
					ddlDeptClassCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlDeptClassCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlDeptClassCode.DataBind();
					ddlDeptClassCode.Items.Insert(0,"");

				
					// ��ͷ����
					this.ddlClassDeptCode.DataSource = dtDeptBySmallFixed;
					ddlClassDeptCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlClassDeptCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlClassDeptCode.DataBind();
					ddlClassDeptCode.Items.Insert(0,"");
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
				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                       //���ز���, ��¼����
				oPageViewState.PSize=50;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=3;           //����ʽ
				oPageViewState.SSort=" [dbizdate] desc ";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_SmallFixedAssetsChange",ex.Message ); 
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
			this.ddlClassDeptCode.SelectedIndexChanged += new System.EventHandler(this.ddlClassDeptCode_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.ddlDeptClassCode.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClassCode_SelectedIndexChanged);
			this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



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
			AdvancedSearchGo("v_SmallFixedAssets_ForAll","Id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
			lblMsg.Text="";
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();


			if(!"".Equals(this.txtInv.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invCode like '%" + this.txtInv.Text.Trim()  + "%' " );

				
			}

			if(!"".Equals(this.txtName .Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invName like '%" + this.txtName.Text.Trim()  + "%' " );

			}

			if(!"".Equals(this.txtManageCode.Text  ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invManageCode  like  '%" + this.txtManageCode.Text   + "%' " );

			}

			if(!"".Equals(this.ddlClassDeptCode.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptClassCode  =  '" + this.ddlClassDeptCode.SelectedValue  + "' " );

			}

			if(!"".Equals(this.ddlDeptentCode.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" DeptCode  =  '" + this.ddlDeptentCode.SelectedValue  + "' " );

			}

			//ddlClassDeptCode

			if(!"".Equals(this.ddlType .SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invClassCode  =  '" + this.ddlType.SelectedValue  + "' " );
				
			}

			if(!"".Equals(this.txtDateFrom.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  >=  '" + this.txtDateFrom.Text  + "' " );
			}

			if(!"".Equals(this.txtDateTo.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" dbizdate  <=  '" + this.txtDateTo .Text  + "' " );
			}

//			if(filter.Length>0)
//			{
//				filter.Append(" and ");
//			}
//			filter.Append(" id not in(select SmallFixedAssets_Id from SmallFixedAssetsChange) ");//�����Ѿ�ת�Ƶ�����
		
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

		/// <summary>
		/// ת�� (liyang 2013-11-05)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			int count=0;
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					count++;
				}
			}

			if(count!=1)
			{
				this.lblMsg.Text="��ѡ��һ����¼�༭";
				return;
			}
			else
			{
				this.lblMsg.Text="";
			}

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					Entiy.SmallFixedAsset sfa=new Entiy.SmallFixedAsset();
					Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

					string sql="select * from v_SmallFixedAssets where id='"+ID+"'";
							
					DataSet ds = dbAccess.ExecuteDataset(sql);
					if(ds.Tables[0].Rows.Count>0)
					{
						this.lblID.Text=ds.Tables[0].Rows[0]["ID"].ToString();//�����ֶ�
						this.lblInvName.Text="Ʒ������: "+ds.Tables[0].Rows[0]["InvName"].ToString();
						//this.lblBApplyDeptClassCode.Text=ds.Tables[0].Rows[0]["nc_deptname"].ToString();+ ds.Tables[0].Rows[0]["DeptCode"].ToString() 
						this.lblBApplyDeptClassCode.Text=ds.Tables[0].Rows[0]["ClassDeptName"].ToString() +  ds.Tables[0].Rows[0]["DeptName"].ToString()   ;



					}
				}
			}
		}


		/// <summary>
		/// ת�������ύ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			try
			{
				if(this.lblID.Text==null || this.lblID.Text=="")
				{
					this.lblMsg.Text="��ѡ��Ҫת�Ƶ�����";
					return;
				}

				if(this.ddlDeptCode.SelectedIndex==0)
				{
					this.lblMsg.Text="��ѡ��ת�Ƶ��ĸ����š�����";
					return;
				}
				if(this.txtDatetime.Text==null || this.txtDatetime.Text=="")
				{
					this.lblMsg.Text="��ѡ������";
					return;
				}
				Visitor MyVisitor = new Visitor(); 
				Entiy.SmallFixedAsset sfa=Entiy.SmallFixedAsset.Find(Int32.Parse(this.lblID.Text));
				Entiy.SmallFixedAssetsChange sfac=new Entiy.SmallFixedAssetsChange();
				sfac.SmallFixedAssetsId=  Int32.Parse(this.lblID.Text);//sfa.ID.ToString(); 
				
				//sfac.Bdptid=sfa.Cdptid; //ת��ǰ����
//				sfac.Bdptid=sfa.DeptCode ;//ת��ǰ����
				sfac.BApplyDeptClassCode = sfa.DeptClassCode ;
				sfac.BApplyDeptCode  = sfa.DeptCode ;
//
//				sfac.Adptid=this.ddlDeptCode.SelectedValue;//ת�ƺ���

				sfac.AApplyDeptClassCode  = this.ddlClassDeptCode.SelectedValue ;
				sfac.AApplyDeptCode       = this.ddlDeptCode.SelectedValue;


				sfac.Datetime=DateTime.Parse( this.txtDatetime.Text);
				sfac.ReMark=this.txtReMark.Text;
				sfac.ImporterCode= MyVisitor.GetUserId.ToUpper().ToString() ;   //MyVisitor.GetUserName;//����Ա
				sfac.Save();

				//����SmallFixedAsset�Ĳ���
				//sfa.Cdptid=this.ddlDeptCode.SelectedValue;//ת�ƺ���
				sfa.DeptClassCode = this.ddlDeptClassCode .SelectedValue ; 
				sfa.DeptCode = this.ddlDeptCode.SelectedValue ; 
				sfa.Save();
				//lblMsg.ForeColor=Color.Blue;
				//lblMsg.Text="ת�Ƴɹ�";
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_SmallFixedAssetsChange",ex.Message );
			}
			
			//���°�
			bindSearchResult();
			this.lblID.Text="";
			this.ddlDeptCode.SelectedIndex=0;
			this.lblInvName.Text="&nbsp;";
			this.lblBApplyDeptClassCode.Text="";
			this.txtDatetime.Text="";
			this.txtReMark.Text="";
		}

		private void ddlClassDeptCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDeptentCode.Items.Clear();
			string bmbh=this.ddlClassDeptCode.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(dtDeptClassCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptentCode .DataSource=dtDeptClassCode;
				ddlDeptentCode.DataValueField=dtDeptClassCode.Columns["bmbh"].ToString();
				ddlDeptentCode.DataTextField =dtDeptClassCode.Columns["bmmc"].ToString();
				ddlDeptentCode.DataBind();
				ddlDeptentCode.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDeptentCode.DataSource=null;
				ddlDeptentCode.DataBind();
			}
		
		}

		private void ddlDeptClassCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDeptCode.Items.Clear();
			string bmbh=this.ddlDeptClassCode.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(ddlDeptCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptCode .DataSource=dtDeptClassCode;
				ddlDeptCode.DataValueField=dtDeptClassCode.Columns["bmbh"].ToString();
				ddlDeptCode.DataTextField =dtDeptClassCode.Columns["bmmc"].ToString();
				ddlDeptCode.DataBind();
				ddlDeptCode.Items.Insert(0,"");
			}		
			else
			{
				this.ddlDeptCode.DataSource=null;
				ddlDeptCode.DataBind();
			}
		}

	}
}
