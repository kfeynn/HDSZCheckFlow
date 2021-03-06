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
	public class ApplySheetBodyInfo2 : System.Web.UI.Page
	{

		#region   属性

		protected System.Web.UI.WebControls.Label lblApplyType;
		protected System.Web.UI.WebControls.Label lblDpteAndPerson;
		protected System.Web.UI.WebControls.Label lblApplyDate;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblMoney;
		protected static string disPlaysCode="";
		protected System.Web.UI.WebControls.DataGrid dgPostail;
		protected System.Web.UI.WebControls.Label  lblMessage;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody_Pay;
		protected System.Web.UI.WebControls.Table tbAnnex;
		protected static string ApplySheetHeadPk="0";
		protected System.Web.UI.WebControls.Label lblPushMoney;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblDeliveryDate;
		protected System.Web.UI.WebControls.Label lblSubmitDate;
		protected System.Web.UI.WebControls.Label lblSheetNo;
		protected System.Web.UI.WebControls.DataGrid dgCCBodyInfo;
		protected System.Web.UI.WebControls.Panel Panel3;
		protected System.Web.UI.WebControls.TextBox txtcheckupplan;
		protected System.Web.UI.WebControls.CheckBox chbmeet;
		protected System.Web.UI.WebControls.CheckBox chbcheckup;
		protected System.Web.UI.WebControls.CheckBox chblimits;
		protected System.Web.UI.WebControls.CheckBox chblimit;
		protected System.Web.UI.WebControls.TextBox txtabountMemo;
		protected System.Web.UI.WebControls.TextBox txtbacterindate;
		protected System.Web.UI.WebControls.CheckBox chbbacterin;
		protected System.Web.UI.WebControls.TextBox txtpassportdate;
		protected System.Web.UI.WebControls.TextBox txtPassportno;
		protected System.Web.UI.WebControls.CheckBox chkPassport;
		protected System.Web.UI.WebControls.TextBox txtVisaDate;
		protected System.Web.UI.WebControls.CheckBox chbVisa;
		protected System.Web.UI.WebControls.TextBox txtPreback;
		protected System.Web.UI.WebControls.TextBox txtPreabound;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.WebControls.TextBox txtCCMemo;
		protected System.Web.UI.WebControls.TextBox txtWithwho;
		protected System.Web.UI.WebControls.TextBox txtwithapps;
		protected System.Web.UI.WebControls.TextBox txtAppclass;
		protected System.Web.UI.WebControls.DropDownList ddlCCType;
		protected System.Web.UI.WebControls.TextBox txtGocity;
		protected System.Web.UI.WebControls.TextBox txtDateTo;
		protected System.Web.UI.WebControls.TextBox txtDateFrom;
		protected System.Web.UI.WebControls.Panel panel1;
		protected System.Web.UI.WebControls.DataGrid dgYQInfo;
		protected System.Web.UI.WebControls.Panel Panel4;
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
		protected System.Web.UI.WebControls.HyperLink hlSumCheck;
		protected System.Web.UI.WebControls.Label lblready;
		protected System.Web.UI.WebControls.Label lblOutMoney;
		protected System.Web.UI.WebControls.DataGrid dgLBBody;
		protected string NumOfAnnex="0";

		#endregion 
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			//string disCode=Request.QueryString["disCode"].ToString();  //替代人工号
			string applyHeadPk=Request.QueryString["applyHeadPk"].ToString();  //将要审批的单据ID
			//disPlaysCode=disCode;
			ApplySheetHeadPk=applyHeadPk;

			if(!Page.IsPostBack)
			{
				try
				{
					BindBaseInfoOfApply(int.Parse(applyHeadPk));
					BindApplyBodyInfo(int.Parse(applyHeadPk));
					BindBudgetInfo(int.Parse(applyHeadPk));
					BindApplyRecord(int.Parse(applyHeadPk));
					BindAnnexInfo(int.Parse(applyHeadPk)); //附件信息
				}
				catch(Exception ex)
				{
					Common.Log.Logger.Log("CheckFlow.ApplySheetBodyInfo2",ex.Message );
				}
			}
		}

		private void BindBaseInfoOfApply(int applyHeadPk)
		{
			try
			{
				//表头信息
				#region 
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
				if(applyHead!=null)
				{
					Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
					if(applyType!=null)
					{
						this.lblApplyType.Text=applyType.ApplyTypeName ;
					}
					Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);
					if(applyBudget!=null)
					{
						this.lblMoney.Text=applyBudget.SheetMoney.ToString("N");
						Entiy.BaseAccountSubject subject = Entiy.BaseAccountSubject.FindByCode(applyBudget.SheetSubject);
						if(subject!=null)
						{
							this.lblSubject.Text= subject.Dispname;
						}
					}
					this.lblApplyDate.Text=applyHead.ApplyDate.ToString("yyyy-MM-dd");

					Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode );
					if(dept!=null)
					{
						this.lblDpteAndPerson.Text =dept.DeptName ;
					}
					Entiy.BasePerson person=Entiy.BasePerson.Find(applyHead.ApplyPersonCode);
					if(person!=null)
					{
						this.lblDpteAndPerson.Text = this.lblDpteAndPerson.Text  + "    "+ person.Name;
					}

//					if(applyHead.DeliveryDate.Year  > 1910)
//					{
						this.lblDeliveryDate.Text=applyHead.DeliveryDate.ToString();
//					}
					if(applyHead.SubmitDate.Year > 1910 )
					{
						this.lblSubmitDate.Text = applyHead.SubmitDate.ToString("yyyy-MM-dd HH:mm:ss");
					}
					this.lblSheetNo.Text= applyHead.ApplySheetNo ;
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
		}

		private void BindApplyRecord(int applyHeadPk)
		{
			DataSet ds=Bussiness.ApplyAuditingBLL.GetApplyRecord(applyHeadPk);
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

		private void BindApplyBodyInfo(int applyHeadPk)
		{
			#region 
			//			//表体详细信息
			//			DataSet ds= Bussiness.ApplyAuditingBLL.GetApplySheetBodyInfo(applyHeadPk);
			//			if(ds!=null)
			//			{
			//				this.dgApplyBody.DataSource=ds;
			//			}
			//			else
			//			{
			//				this.dgApplyBody.DataSource=null;
			//			}
			//			this.dgApplyBody.DataBind();
			#endregion 

			//表体详细信息
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			if(applyHead!=null)
			{
				Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
				if(applyType !=null)
				{
					//applyHead=null;
					if("ApplySheetBody_Purchase".Equals(applyType.ApplySheetBodyTableName) )
					{
						this.dgApplyBody_Pay.Visible=false ;
						
						//表体详细信息
//
//						if(applyHead.ApplyTypeCode =="102")   //暂时写死，以后可改到配置表 102为劳保    启用小额固定资产后再打开 此段注释
//						{
							this.dgApplyBody.Visible = false;
							//劳保购买
							DataSet ds= Bussiness.ApplyAuditingBLL.GetApplySheetBodyInfo(applyHeadPk);
							if(ds!=null)
							{
								this.dgLBBody .DataSource=ds;
							}
							else
							{
								this.dgLBBody.DataSource=null;
							}
							this.dgLBBody.DataBind();

//						}
//						else
//						{
//							this.dgLBBody.Visible = false;
//							//实物购买
//
//							DataSet ds= Bussiness.ApplyAuditingBLL.GetApplyPurchaseBodyInfo(applyHeadPk);
//
//							if(ds!=null)
//							{
//								this.dgApplyBody.DataSource=ds;
//							}
//							else
//							{
//								this.dgApplyBody.DataSource=null;
//							}
//							this.dgApplyBody.DataBind();
//						}
					}
					else if("ApplySheetBody_Pay".Equals(applyType.ApplySheetBodyTableName))
					{
						this.dgApplyBody.Visible=false;

						//报销类表体详细信息
						DataSet ds=Bussiness.ApplyAuditingBLL.GetApplySheetBodyPayInfo(applyHeadPk);
						if(ds!=null )
						{
							this.dgApplyBody_Pay.DataSource=ds;
						}
						else
						{
							this.dgApplyBody_Pay.DataSource=null;
						}
						this.dgApplyBody_Pay.DataBind();
					}
					else if("ApplySheetBody_EvectionCharge".Equals(applyType.ApplySheetBodyTableName))
					{
						this.dgApplyBody.Visible=false;
						this.dgApplyBody_Pay.Visible=false ;

						this.panel1.Visible= true;

						//出差类表体详细信息
						BindCCInfo(applyHeadPk);
					}
					else if("ApplySheetBody_Banquet".Equals(applyType.ApplySheetBodyTableName ))
					{
						//宴请单类型
						this.dgApplyBody.Visible=false;
						this.dgApplyBody_Pay.Visible=false ;
						this.Panel5.Visible= true;
						this.Panel4.Visible= true;

						//宴请单 表体详细
						BindYQInfo(applyHeadPk);
					}
				}
			}
		}

		private void BindYQInfo(int applyHeadPk)
		{
			Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
			if(applyHead != null)
			{
				Entiy.ApplySheetBodyBanquet  applyBanquet = Entiy.ApplySheetBodyBanquet.FindByApplyHeadPk(applyHead.ApplySheetHeadPk);
				if(applyBanquet != null)
				{
					#region  

					// 附值 
					this.Textbox2.Text = applyBanquet.DateFrom.ToString("yyyy-MM-dd") ;
					this.Textbox1.Text   = applyBanquet.DateTo.ToString("yyyy-MM-dd") ;
					this.txtVisitCompany.Text=applyBanquet.CallinCompany ;
					this.txtCallinPerson.Text=applyBanquet.CallinPerson ;
					this.txtCallinMemo.Text  =applyBanquet.CallinMemo  ;
					this.txtVisitDept.Text   =applyBanquet.InviteDept ;
					this.txtVisitPerson.Text =applyBanquet.InvitePerson ;
					this.txtvisitphone.Text  =applyBanquet.InvietDeptInfo ; 
					this.txtRelationDept.Text=applyBanquet.RelationDept ;
					this.txtTalkPlace.Text   =applyBanquet.Talkplace  ;
					if(applyBanquet.NeedTea == 1)
					{
						this.chbTea.Checked =true; 
					}
					else
					{
						this.chbTea.Checked =false; 
					}
					if(applyBanquet.LookFactory==1)
					{
						this.chblookFactory.Checked=true;
					}
					else
					{
						this.chblookFactory.Checked=false;
					}
					this.txtLookNum.Text =applyBanquet.Numofvisit.ToString();
					if(applyBanquet.Lunch==1)
					{
						this.chbLunch.Checked =true;
					}
					else
					{
						this.chbLunch.Checked =false;
					}
					this.txtOtherNeed.Text = applyBanquet.Other ; 
					this.txtEspecialRequest.Text = applyBanquet.EspecialRequest ; 

					
					if(applyBanquet.Carplan == 1  )
					{
						this.RadioButton1.Checked =true;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=false;
					}
					else if(applyBanquet.Carplan == 2 )
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=true;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=false;			
					}
					else if( applyBanquet.Carplan == 3 )
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton4.Checked=false;
						this.RadioButton3.Checked=true;//车辆安排(往返)
					}
					else
					{
						this.RadioButton1.Checked =false;//车辆安排(接)
						this.RadioButton2.Checked=false;//车辆安排(送)
						this.RadioButton3.Checked=false;//车辆安排(往返)
						this.RadioButton4.Checked=true;
					}

					#endregion 
				}

				string cmdStr = "select * from ApplySheetBody_Pay  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";

				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery (cmdStr);
				dgYQInfo.Visible= true;

				if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count >0 )
				{
					ds.Tables[0].Columns.Add("seqNum");        //序号
					for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
					{
						int Num=i+1;
						ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					}
				}

				this.dgYQInfo.DataSource= ds;
				this.dgYQInfo.DataBind();
			}

		}

		private void BindCCInfo(int applyHeadPk)
		{
			Entiy.ApplySheetHead applyHead = Entiy.ApplySheetHead.Find(applyHeadPk);
			if(applyHead != null)
			{
				#region 表体信息
				Entiy.ApplySheetBodyEvection applyEvection = Entiy.ApplySheetBodyEvection.FindByApplyHeadPk(applyHead.ApplySheetHeadPk);
				if(applyEvection != null)
				{
					this.txtDateFrom.Text=applyEvection.DateFrom.ToString("yyyy-MM-dd");//出差日期
					this.txtDateTo.Text =  applyEvection.DateTo.ToString("yyyy-MM-dd") ;//出差结束日期
					this.txtGocity.Text=applyEvection.GoCity ;
					this.ddlCCType.SelectedValue  = applyEvection.EvecionType ;         //出差类型
					this.txtAppclass.Text =	applyEvection.AppClass ;                    //差旅费等级
					this.txtwithapps.Text = applyEvection.Withapps.ToString();          //同行人数
					this.txtWithwho.Text   = applyEvection.Withwho ;                    //同行人
					this.txtCCMemo.Text  = applyEvection.Appduty ;                      //出差理由
					// 国外出差信息applyEvection
					this.txtPreabound.Text =applyEvection.Preabroaddate ;               //上次出国日期
					this.txtPreback.Text=applyEvection.Prebackdate  ;                   //上次回国日前
					if( applyEvection.Visa  == 1)                                       //是否有visa
					{
						this.chbVisa.Checked=true;
					}
					else{this.chbVisa.Checked =false;}
					this.txtVisaDate.Text  =applyEvection.Visadate ;                    //visa有效期
					if(applyEvection.Passport == 1)                                     //是否有护照
					{
						this.chkPassport.Checked = true;
					}
					else
					{	this.chkPassport.Checked = false;}
					this.txtpassportdate.Text = applyEvection.Passportdate ;            //护照有效期
					if(applyEvection.Bacterin == 1)                                     //是否注射疫苗
					{
						this.chbbacterin .Checked =true; 
					}
					else{this.chbbacterin.Checked=false;}
					this.txtbacterindate.Text = applyEvection.Bacterindate;             //疫苗时间
					this.txtabountMemo.Text  = applyEvection.Memo ;                     //国外出差备注
					if(applyEvection.Limitdartcle == 1)                                 //是否携带限制物品
					{
						this.chblimit .Checked= true;
					}
					else{this.chblimit.Checked=false;}
					if(applyEvection.Limittech == 1)                                    //是否有限制技术等
					{
						this.chblimits.Checked=true;
					}
					else{this.chblimits.Checked=false;}
					if(applyEvection.Checkup == 1)                                      //是否要体检
					{
						this.chbcheckup.Checked =true;
					}
					else{this.chbcheckup.Checked=false;}
					if(applyEvection.Meetcondition == 1)                                //是否符合出口条件
					{
						this.chbmeet.Checked= true;
					}
					else{this.chbmeet.Checked=false;}

					this.txtcheckupplan.Text = applyEvection.Checkupdate ;              //体检计划等

				}
				#endregion

				string cmdStr = @"SELECT ApplySheetBody_EvectionCharge.*, 
									Base_CommonCode.CodeName AS CodeName
								FROM ApplySheetBody_EvectionCharge INNER JOIN
									Base_CommonCode ON 
									ApplySheetBody_EvectionCharge.ChargePro = Base_CommonCode.Code AND 
									ApplySheetBody_EvectionCharge.ApplySheetHead_Pk =" + applyHead.ApplySheetHeadPk + " ";


				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery (cmdStr);
				dgCCBodyInfo.Visible= true;

				if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count >0 )
				{
					ds.Tables[0].Columns.Add("seqNum");        //序号
					for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
					{
						int Num=i+1;
						ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					}
				}

				this.dgCCBodyInfo.DataSource= ds;
				this.dgCCBodyInfo.DataBind();
			}
		}
		
		
		private void BindBudgetInfo(int applyHeadPk)   //int  key,int iYear,int iMonth,string applyDept,string Sheetsubject
		{
			//预算情况
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

			if(applyHead!=null && applyBudget!=null)
			{
				Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);
				if(budgetAccount!=null)
				{
					//					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);
					Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
					if(dept!=null && dept.BudgetDeptCode!=null)
					{
						DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyBudget.SheetSubject );
						if(ds != null && ds.Tables.Count > 0 )
						{
							//							this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");
							//							this.lblPushMoney.Text=budgetAccount.PlanMoney.ToString("#,###.##");
							decimal CheckedMoney = 0 ; 
							decimal TotalAllowOutMoney = 0 ; 

							CheckedMoney = applyBudget.SumCheckMoney ;
							TotalAllowOutMoney = applyBudget.AllowOutMoney ; 


							this.lblBudget.Text=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString()).ToString("N");
							this.lblPushMoney.Text=decimal.Parse(ds.Tables[0].Rows[0]["planmoney"].ToString()).ToString("N");
							this.lblChange.Text=ChangeMoney.ToString("N");
							this.lblSheetMoney.Text=applyBudget.SheetMoney.ToString("N");
							this.hlSumCheck.Text = applyBudget.SumCheckMoney.ToString("N");
							this.lblready.Text = decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString()).ToString("N");
							//this.lblOutMoney.Text = ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString() ;
							this.lblOutMoney.Text = applyBudget.AllowOutMoney.ToString("N");
							//给已用金额附查询链接
							if(applyBudget.SumCheckMoney > 0 )
							{
								string url ="../../BaseData/BudGet/UsedMoneyListInfo.aspx?budgetaccountpk=" + budgetAccount.BudgetAccountPk ;
								this.hlSumCheck.NavigateUrl =  url ; 
							}

							//如果单据为新建状态，已经使用金额不能为SumCheckMoney 
							if(applyHead.ApplyProcessCode == "101" )
							{
								this.hlSumCheck.Text =decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()).ToString("N"); 
								this.lblOutMoney.Text = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()).ToString("N");
								CheckedMoney = decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()); 
								TotalAllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());

							}



							//判断超支规则，用预算，推算
					
							int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(applyHead.ApplyDate);
							decimal tempLeft = 0 ; 
							if (budgetStandard == 1 )  //预算
							{
								tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + ChangeMoney + TotalAllowOutMoney -applyBudget.SheetMoney -CheckedMoney - decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString()) ;
							}
							else if(budgetStandard == 2 ) // 推算
							{
								tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["planmoney"].ToString())  + ChangeMoney + TotalAllowOutMoney -applyBudget.SheetMoney -CheckedMoney - decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString()) ;
							}
//							if(tempLeft < 0)
//							{
//								this.lblLeft.ForeColor=Color.Red;
//							}
							this.lblLeft.Text=tempLeft.ToString("N");
						}
					}
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private int IsAuditinged()
		{
			//单据是否已经被同角色的其他人审批过了!

			
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

		

	
	




	}
}
