// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("ApplySheetBody_EvectionCharge")]
    public class ApplySheetBodyEvectionCharge : ActiveRecordBase
    {
        
        private int _applySheetBodyEvectionChargePk;
        
        private int _applySheetHeadPk;
        
        private string _chargePro;
        
        private System.Decimal _money;
        
        private string _currcode;
        
        private System.Decimal _exchangeRate;
        
        private string _memo;
        
        [PrimaryKey(PrimaryKeyType.Native, "ApplySheetBody_EvectionCharge_pk")]
        public int ApplySheetBodyEvectionChargePk
        {
            get
            {
                return this._applySheetBodyEvectionChargePk;
            }
            set
            {
                this._applySheetBodyEvectionChargePk = value;
            }
        }
        
        [Property(Column="ApplySheetHead_Pk")]
        public int ApplySheetHeadPk
        {
            get
            {
                return this._applySheetHeadPk;
            }
            set
            {
                this._applySheetHeadPk = value;
            }
        }
        
        [Property()]
        public string ChargePro
        {
            get
            {
                return this._chargePro;
            }
            set
            {
                this._chargePro = value;
            }
        }
        
        [Property()]
        public System.Decimal Money
        {
            get
            {
                return this._money;
            }
            set
            {
                this._money = value;
            }
        }
        
        [Property()]
        public string Currcode
        {
            get
            {
                return this._currcode;
            }
            set
            {
                this._currcode = value;
            }
        }
        
        [Property()]
        public System.Decimal ExchangeRate
        {
            get
            {
                return this._exchangeRate;
            }
            set
            {
                this._exchangeRate = value;
            }
        }
        
        [Property()]
        public string Memo
        {
            get
            {
                return this._memo;
            }
            set
            {
                this._memo = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(ApplySheetBodyEvectionCharge));
        }
        
        public static ApplySheetBodyEvectionCharge[] FindAll()
        {
            return ((ApplySheetBodyEvectionCharge[])(ActiveRecordBase.FindAll(typeof(ApplySheetBodyEvectionCharge))));
        }
        
        public static ApplySheetBodyEvectionCharge Find(int ApplySheetBodyEvectionChargePk)
        {
            return ((ApplySheetBodyEvectionCharge)(ActiveRecordBase.FindByPrimaryKey(typeof(ApplySheetBodyEvectionCharge), ApplySheetBodyEvectionChargePk,false)));
        }

		public static ApplySheetBodyEvectionCharge[] FindByApplyHeadPk(int ApplyHeadPk)
		{
			SimpleQuery query=new SimpleQuery(typeof(ApplySheetBodyEvectionCharge),@"from ApplySheetBodyEvectionCharge o where  o.ApplySheetHeadPk=?",ApplyHeadPk);
			return (ApplySheetBodyEvectionCharge[])ExecuteQuery(query);
		}
    }
}
