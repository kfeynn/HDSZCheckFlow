// ================================================================================
// 		File: DBAccess.cs
// 		Desc: ���ݿ���ʽӿ��ࡣ�ṩ�������ݿ�ķ��ʽӿڡ�            
// 		Auth: ����
// 		Date: 2007��4��12��
// ================================================================================
// 		Change History
// ================================================================================
// 		Date:		Author:				Description:
// 		--------	--------			-------------------
//		
// ================================================================================
// Copyright (C) 2007-2008 FCKJ Corporation
// ================================================================================
using System;
using System.Data;
using System.Data.Common;
using System.Collections;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Text;

namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// ���ݿ���ʵĳ�����࣬ʵ�ֹ��õ����ݿ���ʷ�����
	/// </summary>
	public abstract class DBAccess
	{		
		#region ��Ա�����͹��캯��
		//���ݱ�ṹ��GetSchemaTable��ȡ����connectionString+":"+tableNameΪ��ֵ����ű�ṹ��DataTable
		static Hashtable m_htbTables;
		//���ݱ�Ľṹ��FillSchema��ȡ����connectionString+":"+tableNameΪ��ֵ����ŵ��е�DataTable
		static Hashtable m_htbTableSchema;		
		//�洢���̵Ĳ����ֶ����ݼ��ϣ���connectionString+":"+spNameΪ��ֵ����Ŵ洢���̵Ĳ���DataTable
		static Hashtable m_htbSPs;
		//�洢���̲������ϣ���ConnectionString+":"+spNameΪ��ֵ����Ŵ洢���̵Ĳ���DBParameterCollection
		/// <summary>
		/// �洢���̲����Ļ��档
		/// </summary>
		static Hashtable m_htbSPParameters;
		/// <summary>
		/// ִ������ĳ�ʱʱ�䣬����Ϊ��λ��
		/// </summary>
		int m_nCmdTimeout;
		/// <summary>
		/// ���������õ�������ʽ��(Access��������������˳�����������õ�˳����ͬ��
		/// </summary>
		protected static Regex m_regParameter;
		/// <summary>
		/// ���ݿ����ӡ�
		/// </summary>
		protected IDbConnection m_dbConnection;
		/// <summary>
		/// ���ݿ�����
		/// </summary>
		protected IDbTransaction m_dbTransaction;
		/// <summary>
		/// ���ݿ�������Ŀ��
		/// </summary>
		protected ushort m_TransCount;
		/// <summary>
		/// ��ʼ�� DBAccess �����ʵ����
		/// </summary>
		protected DBAccess()
		{
			m_dbTransaction=null;
			m_dbConnection=null;
			m_TransCount=0;
			m_nCmdTimeout=30;			
		}

		/// <summary>
		/// ��ʼ�� DBAccess ��ľ�̬ʵ����
		/// </summary>
		static DBAccess()
		{					
			m_htbTables=Hashtable.Synchronized(new Hashtable()); 				
			m_htbSPs=Hashtable.Synchronized(new Hashtable());		
			m_htbTableSchema=Hashtable.Synchronized(new Hashtable());
			m_htbSPParameters=Hashtable.Synchronized(new Hashtable());
			m_regParameter=new Regex(@"(?<parameter>@[^\(\)\,\f\n\r\t\v\x85\p{Z}]+)",RegexOptions.Compiled);
		}

		#endregion

		#region �����ַ���
		/// <summary>
		/// ��ȡ�����ַ�����
		/// </summary>
		protected string ConnectionString
		{
			get
			{
				if (m_dbConnection==null)
				{
					return null;
				} 
				else
				{
					OpenConnection();
					return m_dbConnection.ConnectionString;
				}
			}			
		}
		#endregion

		#region ִ������ĳ�ʱʱ�䣬Ĭ��Ϊ����ʱ
		/// <summary>
		/// ��ȡ����������ִֹ������ĳ��Բ����ɴ���֮ǰ�ĵȴ�ʱ��
		/// ��Ĭ��Ϊ30�루0��ʾ�����ƣ���������ʹ�ã���
		/// </summary>
		public int CommandTimeout
		{
			get
			{
				return m_nCmdTimeout;
			}
			set
			{
				m_nCmdTimeout=value;
			}
		}
		#endregion
		
		#region ���ӵĴ򿪺͹ر�
		/// <summary>
		/// �����ݿ����ӡ�
		/// </summary>
		protected void OpenConnection()
		{
			lock(this)
			{
				if (m_dbConnection!=null && m_dbConnection.State==System.Data.ConnectionState.Closed)
				{
					m_dbConnection.Open();				
				}
			}
		}
		/// <summary>
		/// �ر����ݿ����ӣ��ع�����
		/// </summary>
		public void CloseConnection()
		{
			CloseConnection(true);
		}

		/// <summary>
		/// �ر����ݿ����ӡ�
		/// </summary>
		/// <param name="bCloseTrans">�Ƿ�ع�����true��ʾ�ع�����false��ʾ����������������ӡ�</param>
		protected void CloseConnection(bool bCloseTrans)
		{
			lock(this)
			{
				if (bCloseTrans || m_TransCount==0)
				{				
					if (m_dbConnection!=null)
					{
						m_dbConnection.Close();
						m_dbTransaction=null;
						m_TransCount=0;					
					}
				}		
			}
		}
		#endregion

		#region �������
		/// <summary>
		/// ��ʼ���ݿ����񣨲�֧�ֲ�������Ҫ���ظú�������
		/// </summary>
		/// <returns>�ɹ����������򷵻�true�����򷵻�false��</returns>
		public virtual bool BeginTransaction()
		{		
			lock(this)
			{
				try
				{				
					OpenConnection();
					m_dbTransaction=m_dbConnection.BeginTransaction();				
					m_TransCount++;
					CloseConnection(false);
					return true;
				
				}
				catch
				{
					CloseConnection(true);
					throw;
				} 	
			}
		}

		/// <summary>
		/// �Ƿ��������
		/// </summary>
		/// <returns>���������򷵻�true�����򷵻�false��</returns>
		public bool HasTransaction()
		{
			return (m_TransCount>0);
		}

		/// <summary>
		/// �ύ��ǰ���ݿ�����
		/// </summary>
		/// <returns>�ɹ��ύ�����򷵻�true�����򷵻�false��</returns>
		public bool CommitTransaction()
		{
			lock(this)
			{
				if (m_dbTransaction==null || m_dbTransaction.Connection.State==System.Data.ConnectionState.Closed)
				{
					return false;
				}

				try 
				{
					m_dbTransaction.Commit();
					m_TransCount--;
					CloseConnection(false);
					return true;
				} 
				catch
				{
					CloseConnection(true);
					throw;
				}	
			}
		}

		/// <summary>
		/// �ع���ǰ���ݿ�����
		/// </summary>
		/// <returns>�ɹ��ع������򷵻�true�����򷵻�false��</returns>
		public bool RollbackTransaction()
		{
			lock(this)
			{
				if (m_dbTransaction==null || m_dbTransaction.Connection.State==System.Data.ConnectionState.Closed)
				{
					return false;
				}

				try 
				{
					m_dbTransaction.Rollback();
					m_TransCount=0;
					CloseConnection(false);
					return true;
				} 
				catch 
				{
					CloseConnection(true);
					throw;			
				}
			}
		}
		#endregion		

		#region �����洢���̲���
		/// <summary>
		/// �½��洢���̻��ѯ����еĲ��� IDbDataParameter �ӿڡ�
		/// </summary>
		public abstract IDbDataParameter CreateParameter();
		/// <summary>
		/// �ò������ƺͶ�Ӧ��ʼ��ֵ��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,object value);	
		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType);		
		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,object value);
		/// <summary>
		/// �ò������ơ�DbType �ʹ�С��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size);	
		/// <summary>
		/// �ò�������DbType����С��Դ������ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,string sourceColumn);		
		/// <summary>
		/// �ò������ơ����������͡������Ĵ�С��ParameterDirection�������ľ��ȡ�������С��λ����Դ�С�
		/// Ҫʹ�õ� DataRowVersion �Ͳ�����ֵ��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="direction">ParameterDirection ֵ֮һ��</param>
		/// <param name="isNullable">������ֶε�ֵ��Ϊ�գ���Ϊ true������Ϊ false��</param>
		/// <param name="precision">Ҫ�� Value ����Ϊ��С���������������λ����</param>
		/// <param name="scale">Ҫ�� Value ����Ϊ����С��λ����</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <param name="sourceVersion">DataRowVersion ֵ֮һ��</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,ParameterDirection direction,bool isNullable,byte precision,byte scale,string sourceColumn,DataRowVersion sourceVersion,object value);		
		/// <summary>
		/// ��ָ��������ʼ�� IDbDataParameter�ӿڡ�
		/// </summary>
		/// <param name="param">Ҫ���������Ļ���������</param>		
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public abstract IDbDataParameter CreateParameter(IDbDataParameter param);
		#endregion

		#region ���������ṩ����������ز���
		/// <summary>
		/// �ò������ƺ������ṩ�������ͳ�ʼ�� IDbDataParameter�ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType);
		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,object value);
		/// <summary>
		/// �ò������ơ�DbType �ʹ�С��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size);	
		/// <summary>
		/// �ò������������ṩ�������͡���С��Դ������ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size,string sourceColumn);		
		/// <summary>
		/// �ò������ơ������������ṩ�������͡������Ĵ�С��ParameterDirection�������ľ��ȡ�������С��λ����Դ�С�
		/// Ҫʹ�õ� DataRowVersion �Ͳ�����ֵ��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="direction">ParameterDirection ֵ֮һ��</param>
		/// <param name="isNullable">������ֶε�ֵ��Ϊ�գ���Ϊ true������Ϊ false��</param>
		/// <param name="precision">Ҫ�� Value ����Ϊ��С���������������λ����</param>
		/// <param name="scale">Ҫ�� Value ����Ϊ����С��λ����</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <param name="sourceVersion">DataRowVersion ֵ֮һ��</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size,ParameterDirection direction,bool isNullable,byte precision,byte scale,string sourceColumn,DataRowVersion sourceVersion,object value);
		#endregion		
		
		#region ��ȡ���е����ݵ�SQL
		/// <summary>
		/// ��ȡ��ȡ�����е�SQL��䡣
		/// </summary>
		/// <param name="tableName">Ҫ��ȡ��¼�ı����ơ�</param>
		/// <returns>�û���ȡ��һ����¼��SQL��䡣</returns>
		protected abstract string GetFirstRowSQL(string tableName);		
		#endregion

		#region ��ȡ���ݱ�ʹ洢���̵Ľṹ����
		/// <summary>
		/// ��ȡ��ṹ(������������BatchInsert��BatchDelete��BatchUpdate�Ľṹ)��
		/// </summary>
		/// <param name="tableName">���ݿ�����ơ�</param>
		/// <param name="clone">�ǻ�ȡ�ṹ���ǻ�ȡClone�����true��ʾ��ȡClone�����</param>
		/// <returns>��ȡָ�����ݱ�ı�ṹ��</returns>
		protected DataTable GetTableSchema(string tableName,bool clone)
		{
			lock(this)
			{
				string strKey=this.ConnectionString+":"+ tableName.ToUpper();
				if (m_htbTableSchema.ContainsKey(strKey))
				{
					if (clone)
					{
						return ((DataTable)m_htbTableSchema[strKey]).Clone();	
					}
					else
					{
						return (DataTable)m_htbTableSchema[strKey];					
					}
				}				
				IDbCommand command=null;
				try
				{
					OpenConnection();					
					command=m_dbConnection.CreateCommand();
					if (HasTransaction() && m_dbTransaction!=null ) 
					{
						command.Transaction=m_dbTransaction;					
					}	
					command.CommandType=CommandType.Text;
					command.CommandTimeout=m_nCmdTimeout;
					command.CommandText=GetFirstRowSQL(tableName);				
				
					IDataAdapter adapter=CreateAdapter(command);				
					DataSet ds=new DataSet();
					DataTable[] dts=adapter.FillSchema(ds,SchemaType.Source);				
					if (dts.Length>0)
					{
						DataTable dt=dts[0].Clone();						
						m_htbTableSchema.Add(strKey,dt);
						if (clone)
						{
							return dt.Clone();
						}
						else
						{
							return dt;
						}
					} 
					else
					{
						return null;
					}				
				}
				catch
				{
					CloseConnection(true);				
					throw;
				}		
				finally
				{
					if (command!=null)
					{
						command.Parameters.Clear();
					}
					CloseConnection(false);				
				}
			}
		}

		/// <summary>
		/// ���ر�ṹ(��ʹ��ǰ��Clone������ȡ�ṹ)��
		/// </summary>				
		/// <param name="tableName">�����ơ�</param>
		/// <returns>�������ݱ�ļܹ���Ϣ��</returns>
		public DataTable GetTableSchema(string tableName)
		{
			return GetTableSchema(tableName,true);	
		}

		/// <summary>
		/// ��ȡ�������ݱ�������нṹ���ϡ�
		/// </summary>
		/// <param name="tableName">���ݱ����ơ�</param>
		/// <returns>���ݱ��һ���нṹ��</returns>
		public DataRow GetRowStructure(string tableName)
		{		
			lock(typeof(DBAccess))
			{					
				DataTable dt=this.GetTableSchema(tableName,true);
				if (dt!=null)
				{
					return (dt.NewRow());
				} 
				else
				{
					return null;
				}
			}
		}

		/// <summary>
		/// ��ȡ�������ݱ�������нṹ���ϡ�
		/// ���ضԸ�������һ�������¼�õ�Hashtable���Ա��ֶ���ΪKey��
		/// </summary>
		/// <param name="tableName">���ݱ����ơ�</param>
		/// <returns>�Ա��ֶ�ΪKey��Hashtable��</returns>
		public Hashtable GetRowStructureEx(string tableName)
		{
			Hashtable htb=new Hashtable();			
			DataRow dr=GetRowStructure(tableName);
			foreach (DataColumn dc in dr.Table.Columns)
			{				
				htb.Add(dc.ColumnName,null);				
			}								
			return htb;
		}	

		/// <summary>
		/// ��ȡ���ݱ���ֶνṹ��
		/// </summary>
		/// <param name="tableName">���ݱ����ơ�</param>
		/// <returns>��ṹ�Ľ������</returns>
		public DataTable GetTableStructure(string tableName)
		{
			lock(typeof(DBAccess))
			{				
				string strKey=this.ConnectionString+":"+ tableName.ToUpper();
				if (m_htbTables.ContainsKey(strKey))
				{
					return (DataTable)m_htbTables[strKey];					
				}
				try
				{
					IDataReader reader=ExecuteReader(GetFirstRowSQL(tableName));
					if (reader!=null)
					{
						DataTable dt=reader.GetSchemaTable();
						reader.Close();
						dt.PrimaryKey=new DataColumn[] {dt.Columns["ColumnName"]};
						m_htbTables.Add(strKey,dt);						
						return dt;
					} 
					else
					{
						return null;
					}
				}
				finally{CloseConnection(false);}
			}
		}

		/// <summary>
		/// ���ݱ��ĳһ���Ƿ������������͡�
		/// </summary>
		/// <param name="tableName">Ҫ��ȡ�ṹ�����ݱ����ơ�</param>
		/// <param name="columnName">Ҫ�ж������������ơ�</param>
		/// <returns>����������ֶ��򷵻�true�����򷵻�false��</returns>
		protected bool IsAutoIncrement(string tableName, string columnName)
		{
			DataTable dt=GetTableSchema(tableName,false);			
			if (dt!=null) 
			{
				DataColumn dc=dt.Columns[columnName];
				if (dc!=null)
				{					
					return dc.AutoIncrement;					
				}
			} 
			return false;	
		}		

		/// <summary>
		/// ���ݱ��е�ĳһ���Ƿ������ֵ��
		/// </summary>
		/// <param name="tableName">Ҫ��ȡ�ṹ�����ݱ����ơ�</param>
		/// <param name="columnName">Ҫ�ж������������ơ�</param>
		/// <returns>��������ֵ�򷵻�true�����򷵻�false��</returns>
		protected bool IsAllowDBNull(string tableName,string columnName)
		{
			DataTable dt=GetTableSchema(tableName,false);			
			if (dt!=null) 
			{
				DataColumn dc=dt.Columns[columnName];
				if (dc!=null)
				{					
					return dc.AllowDBNull;						
				}
			} 
			return false;	
		}

		/// <summary>
		/// ��ȡ���ݱ���ĳһ�е�Ĭ��ֵ��
		/// </summary>
		/// <param name="tableName">Ҫ��ȡ�ṹ�����ݱ����ơ�</param>
		/// <param name="columnName">Ҫ��ȡĬ��ֵ�����������ơ�</param>
		/// <returns>���ݱ���ĳһ�е�Ĭ��ֵ��</returns>
		protected object GetDefaultValue(string tableName,string columnName)
		{
			DataTable dt=GetTableSchema(tableName);			
			if (dt!=null) 
			{
				DataColumn dc=dt.Columns[columnName];
				if (dc!=null)
				{					
					return dc.DefaultValue;						
				}
			} 
			return false;	
		}

		/// <summary>
		/// ���� IDbCommand ��ָ���Ĵ洢���̼���������Ϣ�����ָ�� IDbCommand ����� Parameters ���ϡ�
		/// </summary>
		/// <param name="cmd">���ý������е���������Ϣ�Ĵ洢���̵� IDbCommand�����������ᱻ��ӵ� IDbCommand �� Parameters �����С�</param>
		protected abstract void DeriveParameters(IDbCommand cmd);

		/// <summary>
		/// ��ȡ�洢���̵Ĳ������ϡ�
		/// </summary>
		/// <param name="spName">�洢��������</param>		
		/// <returns>�洢���̵Ĳ������ϡ�</returns>
		public DBParameterCollection GetSPParametersEx(string spName)
		{			
			lock(typeof(DBAccess))
			{
				string key=ConnectionString+":"+spName.ToUpper();
				if (m_htbSPParameters.ContainsKey(key))
				{
					return (DBParameterCollection)m_htbSPParameters[key];
				}				
				try
				{
					DBParameterCollection colParameters=new DBParameterCollection();
					OpenConnection();
					IDbCommand cmd = m_dbConnection.CreateCommand();
					cmd.CommandText=spName;
					cmd.CommandTimeout=m_nCmdTimeout;
					if (HasTransaction() && m_dbTransaction!=null ) 
					{
						cmd.Transaction=m_dbTransaction;						
					}					
					cmd.CommandType = CommandType.StoredProcedure;

					DeriveParameters(cmd);		

					foreach (IDbDataParameter p in cmd.Parameters)
					{					
						IDbDataParameter param=CreateParameter(p);
						colParameters.Add(param);	
					}
					m_htbSPParameters.Add(key,colParameters);
					cmd.Parameters.Clear();
					return colParameters;
				}
				catch {throw;}
				finally
				{
					CloseConnection(false);	
				}
			}
		}

		/// <summary>
		/// ��ȡ�洢���̵Ĳ����ṹ���ϡ�
		/// ���ش洢���̲����б��Hashtable���Դ洢���̲�����ΪKey������@����
		/// </summary>
		/// <param name="spName">Ҫ��ȡ�����б�Ĵ洢�������ơ�</param>
		/// <returns>�Դ洢���̲���ΪKey��Hashtable��</returns>
		public Hashtable GetSPParameters(string spName)
		{
			Hashtable htb=new Hashtable();
			DBParameterCollection colParams=this.GetSPParametersEx(spName);
			if (colParams!=null)
			{
				foreach (IDbDataParameter p in colParams)
				{				
					htb.Add(p.ParameterName,null);				
				}			
				return htb;
			} 
			else
			{
				return null;
			}		
		}		
		#endregion

		#region ��ȡ����
		/// <summary>
		/// �����µ����ݿ�������
		/// </summary>
		/// <returns>���������ݿ�ӿڡ�</returns>
		public IDbCommand CreateCommand()
		{
			return this.m_dbConnection.CreateCommand();			
		}
		#endregion

		#region ����ִ����������˳��������� 
		/// <summary>
		/// �����ݿ���ʲ�������ִ������˳������
		/// �������ⲿ�����Ĳ�����Access��Ҫ���ò���˳��һ�£�
		/// </summary>
		/// <param name="commandText">ִ�еĴ���������䡣</param>
		/// <param name="paramCollection">��Ҫ�����Ĳ������ϡ�</param>
		/// <returns>��������еĲ���˳�����еĲ������ϡ�</returns>
		public virtual DBParameterCollection SortParameterCollection(string commandText,DBParameterCollection paramCollection)
		{
			if (paramCollection==null)
			{
				return null;
			}
			DBParameterCollection paramReturn=new DBParameterCollection();			
			Match m=m_regParameter.Match(commandText);
			while (m.Success && m.Length>0)
			{
				string strName=m.Result("${parameter}");
				if (!paramReturn.Contains(strName))
				{
					paramReturn.Add(paramCollection[strName]);
				}	
				m=m.NextMatch();
			}
			return paramReturn;
		}
		#endregion

		#region ����SQL��䣨������������ţ�
		/// <summary>
		/// ������������������������д���
		/// </summary>
		/// <param name="commandText">�������������Ĵ������������ַ�����</param>
		/// <returns>�����Ŀ�������ӦDataAdapter��SQL��䡣</returns>
		protected virtual string BatchSQLFilter(string commandText)
		{
			return commandText;
		}


		/// <summary>
		/// ��ȡ�����ַ����Ĳ�������
		/// </summary>
		public virtual string StringJoinOperator
		{
			get
			{
				return "+";
			}
		}		
		#endregion

		#region ��ȡ��������BatchDelete��BatchUpdate��BatchInsert��BatchExecute�Ĳ���
		/// <summary>
		/// ��ȡ�����������ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">��������ݱ�����ơ�</param>		
		/// <param name="includeCols">��������ʱ�����������С�</param>
		/// <param name="primaryCols">�ڴ����ݱ��������</param>
		/// <param name="table">�������ݵ��ڴ������ݽṹ��</param>
		/// <param name="insertSql">��������ʱ�Ĳ�����䡣</param>
		/// <returns>�����������������</returns>
		public DBParameterCollection GetBatchInsertParameters(string tableName,StringCollection includeCols,StringCollection primaryCols,out DataTable table,out string insertSql)
		{
			
			StringCollection cols=null;
			if (includeCols!=null)
			{
				cols=new StringCollection();
				foreach(string s in includeCols)
				{
					cols.Add(s.ToUpper());
				}
			}
			
			StringCollection pCols=null;
			if (primaryCols!=null)
			{
				pCols=new StringCollection();
				foreach(string s in primaryCols)
				{
					pCols.Add(s.ToUpper());
				}
			}
			return GetBatchInsertParameters(tableName,null,cols,pCols,out table,out insertSql);
		}
		

		/// <summary>
		/// ��ȡ�����������ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">��������ݱ�����ơ�</param>
		/// <param name="dtValue">��Ҫ�����������������ݱ�</param>		
		/// <param name="includeCols">��������ʱ�����������С�</param>
		/// <param name="primaryCols">�ڴ����ݱ��������</param>
		/// <param name="table">�������ݵ��ڴ������ݽṹ��</param>
		/// <param name="insertSql">��������ʱ�Ĳ�����䡣</param>
		/// <returns>�����������������</returns>
		private DBParameterCollection GetBatchInsertParameters(string tableName,DataTable dtValue,StringCollection includeCols,StringCollection primaryCols,out DataTable table,out string insertSql)
		{			
			table=new DataTable(tableName);
			if (includeCols==null)
			{		
				insertSql="";
				return null;
			}
			
			insertSql="INSERT INTO "+tableName +"(";
			string strValues="";
			DataColumn dc;
			
			DBParameterCollection paramCol=new DBParameterCollection();			
			IDbDataParameter param;				
			DataTable dtStruct=GetTableStructure(tableName);
			foreach (DataRow dr in dtStruct.Rows)
			{				
				string strKey=Convert.ToString(dr["ColumnName"]).ToUpper();
				if (dtValue==null || dtValue.Columns.Contains(strKey))
				{
					if (includeCols.Contains(strKey) && !IsAutoIncrement(tableName,strKey))
					{							
						if (strValues!="")
						{
							insertSql+=",";
							strValues+=",";
						}
						insertSql+=strKey;
						strValues+="@"+strKey;
					
						dc=new DataColumn();
						dc.ColumnName=strKey;							
						dc.DataType=(System.Type)dr["DataType"];							
						table.Columns.Add(dc);						

						param=CreateParameter("@"+strKey,Convert.ToInt32(dr["ProviderType"]));						
						param.Direction=ParameterDirection.Input;						
						param.Size=Convert.ToInt32(dr["ColumnSize"]);					
						if (Convert.ToByte(dr["NumericPrecision"])!=255)
						{
							param.Precision=Convert.ToByte(dr["NumericPrecision"]);
						}
						if (Convert.ToByte(dr["NumericScale"])!=255)
						{
						
							param.Scale=Convert.ToByte(dr["NumericScale"]);
						}					
						param.SourceColumn=strKey;	
						paramCol.Add(param);
					}
				}
			}						
			insertSql=insertSql+") VALUES ("+strValues+")";
			

			//Primary Keys
			if (primaryCols!=null && primaryCols.Count>0)
			{
				Hashtable htb=new Hashtable();
				int i=0;
				foreach (DataColumn col in table.Columns)
				{
					if (primaryCols.Contains(col.ColumnName.ToUpper()))
					{
						htb[i++]=col;
					}
				}
				DataColumn[] cols=new DataColumn[htb.Count];
				i=0;
				foreach (object obj in htb.Values)
				{
					cols[i++]=(DataColumn)obj;
				}

				if (cols.Length>0)
				{
					table.PrimaryKey=cols;
				}
			}
			return paramCol;
		}

		/// <summary>
		/// ��ȡ����ɾ�����ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">ɾ�������ݱ�����ơ�</param>		
		/// <param name="includeCols">ɾ������ʱ�����������С�</param>
		/// <param name="whereCols">�������ݱ�ʱ�������ֶΡ�</param>
		/// <param name="primaryCols">ɾ���������ڴ����ݱ��������</param>
		/// <param name="table">ɾ�����ݵ��ڴ������ݽṹ��</param>
		/// <param name="deleteSql">ɾ������ʱ��ɾ����䡣</param>
		/// <returns>ɾ���������������</returns>
		public DBParameterCollection GetBatchDeleteParameters(string tableName,StringCollection includeCols,StringCollection whereCols,StringCollection primaryCols,out DataTable table,out string deleteSql)
		{
			StringCollection cols=null;
			if (includeCols!=null)
			{
				cols=new StringCollection();
				foreach(string s in includeCols)
				{
					cols.Add(s.ToUpper());
				}
			}

			StringCollection wCols=null;
			if (whereCols!=null)
			{
				wCols=new StringCollection();
				foreach(string s in whereCols)
				{
					wCols.Add(s.ToUpper());
				}
			}
			
			StringCollection pCols=null;
			if (primaryCols!=null)
			{
				pCols=new StringCollection();
				foreach(string s in primaryCols)
				{
					pCols.Add(s.ToUpper());
				}
			}

			return GetBatchDeleteParameters(tableName,null,cols,wCols,pCols,out table,out deleteSql);
		}

		/// <summary>
		/// ��ȡ����ɾ�����ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">ɾ�������ݱ�����ơ�</param>
		/// <param name="dtValue">��Ҫ�����������������ݱ�</param>
		/// <param name="includeCols">ɾ������ʱ�����������С�</param>
		/// <param name="whereCols">�������ݱ�ʱ�������ֶΡ�</param>
		/// <param name="primaryCols">ɾ���������ڴ����ݱ��������</param>
		/// <param name="table">ɾ�����ݵ��ڴ������ݽṹ��</param>
		/// <param name="deleteSql">ɾ������ʱ��ɾ����䡣</param>
		/// <returns>ɾ���������������</returns>
		private DBParameterCollection GetBatchDeleteParameters(string tableName,DataTable dtValue,StringCollection includeCols,StringCollection whereCols,StringCollection primaryCols,out DataTable table,out string deleteSql)
		{			
			table=new DataTable(tableName);
			deleteSql="";
			string whereSql="";
			if (includeCols==null)
			{				
				return null;
			}			

			DataColumn dc;
			
			DBParameterCollection paramCol=new DBParameterCollection();			
			IDbDataParameter param;				
			DataTable dtStruct=GetTableStructure(tableName);			
			foreach (DataRow dr in dtStruct.Rows)
			{					
				string strKey=Convert.ToString(dr["ColumnName"]).ToUpper();
				if (dtValue==null || dtValue.Columns.Contains(strKey))
				{				

					if (includeCols.Contains(strKey) || whereCols.Contains(strKey))
					{					
						dc=new DataColumn();
						dc.ColumnName=strKey;							
						dc.DataType=(System.Type)dr["DataType"];							
						table.Columns.Add(dc);						
					}
					//where Sql
					if (whereCols.Contains(strKey))
					{
						if (whereSql!="")
						{
							whereSql+=" AND ";
						}
						whereSql+=strKey+"=@"+strKey;
					
						param=CreateParameter("@"+strKey,Convert.ToInt32(dr["ProviderType"]));						
						param.Direction=ParameterDirection.Input;
						param.Size=Convert.ToInt32(dr["ColumnSize"]);					
						if (Convert.ToByte(dr["NumericPrecision"])!=255)
						{
							param.Precision=Convert.ToByte(dr["NumericPrecision"]);
						}
						if (Convert.ToByte(dr["NumericScale"])!=255)
						{
						
							param.Scale=Convert.ToByte(dr["NumericScale"]);
						}					
						param.SourceColumn=strKey;	
						paramCol.Add(param);					
					}
				}
			}	
	
			if (!whereSql.Equals(String.Empty))
			{
				deleteSql="DELETE FROM "+tableName+ " WHERE " +whereSql;
			}
		
			//Primary Keys
			if (primaryCols!=null && primaryCols.Count>0)
			{
				Hashtable htb=new Hashtable();
				int i=0;
				foreach (DataColumn col in table.Columns)
				{
					if (primaryCols.Contains(col.ColumnName.ToUpper()))
					{
						htb[i++]=col;
					}
				}
				DataColumn[] cols=new DataColumn[htb.Count];
				i=0;
				foreach (object obj in htb.Values)
				{
					cols[i++]=(DataColumn)obj;
				}

				if (cols.Length>0)
				{
					table.PrimaryKey=cols;
				}
			}
			return paramCol;
		}

		/// <summary>
		/// ��ȡ�����������ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">���µ����ݱ�����ơ�</param>		
		/// <param name="includeCols">��������ʱ�����������С�</param>
		/// <param name="whereCols">�������ݱ�ʱ�������ֶΡ�</param>
		/// <param name="primaryCols">�ڴ����ݱ��������</param>
		/// <param name="table">�������ݵ��ڴ������ݽṹ��</param>
		/// <param name="updateSql">��������ʱ�ĸ�����䡣</param>
		/// <returns>�����������������</returns>
		public DBParameterCollection GetBatchUpdateParameters(string tableName,StringCollection includeCols,StringCollection whereCols,StringCollection primaryCols,out DataTable table,out string updateSql)
		{
			StringCollection cols=null;
			if (includeCols!=null)
			{
				cols=new StringCollection();
				foreach(string s in includeCols)
				{
					cols.Add(s.ToUpper());
				}
			}

			StringCollection wCols=null;
			if (whereCols!=null)
			{
				wCols=new StringCollection();
				foreach(string s in whereCols)
				{
					wCols.Add(s.ToUpper());
				}
			}
			
			StringCollection pCols=null;
			if (primaryCols!=null)
			{
				pCols=new StringCollection();
				foreach(string s in primaryCols)
				{
					pCols.Add(s.ToUpper());
				}
			}
			return GetBatchUpdateParameters(tableName,null,cols,wCols,pCols,out table,out updateSql);
		}
	

		/// <summary>
		/// ��ȡ�����������ݵĸ��ֲ�����
		/// </summary>
		/// <param name="tableName">���µ����ݱ�����ơ�</param>
		/// <param name="dtValue">��Ҫ�����������������ݱ�</param>		
		/// <param name="includeCols">��������ʱ�����������С�</param>
		/// <param name="whereCols">�������ݱ�ʱ�������ֶΡ�</param>
		/// <param name="primaryCols">�ڴ����ݱ��������</param>
		/// <param name="table">�������ݵ��ڴ������ݽṹ��</param>
		/// <param name="updateSql">��������ʱ�ĸ�����䡣</param>
		/// <returns>�����������������</returns>
		private DBParameterCollection GetBatchUpdateParameters(string tableName,DataTable dtValue,StringCollection includeCols,StringCollection whereCols,StringCollection primaryCols,out DataTable table,out string updateSql)
		{			
			table=new DataTable(tableName);
			updateSql="";
			string whereSql="";
			if (includeCols==null)
			{				
				return null;
			}			

			DataColumn dc;
			
			DBParameterCollection paramCol=new DBParameterCollection();	
			DBParameterCollection parWhere=new DBParameterCollection();
			IDbDataParameter param;							
			DataTable dtStruct=GetTableStructure(tableName);
			foreach (DataRow dr in dtStruct.Rows)
			{					
				string strKey=Convert.ToString(dr["ColumnName"]).ToUpper();
				if (dtValue==null || dtValue.Columns.Contains(strKey))
				{
					bool b=whereCols.Contains(strKey);
					//where Sql
					if (b)
					{
						if (whereSql!="")
						{
							whereSql+=" AND ";
						}
						whereSql+=strKey+"=@"+strKey;						
					}					

					if (includeCols.Contains(strKey) || b)
					{			
						if (!whereCols.Contains(strKey))
						{
							if (updateSql!="")
							{
								updateSql+=",";						
							}
							updateSql+=strKey+"=@"+strKey;
						}
					
						dc=new DataColumn();
						dc.ColumnName=strKey;							
						dc.DataType=(System.Type)dr["DataType"];							
						table.Columns.Add(dc);						

						param=CreateParameter("@"+strKey,Convert.ToInt32(dr["ProviderType"]));						
						param.Direction=ParameterDirection.Input;
						param.Size=Convert.ToInt32(dr["ColumnSize"]);					
						if (Convert.ToByte(dr["NumericPrecision"])!=255)
						{
							param.Precision=Convert.ToByte(dr["NumericPrecision"]);
						}
						if (Convert.ToByte(dr["NumericScale"])!=255)
						{
						
							param.Scale=Convert.ToByte(dr["NumericScale"]);
						}		
						param.SourceColumn=strKey;	

						if (b)
						{
							parWhere.Add(param);							
						}
						else
						{
							paramCol.Add(param);
						}
					}
				}
			}	
	
			if (!updateSql.Equals(String.Empty))
			{
				updateSql="UPDATE "+tableName+ " SET " + updateSql;
			}
			if (!whereSql.Equals(String.Empty))
			{
				updateSql+=" WHERE "+ whereSql;
			}
			
		
			//Primary Keys
			if (primaryCols!=null && primaryCols.Count>0)
			{
				Hashtable htb=new Hashtable();
				int i=0;
				foreach (DataColumn col in table.Columns)
				{
					if (primaryCols.Contains(col.ColumnName.ToUpper()))
					{
						htb[i++]=col;
					}
				}

				DataColumn[] cols=new DataColumn[htb.Count];
				i=0;
				foreach (object obj in htb.Values)
				{
					cols[i++]=(DataColumn)obj;
				}

				if (cols.Length>0)
				{
					table.PrimaryKey=cols;
				}
			}
			return (paramCol+parWhere);
		}			

		/// <summary>
		/// ��ȡ���������Ĵ洢����ִ������Ͳ������ڴ��ṹ�б�
		/// ��BatchExecute��ִ����Ӧ����������
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="includeCols">���������漰���С�</param>
		/// <param name="primaryCols">�ڴ�������ݴ洢�Ĺؼ��ֶΡ�</param>		
		/// <param name="table">�ڴ��ı�ṹ��</param>
		/// <returns>ִ���������������</returns>
		public IDbCommand GetBatchSPParameters(string spName, StringCollection includeCols, StringCollection primaryCols, out DataTable table)
		{
			DBParameterCollection spParams;
			return GetBatchSPParameters(spName,includeCols,primaryCols,out spParams,out table);
		}

		/// <summary>
		/// ��ȡ���������Ĵ洢����ִ������Ͳ������ڴ��ṹ�б�
		/// ��BatchExecute��ִ����Ӧ����������
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="includeCols">���������漰���С�</param>
		/// <param name="primaryCols">�ڴ�������ݴ洢�Ĺؼ��ֶΡ�</param>
		/// <param name="spParams">�洢���̲�����</param>
		/// <param name="table">�ڴ��ı�ṹ��</param>
		/// <returns>ִ���������������</returns>
		public IDbCommand GetBatchSPParameters(string spName,StringCollection includeCols,StringCollection primaryCols,out DBParameterCollection spParams,out DataTable table)
		{
			table=new DataTable(spName);				
			IDbCommand dbCmd=m_dbConnection.CreateCommand();			
			dbCmd.CommandType=CommandType.StoredProcedure;
			dbCmd.CommandText=spName;
			dbCmd.CommandTimeout=m_nCmdTimeout;

			StringCollection iCols=null;
			if (includeCols!=null)
			{
				iCols=new StringCollection();
				foreach(string s in includeCols)
				{
					iCols.Add(s.ToUpper());
				}
			}
			
			StringCollection pCols=null;
			if (primaryCols!=null)
			{
				pCols=new StringCollection();
				foreach(string s in primaryCols)
				{
					pCols.Add(s.ToUpper());
				}
			}


			DataColumn dc;
			spParams=this.GetSPParametersEx(spName);			
			foreach (IDataParameter p in spParams)
			{
				string strKey=p.ParameterName.TrimStart('@').ToUpper();
				if (iCols.Contains(strKey))
				{									
					dc=new DataColumn();
					dc.ColumnName=strKey;
					dc.DataType=ToDotNetType(p.DbType);					
					table.Columns.Add(dc);	
				}
			}				
		
			//�洢���̲���								
			foreach (IDbDataParameter p in spParams)
			{														
				dbCmd.Parameters.Add(p);
			}

			//Primary Keys
			if (pCols!=null && pCols.Count>0)
			{
				Hashtable htb=new Hashtable();
				int i=0;
				foreach (DataColumn col in table.Columns)
				{
					if (pCols.Contains(col.ColumnName.ToUpper()))
					{
						htb[i++]=col;
					}
				}

				DataColumn[] cols=new DataColumn[htb.Count];
				i=0;
				foreach (object obj in htb.Values)
				{
					cols[i++]=(DataColumn)obj;
				}

				if (cols.Length>0)
				{
					table.PrimaryKey=cols;
				}	
			}
			return dbCmd;
		}
		#endregion		
		
		#region �洢���̲�����ֵ����
		/// <summary>
		/// Ϊ�ض������ݿ��ṩ������SQL��䡣
		/// </summary>
		/// <param name="command">��Ҫ��������</param>
		protected virtual void AttachCommandText(ref IDbCommand command)
		{
			return;
		}

		/// <summary>
		/// ���Ӵ洢���̲�����ָ�����
		/// </summary>
		/// <param name="command">�����Ӳ��������</param>
		/// <param name="parameters">���ӵĲ�����</param>
		/// <param name="commandParameters">���ӵĲ������ϣ������commandΪ�洢���̣���Ϊ�洢���̵Ĳ�����</param>
		protected virtual void AttachParameters(IDbCommand command, IDbDataParameter[] parameters,DBParameterCollection commandParameters)
		{
			if( command == null ) 
			{
				return;
			}					
			AttachCommandText(ref command);
			//�������
			if( parameters != null )
			{				
				foreach (IDbDataParameter p in parameters)
				{
					if( p != null )
					{						
						if ( ( p.Direction == ParameterDirection.InputOutput || 
							p.Direction == ParameterDirection.Input ) && 
							(p.Value == null))
						{
							p.Value = DBNull.Value;
						}
						command.Parameters.Add(p);
					}
				}
			}
			//�������
			if (commandParameters!=null)
			{			
				foreach(IDbDataParameter p in commandParameters)
				{
					if (p!=null && !command.Parameters.Contains(p.ParameterName))
					{
						if ( ( p.Direction == ParameterDirection.InputOutput || 
							p.Direction == ParameterDirection.Input ) && 
							(p.Value == null))
						{
							p.Value = DBNull.Value;
						}
						command.Parameters.Add(p);
					}
				}
			}
		}

		/// <summary>
		/// Ϊ�洢���̵Ĳ�����ֵ��
		/// </summary>
		/// <param name="commandParameters">�洢���̵Ĳ�����</param>
		/// <param name="values">�洢���̵Ĳ�����ֵ���Դ洢���̵Ĳ�������Ϊkey��</param>
		protected virtual void AssignParameterValues(IDbDataParameter[] commandParameters, Hashtable values)
		{			
			if ((commandParameters == null) || (values == null)) 
			{				
				return;
			}
			
			foreach(IDbDataParameter commandParameter in commandParameters)
			{	
				if (values.Contains(commandParameter.ParameterName))
				{
					if (values[commandParameter.ParameterName]==null)
					{
						commandParameter.Value =DBNull.Value;
					} 
					else
					{
						commandParameter.Value =values[commandParameter.ParameterName];
					}
				} 
			}
		}		
		#endregion

		#region ExecuteNonQuery ִ��SQL����洢���̣�����Ӱ�������
		/// <summary>
		/// ִ�д�������SQL�����洢���̣�����Ӱ�������������
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="colParameters">ִ�е�SQL����洢���̵Ĳ������ϡ�</param>
		/// <returns>����Ӱ���������</returns>
		public int ExecuteNonQuery(string commandText,CommandType commandType,DBParameterCollection colParameters)
		{
			//IDbDataParameter[] commandParameters=TransCollectionToArray(colParameters);
			if (colParameters!=null)
			{				
				return ExecuteNonQuery(BatchSQLFilter(commandText),commandType,(IDbDataParameter[])colParameters);
			} 
			else
			{
				return ExecuteNonQuery(commandText,commandType,(IDbDataParameter[])colParameters);
			}
		}
		/// <summary>
		/// ִ��SQL�������Ӱ�������������
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="commandParameters">�������</param>
		/// <returns>����Ӱ���������</returns>
		protected int ExecuteNonQuery(string commandText,CommandType commandType,params IDbDataParameter[] commandParameters)
		{
			lock(this)
			{
				IDbCommand command=null;
				try
				{					
					DBParameterCollection spParam=null;
					OpenConnection();	
					command=m_dbConnection.CreateCommand();
					if (HasTransaction() && m_dbTransaction!=null ) 
					{
						command.Transaction=m_dbTransaction;					
					}	
					command.CommandType=commandType;
					command.CommandTimeout=m_nCmdTimeout;
					command.CommandText=commandText;					
					AttachParameters(command,commandParameters,spParam);							
					return command.ExecuteNonQuery();							
				}
				catch (Exception ex)
				{
					CloseConnection(true);				
					throw ex;
				}		
				finally
				{
					if (command!=null)
					{
						command.Parameters.Clear();
					}
					CloseConnection(false);				
				}
			}
		}

		/// <summary>
		/// ��ͨ��������ִ��SQL��䡣
		/// </summary>
		/// <param name="commandText">ִ�е�SQL��䡣</param>
		/// <returns>Insert,Delete,Update��������Ӱ�����������������-1��</returns>
		public int ExecuteNonQuery(string commandText)
		{
			return ExecuteNonQuery(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// ִ�д洢���̣�����Ӱ������������Ͳ���ֵ��
		/// </summary>
		/// <param name="spName">�洢��������</param>
		/// <param name="htbValue">�Դ洢���̲���ΪKey��Hashtable����GetSPStructureEx����������ʱ����Out���͵�ֵ��</param>
		/// <returns>Insert,Delete,Update��������Ӱ�����������������-1��</returns>
		public int ExecuteNonQuery(string spName,ref Hashtable htbValue)
		{
			IDbDataParameter[] commandParameters=(IDbDataParameter[])GetSPParametersEx(spName);			
			AssignParameterValues(commandParameters,htbValue);
			int nReturn=ExecuteNonQuery(spName,CommandType.StoredProcedure,commandParameters);
			foreach (IDbDataParameter p in commandParameters)
			{
				htbValue[p.ParameterName]=p.Value;
			}
			return nReturn;
		}

		/// <summary>
		/// ��ͨ��������ִ�д洢���̣��޽�������ء�
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="colParameters">�洢���̲������ϡ�</param>
		/// <returns>Insert,Delete,Update��������Ӱ�����������������-1��</returns>
		public int ExecuteNonQuery(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteNonQuery(spName,CommandType.StoredProcedure,(IDbDataParameter[]) colParameters);
		}
		#endregion
	
		#region ExecuteDataset ִ��SQL����洢���̣��������ݼ�
		
		/// <summary>
		/// �ṩ�����Ž�����
		/// </summary>
		/// <param name="command">�����Ž��������</param>
		/// <returns>���������Ž������������DataSet��</returns>
		protected abstract IDbDataAdapter CreateAdapter(IDbCommand command);
		/// <summary>
		/// �ṩ�����Ž�����
		/// </summary>		
		/// <returns>���������Ž�����������������������</returns>
		protected abstract IDbDataAdapter CreateAdapter();

		/// <summary>
		/// ִ�д�������SQL�����洢���̣����ؽ������
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="colParameters">ִ�е�SQL����洢���̵Ĳ������ϡ�</param>
		/// <returns>ִ������صĽ������</returns>
		public DataSet ExecuteDataset(string commandText,CommandType commandType,DBParameterCollection colParameters)
		{			 
			if (colParameters!=null)
			{				
				return ExecuteDataset(BatchSQLFilter(commandText),commandType,(IDbDataParameter[])colParameters);
			} 
			else
			{
				return ExecuteDataset(commandText,commandType,(IDbDataParameter[])colParameters);
			}
		}

		/// <summary>
		/// ִ��SQL������ؽ������
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="commandParameters">�������</param>
		/// <returns>ִ������صĽ������</returns>
		protected DataSet ExecuteDataset(string commandText,CommandType commandType,params IDbDataParameter[] commandParameters)
		{
			lock(this)
			{
				IDbCommand command=null;				
				try
				{					
					DBParameterCollection spParam=null;
					OpenConnection();
					command=m_dbConnection.CreateCommand();
					if (HasTransaction() && m_dbTransaction!=null ) 
					{
						command.Transaction=m_dbTransaction;					
					}	
					command.CommandType=commandType;
					command.CommandTimeout=m_nCmdTimeout;
					command.CommandText=commandText;				
					AttachParameters(command,commandParameters,spParam);
				
					IDataAdapter adapter=CreateAdapter(command);				
					DataSet ds=new DataSet();
					adapter.Fill(ds);
					return ds;				
				}
				catch
				{
					CloseConnection(true);				
					throw;
				}		
				finally
				{
					if (command!=null)
					{
						command.Parameters.Clear();
					}
					CloseConnection(false);				
				}
			}
		}


		/// <summary>
		/// ��ͨ��������ִ��SQL��䡣
		/// </summary>
		/// <param name="commandText">ִ�е�SQL��䡣</param>
		/// <returns>�ò�����ȡ�Ľ������</returns>
		public DataSet ExecuteDataset(string commandText)
		{
			return ExecuteDataset(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// ִ�д洢���̣���ȡ������Ͳ���ֵ��
		/// </summary>
		/// <param name="spName">�洢��������</param>
		/// <param name="htbValue">�Դ洢���̲���ΪKey��Hashtable����GetSPStructureEx����������ʱ����Out���͵�ֵ��</param>
		/// <returns>�ò�����ȡ�Ľ������</returns>
		protected DataSet ExecuteDataset(string spName,ref Hashtable htbValue)
		{
			IDbDataParameter[] commandParameters=(IDbDataParameter[])GetSPParametersEx(spName);
			AssignParameterValues(commandParameters,htbValue);
			return ExecuteDataset(spName,CommandType.StoredProcedure,commandParameters);
		}

		/// <summary>
		/// ��ͨ��������ִ�д洢���̣����ؽ������
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="colParameters">�洢���̲������ϡ�</param>
		/// <returns>�ò�����ȡ�Ľ������</returns>
		public DataSet ExecuteDataset(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteDataset(spName,CommandType.StoredProcedure,(IDbDataParameter[]) colParameters);
		}
		#endregion
		
		#region ExecuteReader ִ��SQL����洢���̣�����ֻ���������
		
		/// <summary>
		/// ִ�д�������SQL�����洢���̣�����SqlDataReader�����ô˷�������Ҫ����CloseConnection���������ر����ӡ�
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="colParameters">ִ�е�SQL����洢���̵Ĳ������ϡ�</param>
		/// <returns>ִ������ص�ֻ�����������</returns>
		public IDataReader ExecuteReader(string commandText,CommandType commandType,DBParameterCollection colParameters)
		{			 
			if (colParameters!=null)
			{				
				return ExecuteReader(BatchSQLFilter(commandText),commandType,(IDbDataParameter[])colParameters);
			} 
			else 
			{
				return ExecuteReader(commandText,commandType,(IDbDataParameter[])colParameters);
			}
		}

		/// <summary>
		/// ִ��SQL�������SqlDataReader�����ô˷�������Ҫ����CloseConnection���������ر����ӡ�
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="commandParameters">�������</param>
		/// <returns>ִ������ص�ֻ�����������</returns>
		protected IDataReader ExecuteReader(string commandText,CommandType commandType,params IDbDataParameter[] commandParameters)
		{
			lock(this)
			{
				IDbCommand command=null;
				try
				{					
					DBParameterCollection spParam=null;
					OpenConnection();
					command=m_dbConnection.CreateCommand();
					command.CommandType=commandType;
					command.CommandText=commandText;
					command.CommandTimeout=m_nCmdTimeout;
					AttachParameters(command,commandParameters,spParam);
					if (HasTransaction() && m_dbTransaction != null ) 
					{
						command.Transaction=m_dbTransaction;					
						return command.ExecuteReader();
					} 
					else
					{
						return command.ExecuteReader(CommandBehavior.CloseConnection);					
					}				
				}
				catch
				{
					CloseConnection(true);
					throw;
				}		
				finally
				{
					if (command != null)
					{
						bool bClear=true;
						foreach(IDbDataParameter cmdParameter in command.Parameters)
						{
							if (cmdParameter.Direction != ParameterDirection.Input)
							{
								bClear=false;
								break;
							}
						}
						if (bClear)
						{
							command.Parameters.Clear();
						}
					}						
				}
			}
		}

		/// <summary>
		/// ��ͨ��������ִ��SQL��䣬����SqlDataReader�����ô˷�������Ҫ����CloseConnection���������ر����ӡ�
		/// </summary>
		/// <param name="commandText">ִ�е�SQL��䡣</param>
		/// <returns>ִ������ص�ֻ�����������</returns>
		public IDataReader ExecuteReader(string commandText)
		{
			return ExecuteReader(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// ��ͨ��������ִ�д洢���̣�����SqlDataReader�����ô˷�������Ҫ����CloseConnection���������ر����ӡ�
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="colParameters">�洢���̲������ϡ�</param>
		/// <returns>ִ������ص�ֻ�����������</returns>
		public IDataReader ExecuteReader(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteReader(spName,CommandType.StoredProcedure,(IDbDataParameter[])colParameters);
		}	
		#endregion

		#region ExecuteScalar ִ��SQL����洢���̣����ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л���


		/// <summary>
		/// ִ�д�������SQL�����洢���̣����ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л��С�
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="colParameters">ִ�е�SQL����洢���̵Ĳ������ϡ�</param>
		/// <returns>������е�һ�еĵ�һ�С�</returns>
		public object ExecuteScalar(string commandText,CommandType commandType,DBParameterCollection colParameters)
		{			
			if (colParameters!=null)
			{				
				return ExecuteScalar(BatchSQLFilter(commandText),commandType,(IDbDataParameter[])colParameters);
			}
			else
			{
				return ExecuteScalar(commandText,commandType,(IDbDataParameter[])colParameters);
			}			
		}

		/// <summary>
		/// ִ��SQL����洢���̣����ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л��С�
		/// </summary>		
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandType">�������͡�</param>
		/// <param name="commandParameters">�������</param>
		/// <returns>������е�һ�еĵ�һ�С�</returns>
		protected object ExecuteScalar(string commandText,CommandType commandType,params IDbDataParameter[] commandParameters)
		{
			lock(this)
			{
				IDbCommand command=null;
				try
				{						
					DBParameterCollection spParam=null;
					OpenConnection();
					command=m_dbConnection.CreateCommand();
					if (HasTransaction() && m_dbTransaction!=null ) 
					{
						command.Transaction=m_dbTransaction;					
					}
					command.CommandType=commandType;
					command.CommandText=commandText;
					command.CommandTimeout=m_nCmdTimeout;
					AttachParameters(command,commandParameters,spParam);			
				
					return command.ExecuteScalar();
				}
				catch
				{
					CloseConnection(true);				
					throw;
				}		
				finally
				{
					if (command!=null)
					{
						command.Parameters.Clear();
					}
					CloseConnection(false);				
				}
			}
		}

		/// <summary>
		/// ִ�в�ѯ�������ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л��С�
		/// </summary>
		/// <param name="commandText">SQL��䡣</param>
		/// <returns>������е�һ�еĵ�һ�С�</returns>
		public object ExecuteScalar(string commandText)
		{
			return ExecuteScalar(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// ִ�в�ѯ�������ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л��С�
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="colParameters">�洢���̲������ϡ�</param>
		/// <returns>������е�һ�еĵ�һ�С�</returns>
		public object ExecuteScalar(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteScalar(spName,CommandType.StoredProcedure,(IDbDataParameter[])colParameters);
		}
	
		#endregion		
		
		#region ConvertToDBString ת���ַ��ֶ���������ַ�
		/// <summary>
		/// ���ַ���������ַ�ת��Ϊ���ݿ�֧���ַ���ʽ��
		/// </summary>
		/// <param name="context">��Ҫת�����ַ���</param>
		/// <returns>ת������ַ���</returns>
		public virtual string ConvertToDBString(string context)
		{
			return context;
		}

		#endregion	
		
		#region ��ȡ����ֵ
		/// <summary>
		/// ��ȡ������ֵ������Nullת��ΪDBNull��GUIDExת��ΪString�ȡ�
		/// </summary>
		/// <param name="value">��Ҫת����ֵ��</param>
		/// <returns>ת�����ֵ��</returns>
		protected virtual object GetParameterValue(object value)
		{
			if (value==null)
			{
				return DBNull.Value;
			}

//			//GUIDEx
//			if (value is GUIDEx)
//			{
//				if (((GUIDEx)value).Value==null)
//				{
//					return DBNull.Value;
//				} 
//				else
//				{
//					return ((GUIDEx)value).Value;
//				}
//			}

			//System.Type
			if (value is Type)
			{				
				return ((Type)value).FullName;
			}
			
			//���ڣ����Ϊ��С��������ΪNull
			if (value is DateTime)
			{
				if ((DateTime)value == DateTime.MinValue)
				{
					return DBNull.Value;
				}
			}			
			return value;					
		}
		#endregion

		#region ��������ת�� 
		/// <summary>
		/// ���ݿ��������͵�.Net���͵�ת����
		/// </summary>
		/// <param name="type">���ݿ�����ֵ��DbTypeֵ��</param>
		/// <returns>ӳ����.Net�����͡�</returns>
		protected  System.Type ToDotNetType(DbType type)
		{			
			switch (type)
			{					
				case DbType.AnsiString:	
				case DbType.AnsiStringFixedLength:
				case DbType.String:
				case DbType.StringFixedLength:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.STRING);
				case DbType.Binary:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.ARRAY);			
				case DbType.Boolean:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.BOOLEAN);			
				case DbType.Byte:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.BYTE);			
				case DbType.Currency:
				case DbType.Decimal:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.DECIMAL);
				case DbType.Date:
				case DbType.Time:
				case DbType.DateTime:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.DATETIME);			
				case DbType.Double:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.DOUBLE);			
				case DbType.Guid:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.GUID);
				case DbType.Int16:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.INT16);
				case DbType.Int32:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.INT32);
				case DbType.Int64:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.INT64);			
				case DbType.Object:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.OBJECT);			
				case DbType.SByte:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.SBYTE);			
				case DbType.Single:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.SINGLE);				
				case DbType.UInt16:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.UINT16);			
				case DbType.UInt32:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.UINT32);			
				case DbType.UInt64:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.UINT64);			
				case DbType.VarNumeric:
				default:
					return System.Type.GetTypeFromCLSID(DotNetTypeGUID.OBJECT);					
			}
		}

		#endregion	

		#region �����ṩ��������
		/// <summary>
		/// ��ȡ�����ض����ݷ��ʳ��������ݱ����е��������͡�
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="columnName"></param>
		/// <returns></returns>
		public virtual int GetColumnProviderDataType(string tableName,string columnName)
		{
			DataTable dt=GetTableStructure(tableName);
			DataRow dr=dt.Rows.Find(new object[]{columnName});
			if (dr!=null)
			{
				return Convert.ToInt32(dr["ProviderType"]);
			}
			else
			{
				return (int)DbType.Object;
			}	
		}
		#endregion

		#region .Net������������
		/// <summary>
		/// .Net�����������͡�
		/// </summary>
		public sealed class DotNetTypeGUID
		{
			private DotNetTypeGUID(){}	
			/// <summary>
			/// ��ȡSystem.Array���͹�����GUID��
			/// </summary>
			public static readonly Guid ARRAY			=System.Type.GetType("System.Array").GUID;

			/// <summary>
			/// ��ȡSystem.Guid���͹�����GUID��
			/// </summary>
			public static readonly Guid GUID			=System.Type.GetType("System.Guid").GUID;				

			/// <summary>
			/// ��ȡSystem.DBNull���͹�����GUID��
			/// </summary>
			public static readonly Guid DBNULL			=System.Type.GetType("System.DBNull").GUID;						

			/// <summary>
			/// ��ȡSystem.Object���͹�����GUID��
			/// </summary>
			public static readonly Guid OBJECT			=System.Type.GetType("System.Object").GUID;
				
			/// <summary>
			/// ��ȡSystem.Boolean����(boolean)������GUID��
			/// </summary>
			public static readonly Guid BOOLEAN			=System.Type.GetType("System.Boolean").GUID;

			/// <summary>
			/// ��ȡSystem.Byte����(byte)������GUID��
			/// </summary>
			public static readonly Guid BYTE			=System.Type.GetType("System.Byte").GUID;

			/// <summary>
			/// ��ȡSystem.Char����(char)������GUID��
			/// </summary>
			public static readonly Guid CHAR			= System.Type.GetType("System.Char").GUID;				

			/// <summary>
			/// ��ȡSystem.DateTime���͹�����GUID��
			/// </summary>
			public static readonly Guid DATETIME		=System.Type.GetType("System.DateTime").GUID;

			/// <summary>
			/// ��ȡSystem.Decimal����(decimal)������GUID��
			/// </summary>
			public static readonly Guid DECIMAL			=System.Type.GetType("System.Decimal").GUID;			

			/// <summary>
			/// ��ȡSystem.Double����(double)������GUID��
			/// </summary>
			public static readonly Guid DOUBLE			=System.Type.GetType("System.Double").GUID;

			/// <summary>
			/// ��ȡSystem.Int16����(short)������GUID��
			/// </summary>
			public static readonly Guid INT16			=System.Type.GetType("System.Int16").GUID;

			/// <summary>
			/// ��ȡSystem.Int32����(int)������GUID��
			/// </summary>
			public static readonly Guid INT32			=System.Type.GetType("System.Int32").GUID;

			/// <summary>
			/// ��ȡSystem.Int64����(long)������GUID��
			/// </summary>
			public static readonly Guid INT64			=System.Type.GetType("System.Int64").GUID;

			/// <summary>
			/// ��ȡSystem.SByte����(sbyte)������GUID��
			/// </summary>
			public static readonly Guid SBYTE			=System.Type.GetType("System.SByte").GUID;

			/// <summary>
			/// ��ȡSystem.Single����(float)������GUID��
			/// </summary>
			public static readonly Guid SINGLE			=System.Type.GetType("System.Single").GUID;

			/// <summary>
			/// ��ȡSystem.String����(string)������GUID��
			/// </summary>
			public static readonly Guid STRING			=System.Type.GetType("System.String").GUID;

			/// <summary>
			/// ��ȡSystem.TimeSpan���͹�����GUID��
			/// </summary>
			public static readonly Guid TIMESPAN		=System.Type.GetType("System.TimeSpan").GUID;

			/// <summary>
			/// ��ȡSystem.UInt16����(ushort)������GUID��
			/// </summary>
			public static readonly Guid UINT16			=System.Type.GetType("System.UInt16").GUID;

			/// <summary>
			/// ��ȡSystem.UInt32����(uint)������GUID��
			/// </summary>
			public static readonly Guid UINT32			=System.Type.GetType("System.UInt32").GUID;

			/// <summary>
			/// ��ȡSystem.UInt64����(ulong)������GUID��
			/// </summary>
			public static readonly Guid UINT64			=System.Type.GetType("System.UInt64").GUID;			
			/// <summary>
			/// ��ȡSystem.Enum����(Enum)������GUID��
			/// </summary>
			public static readonly Guid ENUM			=System.Type.GetType("System.Enum").GUID;		
		}	
		#endregion
	}
}
