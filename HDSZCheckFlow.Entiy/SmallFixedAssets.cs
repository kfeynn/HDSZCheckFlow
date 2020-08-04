using System;

namespace HDSZCheckFlow.Entiy
{
	using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
	[ActiveRecord("SmallFixedAssets")]
	public class SmallFixedAsset : ActiveRecordBase
	{
    
		private int _iD;
    
		private string _invSheetId;
    
		private string _vbillcode;
    
		private string _cinventoryid;
    
		private string _dbizdate;
    
		private string _noutnum;
    
		private string _ninnum;
    
		private string _cwarehouseid;
    
		private string _cdispatcherid;
    
		private string _cdptid;
    
		private string _ccustomerid;
    
		private string _coperatorid;
    
		private int _period;
    
		private int _retireNum;
    
		private string _price;
    
		private string _currTypeCode;
    
		private int _isRetire;
    
		private string _retireDate;
    
		private string _reMark;
    
		private string _invManageCode;
    
		private string _deptClassCode;
    
		private string _deptCode;
    
		private string _keeperCode;
    
		private string _storage;
    
		private int _iNum;
    
		private string _invname;
    
		[PrimaryKey(PrimaryKeyType.Native)]
		public int ID
		{
			get
			{
				return this._iD;
			}
			set
			{
				this._iD = value;
			}
		}
    
		[Property()]
		public string InvSheetId
		{
			get
			{
				return this._invSheetId;
			}
			set
			{
				this._invSheetId = value;
			}
		}
    
		[Property()]
		public string Vbillcode
		{
			get
			{
				return this._vbillcode;
			}
			set
			{
				this._vbillcode = value;
			}
		}
    
		[Property()]
		public string Cinventoryid
		{
			get
			{
				return this._cinventoryid;
			}
			set
			{
				this._cinventoryid = value;
			}
		}
    
		[Property()]
		public string Dbizdate
		{
			get
			{
				return this._dbizdate;
			}
			set
			{
				this._dbizdate = value;
			}
		}
    
		[Property()]
		public string Noutnum
		{
			get
			{
				return this._noutnum;
			}
			set
			{
				this._noutnum = value;
			}
		}
    
		[Property()]
		public string Ninnum
		{
			get
			{
				return this._ninnum;
			}
			set
			{
				this._ninnum = value;
			}
		}
    
		[Property()]
		public string Cwarehouseid
		{
			get
			{
				return this._cwarehouseid;
			}
			set
			{
				this._cwarehouseid = value;
			}
		}
    
		[Property()]
		public string Cdispatcherid
		{
			get
			{
				return this._cdispatcherid;
			}
			set
			{
				this._cdispatcherid = value;
			}
		}
    
		[Property()]
		public string Cdptid
		{
			get
			{
				return this._cdptid;
			}
			set
			{
				this._cdptid = value;
			}
		}
    
		[Property()]
		public string Ccustomerid
		{
			get
			{
				return this._ccustomerid;
			}
			set
			{
				this._ccustomerid = value;
			}
		}
    
		[Property()]
		public string Coperatorid
		{
			get
			{
				return this._coperatorid;
			}
			set
			{
				this._coperatorid = value;
			}
		}
    
		[Property()]
		public int Period
		{
			get
			{
				return this._period;
			}
			set
			{
				this._period = value;
			}
		}
    
		[Property()]
		public int RetireNum
		{
			get
			{
				return this._retireNum;
			}
			set
			{
				this._retireNum = value;
			}
		}
    
		[Property()]
		public string Price
		{
			get
			{
				return this._price;
			}
			set
			{
				this._price = value;
			}
		}
    
		[Property()]
		public string CurrTypeCode
		{
			get
			{
				return this._currTypeCode;
			}
			set
			{
				this._currTypeCode = value;
			}
		}
    
		[Property()]
		public int IsRetire
		{
			get
			{
				return this._isRetire;
			}
			set
			{
				this._isRetire = value;
			}
		}
    
		[Property()]
		public string RetireDate
		{
			get
			{
				return this._retireDate;
			}
			set
			{
				this._retireDate = value;
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
		public string InvManageCode
		{
			get
			{
				return this._invManageCode;
			}
			set
			{
				this._invManageCode = value;
			}
		}
    
		[Property()]
		public string DeptClassCode
		{
			get
			{
				return this._deptClassCode;
			}
			set
			{
				this._deptClassCode = value;
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
		public string KeeperCode
		{
			get
			{
				return this._keeperCode;
			}
			set
			{
				this._keeperCode = value;
			}
		}
    
		[Property()]
		public string Storage
		{
			get
			{
				return this._storage;
			}
			set
			{
				this._storage = value;
			}
		}
    
		[Property()]
		public int INum
		{
			get
			{
				return this._iNum;
			}
			set
			{
				this._iNum = value;
			}
		}
    
		[Property()]
		public string Invname
		{
			get
			{
				return this._invname;
			}
			set
			{
				this._invname = value;
			}
		}
    
    
		public static void DeleteAll()
		{
			ActiveRecordBase.DeleteAll(typeof(SmallFixedAsset));
		}
    
		public static SmallFixedAsset[] FindAll()
		{
			return ((SmallFixedAsset[])(ActiveRecordBase.FindAll(typeof(SmallFixedAsset))));
		}
    
		public static SmallFixedAsset Find(int ID)
		{
			return ((SmallFixedAsset)(ActiveRecordBase.FindByPrimaryKey(typeof(SmallFixedAsset), ID,false)));
		}
	}

}
