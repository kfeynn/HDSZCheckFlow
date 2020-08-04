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
	/// AddAssetApply ��ժҪ˵����
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

			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				InitPageForAdd();
				//��һ����Ŀ
				string Ids = "";
				Ids = GetQuery("Ids");
				InitApplyInfo(Ids);
			}
		}

		#region ��ȡ����
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

		#region  ajax����,�޸ı���ֵ
		//[AjaxMethod()]
        [System.Web.Services.WebMethod]
		public   void SaveFBodyInfo(string FBId,string Value ,int Flag)
		{
			try
			{
				//������������ 
				//FBId���۸�þ�����ID.Value���޸ĺ��ֵ.Flag������޸ĵ��ֶΣ�Ŀǰ��4��  12 ������� 13�������� 14����۸� 15����Ӧ�̣�
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

						//��¼�þ�����
						FinallyCheckBody.CurrTypeCode = Value ; 
						//��¼���ֵĻ�׼����
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

		#region  ��ʼ�������˵�
		private void InitPageForAdd()
		{
			try
			{
				//Ϊ�����ؼ���ֵ
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

				//�󶨿���

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
			//0. ����������Զ��ŷָ�
			string []Id = Ids.Split(new char[]{','});

			if(Id.Length > 0 )
			{
				Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(int.Parse(Id[0]));

				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(AssetBody.ApplySheetHeadPk );

				Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(AssetBody.ApplySheetHeadPk );

				//���¼۸�þ���ͷ��Ϣ

				//�����۸�þ���ͷ��Ϣ
				Entiy.AssetFinallyPriceCheck FinallyCheck =new HDSZCheckFlow.Entiy.AssetFinallyPriceCheck();

				FinallyCheck.ApplySheetHeadPk = AssetBody.ApplySheetHeadPk ; 
				FinallyCheck.ItemName =  ApplyBudget.ItemName ;

				FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.NewPross;   //�½�״̬
				FinallyCheck.MakeDate = DateTime.Now ;

				//��ͬ��
				FinallyCheck.BargainNo = "";

				/////// ����������Ŀ
				
				FinallyCheck.Create();

				//��¼ �������� 
				this.hideApplyCheckHead.Value  = FinallyCheck.Id.ToString() ;

				//���¼۸�þ�����
				////                     ������
				foreach(string i in Id)
				{
					Entiy.AssetFinallyPriceCheckBody FinallyCheckBody = new HDSZCheckFlow.Entiy.AssetFinallyPriceCheckBody();

					FinallyCheckBody.AssetApplySheetBodyId = int.Parse(i);
					FinallyCheckBody.FinallyPriceCheckId   = FinallyCheck.Id ;


					FinallyCheckBody.Create();
				}

				//1. �󶨱�ͷ��Ϣ
				BindApplyHead(AssetBody.ApplySheetHeadPk);
				//2. ��ʾԤ����Ϣ
				BindBudgetInfo(AssetBody.ApplySheetHeadPk);
				//3. �󶨱�����Ϣ
				BindApplyBodyInfo(AssetBody.ApplySheetHeadPk,Ids,FinallyCheck.Id.ToString());

				//��Ӹ�������
				this.hyLindToAnnex.Visible=true;
				this.hyLindToAnnex.Target = "_blank";
				this.hyLindToAnnex.NavigateUrl= "../../Asset/PriceCheck/ApplySheetAnnexForFinallyCheck.aspx?FinallyCheckId=" + FinallyCheck.Id.ToString()   ;			


			}
		}


		


		/// <summary>
		/// �󶨱�ͷ��Ϣ
		/// </summary>
		/// <param name="ApplyBodyKey">����һ����Id</param>
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

				//���ݱ�ͷID����ʹ�õĿ�Ŀ��Ϣ
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
		/// �󶨱�����Ϣ
		/// </summary>
		/// <param name="ApplyHeadPk"></param>
		private void BindApplyBodyInfo(int ApplyHeadPk,string Ids,string FId)
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



		#region  ��һ����Ŀ  

		//		private void BindFirstClassSubject()
		//		{
		//			//ϵͳ��ǰ�� �� ��ǰ��¼��Ա���� 
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

		#region �ؼ����� 
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
			this.btnInBudget.Click += new System.EventHandler(this.btnInBudget_Click);
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			this.dgApply.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.dgApply_ItemCommand);
			this.dgApply.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.dgApply_ItemDataBound);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnInBudget_Click(object sender, System.EventArgs e)
		{
			
			//�۸񳬹�ԭ���ݼ۸� ��ֹ   (�����rmb�Ƚ�)
			//��������ԭ�������� ��ֹ
			//�����Ѽ۸�þ�����
			//�����Ƿ��Ѿ��þ��ֶΡ������� 

			this.lbMsg.Text = "";

            int FinallyCheckKey = int.Parse(this.hideApplyCheckHead.Value);

			//����Ƿ������������Ƿ��к�ͬ�ŵȣ� 

			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

			if(FinallyCheck != null && FinallyCheck.BargainNo.Length <= 0 ) 
			{
				this.lbMsg.Text = "��ͬ�Ų���Ϊ��";
				return ;
			}

			//����ύ
			int i = Bussiness.AssetFinallyCheckPrice.CheckFinallyApplyAndBody(FinallyCheckKey);

			if(i==1)
			{
				//�۸� �����ϸ� ���ύ���� 

				int Flag = Bussiness.AssetCheckFlowBLL.StartFinallyPriceCheckFlow(FinallyCheckKey) ; 

				if(Flag == 1 )
				{
					this.lbMsg.Text = "�����Ѿ��ύ��";

					//�ύ��ռ���ύ���� �� ��������� 

					//�۸�þ���ͷ
					//Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);

					//�����Ѿ��۸�þ���������
					Bussiness.AssetCheckFlowBLL.AddFinallyCheckNumber(FinallyCheck.Id);			
				}
				else
				{
					switch(Flag)
					{
							//����ֵ�� 1���� 2�Ѿ��ύ 3δ�ҵ����� ��4δ�ҵ����ݡ�5�Ѿ��ύ��
						case 1:
							this.lbMsg.Text = "�����Ѿ��ύ��";
							break;
						case 2:
							this.lbMsg.Text ="�����Ѿ��ύ���벻Ҫ�ظ�����";
							break;
						case 3:
							this.lbMsg.Text ="δ�ҵ����̣�";
							break;
						case 4:
							this.lbMsg.Text ="δ�ҵ����ݣ�";
							break;
					}
				}
			}
			else
			{
				switch (i)
				{
					case 2:
						this.lbMsg.Text = "�۸񳬳�";
						break;
					case 3:
						this.lbMsg.Text = "��������";
						break;
					case 4:
						 this.lbMsg.Text ="ϵͳ����";
						break;
				}
			}


			
		}



		//�������뵥��ͷ����״̬Ϊ�ύ
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
				//�����ͷ��Ϣ
				if(this.tbBargainNo.Text.Trim() =="")
				{
					this.lbMsg.Text = "��ͬ�Ų���Ϊ��";
					return ;
				}
				if(this.txtRequestDate.Text.Trim() =="")
				{
					this.lbMsg.Text = "�������ڲ���Ϊ��";
					return ;
				}

				int CheckHeadKey =  int.Parse(this.hideApplyCheckHead.Value);

				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(CheckHeadKey);

				if(FinallyCheck == null )
				{
					this.lbMsg.Text = "ϵͳ�����Ҳ�����Ӧ�þ���";
					Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2","ϵͳ�����Ҳ�����Ӧ�þ���");
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


				//���°󶨱�

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
			#region Ԥ�����
			decimal BudgetMoney = 0;
			decimal ReadyPay    = 0;
 			//���ݱ�ͷ
			Entiy.ApplySheetHead ApplyHead=Entiy.ApplySheetHead.Find(ApplyHeadKey);
			//����Ԥ��
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyHead !=null && ApplyBudget !=null )
			{
				//�������
				this.lblSheetMoney.Text= ApplyBudget.SheetRmbMoney.ToString();
				//�Ѿ�ʹ��
				this.lblSumCheck.Text = ApplyBudget.SumCheckMoney.ToString();
				//Ԥ������
				this.lblOutMoney.Text = ApplyBudget.AllowOutMoney.ToString();
				//����������ĿԤ��
				Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
				if(Dept != null )
				{
					//��ȡ��ĿԤ����Ϣ
					DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,ApplyBudget.ItemName);
					if(ds!=null && ds.Tables.Count >0 && ds.Tables[0].Rows.Count > 0 )
					{
						//Ԥ��
						this.lblBudget.Text= ds.Tables[0].Rows[0]["BudgetMoney"].ToString();
						//��̯
						this.lblready.Text = ds.Tables[0].Rows[0]["ReadyPay"].ToString() ;

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

		private void BindAssetBody(int applyHeadPk)
		{
			#region �󶨱�����Ϣ
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
			// 1 ȫ������
			// 2 Ԥ���ڿ���
			// 3 Ԥ�������
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


		#region ���������Ƿ�Ϊ����

		/// <summary>
		/// ���������Ƿ�Ϊ����
		/// </summary>
		/// <param name="Mail_One">�����ַ���</param>
		/// <returns>bool</returns>
		private  bool IsNumeric(string num)
		{
			//bool Validate_result = true;

			//Validate_result = Regex.IsMatch(num.Trim(), @"^(-?[0-9]*[.]*[0-9]{0,3})$");

			string a = "^(-?[0-9]*[.]*[0-9]{0,3})$" ;  //������ 

			string b = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"  ;  //��������

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

		#region ��ѯ���ֵĻ�׼����(1������)
		private decimal SelectRateByCurrCode(string CurrCode)
		{
			//��ѯ���ֵĻ�׼���ʡ� ��׼����Ϊ����1������

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
//			if(e.CommandName.Equals("delete")) //���������ť
//			{
//				
//				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(int.Parse(this.hideApplyHead.Value));
//				if(ApplyHead == null )
//				{
//					this.lbMsg.Text = "ϵͳ�����Ҳ������ݣ�";
//					return ;
//				}
//				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
//
//				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
//				{
//					this.lbMsg.Text = "�˵������½�״̬������ɾ����";
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
//				//���¼��㱾����� && ʣ����
//				BindApplyMoney(int.Parse(this.hideApplyHead.Value));
//				//�󶨵�������ʾ
//				BindAssetBody(int.Parse(this.hideApplyHead.Value));
//			}
//			//���º����°󶨰�ť����״̬
//			SetButtonsEnable(int.Parse(this.hideApplyHead.Value));
			#endregion 
		}


		private void dgApply_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			//�󶨸�����ť��ʾ��Ϣ
			if ((e.Item.ItemType!=ListItemType.Footer)&&(e.Item.ItemType!=ListItemType.Header)&&(e.Item.ItemType!=ListItemType.Pager)) 
			{ 
				//��ͨ�༭��
				e.Item.Cells[14].Attributes.Add("EditType","TextBox");
				e.Item.Cells[15].Attributes.Add("EditType","TextBox");
				e.Item.Cells[16].Attributes.Add("EditType","TextBox");

				//�����༭��
				e.Item.Cells[13].Attributes.Add("EditType","DropDownList");
				//����ֵ�趨������ʱд�̶���
				e.Item.Cells[13].Attributes.Add("DataItems","{text:'�����',value:'RMB'},{text:'��Ԫ',value:'USD'},{text:'��Ԫ',value:'JPY'},{text:'�۱�',value:'HKD'}");
			}

			e.Item.Cells[0].CssClass = "CellO";
		}

			
	}
}
