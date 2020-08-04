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
	/// FinallyCheckApplyForOneApply 的摘要说明。
	/// </summary>
	public class FinallyCheckApplyForOneApply : System.Web.UI.Page
	{
		#region   属性

		protected System.Web.UI.WebControls.Label lblApplyType;
		protected System.Web.UI.WebControls.Label lblDpteAndPerson;
		protected System.Web.UI.WebControls.Label lblApplyDate;
		protected System.Web.UI.WebControls.Label lblMoney;
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
		protected System.Web.UI.WebControls.Label lblTradeAgreement;
		protected System.Web.UI.WebControls.Label lblCheckDept;
		protected string applyHeadPk;

		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//string disCode=Request.QueryString["disCode"].ToString();  //替代人工号
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
					//附件信息(==)
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

			// .根据单据头,在数据库里找到相应链接
			
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		
	}
}
