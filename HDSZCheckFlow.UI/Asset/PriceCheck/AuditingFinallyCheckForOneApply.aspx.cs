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

namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
	/// <summary>
	/// AuditingFinallyCheckForOneApply 的摘要说明。
	/// </summary>
	public class AuditingFinallyCheckForOneApply : System.Web.UI.Page
	{
		#region   属性

		protected System.Web.UI.WebControls.Label lblApplyType;
		protected System.Web.UI.WebControls.Label lblDpteAndPerson;
		protected System.Web.UI.WebControls.Label lblApplyDate;
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
		protected System.Web.UI.WebControls.DataGrid dgYQInfo;
		protected System.Web.UI.WebControls.Label lblBudgetType;
		protected System.Web.UI.WebControls.DataGrid dgPostail;
		protected string NumOfAnnex="0";
		protected System.Web.UI.WebControls.Label lblBargainNo;
		protected System.Web.UI.WebControls.Label lblRequestDate;
		protected System.Web.UI.WebControls.Label lblReMark;
		protected System.Web.UI.WebControls.Label lblPayForArticle;
		protected System.Web.UI.WebControls.HyperLink hlApplySheetNo;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.DataGrid Datagrid1;
		protected System.Web.UI.WebControls.Label lblTradeAgreement;
		protected System.Web.UI.WebControls.Label lblCheckDept;
		protected string applyHeadPk;

		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			string disCode=Request.QueryString["disCode"].ToString();  //替代人工号
			string FinallyCheckId=Request.QueryString["FinallyCheckId"].ToString();  //将要审批的单据ID

			if(!Page.IsPostBack)
			{
				try
				{
					//表头信息
					BindBaseInfoOfApply(int.Parse(FinallyCheckId));
					//表体信息
					BindApplyBodyInfo(int.Parse(FinallyCheckId));
//					//审批记录
					GetApplyRecordForFinallyCheck(int.Parse(FinallyCheckId));
//					//附件信息
					BindAnnexInfo(int.Parse(FinallyCheckId)); 
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("CheckFlow.AuditingForOneApply",ex.Message ); 
				}
			}
		}

		private void BindBaseInfoOfApply(int FinallyCheckId)
		{
			try
			{
				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckId);
				if(FinallyCheck != null)
				{
					#region 表头信息
					Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(FinallyCheck.ApplySheetHeadPk);
					if(ApplyHead!=null)
					{
						Entiy.ApplyType ApplyType=Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
						if(ApplyType!=null)
						{
							//单据类型
							this.lblApplyType.Text=ApplyType.ApplyTypeName;
						}
						Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(FinallyCheck.ApplySheetHeadPk);
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
						//this.lblSheetNo.Text= ApplyHead.ApplySheetNo ;

						this.hlApplySheetNo.Text = ApplyHead.ApplySheetNo ;

						string url ="../../Asset/CheckFlow/AssetApplyForOneApply.aspx?applyHeadPK=" + FinallyCheck.ApplySheetHeadPk;
						this.hlApplySheetNo.NavigateUrl =  url ; 

						
						//
						this.lblBargainNo.Text = FinallyCheck.BargainNo ;
						this.lblRequestDate.Text = FinallyCheck.RequestDate;
						this.lblPayForArticle.Text  = FinallyCheck.PayForArticle ;

						this.lblReMark .Text  = FinallyCheck.ReMark;

						
						this.lblTradeAgreement.Text = FinallyCheck.TradeAgreement ;
						this.lblCheckDept .Text  = FinallyCheck.CheckDept ;



					}
					#endregion 
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("AuditingFinallyCheckForOneApply.BindBaseInfoOfApply",ex.Message );
			}
		}

		private void BindAnnexInfo(int FinallyCheckId)
		{
			#region 单据附件信息 

			//根据单据头,在数据库里找到相应链接
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByFinallyCheckId(FinallyCheckId);

			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{
				NumOfAnnex = applyAnnexs.Length.ToString();
				//. 生成规则 , 1行一条记录
				foreach(Entiy.ApplySheetAnnex applyAnnex in applyAnnexs)
				{
					TableRow  tr=new TableRow();
					TableCell td=new TableCell();

					string path=Bussiness.upLoadFileBLL.getAnnexPathForFinallyCheck(applyAnnex.FinallyCheckPk);

					if(!"".Equals(path))
					{
						string tdURL  = path + applyAnnex.FileName;
						string xsText = "<a href='http:" + tdURL + "'   target='_blank' >" + applyAnnex.FileName + "</a>";
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

		private void GetApplyRecordForFinallyCheck(int FinallyCheckId)
		{
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecordForFinallyCheck(FinallyCheckId);
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

		private void BindApplyBodyInfo(int FinallyCheckId)
		{
			try
			{
				//表体详细信息
				//string cmdStr = "select * from dbo.v_AssetBody_CheckBody where FId = " + FinallyCheckId ;

				string cmdStr = "exec p_Asset_SelectFinallyCheckBody " + FinallyCheckId.ToString() ;

				//表体详细信息
				DataSet ds= Bussiness.ComQuaryBLL.ExecutebyQuery(cmdStr);
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
			catch(Exception Ex)
			{
				Common.Log.Logger.Log("UI.Asset.PriceCheck.AuditingFinallyCheckForOneApply.BindApplyBodyInfo",Ex.Message);
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

			string FinallyCheckId=Request.QueryString["FinallyCheckId"].ToString();  //将要审批的单据ID
			string disPlaysCode=Request.QueryString["disCode"].ToString();  //替代人工号

			//同意
			// 1. 记录到审批记录表.....
			// 2. 更新此单据的下一审批角色 , 下一角色放弃的话,则找再下一角色
			// 3. 更新是否出部门. IsInCompany 
			// 4. 更新进程状态 
			// 5. 立即记录到上边的审批意见
			// 6. 灰掉相关按钮

			this.lblMessage.Text="";
			if(IsAuditinged() == 1 )
			{
				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

//				Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
//				Audi.Flow_AgreeApplySheet(1,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );

				Bussiness.AssetCheckFlowBLL.Flow_CheckAssetPriceApply(1,myCode,int.Parse(FinallyCheckId),disPlaysCode,this.txtPosital.Text,1);

				GetApplyRecordForFinallyCheck(int.Parse(FinallyCheckId));

				BindAnnexInfo(int.Parse(FinallyCheckId));
			}
			else
			{
				this.lblMessage.Text="单据已被同级人员审批";
			}

		}

		#region 判断单据是否已经审批
		private int IsAuditinged()
		{
			//单据是否已经被同角色的其他人审批过了!

		    string FinallyCheckId=Request.QueryString["FinallyCheckId"].ToString();  //将要审批的单据ID

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(int.Parse(FinallyCheckId));

			if(FinallyCheck != null && FinallyCheck.CurrentCheckRole != null)
			{
				Entiy.ApplyProcessType ProssType = Entiy.ApplyProcessType.Find(FinallyCheck.ApplyProcessCode);
				if(ProssType !=null && ProssType.IsDisallow == 0 ) //先看进程状态是否为驳回
				{
					//判断当前审批角色里是否有自己  ,,部门内或部门外都可以
					string UserCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
					int i=Bussiness.UserInfoBLL.GetCountOfUserRole(FinallyCheck.CurrentCheckRole ,UserCode,FinallyCheck.ApplyDeptCode);
					if(i>0)
					{
						return 1; //属于自己
					}
					else
					{
						return 0; //可能被别人审批了
					}
					//////////////////////////////以上判断需要检验。。。。。。
				}
				else
				{
					//进程状态为null或者 为驳回状态.. 不可再审
					return 0; 
				}
			}
			else
			{
				return 2 ; //未找到单据,错误
			}
		}
		#endregion 

		private void btnRefuse_Click(object sender, System.EventArgs e)
		{
			//拒绝单据

			this.btnAgree.Enabled=false;
			this.btnRefuse.Enabled=false;

			this.lblMessage.Text="";

			string FinallyCheckId=Request.QueryString["FinallyCheckId"].ToString();  //将要审批的单据ID
			string disPlaysCode=Request.QueryString["disCode"].ToString();  //替代人工号

			//拒绝
			if(IsAuditinged() == 1 )
			{
				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

//				Bussiness.ApplyAuditingBLL Audi = new HDSZCheckFlow.Bussiness.ApplyAuditingBLL();
//				Audi.Flow_AgreeApplySheet(0,myCode,int.Parse(ApplySheetHeadPk),disPlaysCode,this.txtPosital.Text,1 );
				Bussiness.AssetCheckFlowBLL.Flow_CheckAssetPriceApply(0,myCode,int.Parse(FinallyCheckId),disPlaysCode,this.txtPosital.Text,1);

				GetApplyRecordForFinallyCheck(int.Parse(FinallyCheckId));

				BindAnnexInfo(int.Parse(FinallyCheckId));
			}
			else
			{
				this.lblMessage.Text="单据已被同级人员审批";
			}
		}

		private void btnGoBack_Click(object sender, System.EventArgs e)
		{
			//回到我的审批页面
//			Response.Redirect("../../Asset/PriceCheck/MyAuditingForFinallyCheck.aspx");
			Response.Redirect("../../CheckFlow/CheckFlow/MyAuditing.aspx");

		}




	}
}
