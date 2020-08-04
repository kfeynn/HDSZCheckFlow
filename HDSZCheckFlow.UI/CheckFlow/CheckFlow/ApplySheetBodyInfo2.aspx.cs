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
	/// AuditingForOneApply ��ժҪ˵����
	/// </summary>
	public class ApplySheetBodyInfo2 : System.Web.UI.Page
	{

		#region   ����

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
			//string disCode=Request.QueryString["disCode"].ToString();  //����˹���
			string applyHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID
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
					BindAnnexInfo(int.Parse(applyHeadPk)); //������Ϣ
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
				//��ͷ��Ϣ
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
			// .���ݵ���ͷ,�����ݿ����ҵ���Ӧ����
			Entiy.ApplySheetAnnex []applyAnnexs=Entiy.ApplySheetAnnex.FindByApplyHeadPk(applyHeadPk);
			if(applyAnnexs!=null && applyAnnexs.Length>0)
			{
				
				NumOfAnnex = applyAnnexs.Length.ToString();
				//. ���ɹ��� , 1��һ����¼
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
				//û���ҵ� ,table ��ӡ�� ,δ�ҵ���ʾ��Ϣ.....
				TableRow  tr=new TableRow();
				TableCell td=new TableCell();
				td.Text="<font color='red'>û�и�����Ϣ</font>"; 
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
			//			//������ϸ��Ϣ
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

			//������ϸ��Ϣ
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
						
						//������ϸ��Ϣ
//
//						if(applyHead.ApplyTypeCode =="102")   //��ʱд�����Ժ�ɸĵ����ñ� 102Ϊ�ͱ�    ����С��̶��ʲ����ٴ� �˶�ע��
//						{
							this.dgApplyBody.Visible = false;
							//�ͱ�����
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
//							//ʵ�ﹺ��
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

						//�����������ϸ��Ϣ
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

						//�����������ϸ��Ϣ
						BindCCInfo(applyHeadPk);
					}
					else if("ApplySheetBody_Banquet".Equals(applyType.ApplySheetBodyTableName ))
					{
						//���뵥����
						this.dgApplyBody.Visible=false;
						this.dgApplyBody_Pay.Visible=false ;
						this.Panel5.Visible= true;
						this.Panel4.Visible= true;

						//���뵥 ������ϸ
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

					// ��ֵ 
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
						this.RadioButton1.Checked =true;//��������(��)
						this.RadioButton2.Checked=false;//��������(��)
						this.RadioButton3.Checked=false;//��������(����)
						this.RadioButton4.Checked=false;
					}
					else if(applyBanquet.Carplan == 2 )
					{
						this.RadioButton1.Checked =false;//��������(��)
						this.RadioButton2.Checked=true;//��������(��)
						this.RadioButton3.Checked=false;//��������(����)
						this.RadioButton4.Checked=false;			
					}
					else if( applyBanquet.Carplan == 3 )
					{
						this.RadioButton1.Checked =false;//��������(��)
						this.RadioButton2.Checked=false;//��������(��)
						this.RadioButton4.Checked=false;
						this.RadioButton3.Checked=true;//��������(����)
					}
					else
					{
						this.RadioButton1.Checked =false;//��������(��)
						this.RadioButton2.Checked=false;//��������(��)
						this.RadioButton3.Checked=false;//��������(����)
						this.RadioButton4.Checked=true;
					}

					#endregion 
				}

				string cmdStr = "select * from ApplySheetBody_Pay  where ApplySheetHead_Pk=" + applyHead.ApplySheetHeadPk + " ";

				DataSet ds = Bussiness.ComQuaryBLL.ExecutebyQuery (cmdStr);
				dgYQInfo.Visible= true;

				if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count >0 )
				{
					ds.Tables[0].Columns.Add("seqNum");        //���
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
				#region ������Ϣ
				Entiy.ApplySheetBodyEvection applyEvection = Entiy.ApplySheetBodyEvection.FindByApplyHeadPk(applyHead.ApplySheetHeadPk);
				if(applyEvection != null)
				{
					this.txtDateFrom.Text=applyEvection.DateFrom.ToString("yyyy-MM-dd");//��������
					this.txtDateTo.Text =  applyEvection.DateTo.ToString("yyyy-MM-dd") ;//�����������
					this.txtGocity.Text=applyEvection.GoCity ;
					this.ddlCCType.SelectedValue  = applyEvection.EvecionType ;         //��������
					this.txtAppclass.Text =	applyEvection.AppClass ;                    //���÷ѵȼ�
					this.txtwithapps.Text = applyEvection.Withapps.ToString();          //ͬ������
					this.txtWithwho.Text   = applyEvection.Withwho ;                    //ͬ����
					this.txtCCMemo.Text  = applyEvection.Appduty ;                      //��������
					// ���������ϢapplyEvection
					this.txtPreabound.Text =applyEvection.Preabroaddate ;               //�ϴγ�������
					this.txtPreback.Text=applyEvection.Prebackdate  ;                   //�ϴλع���ǰ
					if( applyEvection.Visa  == 1)                                       //�Ƿ���visa
					{
						this.chbVisa.Checked=true;
					}
					else{this.chbVisa.Checked =false;}
					this.txtVisaDate.Text  =applyEvection.Visadate ;                    //visa��Ч��
					if(applyEvection.Passport == 1)                                     //�Ƿ��л���
					{
						this.chkPassport.Checked = true;
					}
					else
					{	this.chkPassport.Checked = false;}
					this.txtpassportdate.Text = applyEvection.Passportdate ;            //������Ч��
					if(applyEvection.Bacterin == 1)                                     //�Ƿ�ע������
					{
						this.chbbacterin .Checked =true; 
					}
					else{this.chbbacterin.Checked=false;}
					this.txtbacterindate.Text = applyEvection.Bacterindate;             //����ʱ��
					this.txtabountMemo.Text  = applyEvection.Memo ;                     //������ע
					if(applyEvection.Limitdartcle == 1)                                 //�Ƿ�Я��������Ʒ
					{
						this.chblimit .Checked= true;
					}
					else{this.chblimit.Checked=false;}
					if(applyEvection.Limittech == 1)                                    //�Ƿ������Ƽ�����
					{
						this.chblimits.Checked=true;
					}
					else{this.chblimits.Checked=false;}
					if(applyEvection.Checkup == 1)                                      //�Ƿ�Ҫ���
					{
						this.chbcheckup.Checked =true;
					}
					else{this.chbcheckup.Checked=false;}
					if(applyEvection.Meetcondition == 1)                                //�Ƿ���ϳ�������
					{
						this.chbmeet.Checked= true;
					}
					else{this.chbmeet.Checked=false;}

					this.txtcheckupplan.Text = applyEvection.Checkupdate ;              //���ƻ���

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
					ds.Tables[0].Columns.Add("seqNum");        //���
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
			//Ԥ�����
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
							//�����ý���ѯ����
							if(applyBudget.SumCheckMoney > 0 )
							{
								string url ="../../BaseData/BudGet/UsedMoneyListInfo.aspx?budgetaccountpk=" + budgetAccount.BudgetAccountPk ;
								this.hlSumCheck.NavigateUrl =  url ; 
							}

							//�������Ϊ�½�״̬���Ѿ�ʹ�ý���ΪSumCheckMoney 
							if(applyHead.ApplyProcessCode == "101" )
							{
								this.hlSumCheck.Text =decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()).ToString("N"); 
								this.lblOutMoney.Text = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString()).ToString("N");
								CheckedMoney = decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()); 
								TotalAllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());

							}



							//�жϳ�֧������Ԥ�㣬����
					
							int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(applyHead.ApplyDate);
							decimal tempLeft = 0 ; 
							if (budgetStandard == 1 )  //Ԥ��
							{
								tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + ChangeMoney + TotalAllowOutMoney -applyBudget.SheetMoney -CheckedMoney - decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString()) ;
							}
							else if(budgetStandard == 2 ) // ����
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		

		private int IsAuditinged()
		{
			//�����Ƿ��Ѿ���ͬ��ɫ����������������!

			
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
			if(applyHead!=null && applyHead.CurrentCheckRole!=null)
			{
				Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
				if(prossType!=null &&  prossType.IsDisallow==0)  //�ȿ�����״̬�Ƿ�Ϊ����
				{
					//�жϵ�ǰ������ɫ���Ƿ����Լ�  ,,�����ڻ����ⶼ����
					string UserCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
					int i=Bussiness.UserInfoBLL.GetCountOfUserRole(applyHead.CurrentCheckRole ,UserCode,applyHead.ApplyDeptCode);
					if(i>0)
					{
						return 1; //�����Լ�
					}
					else
					{
						return 0; //���ܱ�����������
					}
				}
				else
				{
					return 0;                 //����״̬Ϊnull���� Ϊ����״̬.. ��������
				}
			}
			else
			{
				return 2; //δ�ҵ�����,����
			}
		}

		

	
	




	}
}
