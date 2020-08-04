// CancelOrderPurchase
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

namespace HDSZCheckFlow.UI.OrderManage.BaseInfo
{
	/// <summary>
	/// ApplyOfCompanyState ��ժҪ˵����
	/// </summary>
	public class CancelOrderPurchase : System.Web.UI.Page
	{
		#region 

		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.LinkButton linkToPage;

		protected System.Web.UI.HtmlControls.HtmlGenericControl divPages;
		protected System.Web.UI.HtmlControls.HtmlInputHidden pagesIndex;//�б�ͷ����ʱ,��Ҫ��ס��ǰ��ҳ��
		protected System.Web.UI.HtmlControls.HtmlInputHidden FieldSort;//��������
		protected System.Web.UI.HtmlControls.HtmlInputHidden HerdSort;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.TextBox txtProduct;
		protected System.Web.UI.WebControls.CheckBox chbSelectAll;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.ImageButton imgBtnUp;
		protected System.Web.UI.WebControls.ImageButton imgBtnDown;
		protected System.Web.UI.WebControls.DataGrid dgOrder;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnSaveOrder;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.TextBox txtOrderNo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden IsEdit;
		protected System.Web.UI.WebControls.DropDownList ddlInvClass;
		//����ʽ 1,����.2����
		protected System.Web.UI.WebControls.TextBox txtApplyNo;

		#endregion 

		private void Page_Load(object sender, System.EventArgs e)
		{
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				
				bindGrid();

				this.dgOrder.DataSource= Bussiness.OrderManageBLL.GetNormalTable() ;
				this.dgOrder.DataBind();
			}
		}

		private void InitPageForAdd()
		{
			try
			{
				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);      // 0 ��ѯ���в���
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

				string cmdStr = "SELECT invClass_pk, InvClassName FROM Base_InvClass where (LEN(invclasscode) > 1)  and (LEFT(invclasscode, 1) in  ('E','F'))  ORder by invclasscode";
				DataTable dt = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr).Tables[0];
				if(dt!=null && dt.Rows.Count>0)
				{
					this.ddlInvClass .DataSource=dt;
					ddlInvClass.DataValueField=dt.Columns[0].ToString();
					ddlInvClass.DataTextField =dt.Columns[1].ToString();
					ddlInvClass.DataBind();
					ddlInvClass.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("HDSZCheckFlow.UI.OrderManage.BaseInfo.PickPurchase",ex.Message);
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
				oPageViewState.SortType=3;           //����ʽ
				oPageViewState.SSort="ApplySheetNo desc ,InventoryCode";        //�����ֶ�

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
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.dgApply_SortCommand);
			this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
			this.imgBtnUp.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnUp_Click);
			this.imgBtnDown.Click += new System.Web.UI.ImageClickEventHandler(this.imgBtnDown_Click);
			this.btnSaveOrder.Click += new System.EventHandler(this.btnSaveOrder_Click);
			this.linkToPage.Click += new System.EventHandler(this.linkToPage_Click);
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

					HyperLink hl = (HyperLink)e.Item.Cells[3].Controls[0];   
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(e.Item.Cells[0].Text));
					if(applyBody!=null)
					{
					}
					applyBody =  null;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderList",ex.Message );
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
			AdvancedSearchGo("v_BaseApplyPurchase","ApplySheetBody_Purchase_pk",out oPageViewState.PCount,10,oPageViewState.PIndex,oPageViewState.SSort,oPageViewState.SortType,SQuery,sFields);
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
			if(!"".Equals(this.txtProduct.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}

				//���� this.txtProduct.Text ,���ŷָ�    ǰ������� ������
				string queryProductStr = "";
				string []testStr = this.txtProduct.Text.Split(new char[] {','});
				foreach(string aaaStr in testStr)
				{
					if(queryProductStr.Length > 0 )
					{
						queryProductStr = queryProductStr + "," + "'" + aaaStr + "'" ;
					}
					else
					{
						queryProductStr =  "'" + aaaStr + "'" ; 
					}
				}

				filter.Append(" InventoryCode in   " +"(" + queryProductStr + ")" );
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

			if(!"".Equals(this.ddlDeptClass.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" ApplyDeptClassCode = " +" '" +  this.ddlDeptClass.SelectedValue + "'" );
			}
			if(!"".Equals(this.ddlDept.SelectedValue))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyDeptCode = " +" '" +  this.ddlDept.SelectedValue + "'" );
			}
			if(!"".Equals(this.ddlInvClass.SelectedValue ))
			{
				//"SELECT invCode FROM Base_inventory WHERE (InvClass_pk = '0001AA00000000001ANM')";
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" InventoryCode in  (  SELECT invCode FROM Base_inventory WHERE (InvClass_pk = '" + this.ddlInvClass.SelectedValue + "') )" );
			}

			//δ�¶���
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" (IsOrder = 0 or IsOrder is null) " );
				
			//����״̬Ϊ�������
			if(filter.Length>0)
			{
				filter.Append(" and ");
			}
			filter.Append(" ApplyProcessCode = 106 " );

		
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

		private  void bindOrderInfo()
		{
			if(!"".Equals(this.txtOrderNo.Text ))
			{
				//�󶨴˶�������Ϣ
				//1.�Ȳ鿴���޴�����Ķ���
				//2.���Ҵ˶�������Ϣ���󶨵�dgorder
				
				//3.��ʶΪ����
				Entiy.OrderSheet orderSheet = Entiy.OrderSheet.FindByOrderNo(this.txtOrderNo.Text.Trim());
				if(orderSheet != null )
				{
					//
					string cmdStr = "select * from v_BaseApplyPurchase where orderno = '" + this.txtOrderNo.Text.Trim() + "'" ;
					DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr) ;
					this.dgOrder.DataSource = ds;
					this.dgOrder.DataBind();

					this.IsEdit.Value = this.txtOrderNo.Text.Trim() ;

				}
				else
				{
					this.lblMessage.Text = "�����������";
				}
			}
		}
	
		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			
			bindGrid();
			bindOrderInfo();
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
			//ȫѡ
			if(this.chbSelectAll.Checked )
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

		private void Button1_Click(object sender, System.EventArgs e)
		{
			//��������

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					//
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(this.dgApply.Items[itm.ItemIndex].Cells[0].Text));
					if(applyBody != null)
					{
						applyBody.IsOrder   = 1 ;
						applyBody.OrderDate = DateTime.Now;
						applyBody.OrderNo   = "" ;
						applyBody.Update();
					}
				}
			}
			this.lblMessage.Text = "���³ɹ�";

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

		private void imgBtnDown_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			this.lblMessage.Text  = "";
			//��ѡ�е���Ŀ��ӵ������DataGrid

			// 1. ���Ѿ����ڣ���������ӡ������¶�����������ӡ� ����  ApplySheetBody_Purchase_pk��

			foreach(DataGridItem itm in this.dgApply.Items )
			{
				CheckBox chkCode=itm.FindControl("CheckBox2") as CheckBox;
				if( chkCode.Checked )
				{
					string purchasepk = this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					string IsOrder    = this.dgApply.Items[itm.ItemIndex].Cells[11].Text ;

					int IsShouldAdd = 1 ; 

					foreach(DataGridItem itme in this.dgOrder.Items )
					{
						if(purchasepk.Equals(this.dgOrder.Items[itme.ItemIndex].Cells[0].Text))
						{
							IsShouldAdd  = 0  ;
						}
					}

					if("1".Equals(IsOrder))
					{
						IsShouldAdd  = 2  ;
					}

					if(IsShouldAdd == 0) 
					{
						this.lblMessage.Text = "�Ѿ����ڣ������ظ���ӣ�" ;
					}
					else if(IsShouldAdd  == 2 )
					{
						this.lblMessage.Text = "�Ѿ��¹������������ظ���" ;
					}
					else
					{
						//���
						DataTable dt = new DataTable() ; 

						if(this.dgOrder.Items.Count >0 )
						{
							dt = Bussiness.OrderManageBLL.MakeTableFromDataGrid(this.dgOrder );
						}
						else
						{
							dt = Bussiness.OrderManageBLL.GetNormalTable();
						}

						DataRow dr = dt.NewRow(); 
						dr["ApplySheetBody_Purchase_pk"] = this.dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
						dr["ApplySheetHead_Pk"] = this.dgApply.Items[itm.ItemIndex].Cells[15].Text ; 

						HyperLink hl = (HyperLink)this.dgApply.Items[itm.ItemIndex].Cells[2].Controls[0];   
						dr["ApplySheetNo"] = hl.Text  ; 

						dr["DeptName"] = this.dgApply.Items[itm.ItemIndex].Cells[3].Text ; 
						dr["ApplyTypeName"] = this.dgApply.Items[itm.ItemIndex].Cells[4].Text ; 
						dr["ApplyDate"] = this.dgApply.Items[itm.ItemIndex].Cells[5].Text ; 
						dr["InventoryCode"] = this.dgApply.Items[itm.ItemIndex].Cells[6].Text ; 
						dr["invName"] = this.dgApply.Items[itm.ItemIndex].Cells[7].Text ; 
						dr["Number"] = this.dgApply.Items[itm.ItemIndex].Cells[8].Text ; 
						dr["RMBPrice"] = this.dgApply.Items[itm.ItemIndex].Cells[9].Text ; 
						dr["money"] = this.dgApply.Items[itm.ItemIndex].Cells[10].Text ; 
						
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()))
						{
//							dr["IsOrder"] = 0 ; 
						}
						else
						{
							dr["IsOrder"] = int.Parse(this.dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) ; 
						}

						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()))
						{
							//dr["orderDate"] = "" ; 
						}
						else
						{
							dr["orderDate"] = DateTime.Parse(this.dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()) ; 
						}

						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()))
						{
//							dr["OrderNo"] = "" ; 
						}
						else
						{
							dr["OrderNo"] = this.dgApply.Items[itm.ItemIndex].Cells[13].Text ; 
						}
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()))
						{
//							dr["IsGiveUp"] = 0 ; 
						}
						else
						{
							dr["IsGiveUp"] =int.Parse( this.dgApply.Items[itm.ItemIndex].Cells[14].Text) ; 
						}
						if("".Equals(this.dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()) || "&nbsp;".Equals(this.dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()))
						{
						}
						else
						{
							dr["memo"] = this.dgApply.Items[itm.ItemIndex].Cells[16].Text ; 
						}
					
						dt.Rows.Add(dr);

						this.dgOrder.DataSource = dt ;
						this.dgOrder.DataBind();

						
					}
				}
			}
		}

		private void imgBtnUp_Click(object sender, System.Web.UI.ImageClickEventArgs e)
		{
			//�Ӷ�����¼datagrid���Ƴ�ѡ�еļ�¼

			DataTable dt = new DataTable() ; 

			if(this.dgOrder.Items.Count >0 )
			{
				dt = Bussiness.OrderManageBLL.MakeTableFromDataGrid(this.dgOrder );
			}
			else
			{
				return ; 
			}

			foreach(DataGridItem itm in this.dgOrder.Items )
			{
				CheckBox chkCode=itm.FindControl("Checkbox1") as CheckBox;
				if( chkCode.Checked )
				{
					string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 

					dt.AcceptChanges(); 
					foreach(DataRow dr in dt.Rows )
					{
						if(dr["ApplySheetBody_Purchase_pk"].ToString().Equals(PurchasePk))
						{
							dr.Delete();
							
						}
					}
				}
			}
			this.dgOrder.DataSource = dt;
			this.dgOrder.DataBind();
		}

		private void btnSaveOrder_Click(object sender, System.EventArgs e)
		{
			//�ж������������޸�
			//1 �������з���
			//2 �޸ļ�¼ԭ�ж����ţ���ԭ����������գ���ʶ������ѡ��grid������� 
			if(this.IsEdit.Value  != "0" )
			{
				#region �޸�
				this.btnSaveOrder.Enabled = false; 

				this.lblMessage.Text = "";
			
				//�ϳɺ�
				string OrderNo  = this.IsEdit.Value ; 
				DateTime dt = DateTime.Now;
				string perCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); 

				Entiy.OrderSheet orderSheet =   HDSZCheckFlow.Entiy.OrderSheet.FindByOrderNo(OrderNo) ; 
				
				orderSheet.OrderNo = OrderNo;
				orderSheet.OrderDate = dt ;
				orderSheet.IsKeep = 0 ;
				orderSheet.MakerCode = perCode ; 

				orderSheet.Save();

				Bussiness.OrderManageBLL.UpdatePurchase(OrderNo);

				foreach(DataGridItem itm in this.dgOrder.Items )
				{
					string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 
					//��� PurchasePk �� �� OrderNo 
					//Entity ʵ���� 
					Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(PurchasePk));
					if(applyBody != null && applyBody.IsOrder != 1 )
					{
						//����Purchase ��
						applyBody.IsOrder   = 1 ; 
						applyBody.OrderDate = dt ;
						applyBody.OrderNo   = OrderNo ;
						applyBody.Update();

						this.lblMessage.Text = "���ɶ����ɹ���  " + OrderNo ;
					}
					else
					{
						this.lblMessage .Text = "�Ѿ��¹������������ٴ��¶�����";
					}
				}
				#endregion 
			}
			else
			{
				#region ����
				this.btnSaveOrder.Enabled = false; 

				this.lblMessage.Text = "";
				//������������Ӽ�¼ �� 1.���ɲ��ظ��Ķ�����  dd2009040200001 
				//2. ��¼�����ţ�������Ʒ���� ��

				#region ���ɶ�����
				//����ǰ׺
				string perFix= System.Configuration.ConfigurationSettings.AppSettings["dingdan"];
				if("".Equals(perFix))
				{
					this.lblMessage.Text  = "û���ҵ�ϵͳǰ׺����";
					return ;
				}
				//ȡϵͳ��ǰ����
				string date =   DateTime.Today.ToString("yyyyMMdd");
				//ȡ��ǰ���ݿ������ˮ��
				string OrderNo = perFix + date ; 
				string  MaxNum1=Bussiness.ApplySheetHeadBLL.GetMaxOrderNo(OrderNo);
				int MaxNum=0;
				if(!"".Equals(MaxNum1))
				{
					MaxNum=int.Parse(MaxNum1.Trim());
				}
				MaxNum += 1;
				string applyMaxNum=MaxNum.ToString();

				for(int iLength=MaxNum.ToString().Length ;iLength<5;iLength++)
				{
					applyMaxNum="0"+applyMaxNum;
				}
				#endregion 

				//�ϳɺ�
				OrderNo  += applyMaxNum ; 
				DateTime dt = DateTime.Now;
				string perCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name)); 

				Entiy.OrderSheet orderSheet =   new HDSZCheckFlow.Entiy.OrderSheet();
				orderSheet = new HDSZCheckFlow.Entiy.OrderSheet();
				orderSheet.OrderNo = OrderNo;
				orderSheet.OrderDate = dt ;
				orderSheet.IsKeep = 0 ;
				orderSheet.MakerCode = perCode ; 
				orderSheet.Create();

				foreach(DataGridItem itm in this.dgOrder.Items )
				{
					try
					{
						//�����ɾ�ķ�����

						string PurchasePk = this.dgOrder.Items[itm.ItemIndex].Cells[0].Text ; 
						//��� PurchasePk �� �� OrderNo 
						//Entity ʵ���� 
						Entiy.ApplySheetBodyPurchase applyBody = Entiy.ApplySheetBodyPurchase.Find(int.Parse(PurchasePk));
						if(applyBody != null && applyBody.IsOrder != 1 )
						{
							//����Purchase ��
							applyBody.IsOrder   = 1 ; 
							applyBody.OrderDate = dt ;
							applyBody.OrderNo   = OrderNo ;
							applyBody.Update();

							this.lblMessage.Text = "���ɶ����ɹ���  " + OrderNo ;
						}
						else
						{
							this.lblMessage .Text = "�Ѿ��¹������������ٴ��¶�����";
						}

						//�޴��� ���ύ
					}
					catch(Exception ex)
					{
						Common.Log.Logger.Log("UI.OrderManage.BaseInfo.btnSaveOrder_Click",ex.Message );
						this.lblMessage.Text = "���ɶ������� �� " ;
					}
				}
				#endregion  
			}
			//���°�
			bindGrid();
			
		}




	}
}
