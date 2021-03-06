// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("ApplySheetBody_Evection")]
    public class ApplySheetBodyEvection : ActiveRecordBase
    {
        
        private int _applySheetBodyEvectionPk;
        
        private int _applySheetHeadPk;
        
        private System.DateTime _dateFrom;
        
        private System.DateTime _dateTo;
        
        private string _goCity;
        
        private string _evecionType;
        
        private string _appClass;
        
        private int _withapps;
        
        private string _withwho;
        
        private string _appduty;
        
        private string _preabroaddate;
        
        private string _prebackdate;

		private int _visa;
        
        private string _visadate;
        
        private int _passport;
        
        private string _passportno;
        
        private string _passportdate;
        
        private int _bacterin;
        
        private string _bacterindate;
        
        private string _memo;
        
        private int _limitdartcle;
        
        private int _limittech;
        
        private int _checkup;
        
        private int _meetcondition;
        
        private string _checkupdate;
        
        [PrimaryKey(PrimaryKeyType.Native, "ApplySheetBody_Evection_pk")]
        public int ApplySheetBodyEvectionPk
        {
            get
            {
                return this._applySheetBodyEvectionPk;
            }
            set
            {
                this._applySheetBodyEvectionPk = value;
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
        public System.DateTime DateFrom
        {
            get
            {
                return this._dateFrom;
            }
            set
            {
                this._dateFrom = value;
            }
        }
        
        [Property()]
        public System.DateTime DateTo
        {
            get
            {
                return this._dateTo;
            }
            set
            {
                this._dateTo = value;
            }
        }
        
        [Property()]
        public string GoCity
        {
            get
            {
                return this._goCity;
            }
            set
            {
                this._goCity = value;
            }
        }
        
        [Property()]
        public string EvecionType
        {
            get
            {
                return this._evecionType;
            }
            set
            {
                this._evecionType = value;
            }
        }
        
        [Property()]
        public string AppClass
        {
            get
            {
                return this._appClass;
            }
            set
            {
                this._appClass = value;
            }
        }
        
        [Property()]
        public int Withapps
        {
            get
            {
                return this._withapps;
            }
            set
            {
                this._withapps = value;
            }
        }
        
        [Property()]
        public string Withwho
        {
            get
            {
                return this._withwho;
            }
            set
            {
                this._withwho = value;
            }
        }
        
        [Property()]
        public string Appduty
        {
            get
            {
                return this._appduty;
            }
            set
            {
                this._appduty = value;
            }
        }
        
        [Property()]
        public string Preabroaddate
        {
            get
            {
                return this._preabroaddate;
            }
            set
            {
                this._preabroaddate = value;
            }
        }
        
        [Property()]
        public string Prebackdate
        {
            get
            {
                return this._prebackdate;
            }
            set
            {
                this._prebackdate = value;
            }
        }

		[Property()]
		public int Visa
		{
			get
			{
				return this._visa;
			}
			set
			{
				this._visa = value;
			}
		}
        
        [Property()]
        public string Visadate
        {
            get
            {
                return this._visadate;
            }
            set
            {
                this._visadate = value;
            }
        }
        
        [Property()]
        public int Passport
        {
            get
            {
                return this._passport;
            }
            set
            {
                this._passport = value;
            }
        }
        
        [Property()]
        public string Passportno
        {
            get
            {
                return this._passportno;
            }
            set
            {
                this._passportno = value;
            }
        }
        
        [Property()]
        public string Passportdate
        {
            get
            {
                return this._passportdate;
            }
            set
            {
                this._passportdate = value;
            }
        }
        
        [Property()]
        public int Bacterin
        {
            get
            {
                return this._bacterin;
            }
            set
            {
                this._bacterin = value;
            }
        }
        
        [Property()]
        public string Bacterindate
        {
            get
            {
                return this._bacterindate;
            }
            set
            {
                this._bacterindate = value;
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
        
        [Property()]
        public int Limitdartcle
        {
            get
            {
                return this._limitdartcle;
            }
            set
            {
                this._limitdartcle = value;
            }
        }
        
        [Property()]
        public int Limittech
        {
            get
            {
                return this._limittech;
            }
            set
            {
                this._limittech = value;
            }
        }
        
        [Property()]
        public int Checkup
        {
            get
            {
                return this._checkup;
            }
            set
            {
                this._checkup = value;
            }
        }
        
        [Property()]
        public int Meetcondition
        {
            get
            {
                return this._meetcondition;
            }
            set
            {
                this._meetcondition = value;
            }
        }
        
        [Property()]
        public string Checkupdate
        {
            get
            {
                return this._checkupdate;
            }
            set
            {
                this._checkupdate = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(ApplySheetBodyEvection));
        }
        
        public static ApplySheetBodyEvection[] FindAll()
        {
            return ((ApplySheetBodyEvection[])(ActiveRecordBase.FindAll(typeof(ApplySheetBodyEvection))));
        }
        
        public static ApplySheetBodyEvection Find(int ApplySheetBodyEvectionPk)
        {
            return ((ApplySheetBodyEvection)(ActiveRecordBase.FindByPrimaryKey(typeof(ApplySheetBodyEvection), ApplySheetBodyEvectionPk,false)));
        }

		public static ApplySheetBodyEvection FindByApplyHeadPk(int ApplyHeadPk)
		{
			SimpleQuery query=new SimpleQuery(typeof(ApplySheetBodyEvection),@"from ApplySheetBodyEvection o where o.ApplySheetHeadPk=? ",ApplyHeadPk);
			ApplySheetBodyEvection[] Values=(ApplySheetBodyEvection[]) ExecuteQuery(query);
			if(Values!=null && Values.Length>0)
			{
				return Values[0];
			}
			else
			{
				return null;
			}
		}
    }
}
