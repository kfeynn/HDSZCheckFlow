// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("budget_account")]
    public class Budgetaccount : ActiveRecordBase
    {
        
        private int _budgetAccountPk;
        
        private int _iyear;
        
        private int _imonth;
        
        private string _deptCode;
        
        private string _subjectCode;
        
        private System.Decimal _budgetMoney;
        
        private System.Decimal _budgetChangeMoney;
        
        private System.Decimal _budgetAddMoney;
        
        private System.Decimal _checkMoney;
        
        private System.Decimal _realMoney;

		private System.Decimal _planMoney;

		private System.Decimal _readypay;

		private System.Decimal _totalAllowOutMoney;

        
        [PrimaryKey(PrimaryKeyType.Native,"budget_account_pk")]
        public int BudgetAccountPk
        {
            get
            {
                return this._budgetAccountPk;
            }
            set
            {
                this._budgetAccountPk = value;
            }
        }
        
        [Property()]
        public int Iyear
        {
            get
            {
                return this._iyear;
            }
            set
            {
                this._iyear = value;
            }
        }
        
        [Property()]
        public int Imonth
        {
            get
            {
                return this._imonth;
            }
            set
            {
                this._imonth = value;
            }
        }
        
        [Property()]
        public string DeptCode
        {
            get
            {
                return this._deptCode;
            }
            set
            {
                this._deptCode = value;
            }
        }
        
        [Property()]
        public string SubjectCode
        {
            get
            {
                return this._subjectCode;
            }
            set
            {
                this._subjectCode = value;
            }
        }
        
        [Property()]
        public System.Decimal BudgetMoney
        {
            get
            {
                return this._budgetMoney;
            }
            set
            {
                this._budgetMoney = value;
            }
        }
        
        [Property()]
        public System.Decimal BudgetChangeMoney
        {
            get
            {
                return this._budgetChangeMoney;
            }
            set
            {
                this._budgetChangeMoney = value;
            }
        }
        
        [Property()]
        public System.Decimal BudgetAddMoney
        {
            get
            {
                return this._budgetAddMoney;
            }
            set
            {
                this._budgetAddMoney = value;
            }
        }
        
        [Property()]
        public System.Decimal CheckMoney
        {
            get
            {
                return this._checkMoney;
            }
            set
            {
                this._checkMoney = value;
            }
        }
        
        [Property()]
        public System.Decimal RealMoney
        {
            get
            {
                return this._realMoney;
            }
            set
            {
                this._realMoney = value;
            }
        }

		[Property()]
		public System.Decimal PlanMoney
		{
			get
			{
				return this._planMoney;
			}
			set
			{
				this._planMoney = value;
			}
		}

		[Property()]
		public System.Decimal Readypay
		{
			get
			{
				return this._readypay;
			}
			set
			{
				this._readypay = value;
			}
		}
    
		[Property()]
		public System.Decimal TotalAllowOutMoney
		{
			get
			{
				return this._totalAllowOutMoney;
			}
			set
			{
				this._totalAllowOutMoney = value;
			}
		}
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(Budgetaccount));
        }
        
        public static Budgetaccount[] FindAll()
        {
            return ((Budgetaccount[])(ActiveRecordBase.FindAll(typeof(Budgetaccount))));
        }

		public static Budgetaccount Find(int BudgetAccountPk)
		{
			return ((Budgetaccount)(ActiveRecordBase.FindByPrimaryKey(typeof(Budgetaccount), BudgetAccountPk,false)));
		}

		public static Budgetaccount FindByYearAndMonth(int iYear,int iMonth,string deptCode,string subjectCode)
		{
			SimpleQuery query=new SimpleQuery(typeof(Budgetaccount),@"from Budgetaccount o where o.Iyear= ? and o.Imonth= ? and o.DeptCode= ? and o.SubjectCode=? ",iYear,iMonth,deptCode,subjectCode);
			Budgetaccount []budGet = (Budgetaccount[])ExecuteQuery(query); 
			if(budGet!=null && budGet.Length>0)
			{
				return budGet[0];
			}
			else
			{
				return null;
			}
		}

		public static Budgetaccount[] FindAccountByYearAndMonth(int iYear, int iMonth)
		{
			SimpleQuery query=new SimpleQuery(typeof(Budgetaccount),@"from Budgetaccount o where o.Iyear= ? and o.Imonth= ? ",iYear,iMonth);
			Budgetaccount []budGet = (Budgetaccount[])ExecuteQuery(query); 
			return budGet;
		}
    }
}
