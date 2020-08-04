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
using AjaxPro;
using System.Text;
using System.Text.RegularExpressions;

namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// EditPriceCheckApply ��ժҪ˵����
	/// </summary>
	public class EditPriceCheckApply : System.Web.UI.Page
	{
		#region

		protected System.Web.UI.WebControls.Panel pAddItem;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyCheckHead;
		protected System.Web.UI.WebControls.Panel PBudgetInfo;
		protected System.Web.UI.WebControls.Label lbBudget;
		protected System.Web.UI.WebControls.Label lbOutMoney;
		protected System.Web.UI.WebControls.Label lbSumCheck;
		protected System.Web.UI.WebControls.Label lbready;
		protected System.Web.UI.WebControls.Label lbSheetMoney;
		protected System.Web.UI.WebControls.Label lbLeft;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.WebControls.LinkButton linkToPage;
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.Button btnInBudget;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddPriceCheckApply_Setp2));

			//�ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				//�󶨿��Ա༭�ĵ��� �� �½�/ȡ��
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

		#region  ��ҳ��ѯ
		string SQuery="";  //��ѯ����
		private void bindSearchResult()
		{
			//��ѯ���ֶ�, * Ϊ����
			string sFields="*";
			//��ȡ��ѯ����      
			SQuery= GetQuerySqlString();
			//�����ѯ״̬
			PageViewState oPageViewState=PageViewState.GetPageViewState(this.ViewState);
			//��������:1.��ѯ�����ͼ,������Ψһ��, 2.ָ������(Ψһ��) 3.������� ҳ��С 4.ҳ�ߴ�(һҳ���ټ�¼) 5.��ǰ��ѯҳ�� 6.�����ֶ� 7.����ʽ 8.��ѯ���� 9.��ѯ�ֶ�
			AdvancedSearchGo("v_FinallyPriceCheckList","Id",out oPageViewState.PCount,5,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
			//�ű�
			divPages.InnerHtml=PageViewState.GetUrl(this.ViewState);
		}

		private string GetQuerySqlString()
		{
			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();

			// �������� �� �ύ״̬Ϊ 1 ��.��ʱ�̶�Ϊ ApplyProcessCode �� 101  �� 201 ���Ժ�����

			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" IsSubmit = 0  "  );

		
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
			//this.dgPostail.DataSource=null;        //��¼���ÿ�
			//this.dgPostail.DataBind();
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
					Common.Log.Logger.Log("UI.Asset.PriceCheck.linkToPage_Click",ex.Message );
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
				Common.Log.Logger.Log("UI.Asset.PriceCheck.linkToPage_Click",ex.Message );
			}
		}

		#endregion

		
		/// <summary>
		/// �󶨱�����Ϣ
		/// </summary>
		/// <param name="ApplyHeadPk"></param>
		private void BindApplyBodyInfo(int FinallyCheckId)
		{

			//������ϸ��Ϣ
			DataSet ds= Bussiness.ApplyAuditingBLL.GetFinallyBodyInfoByCheckId(FinallyCheckId);
			if(ds!=null)
			{
				this.dgApplyBody.DataSource=ds;
			}
			else
			{
				this.dgApplyBody.DataSource=null;
			}
			this.dgApplyBody.DataBind();
			
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
			this.btnInBudget.Click += new System.EventHandler(this.btnInBudget_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

	
		private static  Color color;
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//ѡ��ť
			if(e.CommandName.Equals("look"))
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

				this.hideApplyCheckHead.Value = e.Item.Cells[0].Text ; 
				//3. �󶨱�����Ϣ
				BindApplyBodyInfo(int.Parse(e.Item.Cells[0].Text));

				//��Ӹ�������
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../../Asset/PriceCheck/ApplySheetAnnexForFinallyCheck.aspx?FinallyCheckId=" + e.Item.Cells[0].Text;			
			}
			//ɾ����ť
			else if (e.CommandName.Equals("delete")) 
			{
				//1.�ж��ǿ���ɾ��״̬ ���½�/ȡ�� 
				//2.ɾ���۸�þ�����ͷ����Ӧsqlserver��ɾ���ӱ�

				int FinallyCheckId = int.Parse(e.Item.Cells[0].Text);

				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId); 

				if(FinallyCheck != null )
				{
					FinallyCheck.Delete();
				}
				//���°�
				//bindGrid();

				PageViewState oPageViewState=new PageViewState();
				oPageViewState.PCount=0;
				oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );

				//this.pagesIndex.Value =oPageViewState.PIndex.ToString();
			
				oPageViewState.SSort=this.FieldSort.Value ;//"bmmc";
				oPageViewState.SortType=int.Parse(this.HerdSort.Value) ;//1;

				this.HerdSort.Value =oPageViewState.SortType.ToString();
				PageViewState.SetPageViewState(this.ViewState , oPageViewState);
				bindSearchResult();
			}
		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//�󶨸�����ť��ʾ��Ϣ
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[2].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('��ȷ��ɾ����?');"); 
			}

		
		}

		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			//�۸񳬹�ԭ���ݼ۸� ��ֹ
			//��������ԭ�������� ��ֹ
			//�����Ѽ۸�þ�����

			int FinallyCheckKey = int.Parse(this.hideApplyCheckHead.Value);

			//����Ƿ������������Ƿ��к�ͬ�ŵȣ� 

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

			if(FinallyCheck != null && FinallyCheck.BargainNo.Length <= 0 ) 
			{
				this.lbMsg.Text = "��ͬ�Ų���Ϊ��";
				return ;
			}

			//����ύ
			int i = Bussiness.AssetFinallyCheckPrice.CheckFinallyApplyAndBody(FinallyCheckKey);

			if(i==1)
			{
				//�۸� �����ϸ� ���ύ���� 
				int Flag = Bussiness.AssetCheckFlowBLL.StartFinallyPriceCheckFlow(FinallyCheckKey) ; 
				if(Flag == 1 )
				{
					this.lbMsg.Text = "�����Ѿ��ύ��";
					//�ύ��ռ���ύ���� �� ��������� 
					//�۸�þ���ͷ
					//�����Ѿ��۸�þ���������
					Bussiness.AssetCheckFlowBLL.AddFinallyCheckNumber(FinallyCheck.Id);
				}
				else
				{
					switch(Flag)
					{
							//����ֵ�� 1���� 2�Ѿ��ύ 3δ�ҵ����� ��4δ�ҵ����ݡ�5�Ѿ��ύ��
						case 1:
							this.lbMsg.Text = "�ѳɹ��ύ��";
							break;
						case 2:
							this.lbMsg.Text ="�����Ѿ��ύ���벻Ҫ�ظ�����";
							break;
						case 3:
							this.lbMsg.Text ="δ�ҵ����̣�";
							break;
						case 4:
							this.lbMsg.Text ="δ�ҵ����ݣ�";
							break;
					}
				}
			}
			else
			{
				switch (i)
				{
					case 2:
						this.lbMsg.Text = "�۸񳬳�";
						break;
					case 3:
						this.lbMsg.Text = "��������";
						break;
					case 4:
						this.lbMsg.Text ="ϵͳ����";
						break;
				}
			}

			//���°�
			//bindGrid();
			PageViewState oPageViewState=new PageViewState();
			oPageViewState.PCount=0;
			oPageViewState.PIndex=int.Parse(this.pagesIndex.Value );			
			oPageViewState.SSort=this.FieldSort.Value ; 
			oPageViewState.SortType=int.Parse(this.HerdSort.Value) ; 
			this.HerdSort.Value =oPageViewState.SortType.ToString();
			PageViewState.SetPageViewState(this.ViewState , oPageViewState);
			bindSearchResult();
		}

	}
}
