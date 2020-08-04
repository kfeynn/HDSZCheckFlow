using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// BaseAccountSubject ��ժҪ˵����
	/// </summary>
	public class BaseAccountSubject
	{
		public BaseAccountSubject()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ȡ���п�Ŀ��Ϣ(һ����Ŀ)
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
		/// ����һ����Ŀ,��ѯ������Ŀ
		/// </summary>
		/// <param name="firstSubject"></param>
		/// <returns></returns>
		public static DataTable GetAccountSubjectByFirstSubject(string firstSubject,string budgetDept,string applyTypeCode)
		{
			try
			{
				//����һ����Ŀ,�����ӿ�Ŀ.. (ĩ����Ŀ,ɾ��״̬Ϊ0)
				string cmdStr ="";
				
//				string cmdStr="SELECT Base_AccountSubject.subjectCode,Base_AccountSubject.subjectName  FROM Base_AccountSubject WHERE (IsEnd = 'y') AND (DR = 0) AND (LEFT(subjectCode, 4) = '" + firstSubject + "')";

//				Entiy.BaseCommonRelation[] commonRelation = Entiy.BaseCommonRelation.FindBySunAndFatherCode(firstSubject,budgetDept);
//
//				//�ֽ�ͳһ�� �������Ŀ����п��ƣ� 2008-09-23
//				if(commonRelation!=null && commonRelation.Length > 0)
//				{
//					//�Կ�Ŀ�����˿���subjectName
//					cmdStr=@"SELECT Base_AccountSubject.subjectCode, Base_AccountSubject.dispname  FROM Base_AccountSubject INNER JOIN Base_CommonRelation ON Base_AccountSubject.subjectCode = Base_CommonRelation.sunCode WHERE (Base_AccountSubject.IsEnd = 'y') AND (Base_AccountSubject.DR = 0) AND  " +
//										@"(LEFT(Base_AccountSubject.subjectCode, 4) = '" + firstSubject + "') AND " + 
//										@"(Base_CommonRelation.type = 'secendstep') AND (Base_CommonRelation.fatherCode = '" + budgetDept + "')";				
//				}
//				else
//				{
					//δ�Դ���Ŀ�Ŀ�Ŀ���п���
					//cmdStr="SELECT Base_AccountSubject.subjectCode,Base_AccountSubject.subjectName  FROM Base_AccountSubject WHERE (IsEnd = 'y') AND (DR = 0) AND (LEFT(subjectCode, 4) = '" + firstSubject + "')";
					
					//2008-09-20 ���ӶԿ�Ŀ�Ŀ��� ,���Ʊ� Base_SubjectCodeInApplyType
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
		/// ��ѯ���Ϲ��
		/// </summary>
		/// <returns></returns>
		public static DataSet BaseSubjectTypeQuery(string query )
		{
			try
			{
//				string cmdStr = @"SELECT  Base_inventory.invCode as '����', Base_inventory.invName as '����', Base_inventory.INVTYPE as '���',
// Base_InvClass.InvClassName as '���' FROM Base_inventory INNER JOIN Base_InvClass ON Base_inventory.InvClass_pk = Base_InvClass.InvClass_pk "; 
				//isnull(Base_inventory.INVTYPE,Base_inventory.Invspec) as '���', Base_InvClass.InvClassName as '���' , 
				string cmdStr = @"SELECT  Base_inventory.invCode as '����', Base_inventory.invName as '����', 
Base_inventory.Invspec as '���',Base_inventory.INVTYPE as '�ͺ�', Base_InvClass.invClassCode  '������', Base_InvClass.InvClassName as '���' ,
Base_inventory.CurrTypeCode as '����', Base_inventory.measname as '��λ',
Base_inventory.OriginalcurPrice as 'NCԭ�ҵ���',      
CONVERT(varchar(100),Base_inventory.OrderDate, 23)  as 'NC�۸�����' ,
Base_inventory.RealOriginalcurPrice as 'ʵ��ԭ�ҵ���(����������)', 
CONVERT(varchar(100),Base_inventory.RealPriceDate, 23)  as 'ʵ�ʼ۸�����'            
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
		/// �������
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
				//��ѯ��������Ԥ���Ŀ.
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
