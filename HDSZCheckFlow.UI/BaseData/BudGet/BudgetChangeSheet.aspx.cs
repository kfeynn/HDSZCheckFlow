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
	/// BudgetChangeSheet 的摘要说明。
	/// </summary>
	public class BudgetChangeSheet : System.Web.UI.Page
	{
		protected XPGrid.XpGrid XPGrid1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
				this.XPGrid1.CommandText="select * from budget_change_Sheet order by  Iyear desc , Imonth desc";
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
			this.XPGrid1.BeforeUpdateData += new XPGrid.XpBaseClass.BeforeUpdateDataEventHandler(this.XPGrid1_BeforeUpdateData);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void XPGrid1_BeforeUpdateData(ref bool continueUpdate, XPGrid.CUpdateType updateType, ref string ResultSql, System.Web.UI.WebControls.DataGridItem e)
		{
			#region  废弃预算表中的,调整,追加字段.. 不再需要维护这两个字段
//			if(updateType==XPGrid.CUpdateType.Delete)
//			{
//				//删除记录时,更新预算表				
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
//				#region  取得数据并更新
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
//					if("0".Equals(SheetType))//调整
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
//					else if("1".Equals(SheetType))//追加
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
				//添加记录时,更新预算表				
				int iYear=0 ;
				int iMonth=0;
				string DeptCode="";
				string SheetType="0";
				string OutSubject="";
				string InSubject="";
				decimal Money=0;

				#region 获取数据
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

				#region 更新操作
				//	if("0".Equals(SheetType)) //调整
				//	{
				//转出项目  
				//Entiy.Budgetaccount budGet=Entiy.Budgetaccount.FindByYearAndMonth(iYear,iMonth,DeptCode,OutSubject);

				//转出项目 季度金额信息
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(iYear ,iMonth ,DeptCode,OutSubject );


				if(ds != null)
				{
					//转换金额 季度的
					//decimal changeMoney = Bussiness.BudgetAccountBLL.GetAccountChangeMoney(iYear,iMonth,DeptCode,OutSubject);
					decimal changeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChangeForBudDept(iYear,iMonth,DeptCode,OutSubject);



					//decimal BLeft= budGet.BudgetMoney  + changeMoney + budGet.TotalAllowOutMoney  - budGet.CheckMoney ;
					decimal BLeft = decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + changeMoney + decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString())  - decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString())  -decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());


					if(BLeft < Money)
					{
						XPGrid1.ShowMessage("对不起，转出项目剩余金额不足！",System.Drawing.Color.Red);
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
					XPGrid1.ShowMessage("对不起，转出项目剩余金额不足！",System.Drawing.Color.Red);
					continueUpdate=false;
					return ;
				}
				//对于转入金额的，科目，若本身无预算．则实例化一个空值
				Bussiness.BudgetAccountBLL.SaveBudgetAccountBydeptCode(iYear,iMonth,DeptCode,InSubject);
				
				#endregion 

				//维护录入员字段

				//此处还需要判断LeaderNo是否有效，数据库建立关联由系统自动维护

				string importerCode = Bussiness.UserInfoBLL.GetUserName(int.Parse(User.Identity.Name));

				ChgSql MyChgSql=new ChgSql();
				if (!MyChgSql.ChgResultSql(ref ResultSql,"IMPORTERCODE",importerCode))
				{
					XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
					continueUpdate=false;
				}



//				strPrdtLotNo="'"+strYear.Substring(2,2) + strMonth + strDay + strShopName + strShiftName + strLeaderNo +"'";
//				if (!MyChgSql.ChgResultSql(ref ResultSql,"PRDTLOTNO",strPrdtLotNo))
//				{
//					XPGrid1.ShowMessage("对不起，系统错误！",System.Drawing.Color.Red);
//					continueUpdate=false;
//				}	


				#region  
				//转入项目
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
				//else if("1".Equals(SheetType))//追加
				//{
				//					//追加项目
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
