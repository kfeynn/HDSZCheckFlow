using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.UserInfo
{
	/// <summary>
	/// BaseDeptDAL 的摘要说明。
	/// </summary>
	public class BaseDeptDAL
	{
		public BaseDeptDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 根据ID获取所在部门
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static DataTable GetDeptForUserID(int UserID)
		{
			try
			{
				string cmdStr="" ;
				if(UserID == 0 )              //查询所有一级部门
				{
					cmdStr="SELECT DeptCode, DeptName FROM Base_Dept where (DeptCode = superior_Dept_pk)";
				}
				else
				{
					cmdStr=@"SELECT DeptCode, DeptName FROM Base_Dept where (DeptCode = superior_Dept_pk) AND (DeptCode IN (SELECT superior_Dept_pk
							FROM Base_Dept WHERE DeptCode IN
							(SELECT DeptCode FROM Base_Person WHERE personCode =
                            (SELECT UserName FROM xpGrid_User WHERE UserID = " + UserID + "))))";
				}
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 根据部门查询科组
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClass(string DeptClassCode)
		{
			try
			{
				string cmdStr="select DeptCode, DeptName from Base_Dept  where   superior_Dept_pk = '" + DeptClassCode + "'   AND (DeptCode <> '" + DeptClassCode + "') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL",ex.Message );
				return null;
			}
		} 

		/// <summary>
		/// 根据部门查询科组ForAdd
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassForAdd(string DeptClassCode)
		{
			try
			{
				string cmdStr="select DeptCode, DeptName from Base_Dept  where  dr <> 1  and superior_Dept_pk = '" + DeptClassCode + "'   AND (DeptCode <> '" + DeptClassCode + "') ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL",ex.Message );
				return null;
			}
		}



		//*******************************************************小额固定资产所用到的人事部门(2013-12-10 liyang)****************************************************
		/// <summary>
		/// 获取所有部门信息
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAllDeptBySmallFixed()
		{
			try
			{
				string cmdStr=" select bmid,bmbh,bmmc,fbmbh,ManagerCode,ManagerName from Base_Dept_ForSmallFixed where IsValid=1 and fbmbh='000000' ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL",ex.Message );
				return null;
			}
		} 

		/// <summary>
		/// 根据部门查询科组信息(递归部门下的所有科和组信息)
		/// </summary>
		/// <param name="fbmbh">父节点编码</param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassBySmallFixed(string fbmbh)
		{
			try
			{
				string cmdStr=" with Dept_temp(bmid,bmbh,bmmc,fbmbh,ManagerCode,ManagerName) as ( "+
											" select bmid,bmbh,bmmc,fbmbh,ManagerCode,ManagerName "+
											" from Base_Dept_ForSmallFixed where fbmbh='"+fbmbh+"' and IsValid=1 "+
											" union all "+
											" select a.bmid,a.bmbh,a.bmmc,a.fbmbh,a.ManagerCode,a.ManagerName "+
											" from Base_Dept_ForSmallFixed a,Dept_temp "+
											" where a.fbmbh=Dept_temp.bmbh and a.IsValid=1 "+
											" )select * from Dept_temp ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL",ex.Message );
				return null;
			}
		}

		//*****************************************************************************************************************************************


		/// <summary>
		/// 根据一级部门查询所属nc部门，以逗号分隔
		/// </summary>
		/// <param name="ClassDeptCode"></param>
		/// <returns></returns>
		public static DataTable GetMyNcDeptCode(string ClassDeptCode)
		{
			try
			{
				string cmdStr=" select * from dbo.Base_Dept where superior_Dept_pk = '" + ClassDeptCode + "'  ";
				DBAccess dbAccess=new SQLAccess();
				return dbAccess.ExecuteDataset(cmdStr).Tables[0];
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("DataAccess.UserInfo.BaseDeptDAL.GetMyNcDeptCode",ex.Message );
				return null;
			}



		
		
		}

	}
}
