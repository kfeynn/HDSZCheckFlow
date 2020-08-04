// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
    
    
    [ActiveRecord("Base_Person")]
    public class BasePerson : ActiveRecordBase
    {
        
        private string _personCode;
        
        private string _name;
        
        private string _deptCode;
        
        private string _rank;
        
        [PrimaryKey(PrimaryKeyType.Native)]
        public string PersonCode
        {
            get
            {
                return this._personCode;
            }
            set
            {
                this._personCode = value;
            }
        }
        
        [Property()]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
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
        public string Rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(BasePerson));
        }
        
        public static BasePerson[] FindAll()
        {
            return ((BasePerson[])(ActiveRecordBase.FindAll(typeof(BasePerson))));
        }
        
        public static BasePerson Find(string PersonCode)
        {
            return ((BasePerson)(ActiveRecordBase.FindByPrimaryKey(typeof(BasePerson), PersonCode,false)));
        }
    }
}