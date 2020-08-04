using System;

namespace HDSZCheckFlow.Entiy
{

	using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;

	/// <summary>
	/// SmallFixedAssetsChange 的摘要说明。
	/// </summary>
	[ActiveRecord("SmallFixedAssetsChange")]
	public class SmallFixedAssetsChange : ActiveRecordBase
	{
    
		private int _id;
    
		private int _smallFixedAssetsId;
    
		private string _bApplyDeptClassCode;
    
		private string _bApplyDeptCode;
    
		private string _aApplyDeptClassCode;
    
		private string _aApplyDeptCode;
    
		private System.DateTime _datetime;
    
		private string _reMark;
    
		private string _importerCode;
    
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
    
		[Property(Column="SmallFixedAssets_Id")]
		public int SmallFixedAssetsId
		{
			get
			{
				return this._smallFixedAssetsId;
			}
			set
			{
				this._smallFixedAssetsId = value;
			}
		}
    
		[Property()]
		public string BApplyDeptClassCode
		{
			get
			{
				return this._bApplyDeptClassCode;
			}
			set
			{
				this._bApplyDeptClassCode = value;
			}
		}
    
		[Property()]
		public string BApplyDeptCode
		{
			get
			{
				return this._bApplyDeptCode;
			}
			set
			{
				this._bApplyDeptCode = value;
			}
		}
    
		[Property()]
		public string AApplyDeptClassCode
		{
			get
			{
				return this._aApplyDeptClassCode;
			}
			set
			{
				this._aApplyDeptClassCode = value;
			}
		}
    
		[Property()]
		public string AApplyDeptCode
		{
			get
			{
				return this._aApplyDeptCode;
			}
			set
			{
				this._aApplyDeptCode = value;
			}
		}
    
		[Property()]
		public System.DateTime Datetime
		{
			get
			{
				return this._datetime;
			}
			set
			{
				this._datetime = value;
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
		public string ImporterCode
		{
			get
			{
				return this._importerCode;
			}
			set
			{
				this._importerCode = value;
			}
		}

    
		public static void DeleteAll()
		{
			ActiveRecordBase.DeleteAll(typeof(SmallFixedAssetsChange));
		}
    
		public static SmallFixedAssetsChange[] FindAll()
		{
			return ((SmallFixedAssetsChange[])(ActiveRecordBase.FindAll(typeof(SmallFixedAssetsChange))));
		}
    
		public static SmallFixedAssetsChange Find(int Id)
		{
			return ((SmallFixedAssetsChange)(ActiveRecordBase.FindByPrimaryKey(typeof(SmallFixedAssetsChange), Id,false)));
		}
	}

}
