// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("Asset_FinallyPriceCheck")]
    public class AssetFinallyPriceCheck : ActiveRecordBase
    {
        
        private int _id;
        
        private int _applySheetHeadPk;
        
        private string _priceCheckSheetNo;
        
        private string _itemName;
        
        private string _applyDeptClassCode;
        
        private string _applyDeptCode;
        
        private string _applyPersonCode;

		private System.DateTime _makeDate;
        
        private string _requestDate;
        
        private string _bargainNo;
		    
		private string _payForArticle;
    
		private string _reMark;

		private string _applyProcessCode;
    
		private int _isCheckInCompany;
    
		private string _currentCheckRole;
    
		private int _checkFlowInCompanyHeadPk;
    
		private int _checkSetp;

		private string _tradeAgreement;

		private string _checkDept;
        
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
        public string PriceCheckSheetNo
        {
            get
            {
                return this._priceCheckSheetNo;
            }
            set
            {
                this._priceCheckSheetNo = value;
            }
        }
        
        [Property()]
        public string ItemName
        {
            get
            {
                return this._itemName;
            }
            set
            {
                this._itemName = value;
            }
        }
        
        [Property()]
        public string ApplyDeptClassCode
        {
            get
            {
                return this._applyDeptClassCode;
            }
            set
            {
                this._applyDeptClassCode = value;
            }
        }
        
        [Property()]
        public string ApplyDeptCode
        {
            get
            {
                return this._applyDeptCode;
            }
            set
            {
                this._applyDeptCode = value;
            }
        }
        
        [Property()]
        public string ApplyPersonCode
        {
            get
            {
                return this._applyPersonCode;
            }
            set
            {
                this._applyPersonCode = value;
            }
        }

		[Property()]
		public System.DateTime MakeDate
		{
			get
			{
				return this._makeDate;
			}
			set
			{
				this._makeDate = value;
			}
		}

        
        [Property()]
        public string RequestDate
        {
            get
            {
                return this._requestDate;
            }
            set
            {
                this._requestDate = value;
            }
        }
        
        [Property()]
        public string BargainNo
        {
            get
            {
                return this._bargainNo;
            }
            set
            {
                this._bargainNo = value;
            }
        }

		[Property()]
		public string PayForArticle
		{
			get
			{
				return this._payForArticle;
			}
			set
			{
				this._payForArticle = value;
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

		    
		[Property()]
		public string ApplyProcessCode
		{
			get
			{
				return this._applyProcessCode;
			}
			set
			{
				this._applyProcessCode = value;
			}
		}
    
		[Property()]
		public int IsCheckInCompany
		{
			get
			{
				return this._isCheckInCompany;
			}
			set
			{
				this._isCheckInCompany = value;
			}
		}
    
		[Property()]
		public string CurrentCheckRole
		{
			get
			{
				return this._currentCheckRole;
			}
			set
			{
				this._currentCheckRole = value;
			}
		}
    
		[Property(Column="CheckFlowInCompany_Head_pk")]
		public int CheckFlowInCompanyHeadPk
		{
			get
			{
				return this._checkFlowInCompanyHeadPk;
			}
			set
			{
				this._checkFlowInCompanyHeadPk = value;
			}
		}
    
		[Property()]
		public int CheckSetp
		{
			get
			{
				return this._checkSetp;
			}
			set
			{
				this._checkSetp = value;
			}
		}

		[Property()]
		public string TradeAgreement
		{
			get
			{
				return this._tradeAgreement;
			}
			set
			{
				this._tradeAgreement = value;
			}
		}

		[Property()]
		public string CheckDept
		{
			get
			{
				return this._checkDept;
			}
			set
			{
				this._checkDept = value;
			}
		}

        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(AssetFinallyPriceCheck));
        }
        
        public static AssetFinallyPriceCheck[] FindAll()
        {
            return ((AssetFinallyPriceCheck[])(ActiveRecordBase.FindAll(typeof(AssetFinallyPriceCheck))));
        }
        
        public static AssetFinallyPriceCheck Find(int Id)
        {
            return ((AssetFinallyPriceCheck)(ActiveRecordBase.FindByPrimaryKey(typeof(AssetFinallyPriceCheck), Id,false)));
        }

		//根据 年份，预算部门，项目找对应预算。
		public static AssetFinallyPriceCheck FindByApplyHeadKey(int ApplyHeadKey)
		{
			SimpleQuery query=new SimpleQuery(typeof(AssetFinallyPriceCheck),@"from AssetFinallyPriceCheck o where o.ApplySheetHeadPk= ? ",ApplyHeadKey);
			AssetFinallyPriceCheck []AssetFinallyPriceCheckS = (AssetFinallyPriceCheck[])ExecuteQuery(query); 
			if(AssetFinallyPriceCheckS!=null && AssetFinallyPriceCheckS.Length>0)
			{
				return AssetFinallyPriceCheckS[0];
			}
			else
			{
				return null;
			}
		}
    }
}
