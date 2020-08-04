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
	/// MyAuditing ��ժҪ˵����
	/// </summary>
	public class MyAuditing : System.Web.UI.Page
	{		
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
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid3.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid3_ItemCommand);
			this.DataGrid3.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid3_PageIndexChanged);
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		protected System.Web.UI.WebControls.DataGrid DataGrid2;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Button btnQuery;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox txtApplyNo;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.DataGrid DataGrid3;

		protected System.Web.UI.WebControls.DataGrid DataGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//�����ڵ�½ID�����д�������,union ����ת��Ȩ�޵Ĵ�������
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				string filter = "" ;
				if(Request.Cookies["SearchCondition"]!=null )
				{
					filter = GetQuerySqlByCookie();
				}
				else
				{
					filter = GetQuerySqlString();
				}
				
				BindMyAuditing(int.Parse(User.Identity.Name),filter);

				//�۸�þ�

				filter = GetQuerySqlStringForFinallyCheck();

				BindMyAuditingForFinallyCheck(int.Parse(User.Identity.Name),filter);

		
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
				//DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo();  //��Ŀ ?

				//����״̬
				DataTable dtProssType=Bussiness.ApplyProcessTypeBll.GetProssType();
				if(dtProssType!=null && dtProssType.Rows.Count >0 )
				{
					this.ddlApplyType.DataSource=dtProssType;
					this.ddlApplyType.DataValueField=dtProssType.Columns[0].ToString();
					this.ddlApplyType.DataTextField=dtProssType.Columns[1].ToString();
					this.ddlApplyType.DataBind();
					this.ddlApplyType.Items.Insert(0,"");
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}


		#endregion 


		//���ݵ�½�û�ID�ţ���ѯ�����������
		private void BindMyAuditing(int UserID,string filter)
		{
			//1.�Լ��Ĵ��������Լ�����ת��Ȩ�޵Ĵ�������.

			//���̱� �ύ״̬Ϊ1 ������Ϊ 0 ����˾�ڽ���Ϊ 0 �ı�

			//���ݱ��зֲ�����(�鿴�������)��������, ������ɫ

			//ͨ����ɫ����Ա���ձ����������Լ���������

			string myCode=Bussiness.UserInfoBLL.GetUserName(UserID);
			DataSet ds=Bussiness.ApplySheetHeadBLL.GetMyAuditing(myCode,filter);
			if(ds!=null && ds.Tables[0].Rows.Count >0)
			{
				this.lblMessage.Text="";
				this.DataGrid1.DataSource=ds;
				this.DataGrid1.DataBind();
			}
			else
			{
				this.DataGrid1.DataSource=null;
				this.DataGrid1.DataBind();
				this.lblMessage.ForeColor=Color.Red;
				this.lblMessage.Text="Ŀǰû��������������";
			}

		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Apply")) //���������ť
			{
				//�����ж� 

				//System.
				string AssetTypeCode =  System.Configuration.ConfigurationSettings.AppSettings["Asset"];

				if(AssetTypeCode.Equals(e.Item.Cells[1].Text.Trim()))
				{
					//��Ӫ����ת����
					Response.Redirect("../../Asset/CheckFlow/AuditingAssetForOneApply.aspx?applyHeadPk=" + e.Item.Cells[0].Text + "&disCode=" + e.Item.Cells[10].Text + "");
				}
				else
				{
					//��������ת����
					Response.Redirect("AuditingForOneApply.aspx?applyHeadPk=" + e.Item.Cells[0].Text + "&disCode=" + e.Item.Cells[10].Text + "");
				}
			}
		}

		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid1.CurrentPageIndex = e.NewPageIndex;
			string filter = GetQuerySqlString();
			BindMyAuditing(int.Parse(User.Identity.Name),filter);
		
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

		private void btnQuery_Click(object sender, System.EventArgs e)
		{
			//��¼Session ����Cookie �û�ѡ��Ĳ�ѯ����
			HttpCookie cookie = new HttpCookie("SearchCondition");   
			#region 
			if(!"".Equals(this.ddlType.SelectedValue))
			{
				cookie.Values.Add("ApplyTypeCode",this.ddlType.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("ApplyTypeCode","");   
			}
			if(!"".Equals(this.txtDateFrom.Text))
			{
				cookie.Values.Add("ApplyDateFrom",this.txtDateFrom.Text);   
			}
			else
			{
				cookie.Values.Add("ApplyDateFrom","");   
			}
			if(!"".Equals(this.txtDateTo.Text))
			{
				cookie.Values.Add("ApplyDateTo",this.txtDateTo.Text);   
			}
			else
			{
				cookie.Values.Add("ApplyDateTo","");   
			}
			if(!"".Equals(this.ddlDeptClass.SelectedValue ))
			{
				cookie.Values.Add("ApplyDeptClassCode",this.ddlDeptClass.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("ApplyDeptClassCode","");   
			}
			if(!"".Equals(this.ddlDept .SelectedValue ))
			{
				cookie.Values.Add("ApplyDeptCode",this.ddlDept.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("ApplyDeptCode","");   
			}
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				cookie.Values.Add("applyProcessCode",this.ddlApplyType.SelectedValue);   
			}
			else
			{
				cookie.Values.Add("applyProcessCode","");   
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				cookie.Values.Add("applySheetNo",this.txtApplyNo.Text);   
			}
			else
			{
				cookie.Values.Add("applySheetNo","");   
			}
			#endregion 
			Response.AppendCookie(cookie);
			

			this.DataGrid1.CurrentPageIndex = 0 ;
			string filter = GetQuerySqlString();
			BindMyAuditing(int.Parse(User.Identity.Name),filter);


			//�۸�þ�

			queryMyFinallyCheckApply() ;
		
		}


		//��ѯ�۸�þ�����
		private void queryMyFinallyCheckApply()
		{


			this.DataGrid3.CurrentPageIndex = 0 ;
			string filter = GetQuerySqlStringForFinallyCheck();
			BindMyAuditingForFinallyCheck(int.Parse(User.Identity.Name),filter);

		}

		private string GetQuerySqlStringForFinallyCheck()
		{

			#region  �����ѯ����

			StringBuilder filter=new StringBuilder();


//			if(!"".Equals(this.ddlType.SelectedValue))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" ApplyTypeCode = " +" '" + this.ddlType.SelectedValue + "'" );
//			}
//			if(!"".Equals(this.txtDateFrom.Text))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append("	ApplyDate >= " +" '" + this.txtDateFrom.Text+ "'" );
//			}
//			if(!"".Equals(this.txtDateTo.Text))
//			{
//				if(filter.Length>0)
//				{
//					filter.Append(" and ");
//				}
//				filter.Append(" ApplyDate <= " +" '" +  this.txtDateTo.Text+ "'" );
//			}
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
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyProcessCode= " +" '" + this.ddlApplyType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			// �������� �� �ύ״̬Ϊ 1 ��.��ʱ�̶�Ϊ ApplyProcessCode �� 101  �� 201 ���Ժ�����

	
		

			string returnValue=filter.ToString();


			if(returnValue.Length > 0 )
			{
				returnValue = " where " + returnValue;
			}

			return returnValue;
			#endregion  
		}

		//���ݵ�½�û�ID�ţ���ѯ�����������
		private void BindMyAuditingForFinallyCheck(int UserID,string filter)
		{
			//1.�Լ��Ĵ��������Լ�����ת��Ȩ�޵Ĵ�������.

			//���̱� �ύ״̬Ϊ1 ������Ϊ 0 ����˾�ڽ���Ϊ 0 �ı�

			//���ݱ��зֲ�����(�鿴�������)��������, ������ɫ

			//ͨ����ɫ����Ա���ձ����������Լ���������

			string myCode=Bussiness.UserInfoBLL.GetUserName(UserID);
			DataSet ds=Bussiness.AssetCheckFlowBLL.GetMyAuditingForFinallyCheck(myCode,filter);
			if(ds!=null && ds.Tables[0].Rows.Count >0)
			{
				this.Panel1.Visible = true; 

				this.lblMessage.Text="";
				this.DataGrid3.DataSource=ds;
				this.DataGrid3.DataBind();
			}
			else
			{
				this.Panel1.Visible = false;

				this.DataGrid3.DataSource=null;
				this.DataGrid3.DataBind();
				this.lblMessage.ForeColor=Color.Red;
				
			}

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
			if(!"".Equals(this.ddlApplyType.SelectedValue ))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applyProcessCode= " +" '" + this.ddlApplyType.SelectedValue + "'" );
			}
			if(!"".Equals(this.txtApplyNo.Text))
			{
				if(filter.Length>0)
				{
					filter.Append(" and ");
				}
				filter.Append(" applySheetNo like  " +" '%" + this.txtApplyNo.Text + "%'" );
			}

			// �������� �� �ύ״̬Ϊ 1 ��.��ʱ�̶�Ϊ ApplyProcessCode �� 101  �� 201 ���Ժ�����

	
		

			string returnValue=filter.ToString();


			if(returnValue.Length > 0 )
			{
				returnValue = " where " + returnValue;
			}

			return returnValue;
			#endregion  
		}

		private string GetQuerySqlByCookie()
		{
			if(Request.Cookies["SearchCondition"]!=null )
			{
				#region  �����ѯ����,����Cookie�У�������Ӧ��ֵ��

				StringBuilder filter=new StringBuilder();
				if(!"".Equals(Request.Cookies["SearchCondition"]["ApplyTypeCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyTypeCode = " +" '" + Request.Cookies["SearchCondition"]["ApplyTypeCode"].ToString()  + "'" );
					this.ddlType.SelectedValue = Request.Cookies["SearchCondition"]["ApplyTypeCode"].ToString() ; 
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["ApplyDateFrom"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append("	ApplyDate >= " +" '" + Request.Cookies["SearchCondition"]["ApplyDateFrom"].ToString() + "'" );
					this.txtDateFrom.Text = Request.Cookies["SearchCondition"]["ApplyDateFrom"].ToString() ;
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["ApplyDateTo"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyDate <= " +" '" + Request.Cookies["SearchCondition"]["ApplyDateTo"].ToString() + "'" );
					this.txtDateTo.Text = Request.Cookies["SearchCondition"]["ApplyDateTo"].ToString() ;
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["ApplyDeptClassCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyDeptClassCode = " +" '" + Request.Cookies["SearchCondition"]["ApplyDeptClassCode"].ToString() + "'" );
					this.ddlDeptClass.SelectedValue =  Request.Cookies["SearchCondition"]["ApplyDeptClassCode"].ToString() ; 
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["ApplyDeptCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" ApplyDeptCode = " +" '" + Request.Cookies["SearchCondition"]["ApplyDeptCode"].ToString() + "'" );
					this.ddlDept.SelectedValue = Request.Cookies["SearchCondition"]["ApplyDeptCode"].ToString();
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["applyProcessCode"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" applyProcessCode= " +" '" + Request.Cookies["SearchCondition"]["applyProcessCode"].ToString() + "'" );
					this.ddlApplyType.SelectedValue = Request.Cookies["SearchCondition"]["applyProcessCode"].ToString() ;
				}
				if(!"".Equals(Request.Cookies["SearchCondition"]["applySheetNo"].ToString()))
				{
					if(filter.Length>0)
					{
						filter.Append(" and ");
					}
					filter.Append(" applySheetNo like  " +" '%" + Request.Cookies["SearchCondition"]["applySheetNo"].ToString() + "%'" );
					this.txtApplyNo.Text = Request.Cookies["SearchCondition"]["applySheetNo"].ToString();
				}

				// �������� �� �ύ״̬Ϊ 1 ��.��ʱ�̶�Ϊ ApplyProcessCode �� 101  �� 201 ���Ժ�����

				string returnValue=filter.ToString();
				if(returnValue.Length > 0 )
				{
					returnValue = " where " + returnValue;
				}
				return returnValue;
				#endregion  
			}
			else
			{
				return "";
			}
		}

		private void DataGrid3_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			if(e.CommandName.Equals("Apply")) //���������ť
			{
				//��ת����
				Response.Redirect("../../Asset/PriceCheck/AuditingFinallyCheckForOneApply.aspx?FinallyCheckId=" + e.Item.Cells[0].Text + "&disCode=" + e.Item.Cells[6].Text + "");
				
			}
		}

		private void DataGrid3_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.DataGrid3.CurrentPageIndex = e.NewPageIndex;
			string filter = GetQuerySqlStringForFinallyCheck();
			BindMyAuditing(int.Parse(User.Identity.Name),filter);
		
		}


	}
}
