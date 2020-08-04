// ================================================================================
// 		File: DBAccess.cs
// 		Desc: 数据库访问接口类。提供所有数据库的访问接口。            
// 		Auth: 林阳
// 		Date: 2007年4月12日
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
	/// 数据库访问的抽象基类，实现公用的数据库访问方法。
	/// </summary>
	public abstract class DBAccess
	{		
		#region 成员变量和构造函数
		//数据表结构，GetSchemaTable获取，以connectionString+":"+tableName为键值，存放表结构的DataTable
		static Hashtable m_htbTables;
		//数据表的结构，FillSchema获取，以connectionString+":"+tableName为键值，存放单行的DataTable
		static Hashtable m_htbTableSchema;		
		//存储过程的参数字段数据集合，以connectionString+":"+spName为键值，存放存储过程的参数DataTable
		static Hashtable m_htbSPs;
		//存储过程参数集合，以ConnectionString+":"+spName为键值，存放存储过程的参数DBParameterCollection
		/// <summary>
		/// 存储过程参数的缓存。
		/// </summary>
		static Hashtable m_htbSPParameters;
		/// <summary>
		/// 执行命令的超时时间，以秒为单位。
		/// </summary>
		int m_nCmdTimeout;
		/// <summary>
		/// 分析参数用的正则表达式。(Access的批量操作参数顺序和语句中引用的顺序相同）
		/// </summary>
		protected static Regex m_regParameter;
		/// <summary>
		/// 数据库连接。
		/// </summary>
		protected IDbConnection m_dbConnection;
		/// <summary>
		/// 数据库事务。
		/// </summary>
		protected IDbTransaction m_dbTransaction;
		/// <summary>
		/// 数据库事务数目。
		/// </summary>
		protected ushort m_TransCount;
		/// <summary>
		/// 初始化 DBAccess 类的新实例。
		/// </summary>
		protected DBAccess()
		{
			m_dbTransaction=null;
			m_dbConnection=null;
			m_TransCount=0;
			m_nCmdTimeout=30;			
		}

		/// <summary>
		/// 初始化 DBAccess 类的静态实例。
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

		#region 连接字符串
		/// <summary>
		/// 获取连接字符串。
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

		#region 执行命令的超时时间，默认为不限时
		/// <summary>
		/// 获取或设置在终止执行命令的尝试并生成错误之前的等待时间
		/// ，默认为30秒（0表示无限制，尽量避免使用）。
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
		
		#region 连接的打开和关闭
		/// <summary>
		/// 打开数据库连接。
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
		/// 关闭数据库连接，回滚事务。
		/// </summary>
		public void CloseConnection()
		{
			CloseConnection(true);
		}

		/// <summary>
		/// 关闭数据库连接。
		/// </summary>
		/// <param name="bCloseTrans">是否回滚事务，true表示回滚事务，false表示不处理有事务的连接。</param>
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

		#region 事务管理
		/// <summary>
		/// 开始数据库事务（不支持并行事务要重载该函数）。
		/// </summary>
		/// <returns>成功启动事务则返回true，否则返回false。</returns>
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
		/// 是否存在事务。
		/// </summary>
		/// <returns>存在事务则返回true，否则返回false。</returns>
		public bool HasTransaction()
		{
			return (m_TransCount>0);
		}

		/// <summary>
		/// 提交当前数据库事务。
		/// </summary>
		/// <returns>成功提交事务则返回true，否则返回false。</returns>
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
		/// 回滚当前数据库事务。
		/// </summary>
		/// <returns>成功回滚事务则返回true，否则返回false。</returns>
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

		#region 创建存储过程参数
		/// <summary>
		/// 新建存储过程或查询语句中的参数 IDbDataParameter 接口。
		/// </summary>
		public abstract IDbDataParameter CreateParameter();
		/// <summary>
		/// 用参数名称和对应初始化值初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,object value);	
		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType);		
		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,object value);
		/// <summary>
		/// 用参数名称、DbType 和大小初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="size">参数的长度。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size);	
		/// <summary>
		/// 用参数名、DbType、大小及源列名初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,string sourceColumn);		
		/// <summary>
		/// 用参数名称、参数的类型、参数的大小、ParameterDirection、参数的精度、参数的小数位数、源列、
		/// 要使用的 DataRowVersion 和参数的值初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="direction">ParameterDirection 值之一。</param>
		/// <param name="isNullable">如果该字段的值可为空，则为 true，否则为 false。</param>
		/// <param name="precision">要将 Value 解析为的小数点左右两侧的总位数。</param>
		/// <param name="scale">要将 Value 解析为的总小数位数。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <param name="sourceVersion">DataRowVersion 值之一。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,ParameterDirection direction,bool isNullable,byte precision,byte scale,string sourceColumn,DataRowVersion sourceVersion,object value);		
		/// <summary>
		/// 用指定参数初始化 IDbDataParameter接口。
		/// </summary>
		/// <param name="param">要创建参数的基础参数。</param>		
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public abstract IDbDataParameter CreateParameter(IDbDataParameter param);
		#endregion

		#region 创建数据提供程序类型相关参数
		/// <summary>
		/// 用参数名称和数据提供程序类型初始化 IDbDataParameter接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType);
		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,object value);
		/// <summary>
		/// 用参数名称、DbType 和大小初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="size">参数的长度。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size);	
		/// <summary>
		/// 用参数名、数据提供程序类型、大小及源列名初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size,string sourceColumn);		
		/// <summary>
		/// 用参数名称、参数的数据提供程序类型、参数的大小、ParameterDirection、参数的精度、参数的小数位数、源列、
		/// 要使用的 DataRowVersion 和参数的值初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="direction">ParameterDirection 值之一。</param>
		/// <param name="isNullable">如果该字段的值可为空，则为 true，否则为 false。</param>
		/// <param name="precision">要将 Value 解析为的小数点左右两侧的总位数。</param>
		/// <param name="scale">要将 Value 解析为的总小数位数。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <param name="sourceVersion">DataRowVersion 值之一。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected abstract IDbDataParameter CreateParameter(string parameterName,int providerType,int size,ParameterDirection direction,bool isNullable,byte precision,byte scale,string sourceColumn,DataRowVersion sourceVersion,object value);
		#endregion		
		
		#region 获取首行的数据的SQL
		/// <summary>
		/// 获取获取表首行的SQL语句。
		/// </summary>
		/// <param name="tableName">要获取记录的表名称。</param>
		/// <returns>用户获取第一条记录的SQL语句。</returns>
		protected abstract string GetFirstRowSQL(string tableName);		
		#endregion

		#region 获取数据表和存储过程的结构参数
		/// <summary>
		/// 获取表结构(可以用来进行BatchInsert、BatchDelete、BatchUpdate的结构)。
		/// </summary>
		/// <param name="tableName">数据库表名称。</param>
		/// <param name="clone">是获取结构还是获取Clone结果，true表示获取Clone结果。</param>
		/// <returns>获取指定数据表的表结构。</returns>
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
		/// 返回表结构(请使用前用Clone方法获取结构)。
		/// </summary>				
		/// <param name="tableName">表名称。</param>
		/// <returns>返回数据表的架构信息。</returns>
		public DataTable GetTableSchema(string tableName)
		{
			return GetTableSchema(tableName,true);	
		}

		/// <summary>
		/// 获取给定数据表的数据行结构集合。
		/// </summary>
		/// <param name="tableName">数据表名称。</param>
		/// <returns>数据表的一个行结构。</returns>
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
		/// 获取给定数据表的数据行结构集合。
		/// 返回对给定表创建一个插入记录用的Hashtable，以表字段名为Key。
		/// </summary>
		/// <param name="tableName">数据表名称。</param>
		/// <returns>以表字段为Key的Hashtable。</returns>
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
		/// 获取数据表的字段结构。
		/// </summary>
		/// <param name="tableName">数据表名称。</param>
		/// <returns>表结构的结果集。</returns>
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
		/// 数据表的某一列是否是自增长类型。
		/// </summary>
		/// <param name="tableName">要获取结构的数据表名称。</param>
		/// <param name="columnName">要判定的数据列名称。</param>
		/// <returns>如果是自增字段则返回true，否则返回false。</returns>
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
		/// 数据表中的某一列是否允许空值。
		/// </summary>
		/// <param name="tableName">要获取结构的数据表名称。</param>
		/// <param name="columnName">要判定的数据列名称。</param>
		/// <returns>如果用许空值则返回true，否则返回false。</returns>
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
		/// 获取数据表中某一列的默认值。
		/// </summary>
		/// <param name="tableName">要获取结构的数据表名称。</param>
		/// <param name="columnName">要获取默认值的数据列名称。</param>
		/// <returns>数据表中某一列的默认值。</returns>
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
		/// 从在 IDbCommand 中指定的存储过程检索参数信息并填充指定 IDbCommand 对象的 Parameters 集合。
		/// </summary>
		/// <param name="cmd">引用将从其中导出参数信息的存储过程的 IDbCommand。派生参数会被添加到 IDbCommand 的 Parameters 集合中。</param>
		protected abstract void DeriveParameters(IDbCommand cmd);

		/// <summary>
		/// 获取存储过程的参数集合。
		/// </summary>
		/// <param name="spName">存储过程名称</param>		
		/// <returns>存储过程的参数集合。</returns>
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
		/// 获取存储过程的参数结构集合。
		/// 返回存储过程参数列表的Hashtable，以存储过程参数名为Key（包含@）。
		/// </summary>
		/// <param name="spName">要获取参数列表的存储过程名称。</param>
		/// <returns>以存储过程参数为Key的Hashtable。</returns>
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

		#region 获取命令
		/// <summary>
		/// 创建新的数据库操作命令。
		/// </summary>
		/// <returns>创建的数据库接口。</returns>
		public IDbCommand CreateCommand()
		{
			return this.m_dbConnection.CreateCommand();			
		}
		#endregion

		#region 按照执行语句里参数顺序排序参数 
		/// <summary>
		/// 将数据库访问参数按照执行语句的顺序排序。
		/// （用于外部创建的参数，Access需要调用参数顺序一致）
		/// </summary>
		/// <param name="commandText">执行的带参数的语句。</param>
		/// <param name="paramCollection">需要调整的参数集合。</param>
		/// <returns>按照语句中的参数顺序排列的参数集合。</returns>
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

		#region 处理SQL语句（参数和特殊符号）
		/// <summary>
		/// 将带参数的批量操作命令进行处理。
		/// </summary>
		/// <param name="commandText">进行批量操作的带参数的命令字符串。</param>
		/// <returns>处理后的可用于相应DataAdapter的SQL语句。</returns>
		protected virtual string BatchSQLFilter(string commandText)
		{
			return commandText;
		}


		/// <summary>
		/// 获取连接字符串的操作符。
		/// </summary>
		public virtual string StringJoinOperator
		{
			get
			{
				return "+";
			}
		}		
		#endregion

		#region 获取批量操作BatchDelete、BatchUpdate、BatchInsert、BatchExecute的参数
		/// <summary>
		/// 获取批量插入数据的各种参数。
		/// </summary>
		/// <param name="tableName">插入的数据表的名称。</param>		
		/// <param name="includeCols">插入数据时包括的数据行。</param>
		/// <param name="primaryCols">内存数据表的主键。</param>
		/// <param name="table">插入数据的内存表的数据结构。</param>
		/// <param name="insertSql">插入数据时的插入语句。</param>
		/// <returns>插入数据所需参数。</returns>
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
		/// 获取批量插入数据的各种参数。
		/// </summary>
		/// <param name="tableName">插入的数据表的名称。</param>
		/// <param name="dtValue">将要进行批量操作的数据表。</param>		
		/// <param name="includeCols">插入数据时包括的数据行。</param>
		/// <param name="primaryCols">内存数据表的主键。</param>
		/// <param name="table">插入数据的内存表的数据结构。</param>
		/// <param name="insertSql">插入数据时的插入语句。</param>
		/// <returns>插入数据所需参数。</returns>
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
		/// 获取批量删除数据的各种参数。
		/// </summary>
		/// <param name="tableName">删除的数据表的名称。</param>		
		/// <param name="includeCols">删除数据时包括的数据行。</param>
		/// <param name="whereCols">更新数据表时的条件字段。</param>
		/// <param name="primaryCols">删除的数据内存数据表的主键。</param>
		/// <param name="table">删除数据的内存表的数据结构。</param>
		/// <param name="deleteSql">删除数据时的删除语句。</param>
		/// <returns>删除数据所需参数。</returns>
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
		/// 获取批量删除数据的各种参数。
		/// </summary>
		/// <param name="tableName">删除的数据表的名称。</param>
		/// <param name="dtValue">将要进行批量操作的数据表。</param>
		/// <param name="includeCols">删除数据时包括的数据行。</param>
		/// <param name="whereCols">更新数据表时的条件字段。</param>
		/// <param name="primaryCols">删除的数据内存数据表的主键。</param>
		/// <param name="table">删除数据的内存表的数据结构。</param>
		/// <param name="deleteSql">删除数据时的删除语句。</param>
		/// <returns>删除数据所需参数。</returns>
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
		/// 获取批量更新数据的各种参数。
		/// </summary>
		/// <param name="tableName">更新的数据表的名称。</param>		
		/// <param name="includeCols">更新数据时包括的数据行。</param>
		/// <param name="whereCols">更新数据表时的条件字段。</param>
		/// <param name="primaryCols">内存数据表的主键。</param>
		/// <param name="table">更新数据的内存表的数据结构。</param>
		/// <param name="updateSql">更新数据时的更新语句。</param>
		/// <returns>更新数据所需参数。</returns>
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
		/// 获取批量更新数据的各种参数。
		/// </summary>
		/// <param name="tableName">更新的数据表的名称。</param>
		/// <param name="dtValue">将要进行批量操作的数据表。</param>		
		/// <param name="includeCols">更新数据时包括的数据行。</param>
		/// <param name="whereCols">更新数据表时的条件字段。</param>
		/// <param name="primaryCols">内存数据表的主键。</param>
		/// <param name="table">更新数据的内存表的数据结构。</param>
		/// <param name="updateSql">更新数据时的更新语句。</param>
		/// <returns>更新数据所需参数。</returns>
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
		/// 获取批量操作的存储过程执行命令和参数和内存表结构列表。
		/// 用BatchExecute来执行相应批量操作。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="includeCols">批量操作涉及的列。</param>
		/// <param name="primaryCols">内存表中数据存储的关键字段。</param>		
		/// <param name="table">内存表的表结构。</param>
		/// <returns>执行批量操作的命令。</returns>
		public IDbCommand GetBatchSPParameters(string spName, StringCollection includeCols, StringCollection primaryCols, out DataTable table)
		{
			DBParameterCollection spParams;
			return GetBatchSPParameters(spName,includeCols,primaryCols,out spParams,out table);
		}

		/// <summary>
		/// 获取批量操作的存储过程执行命令和参数和内存表结构列表。
		/// 用BatchExecute来执行相应批量操作。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="includeCols">批量操作涉及的列。</param>
		/// <param name="primaryCols">内存表中数据存储的关键字段。</param>
		/// <param name="spParams">存储过程参数。</param>
		/// <param name="table">内存表的表结构。</param>
		/// <returns>执行批量操作的命令。</returns>
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
		
			//存储过程参数								
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
		
		#region 存储过程参数赋值处理
		/// <summary>
		/// 为特定的数据库提供程序处理SQL语句。
		/// </summary>
		/// <param name="command">需要处理的命令。</param>
		protected virtual void AttachCommandText(ref IDbCommand command)
		{
			return;
		}

		/// <summary>
		/// 附加存储过程参数到指定命令。
		/// </summary>
		/// <param name="command">被附加参数的命令。</param>
		/// <param name="parameters">附加的参数。</param>
		/// <param name="commandParameters">附加的参数集合，如果该command为存储过程，则为存储过程的参数。</param>
		protected virtual void AttachParameters(IDbCommand command, IDbDataParameter[] parameters,DBParameterCollection commandParameters)
		{
			if( command == null ) 
			{
				return;
			}					
			AttachCommandText(ref command);
			//传入参数
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
			//额外参数
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
		/// 为存储过程的参数赋值。
		/// </summary>
		/// <param name="commandParameters">存储过程的参数。</param>
		/// <param name="values">存储过程的参数的值，以存储过程的参数名称为key。</param>
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

		#region ExecuteNonQuery 执行SQL语句或存储过程，返回影响的行数
		/// <summary>
		/// 执行带参数的SQL命令或存储过程，返回影响的数据行数。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="colParameters">执行的SQL语句或存储过程的参数集合。</param>
		/// <returns>命令影响的行数。</returns>
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
		/// 执行SQL命令，返回影响的数据行数。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="commandParameters">命令参数</param>
		/// <returns>命令影响的行数。</returns>
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
		/// 在通用连接上执行SQL语句。
		/// </summary>
		/// <param name="commandText">执行的SQL语句。</param>
		/// <returns>Insert,Delete,Update操作返回影响的行数，其他返回-1。</returns>
		public int ExecuteNonQuery(string commandText)
		{
			return ExecuteNonQuery(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// 执行存储过程，返回影响的数据行数和参数值。
		/// </summary>
		/// <param name="spName">存储过程名称</param>
		/// <param name="htbValue">以存储过程参数为Key的Hashtable，由GetSPStructureEx创建，返回时带回Out类型的值。</param>
		/// <returns>Insert,Delete,Update操作返回影响的行数，其他返回-1。</returns>
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
		/// 在通用连接上执行存储过程，无结果集返回。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="colParameters">存储过程参数集合。</param>
		/// <returns>Insert,Delete,Update操作返回影响的行数，其他返回-1。</returns>
		public int ExecuteNonQuery(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteNonQuery(spName,CommandType.StoredProcedure,(IDbDataParameter[]) colParameters);
		}
		#endregion
	
		#region ExecuteDataset 执行SQL语句或存储过程，返回数据集
		
		/// <summary>
		/// 提供数据桥接器。
		/// </summary>
		/// <param name="command">生成桥接器的命令。</param>
		/// <returns>返回数据桥接器，用来填充DataSet。</returns>
		protected abstract IDbDataAdapter CreateAdapter(IDbCommand command);
		/// <summary>
		/// 提供数据桥接器。
		/// </summary>		
		/// <returns>返回数据桥接器，用来进行批量操作。</returns>
		protected abstract IDbDataAdapter CreateAdapter();

		/// <summary>
		/// 执行带参数的SQL命令或存储过程，返回结果集。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="colParameters">执行的SQL语句或存储过程的参数集合。</param>
		/// <returns>执行命令返回的结果集。</returns>
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
		/// 执行SQL命令，返回结果集。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="commandParameters">命令参数</param>
		/// <returns>执行命令返回的结果集。</returns>
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
		/// 在通用连接上执行SQL语句。
		/// </summary>
		/// <param name="commandText">执行的SQL语句。</param>
		/// <returns>该操作获取的结果集。</returns>
		public DataSet ExecuteDataset(string commandText)
		{
			return ExecuteDataset(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// 执行存储过程，获取结果集和参数值。
		/// </summary>
		/// <param name="spName">存储过程名称</param>
		/// <param name="htbValue">以存储过程参数为Key的Hashtable，由GetSPStructureEx创建，返回时带回Out类型的值。</param>
		/// <returns>该操作获取的结果集。</returns>
		protected DataSet ExecuteDataset(string spName,ref Hashtable htbValue)
		{
			IDbDataParameter[] commandParameters=(IDbDataParameter[])GetSPParametersEx(spName);
			AssignParameterValues(commandParameters,htbValue);
			return ExecuteDataset(spName,CommandType.StoredProcedure,commandParameters);
		}

		/// <summary>
		/// 在通用连接上执行存储过程，返回结果集。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="colParameters">存储过程参数集合。</param>
		/// <returns>该操作获取的结果集。</returns>
		public DataSet ExecuteDataset(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteDataset(spName,CommandType.StoredProcedure,(IDbDataParameter[]) colParameters);
		}
		#endregion
		
		#region ExecuteReader 执行SQL语句或存储过程，返回只进结果集流
		
		/// <summary>
		/// 执行带参数的SQL命令或存储过程，返回SqlDataReader，调用此方法后需要调用CloseConnection（）方法关闭连接。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="colParameters">执行的SQL语句或存储过程的参数集合。</param>
		/// <returns>执行命令返回的只进结果集流。</returns>
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
		/// 执行SQL命令，返回SqlDataReader，调用此方法后需要调用CloseConnection（）方法关闭连接。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="commandParameters">命令参数</param>
		/// <returns>执行命令返回的只进结果集流。</returns>
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
		/// 在通用连接上执行SQL语句，返回SqlDataReader，调用此方法后需要调用CloseConnection（）方法关闭连接。
		/// </summary>
		/// <param name="commandText">执行的SQL语句。</param>
		/// <returns>执行命令返回的只进结果集流。</returns>
		public IDataReader ExecuteReader(string commandText)
		{
			return ExecuteReader(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// 在通用连接上执行存储过程，返回SqlDataReader，调用此方法后需要调用CloseConnection（）方法关闭连接。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="colParameters">存储过程参数集合。</param>
		/// <returns>执行命令返回的只进结果集流。</returns>
		public IDataReader ExecuteReader(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteReader(spName,CommandType.StoredProcedure,(IDbDataParameter[])colParameters);
		}	
		#endregion

		#region ExecuteScalar 执行SQL语句或存储过程，返回查询所返回的结果集中第一行的第一列。忽略额外的列或行


		/// <summary>
		/// 执行带参数的SQL命令或存储过程，返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="colParameters">执行的SQL语句或存储过程的参数集合。</param>
		/// <returns>结果集中第一行的第一列。</returns>
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
		/// 执行SQL语句或存储过程，返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
		/// </summary>		
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandType">命令类型。</param>
		/// <param name="commandParameters">命令参数</param>
		/// <returns>结果集中第一行的第一列。</returns>
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
		/// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
		/// </summary>
		/// <param name="commandText">SQL语句。</param>
		/// <returns>结果集中第一行的第一列。</returns>
		public object ExecuteScalar(string commandText)
		{
			return ExecuteScalar(commandText,CommandType.Text,(IDbDataParameter[])null);
		}

		/// <summary>
		/// 执行查询，并返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="colParameters">存储过程参数集合。</param>
		/// <returns>结果集中第一行的第一列。</returns>
		public object ExecuteScalar(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteScalar(spName,CommandType.StoredProcedure,(IDbDataParameter[])colParameters);
		}
	
		#endregion		
		
		#region ConvertToDBString 转化字符字段里的特殊字符
		/// <summary>
		/// 将字符里的特殊字符转化为数据库支持字符格式。
		/// </summary>
		/// <param name="context">需要转化的字符。</param>
		/// <returns>转化后的字符。</returns>
		public virtual string ConvertToDBString(string context)
		{
			return context;
		}

		#endregion	
		
		#region 获取参数值
		/// <summary>
		/// 获取参数的值，比如Null转化为DBNull、GUIDEx转化为String等。
		/// </summary>
		/// <param name="value">需要转化的值。</param>
		/// <returns>转化后的值。</returns>
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
			
			//日期，如果为最小日期则视为Null
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

		#region 各种类型转化 
		/// <summary>
		/// 数据库数据类型到.Net类型的转化。
		/// </summary>
		/// <param name="type">数据库类型值，DbType值。</param>
		/// <returns>映射后的.Net的类型。</returns>
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

		#region 数据提供程序类型
		/// <summary>
		/// 获取用于特定数据访问程序下数据表中列的数据类型。
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

		#region .Net基本数据类型
		/// <summary>
		/// .Net基本数据类型。
		/// </summary>
		public sealed class DotNetTypeGUID
		{
			private DotNetTypeGUID(){}	
			/// <summary>
			/// 获取System.Array类型关联的GUID。
			/// </summary>
			public static readonly Guid ARRAY			=System.Type.GetType("System.Array").GUID;

			/// <summary>
			/// 获取System.Guid类型关联的GUID。
			/// </summary>
			public static readonly Guid GUID			=System.Type.GetType("System.Guid").GUID;				

			/// <summary>
			/// 获取System.DBNull类型关联的GUID。
			/// </summary>
			public static readonly Guid DBNULL			=System.Type.GetType("System.DBNull").GUID;						

			/// <summary>
			/// 获取System.Object类型关联的GUID。
			/// </summary>
			public static readonly Guid OBJECT			=System.Type.GetType("System.Object").GUID;
				
			/// <summary>
			/// 获取System.Boolean类型(boolean)关联的GUID。
			/// </summary>
			public static readonly Guid BOOLEAN			=System.Type.GetType("System.Boolean").GUID;

			/// <summary>
			/// 获取System.Byte类型(byte)关联的GUID。
			/// </summary>
			public static readonly Guid BYTE			=System.Type.GetType("System.Byte").GUID;

			/// <summary>
			/// 获取System.Char类型(char)关联的GUID。
			/// </summary>
			public static readonly Guid CHAR			= System.Type.GetType("System.Char").GUID;				

			/// <summary>
			/// 获取System.DateTime类型关联的GUID。
			/// </summary>
			public static readonly Guid DATETIME		=System.Type.GetType("System.DateTime").GUID;

			/// <summary>
			/// 获取System.Decimal类型(decimal)关联的GUID。
			/// </summary>
			public static readonly Guid DECIMAL			=System.Type.GetType("System.Decimal").GUID;			

			/// <summary>
			/// 获取System.Double类型(double)关联的GUID。
			/// </summary>
			public static readonly Guid DOUBLE			=System.Type.GetType("System.Double").GUID;

			/// <summary>
			/// 获取System.Int16类型(short)关联的GUID。
			/// </summary>
			public static readonly Guid INT16			=System.Type.GetType("System.Int16").GUID;

			/// <summary>
			/// 获取System.Int32类型(int)关联的GUID。
			/// </summary>
			public static readonly Guid INT32			=System.Type.GetType("System.Int32").GUID;

			/// <summary>
			/// 获取System.Int64类型(long)关联的GUID。
			/// </summary>
			public static readonly Guid INT64			=System.Type.GetType("System.Int64").GUID;

			/// <summary>
			/// 获取System.SByte类型(sbyte)关联的GUID。
			/// </summary>
			public static readonly Guid SBYTE			=System.Type.GetType("System.SByte").GUID;

			/// <summary>
			/// 获取System.Single类型(float)关联的GUID。
			/// </summary>
			public static readonly Guid SINGLE			=System.Type.GetType("System.Single").GUID;

			/// <summary>
			/// 获取System.String类型(string)关联的GUID。
			/// </summary>
			public static readonly Guid STRING			=System.Type.GetType("System.String").GUID;

			/// <summary>
			/// 获取System.TimeSpan类型关联的GUID。
			/// </summary>
			public static readonly Guid TIMESPAN		=System.Type.GetType("System.TimeSpan").GUID;

			/// <summary>
			/// 获取System.UInt16类型(ushort)关联的GUID。
			/// </summary>
			public static readonly Guid UINT16			=System.Type.GetType("System.UInt16").GUID;

			/// <summary>
			/// 获取System.UInt32类型(uint)关联的GUID。
			/// </summary>
			public static readonly Guid UINT32			=System.Type.GetType("System.UInt32").GUID;

			/// <summary>
			/// 获取System.UInt64类型(ulong)关联的GUID。
			/// </summary>
			public static readonly Guid UINT64			=System.Type.GetType("System.UInt64").GUID;			
			/// <summary>
			/// 获取System.Enum类型(Enum)关联的GUID。
			/// </summary>
			public static readonly Guid ENUM			=System.Type.GetType("System.Enum").GUID;		
		}	
		#endregion
	}
}
