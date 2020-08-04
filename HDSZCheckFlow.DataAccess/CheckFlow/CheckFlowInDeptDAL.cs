using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.CheckFlow
{
	/// <summary>
	/// CheckFlowInDeptDAL ��ժҪ˵����
	/// </summary>
	public class CheckFlowInDeptDAL
	{
		public CheckFlowInDeptDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ȡ���п��������Ϣ
		/// </summary>
		/// <returns></returns>
		public static DataTable  GetDeptCodeInfo()
		{
			try
			{
				DBAccess dbAccess=new SQLAccess();
				string cmdStr="SELECT DeptCode,(select DeptName from Base_Dept o  where  o.DeptCode = CheckFlowInDept.DeptCode) as DeptName  FROM CheckFlowInDept GROUP BY DeptCode";
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.CheckFlow.CheckFlowInDeptDAL->",ex.Message );
				return null;
			}
		}


		/// <summary>
		/// �жϲ�����������Ч��
		/// </summary>
		/// <param name="deptCode"></param>
		/// <returns></returns>
		public static int CheckFlowDeptCodeValid(string deptCode)
		{
			int result=0;

			DBAccess dbAccess=new SQLAccess();
			DBParameterCollection Params=new DBParameterCollection();
			Params.Add(Parameter.GetDBParameter("@deptCode",deptCode));
			Params.Add(Parameter.GetDBParameter("@result",result,ParameterDirection.Output));

			dbAccess.ExecuteDataset("p_Flow_CheckFlowInDeptValid",CommandType.StoredProcedure,Params);

			result = Convert.ToInt32(Params[Params.Count-1].Value);
			return result;
		}

		public static DataTable GetFlowInDeptByQuery(string query)
		{

			string cmdStr=@"SELECT CheckRole.CheckRoleName, Base_Person.Name
							FROM CheckFlowInDept INNER JOIN
								CheckRole ON 
								CheckFlowInDept.CheckRoleCode = CheckRole.CheckRoleCode INNER JOIN
								Base_Person ON 
								CheckFlowInDept.CheckPersonCode = Base_Person.personCode" + query;
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr).Tables[0];
		}

//		/// <summary>       ��ʵ���෽��ȡ��
//		/// ��ȡ��������һ������ɫ��Ϣ
//		/// </summary>
//		/// <param name="checkStep"></param>
//		/// <returns></returns>
//		public static string GetFlowDeptStep(string deptCode,int checkStep)
//		{
//			string cmdStr="select top 1  CheckRoleCode from CheckFlowInDept o where o.DeptCode='" + deptCode + "' o.CheckSetp> " + checkStep + "  ORDER BY CheckSetp asc";
//			DBAccess dbAccess=new SQLAccess();
//			return dbAccess.ExecuteScalar(cmdStr).ToString();
//		}
	
	}
}
