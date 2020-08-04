using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// ApplyProcessTypeDAL 的摘要说明。
	/// </summary>
	public class ApplyProcessTypeDAL
	{
		public ApplyProcessTypeDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 查询装态类型 
		/// </summary>
		/// <returns></returns>
		public static DataTable   getProssType()
		{
			// 屏蔽新建，和取回 单据的查看 。。 先固定屏蔽 101. 201 . .以后做活
			DBAccess dbAccess=new SQLAccess();
			string cmdStr="SELECT ApplyProcessTypeCode, ApplyProcessTypeName FROM ApplyProcessType WHERE (ApplyProcessTypeCode NOT IN ('101', '201'))";
			DataSet ds=dbAccess.ExecuteDataset(cmdStr);
			if(ds!=null && ds.Tables.Count>0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 
		/// </summary>
		/// <param name="ProcessTypeCode"></param>
		/// <returns></returns>
		public static DataTable GetProssTypeByTypeCode(string ProcessTypeCode)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStr="SELECT ApplyProcessTypeCode, ApplyProcessTypeName FROM ApplyProcessType WHERE (ApplyProcessTypeCode  == '" + ProcessTypeCode + "')";
			DataSet ds=dbAccess.ExecuteDataset(cmdStr);
			if(ds!=null && ds.Tables.Count>0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}

		}

		/// <summary>
		/// 查询装态类型 
		/// </summary>
		/// <returns></returns>
		public static DataTable   getProssTypeAll()
		{
			// 屏蔽新建，和取回 单据的查看 。。 先固定屏蔽 101. 201 ..以后做活
			DBAccess dbAccess=new SQLAccess();
			string cmdStr="SELECT ApplyProcessTypeCode, ApplyProcessTypeName FROM ApplyProcessType ";
			DataSet ds=dbAccess.ExecuteDataset(cmdStr);
			if(ds!=null && ds.Tables.Count>0)
			{
				return ds.Tables[0];
			}
			else
			{
				return null;
			}
		}
	}
}
