using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Text;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace HDSZCheckFlow.UI.BaseData.Asset
{
	/// <summary>
	/// Asset_Budget_UseDetails ��ժҪ˵����
	/// ��ӪԤ��ʹ����ϸҳ(�Ѿ��������ĵ���)
	/// 2011-10-25 
	/// liyang
	/// </summary>
	public class Asset_Budget_UseDetails_J : System.Web.UI.Page
	{
		#region 

		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.Label lblBudgetDept;
		protected System.Web.UI.WebControls.Label lblCheckedMoney;
		protected System.Web.UI.WebControls.DataGrid DataGrid1;
		protected System.Web.UI.WebControls.Label lblReadypay;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblItemName;
		protected System.Web.UI.WebControls.Label lblYear;
		protected System.Web.UI.WebControls.Label lblBudgetMoney;
		protected System.Web.UI.WebControls.Label lblMessage;
		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
			if(!Page.IsPostBack)
			{
				//				//��ȡ����
				//				string ApplyHeadPk =  getValueByParmes("applyHeadPk");
				//
				//				if(!"".Equals(ApplyHeadPk))
				//				{
				//					BindBaseBudetInfo(int.Parse(ApplyHeadPk));
				//					BindApplyInfo(int.Parse(ApplyHeadPk));
				//				}


				//����Ԥ���Id  ��AssetBudgetPk��

				string AssetBudgetPk =  getValueByParmes("AssetBudgetPk");

				if(!"".Equals(AssetBudgetPk))
				{
					BindBaseBudetInfo(int.Parse(AssetBudgetPk));
					BindApplyInfo(int.Parse(AssetBudgetPk));
				}
			}
		}

		/// <summary>
		/// ��ҳ��ͷ����Ϣ
		/// </summary>
		/// <param name="ApplyHeadPk">����Key</param>
		private  void BindBaseBudetInfo(int AssetBudgetPk)
		{	
			//Ԥ�����Ϣ
			Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.Find(AssetBudgetPk);

			if(AssetBudget !=null )
			{
				Entiy.BaseDept dept =  Entiy.BaseDept.FindByBudgetDeptCode(AssetBudget.DeptCode);

				this.lblYear.Text         = AssetBudget.Iyear.ToString(); 
				this.lblBudgetDept.Text   = dept.DeptName; 
				this.lblItemName.Text     = AssetBudget.ItemName ;
			}
			//��ȡ��ĿԤ����Ϣ
			DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(AssetBudget.Iyear  ,AssetBudget.DeptCode,AssetBudget.ItemName);
			if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
			{
				//Ԥ��
				this.lblBudgetMoney.Text= Decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
				//��̯
				this.lblReadypay.Text = Decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;
				//�Ѿ�ʹ��
				this.lblCheckedMoney.Text = Decimal.Parse(ds.Tables[0].Rows[0]["CheckMoney"].ToString()).ToString("N2") ;
				//Ԥ������
				this.lblOutMoney.Text     = Decimal.Parse(ds.Tables[0].Rows[0]["TotalOutMoney"].ToString()).ToString("N2") ;
				//ʣ����
				this.lblLeft.Text=Decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()).ToString("N2") ;
			}
		}

		#region 
		//		/// <summary>
		//		/// ��ҳ��ͷ����Ϣ
		//		/// </summary>
		//		/// <param name="ApplyHeadPk">����Key</param>
		//		private  void BindBaseBudetInfo(int ApplyHeadPk)
		//		{	
		//
		//			//���ݱ�ͷ
		//			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
		//
		//			//����Ԥ��
		//			Entiy.AssetApplySheetBudget applyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
		//
		//			if(applyHead !=null && applyBudget !=null )
		//			{
		//				//����������ĿԤ��
		//				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
		//
		//				this.lblYear.Text         = applyHead.ApplyDate.Year.ToString();
		//				this.lblBudgetDept.Text   = dept.DeptName; 
		//				this.lblItemName.Text     = applyBudget.ItemName;
		//
		//				if(dept != null )
		//				{
		//					//��ȡ��ĿԤ����Ϣ
		//					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(applyHead.ApplyDate.Year ,dept.BudgetDeptCode,applyBudget.ItemName);
		//					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
		//					{
		//						//Ԥ��
		//						this.lblBudgetMoney.Text= Decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
		//						//��̯
		//						this.lblReadypay.Text = Decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;
		//						
		//						//�Ѿ�ʹ��
		//						this.lblCheckedMoney.Text = Decimal.Parse(ds.Tables[0].Rows[0]["CheckMoney"].ToString()).ToString("N2") ;
		//
		//						//Ԥ������
		//						this.lblOutMoney.Text     = Decimal.Parse(ds.Tables[0].Rows[0]["TotalOutMoney"].ToString()).ToString("N2") ;
		//
		//						//ʣ����
		//						this.lblLeft.Text=Decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()).ToString("N2") ;
		//					}
		//				}
		//
		//			}
		//		}
		//
		//		/// <summary>
		//		/// ��ָ������ݡ����ź�������Ŀ���Ѿ������ĵ����б�
		//		/// </summary>
		//		/// <param name="ApplyHeadPk">����key</param>
		//		private void BindApplyInfo(int ApplyHeadPk)
		//		{
		//			StringBuilder sbFilter=new StringBuilder();
		//			//���ݱ�ͷ
		//			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
		//
		//			//����Ԥ��
		//			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
		//
		//			if(ApplyHead !=null && ApplyBudget !=null)
		//			{	
		//	
		//				//ƴ�Ӳ�ѯ����
		//				sbFilter.Append(" where year(applydate) = '" + ApplyHead.ApplyDate.Year + "'");//���
		//				sbFilter.Append(" and IsSubmit = 1 ");                                          //����״̬
		//				sbFilter.Append(" and ApplyDeptCode= '"+ApplyHead.ApplyDeptCode+"'");		   //����
		//				sbFilter.Append(" and ItemName= '"+ApplyBudget.ItemName+"'");				   //������Ŀ
		//
		//				//���ò�ѯ����
		//				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_AssetApplyList",sbFilter.ToString());
		//
		//				//������
		//				this.dgApply.DataSource = ds;
		//				this.dgApply.DataBind();
		//
		//			}
		//			else
		//			{
		//				this.dgApply.DataSource= null;
		//				this.dgApply.DataBind();
		//			}
		//		}

		#endregion 

		/// <summary>
		/// ��ָ������ݡ����ź�������Ŀ���Ѿ������ĵ����б�
		/// </summary>
		/// <param name="ApplyHeadPk">����key</param>
		private void BindApplyInfo(int AssetBudgetPk)
		{
			StringBuilder sbFilter=new StringBuilder();

			Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.Find(AssetBudgetPk);

			if(AssetBudget !=null)
			{	
				//ƴ�Ӳ�ѯ����
				sbFilter.Append(" where year(applydate) = '" + AssetBudget.Iyear + "'");//���
				sbFilter.Append(" and IsSubmit = 1 ");                                         //�Ѿ��ύ�Ķ���
				sbFilter.Append(" and Budget_deptCode= '"+AssetBudget.DeptCode+"'");		   //����
				sbFilter.Append(" and ItemName= '"+AssetBudget.ItemName+"'");				   //������Ŀ

				//���ò�ѯ����
				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_AssetApplyList",sbFilter.ToString());

				//������
				this.dgApply.DataSource = ds;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply.DataSource= null;
				this.dgApply.DataBind();
			}
		}




		/// <summary>
		/// ��ȡ����
		/// </summary>
		/// <param name="Parmes"></param>
		/// <returns></returns>
		private string getValueByParmes(string Parmes)
		{
			if(Request.QueryString[Parmes] != null && Request.QueryString[Parmes].ToString() !="")
			{
				return Request.QueryString[Parmes].ToString();
			}
			else
			{
				return "";
			}
		}


		

		private static  Color color;
		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			try
			{
				if(e.CommandName.Equals("look")) //���������ť
				{
					DataSet ds = Bussiness.RealMoneyAlterSheetBLL.GetRealMoneyAlterByApplyHeadPk(int.Parse(e.Item.Cells[0].Text));
					this.DataGrid1.DataSource= ds; 
					this.DataGrid1.DataBind();

					for(int i=0;i<this.dgApply.Items.Count ;i++)
					{
						if(this.dgApply.Items[i].BackColor==Color.Yellow)
						{
							this.dgApply.Items[i].BackColor= color;
						}
					}
					color=e.Item.BackColor;
					e.Item.BackColor=Color.Yellow;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Asset_Budget_UseDetails.dgApply_ItemCommand",ex.Message );
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
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		
	}
}
