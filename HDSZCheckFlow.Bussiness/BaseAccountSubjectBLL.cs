using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// BaseAccountSubjectBLL 的摘要说明。
	/// </summary>
	public class BaseAccountSubjectBLL
	{
		public BaseAccountSubjectBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获取所有科目类型信息(一级科目)
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAccountSubjectInfo(string BudgetDept)
		{
			return DataAccess.BaseInfo.BaseAccountSubject.GetAccountSubjectInfo(BudgetDept);
		}

		/// <summary>
		/// 根据一级科目,查询二级科目
		/// </summary>
		/// <param name="firstSubject"></param>
		/// <returns></returns>
		public static DataTable GetAccountSubjectByFirstSubject(string firstSubject,string budgetDept,string applyTypeCode)
		{
			return DataAccess.BaseInfo.BaseAccountSubject.GetAccountSubjectByFirstSubject(firstSubject,budgetDept,applyTypeCode);
		}

		/// <summary>
		/// 查询物料规格
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
