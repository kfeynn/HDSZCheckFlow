using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// DeptBLL 的摘要说明。
	/// </summary>
	public class DeptBLL
	{
		public DeptBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据用户ID查询其所在的部门
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static string GetMyDeptClass(int UserID)
		{
			DataTable dt = DataAccess.UserInfo.BaseDeptDAL.GetDeptForUserID(UserID);
			if(dt!=null && dt.Rows.Count >0)
			{
				return dt.Rows[0]["DeptCode"].ToString();
			}
			else
			{
				return "";
			}

		}


		//查预算部门
		public static string GetMyNcDeptCode(string ClassDeptCode)
		{
			string cmdStr= ""; 

			DataTable dt = DataAccess.UserInfo.BaseDeptDAL.GetMyNcDeptCode(ClassDeptCode);

			if(dt!=null && dt.Rows.Count >0)
			{
				for(int i=0 ;i< dt.Rows.Count ;i++)
				{
					if(cmdStr.Length > 0)
					{
						cmdStr += "," ; 
					}
					cmdStr  += "'" + dt.Rows[i]["budget_DeptCode"].ToString () + "'";


				}

				

			}

			return cmdStr;
			


		}

	}
}
