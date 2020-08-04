using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// UserInfoBLL ��ժҪ˵����
	/// </summary>
	public class UserInfoBLL
	{
		public UserInfoBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ȡ�û�����
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
			//ת����ݸ�����,���߻�������Ȩ��
			return DataAccess.UserInfo.UserInfoDAL.SetChangeRole(myCode,youCode,type);
		}

		public static void  SetUserGiveUp(string myCode,int type )
		{
			DataAccess.UserInfo.UserInfoDAL.SetUserGiveUp(myCode,type);
		}

		#region �û��Ƿ��������Ȩ��
		public static int IsMyRoleGiveUp(string myCode)
		{
			return  DataAccess.UserInfo.UserInfoDAL.IsMyRoleGiveUp(myCode); 
		}
		#endregion 

		#region �û�����Ȩ��״̬
		public static string MyRoleState(string myCode)
		{
			string myRole= DataAccess.UserInfo.UserInfoDAL.MyRoleState(myCode);
			if("".Equals(myRole))
			{
				int IsGiveUp = DataAccess.UserInfo.UserInfoDAL.IsMyRoleGiveUp(myCode);
				if(IsGiveUp > 0 )
				{
					return "����ʱ��������Ȩ��";
				}
				else
				{
					return "δת�����κ���";
				}
			}
			else
			{
				Entiy.BasePerson person=Entiy.BasePerson.Find(myRole);
				if(person!=null && person.Name !=null)
				{
					return "��ת����:  " + person.Name ;
				}
				else
				{
					return "";
				}
			}
		}
		#endregion 


		#region �����˹���
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
		/// ��ȡ�û����ڵ�Ԥ�㲿��
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public static string GetUserBudgetDept(string userID)
		{
			string budgetDept = "";
			try
			{
				// 1. �û����� 
				string personCode = GetUserName(int.Parse(userID));
				// 2. ������������

				Entiy.BasePerson basePerson = Entiy.BasePerson.Find(personCode);
				if(basePerson != null )
				{
					// 3. ��������Ԥ�㲿�� 
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
		/// ��ѯ�û�����һ������
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>

		public static string GetUserClassDept(string userID)
		{
			string classDept = "";
			try
			{
				// 1. �û����� 
				string personCode = GetUserName(int.Parse(userID));
				// 2. ������������

				Entiy.BasePerson basePerson = Entiy.BasePerson.Find(personCode);
				if(basePerson != null )
				{
					// 3. ��������Ԥ�㲿�� 
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
		/// ����֮������������ϵ�Ƿ����
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
