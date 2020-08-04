//	
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

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// AddApplySheet 的摘要说明。
	/// </summary>
	public class AddApplySheetNew : System.Web.UI.Page
	{
		#region  属性
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected System.Web.UI.WebControls.DropDownList ddlDeptClass;
		protected System.Web.UI.WebControls.DropDownList ddlDept;
		protected System.Web.UI.WebControls.DropDownList ddlSubject;
		protected System.Web.UI.WebControls.TextBox txtPerson;
		protected System.Web.UI.WebControls.TextBox txtPersonName;
		protected System.Web.UI.WebControls.Button btnAdd;
		protected System.Web.UI.WebControls.Label lblMessage;
		protected XPGrid.XpGrid XPGrid1;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;//记录此次添加的表头PK
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.WebControls.Button btnOutConrt;
		protected System.Web.UI.WebControls.Button btnInConrt;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label Label2;
		protected System.Web.UI.WebControls.Label Label3;
		protected System.Web.UI.WebControls.Label Label4;
		protected System.Web.UI.WebControls.Label Label5;
		protected System.Web.UI.WebControls.Label Label6;
		protected System.Web.UI.WebControls.Label Label7;
		protected System.Web.UI.WebControls.DropDownList ddlFirstSubject;
		protected System.Web.UI.WebControls.DropDownList ddlApplyType;
		protected System.Web.UI.WebControls.HyperLink hyLindToAnnex;
		protected System.Web.UI.WebControls.Label lblAnnexMsg;
		protected System.Web.UI.WebControls.Label Label8;
		protected System.Web.UI.WebControls.Label lblPush;
		protected System.Web.UI.WebControls.Button btnEdit;
		protected System.Web.UI.WebControls.Button btnSave;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		protected System.Web.UI.WebControls.Label Label9;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenLeft;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.TextBox txtDeliveryDate;
		protected System.Web.UI.WebControls.Label Label11;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.Label Label12;
		protected System.Web.UI.WebControls.Label lblAlterMoney;
		protected System.Web.UI.WebControls.Label lblMsg;
		protected System.Web.UI.WebControls.Label Label10;
		//private static decimal leftMoney= 0 ;
		#endregion  

	
		private void Page_Load(object sender, System.EventArgs e)
		{
			Utility.RegisterTypeForAjax(typeof(AddApplySheet));
		
			if(!Page.IsPostBack)
			{
				#region 

				this.ddlApplyType.Enabled = false;
				this.ddlDept.Enabled = false ;
				this.ddlDeptClass.Enabled =false; 
				this.ddlFirstSubject.Enabled= false ;
				this.ddlSubject.Enabled = false ;
				this.txtDate.Enabled = false ;
				this.txtPerson.Enabled=false ;
				this.txtDeliveryDate.Enabled =false; 

				this.ddlApplyType.BackColor= Color.LightGray;
				this.ddlDept.BackColor = Color.LightGray;
				this.ddlDeptClass.BackColor = Color.LightGray;
				this.ddlFirstSubject.BackColor=  Color.LightGray;
				this.ddlSubject.BackColor =  Color.LightGray;
				this.txtDate.BackColor =  Color.LightGray;
				this.txtPerson.BackColor= Color.LightGray;
				this.txtPersonName.BackColor = Color.LightGray;
				this.txtDeliveryDate.BackColor=Color.LightGray;

				this.btnSave.Enabled=false;
				this.btnEdit.Enabled=false;

				#endregion 

				InitPageForAdd();
			}
		}
		
		#region  初始化下拉菜单
		private void InitPageForAdd()
		{
			try
			{
				//为下拉控件附值
				string deptClassCode=Bussiness.UserInfoBLL.GetUserClassDept (User.Identity.Name);
				DataTable dtType=Bussiness.ApplySheetHeadBLL.GetApplyTypeNon (deptClassCode);
				if(dtType!=null && dtType.Rows.Count>0)
				{
					this.ddlApplyType.DataSource =dtType;
					ddlApplyType.DataValueField=dtType.Columns[0].ToString();
					ddlApplyType.DataTextField=dtType.Columns [1].ToString();

					ddlApplyType.DataBind();
					ddlApplyType.Items.Insert(0,"");
					dtType=null;
				}

				DataTable dtDeptClass=Bussiness.CheckFlowInDeptBLL.GetDeptForUserID(int.Parse(HttpContext.Current.User.Identity.Name));
				if(dtDeptClass!=null && dtDeptClass.Rows.Count>0)
				{
					this.ddlDeptClass.DataSource=dtDeptClass;
					ddlDeptClass.DataValueField=dtDeptClass.Columns[0].ToString();
					ddlDeptClass.DataTextField =dtDeptClass.Columns[1].ToString();
					ddlDeptClass.DataBind();
					ddlDeptClass.Items.Insert(0,"");
				}

				//				string budgetDept = Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
				//				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(budgetDept); //一级科目
				//				if(dtSubject!=null && dtSubject.Rows.Count >0)
				//				{
				//					this.ddlFirstSubject.DataSource=dtSubject;
				//					ddlFirstSubject.DataValueField=dtSubject.Columns[0].ToString();
				//					ddlFirstSubject.DataTextField =dtSubject.Columns[1].ToString();
				//					ddlFirstSubject.DataBind();
				//					ddlFirstSubject.Items.Insert(0,"");
				//				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message );
			}

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
			this.ddlApplyType.SelectedIndexChanged += new System.EventHandler(this.ddlApplyType_SelectedIndexChanged);
			this.ddlDeptClass.SelectedIndexChanged += new System.EventHandler(this.ddlDeptClass_SelectedIndexChanged);
			this.ddlDept.SelectedIndexChanged += new System.EventHandler(this.ddlDept_SelectedIndexChanged);
			this.ddlFirstSubject.SelectedIndexChanged += new System.EventHandler(this.ddlFirstSubject_SelectedIndexChanged);
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.XPGrid1.AfterUpdate += new XPGrid.XpBaseClass.AfterUpdateEventHandler(this.XPGrid1_AfterUpdate);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			//this.Hidden2 是否为修改
			this.Hidden2.Value= "0" ;

			#region 
			this.ddlApplyType.SelectedIndex  = 0 ;
			//this.ddlDept.SelectedIndex  = 0 ;
			this.ddlDeptClass.SelectedIndex  =0; 
			//this.ddlFirstSubject.SelectedIndex = 0 ;
			//this.ddlSubject.SelectedIndex  = 0 ;
			this.txtDate.Text  = "" ;
			this.txtPerson.Text ="" ;
			this.txtDeliveryDate.Text="" ;
			this.Label9.Text= "";
			this.Label10.Text="";

			this.ddlApplyType.Enabled = true ;
			this.ddlDept.Enabled = true ;
			this.ddlDeptClass.Enabled =true; 
			this.ddlFirstSubject.Enabled= true ;
			this.ddlSubject.Enabled = true ;
			this.txtDate.Enabled = true ;
			this.txtPerson.Enabled=true ;
			this.txtDeliveryDate.Enabled=true; 

			this.ddlApplyType.BackColor= Color.White ;
			this.ddlDept.BackColor =Color.White ;
			this.ddlDeptClass.BackColor = Color.White ;
			this.ddlFirstSubject.BackColor=  Color.White;
			this.ddlSubject.BackColor =  Color.White;
			this.txtDate.BackColor =  Color.White;
			this.txtPerson.BackColor= Color.White;
			this.txtDeliveryDate.BackColor=Color.White;

			this.lblBudget.Text="";
			this.lblPush.Text="";
			this.lblChange.Text="";
			this.lblSumCheck.Text="";
			this.lblSheetMoney.Text="";
			this.lblLeft.Text="";

			this.btnAdd.Enabled=false;
			this.btnEdit.Enabled=false;
			this.btnSave.Enabled=true;

			#endregion 
	
		}


		//显示部门科目预算情况
		private void BindBudgetInfo(int iYear,int iMonth,string applyDept,string Sheetsubject)
		{
			
			#region 
			this.Label2.Visible=true;
			this.Label3.Visible=true;
			this.Label4.Visible =true;
			this.Label5.Visible=true;
			this.Label6.Visible=true;
			this.Label7.Visible=true;
			this.Label8.Visible=true;
			this.Label11.Visible = true;
			this.Label12.Visible =true;
			#endregion 
			// 更改为按季度为判断标准
			//1.根据申请月份，得出当前所在季度
			//2.得到季度金额合计
			//3.判断标准添加考虑待摊金额
			Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyDept);
			if(dept!=null && dept.BudgetDeptCode!=null)
			{
				
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,dept.BudgetDeptCode,Sheetsubject );
				if(ds != null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(iYear,iMonth,applyDept,Sheetsubject);

					this.lblBudget.Text=ds.Tables[0].Rows[0]["budgetmoney"].ToString();
					this.lblPush.Text=ds.Tables[0].Rows[0]["planmoney"].ToString();
					this.lblChange.Text=ChangeMoney.ToString("N2") ; 
					this.lblSumCheck.Text=ds.Tables[0].Rows[0]["checkmoney"].ToString();
					this.lblready.Text  = ds.Tables[0].Rows[0]["readypay"].ToString();
					this.lblOutMoney.Text  = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString();
					this.lblAlterMoney.Text = ds.Tables[0].Rows[0]["alterMoney"].ToString();
				
					//					//费用超支标准，预算或者推算。
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
					decimal leftmoney = 0 ; 
					if (budgetStandard == 1 )  //预算
					{
						leftmoney=decimal.Parse(this.lblBudget.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text)  -decimal.Parse(this.lblready.Text);
					}
					else if(budgetStandard == 2 ) // 推算
					{
						leftmoney=decimal.Parse(this.lblPush.Text)  + ChangeMoney + decimal.Parse(this.lblOutMoney.Text)  - decimal.Parse(this.lblSumCheck.Text) -decimal.Parse(this.lblready.Text);
					}
					this.lblLeft.Text=leftmoney.ToString("#,###.##");
					//给全局变量 
					this.HiddenLeft.Value= leftmoney.ToString();
				}
			}

			#region  作废
			//			Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(iYear,iMonth,applyDept,Sheetsubject);
			//			if(budgetAccount!=null)
			//			{				
			//				decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(iYear,iMonth,applyDept,Sheetsubject);
			//
			//				this.lblBudget.Text=budgetAccount.BudgetMoney.ToString();
			//				this.lblPush.Text=budgetAccount.PlanMoney .ToString("#,###.##");
			//				this.lblChange.Text=ChangeMoney.ToString("#,###.##");
			//				this.lblSumCheck.Text=budgetAccount.CheckMoney.ToString("#,###.##");
			//				
			//				//费用超支标准，预算或者推算。
			//				int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(DateTime.Today);
			//				decimal leftmoney = 0 ; 
			//				if (budgetStandard == 1 )  //预算
			//				{
			//					leftmoney=budgetAccount.BudgetMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				else if(budgetStandard == 2 ) // 推算
			//				{
			//					leftmoney=budgetAccount.PlanMoney  + ChangeMoney - budgetAccount.CheckMoney ;
			//				}
			//				this.lblLeft.Text=leftmoney.ToString("#,###.##");
			//				//leftMoney = leftmoney ;  //给全局变量 
			//				this.HiddenLeft.Value= leftmoney.ToString();
			//			}
			#endregion 
		}


		#region 绑定科组
		private void ddlDeptClass_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//绑定科组
			this.ddlDept.Items.Clear();
			string deptClass=this.ddlDeptClass.SelectedValue;
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
		}
		#endregion 

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			try
			{
				#region 添加记录时，系统维护插入的表头主键
				if(updateType==XPGrid.CUpdateType.Delete)
				{
					if(!"".Equals(this.Hidden1.Value))
					{
						int key=int.Parse(this.Hidden1.Value); 
						Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
						if(applySheet!=null )
						{
							Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
							if(applyPross.IsSubmit!=0)
							{
								XPGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
								continueUpdate=false;
								return ;
							}
						}
					}
					else
					{
						XPGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;

					}
				}
				if(updateType!=XPGrid.CUpdateType.Delete)
				{
					//给表头主键 赋值
					if(!"".Equals(this.Hidden1.Value))
					{
						int key=int.Parse(this.Hidden1.Value); 
						Entiy.ApplySheetHead  applySheet=Entiy.ApplySheetHead.Find(key);
						if(applySheet!=null )
						{
							Entiy.ApplyProcessType applyPross=Entiy.ApplyProcessType.Find(applySheet.ApplyProcessCode);
							if(applyPross.IsSubmit!=0)
							{
								XPGrid1.ShowMessage("对不起，此单处于锁定状态！",System.Drawing.Color.Red);
								continueUpdate=false;
								return ;
							}
						}

						ChgSql MyChgSql=new ChgSql();
						if (!MyChgSql.ChgResultSql(ref ResultSql,"APPLYSHEETHEAD_PK",key.ToString()))
						{
							XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
							continueUpdate=false;
						}	


						//购买类的时候,给总金额附值(用于区分报销类以及日后其他类别的处理)
						Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applySheet.ApplyTypeCode);   
						if(applyTypes !=null )
						{
							if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
							{		
								#region 
								//给总金额附值，本币单价附值
								decimal number=0;                 //数量
				
								decimal orPrice=0;　　　　　　　　//原币单价
								string  bizhong="";				  //币种　，通过币种得到，汇率,计算本币单价，总金额
								string inventycode = "";          //存货编码

								for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
								{ 
									XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
									object ob = XPGrid1.GetInputControlValue(F); 
									if (F.ColName == "NUMBER")                  //数量
									{ 
										number = System.Convert.ToDecimal(ob); 
									} 
									if (F.ColName == "CURRTYPECODE")            //币种
									{ 
										bizhong = System.Convert.ToString(ob); 
									} 
									if (F.ColName == "ORIGINALCURRPRICE")       //原币单价
									{ 
										orPrice  = System.Convert.ToDecimal(ob); 
									} 
									if (F.ColName == "INVENTORYCODE")           //存货编码 InventoryCode
									{ 
										inventycode  = System.Convert.ToString(ob); 
									} 

								} 

								
								//2014-03-20 更改。由存货编码 更新 币种、价格 信息。－－－－－－－－－－－－－－－－ 


								// 获取此存货编码的 币种、价格 
								//string cmdStrPrice = "select ISNULL(RealCurrTypeCode,CurrTypeCode ) as currTypeCode,ISNULL(RealOriginalcurPrice,OriginalcurPrice ) as OriginalcurPrice   from dbo.Base_inventory where inv_pk = '" + inventycode.Trim() + "'";
								string cmdStrPrice = "select RealCurrTypeCode as currTypeCode,RealOriginalcurPrice  as OriginalcurPrice   from dbo.Base_inventory where inv_pk = '" + inventycode.Trim() + "'";


								DataSet dsPrice = Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStrPrice) ;

								if(dsPrice != null && dsPrice.Tables.Count > 0 && dsPrice.Tables[0].Rows.Count > 0 )
								{
									//-------------------------- (liyang 2014-08-08)-----过滤原币单价为0的数据----------------------
									string orPriceStr=dsPrice.Tables[0].Rows[0]["OriginalcurPrice"].ToString();
									if(orPriceStr=="" || orPriceStr.Trim().Length==0) //原币单价不能为0
									{
										XPGrid1.ShowMessage("此物料没有维护单价！",System.Drawing.Color.Red);
										continueUpdate=false;
										return;
									}
									else
									{
										orPrice = decimal.Parse(dsPrice.Tables[0].Rows[0]["OriginalcurPrice"].ToString().Trim());
									}
									//--------------------------------------------------------------------------------

									bizhong = dsPrice.Tables[0].Rows[0]["currTypeCode"].ToString();

								}
								else    //没找到单价信息
								{
									XPGrid1.ShowMessage("对不起，此物料编码单价信息错误！",System.Drawing.Color.Red);
									continueUpdate=false;
								}		
								//－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－－





								string budgetSubject = this.ddlSubject.SelectedValue;    // 预算科目
								int nums = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubject(budgetSubject);  //预算科目进行了控制
								if (nums > 0 )
								{
									// 取前三位
									//									int nums2 = Entiy.BaseSubjectInBudgetAllow.FindCountByBudgetSubjectAndAccount(budgetSubject,inventycode.Substring(0,3));      // 找不到控制的存货编码
									//2012-07-06 改写到 p_Apply_ControlPurchaseCode，放开控制位数
									string cmdStr = "exec p_Apply_ControlPurchaseCode  '" + budgetSubject + "','" + inventycode +"'" ;
									int nums2 = Bussiness.ComQuaryBLL.GetExecuteScalar(cmdStr); 
									
									if (nums2 == 0 )
									{
										XPGrid1.ShowMessage("对不起，购买物品不属于申请科目！",System.Drawing.Color.Red);
										continueUpdate=false;							
									}
								}

								Entiy.BasecurrencyType currType=Entiy.BasecurrencyType.Find(bizhong);
								if(currType!=null)
								{
									decimal TotalMoney=number * currType.ExchangeRate * orPrice;          //总金额

									if (!MyChgSql.ChgResultSql(ref ResultSql,"MONEY",TotalMoney.ToString()))
									{
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
										continueUpdate=false;
									}
									decimal RmbMoney=currType.ExchangeRate * orPrice ;                     //本币单价
									if (!MyChgSql.ChgResultSql(ref ResultSql,"RMBPRICE",RmbMoney.ToString()))
									{
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
										continueUpdate=false;
									}
									if (!MyChgSql.ChgResultSql(ref ResultSql,"EXCHANGERATE",currType.ExchangeRate.ToString()))
									{
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
										continueUpdate=false;
									}
									//originalcurrPrice
									if (!MyChgSql.ChgResultSql(ref ResultSql,"ORIGINALCURRPRICE",RmbMoney.ToString()))
									{
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
										continueUpdate=false;
									}
									if (!MyChgSql.ChgResultSql(ref ResultSql,"CURRTYPECODE","'" + bizhong.ToString() + "'")) // 币种
									{
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
										continueUpdate=false;
									}

								}
								else                       //币种有误
								{
									XPGrid1.ShowMessage("对不起，币种错误！",System.Drawing.Color.Red);
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


								for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
								{ 
									XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
									object ob = XPGrid1.GetInputControlValue(F); 
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
										XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
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
									XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
									continueUpdate=false;
								}	
								#endregion 

							}
						}
					}
				}
				#endregion
			}
			catch(Exception ex)
			{
				Response.Write(ex.Message) ;
			}
		}

		private void SetButtonsEnable(int key)
		{			
			// 1 紧急审批可用， < 3000 
			// 2 预算内可用
			// 3 预算外可用
			// 4 紧急 and 预算内 可用
			// 5 紧急 and 预算外 可用
			// 6 已所定，全不可用
			// 7 没有表体，不可用
			// 8 出现错误
			int Na;
			int i=Bussiness.ApplySheetHeadBLL.SetButtonEnable(key,out Na);
			switch(i)
			{
				case 2:
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					
					break;
				case 3:
					this.btnOutConrt.Enabled=true;
					
					this.btnInConrt.Enabled=false;
					break;
				case 4:
					
					this.btnInConrt.Enabled=true;
					this.btnOutConrt.Enabled=false;
					break;
				case 5:
					
					this.btnOutConrt.Enabled=true;
					this.btnInConrt.Enabled=false;
					break;
				case 6:
					
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 7:
					
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
				case 8:
					
					this.btnInConrt.Enabled=false;
					this.btnOutConrt.Enabled=false;
					break;
			}
		}

		private void XPGrid1_AfterUpdate(object sender, XPGrid.CUpdateType updateType, string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);

					SetButtonsEnable(key);

					decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);
					this.lblSheetMoney.Text=ThisMoney.ToString("#,###.##");
					
					decimal thisleft=0;           
					decimal leftMoeny = decimal.Parse(this.HiddenLeft.Value);
					thisleft=leftMoeny-ThisMoney;
					
					this.lblLeft.Text =  thisleft.ToString("#,###.##");      //剩余金额
					Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
					if(applyHeadBudget!=null)
					{
						applyHeadBudget.SheetMoney=ThisMoney; //本次累计金额
						applyHeadBudget.Update();
					}
					else
					{
						HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet","找不到applyHeadBudget");
					}

	
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet.XPGrid1_AfterUpdate",ex.Message);
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


		#region 提交按钮
		

		private void btnInConrt_Click(object sender, System.EventArgs e)
		{
			//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			//			{
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);
					//更新流程信息
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
					if(applyHead!=null)
					{
						// 先看单据是否已经是提交状态
						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
						{
							this.lblMessage .Text = "此单已经提交过!请不要重复提交";
							return ;
						}

						///////////2014-03-20 实务、劳保类型的 提交前 更新币种、金额信息 [p_Apply_AutoUpdatePrice] 在提交时刻防止价格变动  //////////////////////////
						
						Bussiness.BudgetAccountBLL.UpdateApplyPriceFromApplyHeadPk(key);


						// 2014-08-25  增加判断，若更新后实务类型有表体单价为0或者NULL等不合理值，则拒绝提交 
						//p_ApplyForPurchasePriceNull

						DataSet DsIsNullPrice =  Bussiness.BudgetAccountBLL.IsNullApplyPriceFromApplyHeadPk(key);
						if(DsIsNullPrice != null && DsIsNullPrice.Tables.Count >0 && DsIsNullPrice.Tables[0].Rows.Count >0 )
						{
							this.lblMessage.Text ="此单表体金额信息有误，不能提交";
							return;

						}
						

						/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

						/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
						///

						DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
						if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
						{
							this.lblMessage.Text ="此单余额信息有误，不能提交";
							return;
						}
							

							



						///////////////////////////////////////////END////////////////////////////////////////////////////

							

						#region 
						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //本次审批金额
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.InBudget,ThisMoney,MydeptCode); 
						if(TypeInFlow!=null)
						{
							//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
							//								string Message="";
							//								int CheckStep=0,DeptToCompany=0 ;
							//								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
						
							if(!"".Equals(checkRole)  )
							{
								applyHead.CurrentCheckRole=checkRole;
								applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								applyHead.CheckSetp=CheckStep;
							
								applyHead.Update();

								// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
								//									//根据工号发邮件            发邮件(方法2)
								//								
								//
								//								
								//									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								//									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
								//
								//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
								//
								//
								//									mailBll.ThreadSendMail();
								//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

								//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);

								updatePross(key);   //更新流程状态

								//提交既占预算，更新预算表的已占用预算额
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									// 以前的审计金额为季度累计审计金额
									Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
									DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

									decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
										
									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;

									decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //允许的预算外金额
									ds = null; 
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["InCorntType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急
									applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

									applyHeadBudget.Update();
								}
							}
							else
							{
								Response.Write(Message);
								HDSZCheckFlow.Common.Log.Logger.Log("提交预算内审批","没有找到相关审批角色");
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
								

								
								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

								//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
								//
								//
								//									mailBll.ThreadSendMail();
							}

								
						}
						else
						{
							Response.Write("未设置相关流程!!!!!!!");
						}
						#endregion 

					}
					//						tran.VoteCommit();
					SetButtonsEnable(key);
				}
			}
			catch(Exception ex)
			{
				//					tran.VoteRollBack();
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet",ex.Message);
			}
			//			}
		}

		private void btnOutConrt_Click(object sender, System.EventArgs e)
		{
			//			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			//			{
			try
			{
				if(!"".Equals(this.Hidden1.Value ))
				{
					int key =int.Parse(this.Hidden1.Value);

					//更新流程信息
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(key);
					if(applyHead!=null)
					{

						// 先看单据是否已经是提交状态
						string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];

						if(submit.IndexOf(applyHead.ApplyProcessCode ,0) == -1)
						{
							this.lblMessage .Text = "此单已经提交过!请不要重复提交";
							return ;
						}


						///////////2014-03-20 实务、劳保类型的 提交前 更新币种、金额信息 [p_Apply_AutoUpdatePrice] 在提交时刻防止价格变动  //////////////////////////
						

						Bussiness.BudgetAccountBLL.UpdateApplyPriceFromApplyHeadPk(key);

						// 2014-08-25  增加判断，若更新后实务类型有表体单价为0或者NULL等不合理值，则拒绝提交 
						//p_ApplyForPurchasePriceNull

						DataSet DsIsNullPrice =  Bussiness.BudgetAccountBLL.IsNullApplyPriceFromApplyHeadPk(key);
						if(DsIsNullPrice != null && DsIsNullPrice.Tables.Count >0 && DsIsNullPrice.Tables[0].Rows.Count >0 )
						{
							this.lblMessage.Text ="此单表体金额信息有误，不能提交";
							return;

						}



						/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////



						/////////2014-01-07 添加 增加一道判断  p_getBudgetInfobySheetHeadPk   若余额为负数则禁止提交  /////
						///

						DataSet leftds = Bussiness.BudgetAccountBLL.getLeftMoneyForUnSubmitApply(key);
						if(leftds == null ||  decimal.Parse(leftds.Tables[0].Rows[0]["sheetMoney"].ToString()) <= 0 || decimal.Parse(leftds.Tables[0].Rows[0]["leftMoney"].ToString()) < 0 )
						{
							this.lblMessage.Text ="此单余额信息有误，不能提交";
							return;
						}
							
						

						///////////////////////////////////////////END////////////////////////////////////////////////////

						#region 
						Entiy.ApplySheetBodyPurchase[] applySheetBodys=Entiy.ApplySheetBodyPurchase.FindByApplyHeadPk(key);
						decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(key);  //本次审批金额


						string MydeptCode = Bussiness.UserInfoBLL.GetUserClassDept(User.Identity.Name);
						Entiy.ApplyTypeInCheckFlow TypeInFlow=Entiy.ApplyTypeInCheckFlow.FindByCodeAndType(applyHead.ApplyTypeCode,HDSZCheckFlow.Common.Const.OutBudget,ThisMoney,MydeptCode); 
						
						if(TypeInFlow!=null)
						{
							//更新当前审批角色		,未找到审批角色写日志, 说明部门内流程有问题
							//								string Message="";
							//								int CheckStep=0,DeptToCompany=0 ;
							//								string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message);
							//								if(!"".Equals(checkRole))
							//								{
							string Message="",	NextCheckCode ="";
							int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
							string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(applyHead.ApplySheetHeadPk ,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
								
							if(!"".Equals(checkRole))
							{
								applyHead.CurrentCheckRole=checkRole;
								applyHead.CheckFlowInCompanyHeadPk=TypeInFlow.CheckFlowInCompanyHeadPk ;
								applyHead.CheckSetp=CheckStep;
								applyHead.Update();

								// 根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 

								string UserCode=Bussiness.ApplyAuditingBLL.GetPersonCodeByRoleAndSetp(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode);
								
								//根据工号发邮件            发邮件(方法2)

								//							
								//									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
								//									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
								//
								//									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
								//
								//									mailBll.ThreadSendMail();


								//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString());

								//								Bussiness.ApplyAuditingBLL.SendEmailByUserCode(UserCode);


								updatePross(key);

								//提交既占预算，更新预算表的已占用预算额
								Entiy.ApplySheetHeadBudget applyHeadBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(key);
								if(applyHeadBudget!=null )
								{
									Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,applyHead.ApplyDeptCode,applyHeadBudget.SheetSubject);
									//decimal tempMoney=budgetAccount.CheckMoney ;
									Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
									DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyHeadBudget.SheetSubject );

									decimal tempMoney=decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());//budgetAccount.CheckMoney ;
									//ds = null; 

									//decimal AllowOutMoney = budgetAccount.TotalAllowOutMoney;   //允许的预算外金额
									decimal AllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());   //允许的预算外金额


									budgetAccount.CheckMoney = budgetAccount.CheckMoney + applyHeadBudget.SheetMoney;
									budgetAccount.Update();
									applyHeadBudget.SumCheckMoney = tempMoney ;
									string submitType=System.Configuration.ConfigurationSettings.AppSettings["OutCorntType"];
									applyHeadBudget.SubmitType = int.Parse(submitType) ;// 紧急
									applyHeadBudget.AllowOutMoney = AllowOutMoney ; 

									applyHeadBudget.Update();
								}


									
								if(IsGiveUp ==1 )
								{
									//此用户放弃审批,循环调用方法本身;
									Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
									Audi.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);

									//										Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(2,NextCheckCode,applyHead.ApplySheetHeadPk ,"","",1);
								}
								else
								{
									//根据工号发邮件            发邮件(方法2)
								

								
									Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
									Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );

									Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);


									mailBll.ThreadSendMail();
								}
							}
						
						}
						else
						{
							Response.Write("未设置相关流程!!!!!");
						}
						#endregion 
					}
					//						tran.VoteCommit();
					SetButtonsEnable(key);
				}
			}
			catch(Exception ex)
			{
				//					tran.VoteRollBack();
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AddApplySheet",ex.Message);
			}
			//			}
		}

		#endregion  

		private void ddlFirstSubject_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//选择了一级科目后,帮定子级科目

			//绑定科组
			this.ddlSubject.Items.Clear();
			string firstSubject=this.ddlFirstSubject.SelectedValue;
			string budgetDept =Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			string applyTypeCode = this.ddlApplyType.SelectedValue ;
			DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
			if(dtSubject!=null && dtSubject.Rows.Count>0)
			{
				this.ddlSubject .DataSource=dtSubject;
				ddlSubject.DataValueField=dtSubject.Columns[0].ToString();
				ddlSubject.DataTextField =dtSubject.Columns[1].ToString();
				ddlSubject.DataBind();
				ddlSubject .Items.Insert(0,"");
			}		
			else
			{
				this.ddlSubject.DataSource=null;
				ddlSubject.DataBind();
			}
		}

		private void ddlApplyType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		

			//绑定科组
			this.ddlSubject.Items.Clear();
			string firstSubject=this.ddlFirstSubject.SelectedValue;
			string budgetDept =Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			string applyTypeCode = this.ddlApplyType.SelectedValue ;
			DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
			if(dtSubject!=null && dtSubject.Rows.Count>0)
			{
				this.ddlSubject .DataSource=dtSubject;
				ddlSubject.DataValueField=dtSubject.Columns[0].ToString();
				ddlSubject.DataTextField =dtSubject.Columns[1].ToString();
				ddlSubject.DataBind();
				ddlSubject .Items.Insert(0,"");
			}		
			else
			{
				this.ddlSubject.DataSource=null;
				ddlSubject.DataBind();
			}
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			

			#region  添加功能 
			this.lblMessage.Text="";
			try
			{
				//1. 生成定单号
				string applyNo="";
				string applyType=this.ddlApplyType.SelectedValue;
				DateTime  applyDate=new DateTime();
				if(!"".Equals(txtDate.Text))
				{
					applyDate=DateTime.Parse(txtDate.Text);
					//申请日期不能小于 当前月份............
					if(applyDate.Year < DateTime.Today.Year || (applyDate.Year == DateTime.Today.Year && applyDate.Month < DateTime.Today.Month) )
					{
						this.lblMessage.Text= "申请日期不能为以前月份！";
						return ;
					}
				}
				string applyDeptClass=this.ddlDeptClass.SelectedValue;
				string applyDept=this.ddlDept.SelectedValue;
				string applySubject=this.ddlSubject.SelectedValue;
				string personCode=this.txtPerson.Text;
				string firstSubject=this.ddlFirstSubject.SelectedValue;
				string  DeliveryDate="";
				if(!"".Equals(txtDeliveryDate.Text))
				{
					DeliveryDate=txtDeliveryDate.Text;
				}

				#region 
				if("".Equals(applyType))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="类型不能为空";
					return;
				}
				if("".Equals(txtDate.Text))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请日期不能为空";
					return;
				}
				if("".Equals(applyDeptClass))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请部门不能为空";
					return;
				}
				if("".Equals(applyDept))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请科组不能为空";
					return;
				}
				if("".Equals(firstSubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="一级科目不能为空";
					return;
				}
				if("".Equals(applySubject))
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="申请科目不能为空";
					return;
				}
				//				if("".Equals(this.txtDeliveryDate.Text))
				//				{
				//					this.lblMessage.ForeColor=Color.Red;
				//					this.lblMessage.Text="交货日期不能为空";
				//					return;
				//				}

				Entiy.BasePerson person=Entiy.BasePerson.Find(personCode);
				if(person==null)
				{
					this.lblMessage.ForeColor=Color.Red;
					this.lblMessage.Text="人员不存在";
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

				if(!"1".Equals(this.Hidden2.Value))   // 非更新状态 
				{
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


					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态

					applySheet.Create();


					//添加ApplySheetHead_Budget 表
					Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.SelectApplySheetHeadPk(applyNo);

					Entiy.ApplySheetHeadBudget ApplyHeadBudget=new HDSZCheckFlow.Entiy.ApplySheetHeadBudget();
					if(applyHead!=null)
					{
						ApplyHeadBudget.ApplySheetHeadPk= applyHead.ApplySheetHeadPk ;
						ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
						ApplyHeadBudget.SheetSubject=applySubject;
						ApplyHeadBudget.Create();
					}

					this.Hidden1.Value=applyHead.ApplySheetHeadPk.ToString();  //记录此次添加的表头PK

					
					//找到相关表体  ApplyType  申请单据类型表
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XPGrid1.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XPGrid1.DataBind();
					
						//添加附件可用
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + applyHead.ApplySheetHeadPk.ToString()   ;

					}

					this.Label9.Text= applyNo ;                                 //显示单据号
					this.Label10.Text=System.DateTime.Now.ToString();


				}
				else                                   // 更新状态 
				{
					Entiy.ApplySheetHead applySheet=HDSZCheckFlow.Entiy.ApplySheetHead.Find(int.Parse(this.Hidden1.Value));
					//applySheet.ApplySheetNo=applyNo;
					//applySheet.ApplyTypeCode=applyType;
					applySheet.ApplyDate=applyDate;
					applySheet.ApplyDeptClassCode =applyDeptClass;
					applySheet.ApplyDeptCode=applyDept;
					applySheet.ApplyPersonCode=personCode ;
					applySheet.ApplyMakerCode=personMakerCode;

					applySheet.DeliveryDate = DeliveryDate ;
					applySheet.SubmitDate = System.DateTime.Now;         // 提交时间为系统当前时间

					applySheet.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //新建状态

					applySheet.Update();


					//添加ApplySheetHead_Budget 表
					
					Entiy.ApplySheetHeadBudget ApplyHeadBudget=HDSZCheckFlow.Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(int.Parse(this.Hidden1.Value));

					ApplyHeadBudget.SheetFirstClassSubject=firstSubject;
					ApplyHeadBudget.SheetSubject=applySubject;
					ApplyHeadBudget.Update ();
					
					//找到相关表体  ApplyType  申请单据类型表
					Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyType);
					if(applyTypes !=null )
					{
						//					this.XPGrid1.CommandText="select * from ApplySheetBody_Purchase where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XPGrid1.CommandText="select * from " + applyTypes.ApplySheetBodyTableName + " where ApplySheetHead_Pk=" + this.Hidden1.Value + " ";  //" + applyHead.ApplySheetHeadPk + "
						this.XPGrid1.DataBind();
					
						//添加附件可用
						this.hyLindToAnnex.Visible=true;
						this.hyLindToAnnex.Target = "_blank";
						this.hyLindToAnnex.NavigateUrl= "ApplySheetAnnex.aspx?returnurl=AddApplySheet.aspx&ApplyHeadPk=" + this.Hidden1.Value   ;

					}

					this.Label9.Text= applySheet.ApplySheetNo ;                                 //显示单据号
					this.Label10.Text=System.DateTime.Now.ToString();


				}

				this.lblMessage.ForeColor=Color.Blue;
				this.lblMessage.Text="添加成功";
				//若没有部门科目记录,则初始化一个空值
				string message="";
				Bussiness.BudgetAccountBLL.SaveBudgetAccount(applyDate.Year,applyDate.Month,applyDept,applySubject,out message);
				if(!"".Equals(message))
				{
					this.lblMessage.Text=message;
				}
				
				BindBudgetInfo(applyDate.Year,applyDate.Month,applyDept,applySubject);//显示部门科目预算情况

				
 
				this.Label1.Visible=true;
			
				this.btnAdd.Enabled=true;
				this.btnEdit.Enabled=true;
				this.btnSave.Enabled=false;

				this.ddlApplyType.Enabled = false;
				this.ddlDept.Enabled = false ;
				this.ddlDeptClass.Enabled =false; 
				this.ddlFirstSubject.Enabled= false ;
				this.ddlSubject.Enabled = false ;
				this.txtDate.Enabled = false ;
				this.txtPerson.Enabled=false ;
				this.txtDeliveryDate.Enabled=false; 

				this.ddlApplyType.BackColor= Color.LightGray;
				this.ddlDept.BackColor = Color.LightGray;
				this.ddlDeptClass.BackColor = Color.LightGray;
				this.ddlFirstSubject.BackColor=  Color.LightGray;
				this.ddlSubject.BackColor =  Color.LightGray;
				this.txtDate.BackColor =  Color.LightGray;
				this.txtPerson.BackColor= Color.LightGray;
				this.txtPersonName.BackColor = Color.LightGray;
				this.txtDeliveryDate.BackColor =Color.LightGray;

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("UI.CheckFlow.CheckFlow.ApplySheet",ex.Message);
			}
			#endregion 
	
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			#region 

			//this.ddlApplyType.Enabled = true ;
			this.ddlDept.Enabled = true ;
			this.ddlDeptClass.Enabled =true; 
			this.ddlFirstSubject.Enabled= true ;
			this.ddlSubject.Enabled = true ;
			this.txtDate.Enabled = true ;
            this.txtPerson.Enabled = true; this.txtPerson.Text = "000000814";
			this.txtDeliveryDate.Enabled=true;

			//this.ddlApplyType.BackColor= Color.White ;
			this.ddlDept.BackColor =Color.White ;
			this.ddlDeptClass.BackColor = Color.White ;
			this.ddlFirstSubject.BackColor=  Color.White;
			this.ddlSubject.BackColor =  Color.White;
			this.txtDate.BackColor =  Color.White;
			this.txtPerson.BackColor= Color.White;
			this.txtDeliveryDate.BackColor=Color.White;

			this.btnAdd.Enabled=false;
			this.btnEdit.Enabled=false;
			this.btnSave.Enabled=true;

			#endregion 
			//表示为修改状态
			this.Hidden2.Value = "1" ; 
		
		}

		private void ddlDept_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			#region 
			//				string budgetDept = Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			//				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(budgetDept); //一级科目
			//				if(dtSubject!=null && dtSubject.Rows.Count >0)
			//				{
			//					this.ddlFirstSubject.DataSource=dtSubject;
			//					ddlFirstSubject.DataValueField=dtSubject.Columns[0].ToString();
			//					ddlFirstSubject.DataTextField =dtSubject.Columns[1].ToString();
			//					ddlFirstSubject.DataBind();
			//					ddlFirstSubject.Items.Insert(0,"");
			//				}
			
			//根据选定的科组查询所对应的一级科目

			//string budgetDept = Bussiness.UserInfoBLL.GetUserBudgetDept(User.Identity.Name);
			#endregion 

			Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(this.ddlDept.SelectedValue);
			if(dept != null && dept.BudgetDeptCode != null )
			{
				DataTable dtSubject=Bussiness.BaseAccountSubjectBLL.GetAccountSubjectInfo(dept.BudgetDeptCode); //一级科目
				if(dtSubject!=null && dtSubject.Rows.Count >0)
				{
					this.ddlFirstSubject.DataSource=dtSubject;
					ddlFirstSubject.DataValueField=dtSubject.Columns[0].ToString();
					ddlFirstSubject.DataTextField =dtSubject.Columns[1].ToString();
					ddlFirstSubject.DataBind();
					ddlFirstSubject.Items.Insert(0,"");
				}
			}

		}

	}
}
