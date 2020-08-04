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


namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// GetBackPriceCheckApply ��ժҪ˵����
	/// </summary>
	public class GetBackPriceCheckApply : System.Web.UI.Page
	{
		#region
		protected System.Web.UI.WebControls.DataGrid dgApply;
//		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
//		protected System.Web.UI.WebControls.Button btnQuery;
//		protected System.Web.UI.WebControls.DropDownList ddlType;
//		protected System.Web.UI.WebControls.TextBox txtDateFrom;
//		protected System.Web.UI.WebControls.TextBox txtDateTo;
//		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
//		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.WebControls.DataGrid dgPostail;//����ʽ 1,����.2����
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.WebControls.Label lbMsg;
		protected System.Web.UI.WebControls.Button btnGetBack;
		protected System.Web.UI.WebControls.Button btnKeep;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyHead;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
//		protected System.Web.UI.WebControls.TextBox txtApplyNo;
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
				PageViewState oPageViewState=new PageViewState();          //����״̬
				oPageViewState.PCount=0;                                   //���ز���, ��¼����
				oPageViewState.PSize=5;                                   //���ز���,   ҳ��С
				oPageViewState.PIndex=1;                                   //��ǰ��ѯҳ��
				oPageViewState.SortType=2;                                 //����ʽ
				oPageViewState.SSort="Id";                                 //�����ֶ�
				this.HerdSort.Value =oPageViewState.SortType.ToString();   //��¼��ȫ�ֱ���,��ͷ�������
				this.FieldSort.Value =oPageViewState.SSort.ToString();     //ͬ��,�����ֶ�

				PageViewState.SetPageViewState(this.ViewState,oPageViewState);
				bindSearchResult();
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
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
			this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
			this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private static  Color color;

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("look")) //���������ť
			{
				//������¼
				GetApplyRecordForFinallyCheck(int.Parse(e.Item.Cells[0].Text));

				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					if(this.dgApply.Items[i].BackColor==Color.Yellow)
					{
						this.dgApply.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow;

				//���۸�þ����� ���浽������ 
				this.hideApplyHead.Value = e.Item.Cells[0].Text ; 
			}
		}

		#region  ��ҳ��ѯ
		string SQuery="";  //��ѯ����
		private void bindSearchResult()
		{
			//��ѯ���ֶ�, * Ϊ����
			string sFields="*";
			//��ȡ��ѯ����      
			SQuery=" IsDisallow = 1 or (IsSubmit = 1 and IsCheck = 0 ) or issubmitAgain = 1 ";
			//�����ѯ״̬
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//��������:1.��ѯ�����ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_FinallyPriceCheckList","Id",out oPageViewState.PCount,5,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			this.dgPostail.DataSource=null;        //��¼���ÿ�
			this.dgPostail.DataBind();
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

		private void GetApplyRecordForFinallyCheck(int FinallyCheckId)
		{
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecordForFinallyCheck(FinallyCheckId);
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

		private void btnGetBack_Click(object sender, System.EventArgs e)
		{
			//ȡ�ص���

			//ȡ�ر�, 1,���ǻ�û����������ȡ��, ����Ϊ�½�״̬, 2.�����ص�ȡ��,����Ϊȡ��״̬

			int FinallyCheckId = int.Parse(this.hideApplyHead.Value);

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId);

			if(FinallyCheck != null )
			{
				Entiy.ApplyProcessType ApplyProcess=Entiy.ApplyProcessType.Find(FinallyCheck.ApplyProcessCode); //�鿴���뵥����
				if(ApplyProcess!=null)
				{
					if((ApplyProcess.IsSubmit == 1 && ApplyProcess.IsCheck==0 ) )  //�½���δ�������� or ����
					{
						//����Ϊ�½�״̬, ��������������pkΪ 0
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;
						FinallyCheck.CheckFlowInCompanyHeadPk=0;
						FinallyCheck.CurrentCheckRole="";
						FinallyCheck.IsCheckInCompany=0;
						FinallyCheck.CheckSetp=0;                                  //����������Ϊ0
						FinallyCheck.Update();
						//RemoveBudget(FinallyCheck.ApplySheetHeadPk);
						//����Ѽ۸�þ�����
						Bussiness.AssetCheckFlowBLL.RemoveFinallyCheckNumber(FinallyCheck.Id);
					}
					else if(ApplyProcess.IsDisallow == 1)
					{
						//����Ϊȡ��״̬, ��������������pkΪ 0
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.GetBackPross;
						FinallyCheck.CheckFlowInCompanyHeadPk=0;
						FinallyCheck.CurrentCheckRole="";
						FinallyCheck.IsCheckInCompany=0;
						FinallyCheck.CheckSetp=0;                                  //����������Ϊ0
						FinallyCheck.Update();
						//RemoveBudget(FinallyCheck.ApplySheetHeadPk);
						//����Ѽ۸�þ�����
						Bussiness.AssetCheckFlowBLL.RemoveFinallyCheckNumber(FinallyCheck.Id);
					}
					//���°�
					bindGrid();
				}
				else
				{
					this.lbMsg.Text = "ϵͳ����û���ҵ����ݣ�";
				}
			}
		}

		private void btnKeep_Click(object sender, System.EventArgs e)
		{
			//��浥�ݣ��۸�þ�����ʱû�з�����ã�
		}

	}
}
