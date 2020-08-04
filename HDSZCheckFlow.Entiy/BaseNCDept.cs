// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
    
    
    [ActiveRecord("Base_NC_Dept")]
    public class BaseNCDept : ActiveRecordBase
    {
        
        private string _nCDeptPk;
        
        private string _nCDeptCode;
        
        private string _nCDeptName;
        
        private string _nCsuperiorDeptPk;
        
        private string _budgetDeptCode;
        
        [PrimaryKey(PrimaryKeyType.Native, "NC_Dept_pk")]
        public string NCDeptPk
        {
            get
            {
                return this._nCDeptPk;
            }
            set
            {
                this._nCDeptPk = value;
            }
        }
        
        [Property(Column="NC_DeptCode")]
        public string NCDeptCode
        {
            get
            {
                return this._nCDeptCode;
            }
            set
            {
                this._nCDeptCode = value;
            }
        }
        
        [Property(Column="NC_DeptName")]
        public string NCDeptName
        {
            get
            {
                return this._nCDeptName;
            }
            set
            {
                this._nCDeptName = value;
            }
        }
        
        [Property(Column="NC_superior_Dept_pk")]
        public string NCsuperiorDeptPk
        {
            get
            {
                return this._nCsuperiorDeptPk;
            }
            set
            {
                this._nCsuperiorDeptPk = value;
            }
        }
        
        [Property(Column="budget_DeptCode")]
        public string BudgetDeptCode
        {
            get
            {
                return this._budgetDeptCode;
            }
            set
            {
                this._budgetDeptCode = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(BaseNCDept));
        }

        public static BaseNCDept[] FindAll()
        {
            return ((BaseNCDept[])(ActiveRecordBase.FindAll(typeof(BaseNCDept))));
        }
        
        public static BaseNCDept Find(string NCDeptPk)
        {
            return ((BaseNCDept)(ActiveRecordBase.FindByPrimaryKey(typeof(BaseNCDept), NCDeptPk)));
        }
    }
}
