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

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// AuditingForOneApply 的摘要说明。
	/// </summary>
	public class AuditingAssetForOneApply : System.Web.UI.Page
	{

		#region   属性

		protected System.Web.UI.WebControls.Label lblApplyType;
		protected System.Web.UI.WebControls.Label lblDpteAndPerson;
		protected System.Web.UI.WebControls.Label lblApplyDate;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Button btnAgree;
		protected System.Web.UI.WebControls.Button btnRefuse;
		protected System.Web.UI.WebControls.TextBox txtPosital;
		protected System.Web.UI.WebControls.Label lblMoney;
		protected System.Web.UI.WebControls.Button btnGoBack;
		protected System.Web.UI.WebControls.Label  lblMessage;
		protected System.Web.UI.WebControls.Table tbAnnex;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblDeliveryDate;
		protected System.Web.UI.WebControls.Label lblSubmitDate;
		protected System.Web.UI.WebControls.Label lblSheetNo;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.TextBox txtCCMemo;
		protected System.Web.UI.WebControls.TextBox txtWithwho;
		protected System.Web.UI.WebControls.TextBox txtwithapps;
		protected System.Web.UI.WebControls.TextBox txtAppclass;
		protected System.Web.UI.WebControls.DropDownList ddlCCType;
		protected System.Web.UI.WebControls.TextBox txtGocity;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.Panel panel1;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.TextBox txtPreabound;
		protected System.Web.UI.WebControls.TextBox txtPreback;
		protected System.Web.UI.WebControls.CheckBox chbVisa;
		protected System.Web.UI.WebControls.TextBox txtVisaDate;
		protected System.Web.UI.WebControls.CheckBox chkPassport;
		protected System.Web.UI.WebControls.TextBox txtPassportno;
		protected System.Web.UI.WebControls.TextBox txtpassportdate;
		protected System.Web.UI.WebControls.CheckBox chbbacterin;
		protected System.Web.UI.WebControls.TextBox txtbacterindate;
		protected System.Web.UI.WebControls.TextBox txtabountMemo;
		protected System.Web.UI.WebControls.CheckBox chblimit;
		protected System.Web.UI.WebControls.CheckBox chblimits;
		protected System.Web.UI.WebControls.CheckBox chbcheckup;
		protected System.Web.UI.WebControls.CheckBox chbmeet;
		protected System.Web.UI.WebControls.TextBox txtcheckupplan;
		protected System.Web.UI.WebControls.DataGrid dgCCBodyInfo;
		protected System.Web.UI.WebControls.TextBox txtEspecialRequest;
		protected System.Web.UI.WebControls.RadioButton RadioButton4;
		protected System.Web.UI.WebControls.RadioButton RadioButton3;
		protected System.Web.UI.WebControls.RadioButton RadioButton2;
		protected System.Web.UI.WebControls.RadioButton RadioButton1;
		protected System.Web.UI.WebControls.TextBox txtOtherNeed;
		protected System.Web.UI.WebControls.CheckBox chbLunch;
		protected System.Web.UI.WebControls.TextBox txtLookNum;
		protected System.Web.UI.WebControls.CheckBox chblookFactory;
		protected System.Web.UI.WebControls.CheckBox chbTea;
		protected System.Web.UI.WebControls.TextBox txtRelationDept;
		protected System.Web.UI.WebControls.TextBox txtvisitphone;
		protected System.Web.UI.WebControls.TextBox txtVisitPerson;
		protected System.Web.UI.WebControls.TextBox txtVisitDept;
		protected System.Web.UI.WebControls.TextBox txtTalkPlace;
		protected System.Web.UI.WebControls.TextBox txtCallinMemo;
		protected System.Web.UI.WebControls.TextBox txtCallinPerson;
		protected System.Web.UI.WebControls.TextBox txtVisitCompany;
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected System.Web.UI.WebControls.TextBox Textbox2;
		protected System.Web.UI.WebControls.Panel Panel5;
		protected System.Web.UI.WebControls.Panel Panel4;
		protected System.Web.UI.WebControls.DataGrid dgYQInfo;
		protected System.Web.UI.WebControls.HyperLink hlSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblBudgetType;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.DataGrid dgPostail;
		protected string NumOfAnnex="0";
		protected System.Web.UI.WebControls.Label lblReasonEffect;
		protected string applyHeadPk;

		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string disCode=Request.QueryString["disCode"].ToString();  //替代人工号
			string ApplyHeadPk=Request.QueryString["applyHeadPk"].ToString();  //将要审批的单据ID

			//保持滚动条位置不变。。 （没效果）
			//this.Page.SmartNavigation = true;

			if(!Page.IsPostBack)
			{
				try
				{
					//表头信息
					BindBaseInfoOfApply(int.Parse(ApplyHeadPk));
					//表体信息
					BindApplyBodyInfo(int.Parse(ApplyHeadPk));
					//预算信息
					BindBudgetInfo(int.Parse(ApplyHeadPk));
					//审批记录
					BindApplyRecord(int.Parse(ApplyHeadPk));
					//附件信息
					BindAnnexInfo(int.Parse(ApplyHeadPk)); 
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("CheckFlow.AuditingForOneApply",ex.Message ); 
				}
			}
		}

		private void BindBaseInfoOfApply(int ApplyHeadPk)
		{
			try
			{
				#region 表头信息
				Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
				if(ApplyHead!=null)
				{
					Entiy.ApplyType ApplyType=Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
					if(ApplyType!=null)
					{
						//单据类型
						this.lblApplyType.Text=ApplyType.ApplyTypeName;
					}
					Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
					if(AssetBudget != null)
					{
						//单据金额
						this.lblMoney.Text = AssetBudget.SheetRmbMoney.ToString("N2");
						//预算项目
						this.lblSubject.Text = AssetBudget.ItemName ;  
						//预算类别
						if(AssetBudget.SubmitType == 2 )
						{
							this.lblBudgetType.Text = "预算外";
							this.lblBudgetType.ForeColor = Color.Red ;
						}
						else
						{
							this.lblBudgetType.Text = "预算内";
						}
					}
					//申请日期
					this.lblApplyDate.Text=ApplyHead.ApplyDate.ToString("yyyy-MM-dd");

					Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(dept!=null)
					{
						//申请部门
						this.lblDpteAndPerson.Text =dept.DeptName ;
					}
					Entiy.BasePerson person=Entiy.BasePerson.Find(ApplyHead.ApplyPersonCode);
					if(person!=null)
					{
						//申请部门 && 人员
						this.lblDpteAndPerson.Text = this.lblDpteAndPerson.Text  + "    "+ person.Name;
					}
					//要求日期
					this.lblDeliveryDate.Text=ApplyHead.DeliveryDate.ToString();
					if(ApplyHead.SubmitDate.Year > 1910 )
					{
						//单据填写时间
						this.lblSubmitDate.Text = ApplyHead.SubmitDate.ToString("yyyy-MM-dd HH:mm:ss");
					}
					//单据号
					this.lblSheetNo.Text= ApplyHead.ApplySheetNo ;

					//提案理由及达到效果
					this.lblReasonEffect.Text = ApplyHead.ReasonForAsset + "  <br/> <br/>" + ApplyHead.Effect ;
				}

				#endregion 
			}
			catch(Exception ex)
			{
				 Common.Log.Logger.Log("BindBaseInfoOfApply",ex.Message );
			}
		}

		private void BindAnnexInfo(int applyHeadPk)
		{
			#region 单据附件信息 

			// .根据单据头,在数据库里找到相应链接
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByApplyHeadPk(applyHeadPk);
			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{
				NumOfAnnex = applyAnnexs.Length.ToString();
				//. 生成规则 , 1行一条记录
				foreach(Entiy.ApplySheetAnnex applyAnnex in applyAnnexs)
				{
					TableRow  tr=new TableRow();
					TableCell td=new TableCell();

					string path=Bussiness.upLoadFileBLL.getAnnexPath(applyAnnex.ApplySheetHeadPk);
					if(!"".Equals(path))
					{
						//string tdURL  = path + applyAnnex.FileName;
						//string xsText = "<a href='http:" + tdURL + "'   target='_blank' >" + applyAnnex.FileName + "</a>";
						//td.Text= xsText ;
						string jsStr="window.showModalDialog('../../BaseData/Commons/AnnexInfoShow.aspx?FileName="+applyAnnex.FileName+"&applyHeadPk="+applyAnnex.ApplySheetHeadPk+"','','dialogWidth=800px;dialogHeight=770px;status=no;help=no;scrollbars:no;')";
						string tdURL  = path + applyAnnex.FileName;
						string xsText = "<a href='http:" + tdURL + "'   target='_blank' >" + applyAnnex.FileName + "</a>";

						//2011-11-22 liyang
						//string xsText = "<a href='javascript:void' onclick=\""+jsStr+"\">" + applyAnnex.FileName + "</a>";
						td.Text= xsText ;

					}
					else
					{
						td.Text=""; 
					}
					tr.Cells.Add(td);
					this.tbAnnex .Rows.Add(tr);
					td =null;
					tr =null;
				}
			}
			else
			{
				//没有找到 ,table 打印出 ,未找到提示信息.....
				TableRow  tr=new TableRow();
				TableCell td=new TableCell();
				td.Text="<font color='red'>没有附件信息</font>"; 
				tr.Cells.Add(td);
				this.tbAnnex .Rows.Add(tr);
				td =null;
				tr =null;
			}

			#endregion 
		}

		private void BindApplyRecord(int ApplyHeadPk)
		{
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecord(ApplyHeadPk);
			if(ds!=null)
			{
				this.dgPostail.DataSource=ds;
			}
			else
			{
				this.dgPostail.DataSource=null;
			}
			this.dgPostail.DataBind();
		}

		private void BindApplyBodyInfo(int ApplyHeadPk)
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
						DataSet ds= Bussiness.ApplyAuditingBLL.GetApplySheetBodyAssetInfo(ApplyHeadPk);
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
				}
			}

		}

		//根据单据号，查询所用预算Id
		private int FindAssetBudgetPk(int ApplyHeadPk)
		{
			int AssetBudgetPk= 0 ;
			//必要条件 ，年，预算部门编号，项目 

			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadPk);

			Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);

			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);

			if(ApplyHead !=null && Dept != null && ApplyBudget !=null )
			{
				Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.FindByYearAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,Dept.BudgetDeptCode);
				if(AssetBudget!=null)
				{
					AssetBudgetPk = AssetBudget.Id;
				}
			}

			return AssetBudgetPk ; 
		}


		private void BindBudgetInfo(int ApplyHeadPk)
		{
			#region 预算情况

			decimal BudgetMoney = 0;
			decimal ReadyPay    = 0;
 

			//单据表头
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			//单据预算
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);

			if(ApplyHead !=null && ApplyBudget !=null )
			{
				//本单金额
				this.lblSheetMoney.Text= ApplyBudget.SheetRmbMoney.ToString("N2");
				//已经使用
				this.hlSumCheck.Text = ApplyBudget.SumCheckMoney.ToString("N2");
				//给已用金额附查询链接
//				if(ApplyBudget.SumCheckMoney > 0)
//				{
					//已用新营预算查询地址连接
//					string url ="../../BaseData/Asset/Asset_Budget_UseDetails.aspx?applyHeadPk=" + ApplyHead.ApplySheetHeadPk;
//					this.hlSumCheck.NavigateUrl =  url ; 
					int AssetBudgetPk = FindAssetBudgetPk(ApplyHeadPk) ; 
					string url ="../../BaseData/Asset/Asset_Budget_UseDetails.aspx?AssetBudgetPk=" + AssetBudgetPk;
					this.hlSumCheck.NavigateUrl =  url ; 
//				}
				//预算外金额
				this.lblOutMoney.Text = ApplyBudget.AllowOutMoney.ToString("N2");


				//单据所用项目预算
				Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
				if(Dept != null )
				{
					//获取项目预算信息
					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,ApplyBudget.ItemName);
					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
					{
						//预算
						this.lblBudget.Text= decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
						//待摊
						this.lblready.Text = decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;

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
			this.btnAgree.Click += new System.EventHandler(this.btnAgree_Click);
			this.btnRefuse.Click += new System.EventHandler(this.btnRefuse_Click);
			this.btnGoBack.Click += new System.EventHandler(this.btnGoBack_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnAgree_Click(object sender, System.EventArgs e)
		{
			this.btnAgree.Enabled=false;
			this.btnRefuse.Enabled=false;

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //将要审批的单据ID

			string disPlaysCode=Request.QueryString["disCode"].ToString();  //替代人工号

			//同意

			// 1. 记录到审批记录表.....

			// 2. 更新此单据的下一审批角色 , 下一角色放弃的话,则找再下一角色

			// 3. 更新是否出部门. IsInCompany 

			// 4. 更新进程状态 

			// 5. 立即记录到上边的审批意见

			// 6. 灰掉相关按钮

			//Flow_AgreeApplySheet(1);
			this.lblMessage.Text="";
			if(IsAuditinged() == 1 )
			{
				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

				Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();

				Audi.Flow_AgreeApplySheet(1,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );

//				Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(1,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );
				BindApplyRecord(int.Parse(ApplySheetHeadPk));

				BindAnnexInfo(int.Parse(ApplySheetHeadPk));
			}
			else
			{
				this.lblMessage.Text="单据已被同级人员审批";
			}

		}

		private int IsAuditinged()
		{
			//单据是否已经被同角色的其他人审批过了!

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //将要审批的单据ID


			
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
			if(applyHead!=null && applyHead.CurrentCheckRole!=null)
			{
				Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
				if(prossType!=null &&  prossType.IsDisallow==0)  //先看进程状态是否为驳回
				{
					//判断当前审批角色里是否有自己  ,,部门内或部门外都可以
					string UserCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
					int i=Bussiness.UserInfoBLL.GetCountOfUserRole(applyHead.CurrentCheckRole ,UserCode,applyHead.ApplyDeptCode);
					if(i>0)
					{
						return 1; //属于自己
					}
					else
					{
						return 0; //可能被别人审批了
					}
				}
				else
				{
					return 0;                 //进程状态为null或者 为驳回状态.. 不可再审
				}
			}
			else
			{
				return 2; //未找到单据,错误
			}
		}

		#region  改写到 Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet
//		private void Flow_AgreeApplySheet(int agreeType)
//		{
//			try
//			{
//				//agreeType : 1同意 , 0 拒绝
//
//				//1. 将审批日志记录到 记录表
//				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
//				string posital=this.txtPosital.Text;
//
//				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
//				if(applyHead!=null)
//				{
//					Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
//					applyRecord.ApplySheetHeadPk=int.Parse(ApplySheetHeadPk);       //单据主键
//					applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//审批类别  部门内/公司内 
//					applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//审批角色
//					applyRecord.CheckSetp=applyHead.CheckSetp;						//审批级
//					applyRecord.CheckPersonCode=myCode;								//审批人Code
//					applyRecord.CheckComment=posital;								//审批意见
//					applyRecord.Checkdate=DateTime.Now;								//审批时间
//					if(!"".Equals(disPlaysCode))                     
//					{
//						applyRecord.DisplaysPersonCode = disPlaysCode;				//被替代人Code
//						applyRecord.IsDisplays=1;									//是否替代审批
//					}
//					applyRecord.IsPass=agreeType;									//是否同意
//
//					applyRecord.Create();
//
//					if(agreeType==1)
//					{
//						#region   同意 
//						//2.更新此单据的下一审批角色 
//						string Message="";
//						int CheckStep=0,DeptToCompany=0 ;
//						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(int.Parse(ApplySheetHeadPk),out CheckStep,out DeptToCompany,out Message);
//						applyHead.CurrentCheckRole=checkRole ;   //审批角色
//						applyHead.CheckSetp=CheckStep;           //步骤
//						if(DeptToCompany == 1 )                  //进程状态
//						{
//							applyHead.IsCheckInCompany=1;											//更新是否出部门. IsInCompany 
//							Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//							if(prossType !=null && prossType.IsSubmitAgain==1)
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyAgain;
//							}
//							else
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;		//更新进程状态为公司内
//							}
//						}
//						else if(DeptToCompany == 0 )
//						{
//							Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//							if(prossType !=null && prossType.IsSubmitAgain==1)
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DeptAgain;
//							}
//							else
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DeptPross;		//更新进程状态为部门内开始审批了
//							}
//						}
//						else if(DeptToCompany ==2  )
//						{
//							Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode); 
//							if(prossType !=null && prossType.IsSubmitAgain==1)
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverAgain;
//							}
//							else
//							{
//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		//更新进程状态为审批结束了
//							}
//						}
//						applyHead.Update();
//						#endregion  
//					}
//					else
//					{
//						#region  拒绝
//						//3.更新进程状态为   驳回  ,审批角色置为空 ,步骤也为空 
//						applyHead.CurrentCheckRole="";
//						applyHead.CheckSetp=-1;
//						Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
//						if(prossType !=null && prossType.IsSubmitAgain==1)
//						{
//							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisAgain  ;
//						}
//						else
//						{
//							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisPross ;		
//						}
//						#endregion 
//					}
//				}
//			}
//			catch(Exception ex)
//			{
//				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AuditingForOneApply",ex.Message);
//			}
//		}
		#endregion  

		private void btnRefuse_Click(object sender, System.EventArgs e)
		{
			this.btnAgree.Enabled=false;
			this.btnRefuse.Enabled=false;

			this.lblMessage.Text="";

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //将要审批的单据ID
			string disPlaysCode=Request.QueryString["disCode"].ToString();  //替代人工号



			//拒绝
			if(IsAuditinged() == 1 )
			{
				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

				Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
				Audi.Flow_AgreeApplySheet(0,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );

//				Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet(0,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );
				BindApplyRecord(int.Parse(ApplySheetHeadPk));
				
				BindAnnexInfo(int.Parse(ApplySheetHeadPk));
			}
			else
			{
				this.lblMessage.Text="单据已被同级人员审批";
			}

			

		}

		private void btnGoBack_Click(object sender, System.EventArgs e)
		{
			//回到我的审批页面
			Response.Redirect("../../CheckFlow/CheckFlow/MyAuditing.aspx");
		}




	}
}
