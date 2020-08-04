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
using System.Threading;

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ApplySheet 的摘要说明。
	/// </summary>
	public class ApplySheetEdit : System.Web.UI.Page
	{
		#region  属性
		protected XPGrid.XpGrid XPGrid2;
		protected System.Web.UI.WebControls.Button btnPress;
		protected System.Web.UI.WebControls.Button btnInConrt;
		protected System.Web.UI.WebControls.Button btnOutConrt;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Label lblAnnexMsg;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected XPGrid.XpGrid XPGrid1;
		#endregion  
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				//这里改为读配置文件，获取招待申请类型编码(2011-09-09 liyang) 
				string evectionCode = System.Configuration.ConfigurationSettings.AppSettings["Evection"]; //出差
				string banquetCode = System.Configuration.ConfigurationSettings.AppSettings["Banquet"]; //宴请
				string assetCode  = System.Configuration.ConfigurationSettings.AppSettings["Asset"];    //新营

				Utility.RegisterTypeForAjax(typeof(ApplySheet));
				string personCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(HttpContext.Current.User.Identity.Name));
				if( !"".Equals(personCode))
				{
//					查询属于本人的未提交的申请,或者提交没审批的申请  , 排除 出差，宴请，新营 
					string cmdStr="SELECT ApplySheetHead.*  FROM ApplySheetHead INNER JOIN ApplyProcessType ON ApplySheetHead.ApplyProcessCode = ApplyProcessType.ApplyProcessTypeCode " +
												" WHERE (ApplySheetHead.ApplyDeptClassCode =(SELECT superior_Dept_pk " + 
												" FROM Base_Dept WHERE DeptCode =(SELECT DeptCode FROM Base_Person " +
												" WHERE personCode = '" + personCode + "'))) AND " +
												"(ApplySheetHead.IsKeeping <> 1 OR ApplySheetHead.IsKeeping IS NULL)  AND (ApplyProcessType.IsSubmit = 0) and applytypecode not in ('"+evectionCode+"','"+banquetCode+"','" + assetCode + "') " +
												" ORDER BY ApplySheetHead.ApplyDate DESC";
					this.XPGrid1.CommandText=cmdStr;
					
//					else
//					{
//						this.XPGrid1.CommandText="select * from ApplySheetHead where  (IsKeeping !=1 OR IsKeeping IS NULL) order by  ApplyDate desc";
//						this.XPGrid1.DataBind();
//					}
				}

				if(!Page.IsPostBack)
				{

					//目前不需要添加部分
					//InitPageForAdd();
				}
			}
			catch(Exception ex)
			{
				//Response.Write(ex.ToString());
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
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
			this.btnInConrt.Click += new System.EventHandler(this.btnInConrt_Click);
			this.btnOutConrt.Click += new System.EventHandler(this.btnOutConrt_Click);
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.XPGrid1.SelectedIndexChanged += new XPGrid.XpGrid.SelectedIndexChangedEventHandler(this.XPGrid1_SelectedIndexChanged);
			this.XPGrid2.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid2_BeforeUpdateData);
			this.XPGrid2.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XPGrid2_AfterUpdate);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


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
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
				return "";
			}
		}
		#endregion 


		#region 显示部门科目预算情况
		private void BindBudgetInfo(int  key,int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			this.Label2.Visible=true;
			this.Label3.Visible=true;
			this.Label4.Visible=true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			this.Label8.Visible =true;
			this.Label9.Visible =true; 	
			this.Label12.Visible =true;

			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,dept.BudgetDeptCode,Sheetsubject );
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
				if(ds != null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(iYear,iMonth,applyDept,Sheetsubject);

					this.lblBudget.Text=ds.Tables[0].Rows[0]["budgetmoney"].ToString();
					this.lblPush.Text=ds.Tables[0].Rows[0]["planmoney"].ToString();
					this.lblChange.Text=ChangeMoney.ToString("N2");
					this.lblSumCheck.Text=ds.Tables[0].Rows[0]["checkmoney"].ToString();
					this.lblready.Text  = ds.Tables[0].Rows[0]["readypay"].ToString();
					this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
					this.lblAlterMoney.Text =  ds.Tables[0].Rows[0]["alterMoney"].ToString();
					
				
					//费用超支标准，预算或者推算。
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
					decimal leftmoney = 0 ; 
					if (budgetStandard == 1 )  //预算
					{
						leftmoney=decimal.Parse(this.lblBudget.Text) + ChangeMoney + decimal.Parse(this.lblOutMoney.Text) - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text)-ThisMoney ;	
					}
					else if(budgetStandard == 2 ) // 推算
					{
						leftmoney=decimal.Parse(this.lblPush.Text) + ChangeMoney + decimal.Parse(this.lblOutMoney.Text) - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text)-ThisMoney ;	
					}
					this.lblSheetMoney.Text=ThisMoney.ToString("N2");			

					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
					if(applyHead!=null)
					{
						Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
						if(prossType!=null)
						{
							if(prossType.IsSubmit==0)
							{
								this.lblLeft.Text=leftmoney.ToString("N2");
							}
						}
					}
				}
			}

			#region 作废
//			Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(iYear,iMonth,applyDept,Sheetsubject);
//			decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
//			if(budgetAccount!=null)
//			{
//				decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(iYear,iMonth,applyDept,Sheetsubject);
//
//				this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");
//				this.lblPush.Text = budgetAccount.PlanMoney.ToString("#,###.##");
//				this.lblChange.Text=ChangeMoney.ToString("#,###.##");
//				this.lblAdd.Text=budgetAccount.BudgetAddMoney.ToString("#,###.##");
//				this.lblSumCheck.Text=budgetAccount.CheckMoney.ToString("#,###.##");
//				
//				int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today );
//				decimal leftmoney = 0 ; 
//				if (budgetStandard == 1 )  //预算
//				{
//					leftmoney=budgetAccount.BudgetMoney + ChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;	
//				}
//				else if(budgetStandard == 2 ) // 推算
//				{
//					leftmoney=budgetAccount.PlanMoney + ChangeMoney  - budgetAccount.CheckMoney-ThisMoney ;	
//				}
//
//
//				this.lblSheetMoney.Text=ThisMoney.ToString("#,###.##");
//				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
//				if(applyHead!=null)
//				{
//					Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//					if(prossType!=null)
//					{
//						if(prossType.IsSubmit==0)
//						{
//							this.lblLeft.Text=leftmoney.ToString("#,###.##");
//						}
//						else
//						{
//							Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
//							if(applyBudget!=null)
//							{
//								//decimal left=budgetAccount.BudgetMoney + budgetAccount.BudgetChangeMoney + budgetAccount.BudgetAddMoney-applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
//								decimal left=budgetAccount.PlanMoney + ChangeMoney -applyBudget.SheetMoney-applyBudget.SumCheckMoney ;
//								this.lblLeft.Text=left.ToString("#,###.##");
//								this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");
//							}
//						}
//					}
//				}
//			}
			#endregion 
		}

		#endregion 

		private void XPGrid1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				#region 选中单据头，填写单据信息

				if(XPGrid1.GetEditState() == XPGrid.CEditState.NotInEdit)
				{
					string[] keys = this.XPGrid1.GetSelectedKey();
					if(keys == null || keys.Length == 0)
					{
						return;
					}
//					this.XPGrid2 .Visible=true;
//					this.XPGrid2.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk =" + keys[0] + " order by InventoryName asc";
//					this.XPGrid2.DataBind();

					//判断排头哪些按钮可用 ,紧急按钮不判断，预算内判断金额，预算外判断，取回单据判断是否被驳回 or 还未有人审批
					SetButtonEnable(int.Parse(keys[0]));
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
					Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));

					if(applyHead!=null && applyBudget!=null)
					{
						BindBudgetInfo(int.Parse(keys[0]),applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);//显示部门科目预算情况

						// 根据申请但类型, 判断表体采用的表 , 用以区分实物类,非实物类申请
						//
						//找到相关表体  ApplyType  申请单据类型表
						Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						if(applyTypes !=null )
						{
							this.XPGrid2 .Visible=true;
							this.XPGrid2.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
							this.XPGrid2.DataBind();
						}
					}

					//添加附件可用
					this.hyLindToAnnex.Visible=true;
					this.hyLindToAnnex.Target = "_blank";
					this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=ApplySheetEdit.aspx&ApplyHeadPk=" + keys[0]   ;
				}
				else
				{
					this.XPGrid2.Visible=false;
					this.hyLindToAnnex.Visible=false;
				}
				#endregion 
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}
		}


		#region 判断哪些按钮可用
		private void SetButtonEnable(int key)
		{			
			// 1 紧急审批可用， < 3000 
			// 2 预算内可用
			// 3 预算外可用
			// 4 紧急 and 预算内 可用
			// 5 紧急 and 预算外 可用
			// 6 已所定，全不可用
			// 7 没有表体，不可用
			// 8 出现错误
			// Na==1 驳回可用 Na==2  封存可用
			int Na;
			int i=Bussiness.ApplySheetHeadBLL.SetButtonEnable(key,out Na);

			switch(i)
			{
				case 2:
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					this.btnPress.Enabled=false;
					break;
				case 3:
					this.btnOutConrt.Enabled=true;
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					break;
				case 4:
					this.btnPress.Enabled=true;
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					break;
				case 5:
					this.btnPress.Enabled=true;
					this.btnOutConrt.Enabled=true;
					this.btnInConrt.Enabled=false;
					break;
				case 6:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 7:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 8:
					this.btnPress.Enabled=false;
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
			}
		}

		#endregion 

		private void XPGrid2_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			#region 添加记录时，系统维护插入的表头主键
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )  //不是新建状态  或者 设有预算外审批 都是锁定标准
					{
						XPGrid2.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//给表头主键 赋值
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )   //不是新建状态  或者 设有预算外审批 都是锁定标准
					{
						XPGrid2.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql,"APPLYSHEETHEAD_PK",keys[0]))
				{
					XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
					continueUpdate=false;
				}	

				
				Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applySheet.ApplyTypeCode);   
				if(applyTypes !=null )
				{
					//购买类的时候,给总金额附值(用于区分报销类以及日后其他类别的处理)
					if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
					{
						#region 
						//给总金额附值，本币单价附值
						decimal number=0;                 //数量
						decimal orPrice=0;　　　　　　　　//原币单价
						string  bizhong="";				  //币种　，通过币种得到，汇率,计算本币单价，总金额
						string inventycode = "";          //存货编码

						for (int i = 0; i <= XPGrid2.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid2.FieldList[i]; 
							object ob = XPGrid2.GetInputControlValue(F); 
							if (F.ColName == "NUMBER") 
							{ 
								number = System.Convert.ToDecimal(ob); 
							} 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob); 
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob); 
							} 
							if (F.ColName == "INVENTORYCODE")           //存货编码 InventoryCode
							{ 
								inventycode  = System.Convert.ToString(ob); 
							} 
						} 

						Entiy.ApplySheetHeadBudget applyBudget  = Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
						if(applyBudget!=null)
						{
							string budgetSubject = applyBudget.SheetSubject ;    // 预算科目
							int nums = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubject(budgetSubject);  //预算科目进行了控制
							if (nums > 0 )
							{
								// 取前三位
//								int nums2 = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubjectAndAccount(budgetSubject,inventycode.Substring(0,3));      // 找不到控制的存货编码

								//2012-07-06 改写到 p_Apply_ControlPurchaseCode，放开控制位数
								string cmdStr = "exec p_Apply_ControlPurchaseCode  '" + budgetSubject + "','" + inventycode +"'" ;
								int nums2 = Bussiness.ComQuaryBLL.GetExecuteScalar(cmdStr); 

								if (nums2 == 0 )
								{
									XPGrid2.ShowMessage("对不起，购买物品不属于申请科目！",System.Drawing.Color.Red);
									continueUpdate=false;							
								}
							}
						}
						else
						{
							XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
							continueUpdate=false;								
						}

						Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
						if(currType!=null)
						{
							decimal TotalMoney=number * currType.ExchangeRate * orPrice;          //总金额

							if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
							{
								XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							decimal RmbMoney=currType.ExchangeRate * orPrice ;                     //本币单价
							if (!MyChgSql.ChgResultSql(ref ResultSql,"RMBPRICE",RmbMoney.ToString()))
							{
								XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
							{
								XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
						}
						else                       //币种有误
						{
							XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
							continueUpdate=false;
						}	
						#endregion 
					}
					else if("ApplySheetBody_Pay".Equals(applyTypes.ApplySheetBodyTableName))
					{
						//报销类以及日后其他类别的处理
						#region 

						//给总金额附值，本币单价附值
				
						decimal orPrice=0;　　　　　　　　//原币金额
						string  bizhong="";				  //币种　，通过币种得到，汇率,计算本币单价，总金额


						for (int i = 0; i <= XPGrid2.FieldList.Count - 1; i++) 
						{ 
							XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid2.FieldList[i]; 
							object ob = XPGrid2.GetInputControlValue(F); 
							if (F.ColName == "CURRTYPECODE") 
							{ 
								bizhong = System.Convert.ToString(ob);   //币种
							} 
							if (F.ColName == "ORIGINALCURRPRICE") 
							{ 
								orPrice  = System.Convert.ToDecimal(ob);  //原币金额
							} 
						} 
						Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
						if(currType!=null)
						{
							decimal TotalMoney= currType.ExchangeRate * orPrice;          //RMB 金额

							if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
							{
								XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
							if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
							{
								XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
								continueUpdate=false;
							}
						}
						else                       //币种有误
						{
							XPGrid2.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
							continueUpdate=false;
						}	
						#endregion 

					}
					
				}
			}
			#endregion
		}
	
		#region  提交紧急审批
		private void btnPress_Click(object sender, System.EventArgs e)
		{
			//紧急审批
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			
			Entiy.CheckFlowInCompanyhead checkFlow=Entiy.CheckFlowInCompanyhead.FindByFlowCode("jinji"); //紧急流程Code ,,改为判断流程标识 3 !!!!!
			if(checkFlow!=null)
			{
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applyHead!=null)
				{				
					//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
//					string Message="";
//					int CheckStep=0,DeptToCompany=0 ;
//					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
					string Message="",	NextCheckCode ="";
					int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
					string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
					if(IsGiveUp ==1 )
					{
						//此用户放弃审批,循环调用方法本身;
						Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
						Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//						Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
					}
					#region 
					else if(!"".Equals(checkRole))
					{
					 
						applyHead.CurrentCheckRole=checkRole;

						applyHead.CheckFlowInCompanyHeadPk =checkFlow.CheckFlowInCompanyHeadPk ;

						applyHead.CheckSetp=CheckStep;
						
						applyHead.Update();

						//						// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 
						//
						//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
						//								
						//						//根据工号发邮件            发邮件(方法2)
						//
						//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

						//发送邮件
//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
						Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
						Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//						//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//						mailBll.ThreadSendMail();
//						

						updatePross(int.Parse(keys[0]));

						//提交既占预算，更新预算表的已占用预算额
						Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
						if(applyHeadBudget!=null )
						{
							Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
							decimal tempMoney=budgetAccount.CheckMoney ;
							budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
							
							budgetAccount.Update();
							applyHeadBudget.SumCheckMoney = tempMoney ;
							string submitType=System.Configuration.ConfigurationSettings.AppSettings["PressType"];
							applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急
							applyHeadBudget.Update();
						}

					}
					else
					{
						this.lblMsg.Text="没有设置相关审批角色";
						HDSZCheckFlow.Common.Log.Logger.Log("提交紧急审批","没有找到相关审批角色");
					}
					#endregion  
				}
			}
			else
			{
				this.lblMsg.Text="未设置相关审批流程!!!!";
			}

			SetButtonEnable(int.Parse(keys[0]));

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


		#region 提交预算内审批
		private void btnInConrt_Click(object sender, System.EventArgs e)
		{
//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
//			{
				try
				{
					//预算内审批 , 更新状态
					string[] keys = this.XPGrid1.GetSelectedKey();
					if(keys == null || keys.Length == 0)
					{
						return;
					}

					//更新流程信息
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
					if(applyHead!=null)
					{
						// 先看单据是否已经是提交状态
						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
						{
							this.lblMessage .Text = "此单已经提交过!请不要重复提交";
							return ;
						}

						/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
						///

						DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));
						if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
						{
							this.lblMessage.Text ="此单余额信息有误，不能提交";
							return;
						}
							

							

						///////////////////////////////////////////END////////////////////////////////////////////////////

						#region 
						decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //本次审批金额


						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
						if(TypeInFlow!=null)
						{
							//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
//							string Message="";
//							int CheckStep=0,DeptToCompany=0 ;
//							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);

							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
							if(!"".Equals(checkRole))
							{
								applyHead.CurrentCheckRole=checkRole;
								applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								applyHead.CheckSetp=CheckStep;
								applyHead.Update();

								//						// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 
								//
								//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								//							
								//						//根据工号发邮件            发邮件(方法2)
								//
								//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

								//发送邮件
								//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//								//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//								mailBll.ThreadSendMail();

								updatePross(int.Parse(keys[0]));   //更新流程状态

								//提交既占预算，更新预算表的已占用预算额
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									//decimal tempMoney=budgetAccount.CheckMoney ;
									Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
									DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

									decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;


									decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //允许的预算外金额
									ds = null; 

									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
						
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// InCorntType
									applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

									applyHeadBudget.Update();
								}
							}
							else
							{
								this.lblMsg.Text="没有找到相关审批角色";
								HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
							}

										
							if(IsGiveUp ==1 )
							{
								//此用户放弃审批,循环调用方法本身;
								Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
								Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);


//								Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
							}
							else
							{
								//根据工号发邮件            发邮件(方法2)
								

								
								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//
//								mailBll.ThreadSendMail();
							}
					
						}
						else
						{
							this.lblMsg.Text="未设置相关流程!!!!!";
						}
						#endregion 
					}
//					tran.VoteCommit();
					SetButtonEnable(int.Parse(keys[0]));
				}
				catch(Exception ex)
				{
//					tran.VoteRollBack();
					Common.Log.Logger.Log("applyedit.btnInConrt_Click",ex.Message );
				}
//			}

		}
		#endregion  

		#region  提交预算外审批 
		private void btnOutConrt_Click(object sender, System.EventArgs e)
		{
//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
//			{
				try
				{
					//预算外审批
					string[] keys = this.XPGrid1.GetSelectedKey();
					if(keys == null || keys.Length == 0)
					{
						return;
					}

					//更新流程信息
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
					if(applyHead!=null)
					{
						// 先看单据是否已经是提交状态
						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
						{
							this.lblMessage .Text = "此单已经提交过!请不要重复提交";
							return ;
						}

						/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
						///

						DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(int.Parse(keys[0]));
						if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
						{
							this.lblMessage.Text ="此单余额信息有误，不能提交";
							return;
						}
							

							



						///////////////////////////////////////////END////////////////////////////////////////////////////

						#region 
						Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(int.Parse(keys[0]));
			
						decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));  //本次审批金额


						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
						if(TypeInFlow!=null)
						{
							//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
//							string Message="";
//							int CheckStep=0,DeptToCompany=0 ;
//							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
							if(!"".Equals(checkRole) )
							{
								applyHead.CurrentCheckRole=checkRole;
					
								applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;

								applyHead.CheckSetp=CheckStep;

								applyHead.Update();

								//						// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 
								//
								//						string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								//							
								//						//根据工号发邮件            发邮件(方法2)
								//
								//						Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

								//发送邮件
								//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//								//ThreadSendMail(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
//								mailBll.ThreadSendMail();


								updatePross(int.Parse(keys[0]));

								//提交既占预算，更新预算表的已占用预算额
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									//decimal tempMoney=budgetAccount.CheckMoney ;
									Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
									DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

									decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
									ds = null; 
									dept = null;
									//decimal AllowOutMoney = budgetAccount.TotalAllowOutMoney;   //允许的预算外金额

									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// OutCorntType

									//applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

									applyHeadBudget.Update();
								}

											
								if(IsGiveUp ==1 )
								{
									//此用户放弃审批,循环调用方法本身;

									Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
									Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

//									Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
								}
								else
								{
									//根据工号发邮件            发邮件(方法2)
								
//
//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//
//									mailBll.ThreadSendMail();
								}

							}
							else
							{
								this.lblMsg.Text="没有找到相关审批角色";
								HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
							}
						}
						else
						{
							this.lblMsg.Text="未设置相关流程!!!!!";
						}
						#endregion 
					}
				//	tran.VoteCommit();
					SetButtonEnable(int.Parse(keys[0]));
				}
				catch(Exception ex)
				{
					//tran.VoteRollBack();
					Common.Log.Logger.Log("applyedit.btnOutConrt_Click",ex.Message );
				}
			//}

		}
		#endregion  

		private void RemoveBudget(int key)
		{
			//更新预算表的已占用预算额,
			Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
			Entiy.ApplySheetHead  applyHead=Entiy.ApplySheetHead.Find(key);
			if(applyHeadBudget!=null &&  applyHead!=null)
			{
				Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
				budgetAccount.CheckMoney = budgetAccount.CheckMoney - applyHeadBudget.SheetMoney;
				budgetAccount.Update();
				applyHeadBudget.SumCheckMoney = 0 ;
			
				applyHeadBudget.SubmitType = 0 ;// OutCorntType
				applyHeadBudget.Update();
			}
		}


		private void XPGrid2_AfterUpdate(object sender, XPGrid.CUpdateType updateType, string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			string[] keys = this.XPGrid1.GetSelectedKey();
			if(keys == null || keys.Length == 0)
			{
				return;
			}
			SetButtonEnable(int.Parse(keys[0]));

			//更新本张单金额
			decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(int.Parse(keys[0]));
			Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));
			if(applyHeadBudget!=null)
			{
				applyHeadBudget.SheetMoney=ThisMoney; //本次累计金额
				applyHeadBudget.Update();
			}
			else
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet","找不到applyHeadBudget" + keys[0].ToString() );
			}
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
			Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(keys[0]));

			if(applyHead!=null && applyBudget!=null)
			{
				BindBudgetInfo(int.Parse(keys[0]),applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);//显示部门科目预算情况
			}
		}


		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			if(updateType==XPGrid.CUpdateType.Delete)
			{
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0 || applyPross.IsSubmitAgain==1 || applySheet.IsOverBudget ==1 )
					{
						XPGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}
			}
			if(updateType!=XPGrid.CUpdateType.Delete)
			{
				//判断单据状态，是否能编辑
				string[] keys = this.XPGrid1.GetSelectedKey();
				if(keys == null || keys.Length == 0)
				{
					continueUpdate=false;
					return;
				}
				Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(int.Parse(keys[0]));
				if(applySheet!=null )
				{
					Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
					if(applyPross.IsSubmit!=0 || applySheet.IsOverBudget == 1 )
					{
						XPGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
				}

				#region 维护单据号
				string applyNo="";
				string applyType="";
				DateTime  applyDate=new DateTime();

				for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
				{ 
					XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
					object ob = XPGrid1.GetInputControlValue(F); 
					if (F.ColName == "APPLYTYPECODE") 
					{ 
						applyType = System.Convert.ToString (ob); 
					} 
					if (F.ColName == "APPLYDATE") 
					{ 
						applyDate = System.Convert.ToDateTime(ob); 
					} 
				} 
				#region 生成单据号
				//1.取前缀
				Entiy.ApplyType applyTyp=Entiy.ApplyType.Find(applyType);
				if(applyTyp!=null)
				{
					applyNo=applyTyp.ApplySheetEncode ;
				}
				else
				{
					Page.RegisterClientScriptBlock("a","<scrpit language='JavaScript'>alert('生成单据号错误!');</scrpit>");
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

				//当修改后的前缀,与之前的前缀相同时,流水号不变 
				string sheetNO=applySheet.ApplySheetNo ;
				string per=sheetNO.Substring(0,sheetNO.Length-5);
				if(applyNo.Equals(per))
				{
					applyNo=applySheet.ApplySheetNo;
				}
				else
				{
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
				}
				#endregion 

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql," APPLYSHEETNO","'" + applyNo.ToString() + "'"))
				{
					XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
					continueUpdate=false;
				}	
				#endregion 
			}
		}






	
	
		
	

	

	}
}
