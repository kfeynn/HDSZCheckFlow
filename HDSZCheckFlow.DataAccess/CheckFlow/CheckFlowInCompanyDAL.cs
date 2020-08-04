using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.CheckFlow
{
	/// <summary>
	/// CheckFlowInCompanyDAL 的摘要说明。
	/// </summary>
	public class CheckFlowInCompanyDAL
	{
		public CheckFlowInCompanyDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 检查流程名是否有效
		/// </summary>
		/// <param name="flowHeadPk">流程标题主键</param>
		/// <returns></returns>
		public static int CheckOneFlowHeadValid(int flowHeadPk)
		{
			int result=0;

			DBAccess dbAccess=new SQLAccess();
			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@headPk",flowHeadPk));
			Params.Add(Parameter.GetDBParameter("@result",result,ParameterDirection.Output));

			dbAccess.ExecuteDataset("p_Flow_CheckFlowHeadValid",CommandType.StoredProcedure,Params);

			result = Convert.ToInt32(Params[Params.Count-1].Value);
			return result;
		}

		/// <summary>
		///  查询审批级对应角色 ,人员
		/// </summary>
		/// <returns></returns>
		public static DataTable GetFlowCheckInfoByQuery(string query)
		{
			try
			{
				string cmdStr=@"SELECT CheckRole.CheckRoleName, Base_Person.Name
							FROM Base_Person INNER JOIN
								CheckPersonInRole ON 
								Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
								CheckRole ON 
								CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN
								CheckFlowInCompany_Body ON 
								CheckPersonInRole.CheckRoleCode = CheckFlowInCompany_Body.CheckRoleCode" + query ;
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("CheckFlowInCompanyDAL.GetFlowCheckInfoByQuery",ex.Message );
				return null;
			}

		}

		public static DataTable GetFlowCheckInfoByCompanyFlowPkAndDeptCode(int CompanyFlowPK,string DeptCode)
		{
			try
			{
//				string cmdStr = @"SELECT CheckRole.CheckRoleName, Base_Person.Name, 
// CheckFlowInCompany_Body.CheckStep
//FROM Base_Person INNER JOIN
//      CheckPersonInRole ON 
//      Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
//      CheckRole ON 
//      CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode and CheckRole.isrefer= 0  INNER JOIN
//      CheckFlowInCompany_Body ON 
//      CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode LEFT OUTER
//       JOIN
//      Base_RolePersonAnther ON 
//      CheckRole.CheckRoleCode = Base_RolePersonAnther.role
//WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = " + CompanyFlowPK +
//@" ) and (Base_RolePersonAnther.content is  null or 
//Base_RolePersonAnther.content ='" + DeptCode + "' ) " +
//" union all " +
//@"SELECT CheckRole.CheckRoleName, Base_Person.Name,
//      CheckFlowInCompany_Body.CheckStep   
//FROM CheckFlowInCompany_Body INNER JOIN
//      CheckRole ON 
//      CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode and CheckRole.isrefer= 1  INNER JOIN
//      Base_RolePersonAnther ON 
//      CheckRole.CheckRoleCode = Base_RolePersonAnther.role INNER JOIN
//      Base_Person ON 
//      Base_RolePersonAnther.personCode = Base_Person.personCode
//WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = " + CompanyFlowPK + @") AND 
//      (Base_RolePersonAnther.content = '" + DeptCode + "')" +
//"ORDER BY CheckFlowInCompany_Body.CheckStep";
				string cmdStr =@"SELECT CheckRole.CheckRoleName, Base_Person.Name, 
      CheckFlowInCompany_Body.CheckStep
FROM Base_Person INNER JOIN
      CheckPersonInRole ON 
      Base_Person.personCode = CheckPersonInRole.PersonCode INNER JOIN
      CheckRole ON CheckPersonInRole.CheckRoleCode = CheckRole.CheckRoleCode AND 
      CheckRole.IsRefer = 0 INNER JOIN
      CheckFlowInCompany_Body ON 
      CheckFlowInCompany_Body.CheckRoleCode = CheckRole.CheckRoleCode
WHERE (CheckFlowInCompany_Body.CheckFlowInCompany_Head_pk = " + CompanyFlowPK + ") " + 
"ORDER BY CheckFlowInCompany_Body.CheckStep";

				DBAccess dbAccess = new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("CheckFlowInCompanyDAL.GetFlowCheckInfoByCompanyFlowPkAndDeptCode",ex.Message );
				return null;
			}
		}
	}
}
