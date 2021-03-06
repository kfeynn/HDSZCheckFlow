// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("budget_change_Sheet")]
    public class BudgetchangeSheet : ActiveRecordBase
    {
        
        private int _budgetChangePk;
        
        private int _iyear;
        
        private int _imonth;
        
        private System.DateTime _sheetDate;
        
        private string _deptCode;
        
        private string _sheetTypeCode;
        
        private string _outSubject;
        
        private string _inSubject;
        
        private System.Decimal _money;
        
        [PrimaryKey(PrimaryKeyType.Native, "budget_change_pk")]
        public int BudgetChangePk
        {
            get
            {
                return this._budgetChangePk;
            }
            set
            {
                this._budgetChangePk = value;
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
        public System.DateTime SheetDate
        {
            get
            {
                return this._sheetDate;
            }
            set
            {
                this._sheetDate = value;
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
        public string SheetTypeCode
        {
            get
            {
                return this._sheetTypeCode;
            }
            set
            {
                this._sheetTypeCode = value;
            }
        }
        
        [Property()]
        public string OutSubject
        {
            get
            {
                return this._outSubject;
            }
            set
            {
                this._outSubject = value;
            }
        }
        
        [Property()]
        public string InSubject
        {
            get
            {
                return this._inSubject;
            }
            set
            {
                this._inSubject = value;
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
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(BudgetchangeSheet));
        }
        
        public static BudgetchangeSheet[] FindAll()
        {
            return ((BudgetchangeSheet[])(ActiveRecordBase.FindAll(typeof(BudgetchangeSheet))));
        }
        
        public static BudgetchangeSheet Find(int BudgetChangePk)
        {
            return ((BudgetchangeSheet)(ActiveRecordBase.FindByPrimaryKey(typeof(BudgetchangeSheet), BudgetChangePk,false)));
        }

		public static BudgetchangeSheet FindByYearAndMonth(int iYear,int iMonth)
		{
			SimpleQuery query=new SimpleQuery(typeof(BudgetchangeSheet),@"from BudgetchangeSheet o where o.Iyear= ? and o.Imonth= ?",iYear,iMonth);
			BudgetchangeSheet []budGet = (BudgetchangeSheet[])ExecuteQuery(query); 
			if(budGet!=null && budGet.Length>0)
			{
				return budGet[0];
			}
			else
			{
				return null;
			}
		}

		public static BudgetchangeSheet[] FindChangeSheetOut(int iYear,int iMonth,string deptCode,string subjectCode)
		{
			//科目转出
			SimpleQuery query=new SimpleQuery(typeof(BudgetchangeSheet),@"from BudgetchangeSheet o where o.Iyear=? and o.Imonth=? and o.DeptCode=?  and OutSubject=?  ",iYear,iMonth,deptCode,subjectCode);
			BudgetchangeSheet[] budgetchangeSheets=(BudgetchangeSheet[])ExecuteQuery(query);
			return budgetchangeSheets;
		}

		public static BudgetchangeSheet[] FindChangeSheetIn(int iYear,int iMonth,string deptCode,string subjectCode)
		{
			//科目转入
			SimpleQuery query=new SimpleQuery(typeof(BudgetchangeSheet),@"from BudgetchangeSheet o where o.Iyear=? and o.Imonth=? and o.DeptCode=?  and InSubject=?  ",iYear,iMonth,deptCode,subjectCode);
			BudgetchangeSheet[] budgetchangeSheets=(BudgetchangeSheet[])ExecuteQuery(query);
			return budgetchangeSheets;
		}

    }
}
