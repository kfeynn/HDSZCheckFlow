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
	/// AddAssetApply 的摘要说明。
	/// </summary>
	public class AddPriceCheckApply_Setp2 : System.Web.UI.Page
	{

		#region
		protected System.Web.UI.WebControls.Button btnInBudget;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox tbApplyDate;
		protected System.Web.UI.WebControls.DropDownList ddlFirstSubject;
		protected System.Web.UI.WebControls.TextBox tbPerson;
		protected System.Web.UI.WebControls.DropDownList ddlClassDept;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.TextBox tbDeliveryDate;
		protected System.Web.UI.WebControls.Panel pAddItem;
		protected System.Web.UI.WebControls.Label lblApplyNo;
		protected System.Web.UI.WebControls.Label lblMakeDate;
		protected System.Web.UI.WebControls.Label lbBudget;
		protected System.Web.UI.WebControls.Label lbSumCheck;
		protected System.Web.UI.WebControls.Label lbready;
		protected System.Web.UI.WebControls.Label lbOutMoney;
		protected System.Web.UI.WebControls.Label lbSheetMoney;
		protected System.Web.UI.WebControls.Label lbLeft;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Panel PBudgetInfo;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.TextBox Textbox3;
		protected System.Web.UI.WebControls.TextBox tbBargainNo;
		protected System.Web.UI.WebControls.TextBox tbPayForArticle;
		protected System.Web.UI.WebControls.TextBox tbRemark;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyCheckHead;
		protected System.Web.UI.WebControls.TextBox txtCheckDept;
		protected System.Web.UI.WebControls.TextBox txtTradeAgreement;
		protected System.Web.UI.WebControls.TextBox txtRequestDate;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddPriceCheckApply_Setp2));

			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				//绑定一级科目
				string Ids = "";
				Ids = GetQuery("Ids");
				InitApplyInfo(Ids);
			}
		}

		#region 获取参数
		private string GetQuery(string colString)
		{
			if(Request.QueryString[colString] != null)
			{
				return Request.QueryString[colString].ToString();
			}
			else
			{
				return "";
			}
		}
		#endregion 

		#region  ajax方法,修改表体值
		//[AjaxMethod()]
        [System.Web.Services.WebMethod]
		public   void SaveFBodyInfo(string FBId,string Value ,int Flag)
		{
			try
			{
				//三个参数意义 
				//FBId：价格裁决表体ID.Value：修改后的值.Flag：标记修改的字段（目前有4个  12 代表币种 13代表数量 14代表价格 15代表供应商）
				int BId = int.Parse(FBId);
				decimal BValue = 0 ; 
				int BFlag =0;
				if(Common.Util.CommonUtil.IsNumeric(Value))
				{
					BValue = decimal.Parse(Value);
				}
				BFlag = Flag ;
				Entiy.AssetFinallyPriceCheckBody FinallyCheckBody = Entiy.AssetFinallyPriceCheckBody.Find(BId);
				switch  ( BFlag )
				{
					case 12:

						//记录裁决币种
						FinallyCheckBody.CurrTypeCode = Value ; 
						//记录币种的基准利率
						//Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.FindByYearAndMonth(Value,DateTime.Today.Year,1);

						Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.Find(Value);

						if(CurrType != null )
						{
							FinallyCheckBody.ExchangeRate = CurrType.ExchangeRate ;
						}
						
						break;
					case 13:
						FinallyCheckBody.Number = int.Parse(BValue.ToString()) ;
						break;
					case 14:
						FinallyCheckBody.FinallyPrice  = BValue ; 
						break;
					case 15:
						FinallyCheckBody.Offer = Value ; 
						break;
				}
				FinallyCheckBody.Save();
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2.SaveFBodyInfo",ex.Message );
			}
		}

		#endregion 

		#region  初始化下拉菜单
		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
//				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
//				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeByCode (deptClassCode,"Asset");
//				if(dtType!=null && dtType.Rows.Count>0)
//				{
//					this.ddlType .DataSource =dtType;
//					ddlType.DataValueField=dtType.Columns[0].ToString();
//					ddlType.DataTextField=dtType.Columns [1].ToString();
//					ddlType.DataBind();
//					ddlType.Items.Insert(0,"");
//					dtType=null;
//				}

				string TypeCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"] ; 

				string cdStr = "select * from ApplyType where ApplyTypeCode = " + TypeCode ; 
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cdStr);
				if(ds !=null )
				{
					this.ddlType .DataSource =ds;
					ddlType.DataValueField="ApplyTypeCode";
					ddlType.DataTextField="ApplyTypeName";
					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
				}



				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(0);
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlClassDept.DataSource=dtDeptClass;
					ddlClassDept.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlClassDept.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlClassDept.DataBind();
					ddlClassDept.Items.Insert(0,"");
				}

				//绑定科组

				string cmdStr = "select * from Base_dept where deptcode <> superior_dept_pk order by deptcode ";
				DataTable dtDept=Bussiness.ComQuaryBLL.ExecutebyQuery (cmdStr).Tables[0];
				if(dtDept!=null && dtDept.Rows.Count>0)
				{
					this.ddlDept.DataSource=dtDept;
					ddlDept.DataValueField="DeptCode" ; 
					ddlDept.DataTextField ="DeptName" ; 
					ddlDept.DataBind();
					ddlDept .Items.Insert(0,"");
				}
				else
				{
					this.ddlDept.DataSource=null;
					ddlDept.DataBind();
				}

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}
		#endregion

		private void InitApplyInfo(string Ids)
		{
			//0. 处理参数，以逗号分隔
			string []Id = Ids.Split(new char[]{','});

			if(Id.Length > 0 )
			{
				Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(int.Parse(Id[0]));

				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(AssetBody.ApplySheetHeadPk );

				Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(AssetBody.ApplySheetHeadPk );

				//更新价格裁决表头信息

				//新增价格裁决表头信息
				Entiy.AssetFinallyPriceCheck FinallyCheck =new HDSZCheckFlow.Entiy.AssetFinallyPriceCheck();

				FinallyCheck.ApplySheetHeadPk = AssetBody.ApplySheetHeadPk ; 
				FinallyCheck.ItemName =  ApplyBudget.ItemName ;

				FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态
				FinallyCheck.MakeDate = DateTime.Now ;

				//合同号
				FinallyCheck.BargainNo = "";

				/////// 可能增加项目
				
				FinallyCheck.Create();

				//记录 到隐藏域 
				this.hideApplyCheckHead.Value  = FinallyCheck.Id.ToString() ;

				//更新价格裁决表体
				////                     新增。
				foreach(string i in Id)
				{
					Entiy.AssetFinallyPriceCheckBody FinallyCheckBody = new HDSZCheckFlow.Entiy.AssetFinallyPriceCheckBody();

					FinallyCheckBody.AssetApplySheetBodyId = int.Parse(i);
					FinallyCheckBody.FinallyPriceCheckId   = FinallyCheck.Id ;


					FinallyCheckBody.Create();
				}

				//1. 绑定表头信息
				BindApplyHead(AssetBody.ApplySheetHeadPk);
				//2. 显示预算信息
				BindBudgetInfo(AssetBody.ApplySheetHeadPk);
				//3. 绑定表体信息
				BindApplyBodyInfo(AssetBody.ApplySheetHeadPk,Ids,FinallyCheck.Id.ToString());

				//添加附件可用
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../../Asset/PriceCheck/ApplySheetAnnexForFinallyCheck.aspx?FinallyCheckId=" + FinallyCheck.Id.ToString()   ;			


			}
		}


		


		/// <summary>
		/// 绑定表头信息
		/// </summary>
		/// <param name="ApplyBodyKey">任意一表体Id</param>
		private void BindApplyHead(int ApplyHeadKey)
		{
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null)
			{
				this.ddlClassDept.SelectedValue = ApplyHead.ApplyDeptClassCode ;
				this.tbApplyDate .Text  = ApplyHead.ApplyDate.ToString("yyyy-MM-dd");
				this.ddlDept.SelectedValue = ApplyHead.ApplyDeptCode;
				this.ddlType.SelectedValue = ApplyHead.ApplyTypeCode;

				this.tbDeliveryDate .Text = ApplyHead.DeliveryDate.ToString();
				this.tbPerson.Text = ApplyHead.ApplyMakerCode.ToString();
				this.lblApplyNo.Text = ApplyHead.ApplySheetNo ;
				this.lblMakeDate.Text = ApplyHead.SubmitDate.ToString();

				Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
				if(ApplyBudget != null)
				{
					this.ddlFirstSubject.SelectedValue = ApplyBudget.ItemName ;
				}

				//根据表头ID绑定所使用的科目信息
				string cmdStr = " select * from dbo.Asset_ApplySheet_Budget  where ApplySheetHead_Pk =  " + ApplyHeadKey ;
				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
				if(ds!=null && ds.Tables.Count >0  &&  ds.Tables[0].Rows.Count > 0 )
				{
					this.ddlFirstSubject.DataSource = ds;
					this.ddlFirstSubject.DataValueField = "ItemName";
					this.ddlFirstSubject.DataValueField = "ItemName";
					this.ddlFirstSubject.DataBind();
				}
			}
		}


		/// <summary>
		/// 绑定表体信息
		/// </summary>
		/// <param name="ApplyHeadPk"></param>
		private void BindApplyBodyInfo(int ApplyHeadPk,string Ids,string FId)
		{
			//表体详细信息
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(ApplyHead!=null)
			{
				Entiy.ApplyType ApplyType=Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
				if(ApplyType !=null)
				{
					//ApplyHead=null;
					if("Asset_ApplySheet_Body".Equals(ApplyType.ApplySheetBodyTableName) )
					{
						//表体详细信息
						DataSet ds= Bussiness.ApplyAuditingBLL.GetApplySheetBodyAssetAndCheckInfo(ApplyHeadPk,Ids,FId);
						if(ds!=null)
						{
							this.dgApply.DataSource=ds;
						}
						else
						{
							this.dgApply.DataSource=null;
						}
						this.dgApply.DataBind();
					}
				}
			}

		}



		#region  绑定一级科目  

		//		private void BindFirstClassSubject()
		//		{
		//			//系统当前年 ｜ 当前登录人员部门 
		//			int iYear = DateTime.Today.Year ;
		//			DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
		//
		//			string ClassDept = "";
		//
		//			if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
		//			{
		//				ClassDept = dtDeptClass.Rows[0][0].ToString();
		//			}
		//			if(!ClassDept.Equals(""))
		//			{
		//
		//				DataSet ds = Bussiness.AssetBudgetBll.SelectFirstClassSubjectByYearAndDept(iYear,ClassDept);
		//				if (ds!=null && ds.Tables.Count > 0 ) 
		//				{
		//
		//
		//				}
		//
		//			}
		//
		//		}

		#endregion

		#region 控件可用 
		private void openControlEnable()
		{
			this.ddlType.Enabled = true;
			this.tbApplyDate.Enabled = true;
			this.ddlClassDept.Enabled = true;
			this.ddlDept.Enabled = true;
			this.ddlFirstSubject.Enabled = true;
			this.tbPerson.Enabled = true;
			this.tbDeliveryDate.Enabled = true;
		}
		#endregion 

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
			this.btnInBudget.Click += new System.EventHandler(this.btnInBudget_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			
			//价格超过原单据价格 阻止   (换算成rmb比较)
			//数量超过原单据数量 阻止
			//更新已价格裁决数量
			//更新是否已经裁决字段。。。。 

			this.lbMsg.Text = "";

            int FinallyCheckKey = int.Parse(this.hideApplyCheckHead.Value);

			//检测是否数据完整（是否有合同号等） 

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

			if(FinallyCheck != null && FinallyCheck.BargainNo.Length <= 0 ) 
			{
				this.lbMsg.Text = "合同号不能为空";
				return ;
			}

			//检测提交
			int i = Bussiness.AssetFinallyCheckPrice.CheckFinallyApplyAndBody(FinallyCheckKey);

			if(i==1)
			{
				//价格 数量合格 ，提交审批 

				int Flag = Bussiness.AssetCheckFlowBLL.StartFinallyPriceCheckFlow(FinallyCheckKey) ; 

				if(Flag == 1 )
				{
					this.lbMsg.Text = "单据已经提交！";

					//提交即占已提交数量 ， 已审批金额 

					//价格裁决表头
					//Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

					//更新已经价格裁决表体数量
					Bussiness.AssetCheckFlowBLL.AddFinallyCheckNumber(FinallyCheck.Id);			
				}
				else
				{
					switch(Flag)
					{
							//返回值： 1正常 2已经提交 3未找到流程 。4未找到单据。5已经提交。
						case 1:
							this.lbMsg.Text = "单据已经提交！";
							break;
						case 2:
							this.lbMsg.Text ="单据已经提交！请不要重复操作";
							break;
						case 3:
							this.lbMsg.Text ="未找到流程！";
							break;
						case 4:
							this.lbMsg.Text ="未找到单据！";
							break;
					}
				}
			}
			else
			{
				switch (i)
				{
					case 2:
						this.lbMsg.Text = "价格超出";
						break;
					case 3:
						this.lbMsg.Text = "数量超出";
						break;
					case 4:
						 this.lbMsg.Text ="系统出错";
						break;
				}
			}


			
		}



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

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.lbMsg.Text = "" ;
				//保存表头信息
				if(this.tbBargainNo.Text.Trim() =="")
				{
					this.lbMsg.Text = "合同号不能为空";
					return ;
				}
				if(this.txtRequestDate.Text.Trim() =="")
				{
					this.lbMsg.Text = "到货日期不能为空";
					return ;
				}

				int CheckHeadKey =  int.Parse(this.hideApplyCheckHead.Value);

				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(CheckHeadKey);

				if(FinallyCheck == null )
				{
					this.lbMsg.Text = "系统出错，找不到对应裁决表！";
					Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2","系统出错，找不到对应裁决表");
					return ;
				}

				FinallyCheck.BargainNo = this.tbBargainNo.Text;
				if(this.tbPayForArticle.Text.Length > 200)
				{
					FinallyCheck.PayForArticle = this.tbPayForArticle.Text.Substring(0,199);
				}
				else
				{
					FinallyCheck.PayForArticle = this.tbPayForArticle.Text;
				}
				if( this.tbRemark.Text.Length > 400)
				{
					FinallyCheck.ReMark  = this.tbRemark.Text.Substring(0,399);
				}
				else
				{
					FinallyCheck.ReMark  = this.tbRemark.Text;
				}

				if(this.txtCheckDept.Text.Length > 200)
				{
					FinallyCheck.CheckDept = this.txtCheckDept.Text.Substring (0,199) ;
				}
				else
				{
					FinallyCheck.CheckDept = this.txtCheckDept.Text ;
				}

				if(this.txtTradeAgreement.Text .Length > 200)
				{
					FinallyCheck.TradeAgreement = this.txtTradeAgreement.Text.Substring(0,199) ;
				}
				else
				{
					FinallyCheck.TradeAgreement = this.txtTradeAgreement.Text ;
				}

				FinallyCheck.RequestDate = this.txtRequestDate.Text ;

				FinallyCheck.Save ();


				//重新绑定表单

				string Ids = "";
				Ids = GetQuery("Ids");

				BindApplyBodyInfo(FinallyCheck.ApplySheetHeadPk,Ids,FinallyCheck.Id.ToString());
				//BindApplyBodyInfo(AssetBody.ApplySheetHeadPk,Ids,FinallyCheck.Id.ToString());
				

			}
			catch(Exception Ex)
			{
				Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2.btnSave_Click",Ex.Message );
				this.lbMsg.Text = Ex.Message ;
			}
		}

		private void BindBudgetInfo (int ApplyHeadKey)
		{
			#region 预算情况
			decimal BudgetMoney = 0;
			decimal ReadyPay    = 0;
 			//单据表头
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
			//单据预算
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyHead !=null && ApplyBudget !=null )
			{
				//本单金额
				this.lblSheetMoney.Text= ApplyBudget.SheetRmbMoney.ToString();
				//已经使用
				this.lblSumCheck.Text = ApplyBudget.SumCheckMoney.ToString();
				//预算外金额
				this.lblOutMoney.Text = ApplyBudget.AllowOutMoney.ToString();
				//单据所用项目预算
				Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
				if(Dept != null )
				{
					//获取项目预算信息
					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,ApplyBudget.ItemName);
					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
					{
						//预算
						this.lblBudget.Text= ds.Tables[0].Rows[0]["BudgetMoney"].ToString();
						//待摊
						this.lblready.Text = ds.Tables[0].Rows[0]["ReadyPay"].ToString() ;

						BudgetMoney = decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString());
						ReadyPay    = decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString());
					}
				}
				//计算剩余金额
				decimal LeftMoney = BudgetMoney + ApplyBudget.AllowOutMoney - ApplyBudget.SumCheckMoney - ReadyPay - ApplyBudget.SheetRmbMoney ;
				this.lblLeft.Text = LeftMoney.ToString("N2");
			}

			#endregion
		}

		private void BindAssetBody(int applyHeadPk)
		{
			#region 绑定表体信息
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

		private void btnEdit_Click(object sender, System.EventArgs e)
		{

		}

		private void SetButtonsEnable(int ApplyHeadPk)
		{
			// 1 全不可用
			// 2 预算内可用
			// 3 预算外可用
			int i=Bussiness.ApplySheetHeadForAssetBLL.SetButtonEnableForAsset(ApplyHeadPk);
			switch(i)
			{
				case 1:
					this.btnInBudget.Enabled=false;
					break;
				case 2:
					this.btnInBudget.Enabled=true;
					break;
				case 3:
					this.btnInBudget.Enabled=false;
					break;
			}
		}


		#region 检验输入是否为数字

		/// <summary>
		/// 检验输入是否为数字
		/// </summary>
		/// <param name="Mail_One">数字字符串</param>
		/// <returns>bool</returns>
		private  bool IsNumeric(string num)
		{
			//bool Validate_result = true;

			//Validate_result = Regex.IsMatch(num.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,3})$");

			string a = "^(-?[0-9]*[.]*[0-9]{0,3})$" ;  //正整数 

			string b = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"  ;  //正浮点数

			if(Regex.IsMatch(num.Trim(), @a) || Regex.IsMatch(num.Trim(), @b))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

		#region 查询币种的基准利率(1月利率)
		private decimal SelectRateByCurrCode(string CurrCode)
		{
			//查询币种的基准利率。 基准利率为当年1月利率

			Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.FindByYearAndMonth(CurrCode,DateTime.Today.Year,1);
			if(CurrType != null )
			{
				return CurrType.ExchangeRate ;
			}
			else
			{
				return  0 ;
			}
		}
		#endregion

		private void dgApply_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			#region 
//			if(e.CommandName.Equals("delete")) //点击审批按钮
//			{
//				
//				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
//				if(ApplyHead == null )
//				{
//					this.lbMsg.Text = "系统错误，找不到单据！";
//					return ;
//				}
//				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
//
//				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
//				{
//					this.lbMsg.Text = "此单不是新建状态，不能删除！";
//					return ;
//				}
//
//				for(int i=0;i<this.dgApply.Items.Count ;i++)
//				{
//					Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(int.Parse(e.Item.Cells[0].Text.Trim()));
//					if(AssetBody != null ) 
//					{
//						AssetBody.Delete();
//					}
//				}
//				//重新计算本单金额 && 剩余金额
//				BindApplyMoney(int.Parse(this.hideApplyHead.Value));
//				//绑定到表体显示
//				BindAssetBody(int.Parse(this.hideApplyHead.Value));
//			}
//			//更新后重新绑定按钮可用状态
//			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));
			#endregion 
		}


		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				//普通编辑框
				e.Item.Cells[14].Attributes.Add("EditType","TextBox");
				e.Item.Cells[15].Attributes.Add("EditType","TextBox");
				e.Item.Cells[16].Attributes.Add("EditType","TextBox");

				//下拉编辑框
				e.Item.Cells[13].Attributes.Add("EditType","DropDownList");
				//下拉值设定，（暂时写固定）
				e.Item.Cells[13].Attributes.Add("DataItems","{text:'人民币',value:'RMB'},{text:'美元',value:'USD'},{text:'日元',value:'JPY'},{text:'港币',value:'HKD'}");
			}

			e.Item.Cells[0].CssClass = "CellO";
		}

			
	}
}
