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
using System.Text.RegularExpressions;

namespace HDSZCheckFlow.UI.Asset.CheckFlow
{
	/// <summary>
	/// AddAssetApply 的摘要说明。
	/// </summary>
	public class GetBackAssetApply : System.Web.UI.Page
	{
		#region

		protected System.Web.UI.WebControls.Panel pAddItem;
		protected System.Web.UI.WebControls.DropDownList ddlSubjectCode;
		protected System.Web.UI.WebControls.TextBox tbInvName;
		protected System.Web.UI.WebControls.TextBox tbInvType;
		protected System.Web.UI.WebControls.TextBox tbOriginalcurrPrice;
		protected System.Web.UI.WebControls.DropDownList ddlUnit;
		protected System.Web.UI.WebControls.DropDownList ddlcurrTypeCode;
		protected System.Web.UI.WebControls.TextBox tbNumber;
		protected System.Web.UI.WebControls.DataGrid dgApply;
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
		protected System.Web.UI.WebControls.DataGrid dgApplyHead;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyHead;
		protected System.Web.UI.WebControls.Button btnGetBack;
		protected System.Web.UI.WebControls.Button btnKeep;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				this.btnGetBack.Enabled = false; 
				this.btnKeep.Enabled = false;

				BindGetBackAssetApply() ; 
			}
		}

		private void BindGetBackAssetApply()
		{
			string AssetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //新营
			
			string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
			if( !"".Equals(personCode))
			{
				string cmdStr="SELECT v_AssetApplyList.*  FROM v_AssetApplyList INNER JOIN ApplyProcessType ON v_AssetApplyList.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
					" WHERE (v_AssetApplyList.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
					" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
					" WHERE personCode = '" + personCode + "'))) AND  v_AssetApplyList.ApplyTypeCode = " + AssetCode + " and " +
					"(((v_AssetApplyList.IsKeeping <> 1 OR v_AssetApplyList.IsKeeping IS NULL)) AND (ApplyProcessType.IsDisallow = 1) or (ApplyProcessType.IsSubmitAgain=1 and ApplyProcessType.IsSubmit= 0 and  v_AssetApplyList.IsKeeping <> 1 OR v_AssetApplyList.IsKeeping IS NULL ) or (ApplyProcessType.IsSubmit=1 and ApplyProcessType.IsCheck=0 and ApplyProcessType.IsSubmitAgain=0) )" +
					" ORDER BY v_AssetApplyList.ApplyDate DESC";

				DataSet ds= Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
				if(ds!= null && ds.Tables.Count > 0)
				{
					this.dgApplyHead.CurrentPageIndex = 0 ;

					this.dgApplyHead.DataSource = ds;
					this.dgApplyHead.DataBind();
				}
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
			this.btnGetBack.Click += new System.EventHandler(this.btnGetBack_Click);
			this.btnKeep.Click += new System.EventHandler(this.btnKeep_Click);
			this.dgApplyHead.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApplyHead_ItemCommand);
			this.dgApplyHead.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.dgApplyHead_PageIndexChanged);
			this.dgApplyHead.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApplyHead_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion




		//更新申请单表头进程状态为提交
		private void updatePross(int ApplySheetHeadPk)
		{
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplySheetHeadPk);
			if(applyHead!=null)
			{
				applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.SubmitPross;
				applyHead.Update();
			}
		}

		private void BindBudgetInfo (int ApplyHeadKey)
		{
			#region 显示预算信息

			this.PBudgetInfo.Visible = true;
			// 更改为按季度为判断标准
			//1.根据申请月份，得出当前所在季度
			//2.得到季度金额合计
			//3.判断标准添加考虑待摊金额

			this.lblSheetMoney .Visible = true;

			DataSet ds = Bussiness.AssetBudgetBll.SelectAssetBudgetByApplyHeadKey(ApplyHeadKey);

			if(ds != null)
			{
				this.lblBudget.Text = ds.Tables[0].Rows[0]["BudgetMoney"].ToString();
				this.lblSumCheck.Text=ds.Tables[0].Rows[0]["CheckMoney"].ToString();
				this.lblready.Text  = ds.Tables[0].Rows[0]["ReadyPay"].ToString();
				this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalOutMoney"].ToString();
				this.lblSheetMoney.Text = ds.Tables[0].Rows[0]["ApplyMoney"].ToString();
				this.lblLeft.Text=ds.Tables[0].Rows[0]["LeftMoney"].ToString();
			}		
			#endregion 
		}

	
		private void BindAssetBody(int applyHeadPk)
		{
			#region 绑定表体信息

			this.pAddItem.Visible =true;
			this.dgApply.Visible = true;


			string cmdStr = "select * from dbo.Asset_ApplySheet_Body where applySheetHead_pk = " +  applyHeadPk.ToString()  + " order by id desc "  ; 

			DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			if(ds!=null && ds.Tables.Count >0 )
			{
				this.dgApply.DataSource = ds ;
				this.dgApply.DataBind();
			}
			else
			{
				this.dgApply.DataSource = null;
				this.dgApply.DataBind();
			}
			#endregion 
		}






		private void SetButtonsEnable(int ApplyHeadPk)
		{
			// 1 全不可用
			// 2 取回可用
			// 3 封存可用
			int i=Bussiness.ApplySheetHeadForAssetBLL.SetButtonEnableForAssetGetBack(ApplyHeadPk);
			switch(i)
			{
				case 1:
					this.btnGetBack .Enabled=false;
					this.btnKeep.Enabled=false;
					break;
				case 2:
					this.btnGetBack.Enabled=true;
					this.btnKeep.Enabled=false;
					break;
				case 3:
					this.btnGetBack .Enabled=false;
					this.btnKeep.Enabled=true;
					break;
			}
		}


		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			//取消按钮
			this.ddlSubjectCode.SelectedIndex = -1 ;
			this.ddlUnit.SelectedIndex = -1 ;
			this.ddlcurrTypeCode.SelectedIndex = -1 ;

			this.tbInvName.Text = "";
			this.tbNumber.Text = "";
			this.tbInvType.Text = "";
			this.tbOriginalcurrPrice.Text = "";
		}

		private static  Color color;

		private void dgApplyHead_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			//点击 选择 / 删除

			if(e.CommandName.Equals("delete")) 
			{
				#region 删除

				//表头Id
				int ApplyHeadKey = int.Parse(e.Item.Cells[0].Text) ;
				
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
				if(ApplyHead == null )
				{
					this.lbMsg.Text = "系统错误，找不到单据！";
					return ;
				}

				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
				{
					this.lbMsg.Text = "此单不是新建状态，不能删除！";
					return ;
				}

				//删除表单
				ApplyHead.Delete();

				//重新帮定表头
				BindGetBackAssetApply() ; 

				//剩余金额 && 表体 隐藏

				this.PBudgetInfo.Visible = false;

				this.dgApply.DataSource = null;
				this.dgApply.DataBind();

				this.pAddItem.Visible = false;

				#endregion 
			}
			if(e.CommandName.Equals("select"))
			{
				#region 选择

				#region 行变色
				for(int i=0;i<this.dgApplyHead.Items.Count ;i++)
				{
					if(this.dgApplyHead.Items[i].BackColor== Color.Yellow)
					{
						this.dgApplyHead.Items[i].BackColor= color;
					}
				}
				color=e.Item.BackColor;
				e.Item.BackColor=Color.Yellow; //Color.Yellow;
				//e.Item.ForeColor = Color.FromArgb(0,51,153);    //在系统调色板里查询rgb值
				#endregion 

				int ApplyHeadKey = int.Parse(e.Item.Cells[0].Text) ;

				//记录到隐藏域
				this.hideApplyHead.Value = ApplyHeadKey.ToString();


				#region  绑定此表单对应表体

				//显示预算信息
				BindBudgetInfo(ApplyHeadKey);

				//绑定到表体显示
				
				BindAssetBody(ApplyHeadKey);

			


				#endregion


				//设置按钮可用状态
				SetButtonsEnable(ApplyHeadKey);

				#endregion 
			}

		}



		private void dgApplyHead_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[2].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认删除吗?');"); 
			}
		}

		private void btnGetBack_Click(object sender, System.EventArgs e)
		{
			//取回单据

			//取回表单, 1,若是还没有人审批的取回, 更新为新建状态, 2.被驳回的取回,更新为取回状态

			int ApplyHeadKey = int.Parse(this.hideApplyHead.Value);

			Entiy.ApplySheetHead  ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
			
			if(ApplyHead!=null)
			{
				if(ApplyHead.ApplyProcessCode!=null)
				{
					Entiy.ApplyProcessType ApplyProcess=Entiy.ApplyProcessType.Find(ApplyHead.ApplyProcessCode); //查看申请单进程
					if(ApplyProcess!=null)
					{
						if((ApplyProcess.IsSubmit == 1 && ApplyProcess.IsCheck==0 ) )  //新建还未有人审批 or 驳回
						{
							//更新为新建状态, 更新所采用流程pk为 0
							ApplyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;
							ApplyHead.CheckFlowInCompanyHeadPk=0;
							ApplyHead.CurrentCheckRole="";
							ApplyHead.IsCheckInCompany=0;
							ApplyHead.CheckSetp=0;                                  //审批级设置为0
							RemoveBudget(ApplyHead.ApplySheetHeadPk);
							ApplyHead.Update();
							//更新预算表的 已审批金额 

							//Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApplyForGetBack (ApplyHeadKey);

						}
						else if(ApplyProcess.IsDisallow == 1)
						{
							//更新为取回状态, 更新所采用流程pk为 0
							ApplyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.GetBackPross;
							ApplyHead.CheckFlowInCompanyHeadPk=0;
							ApplyHead.CurrentCheckRole="";
							ApplyHead.IsCheckInCompany=0;
							ApplyHead.CheckSetp=0;                                  //审批级设置为0
							RemoveBudget(ApplyHead.ApplySheetHeadPk);
							ApplyHead.Update();
						
						}
					}
				}
			}

			SetButtonsEnable(ApplyHeadKey);

		}

		private void RemoveBudget(int ApplyHeadKey)
		{
			//减去预算表占用金额信息
			Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApplyForGetBack(ApplyHeadKey);

			//更新单据预算表的信息

			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);

			if(ApplyBudget != null && ApplyHead != null )
			{
				ApplyBudget.SumCheckMoney = 0 ;
				ApplyBudget.SubmitType = 0 ;
				ApplyBudget.Update();
			}

		}

		private void btnKeep_Click(object sender, System.EventArgs e)
		{
			//封存单据

			int ApplyHeadKey = int.Parse(this.hideApplyHead.Value);


			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(applyHead!=null)
			{
				applyHead.IsKeeping=1;    //将单据置为封存状态
				applyHead.Update();
			}

			SetButtonsEnable(ApplyHeadKey);

		}

		private void dgApplyHead_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			this.dgApplyHead.CurrentPageIndex = e.NewPageIndex;

			BindGetBackAssetApply() ; 

			this.PBudgetInfo.Visible = false;

			this.pAddItem.Visible = false;

			
		
		}

	
	}
}
