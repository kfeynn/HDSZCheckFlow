using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.OrderManage
{
	/// <summary>
	/// OrderManageDAL 的摘要说明。
	/// </summary>
	public class OrderManageDAL
	{
		public OrderManageDAL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 根据OrderId查找  OrderBody信息
		/// </summary>
		/// <param name="OrderId"></param>
		/// <returns></returns>
		public static DataSet  GetOrderBodyByOrderId(int OrderId)
		{

			string cmdStr = "SELECT * FROM v_BaseApplyPurchase WHERE (OrderNo =  (SELECT orderno FROM ordersheet WHERE id = " + OrderId + "))";
			DBAccess dbAccess = new SQLAccess();
			return  dbAccess.ExecuteDataset (cmdStr);

		}

		public static DataSet GetJudgetNcBudOrderInfo(string filter)
		{
			//获取对应信息
			string cmdStr = "select * from v_BudNcOrderInfo " + filter;
			DBAccess dbAccess = new SQLAccess();
			return dbAccess.ExecuteDataset (cmdStr); 
		}

		public static void UpdatePurchase(string OrderNo)
		{
			string cmdStr= " UPDATE ApplySheetBody_Purchase SET IsOrder = 0,OrderNo=''  WHERE OrderNo = '" + OrderNo + "' ";
			DBAccess dbAccess = new SQLAccess();
			dbAccess.ExecuteNonQuery(cmdStr);
		}

	}
}
