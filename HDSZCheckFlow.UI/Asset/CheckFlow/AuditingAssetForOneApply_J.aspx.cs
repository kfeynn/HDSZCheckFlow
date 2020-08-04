//	public class AuditingAssetForOneApply_J : System.Web.UI.Page
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
	public class AuditingAssetForOneApply_J : System.Web.UI.Page
	{

		#region   ����

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
			string disCode=Request.QueryString["disCode"].ToString();  //����˹���
			string ApplyHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID

			//���ֹ�����λ�ò��䡣�� ��ûЧ����
			//this.Page.SmartNavigation = true;

			if(!Page.IsPostBack)
			{
				try
				{
					//��ͷ��Ϣ
					BindBaseInfoOfApply(int.Parse(ApplyHeadPk));
					//������Ϣ
					BindApplyBodyInfo(int.Parse(ApplyHeadPk));
					//Ԥ����Ϣ
					BindBudgetInfo(int.Parse(ApplyHeadPk));
					//������¼
					BindApplyRecord(int.Parse(ApplyHeadPk));
					//������Ϣ
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
				#region ��ͷ��Ϣ
				Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
				if(ApplyHead!=null)
				{
					Entiy.ApplyType ApplyType=Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
					if(ApplyType!=null)
					{
						//��������
						this.lblApplyType.Text=ApplyType.ApplyTypeName;
					}
					Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);
					if(AssetBudget != null)
					{
						//���ݽ��
						this.lblMoney.Text = AssetBudget.SheetRmbMoney.ToString("N2");
						//Ԥ����Ŀ
						this.lblSubject.Text = AssetBudget.ItemName ;  
						//Ԥ�����
						if(AssetBudget.SubmitType == 2 )
						{
							this.lblBudgetType.Text = "Ԥ����";
							this.lblBudgetType.ForeColor = Color.Red ;
						}
						else
						{
							this.lblBudgetType.Text = "Ԥ����";
						}
					}
					//��������
					this.lblApplyDate.Text=ApplyHead.ApplyDate.ToString("yyyy-MM-dd");

					Entiy.BaseDept dept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(dept!=null)
					{
						//���벿��
						this.lblDpteAndPerson.Text =dept.DeptName ;
					}
					Entiy.BasePerson person=Entiy.BasePerson.Find(ApplyHead.ApplyPersonCode);
					if(person!=null)
					{
						//���벿�� && ��Ա
						this.lblDpteAndPerson.Text = this.lblDpteAndPerson.Text  + "    "+ person.Name;
					}
					//Ҫ������
					this.lblDeliveryDate.Text=ApplyHead.DeliveryDate.ToString();
					if(ApplyHead.SubmitDate.Year > 1910 )
					{
						//������дʱ��
						this.lblSubmitDate.Text = ApplyHead.SubmitDate.ToString("yyyy-MM-dd HH:mm:ss");
					}
					//���ݺ�
					this.lblSheetNo.Text= ApplyHead.ApplySheetNo ;

					//�᰸���ɼ��ﵽЧ��
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
			#region ���ݸ�����Ϣ 

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
				//û���ҵ� ,table ��ӡ�� ,δ�ҵ���ʾ��Ϣ.....
				TableRow  tr=new TableRow();
				TableCell td=new TableCell();
				td.Text="<font color='red'>û�и�����Ϣ</font>"; 
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
			//������ϸ��Ϣ
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(ApplyHead!=null)
			{
				Entiy.ApplyType ApplyType=Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
				if(ApplyType !=null)
				{
					//ApplyHead=null;
					if("Asset_ApplySheet_Body".Equals(ApplyType.ApplySheetBodyTableName) )
					{
						//������ϸ��Ϣ
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

		//���ݵ��ݺţ���ѯ����Ԥ��Id
		private int FindAssetBudgetPk(int ApplyHeadPk)
		{
			int AssetBudgetPk= 0 ;
			//��Ҫ���� ���꣬Ԥ�㲿�ű�ţ���Ŀ 

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
			#region Ԥ�����

			decimal BudgetMoney = 0;
			decimal ReadyPay    = 0;
 

			//���ݱ�ͷ
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			//����Ԥ��
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadPk);

			if(ApplyHead !=null && ApplyBudget !=null )
			{
				//�������
				this.lblSheetMoney.Text= ApplyBudget.SheetRmbMoney.ToString("N2");
				//�Ѿ�ʹ��
				this.hlSumCheck.Text = ApplyBudget.SumCheckMoney.ToString("N2");
				//�����ý���ѯ����
				//				if(ApplyBudget.SumCheckMoney > 0)
				//				{
				//������ӪԤ���ѯ��ַ����
				//					string url ="../../BaseData/Asset/Asset_Budget_UseDetails.aspx?applyHeadPk=" + ApplyHead.ApplySheetHeadPk;
				//					this.hlSumCheck.NavigateUrl =  url ; 
				int AssetBudgetPk = FindAssetBudgetPk(ApplyHeadPk) ; 
				string url ="../../BaseData/Asset/Asset_Budget_UseDetails_J.aspx?AssetBudgetPk=" + AssetBudgetPk;
				this.hlSumCheck.NavigateUrl =  url ; 
				//				}
				//Ԥ������
				this.lblOutMoney.Text = ApplyBudget.AllowOutMoney.ToString("N2");


				//����������ĿԤ��
				Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
				if(Dept != null )
				{
					//��ȡ��ĿԤ����Ϣ
					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,ApplyBudget.ItemName);
					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
					{
						//Ԥ��
						this.lblBudget.Text= decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString()).ToString("N2");
						//��̯
						this.lblready.Text = decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString()).ToString("N2") ;

						BudgetMoney = decimal.Parse(ds.Tables[0].Rows[0]["BudgetMoney"].ToString());
						ReadyPay    = decimal.Parse(ds.Tables[0].Rows[0]["ReadyPay"].ToString());
					}
				}

				//����ʣ����
				decimal LeftMoney = BudgetMoney + ApplyBudget.AllowOutMoney - ApplyBudget.SumCheckMoney - ReadyPay - ApplyBudget.SheetRmbMoney ;

				this.lblLeft.Text = LeftMoney.ToString("N2");


			}

			#endregion

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

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID

			string disPlaysCode=Request.QueryString["disCode"].ToString();  //����˹���

			//ͬ��

			// 1. ��¼��������¼��.....

			// 2. ���´˵��ݵ���һ������ɫ , ��һ��ɫ�����Ļ�,��������һ��ɫ

			// 3. �����Ƿ������. IsInCompany 

			// 4. ���½���״̬ 

			// 5. ������¼���ϱߵ��������

			// 6. �ҵ���ذ�ť

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
				this.lblMessage.Text="�����ѱ�ͬ����Ա����";
			}

		}

		private int IsAuditinged()
		{
			//�����Ƿ��Ѿ���ͬ��ɫ����������������!

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID


			
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

		#region  ��д�� Bussiness.ApplyAuditingBLL.Flow_AgreeApplySheet
		//		private void Flow_AgreeApplySheet(int agreeType)
		//		{
		//			try
		//			{
		//				//agreeType : 1ͬ�� , 0 �ܾ�
		//
		//				//1. ��������־��¼�� ��¼��
		//				string myCode=Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));
		//				string posital=this.txtPosital.Text;
		//
		//				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(int.Parse(ApplySheetHeadPk));
		//				if(applyHead!=null)
		//				{
		//					Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
		//					applyRecord.ApplySheetHeadPk=int.Parse(ApplySheetHeadPk);       //��������
		//					applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//�������  ������/��˾�� 
		//					applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//������ɫ
		//					applyRecord.CheckSetp=applyHead.CheckSetp;						//������
		//					applyRecord.CheckPersonCode=myCode;								//������Code
		//					applyRecord.CheckComment=posital;								//�������
		//					applyRecord.Checkdate=DateTime.Now;								//����ʱ��
		//					if(!"".Equals(disPlaysCode))                     
		//					{
		//						applyRecord.DisplaysPersonCode = disPlaysCode;				//�������Code
		//						applyRecord.IsDisplays=1;									//�Ƿ��������
		//					}
		//					applyRecord.IsPass=agreeType;									//�Ƿ�ͬ��
		//
		//					applyRecord.Create();
		//
		//					if(agreeType==1)
		//					{
		//						#region   ͬ�� 
		//						//2.���´˵��ݵ���һ������ɫ 
		//						string Message="";
		//						int CheckStep=0,DeptToCompany=0 ;
		//						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(int.Parse(ApplySheetHeadPk),out CheckStep,out DeptToCompany,out Message);
		//						applyHead.CurrentCheckRole=checkRole ;   //������ɫ
		//						applyHead.CheckSetp=CheckStep;           //����
		//						if(DeptToCompany == 1 )                  //����״̬
		//						{
		//							applyHead.IsCheckInCompany=1;											//�����Ƿ������. IsInCompany 
		//							Entiy.ApplyProcessType prossType=Entiy.ApplyProcessType.Find(applyHead.ApplyProcessCode);
		//							if(prossType !=null && prossType.IsSubmitAgain==1)
		//							{
		//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyAgain;
		//							}
		//							else
		//							{
		//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;		//���½���״̬Ϊ��˾��
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
		//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DeptPross;		//���½���״̬Ϊ�����ڿ�ʼ������
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
		//								applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		//���½���״̬Ϊ����������
		//							}
		//						}
		//						applyHead.Update();
		//						#endregion  
		//					}
		//					else
		//					{
		//						#region  �ܾ�
		//						//3.���½���״̬Ϊ   ����  ,������ɫ��Ϊ�� ,����ҲΪ�� 
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

			string ApplySheetHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID
			string disPlaysCode=Request.QueryString["disCode"].ToString();  //����˹���



			//�ܾ�
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
				this.lblMessage.Text="�����ѱ�ͬ����Ա����";
			}

			

		}

		private void btnGoBack_Click(object sender, System.EventArgs e)
		{
			//�ص��ҵ�����ҳ��
			Response.Redirect("../../CheckFlow/CheckFlow/MyAuditing_J.aspx");
		}




	}
}
