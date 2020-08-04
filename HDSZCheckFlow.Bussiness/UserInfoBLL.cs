using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// UserInfoBLL 的摘要说明。
	/// </summary>
	public class UserInfoBLL
	{
		public UserInfoBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 获取用户工号
		/// </summary>
		/// <param name="UserId"></param>
		/// <returns></returns>
		public static string GetUserName(int UserId)
		{
			return  DataAccess.UserInfo.UserInfoDAL.GetUserName(UserId);
		}

		public static int GetCountOfUserRole(string Role,string UserCode,string deptCode)
		{
			return DataAccess.UserInfo.UserInfoDAL.GetCountOfUserRole(Role,UserCode,deptCode);
		}

		public static int  GetSetChangeRoles(string myCode,string youCode,int type)
		{
			//转移身份给别人,或者回收审批权限
			return DataAccess.UserInfo.UserInfoDAL.SetChangeRole(myCode,youCode,type);
		}

		public static void  SetUserGiveUp(string myCode,int type )
		{
			DataAccess.UserInfo.UserInfoDAL.SetUserGiveUp(myCode,type);
		}

		#region 用户是否放弃审批权限
		public static int IsMyRoleGiveUp(string myCode)
		{
			return  DataAccess.UserInfo.UserInfoDAL.IsMyRoleGiveUp(myCode); 
		}
		#endregion 

		#region 用户审批权限状态
		public static string MyRoleState(string myCode)
		{
			string myRole= DataAccess.UserInfo.UserInfoDAL.MyRoleState(myCode);
			if("".Equals(myRole))
			{
				int IsGiveUp = DataAccess.UserInfo.UserInfoDAL.IsMyRoleGiveUp(myCode);
				if(IsGiveUp > 0 )
				{
					return "已暂时放弃审批权限";
				}
				else
				{
					return "未转交给任何人";
				}
			}
			else
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(myRole);
				if(person!=null && person.Name !=null)
				{
					return "已转交给:  " + person.Name ;
				}
				else
				{
					return "";
				}
			}
		}
		#endregion 


		#region 替审人工号
		public static string DisPersonCode(string myCode)
		{
			string DisplaysCode = DataAccess.UserInfo.UserInfoDAL.MyRoleState(myCode);
			if("".Equals(DisplaysCode))
			{
				DisplaysCode=myCode;
			}
			return DisplaysCode;
		}
		#endregion 

		/// <summary>
		/// 获取用户所在的预算部门
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public static string GetUserBudgetDept(string userID)
		{
			string budgetDept = "";
			try
			{
				// 1. 用户工号 
				string personCode = GetUserName(int.Parse(userID));
				// 2. 工号所属部门

				Entiy.BasePerson basePerson = Entiy.BasePerson.Find(personCode);
				if(basePerson != null )
				{
					// 3. 部门所属预算部门 
					Entiy.BaseDept baseDept = Entiy.BaseDept.FindByDeptCode(basePerson.DeptCode);
					if(baseDept !=null)
					{
						budgetDept = baseDept.BudgetDeptCode;
					}
				}
				return budgetDept ;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UserInfoBLL.GetUserBudgetDept",ex.Message );
				return budgetDept ;
			}
		}
		/// <summary>
		/// 查询用户所在一级部门
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>

		public static string GetUserClassDept(string userID)
		{
			string classDept = "";
			try
			{
				// 1. 用户工号 
				string personCode = GetUserName(int.Parse(userID));
				// 2. 工号所属部门

				Entiy.BasePerson basePerson = Entiy.BasePerson.Find(personCode);
				if(basePerson != null )
				{
					// 3. 部门所属预算部门 
					Entiy.BaseDept baseDept = Entiy.BaseDept.FindByDeptCode(basePerson.DeptCode);
					if(baseDept !=null)
					{
						classDept = baseDept.SuperiorDeptPk;
					}
				}
				return classDept ;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("UserInfoBLL.GetUserClassDept",ex.Message );
				return classDept ;
			}
		}

		/// <summary>
		/// 两人之间的主审，替审关系是否成立
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="displaysCode"></param>
		/// <returns></returns>
		public static bool displaysCheckRelation(string userCode ,string displaysCode)
		{
			return DataAccess.UserInfo.UserInfoDAL.displaysCheckRelation(userCode,displaysCode);

		}
	}
}
