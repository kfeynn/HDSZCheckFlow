//AssetArrivalRemarks
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

namespace HDSZCheckFlow.UI.Asset.FixedAssets2
{
	/// <summary>
	/// AssetAdvanceRemarkss ��ժҪ˵����
	/// </summary>
	public class AssetArrivalRemarks : System.Web.UI.Page
	{

		#region 
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.Button btnEnter;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.Label lblHidden;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.CheckBox CheckBox1;
		protected System.Web.UI.WebControls.RadioButton rbtMark1;
		protected System.Web.UI.WebControls.RadioButton rbtMark2;
		protected System.Web.UI.WebControls.RadioButton rbtMark3;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.TextBox txtBargainNo;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		//����ʽ 1,����.2����
		protected System.Web.UI.WebControls.TextBox txtApplyNo;

		#endregion 


		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				
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
				oPageViewState.PSize=10;                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                  //��ǰ��ѯҳ��
				oPageViewState.SortType=3;           //����ʽ
				oPageViewState.SSort=" BargainNo desc,applysheetno desc ";        //�����ֶ�

				this.HerdSort.Value =oPageViewState.SortType.ToString ();                //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort;                  //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.Message );
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
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals("ReMark")) //���������ť
				{
					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						{
							this.dgApply.Items[i].BackColor= color;
						}
					}
					color=e.Item.BackColor;
					e.Item.BackColor=Color.Yellow;

					// ..initial Panel

					this.Panel1.Visible=true;
					HyperLink hl = (HyperLink)e.Item.Cells[3].Controls[0];   
					this.Label5.Text= hl.Text;
					
					Entiy.AssetFinallyPriceCheckBody applyBody = Entiy.AssetFinallyPriceCheckBody.Find(int.Parse(e.Item.Cells[0].Text));
					if(applyBody!=null)
					{
						if(applyBody.IsArrived  == 1)
						{
							this.CheckBox1.Checked =true;
						}
						else
						{
							this.CheckBox1.Checked =false;
						}

						this.txtDate.Text = applyBody.ArriveDatetime ; 

						
					}
					applyBody =  null;

					this.lblHidden.Visible=false;
					this.lblHidden.Text = e.Item.Cells[0].Text;

					this.lblMessage.Text = "";
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Ԥ���ע",ex.ToString());
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
			AdvancedSearchGo("v_Asset_FinallyCheckBody","id",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				//���� this.txtApplyNo.Text ,���ŷָ�    ǰ������� ������
				string querySheetNoStr = "";
				string []tempStr = this.txtApplyNo.Text.Split(new char[] {','});
				foreach(string aaStr in tempStr)
				{
					if(querySheetNoStr.Length > 0 )
					{
						querySheetNoStr = querySheetNoStr + "," + "'" + aaStr + "'" ;
					}
					else
					{
						querySheetNoStr =  "'" + aaStr + "'" ; 
					}
				}

				filter.Append(" ApplySheetNo in  " +" (" + querySheetNoStr + ")" );
			}
			if(!"".Equals(this.txtBargainNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				filter.Append(" BargainNo  like '%"  + this.txtBargainNo.Text + "%'" );
			}

			if(!"".Equals(this.txtDateFrom.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				filter.Append(" arrivedatetime  >= '"  + this.txtDateFrom.Text + "'" );
			}

			if(!"".Equals(this.txtDateTo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				filter.Append(" arrivedatetime  <= '"  + this.txtDateTo.Text + "'" );
			}




			if(!this.rbtMark3.Checked)
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				if(this.rbtMark1.Checked )
				{
					filter.Append(" IsArrived = 1 " );
				}
				else
				{
					filter.Append(" (IsArrived = 0 or IsArrived is null) " );
				}
			}

			//���½�״̬
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsCheckInCompany = 1  " );
		
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

			//���� ���� 

			this.Panel1.Visible = false;
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
			this.Panel1.Visible = false;
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

		private void btnEnter_Click(object sender, System.EventArgs e)
		{	
			if(!"".Equals(this.lblHidden.Text))
			{
				int isOrder = this.CheckBox1.Checked ? 1 : 0 ;

				string username = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name) );

				Entiy.AssetFinallyPriceCheckBody AFBody = Entiy.AssetFinallyPriceCheckBody.Find(int.Parse(this.lblHidden.Text));
				if(AFBody != null )
				{
					if(isOrder == 0 && AFBody.IsInStore == 1 )
					{
						this.lblMessage.ForeColor= Color.Red ;
						this.lblMessage.Text = "�Ѿ�������⣬�����޸ģ�";
					}
					else
					{
						AFBody.IsArrived  = isOrder ;
						AFBody.ArriveDatetime  = this.txtDate.Text ;
						AFBody.ArriveSigner = username;
						AFBody.Update();

						this.lblMessage.Text = "�޸ĳɹ�!";

						//���²�ѯ 


						PageViewState oPageViewState=new PageViewState();

						oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );
						oPageViewState.SSort=this.FieldSort.Value ;
						oPageViewState.SortType=int.Parse(this.HerdSort.Value );

						this.HerdSort.Value =oPageViewState.SortType.ToString();
						PageViewState.SetPageViewState(this.ViewState , oPageViewState);
						bindSearchResult();
					}
				}
			}
			else
			{
				this.lblMessage.Text  = "�����Ҳ�����עID! " ;
			}
		}

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//����


			//������Excel   v_Asset_FinallyCheckBody

			string cmdStr = "" ;//GetQuerySqlString();

			cmdStr = " select applysheetno ������, BargainNo ��ͬ��,deptname ���벿��,makedate �������� ,InventoryName ��Ŀ����,IsArrived ����,ArriveSigner ��ע��Ա,ArriveDatetime ����ʱ�� ,offer ��Ӧ��,number ����,currtypecode ����,Exchangerate ����, Finallyprice �۸�,Exchangerate * number * Finallyprice as RMB��� from v_Asset_FinallyCheckBody  where " + GetQuerySqlString();

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery (cmdStr); 

			if(ds!=null && ds.Tables[0].Rows.Count > 0 )
			{
				Common.Util.ExcelHelper excelhelper = new HDSZCheckFlow.Common.Util.ExcelHelper();

				excelhelper.GoToExcelFromDataSet("fileName.csv",ds);
			}

		
		}

	}
}
