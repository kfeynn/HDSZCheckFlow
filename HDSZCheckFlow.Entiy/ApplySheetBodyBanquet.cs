// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    [ActiveRecord("ApplySheetBody_Banquet")]
    public class ApplySheetBodyBanquet : ActiveRecordBase
    {
        
        private int _applySheetBodyBanquetPk;
        
        private int _applySheetHeadPk;
        
        private System.DateTime _dateFrom;
        
        private System.DateTime _dateTo;
        
        private string _callinCompany;
        
        private string _callinPerson;
        
        private string _callinMemo;
        
        private string _inviteDept;
        
        private string _invitePerson;
        
        private string _invietDeptInfo;
        
        private string _relationDept;
        
        private string _talkplace;
        
        private int _needTea;
        
        private int _lookFactory;
        
        private int _numofvisit;
        
        private int _lunch;
        
        private string _other;
        
        private int _carplan;
        
        private string _especialRequest;
        
        [PrimaryKey(PrimaryKeyType.Native, "ApplySheetBody_Banquet_pk")]
        public int ApplySheetBodyBanquetPk
        {
            get
            {
                return this._applySheetBodyBanquetPk;
            }
            set
            {
                this._applySheetBodyBanquetPk = value;
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
        public string CallinCompany
        {
            get
            {
                return this._callinCompany;
            }
            set
            {
                this._callinCompany = value;
            }
        }
        
        [Property()]
        public string CallinPerson
        {
            get
            {
                return this._callinPerson;
            }
            set
            {
                this._callinPerson = value;
            }
        }
        
        [Property()]
        public string CallinMemo
        {
            get
            {
                return this._callinMemo;
            }
            set
            {
                this._callinMemo = value;
            }
        }
        
        [Property()]
        public string InviteDept
        {
            get
            {
                return this._inviteDept;
            }
            set
            {
                this._inviteDept = value;
            }
        }
        
        [Property()]
        public string InvitePerson
        {
            get
            {
                return this._invitePerson;
            }
            set
            {
                this._invitePerson = value;
            }
        }
        
        [Property()]
        public string InvietDeptInfo
        {
            get
            {
                return this._invietDeptInfo;
            }
            set
            {
                this._invietDeptInfo = value;
            }
        }
        
        [Property()]
        public string RelationDept
        {
            get
            {
                return this._relationDept;
            }
            set
            {
                this._relationDept = value;
            }
        }
        
        [Property()]
        public string Talkplace
        {
            get
            {
                return this._talkplace;
            }
            set
            {
                this._talkplace = value;
            }
        }
        
        [Property()]
        public int NeedTea
        {
            get
            {
                return this._needTea;
            }
            set
            {
                this._needTea = value;
            }
        }
        
        [Property()]
        public int LookFactory
        {
            get
            {
                return this._lookFactory;
            }
            set
            {
                this._lookFactory = value;
            }
        }
        
        [Property()]
        public int Numofvisit
        {
            get
            {
                return this._numofvisit;
            }
            set
            {
                this._numofvisit = value;
            }
        }
        
        [Property()]
        public int Lunch
        {
            get
            {
                return this._lunch;
            }
            set
            {
                this._lunch = value;
            }
        }
        
        [Property()]
        public string Other
        {
            get
            {
                return this._other;
            }
            set
            {
                this._other = value;
            }
        }
        
        [Property()]
        public int Carplan
        {
            get
            {
                return this._carplan;
            }
            set
            {
                this._carplan = value;
            }
        }
        
        [Property()]
        public string EspecialRequest
        {
            get
            {
                return this._especialRequest;
            }
            set
            {
                this._especialRequest = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(ApplySheetBodyBanquet));
        }
        
        public static ApplySheetBodyBanquet[] FindAll()
        {
            return ((ApplySheetBodyBanquet[])(ActiveRecordBase.FindAll(typeof(ApplySheetBodyBanquet))));
        }
        
        public static ApplySheetBodyBanquet Find(int ApplySheetBodyBanquetPk)
        {
            return ((ApplySheetBodyBanquet)(ActiveRecordBase.FindByPrimaryKey(typeof(ApplySheetBodyBanquet), ApplySheetBodyBanquetPk,false)));
        }

		public static ApplySheetBodyBanquet FindByApplyHeadPk(int ApplyHeadPk)
		{
			SimpleQuery query=new SimpleQuery(typeof(ApplySheetBodyBanquet),@"from ApplySheetBodyBanquet o where o.ApplySheetHeadPk=? ",ApplyHeadPk);
			ApplySheetBodyBanquet[] Values=(ApplySheetBodyBanquet[]) ExecuteQuery(query);
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
