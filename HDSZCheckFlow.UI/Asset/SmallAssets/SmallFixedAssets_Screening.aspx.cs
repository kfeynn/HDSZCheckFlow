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
	/// SmallFixedAssets_Screening ��ժҪ˵����
	/// </summary>
	public class SmallFixedAssets_Screening : System.Web.UI.Page
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
		protected System.Web.UI.WebControls.Button btnEntryOK;
		protected System.Web.UI.WebControls.Button btnFail;
		protected System.Web.UI.WebControls.Label lblMsg;
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

				DataTable dtDeptClass=Bussiness.SmallFixedBLL.GetNCDeptInfo ();;      // 0 ��ѯ���в���
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[2].ToString();
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
				Common.Log.Logger.Log("v_SmallFixedAssets_Screening",ex.Message );
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
			this.btnEntryOK.Click += new System.EventHandler(this.btnEntryOK_Click);
			this.btnFail.Click += new System.EventHandler(this.btnFail_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
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
			AdvancedSearchGo("v_SmallFixedAssets_Screening","Id",out oPageViewState.PCount,20,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
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

			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" cdptid  =  '" + this.ddlDeptClass.SelectedValue  + "' " );

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
		/// ȷʵΪС��̶��ʲ� (liyang 2013-10-31)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnEntryOK_Click(object sender, System.EventArgs e)
		{
			lblMsg.Text= "" ; 
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
						Entiy.SmallFixedAsset sfa=new Entiy.SmallFixedAsset();
						Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

						string sql="select * from v_SmallFixedAssets_Screening where id='"+ID+"'";
						DBAccess dbAccess=new SQLAccess();				
						DataSet ds = dbAccess.ExecuteDataset(sql);
						if(sfa != null && ds.Tables[0].Rows.Count>0)
						{ 
							sfa.InvSheetId=ID;
							sfa.Vbillcode=ds.Tables[0].Rows[0]["vbillcode"].ToString();
							sfa.Cinventoryid=ds.Tables[0].Rows[0]["cinventoryid"].ToString();
							sfa.Dbizdate=ds .Tables[0].Rows[0]["dbizdate"].ToString();
							sfa.Price=ds.Tables[0].Rows[0]["OriginalcurPrice"].ToString();
							sfa.CurrTypeCode=ds.Tables[0].Rows[0]["CurrTypeCode"].ToString();
							sfa.Noutnum=Common.Util.CommonUtil.MySubString(ds.Tables[0].Rows[0]["noutnum"].ToString());//ȥ��С����
                            sfa.INum = int.Parse(Common.Util.CommonUtil.MySubString(ds.Tables[0].Rows[0]["noutnum"].ToString()));
							sfa.Ninnum=ds.Tables[0].Rows[0]["ninnum"].ToString();
							sfa.Cwarehouseid=ds.Tables[0].Rows[0]["cwarehouseid"].ToString();
							sfa.Cdispatcherid=ds.Tables[0].Rows[0]["cdispatcherid"].ToString();
							sfa.Cdptid=ds.Tables[0].Rows[0]["cdptid"].ToString();
							SmallFixedBLL.Save(sfa);

							lblMsg.Text= "��ӳɹ���";

							//��ʱ����
//							//�޸Ĺ��˱�(��ѡΪС�̶��ʲ������ݴӹ��˱�����Ϊ2�����ٳ����ڿ�ѡ��������˱��1��2�������ڿ�ѡ������)
//							if(SmFlag != null)
//							{
//								SmFlag.IsFlag = 2 ;
//								SmFlag.Save ();	
//							}
//							else//���SmallFixedAssetsFlag��û�и����ݣ��ͼ�¼�����ݣ������ٴγ����ڿ�ѡ�����
//							{							
//								Entiy.SmallFixedAssetsFlag SmFlag_new = new Entiy.SmallFixedAssetsFlag();
//								SmFlag_new.InvSheetId=ID;
//								SmFlag_new.IsFlag = 2 ;
//								SmallFixedAssetsFlagBLL.Save(SmFlag_new);	 	
//								//SmFlag_new.Create();
//							}
						}
					}
				}
				if(!flag)
				{
					lblMsg.Text="��ѡ�����������ٲ�����";
					return;
				}
//				else
//				{
//					lblMsg.Text="";
//				}
				
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("btnEntryOK_Click",ex.Message );
			}

			//���°�
			//bindSearchResult();
		}

		/// <summary>(liyang 2013-10-31)
		/// ����С��̶��ʲ�(�ڿ�ѡ������ȥ������С��̶��ʲ������ǽ���־��Ϊ1�������ݲ������ڿ�ѡ������)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnFail_Click(object sender, System.EventArgs e)
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

					Entiy.SmallFixedAssetsFlag SmFlag = Entiy.SmallFixedAssetsFlag.Find(ID);

					if(SmFlag != null)
					{
						SmFlag.IsFlag = 1 ;

						SmFlag.Save ();
					}
					else
					{
						//������ʵ��

//						string cmdStr = " insert into SmallFixedAssetsFlag(invsheetid,isflag) values ('" + ID + "', 1 ) ";
//						Bussiness.ComQuaryBLL.ExecuteStr(cmdStr);

						Entiy.SmallFixedAssetsFlag SmFlag_new = new Entiy.SmallFixedAssetsFlag();
						SmFlag_new.InvSheetId=ID;
						SmFlag_new.IsFlag = 1 ;
						SmallFixedAssetsFlagBLL.Save(SmFlag_new);	 


					}

				}
			}
			if(!flag)
			{
				lblMsg.Text="��ѡ�����������ٲ�����";
				return;
			}
			else
			{
				lblMsg.Text="";
			}
				
		}
		catch(Exception ex)
		{
			Common.Log.Logger.Log("btnFail_Click",ex.Message );
		}


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

		private void btnExportExcel_Click(object sender, System.EventArgs e)
		{
			this.dgApply.AllowSorting=false;
			this.dgApply.AllowPaging=false;
			
			string cmdStr = "select * from v_SmallFixedAssets_Screening";
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



	}
}
