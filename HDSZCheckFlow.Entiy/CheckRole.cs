// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
    
    
    [ActiveRecord("CheckRole")]
    public class CheckRole : ActiveRecordBase
    {
        
        private string _checkRoleCode;
        
        private string _checkRoleName;
        
        private string _checkRoleDept;
        
        [PrimaryKey(PrimaryKeyType.Native)]
        public string CheckRoleCode
        {
            get
            {
                return this._checkRoleCode;
            }
            set
            {
                this._checkRoleCode = value;
            }
        }
        
        [Property()]
        public string CheckRoleName
        {
            get
            {
                return this._checkRoleName;
            }
            set
            {
                this._checkRoleName = value;
            }
        }
        
        [Property()]
        public string CheckRoleDept
        {
            get
            {
                return this._checkRoleDept;
            }
            set
            {
                this._checkRoleDept = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(CheckRole));
        }
        
        public static CheckRole[] FindAll()
        {
            return ((CheckRole[])(ActiveRecordBase.FindAll(typeof(CheckRole))));
        }
        
        public static CheckRole Find(string CheckRoleCode)
        {
            return ((CheckRole)(ActiveRecordBase.FindByPrimaryKey(typeof(CheckRole), CheckRoleCode,false)));
        }
    }
}