using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// SmallFixedBLL ��ժҪ˵����
	/// </summary>
	public class SmallFixedBLL
	{
		public SmallFixedBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static DataTable GetNCDeptInfo()
		{
			 
			return DataAccess.SmallFixed.SmallFixedDAL.GetNCDeptInfo();

		}

		/// <summary>
		/// ����Ƿ���ڹ������
		/// </summary>
		/// <param name="InvManageCode"></param>
		/// <returns></returns>
		public static bool CheckExistsInvManageCode(string invManageCode)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.CheckExistsInvManageCode(invManageCode);
		}

		//������Ϣ
		public static DataTable   GetInvInfo( )
		{
			return DataAccess.SmallFixed.SmallFixedDAL.GetInvInfo();
		}

		public static DataTable GetNCTypeInfo()
		{
			 
			return DataAccess.SmallFixed.SmallFixedDAL.GetNCTypeInfo();

		}
		/// <summary> 
		/// SmallFixedAsset�����ݲ���(Ŀǰֻ���벿���ֶε�����)
		/// </summary>
		/// <param name="sfa"></param>
		/// <returns></returns>
		public static int Save(Entiy.SmallFixedAsset sfa)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.Save(sfa); 
		}

		/// <summary>
		/// ����
		/// </summary>
		/// <param name="sfa"></param>
		/// <returns></returns>
		public static int Update(Entiy.SmallFixedAsset sfa)
		{
			return DataAccess.SmallFixed.SmallFixedDAL.Update(sfa);
		}





	}
}
