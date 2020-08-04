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

namespace HDSZCheckFlow.UI.Asset.CheckFlow
{
	/// <summary>
	/// AddAssetApply 的摘要说明。
	/// </summary>
	public class AddAssetApply : System.Web.UI.Page
	{
		#region
		protected System.Web.UI.WebControls.Button btnInBudget;
		protected System.Web.UI.WebControls.Button btnOutBudget;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.WebControls.DropDownList ddlType;
		protected System.Web.UI.WebControls.TextBox tbApplyDate;
		protected System.Web.UI.WebControls.DropDownList ddlFirstSubject;
		protected System.Web.UI.WebControls.TextBox tbPerson;
		protected System.Web.UI.WebControls.Label lblName;
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
		protected System.Web.UI.WebControls.DropDownList ddlSubjectCode;
		protected System.Web.UI.WebControls.TextBox tbInvName;
		protected System.Web.UI.WebControls.TextBox tbInvType;
		protected System.Web.UI.WebControls.TextBox tbOriginalcurrPrice;
		protected System.Web.UI.WebControls.DropDownList ddlUnit;
		protected System.Web.UI.WebControls.DropDownList ddlcurrTypeCode;
		protected System.Web.UI.WebControls.TextBox tbNumber;
		protected System.Web.UI.WebControls.DataGrid dgApply;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Panel PBudgetInfo;
		protected System.Web.UI.HtmlControls.HtmlInputHidden hideApplyHead;
		protected System.Web.UI.WebControls.Button btnAddBody;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenLeft;
		protected System.Web.UI.WebControls.Button btnCancel;
		protected System.Web.UI.WebControls.TextBox tbReasonForAsset;
		protected System.Web.UI.WebControls.TextBox tbEffect;
		protected System.Web.UI.WebControls.Label lbMsg;
		#endregion
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			Utility.RegisterTypeForAjax(typeof(AddAssetApply));

			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				this.btnInBudget.Enabled = false; 
				this.btnOutBudget.Enabled = false;

				this.btnEdit.Enabled = false;
				this.btnSave.Enabled = false;

				InitPageForAdd();

				//绑定一级科目 
			}
		}

		#region  ajax方法,供页面查询用户姓名
		[AjaxMethod()]
		public string  GetUserNameByCode(string personCode)
		{
			try
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person!=null)
				{
					return person.Name;
				}
				else
				{
					return "";
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.Asset.CheckFlow.AddAssetApply",ex.Message );
				return "";
			}
		}
		#endregion 

		#region  初始化下拉菜单
		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeByCode (deptClassCode,"Asset");
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlType .DataSource =dtType;
					ddlType.DataValueField=dtType.Columns[0].ToString();
					ddlType.DataTextField=dtType.Columns [1].ToString();

					ddlType.DataBind();
					ddlType.Items.Insert(0,"");
					dtType=null;
				}

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlClassDept.DataSource=dtDeptClass;
					ddlClassDept.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlClassDept.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlClassDept.DataBind();
					ddlClassDept.Items.Insert(0,"");
				}			


				
//				//绑定一级科目.系统当前年 ｜ 当前登录人员部门 
//				int iYear = DateTime.Today.Year ;
//				//DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
//				string ClassDept = "";
//
//				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
//				{
//					ClassDept = dtDeptClass.Rows[0][0].ToString();
//				}
//				if(!ClassDept.Equals(""))
//				{
//					DataSet ds = Bussiness.AssetBudgetBll.SelectFirstClassSubjectByYearAndDept(iYear,ClassDept);
//					if (ds!=null && ds.Tables.Count > 0 ) 
//					{
//						this.ddlFirstSubject.DataSource = ds.Tables[0];
//						this.ddlFirstSubject.DataValueField = ds.Tables[0].Columns["ItemName"].ToString();
//						this.ddlFirstSubject.DataTextField  = ds.Tables[0].Columns["ItemName"].ToString();
//						this.ddlFirstSubject.DataBind();
//						this.ddlFirstSubject.Items.Insert(0,"");
//					}
//				}


				
			}

			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

		}
		#endregion

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
			this.btnOutBudget.Click += new System.EventHandler(this.btnOutBudget_Click);
			this.ddlClassDept.SelectedIndexChanged += new System.EventHandler(this.ddlClassDept_SelectedIndexChanged);
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlFirstSubject.SelectedIndexChanged += new System.EventHandler(this.ddlFirstSubject_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.btnAddBody.Click += new System.EventHandler(this.btnAddBody_Click);
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion



		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			//预算内提交
			//如果单据已提交 则阻止
			//找到对应审批流程 更新表头
			//更新表单预算状态 
			//更新提交按钮状态 
			try
			{
				this.lbMsg.Text = "" ; 
				if(!"".Equals(this.hideApplyHead.Value ))
				{
					int ApplyHeadKey =int.Parse(this.hideApplyHead.Value);
					//更新流程信息
					Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead!=null)
					{
						#region 是否为提交状态

						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
						{
							this.lbMsg.Text = "此单已经提交过!请不要重复提交";
							return ;
						}
						#endregion

						//单据金额 
						decimal AssetApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

						Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						if(AssetBudget == null )
						{
							this.lbMsg.Text ="没有对应预算表信息。请联系电脑室！";
							return ;
						}
						//预算部门
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
						if(BaseDept == null || BaseDept.BudgetDeptCode.Length <=0 )
						{
							this.lbMsg.Text ="没有设置预算部门。请联系电脑室！";
							return ;
						}
						//预算信息
						DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BaseDept.BudgetDeptCode ,AssetBudget.ItemName);
						
						if(DsBudget == null || DsBudget.Tables .Count <=0 )
						{
							this.lbMsg.Text ="没有对应预算信息。请联系电脑室！";
							return ;
						}

						if(decimal.Parse(DsBudget.Tables[0].Rows[0]["LeftMoney"].ToString()) < AssetApplyMoney )
						{
							//剩余金额不足
							this.lbMsg.Text = "剩余金额不足，不能提交！";
							return; 
						}

						#region 

						//匹配审批流程

						//当前用户所在部门
						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						//本单金额
						decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);  //本次审批金额
						//所属于合议部门
						string DecisionDept = Bussiness.AssetCheckFlowBLL.FindDecisionDeptByApplyHeadPk(ApplyHeadKey);

						


						//匹配审批流程
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindAssetByCodeAndType(ApplyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ApplyMoney,MydeptCode,DecisionDept); 
						if(TypeInFlow!=null)
						{
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );

							if(!"".Equals(checkRole))
							{
								ApplyHead.CurrentCheckRole=checkRole;
								ApplyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								ApplyHead.CheckSetp=CheckStep;
								ApplyHead.Update();

								// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode);

								updatePross(ApplyHeadKey);   //更新流程状态

//								//提交既占预算，更新预算表的已占用预算额

								//Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
								if(AssetBudget != null )
								{
//									维护以下 4个字段 

//									申请单本币金额	SheetRmbMoney
//									已用预算		SumCheckMoney
//									允许预算外金额	AllowOutMoney
//									是否预算外/内	SubmitType

									//单据金额 
									AssetBudget.SheetRmbMoney = AssetApplyMoney ;
									//已审批金额
									AssetBudget.SumCheckMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["CheckMoney"].ToString()) ; 
									//预算外金额
									AssetBudget.AllowOutMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["TotalOutMoney"].ToString());
									//提交的是预算内
									AssetBudget.SubmitType = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["InCorntType"]); 

									AssetBudget.Update();

									//更新预算表的 已审批金额 

									Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply(ApplyHeadKey);

									this.lbMsg.Text = "提交成功";
								}

							}
							else
							{
								Response.Write(Message);
								HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
							}

							if(IsGiveUp == 1 )
							{
								//此用户放弃审批,循环调用方法本身;
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();

								Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
								//取消发邮件功能
//								//根据工号发邮件            发邮件(方法2)
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//
//								mailBll.ThreadSendMail();
							}
						}
						else
						{
							this.lbMsg.Text = "未设置相关审批流程!请联系电脑室 ";
						}
						#endregion 
					}
					SetButtonsEnable(ApplyHeadKey);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddAssetApply.SubmitInBudget",ex.Message);
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




		private void btnOutBudget_Click(object sender, System.EventArgs e)
		{
			//预算外提交

			try
			{
				this.lbMsg.Text = "" ; 
				if(!"".Equals(this.hideApplyHead.Value ))
				{
					int ApplyHeadKey =int.Parse(this.hideApplyHead.Value);
					//更新流程信息
					Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead!=null)
					{
						#region 是否为提交状态

						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
						{
							this.lbMsg.Text = "此单已经提交过!请不要重复提交";
							return ;
						}
						#endregion


						//单据金额 
						decimal AssetApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

						Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						if(AssetBudget == null )
						{
							this.lbMsg.Text ="没有对应预算表信息。请联系电脑室！";
							return ;
						}
						//预算部门
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);

						if(BaseDept == null || BaseDept.BudgetDeptCode.Length <=0 )
						{
							this.lbMsg.Text ="没有预算部门。请联系电脑室！";
							return ;
						}

						//预算信息
						DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BaseDept.BudgetDeptCode,AssetBudget.ItemName);
						
						if(DsBudget == null || DsBudget.Tables .Count <=0 )
						{
							this.lbMsg.Text ="没有对应预算信息。请联系电脑室！";
							return ;
						}

//						if(decimal.Parse(DsBudget.Tables[0].Rows[0]["LeftMoney"].ToString()) < AssetApplyMoney )
//						{
//							//剩余金额不足
//							this.lbMsg.Text = "剩余金额不足，不能提交！";
//							return; 
//						}

						#region 

						//匹配审批流程

						//当前用户所在部门
						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						//本单金额
						decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);  //本次审批金额
						//所属于合议部门
						string DecisionDept = Bussiness.AssetCheckFlowBLL.FindDecisionDeptByApplyHeadPk(ApplyHeadKey);

						//匹配审批流程
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindAssetByCodeAndType(ApplyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ApplyMoney,MydeptCode,DecisionDept); 
						if(TypeInFlow!=null)
						{
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );

							if(!"".Equals(checkRole))
							{
								ApplyHead.CurrentCheckRole=checkRole;
								ApplyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								ApplyHead.CheckSetp=CheckStep;
								ApplyHead.Update();

								// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode);

								updatePross(ApplyHeadKey);   //更新流程状态

								if(AssetBudget != null )
								{
									//维护4个字段 

									//单据金额 
									AssetBudget.SheetRmbMoney = AssetApplyMoney ;
									//已审批金额
									AssetBudget.SumCheckMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["CheckMoney"].ToString()) ; 
									//预算外金额
									AssetBudget.AllowOutMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["TotalOutMoney"].ToString());
									//提交的是预算内
									AssetBudget.SubmitType = int.Parse(System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"]); 
									//提交更新
									AssetBudget.Update();

									//更新预算表的 已审批金额 
									Bussiness.AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply(ApplyHeadKey);
								}
							}
							else
							{
								Response.Write(Message);
								HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
							}
							if(IsGiveUp == 1 )
							{
								//此用户放弃审批,循环调用方法本身;
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();

								Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
//								//根据工号发邮件            发邮件(方法2)
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//
//								mailBll.ThreadSendMail();
							}
						}
						else
						{
							this.lbMsg.Text = "未设置相关审批流程!请联系电脑室 ";
						}
						#endregion 
					}
					SetButtonsEnable(ApplyHeadKey);
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddAssetApply.SubmitInBudget",ex.Message);
			}

		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//添加按钮，让控件可用。
			this.btnAdd.Enabled = false;
			this.btnEdit.Enabled =false;
			this.btnSave.Enabled = true;
			openControlEnable();
		}

		private void ddlClassDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			#region 选定部门，绑定其二级部门
			//绑定科组
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlClassDept.SelectedValue;
			DataTable dtDept=Bussiness.CheckFlowInDeptBLL.GetDeptForDeptClassForAdd(deptClass);
			if(dtDept!=null && dtDept.Rows.Count>0)
			{
				this.ddlDept.DataSource=dtDept;
				ddlDept.DataValueField=dtDept.Columns[0].ToString();
				ddlDept.DataTextField =dtDept.Columns[1].ToString();
				ddlDept.DataBind();
				ddlDept .Items.Insert(0,"");
			}
			else
			{
				this.ddlDept.DataSource=null;
				ddlDept.DataBind();
			}
			#endregion
		}

		#region 
//		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(this.ddlDept.SelectedValue);
//			if(dept != null && dept.BudgetDeptCode != null )
//			{
//				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(dept.BudgetDeptCode); //一级科目
//				if(dtSubject!=null && dtSubject.Rows.Count >0)
//				{
//					this.ddlFirstSubject.DataSource=dtSubject;
//					ddlFirstSubject.DataValueField=dtSubject.Columns[0].ToString();
//					ddlFirstSubject.DataTextField =dtSubject.Columns[1].ToString();
//					ddlFirstSubject.DataBind();
//					ddlFirstSubject.Items.Insert(0,"");
//				}
//			}
//		}


		private void ddlFirstSubject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//选定一级科目对应的子科目信息 || 暂时无二级科目 
//			string ItemName = this.ddlFirstSubject.SelectedValue;
//			int iYear  = DateTime.Today.Year;
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
//				DataSet ds = Bussiness.AssetBudgetBll.SelectSubItemByYearAndFirstItem (iYear,ClassDept,ItemName);
//				if(ds!=null && ds.Tables.Count > 0 )
//				{
//					this.ddlSubject.DataSource=ds.Tables[0];
//					ddlSubject.DataValueField=ds.Tables[0].Columns["SubjectName"].ToString();
//					ddlSubject.DataTextField =ds.Tables[0].Columns["SubjectName"].ToString();
//					ddlSubject.DataBind();
//					ddlSubject .Items.Insert(0,"");
//				}
//			}
		}

		#endregion 

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			#region 添加表头按钮 
			//检验表头信息
			string applyNo="";
			string applyType=this.ddlType.SelectedValue;
			DateTime  applyDate=new DateTime();
			if(!"".Equals(this.tbApplyDate.Text))
			{
				applyDate=DateTime.Parse(tbApplyDate.Text);
				//申请日期不能小于 当前月份............
				if(applyDate.Year < DateTime.Today.Year || (applyDate.Year == DateTime.Today.Year && applyDate.Month < DateTime.Today.Month) )
				{
					this.lbMsg.Text= "申请日期不能为以前月份！";
					return ;
				}
			}
			string applyDeptClass=this.ddlClassDept.SelectedValue;
			string applyDept=this.ddlDept.SelectedValue;
			//string applySubject=this.ddlSubject.SelectedValue;
			string personCode=this.tbPerson.Text;
			string firstSubject=this.ddlFirstSubject.SelectedValue;
			string  DeliveryDate="";
			if(!"".Equals(tbDeliveryDate.Text))
			{
				DeliveryDate=tbDeliveryDate.Text;
			}

			#region 检验非空条件
			if("".Equals(applyType))
			{
				this.lbMsg .ForeColor=Color.Red;
				this.lbMsg.Text="类型不能为空";
				return;
			}
			if("".Equals(tbApplyDate.Text))
			{
				this.lbMsg.ForeColor=Color.Red;
				this.lbMsg.Text="申请日期不能为空";
				return;
			}
			if("".Equals(applyDeptClass))
			{
				this.lbMsg.ForeColor=Color.Red;
				this.lbMsg.Text="申请部门不能为空";
				return;
			}
			if("".Equals(applyDept))
			{
				this.lbMsg.ForeColor=Color.Red;
				this.lbMsg.Text="申请科组不能为空";
				return;
			}
			if("".Equals(firstSubject))
			{
				this.lbMsg.ForeColor=Color.Red;
				this.lbMsg.Text="一级科目不能为空";
				return;
			}
//			if("".Equals(applySubject))
//			{
//				this.lbMsg.ForeColor=Color.Red;
//				this.lbMsg.Text="申请科目不能为空";
//				return;
//			}


			Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
			if(person==null)
			{
				this.lbMsg.ForeColor=Color.Red;
				this.lbMsg.Text="人员不存在";
				return ;
			}
			#endregion 

			#region 生成单据号
			//1.取前缀
			Entiy.ApplyType applyTyp=Entiy.ApplyType.Find(applyType);
			if(applyTyp!=null)
			{
				applyNo=applyTyp.ApplySheetEncode ;
			}
			else
			{
				this.lbMsg.Text="生成单据号错误!";
				return ;
			}
			//2.取年月
			int iYear=applyDate.Year;
			int iMonth=applyDate.Month;
			string tempMonth=iMonth.ToString();
			for(int iLength=iMonth.ToString().Length ;iLength<2;iLength++)
			{
				tempMonth="0"+tempMonth;
			}
			applyNo += iYear.ToString();
			applyNo += tempMonth;

			//3.取流水号
			string  MaxNum1=Bussiness.ApplySheetHeadBLL.GetMaxSheetNo(applyNo);
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
			//4.合并单据号
			applyNo = applyNo + applyMaxNum;

			#endregion 

			
			string personMakerCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));

			//保存单据表头信息 

			Entiy.ApplySheetHead applySheet=new HDSZCheckFlow.Entiy.ApplySheetHead();
			applySheet.ApplySheetNo=applyNo;
			applySheet.ApplyTypeCode=applyType;
			applySheet.ApplyDate=applyDate;
			applySheet.ApplyDeptClassCode =applyDeptClass;
			applySheet.ApplyDeptCode=applyDept;
			//applySheet.SheetSubject =applySubject;
			applySheet.ApplyPersonCode=personCode ;
			applySheet.ApplyMakerCode=personMakerCode;
			applySheet.DeliveryDate = DeliveryDate ;
			applySheet.SubmitDate = System.DateTime.Now;         // 提交时间为系统当前时间
			applySheet.ExpenseDate  = DateTime.Parse("1900-01-01"); //报销日期 给默认日期

			//提案理由
//			if(this.tbReasonForAsset.Text.Length >= 400)
//			{
//				applySheet.ReasonForAsset = this.tbReasonForAsset.Text.Substring(0,398);
//			}
//			else
//			{
//				applySheet.ReasonForAsset = this.tbReasonForAsset.Text ; 
//			}

			applySheet.ReasonForAsset = this.tbReasonForAsset.Text ; 

			//达到效果
//			if(this.tbEffect.Text.Length >= 400)
//			{
//				applySheet.Effect = this.tbEffect.Text.Substring(0,398);
//			}
//			else
//			{
//				applySheet.Effect = this.tbEffect.Text;
//			}

			applySheet.Effect = this.tbEffect.Text;

			applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态

			applySheet.Create();

			//添加 Asset_ApplySheet_Budget
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);

			Entiy.AssetApplySheetBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.AssetApplySheetBudget();

			if(applyHead!=null)
			{
				ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
				ApplyHeadBudget.ItemName=firstSubject;
				//ApplyHeadBudget.SheetSubject=applySubject;
				ApplyHeadBudget.Create();
			}

//			this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //记录此次添加的表头PK



//			//添加附件可用
//			this.hyLindToAnnex.Visible=true;
//			this.hyLindToAnnex.Target = "_blank";
//			this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;



			//添加附件可用
			this.hyLindToAnnex.Visible=true;
			this.hyLindToAnnex.Target = "_blank";
			this.hyLindToAnnex.NavigateUrl= "../../CheckFlow/CheckFlow/ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;

			//显示部门科目预算情况

			Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(applyDept);
			if(BaseDept != null )
			{
				BindBudgetInfo(applyDate.Year,BaseDept.BudgetDeptCode,firstSubject);
			}

			this.lblApplyNo.Text = applyNo; 

			this.lblMakeDate.Text = DateTime.Now.ToString();

			//显示表体 

			this.pAddItem.Visible = true;
			this.dgApply.Visible= true;

			//显示当前表单对应预算信息
			//按钮状态
			this.btnSave.Enabled = false;
			this.btnEdit.Enabled = true;
			this.btnAdd.Enabled = true;

			//初始化添加表体的
			
			BindInitAddBody();

			BindAssetBody(applyHead.ApplySheetHeadPk);

			//全局变量记录表头值
			this.hideApplyHead.Value = applyHead.ApplySheetHeadPk.ToString()  ; 


			#endregion 
		}

		private void BindBudgetInfo (int iYear ,string BudgetDeptcode,string ItemName )
		{
			#region 显示预算信息

			this.PBudgetInfo.Visible = true;
			// 更改为按季度为判断标准
			//1.根据申请月份，得出当前所在季度
			//2.得到季度金额合计
			//3.判断标准添加考虑待摊金额

			DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(iYear ,BudgetDeptcode,ItemName );
			if(ds != null)
			{
				this.lblBudget.Text = ds.Tables[0].Rows[0]["BudgetMoney"].ToString();
				this.lblSumCheck.Text=ds.Tables[0].Rows[0]["CheckMoney"].ToString();
				this.lblready.Text  = ds.Tables[0].Rows[0]["ReadyPay"].ToString();
				this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalOutMoney"].ToString();
				this.lblLeft.Text=ds.Tables[0].Rows[0]["LeftMoney"].ToString();

				//将剩余金额记录到隐藏控件
				this.HiddenLeft.Value = ds.Tables[0].Rows[0]["LeftMoney"].ToString() ; 
			}		
			#endregion 
		}

		private void BindInitAddBody()
		{
			#region 初始化添加表体的下拉控件

			//选定一级科目对应的子科目信息 || 暂时无二级科目 
			string ItemName = this.ddlFirstSubject.SelectedValue;
			int iYear  = DateTime.Today.Year;
			DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));

			string ClassDept = "";

			if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
			{
				ClassDept = dtDeptClass.Rows[0][0].ToString();
			}
			if(!ClassDept.Equals(""))
			{
				DataSet ds = Bussiness.AssetBudgetBll.SelectSubItemByYearAndFirstItem (iYear,ClassDept,ItemName);
				if(ds!=null && ds.Tables.Count > 0 )
				{
					this.ddlSubjectCode.DataSource=ds.Tables[0];
					ddlSubjectCode.DataValueField=ds.Tables[0].Columns["SubjectName"].ToString();
					ddlSubjectCode.DataTextField =ds.Tables[0].Columns["SubjectName"].ToString();
					ddlSubjectCode.DataBind();
					ddlSubjectCode .Items.Insert(0,"");
				}
			}


			//单位

			string cmdStr = "select  * from Base_Unit where isStop <> 1  order by unitName ";

			DataSet Dunits = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);

			if(Dunits!=null && Dunits.Tables.Count > 0 )
			{
				this.ddlUnit.DataSource = Dunits.Tables[0];
				this.ddlUnit.DataValueField = "id";
				this.ddlUnit.DataTextField = "unitName";
				this.ddlUnit.DataBind();
				this.ddlUnit.Items.Insert(0,"");

			}

			//币种

			string cmdStrcurrency = "select currtypecode,currtypeName  from Base_currencyType group by currtypecode,currtypeName";
			DataSet Dcurr = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStrcurrency);
			if(Dcurr != null && Dcurr .Tables.Count > 0 )
			{

				this.ddlcurrTypeCode .DataSource = Dcurr.Tables[0];
				this.ddlcurrTypeCode.DataValueField = "currtypecode";
				this.ddlcurrTypeCode.DataTextField = "currtypeName";
				this.ddlcurrTypeCode.DataBind();
				this.ddlcurrTypeCode.Items.Insert(0,"");
			}

			#endregion 
		}

		private void BindAssetBody(int applyHeadPk)
		{
			#region 绑定表体信息
			string cmdStr = "select * from dbo.v_Asset_ApplySheet_Body where applySheetHead_pk = " +  applyHeadPk.ToString()  + " order by id desc "  ; 

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
			//编辑按钮
			this.btnSave.Enabled = true;
			this.btnEdit.Enabled = false;
			this.btnAdd.Enabled = false;
		}

		private void btnAddBody_Click(object sender, System.EventArgs e)
		{
			// 添加表体
			// this.hideApplyHead.Value  表头值 
			// 检验添加值是否正确
			// 添加 
			this.lbMsg.Text = "";

			if(!IsNumeric(this.tbNumber.Text.Trim()))
			{
				this.lbMsg.Text = "数量不是数字";
				return;
			}
			if(!IsNumeric(this.tbOriginalcurrPrice.Text.Trim()))
			{
				this.lbMsg.Text = "单价不是数字";
				return;
			}
			if(this.ddlUnit.SelectedItem.Text == "")
			{
				this.lbMsg.Text = "单位不能为空";
				return ;
			}
			if(this.ddlcurrTypeCode.SelectedItem.Text == "")
			{
				this.lbMsg.Text = "币种不能为空";
				return ;
			}

			//单据不是新建状态不能添加

			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
			if(ApplyHead == null )
			{
				this.lbMsg.Text = "系统错误，找不到单据！";
				return ;
			}

			string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

			if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
			{
				this.lbMsg.Text = "此单不是新建状态，不能添加！";
				return ;
			}

			Entiy.AssetApplySheetBody AssetBody = new HDSZCheckFlow.Entiy.AssetApplySheetBody();
			AssetBody.ApplySheetHeadPk = int.Parse(this.hideApplyHead.Value);
			AssetBody.SubjectName      = this.ddlSubjectCode.SelectedItem.Text.Trim();
			AssetBody.InventoryName    = this.tbInvName.Text;
			AssetBody.InvType          = this.tbInvType.Text;
			AssetBody.BaseUnitId       = int.Parse(this.ddlUnit.SelectedValue);
			AssetBody.Number           = int.Parse(this.tbNumber.Text.Trim());
			AssetBody.OriginalcurrPrice= decimal.Parse(this.tbOriginalcurrPrice.Text.Trim());
			AssetBody.OriginalMoney    = int.Parse(this.tbNumber.Text.Trim()) * decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) ;
			AssetBody.CurrTypeCode     = this.ddlcurrTypeCode.SelectedValue ;
			AssetBody.ExchangeRate     = SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim());			//利率
			AssetBody.RmbPrice         = decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) *   SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim()) ;    //本币单价
		    AssetBody.RmbMoney         = int.Parse(this.tbNumber.Text.Trim()) * decimal.Parse(this.tbOriginalcurrPrice.Text.Trim()) * SelectRateByCurrCode(this.ddlcurrTypeCode.SelectedValue.Trim()) ;           //本币金额

			AssetBody.Create();
		
			//绑定到表体显示
			BindAssetBody(int.Parse(this.hideApplyHead.Value));

			//计算本单金额，记录余额信息
			BindApplyMoney(int.Parse(this.hideApplyHead.Value));

			//记录本单金额信息

			//本单金额
			decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(this.hideApplyHead.Value));  //本次审批金额
			Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(int.Parse(this.hideApplyHead.Value));
			if(AssetBudget != null )
			{
				AssetBudget.SheetRmbMoney = ApplyMoney;
				AssetBudget.Update();
			}



			//计算可用提交状态

			//int.Parse(this.hideApplyHead.Value)
			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));

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
					this.btnOutBudget.Enabled=false;
					break;
				case 2:
					this.btnInBudget.Enabled=true;
					this.btnOutBudget.Enabled=false;
					break;
				case 3:
					this.btnInBudget.Enabled=false;
					this.btnOutBudget.Enabled=true;
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

			//Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.FindByYearAndMonth(CurrCode,DateTime.Today.Year,1);

			//弃用年月利率。 统一利率。
			Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.Find(CurrCode);
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
			if(e.CommandName.Equals("delete")) //点击审批按钮
			{
				
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
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

				for(int i=0;i<this.dgApply.Items.Count ;i++)
				{
					Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(int.Parse(e.Item.Cells[0].Text.Trim()));
					if(AssetBody != null ) 
					{
						AssetBody.Delete();
					}
				}
				//重新计算本单金额 && 剩余金额
				BindApplyMoney(int.Parse(this.hideApplyHead.Value));
				//绑定到表体显示
				BindAssetBody(int.Parse(this.hideApplyHead.Value));

				//本单金额
				decimal ApplyMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(this.hideApplyHead.Value));  //本次审批金额
				Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(int.Parse(this.hideApplyHead.Value));
				if(AssetBudget != null )
				{
					AssetBudget.SheetRmbMoney = ApplyMoney;
					AssetBudget.Update();
				}

			}

			//更新后重新绑定按钮可用状态
			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));
		}

		private void BindApplyMoney(int ApplyHeadPk)
		{
			#region 计算单据金额 && 剩余金额

			try
			{
				this.lbMsg.Text = "";

				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadPk);

				this.lblSheetMoney.Visible = true;
				this.lblSheetMoney.Text=ThisMoney.ToString();

				decimal thisleft=0;           
				decimal leftMoeny = decimal.Parse(this.HiddenLeft.Value);
				thisleft=leftMoeny-ThisMoney;
				this.lblLeft.Text =  thisleft.ToString("#,###.##");      //剩余金额

				if(thisleft < 0 )
				{
					this.lbMsg.Text = "预算超出，请填写超预算审批单！";
				}

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("AssetAdd.BindApplyMoney",ex.Message);
			}
			#endregion
		}

		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//绑定给定按钮提示信息
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				Button ldeleterecord=(Button)e.Item.Cells[1].Controls[1]; 
				ldeleterecord.Attributes.Add("onclick","javascript:return confirm('您确认删除吗?');"); 
			}

		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			//绑定一级科目.系统当前年 ｜ 当前登录人员部门 
			int iYear = DateTime.Today.Year ;

			DataSet ds = Bussiness.AssetBudgetBll.SelectFirstClassSubjectByYearAndDept(iYear,this.ddlDept.SelectedValue);
			if (ds!=null && ds.Tables.Count > 0 ) 
			{
				this.ddlFirstSubject.DataSource = ds.Tables[0];
				this.ddlFirstSubject.DataValueField = ds.Tables[0].Columns["ItemName"].ToString();
				this.ddlFirstSubject.DataTextField  = ds.Tables[0].Columns["ItemName"].ToString();
				this.ddlFirstSubject.DataBind();
				this.ddlFirstSubject.Items.Insert(0,"");
			}

			//////////////////////////
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


	
	}
}
