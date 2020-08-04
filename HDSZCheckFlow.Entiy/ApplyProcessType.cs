// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
    
    
    [ActiveRecord("ApplyProcessType")]
    public class ApplyProcessType : ActiveRecordBase
    {
        
        private string _applyProcessTypeCode;
        
        private string _applyProcessTypeName;
        
        private int _isSubmit;
        
        private int _isCheck;
        
        private int _isFinishInDept;
        
        private int _isFinishInCompany;
        
        private int _isDisallow;
        
        private int _isSubmitAgain;
        
        [PrimaryKey(PrimaryKeyType.Native)]
        public string ApplyProcessTypeCode
        {
            get
            {
                return this._applyProcessTypeCode;
            }
            set
            {
                this._applyProcessTypeCode = value;
            }
        }
        
        [Property()]
        public string ApplyProcessTypeName
        {
            get
            {
                return this._applyProcessTypeName;
            }
            set
            {
                this._applyProcessTypeName = value;
            }
        }
        
        [Property()]
        public int IsSubmit
        {
            get
            {
                return this._isSubmit;
            }
            set
            {
                this._isSubmit = value;
            }
        }
        
        [Property()]
        public int IsCheck
        {
            get
            {
                return this._isCheck;
            }
            set
            {
                this._isCheck = value;
            }
        }
        
        [Property()]
        public int IsFinishInDept
        {
            get
            {
                return this._isFinishInDept;
            }
            set
            {
                this._isFinishInDept = value;
            }
        }
        
        [Property()]
        public int IsFinishInCompany
        {
            get
            {
                return this._isFinishInCompany;
            }
            set
            {
                this._isFinishInCompany = value;
            }
        }
        
        [Property()]
        public int IsDisallow
        {
            get
            {
                return this._isDisallow;
            }
            set
            {
                this._isDisallow = value;
            }
        }
        
        [Property()]
        public int IsSubmitAgain
        {
            get
            {
                return this._isSubmitAgain;
            }
            set
            {
                this._isSubmitAgain = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(ApplyProcessType));
        }
        
        public static ApplyProcessType[] FindAll()
        {
            return ((ApplyProcessType[])(ActiveRecordBase.FindAll(typeof(ApplyProcessType))));
        }
        
        public static ApplyProcessType Find(string ApplyProcessTypeCode)
        {
            return ((ApplyProcessType)(ActiveRecordBase.FindByPrimaryKey(typeof(ApplyProcessType), ApplyProcessTypeCode,false)));
        }
    }
}