using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// BaseAccountSubjectBLL ��ժҪ˵����
	/// </summary>
	public class BaseAccountSubjectBLL
	{
		public BaseAccountSubjectBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ȡ���п�Ŀ������Ϣ(һ����Ŀ)
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAccountSubjectInfo(string BudgetDept)
		{
			return DataAccess.BaseInfo.BaseAccountSubject.GetAccountSubjectInfo(BudgetDept);
		}

		/// <summary>
		/// ����һ����Ŀ,��ѯ������Ŀ
		/// </summary>
		/// <param name="firstSubject"></param>
		/// <returns></returns>
		public static DataTable GetAccountSubjectByFirstSubject(string firstSubject,string budgetDept,string applyTypeCode)
		{
			return DataAccess.BaseInfo.BaseAccountSubject.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
		}

		/// <summary>
		/// ��ѯ���Ϲ��
		/// </summary>
		/// <returns></returns>
		public static DataSet BaseSubjectTypeQuery(string query)
		{
			return DataAccess.BaseInfo.BaseAccountSubject.BaseSubjectTypeQuery(query) ;

		}
		public static DataSet BaseSubjectType()
		{
			return DataAccess.BaseInfo.BaseAccountSubject.BaseSubjectType();

		}

		public static DataSet QuerySubjectByDeptAndDate(string Dept,int iYear,int iMonth)
		{

			return DataAccess.BaseInfo.BaseAccountSubject.QuerySubjectByDeptAndDate(Dept,iYear,iMonth);

		}

		public static DataSet SelectAllSubject()
		{
			return DataAccess.BaseInfo.BaseAccountSubject.SelectAllSubject();
		}

	}
}
