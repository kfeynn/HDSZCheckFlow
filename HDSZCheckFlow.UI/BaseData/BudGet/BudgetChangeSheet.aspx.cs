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

namespace HDSZCheckFlow.UI.BaseData.BudGet
{
	/// <summary>
	/// BudgetChangeSheet ��ժҪ˵����
	/// </summary>
	public class BudgetChangeSheet : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from budget_change_Sheet order by  Iyear desc , Imonth desc";
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
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			#region  ����Ԥ����е�,����,׷���ֶ�.. ������Ҫά���������ֶ�
//			if(updateType==XPGrid.CUpdateType.Delete)
//			{
//				//ɾ����¼ʱ,����Ԥ���				
//				int iYear=0 ;
//				int iMonth=0;
//				string DeptCode="";
//				string SheetType="";
//				string OutSubject="";
//				string InSubject="";
//				decimal Money=0;
//
//				string []selectedKey=XPGrid1.GetSelectedKey();
//				
//				#region  ȡ�����ݲ�����
//
//				foreach(string key in selectedKey)
//				{
//					int keyPk=int.Parse(key);
//					Entiy.BudgetchangeSheet budGetChange=Entiy.BudgetchangeSheet.Find(keyPk);
//					if(budGetChange != null)
//					{
//						iYear=budGetChange.Iyear;
//						iMonth=budGetChange.Imonth;
//						DeptCode=budGetChange.DeptCode;
//						SheetType=budGetChange.SheetTypeCode;
//						OutSubject=budGetChange.OutSubject;
//						InSubject=budGetChange.InSubject;
//						Money=budGetChange.Money ;
//
//						budGetChange=null;
//					}	
//					if("0".Equals(SheetType))//����
//					{
//						Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,OutSubject);
//						if(budGet != null)
//						{
//							budGet.BudgetChangeMoney=budGet.BudgetChangeMoney + Money;
//							budGet.Update();
//						}
//						Entiy.Budgetaccount budGetInSubject=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,InSubject);
//						if(budGetInSubject != null)
//						{
//							budGetInSubject.BudgetChangeMoney=budGetInSubject.BudgetChangeMoney - Money;
//							budGetInSubject.Update();
//						}
//					}
//					else if("1".Equals(SheetType))//׷��
//					{
//						Entiy.Budgetaccount budGetInSubject=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,InSubject);
//						if(budGetInSubject != null)
//						{
//							budGetInSubject.BudgetAddMoney =budGetInSubject.BudgetAddMoney - Money;
//							budGetInSubject.Update();
//						}
//					}
//				}
//				#endregion 
//			}
	#endregion  

			if(updateType==XPGrid.CUpdateType.Insert)
			{
				//��Ӽ�¼ʱ,����Ԥ���				
				int iYear=0 ;
				int iMonth=0;
				string DeptCode="";
				string SheetType="0";
				string OutSubject="";
				string InSubject="";
				decimal Money=0;

				#region ��ȡ����
				for (int i = 0; i <= XPGrid1.FieldList.Count - 1; i++) 
				{
					XPGrid.DBStruct.CDBField F =(XPGrid.DBStruct.CDBField)XPGrid1.FieldList[i]; 
					object ob = XPGrid1.GetInputControlValue(F); 
					if (F.ColName == "IYEAR") 
					{ 
						iYear = System.Convert.ToInt32(ob); 
					} 
					if (F.ColName == "IMONTH") 
					{ 
						iMonth = System.Convert.ToInt32(ob); 
					} 
					if (F.ColName == "DEPTCODE") 
					{ 
						DeptCode = System.Convert.ToString(ob); 
					} 
					if (F.ColName == "SHEETTYPECODE") 
					{ 
						SheetType = System.Convert.ToString(ob); 
					} 
					if (F.ColName == "OUTSUBJECT") 
					{ 
						OutSubject = System.Convert.ToString(ob); 
					} 
					if (F.ColName == "INSUBJECT") 
					{ 
						InSubject = System.Convert.ToString(ob); 
					} 
					if (F.ColName == "MONEY") 
					{ 
						Money = System.Convert.ToDecimal(ob); 
					} 
				}
				#endregion 

				#region ���²���
				//	if("0".Equals(SheetType)) //����
				//	{
				//ת����Ŀ  
				//Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,OutSubject);

				//ת����Ŀ ���Ƚ����Ϣ
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,DeptCode,OutSubject );


				if(ds != null)
				{
					//ת����� ���ȵ�
					//decimal changeMoney = Bussiness.BudgetAccountBLL.GetAccountChangeMoney(iYear,iMonth,DeptCode,OutSubject);
					decimal changeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChangeForBudDept(iYear,iMonth,DeptCode,OutSubject);



					//decimal BLeft= budGet.BudgetMoney  + changeMoney + budGet.TotalAllowOutMoney  - budGet.CheckMoney ;
					decimal BLeft = decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + changeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString())  - decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString())  -decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());


					if(BLeft < Money)
					{
						XPGrid1.ShowMessage("�Բ���ת����Ŀʣ����㣡",System.Drawing.Color.Red);
						continueUpdate=false;
						return ;
					}
					//						else
					//						{
					//							budGet.BudgetChangeMoney=budGet.BudgetChangeMoney - Money;
					//							budGet.Update();
					//						}
				}
				else
				{
					XPGrid1.ShowMessage("�Բ���ת����Ŀʣ����㣡",System.Drawing.Color.Red);
					continueUpdate=false;
					return ;
				}
				//����ת����ģ���Ŀ����������Ԥ�㣮��ʵ����һ����ֵ
				Bussiness.BudgetAccountBLL.SaveBudgetAccountBydeptCode(iYear,iMonth,DeptCode,InSubject);
				
				#endregion 

				//ά��¼��Ա�ֶ�

				//�˴�����Ҫ�ж�LeaderNo�Ƿ���Ч�����ݿ⽨��������ϵͳ�Զ�ά��

				string importerCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql,"IMPORTERCODE",importerCode))
				{
					XPGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
					continueUpdate=false;
				}



//				strPrdtLotNo="'"+strYear.Substring(2,2) + strMonth + strDay + strShopName + strShiftName + strLeaderNo +"'";
//				if (!MyChgSql.ChgResultSql(ref ResultSql,"PRDTLOTNO",strPrdtLotNo))
//				{
//					XPGrid1.ShowMessage("�Բ���ϵͳ����",System.Drawing.Color.Red);
//					continueUpdate=false;
//				}	


				#region  
				//ת����Ŀ
				//					Entiy.Budgetaccount budGetInSubject=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,InSubject);
				//					if(budGetInSubject == null)
				//					{
				//						budGetInSubject=new HDSZCheckFlow.Entiy.Budgetaccount();
				//					}
				//					budGetInSubject.Iyear=iYear;
				//					budGetInSubject.Imonth=iMonth;
				//					budGetInSubject.DeptCode=DeptCode;
				//					budGetInSubject.SubjectCode = InSubject ;
				//
				//					budGetInSubject.BudgetChangeMoney=budGetInSubject.BudgetChangeMoney + Money;
				//					budGetInSubject.Save();
					
				//}
				//else if("1".Equals(SheetType))//׷��
				//{
				//					//׷����Ŀ
				//					Entiy.Budgetaccount budGetInSubject=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,InSubject);
				//					if(budGetInSubject == null)
				//					{
				//						budGetInSubject=new HDSZCheckFlow.Entiy.Budgetaccount();
				//					}
				//					budGetInSubject.BudgetAddMoney =budGetInSubject.BudgetAddMoney + Money;
				//					budGetInSubject.Save();
				//					
				//}
				#endregion  
			

			}
		
		}
	}
}
