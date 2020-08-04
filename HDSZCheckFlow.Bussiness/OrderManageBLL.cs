using System;
using System.Data;
using System.Web.UI.WebControls;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// OrderManageBLL 的摘要说明。
	/// </summary>
	public class OrderManageBLL
	{
		public OrderManageBLL()
		{
		}

		public static DataTable GetNormalTable()
		{
			//制造一个
			DataTable dt = new DataTable();
			dt.Columns.Add("ApplySheetBody_Purchase_pk");
			dt.Columns.Add("ApplySheetHead_Pk");
			dt.Columns.Add("ApplySheetNo");
			dt.Columns.Add("DeptName");
			dt.Columns.Add("ApplyTypeName");
			dt.Columns.Add("ApplyDate");
			dt.Columns.Add("InventoryCode");
			dt.Columns.Add("invName");
			dt.Columns.Add("Number");
			dt.Columns.Add("RMBPrice");
			dt.Columns.Add("money");
			dt.Columns.Add("IsOrder");
			dt.Columns.Add("orderDate");
			dt.Columns.Add("OrderNo");
			dt.Columns.Add("IsGiveUp");
			dt.Columns.Add("memo");

			return dt;
		}

		public static DataTable MakeTableFromDataGrid(DataGrid dgApply)
		{
			try
			{
				DataTable dt = new DataTable() ; 
				dt = Bussiness.OrderManageBLL.GetNormalTable();
				foreach(DataGridItem itm in dgApply.Items )
				{
					DataRow dr = dt.NewRow(); 
					dr["ApplySheetBody_Purchase_pk"] = dgApply.Items[itm.ItemIndex].Cells[0].Text ; 
					dr["ApplySheetHead_Pk"] = dgApply.Items[itm.ItemIndex].Cells[15].Text ; 

					HyperLink hl = (HyperLink)dgApply.Items[itm.ItemIndex].Cells[2].Controls[0];   
					dr["ApplySheetNo"] = hl.Text  ; 

					dr["DeptName"] = dgApply.Items[itm.ItemIndex].Cells[3].Text ; 
					dr["ApplyTypeName"] = dgApply.Items[itm.ItemIndex].Cells[4].Text ; 
					dr["ApplyDate"] = dgApply.Items[itm.ItemIndex].Cells[5].Text ; 
					dr["InventoryCode"] = dgApply.Items[itm.ItemIndex].Cells[6].Text ; 
					dr["invName"] = dgApply.Items[itm.ItemIndex].Cells[7].Text ; 
					dr["Number"] = dgApply.Items[itm.ItemIndex].Cells[8].Text ; 
					dr["RMBPrice"] = dgApply.Items[itm.ItemIndex].Cells[9].Text ; 
					dr["money"] = dgApply.Items[itm.ItemIndex].Cells[10].Text ; 
						
					if("".Equals(dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) || "&nbsp;".Equals(dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()))
					{
//						dr["IsOrder"] = 0 ; 
					}
					else
					{
						dr["IsOrder"] = int.Parse(dgApply.Items[itm.ItemIndex].Cells[11].Text.Trim()) ; 
					}
					if("".Equals(dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()) || "&nbsp;".Equals(dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim()))
					{
						//dr["orderDate"] = "" ; 
					}
					else
					{
						//Convert.ToDateTime
						dr["orderDate"] = dgApply.Items[itm.ItemIndex].Cells[12].Text.Trim() ; 
					}

					if("".Equals(dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()) || "&nbsp;".Equals(dgApply.Items[itm.ItemIndex].Cells[13].Text.Trim()))
					{
//						dr["OrderNo"] = "" ; 
					}
					else
					{
						dr["OrderNo"] = dgApply.Items[itm.ItemIndex].Cells[13].Text ; 
					}
					if("".Equals(dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()) || "&nbsp;".Equals(dgApply.Items[itm.ItemIndex].Cells[14].Text.Trim()))
					{
//						dr["IsGiveUp"] = 0 ; 
					}
					else
					{
						dr["IsGiveUp"] =int.Parse( dgApply.Items[itm.ItemIndex].Cells[14].Text) ; 
					}
					if("".Equals(dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()) || "&nbsp;".Equals(dgApply.Items[itm.ItemIndex].Cells[16].Text.Trim()))
					{
					}
					else
					{
						dr["memo"] = dgApply.Items[itm.ItemIndex].Cells[16].Text ; 
					}
					dt.Rows.Add(dr);
				}
				return dt; 
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Bussiness.OrderManageBLL.MakeTableFromDataGrid",ex.Message);
				return null;
			}
		}

		/// <summary>
		/// 根据OrderId查找  OrderBody信息
		/// </summary>
		/// <param name="OrderId"></param>
		/// <returns></returns>
		public static DataSet GetOrderBodyByOrderId(int OrderId)
		{
			try
			{
				DataSet ds =   DataAccess.OrderManage.OrderManageDAL.GetOrderBodyByOrderId(OrderId) ;
				if(ds!=null && ds.Tables[0].Rows.Count>0)
				{
					ds.Tables[0].Columns.Add("seqNum");        //序号
					for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
					{
						int Num=i+1;
						ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					}
				}
				return ds;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("OrderManageBLL.GetOrderBodyByOrderId",ex.Message );
				return null;
			}
		}

		/// <summary>
		/// 根据OrderId，查找定单报表所需信息
		/// </summary>
		/// <param name="OrderId"></param>
		/// <returns></returns>
		public static DataSet GetOrderInfoForReport(int OrderId)
		{
			string view="",view2="";
			string query="",query2="";
			// 1. 取得要查询的视图 

			view = "v_Order_Info";  // 要查询两个表 v_BaseApplyPurchase , v_ApplyCheckRecord 表单基本信息,审批信息
			query = " where id= " + OrderId + "  ";
			Entiy.OrderSheet order = Entiy.OrderSheet.Find(OrderId);
			if (order == null )
			{
				return null;
			}

			view2 = "v_BaseApplyPurchase";
			query2 = "  where OrderNo = '" + order.OrderNo  + "' order by applysheetno desc ,Inventorycode asc "   ;//+ "  and  ispass!='拒绝'  ";
			
			//组合一个符合报表的DataSet ,(1.装载两个表的DataSet BaseApplyPurchase,ApplyCheckRecord)
			DataSet ds1 = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view,query);
			ds1.Tables[0].TableName ="ds1";
			DataSet ds2 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view2,query2);
			ds2.Tables[0].TableName = "ds2";


			DataSet ds=new DataSet();
			ds.Tables.Add(ds1.Tables["ds1"].Copy());
			ds.Tables.Add(ds2.Tables["ds2"].Copy());

			ds.Tables[0].TableName = "OrderHead";     
			ds.Tables[1].TableName = "v_BaseApplyPurchase";
				
			return ds;		
		}

		public static DataSet GetJudgetNcBudOrderInfo(string filter)
		{
			//获取对应信息

			return DataAccess.OrderManage.OrderManageDAL.GetJudgetNcBudOrderInfo(filter);

		}
		public static void UpdatePurchase(string OrderNo)
		{
			DataAccess.OrderManage.OrderManageDAL.UpdatePurchase( OrderNo);
		}
	}
}
