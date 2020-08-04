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
	/// Asset_Budget_UseDetails 的摘要说明。
	/// 新营预算使用明细页(已经审批过的单据)
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
				//				//获取参数
				//				string ApplyHeadPk =  getValueByParmes("applyHeadPk");
				//
				//				if(!"".Equals(ApplyHeadPk))
				//				{
				//					BindBaseBudetInfo(int.Parse(ApplyHeadPk));
				//					BindApplyInfo(int.Parse(ApplyHeadPk));
				//				}


				//传入预算表Id  （AssetBudgetPk）

				string AssetBudgetPk =  getValueByParmes("AssetBudgetPk");

				if(!"".Equals(AssetBudgetPk))
				{
					BindBaseBudetInfo(int.Parse(AssetBudgetPk));
					BindApplyInfo(int.Parse(AssetBudgetPk));
				}
			}
		}

		/// <summary>
		/// 绑定页面头部信息
		/// </summary>
		/// <param name="ApplyHeadPk">单据Key</param>
		private  void BindBaseBudetInfo(int AssetBudgetPk)
		{	
			//预算表信息
			Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.Find(AssetBudgetPk);

			if(AssetBudget !=null )
			{
				Entiy.BaseDept dept =  Entiy.BaseDept.FindByBudgetDeptCode(AssetBudget.DeptCode);

				this.lblYear.Text         = AssetBudget.Iyear.ToString(); 
				this.lblBudgetDept.Text   = dept.DeptName; 
				this.lblItemName.Text     = AssetBudget.ItemName ;
			}
			//获取项目预算信息
			DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(AssetBudget.Iyear  ,AssetBudget.DeptCode,AssetBudget.ItemName);
			if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
			{
				//预算
				this.lblBudgetMoney.Text= Decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
				//待摊
				this.lblReadypay.Text = Decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;
				//已经使用
				this.lblCheckedMoney.Text = Decimal.Parse(ds.Tables[0].Rows[0]["CheckMoney"].ToString()).ToString("N2") ;
				//预算外金额
				this.lblOutMoney.Text     = Decimal.Parse(ds.Tables[0].Rows[0]["TotalOutMoney"].ToString()).ToString("N2") ;
				//剩余金额
				this.lblLeft.Text=Decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()).ToString("N2") ;
			}
		}

		#region 
		//		/// <summary>
		//		/// 绑定页面头部信息
		//		/// </summary>
		//		/// <param name="ApplyHeadPk">单据Key</param>
		//		private  void BindBaseBudetInfo(int ApplyHeadPk)
		//		{	
		//
		//			//单据表头
		//			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
		//
		//			//单据预算
		//			Entiy.AssetApplySheetBudget applyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
		//
		//			if(applyHead !=null && applyBudget !=null )
		//			{
		//				//单据所用项目预算
		//				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
		//
		//				this.lblYear.Text         = applyHead.ApplyDate.Year.ToString();
		//				this.lblBudgetDept.Text   = dept.DeptName; 
		//				this.lblItemName.Text     = applyBudget.ItemName;
		//
		//				if(dept != null )
		//				{
		//					//获取项目预算信息
		//					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(applyHead.ApplyDate.Year ,dept.BudgetDeptCode,applyBudget.ItemName);
		//					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
		//					{
		//						//预算
		//						this.lblBudgetMoney.Text= Decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
		//						//待摊
		//						this.lblReadypay.Text = Decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;
		//						
		//						//已经使用
		//						this.lblCheckedMoney.Text = Decimal.Parse(ds.Tables[0].Rows[0]["CheckMoney"].ToString()).ToString("N2") ;
		//
		//						//预算外金额
		//						this.lblOutMoney.Text     = Decimal.Parse(ds.Tables[0].Rows[0]["TotalOutMoney"].ToString()).ToString("N2") ;
		//
		//						//剩余金额
		//						this.lblLeft.Text=Decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()).ToString("N2") ;
		//					}
		//				}
		//
		//			}
		//		}
		//
		//		/// <summary>
		//		/// 在指定的年份、部门和申请项目下已经审批的单据列表
		//		/// </summary>
		//		/// <param name="ApplyHeadPk">单据key</param>
		//		private void BindApplyInfo(int ApplyHeadPk)
		//		{
		//			StringBuilder sbFilter=new StringBuilder();
		//			//单据表头
		//			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
		//
		//			//单据预算
		//			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
		//
		//			if(ApplyHead !=null && ApplyBudget !=null)
		//			{	
		//	
		//				//拼接查询条件
		//				sbFilter.Append(" where year(applydate) = '" + ApplyHead.ApplyDate.Year + "'");//年份
		//				sbFilter.Append(" and IsSubmit = 1 ");                                          //审批状态
		//				sbFilter.Append(" and ApplyDeptCode= '"+ApplyHead.ApplyDeptCode+"'");		   //部门
		//				sbFilter.Append(" and ItemName= '"+ApplyBudget.ItemName+"'");				   //申请项目
		//
		//				//调用查询方法
		//				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_AssetApplyList",sbFilter.ToString());
		//
		//				//绑定数据
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
		/// 在指定的年份、部门和申请项目下已经审批的单据列表
		/// </summary>
		/// <param name="ApplyHeadPk">单据key</param>
		private void BindApplyInfo(int AssetBudgetPk)
		{
			StringBuilder sbFilter=new StringBuilder();

			Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.Find(AssetBudgetPk);

			if(AssetBudget !=null)
			{	
				//拼接查询条件
				sbFilter.Append(" where year(applydate) = '" + AssetBudget.Iyear + "'");//年份
				sbFilter.Append(" and IsSubmit = 1 ");                                         //已经提交的订单
				sbFilter.Append(" and Budget_deptCode= '"+AssetBudget.DeptCode+"'");		   //部门
				sbFilter.Append(" and ItemName= '"+AssetBudget.ItemName+"'");				   //申请项目

				//调用查询方法
				DataSet ds = Bussiness.ComQuaryBLL.GetDataSetByViewAndQuery("v_AssetApplyList",sbFilter.ToString());

				//绑定数据
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
		/// 获取参数
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
				if(e.CommandName.Equals("look")) //点击审批按钮
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




		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		
	}
}
