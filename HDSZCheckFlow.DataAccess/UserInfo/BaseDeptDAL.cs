using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.UserInfo
{
	/// <summary>
	/// BaseDeptDAL ��ժҪ˵����
	/// </summary>
	public class BaseDeptDAL
	{
		public BaseDeptDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		/// <summary>
		/// ����ID��ȡ���ڲ���
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static DataTable GetDeptForUserID(int UserID)
		{
			try
			{
				string cmdStr="" ;
				if(UserID == 0 )              //��ѯ����һ������
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
		/// ���ݲ��Ų�ѯ����
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
		/// ���ݲ��Ų�ѯ����ForAdd
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



		//*******************************************************С��̶��ʲ����õ������²���(2013-12-10 liyang)****************************************************
		/// <summary>
		/// ��ȡ���в�����Ϣ
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
		/// ���ݲ��Ų�ѯ������Ϣ(�ݹ鲿���µ����пƺ�����Ϣ)
		/// </summary>
		/// <param name="fbmbh">���ڵ����</param>
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
		/// ����һ�����Ų�ѯ����nc���ţ��Զ��ŷָ�
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
