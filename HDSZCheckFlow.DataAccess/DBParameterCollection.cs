// ================================================================================
// 		File: DBParameterCollection.cs
// 		Desc: ���ݿ���ʲ���������
//			����װ
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
	/// �洢���̲����ļ����ࡣ
	/// </summary>
	public class DBParameterCollection:System.Collections.Specialized.NameObjectCollectionBase,IEnumerable
	{
		/// <summary>
		/// ���캯����
		/// </summary>
		public DBParameterCollection()
		{	
			
		}		
		
		/// <summary>
		/// �洢���̲�������������
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
		/// �洢���̲�������������
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
		/// ��ȡ���е� IDbDataParameter �����顣
		/// </summary>
		public IDbDataParameter[] AllValues
		{
			get
			{
				return (IDbDataParameter[]) base.BaseGetAllValues(typeof(IDbDataParameter));				
			}
		}

		/// <summary>
		/// ��ȡ���еĲ��������Ƶ����顣
		/// </summary>
		public string[] AllKeys
		{
			get
			{
				return base.BaseGetAllKeys();
			}
		}

		/// <summary>
		/// ��Ӳ�����������
		/// </summary>
		/// <param name="value">��ӵ������еĲ�����</param>
		/// <returns>��ӵĲ����������е�����ֵ��</returns>
		public void Add( IDbDataParameter value)  
		{
			if (value!=null)
			{				
				base.BaseAdd(value.ParameterName,value);				
			}
		}
		
		/// <summary>
		/// ���������Ƴ��ض��Ĳ�����
		/// </summary>
		/// <param name="value">Ҫ�Ƴ��Ĳ�����</param>
		public void Remove( IDbDataParameter value )  
		{			
			if (value!=null)
			{
				Remove(value.ParameterName);
			}
		}

		/// <summary>
		/// ���������Ƴ��ض��Ĳ�����
		/// </summary>
		/// <param name="parameterName">Ҫ�Ƴ��Ĳ��������ơ�</param>
		public void Remove( string parameterName)  
		{			
			base.BaseRemove(parameterName);
		}

		/// <summary>
		/// �������Ƿ�����ض���ֵ��
		/// </summary>
		/// <param name="value">����������Ƿ���ڵĲΡ�</param>
		/// <returns>��������а����򷵻�true�����򷵻�false��</returns>		
		public bool Contains( IDbDataParameter value )  
		{			
			if (value!=null)
			{
				return( Contains(value.ParameterName));
			} 			
			return false;			
		}	
	
		/// <summary>
		/// �������Ƿ�����ض���ֵ��
		/// </summary>
		/// <param name="parameterName">����������Ƿ���ڵĲ������ơ�</param>
		/// <returns>��������а����򷵻�true�����򷵻�false��</returns>		
		public bool Contains( string parameterName )  
		{			
			return (base.BaseGet(parameterName)!=null);
		}	
	
		/// <summary>
		/// ��������ָ��DBParameterCollection����Ĳ�������
		/// </summary>
		/// <param name="a">һ��DBParameterCollection����</param>
		/// <param name="b">һ��DBParameterCollection����</param>
		/// <returns>a��b�Ĳ���������a��b��˳��</returns>
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
		/// �������Ƿ����IDbDataParameter����
		/// </summary>
		public bool IsEmpty
		{
			get
			{
				return BaseHasKeys();		
			}
		}
		#region IEnumerable ��Ա

		/// <summary>
		/// ���ؿ�ѭ������ DBParameterCollection ��ö������
		/// </summary>
		/// <returns>���� DBParameterCollection ʵ���� IEnumerator��</returns>
		public new IEnumerator GetEnumerator()
		{
			return AllValues.GetEnumerator();
		}

		#endregion
		 
		/// <summary>
		/// ת��ΪIDbDataParameter ������ʽ��
		/// </summary>
		/// <param name="parameterCollection">Ҫת����DBParameterCollection �������ϡ�</param>
		/// <returns>ת�����IDbDataParameter�������</returns>
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
