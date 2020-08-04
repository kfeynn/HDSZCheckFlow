// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("Base_Dept")]
    public class BaseDept : ActiveRecordBase
    {
        
        private int _deptPk;
        
        private string _deptName;
        
        private string _deptCode;
        
        private string _superiorDeptPk;
        
        private string _budgetDeptCode; 

		private int _dr;
        
        [PrimaryKey(PrimaryKeyType.Native, "Dept_pk")]
        public int DeptPk
        {
            get
            {
                return this._deptPk;
            }
            set
            {
                this._deptPk = value;
            }
        }
        
        [Property()]
        public string DeptName
        {
            get
            {
                return this._deptName;
            }
            set
            {
                this._deptName = value;
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
        
        [Property(Column="superior_Dept_pk")]
        public string SuperiorDeptPk
        {
            get
            {
                return this._superiorDeptPk;
            }
            set
            {
                this._superiorDeptPk = value;
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


		[Property(Column="DR")]
		public int Dr
		{
			get
			{
				return this._dr;
			}
			set
			{
				this._dr = value;
			}
		}
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(BaseDept));
        }
        
        public static BaseDept[] FindAll()
        {
            return ((BaseDept[])(ActiveRecordBase.FindAll(typeof(BaseDept))));
        }
        
        public static BaseDept Find(int DeptPk)
        {
            return ((BaseDept)(ActiveRecordBase.FindByPrimaryKey(typeof(BaseDept), DeptPk,false)));
        }

		public static BaseDept FindByDeptCode(string DeptCode)
		{
			SimpleQuery query=new SimpleQuery(typeof(BaseDept),@"from BaseDept o where o.DeptCode=?",DeptCode);
			BaseDept[] depts=(BaseDept[])ExecuteQuery(query);
			if(depts!=null && depts.Length>0)
			{
				return depts[0];
			}
			else
			{
				return null;
			}
		}
 
		public static BaseDept FindByBudgetDeptCode(string BudgetDeptCode)
		{
			SimpleQuery query=new SimpleQuery(typeof(BaseDept),@"from BaseDept o where o.BudgetDeptCode=?",BudgetDeptCode);
			BaseDept[] depts=(BaseDept[])ExecuteQuery(query);
			if(depts!=null && depts.Length>0)
			{
				return depts[0];
			}
			else
			{
				return null;
			}
		}


		//根据SuperiorDeptPk 来查询 2011-12-05 liyang(查相应部门下的所有科)
		public static BaseDept[] FindByBudgetSuperiorDeptPk(string SuperiorDeptPk)
		{
			SimpleQuery query=new SimpleQuery(typeof(BaseDept),@"from BaseDept o where o.SuperiorDeptPk=?",SuperiorDeptPk);
			BaseDept[] depts=(BaseDept[])ExecuteQuery(query);
			if(depts!=null && depts.Length>0)
			{
				return depts;
			}
			else
			{
				return null;
			}
		}

    }
}
