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
using HDSZCheckFlow.Bussiness;

namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssetsChangeManagement ��ժҪ˵����
	/// </summary>
	public class SmallFixedAssetsChangeManagement : System.Web.UI.Page
	{
		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
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
		protected System.Web.UI.WebControls.TextBox txtImporterCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlBDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlAClassDept;
		protected System.Web.UI.WebControls.DropDownList ddlClassDeptCode;
		
		DBAccess dbAccess=new SQLAccess();		

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				this.btnDel.Attributes.Add("onclick","javascript:return confirm('��ȷ��ȡ����?');"); 
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

				DataTable dtDeptBySmallFixed=Bussiness.CheckFlowInDeptBLL.GetAllDeptBySmallFixed();

				if(dtDeptBySmallFixed!=null && dtDeptBySmallFixed.Rows.Count>0)
				{
					// ��ͷ����
					this.ddlBDeptClass.DataSource=dtDeptBySmallFixed;
					ddlBDeptClass.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlBDeptClass.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlBDeptClass.DataBind();
					ddlBDeptClass.Items.Insert(0,"");

				
					
					this.ddlAClassDept.DataSource = dtDeptBySmallFixed;
					ddlAClassDept.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlAClassDept.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlAClassDept.DataBind();
					ddlAClassDept.Items.Insert(0,"");


					/////////////////////
					

						// ��ͷ����
					this.ddlClassDeptCode.DataSource=dtDeptBySmallFixed;
					ddlClassDeptCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
					ddlClassDeptCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
					ddlClassDeptCode.DataBind();
					ddlClassDeptCode.Items.Insert(0,"");

				
//				
//					this.ddlDeptCode.DataSource = dtDeptBySmallFixed;
//					ddlDeptCode.DataValueField=dtDeptBySmallFixed.Columns["bmbh"].ToString();
//					ddlDeptCode.DataTextField =dtDeptBySmallFixed.Columns["bmmc"].ToString();
//					ddlDeptCode.DataBind();
//					ddlDeptCode.Items.Insert(0,"");


				}

			


//				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();      // 0 ��ѯ���в���
//				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
//				{
//					//ת��ǰ����
//					this.ddlDeptClass.DataSource=dtDeptClass;
//					ddlDeptClass.DataValueField= dtDeptClass.Columns[0].ToString(); 
//					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlDeptClass.DataBind();
//					ddlDeptClass.Items.Insert(0,"");
//					
//					//ת�ƺ���
//					this.ddlOut_NC_DeptName.DataSource=dtDeptClass;
//					ddlOut_NC_DeptName.DataValueField=dtDeptClass.Columns[0].ToString();
//					ddlOut_NC_DeptName.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlOut_NC_DeptName.DataBind();
//					ddlOut_NC_DeptName.Items.Insert(0,"");
//
//					
//
//
//					//ת�Ʋ���
//					this.ddlDeptClassCode.DataSource=dtDeptClass;
//					this.ddlDeptClassCode.DataValueField=dtDeptClass.Columns[0].ToString();
//					this.ddlDeptClassCode.DataTextField =dtDeptClass.Columns["DeptCode_DeptName"].ToString();
//					this.ddlDeptClassCode.DataBind();
//					this.ddlDeptClassCode.Items.Insert(0,"");
//				}

				
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
				oPageViewState.SSort=" [ID] desc ";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_SmallFixedAssetsChangeManagement",ex.Message ); 
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
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemCreated);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			this.ddlClassDeptCode.SelectedIndexChanged += new System.EventHandler(this.ddlClassDeptCode_SelectedIndexChanged);
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
			AdvancedSearchGo("v_SmallFixedAssetsChange","Id",out oPageViewState.PCount,15,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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

//			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" cdptid  =  '" + this.ddlDeptClass.SelectedValue  + "' " );
//			}

			if(!"".Equals(this.ddlBDeptClass.SelectedValue ))//ת��ǰ�Ĳ���
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" BApplyDeptClassCode  =  '" + this.ddlBDeptClass.SelectedValue  + "' " );

			}

			if(!"".Equals(this.ddlAClassDept.SelectedValue ))//ת�ƺ�Ĳ���
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" AApplyDeptClassCode  =  '" + this.ddlAClassDept.SelectedValue  + "' " );

			}


			if(!"".Equals(this.txtImporterCode.Text ))//¼��Ա����
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ImporterCode  =  '" + this.txtImporterCode.Text  + "' " );
				
			}

			

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
				filter.Append(" Datetime  >=  '" + this.txtDateFrom.Text  + "' " );
			}

			if(!"".Equals(this.txtDateTo.Text ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" Datetime  <=  '" + this.txtDateTo .Text  + "' " );
			}
		
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
		/// �༭ (liyang 2013-11-05)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			this.ddlClassDeptCode.SelectedIndex=0;
			this.txtDatetime.Text="";
			this.txtReMark.Text="";

			int count=0;
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked)
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

					string sql="select * from v_SmallFixedAssetsChange where id='"+ID+"'";
							
					DataSet ds = dbAccess.ExecuteDataset(sql);
					if(ds.Tables[0].Rows.Count>0)
					{
						this.lblID.Text=ds.Tables[0].Rows[0]["ID"].ToString();//�����ֶ�
						this.lblInvName.Text="Ʒ������: "+ds.Tables[0].Rows[0]["InvName"].ToString();
						this.lblBApplyDeptClassCode.Text=ds.Tables[0].Rows[0]["bdeptclassname"].ToString() + ds.Tables[0].Rows[0]["bdeptname"].ToString(); 
						this.txtDatetime.Text=String.Format("{0:yyyy-MM-dd}",ds.Tables[0].Rows[0]["Datetime"]);
						this.txtReMark.Text=ds.Tables[0].Rows[0]["ReMark"].ToString(); 
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
			if(this.lblID.Text==null || this.lblID.Text=="")
			{
				this.lblMsg.Text="��ѡ��Ҫת�Ƶ�����";
				return;
			}

			if(this.ddlClassDeptCode.SelectedIndex==0)
			{
				this.lblMsg.Text="��ѡ��ת�Ƶ��ĸ�����";
				return;
			}
			if(this.txtDatetime.Text==null || this.txtDatetime.Text=="")
			{
				this.lblMsg.Text="��ѡ������";
				return;
			}
			
			Visitor MyVisitor = new Visitor(); 
			Entiy.SmallFixedAssetsChange sfac=Entiy.SmallFixedAssetsChange.Find(Int32.Parse(this.lblID.Text));
//			sfac.Bdptid=sfac.Bdptid;//ת��ǰ����
//			sfac.Adptid=this.ddlAApplyDeptClassCode.SelectedValue;//ת�ƺ��� 

			sfac.AApplyDeptClassCode = this.ddlClassDeptCode.SelectedValue;
			sfac.AApplyDeptCode      = this.ddlDeptCode.SelectedValue;

			sfac.Datetime=DateTime.Parse( this.txtDatetime.Text);
			sfac.ReMark=this.txtReMark.Text;
			sfac.ImporterCode=MyVisitor.GetUserName;//����Ա
			
			sfac.Save(); 

			Entiy.SmallFixedAsset sfa=Entiy.SmallFixedAsset.Find(sfac.SmallFixedAssetsId);
			//����SmallFixedAsset�Ĳ���
			//sfa.Cdptid=this.ddlClassDeptCode.SelectedValue;//ת�ƺ���

			sfa.DeptClassCode =  this.ddlClassDeptCode.SelectedValue;
			sfa.DeptCode =  this.ddlDeptCode.SelectedValue;



			sfa.Save();

			//���°�
			bindSearchResult();
			this.ddlClassDeptCode.SelectedIndex=0;
			this.lblInvName.Text="&nbsp;";
			this.lblBApplyDeptClassCode.Text="";
			this.txtDatetime.Text="";
			this.txtReMark.Text="";
		}

		/// <summary>
		/// ɾ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					if(ID!=null || ID!="")
					{
						string sql="delete from SmallFixedAssetsChange where ID="+ID;
						dbAccess.ExecuteNonQuery(sql);
					}
				}
			}

			//���°�
			bindSearchResult();
		}


		/// <summary>
		/// ����Excel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnExport_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssetsChange";
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

		/// <summary>
		/// ���⵼��Excel���ֵ��쳣
		/// </summary>
		/// <param name="control"></param>
		public override void VerifyRenderingInServerForm(Control control)
		{
		}

		private void chbSelectAll_CheckedChanged(object sender, System.EventArgs e)
		{
			CheckBox chbAll=(CheckBox)sender;
			//ȫѡ
			if(chbAll.Checked )
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					chkCode.Checked=true;
				}
			}
			else
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					chkCode.Checked=false;				
				}
			}
		}

		private void dgApply_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			if(e.Item.ItemType==ListItemType.Header)
			{
				CheckBox chbAll=(CheckBox)e.Item.FindControl("chbAll");
				if(chbAll!=null)
				{
					chbAll.CheckedChanged+=new EventHandler(chbSelectAll_CheckedChanged);
				}
			}
		}

		private void ddlClassDeptCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//�󶨿���
			this.ddlDeptCode.Items.Clear();
			string bmbh=this.ddlClassDeptCode.SelectedValue;
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
