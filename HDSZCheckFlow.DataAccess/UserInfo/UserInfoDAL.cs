using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.UserInfo
{
	/// <summary>
	/// UserInfoDAL 的摘要说明。
	/// </summary>
	public class UserInfoDAL
	{
		public UserInfoDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 根据ID取用户工号
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static string GetUserName(int UserID)
		{
			try
			{
				DBAccess dbAccess=new SQLAccess();
				string cmdStr="select top 1 UserName from xpGrid_User where UserID= " + UserID + " " ;
				return dbAccess.ExecuteScalar(cmdStr).ToString();
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.UserInfoDAL",ex.Message );
				return "";
			}
		}

		public static int GetCountOfUserRole(string Role,string UserCode,string deptCode)
		{
			// 根据 角色,用户Code,部门Code  判断当前审批角色是否属于此人 . (考虑到有转移权限的情况)
			try
			{
				string cmdStr=@"SELECT count(0) FROM CheckFlowInDept CROSS JOIN CheckPersonInRole WHERE (CheckFlowInDept.CheckPersonCode IN (SELECT UserName FROM xpGrid_User " +
					@"WHERE (displaysPerson = '" + UserCode + "') AND (IsDisplays = 1) OR (UserName = '" + UserCode + "'))) AND (CheckFlowInDept.CheckRoleCode = '" + Role + "') AND  " +
					"(CheckFlowInDept.DeptCode = '" + deptCode + "') OR " + 
					@"(CheckPersonInRole.CheckRoleCode = '" + Role + "') AND  " + 
					"(CheckPersonInRole.PersonCode IN (SELECT UserName FROM xpGrid_User " +
					@"WHERE (displaysPerson = '" + UserCode + "') AND (IsDisplays = 1) OR "+
					"(UserName = '" + UserCode + "')))";

				DBAccess dbAccess=new SQLAccess();
				return (int)dbAccess.ExecuteScalar(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.UserInfoDAL.GetCountOfUserRole",ex.Message );
				return -1;
			}
		}

		/// <summary>
		/// 设置转移权限
		/// </summary>
		/// <param name="myCode"></param>
		/// <param name="youCode"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public static int SetChangeRole(string myCode,string youCode,int type)
		{
			try
			{
				string cmdStr="update xpGrid_User set displaysPerson='" + youCode  + "',IsDisplays=" + type + " where UserName='" + myCode + "'";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteNonQuery(cmdStr);
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.UserInfoDAL",ex.Message );
				return 0;
			}
		}

		/// <summary>
		/// 设置用户放弃审批权限
		/// </summary>
		/// <param name="myCode">用户工号</param>
		public static void  SetUserGiveUp(string myCode,int type )
		{
			string cmdStr="update xpGrid_User set IsGiveUp =" + type + " where UserName='" + myCode + "'";
			DBAccess dbAccess=new SQLAccess();
			dbAccess.ExecuteNonQuery(cmdStr);
		}

		public static string MyRoleState(string myCode)
		{
			try
			{
				string cmdStr="select displaysPerson from xpGrid_User where IsDisplays=1 and UserName='" + myCode + "'";
				DBAccess dbAccess=new SQLAccess();
				Object o=dbAccess.ExecuteScalar(cmdStr);
				if(o!=null)
				{
					return o.ToString();
				}
				else
				{
					return "";
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.UserInfoDAL.MyRoleState",ex.Message );
				return "";
			}
		}

		public static int IsMyRoleGiveUp(string myCode)
		{
			string cmdStr="select count(*) from xpGrid_User where   UserName='" + myCode + "' and isGiveup = 1 ";
			DBAccess dbAccess = new SQLAccess();
			Object o=dbAccess.ExecuteScalar(cmdStr);
			if(o!=null)
			{
				return (int)o ;
			}
			else
			{
				return 0 ;
			}
		}

		/// <summary>
		/// 本人权限是否已转交给这个人
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="displaysCode"></param>
		/// <returns></returns>
		public static bool displaysCheckRelation(string userCode ,string displaysCode)
		{
			try
			{
				string cmdStr = "SELECT count(*) FROM xpGrid_User where username = '" + userCode + "' and displaysperson = '" + displaysCode + "' and  IsDisplays=1 ";
				DBAccess dbAccess = new SQLAccess();
				int i = (int)dbAccess.ExecuteScalar(cmdStr);
				if(i>0)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.UserInfoDAL.MyRoleState",ex.Message );
				return false;
			}
		}



	}
}
