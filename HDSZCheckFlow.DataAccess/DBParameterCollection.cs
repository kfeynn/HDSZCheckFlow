// ================================================================================
// 		File: DBParameterCollection.cs
// 		Desc: 数据库访问参数容器类
//			　封装
// 		Called by:   
//               
// 		Auth: Andy Lee
// 		Date: 2007-04-25
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//    
// ================================================================================
// Copyright (C) 2007 FCKJ Corporation
// ================================================================================

using System;
using System.Collections;
using System.Data;

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// 存储过程参数的集合类。
	/// </summary>
	public class DBParameterCollection:System.Collections.Specialized.NameObjectCollectionBase,IEnumerable
	{
		/// <summary>
		/// 构造函数。
		/// </summary>
		public DBParameterCollection()
		{	
			
		}		
		
		/// <summary>
		/// 存储过程参数类索引器。
		/// </summary>
		public IDbDataParameter this[ int index ]  
		{
			get  
			{
				return ((IDbDataParameter)base.BaseGet(index));				
			}
			set  
			{
				base.BaseSet(index,value);
			}			
		}	

		/// <summary>
		/// 存储过程参数类索引器。
		/// </summary>
		public IDbDataParameter this[ string parameterName ]  
		{
			get  
			{
				return ((IDbDataParameter)base.BaseGet(parameterName));				
			}
			set  
			{
				base.BaseSet(parameterName,value);				
			}			
		}
	
		/// <summary>
		/// 获取所有的 IDbDataParameter 的数组。
		/// </summary>
		public IDbDataParameter[] AllValues
		{
			get
			{
				return (IDbDataParameter[]) base.BaseGetAllValues(typeof(IDbDataParameter));				
			}
		}

		/// <summary>
		/// 获取所有的参数的名称的数组。
		/// </summary>
		public string[] AllKeys
		{
			get
			{
				return base.BaseGetAllKeys();
			}
		}

		/// <summary>
		/// 添加参数到容器。
		/// </summary>
		/// <param name="value">添加到容器中的参数。</param>
		/// <returns>添加的参数在容器中的索引值。</returns>
		public void Add( IDbDataParameter value)  
		{
			if (value!=null)
			{				
				base.BaseAdd(value.ParameterName,value);				
			}
		}
		
		/// <summary>
		/// 从容器中移除特定的参数。
		/// </summary>
		/// <param name="value">要移除的参数。</param>
		public void Remove( IDbDataParameter value )  
		{			
			if (value!=null)
			{
				Remove(value.ParameterName);
			}
		}

		/// <summary>
		/// 从容器中移除特定的参数。
		/// </summary>
		/// <param name="parameterName">要移除的参数的名称。</param>
		public void Remove( string parameterName)  
		{			
			base.BaseRemove(parameterName);
		}

		/// <summary>
		/// 容器中是否包含特定的值。
		/// </summary>
		/// <param name="value">检测容器中是否存在的参。</param>
		/// <returns>如果容器中包含则返回true，否则返回false。</returns>		
		public bool Contains( IDbDataParameter value )  
		{			
			if (value!=null)
			{
				return( Contains(value.ParameterName));
			} 			
			return false;			
		}	
	
		/// <summary>
		/// 容器中是否包含特定的值。
		/// </summary>
		/// <param name="parameterName">检测容器中是否存在的参数名称。</param>
		/// <returns>如果容器中包含则返回true，否则返回false。</returns>		
		public bool Contains( string parameterName )  
		{			
			return (base.BaseGet(parameterName)!=null);
		}	
	
		/// <summary>
		/// 返回两个指定DBParameterCollection对象的并集。。
		/// </summary>
		/// <param name="a">一个DBParameterCollection对象。</param>
		/// <param name="b">一个DBParameterCollection对象。</param>
		/// <returns>a和b的并集，按照a、b的顺序。</returns>
		public static DBParameterCollection operator +(DBParameterCollection a,DBParameterCollection b)
		{
			if (b==null || b.Count==0)
			{
				return a;
			}
			foreach( IDbDataParameter param in b)
			{
				if (!a.Contains(param))
				{
					a.Add(param);
					b.Remove(param);
				}
			}
			return a;
		}

		/// <summary>
		/// 集合中是否包含IDbDataParameter对象。
		/// </summary>
		public bool IsEmpty
		{
			get
			{
				return BaseHasKeys();		
			}
		}
		#region IEnumerable 成员

		/// <summary>
		/// 返回可循环访问 DBParameterCollection 的枚举数。
		/// </summary>
		/// <returns>用于 DBParameterCollection 实例的 IEnumerator。</returns>
		public new IEnumerator GetEnumerator()
		{
			return AllValues.GetEnumerator();
		}

		#endregion
		 
		/// <summary>
		/// 转换为IDbDataParameter 数组形式。
		/// </summary>
		/// <param name="parameterCollection">要转化的DBParameterCollection 参数集合。</param>
		/// <returns>转化后的IDbDataParameter数组对象。</returns>
		public static implicit operator IDbDataParameter[](DBParameterCollection parameterCollection)
		{			
			if (parameterCollection	==null)
			{
				return new IDbDataParameter[0];
			} 
			else
			{
				return parameterCollection.AllValues;
			}
		}	
	}
}
