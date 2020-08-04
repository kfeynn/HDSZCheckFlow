// 
// Generated by ActiveRecord Generator
// 
//
namespace HDSZCheckFlow.Entiy
{
    using Castle.ActiveRecord;
	using Castle.ActiveRecord.Queries;
    
    
    [ActiveRecord("Base_CommonRelation")]
    public class BaseCommonRelation : ActiveRecordBase
    {
        
        private int _iD;
        
        private string _sunCode;
        
        private string _fatherCode;
        
        private string _type;
        
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
        public string SunCode
        {
            get
            {
                return this._sunCode;
            }
            set
            {
                this._sunCode = value;
            }
        }
        
        [Property()]
        public string FatherCode
        {
            get
            {
                return this._fatherCode;
            }
            set
            {
                this._fatherCode = value;
            }
        }
        
        [Property()]
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
        
        public static void DeleteAll()
        {
            ActiveRecordBase.DeleteAll(typeof(BaseCommonRelation));
        }
        
        public static BaseCommonRelation[] FindAll()
        {
            return ((BaseCommonRelation[])(ActiveRecordBase.FindAll(typeof(BaseCommonRelation))));
        }
        
        public static BaseCommonRelation Find(int ID)
        {
            return ((BaseCommonRelation)(ActiveRecordBase.FindByPrimaryKey(typeof(BaseCommonRelation), ID,false)));
        }
		
		public static BaseCommonRelation[] FindBySunAndFatherCode(string sunCode,string fatherCode)
		{
			SimpleQuery query=new SimpleQuery(typeof(BaseCommonRelation),@"from BaseCommonRelation o where left(o.SunCode,4)=? and  o.Type ='secendstep'  and o.FatherCode=?",sunCode,fatherCode);
			BaseCommonRelation[] baseCommonRelation=(BaseCommonRelation[])ExecuteQuery(query);
			return baseCommonRelation;
		}
    }
}
