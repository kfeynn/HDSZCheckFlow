using System;
using NHibernate.Type;

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// ParamInfo 的摘要说明。
	/// </summary>
	public class ParamInfo 
	{
		private string name; // 参数名称
		private object value; // 参数值
		private IType type; // 参数类型
		public ParamInfo( string name, object value, IType type ) 
		{
			this.name = name;
			this.value = value;
			this.type = type;
		} 
		public string Name 
		{
			get { return name; }
		} 
		public object Value 
		{
			get { return value; }
		} 
		public IType Type 
		{
			get { return type; }
		} 
	} 
}
