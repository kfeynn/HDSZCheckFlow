using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.BaseInfo
{
	/// <summary>
	/// ApplyProcessTypeDAL ��ժҪ˵����
	/// </summary>
	public class ApplyProcessTypeDAL
	{
		public ApplyProcessTypeDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ѯװ̬���� 
		/// </summary>
		/// <returns></returns>
		public static DataTable   getProssType()
		{
			// �����½�����ȡ�� ���ݵĲ鿴 ���� �ȹ̶����� 101. 201 . .�Ժ�����
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
		/// ��ѯװ̬���� 
		/// </summary>
		/// <returns></returns>
		public static DataTable   getProssTypeAll()
		{
			// �����½�����ȡ�� ���ݵĲ鿴 ���� �ȹ̶����� 101. 201 ..�Ժ�����
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
