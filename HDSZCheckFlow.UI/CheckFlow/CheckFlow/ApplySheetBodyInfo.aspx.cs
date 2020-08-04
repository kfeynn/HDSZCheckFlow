using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;//ApplySheetBodyInfo
//			if(Request.QueryString["applyHeadPK"] !=null)
//			{
//				string applyHeadPk=Request.QueryString["applyHeadPK"].ToString();
//				BindApplyBodyInfo(int.Parse(applyHeadPk));
//			}
namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
	/// <summary>
	/// ApplySheetBodyInfo ��ժҪ˵����
	/// </summary>
	public class ApplySheetBodyInfo : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.Label lblApplyType;
		protected System.Web.UI.WebControls.Label lblDpteAndPerson;
		protected System.Web.UI.WebControls.Label lblApplyDate;
		protected System.Web.UI.WebControls.Label lblBudget;
		protected System.Web.UI.WebControls.Label lblChange;
		protected System.Web.UI.WebControls.Label lblSumCheck;
		protected System.Web.UI.WebControls.Label lblSheetMoney;
		protected System.Web.UI.WebControls.Label lblLeft;
		protected System.Web.UI.WebControls.Label lblMoney;
		protected System.Web.UI.WebControls.Table tbAnnex;
		protected static string ApplySheetHeadPk="0";
		protected System.Web.UI.WebControls.Label lblPushMoney;
		protected System.Web.UI.WebControls.Label lblSubject;
		protected System.Web.UI.WebControls.Label lblDeliveryDate;
		protected System.Web.UI.WebControls.Label lblSubmitDate;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody;
		protected System.Web.UI.WebControls.DataGrid dgApplyBody_Pay;
		protected string NumOfAnnex="0";
	
		private void Page_Load(object sender, System.EventArgs e)
		{

			string applyHeadPk=Request.QueryString["applyHeadPk"].ToString();  //��Ҫ�����ĵ���ID
			ApplySheetHeadPk=applyHeadPk;
			if(!Page.IsPostBack)
			{
				BindBaseInfoOfApply(int.Parse(applyHeadPk));
				BindApplyBodyInfo(int.Parse(applyHeadPk));
				BindBudgetInfo(int.Parse(applyHeadPk));
				BindAnnexInfo(int.Parse(applyHeadPk)); //������Ϣ
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
						this.lblMoney.Text=applyBudget.SheetMoney.ToString("#,###.##");
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

					this.lblDeliveryDate.Text=applyHead.DeliveryDate.ToString();
					this.lblSubmitDate.Text = applyHead.SubmitDate.ToString("yyyy-MM-dd HH:mm:ss");

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

			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			if(applyHead!=null)
			{
				Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
				if(applyType !=null)
				{
					applyHead=null;
					if("ApplySheetBody_Purchase".Equals(applyType.ApplySheetBodyTableName) )
					{
						this.dgApplyBody_Pay.Visible=false ;
						//������ϸ��Ϣ
						DataSet ds= Bussiness.ApplyAuditingBLL.GetApplySheetBodyInfo(applyHeadPk);
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
				}
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
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);

					this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");
					this.lblPushMoney.Text=budgetAccount.PlanMoney.ToString("#,###.##");
					//					this.lblChange.Text=budgetAccount.BudgetChangeMoney.ToString("#,###.##");
					this.lblChange.Text=ChangeMoney.ToString("#,###.##");
					//					this.lblAdd.Text="//" + budgetAccount.BudgetAddMoney.ToString("#,###.##");
					this.lblSheetMoney.Text=applyBudget.SheetMoney.ToString("#,###.##");
					this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");
					//					decimal tempLeft=budgetAccount.BudgetMoney + budgetAccount.BudgetChangeMoney + budgetAccount.BudgetAddMoney -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;
					//					decimal tempLeft=budgetAccount.PlanMoney  + budgetAccount.BudgetChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;
					//decimal tempLeft=budgetAccount.PlanMoney  + ChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;
					
					//���ó�֧��׼��Ԥ��������㡣
					int budgetStandard = Bussiness.BudgetAccountBLL.budgetStandard(applyHead.ApplyDate );
					decimal tempLeft = 0 ; 
					if (budgetStandard == 1 )  //Ԥ��
					{
						tempLeft=budgetAccount.BudgetMoney  + ChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;
					}
					else if(budgetStandard == 2 ) // ����
					{
						tempLeft=budgetAccount.PlanMoney  + ChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;
					}

					if(tempLeft < 0)
					{
						this.lblLeft.ForeColor=Color.Red;
					}
					this.lblLeft.Text=tempLeft.ToString("#,###.##");
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
	

		private void btnGoBack_Click(object sender, System.EventArgs e)
		{
			//�ص��ҵ�����ҳ��
			Response.Redirect("MyAuditing.aspx");
		}




	}
}
