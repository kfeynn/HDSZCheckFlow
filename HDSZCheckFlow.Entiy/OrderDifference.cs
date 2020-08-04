// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("OrderDifference")]
    public class OrderDifference : ActiveRecordBase
    {
        
        private int _id;
        
        private string _orderNo;
        
        private string _inventoryCode;
        
        private int _isDone;
        
        private string _reMark;
        
        [PrimaryKey(PrimaryKeyType.Native)]
        public int Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
        
        [Property()]
        public string OrderNo
        {
            get
            {
                return this._orderNo;
            }
            set
            {
                this._orderNo = value;
            }
        }
        
        [Property()]
        public string InventoryCode
        {
            get
            {
                return this._inventoryCode;
            }
            set
            {
                this._inventoryCode = value;
            }
        }
        
        [Property()]
        public int IsDone
        {
            get
            {
                return this._isDone;
            }
            set
            {
                this._isDone = value;
            }
        }
        
        [Property()]
        public string ReMark
        {
            get
            {
                return this._reMark;
            }
            set
            {
                this._reMark = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(OrderDifference));
        }
        
        public static OrderDifference[] FindAll()
        {
            return ((OrderDifference[])(ActiveRecordBase.FindAll(typeof(OrderDifference))));
        }
        
        public static OrderDifference Find(int Id)
        {
            return ((OrderDifference)(ActiveRecordBase.FindByPrimaryKey(typeof(OrderDifference), Id,false)));
        }

		public static OrderDifference FindByOrderNoAndInventoryCode(string OrderNO,string InventoryCode)
		{
			SimpleQuery query = new SimpleQuery(typeof(OrderDifference),"from  OrderDifference o where o.OrderNo = ? and o.InventoryCode=?",OrderNO,InventoryCode);
			OrderDifference[] orderDiff = (OrderDifference[])ExecuteQuery(query);
			if(orderDiff!=null && orderDiff.Length>0)
			{
				return orderDiff[0];
			}
			else
			{
				return null;
			}
		}
    }
}