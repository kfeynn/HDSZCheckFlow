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
using System.Text.RegularExpressions;


namespace HDSZCheckFlow.UI.Asset.SmallAssets
{
	/// <summary>
	/// SmallFixedAssets ��ժҪ˵����
	/// </summary>
	public class SmallFixedAssets : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.TextBox txtRetireDate;
		protected System.Web.UI.WebControls.TextBox txtRetireNum;
		protected System.Web.UI.WebControls.TextBox txtReMark;
		protected System.Web.UI.WebControls.Button btnSubmit;
		protected System.Web.UI.WebControls.TextBox txtPrice;
		protected System.Web.UI.WebControls.TextBox txtCurrTypeCode;
		protected System.Web.UI.WebControls.TextBox txtNoutnum;
		protected System.Web.UI.WebControls.Label lblID;
		protected System.Web.UI.WebControls.TextBox txtInv;

		#endregion 
		protected System.Web.UI.WebControls.TextBox txtInvManageCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClassCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlClassDeptCode;
		protected System.Web.UI.WebControls.DropDownList ddlDeptentCode;
		protected System.Web.UI.WebControls.TextBox txtManageCode;

		
		DBAccess dbAccess=new SQLAccess();		

		private void Page_Load(object sender, System.EventArgs e)
		{
			Response.Cache.SetNoStore(); 
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

//				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();    // 0 ��ѯ���в��� 
//				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
//				{
//					this.ddlDeptClass.DataSource=dtDeptClass;
//					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
//					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
//					ddlDeptClass.DataBind();
//					ddlDeptClass.Items.Insert(0,"");
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
				oPageViewState.SortType=1;           //����ʽ
				oPageViewState.SSort=" [InvManageCode] asc ";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("v_SmallFixedAssets",ex.Message );
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
			this.dgApply.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemCreated);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
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
			AdvancedSearchGo("[v_SmallFixedAssets_ForAll]","Id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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

			if(!"".Equals(this.txtManageCode.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" invManageCode like '%" + this.txtManageCode.Text.Trim()  + "%' " );

				
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
//
//			}

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
			//			filter.Append("  ( cast(rmbprice as decimal) >= 500 )     " );
		
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
				this.FieldSort.Value+=" ASC ";
			}
			else if(int.Parse(this.HerdSort.Value )==1)
			{
				this.HerdSort.Value ="2";
				this.FieldSort.Value+=" DESC ";
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

		

		/// <summary>
		/// �༭ (liyang 2013-11-01)
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

					string sql="select * from v_SmallFixedAssets_forall where id='"+ID+"'";
							
					DataSet ds = dbAccess.ExecuteDataset(sql);
					if(ds.Tables[0].Rows.Count>0)
					{
						//sfa.InvSheetId=ID;
						this.lblID.Text=ds.Tables[0].Rows[0]["ID"].ToString();//�����ֶ�
						this.lblInvName.Text="Ʒ������: "+ds.Tables[0].Rows[0]["InvName"].ToString();
						
						
						this.txtPeriod.Text =ds .Tables[0].Rows[0]["Period"].ToString();
						this.txtNoutnum.Text =ds.Tables[0].Rows[0]["leftnum"].ToString();
						this.txtRetireDate.Text =String.Format("{0:yyyy-MM-dd}",ds.Tables[0].Rows[0]["RetireDate"]);
						this.txtRetireNum.Text =ds.Tables[0].Rows[0]["RetireNum"].ToString();
						this.txtReMark.Text=ds.Tables[0].Rows[0]["ReMark"].ToString(); 
						this.txtInvManageCode.Text=ds.Tables[0].Rows[0]["InvManageCode"].ToString(); 
						this.ddlDeptClassCode.SelectedValue=ds.Tables[0].Rows[0]["DeptClassCode"].ToString();
						this.txtPrice.Text =ds.Tables[0].Rows[0]["RmbPrice"].ToString();
						this.txtCurrTypeCode.Text =ds.Tables[0].Rows[0]["CurrTypeCode"].ToString();

						BindDeptCode();

						if(ds.Tables[0].Rows[0]["DeptCode"].ToString().Trim() != "")
						{

							this.ddlDeptCode.SelectedValue=ds.Tables[0].Rows[0]["DeptCode"].ToString();
						}



				
						//sfa.Save ();
					}
				}
			}

			//���°�
			//bindSearchResult();
			//this.lblMsg.Text="";
		}

		/// <summary>(liyang 2013-11-01)
		/// ɾ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDel_Click(object sender, System.EventArgs e)
		{
			bool flag=false;
			try
			{
				foreach(DataGridItem itm in this.dgApply.Items )
				{
					CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
					if( chkCode.Checked )
					{
						flag=true;
						string ID= this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
						if(ID!=null || ID!="")
						{
							string sql=" delete from SmallFixedAssets where ID="+ID ;
							dbAccess.ExecuteNonQuery(sql);
						}
					}
				}
				if(!flag)
				{
					lblMsg.Text="��ѡ��Ҫɾ�������ݣ�";
					return;
				}
				else
				{
					lblMsg.Text="";
				}				
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("btnDel_Click",ex.Message );
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
			
			string cmdStr = "select * from v_SmallFixedAssets_ForAll ";
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


		/// <summary>
		/// �༭�����ύ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if(this.lblID.Text==null || this.lblID.Text=="")
			{
				this.lblMsg.Text="��ѡ��Ҫ�༭������";
				return;
			}
			Entiy.SmallFixedAsset sfa=Entiy.SmallFixedAsset.Find(Int32.Parse(this.lblID.Text));


			if(this.txtPeriod.Text==null || this.txtPeriod.Text=="")
			{
				this.txtPeriod.Text="0";
			}
			
			Regex   reg=new   Regex("^[0-9]+$"); 

			Match   retireNum_text=reg.Match(this.txtRetireNum.Text); 
			Match   noutnum_text=reg.Match(this.txtNoutnum.Text); 
			Match   period_text=reg.Match(this.txtPeriod.Text); 
			if(!retireNum_text.Success || !noutnum_text.Success || !period_text.Success) 
			{ 
				lblMsg.Text="����ȷ����������ݣ�";
				return ;
			} 
			else
			{
				lblMsg.Text="";
			}
			
			int retireNum=Int32.Parse(this.txtRetireNum.Text);
			int noutNum=Int32.Parse(this.txtNoutnum.Text);

			//�����������ܴ��ڳ�������
			if(retireNum>noutNum)
			{
				lblMsg.Text="���������ܴ��ڿ���";
				return;
			}
			else
			{
				lblMsg.Text="";
			}

			//��������������ڳ��������������Ƿ񱨷���Ϊ1
			if(retireNum==noutNum)
			{
				//�����������ڣ���Ĭ��Ϊ��ǰ����
				if(this.txtRetireDate.Text.Trim().Length==0)
				{
						this.txtRetireDate.Text=DateTime.Now.ToString("yyyy-MM-dd");
				 }
					 sfa.IsRetire=1; 
			}
			else
			{
				sfa.IsRetire=0;
			}

			sfa.Price=this.txtPrice.Text;//�۸�
			sfa.CurrTypeCode=this.txtCurrTypeCode.Text;//����
			sfa.Period=Int32.Parse(this.txtPeriod.Text);
			sfa.Noutnum=this.txtNoutnum.Text;
			sfa.ReMark=this.txtReMark.Text;
			sfa.RetireDate=this.txtRetireDate.Text;
			sfa.RetireNum=retireNum;
			sfa.ID=Int32.Parse(this.lblID.Text);
			sfa.InvManageCode=txtInvManageCode.Text;
			sfa.DeptClassCode=this.ddlDeptClassCode.SelectedValue;
			sfa.DeptCode=this.ddlDeptCode.SelectedValue;
			
			sfa.Update();

			//���°�
			bindSearchResult();
			
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

		private void ddlDeptClassCode_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			BindDeptCode();
		}

		private void BindDeptCode()
		{
			//�󶨿���
			this.ddlDeptCode.Items.Clear();
			string bmbh=this.ddlDeptClassCode.SelectedValue;
			DataTable dtDeptClassCode=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassBySmallFixed(bmbh);
			if(dtDeptClassCode!=null && dtDeptClassCode.Rows.Count>0)
			{
				this.ddlDeptCode.DataSource=dtDeptClassCode;
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
	}
}
