// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("ApplyTypeInCheckFlow")]
    public class ApplyTypeInCheckFlow : ActiveRecordBase
    {
        
        private int _applyTypeInCheckFlowPk;
        
        private string _applyTypeCode;
        
        private int _checkFlowInCompanyHeadPk;
        
        private System.Decimal _sheetMinMoney;
        
        private System.Decimal _sheetMaxMoney;
        
        private string _sheetCondition;

		private int _checkType;

		private int _isInfinite;

		private string _deptCode;

		private string _baseDecisionDeptCodes;
        
        [PrimaryKey(PrimaryKeyType.Native, "ApplyTypeInCheckFlow_pk")]
        public int ApplyTypeInCheckFlowPk
        {
            get
            {
                return this._applyTypeInCheckFlowPk;
            }
            set
            {
                this._applyTypeInCheckFlowPk = value;
            }
        }
        
        [Property()]
        public string ApplyTypeCode
        {
            get
            {
                return this._applyTypeCode;
            }
            set
            {
                this._applyTypeCode = value;
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
        
        [Property(Column="Sheet_MinMoney")]
        public System.Decimal SheetMinMoney
        {
            get
            {
                return this._sheetMinMoney;
            }
            set
            {
                this._sheetMinMoney = value;
            }
        }
        
        [Property(Column="Sheet_MaxMoney")]
        public System.Decimal SheetMaxMoney
        {
            get
            {
                return this._sheetMaxMoney;
            }
            set
            {
                this._sheetMaxMoney = value;
            }
        }
        
        [Property(Column="Sheet_Condition")]
        public string SheetCondition
        {
            get
            {
                return this._sheetCondition;
            }
            set
            {
                this._sheetCondition = value;
            }
        }

		[Property()]
		public int CheckType
		{
			get
			{
				return this._checkType;
			}
			set
			{
				this._checkType = value;
			}
		}

		[Property()]
		public int IsInfinite
		{
			get
			{
				return this._isInfinite;
			}
			set
			{
				this._isInfinite = value;
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
	
		[Property(Column="Base_decisionDept_codes")]
		public string BaseDecisionDeptCodes
		{
			get
			{
				return this._baseDecisionDeptCodes;
			}
			set
			{
				this._baseDecisionDeptCodes = value;
			}
		}
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(ApplyTypeInCheckFlow));
        }
        
        public static ApplyTypeInCheckFlow[] FindAll()
        {
            return ((ApplyTypeInCheckFlow[])(ActiveRecordBase.FindAll(typeof(ApplyTypeInCheckFlow))));
        }
        
        public static ApplyTypeInCheckFlow Find(int ApplyTypeInCheckFlowPk)
        {
            return ((ApplyTypeInCheckFlow)(ActiveRecordBase.FindByPrimaryKey(typeof(ApplyTypeInCheckFlow), ApplyTypeInCheckFlowPk,false)));
        }

		public static int  SelectCountByApplyTypeCode(string ApplyTypeCode)
		{
			int returnValue=0;
			ScalarQuery query=new ScalarQuery(typeof(ApplyTypeInCheckFlow),@"select count(*) from ApplyTypeInCheckFlow o where o.ApplyTypeCode=?",ApplyTypeCode);
			returnValue=(int)ExecuteQuery(query);
			return returnValue;
		}

		/// <summary>
		/// ������������
		/// </summary>
		/// <param name="ApplyTypeCode">��������</param>
		/// <param name="CheckType">�ύ����</param>
		/// <param name="Money">���</param>
		/// <param name="deptCode">����</param>
		/// <returns></returns>
		public static ApplyTypeInCheckFlow FindByCodeAndType(string ApplyTypeCode,int CheckType,decimal Money,string deptCode)
		{
			SimpleQuery query=new SimpleQuery(typeof(ApplyTypeInCheckFlow),@"from ApplyTypeInCheckFlow o where o.DeptCode = ?  and  o.ApplyTypeCode=? and o.CheckType=?  and ((?>=o.SheetMinMoney and ?<o.SheetMaxMoney ) or ( ?>=o.SheetMinMoney and o.IsInfinite=1))",deptCode,ApplyTypeCode,CheckType,Money,Money,Money);
			ApplyTypeInCheckFlow[] TypeInCheckFlows=(ApplyTypeInCheckFlow[])ExecuteQuery(query);
			if(TypeInCheckFlows!=null && TypeInCheckFlows.Length>0)
			{
				return TypeInCheckFlows[0];
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ������������
		/// </summary>
		/// <param name="ApplyTypeCode">��������</param>
		/// <param name="CheckType">�ύ����</param>
		/// <param name="Money">���</param>
		/// <param name="deptCode">����</param>
		/// <param name="deptCode">���鲿�� 1 �� 1��2 </param>
		/// <returns></returns>
		public static ApplyTypeInCheckFlow FindAssetByCodeAndType(string ApplyTypeCode,int CheckType,decimal Money,string deptCode,string DecisionDept)
		{
			SimpleQuery query=new SimpleQuery(typeof(ApplyTypeInCheckFlow),@"from ApplyTypeInCheckFlow o where o.DeptCode = ?  and  o.ApplyTypeCode=? and o.CheckType=? and o.BaseDecisionDeptCodes = ?  and ((?>=o.SheetMinMoney and ?<o.SheetMaxMoney ) or ( ?>=o.SheetMinMoney and o.IsInfinite=1))",deptCode,ApplyTypeCode,CheckType,DecisionDept,Money,Money,Money);
			ApplyTypeInCheckFlow[] TypeInCheckFlows=(ApplyTypeInCheckFlow[])ExecuteQuery(query);
			if(TypeInCheckFlows!=null && TypeInCheckFlows.Length>0)
			{
				return TypeInCheckFlows[0];
			}
			else
			{
				return null;
			}
		}




    }
}