using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// BaseAccountSubject 的摘要说明。
	/// </summary>
	public class BaseAccountSubject
	{
		public BaseAccountSubject()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获取所有科目信息(一级科目)
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAccountSubjectInfo(string BudgetDept)
		{
			try
			{
//				string cmdStr="select subjectCode,subjectName from  Base_AccountSubject order by subjectName asc ";
				string cmdStr=@"SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.Dispname
								FROM Base_AccountSubject INNER JOIN
									Base_CommonRelation ON 
									Base_AccountSubject.subjectCode = Base_CommonRelation.sunCode
								WHERE (Base_CommonRelation.type = 'firststep') AND 
									(Base_CommonRelation.fatherCode = '" + BudgetDept + "') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.BaseInfo.BaseAccountSubject",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 根据一级科目,查询二级科目
		/// </summary>
		/// <param name="firstSubject"></param>
		/// <returns></returns>
		public static DataTable GetAccountSubjectByFirstSubject(string firstSubject,string budgetDept,string applyTypeCode)
		{
			try
			{
				//根据一级科目,查找子科目.. (末级科目,删除状态为0)
				string cmdStr ="";
				
//				string cmdStr="SELECT Base_AccountSubject.subjectCode,Base_AccountSubject.subjectName  FROM Base_AccountSubject WHERE (IsEnd = 'y') AND (DR = 0) AND (LEFT(subjectCode, 4) = '" + firstSubject + "')";

//				Entiy.BaseCommonRelation[] commonRelation = Entiy.BaseCommonRelation.FindBySunAndFatherCode(firstSubject,budgetDept);
//
//				//现今统一由 类型与科目表进行控制！ 2008-09-23
//				if(commonRelation!=null && commonRelation.Length > 0)
//				{
//					//对科目进行了控制subjectName
//					cmdStr=@"SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.dispname  FROM Base_AccountSubject INNER JOIN Base_CommonRelation ON Base_AccountSubject.subjectCode = Base_CommonRelation.sunCode WHERE (Base_AccountSubject.IsEnd = 'y') AND (Base_AccountSubject.DR = 0) AND  " +
//										@"(LEFT(Base_AccountSubject.subjectCode, 4) = '" + firstSubject + "') AND " + 
//										@"(Base_CommonRelation.type = 'secendstep') AND (Base_CommonRelation.fatherCode = '" + budgetDept + "')";				
//				}
//				else
//				{
					//未对此项目的科目进行控制
					//cmdStr="SELECT Base_AccountSubject.subjectCode,Base_AccountSubject.subjectName  FROM Base_AccountSubject WHERE (IsEnd = 'y') AND (DR = 0) AND (LEFT(subjectCode, 4) = '" + firstSubject + "')";
					
					//2008-09-20 增加对科目的控制 ,控制表 Base_SubjectCodeInApplyType
					cmdStr = @"SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.dispname" +
								" FROM Base_AccountSubject INNER JOIN	Base_SubjectCodeInApplyType ON " +
								"	Base_SubjectCodeInApplyType.firstSubjectCode = LEFT(Base_AccountSubject.subjectCode,4) AND Base_AccountSubject.IsEnd = 'y' AND Base_AccountSubject.DR = 0 AND " +
									" LEFT(Base_AccountSubject.subjectCode, 4) = '" + firstSubject + "'" +
						      @" AND Base_SubjectCodeInApplyType.subjectCode = Base_AccountSubject.subjectCode AND 
									Base_SubjectCodeInApplyType.ApplyTypeCode = '" + applyTypeCode + "'  order by Base_AccountSubject.subjectCode asc ";
//				}
			
				DBAccess dbAccess=new SQLAccess();
				DataSet ds = dbAccess.ExecuteDataset(cmdStr);
				if(ds!=null && ds.Tables.Count>0)
				{
					return ds.Tables[0];
				}
				else
				{
					return null;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DAL>GetAccountSubjectByFirstSubject",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 查询物料规格
		/// </summary>
		/// <returns></returns>
		public static DataSet BaseSubjectTypeQuery(string query )
		{
			try
			{
//				string cmdStr = @"SELECT  Base_inventory.invCode as '编码', Base_inventory.invName as '名称', Base_inventory.INVTYPE as '规格',
// Base_InvClass.InvClassName as '类别' FROM Base_inventory INNER JOIN Base_InvClass ON Base_inventory.InvClass_pk = Base_InvClass.InvClass_pk "; 
				//isnull(Base_inventory.INVTYPE,Base_inventory.Invspec) as '规格', Base_InvClass.InvClassName as '类别' , 
				string cmdStr = @"SELECT  Base_inventory.invCode as '编码', Base_inventory.invName as '名称', 
Base_inventory.Invspec as '规格',Base_inventory.INVTYPE as '型号', Base_InvClass.invClassCode  '类别编码', Base_InvClass.InvClassName as '类别' ,
Base_inventory.CurrTypeCode as '币种', Base_inventory.measname as '单位',
Base_inventory.OriginalcurPrice as 'NC原币单价',      
CONVERT(varchar(100),Base_inventory.OrderDate, 23)  as 'NC价格日期' ,
Base_inventory.RealOriginalcurPrice as '实际原币单价(经过审批的)', 
CONVERT(varchar(100),Base_inventory.RealPriceDate, 23)  as '实际价格日期'            
FROM Base_inventory INNER JOIN Base_InvClass ON Base_inventory.InvClass_pk =
Base_InvClass.InvClass_pk " ;
				cmdStr = cmdStr + query; 
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset (cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DAL>BaseAccountSubject.BaseSubjectTypeQuery",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 物料类别
		/// </summary>
		/// <returns></returns>
		public static DataSet BaseSubjectType()
		{
			try
			{
				string cmdStr = @"SELECT  
								Base_InvClass.invClassCode,Base_InvClass.InvClassName 
								FROM Base_inventory INNER JOIN Base_InvClass ON
								Base_inventory.InvClass_pk = Base_InvClass.InvClass_pk WHERE (LEFT(Base_InvClass.invClassCode, 1) = 'E') 
								AND (Base_inventory.INVTYPE IS NOT NULL) 
								group by Base_InvClass.invClassCode,Base_InvClass.InvClassName ";
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DAL>BaseAccountSubject.BaseSubjectType",ex.Message );
				return null;
			}
		}


		public static DataSet QuerySubjectByDeptAndDate(string Dept,int iYear,int iMonth)
		{
			try
			{
				string cmdStr = "SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.Dispname FROM Base_AccountSubject INNER JOIN budget_account ON Base_AccountSubject.subjectCode = budget_account.SubjectCode " +
"WHERE (budget_account.Iyear = " + iYear + ") AND (budget_account.Imonth = " + iMonth + ") AND " +
"(budget_account.deptCode  in ( select budget_DeptCode from Base_Dept where superior_Dept_pk = '" + Dept + "') ) ORDER BY Base_AccountSubject.subjectCode";

				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Dal>BaseAccountSubject.QuerySubjectByDeptAndDate",ex.Message );
				return null;
			}
		}


		public static DataSet SelectAllSubject()
		{
			try
			{
				//查询所有已做预算科目.
				string cmdStr = @"SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.Dispname FROM Base_AccountSubject
								INNER JOIN budget_account ON Base_AccountSubject.subjectCode = budget_account.SubjectCode
								group by Base_AccountSubject.subjectcode ,Base_AccountSubject.dispname  
								order by Base_AccountSubject.subjectcode ";
				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Dal>BaseAccountSubject.SelectAllSubject",ex.Message );
				return null;
			}
		}

	}
}
