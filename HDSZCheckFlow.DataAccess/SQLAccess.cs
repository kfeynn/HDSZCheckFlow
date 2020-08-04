// ================================================================================
// 		File: SQLAccess.cs
// 		Desc: SQL Server数据库访问类
//			用于对数据库的调用，本类封装对数据库的访问。
//			提供一般的数据库操作；数据查询操作；数据读取操作。             
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
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;
using HDSZCheckFlow.Common.Config;
  
namespace HDSZCheckFlow.DataAccess
{
	/// <summary>
	/// Summary description for SQLAccess.
	/// </summary>
	public sealed class SQLAccess:DBAccess
	{
		#region 成员变量和构造函数

		#endregion

		#region 不支持并发事务
		/// <summary>
		/// 启动非并发事务。
		/// </summary>
		/// <returns>如果启动成功则返回true，否则返回false。</returns>
		public override bool BeginTransaction()
		{
			if (this.HasTransaction())
			{
				return false;
			}
			return base.BeginTransaction ();
		}

		#endregion

		#region 获取首行的数据的SQL
		/// <summary>
		/// 获取获取表首行的SQL语句。
		/// </summary>
		/// <param name="tableName">要获取记录的表名称。</param>
		/// <returns>用户获取第一条记录的SQL语句。</returns>
		protected override string GetFirstRowSQL(string tableName)
		{
			return "select top 0 * from "+tableName;
		}	
		#endregion

		#region 成员变量、构造函数和析构函数		

		/// <summary>
		/// 默认构造函数，用Web.Config里的配置作为连接字符串初始化连接。
		/// </summary>
		public SQLAccess():this(GlobalConfiguration.ConnectionString){}
		
		/// <summary>
		/// 用传入的服务器名称，数据库名称，用户名称，密码来组织连接字符串初始化连接。
		/// </summary>
		/// <param name="server">服务器地址（或名称）。</param>
		/// <param name="database">数据库名称。</param>
		/// <param name="user">用户ID。</param>
		/// <param name="password">密码。</param>
		public SQLAccess(string server,string database,string user,string password)
			:this("user id="+user+";password="+password+";data source="+server+";initial catalog="+database)
		{					
		}

		/// <summary>
		/// 直接传入组织好的连接字符串初始化连接。
		/// </summary>
		/// <param name="connectionString">连接字符串。</param>
		public SQLAccess(string connectionString):this(new SqlConnection(connectionString))
		{						
		}	

		/// <summary>
		/// 直接传入数据库连接初始化连接。
		/// </summary>
		/// <param name="connection">数据库连接。</param>
		public SQLAccess(SqlConnection connection)
		{
			if (connection==null)
			{
				m_dbConnection=new SqlConnection(GlobalConfiguration.ConnectionString);
			} 
			else
			{
				m_dbConnection=connection;
			}								
		}
		
		/// <summary>
		/// 清除事务，释放连接（回滚事务）。
		/// </summary>
		~SQLAccess()
		{
			CloseConnection();				
		}		
		#endregion

		#region 创建SQL命令或存储过程参数
		/// <summary>
		/// 新建存储过程或查询语句中的参数 IDbDataParameter 接口。
		/// </summary>
		public override IDbDataParameter CreateParameter()
		{
			return new SqlParameter();
		}
		/// <summary>
		/// 用参数名称和对应初始化值初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(string parameterName,object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.Value=GetParameterValue(value);		
			return parameter;
		}
		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;			
			return parameter;
		}

		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;	
			parameter.Value=GetParameterValue(value);
			return parameter;
		}

		/// <summary>
		/// 用参数名称、DbType 和大小初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="size">参数的长度。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;
			parameter.Size=size;
			return parameter;
		}
		/// <summary>
		/// 用参数名、DbType、大小及源列名初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="dbType">DbType 值之一。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,string sourceColumn)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;
			parameter.Size=size;			
			parameter.SourceColumn=sourceColumn;			
			return parameter;
		}
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
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size,ParameterDirection direction,bool isNullable,byte precision,byte scale,string sourceColumn,DataRowVersion sourceVersion,object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;
			parameter.Size=size;
			parameter.Direction=direction;
			parameter.IsNullable=isNullable;	
			parameter.Precision=precision;
			parameter.Scale=scale;
			parameter.SourceColumn=sourceColumn;
			parameter.SourceVersion=sourceVersion;
			parameter.Value=GetParameterValue(value);
			return parameter;
		}
		/// <summary>
		/// 用指定参数初始化 IDbDataParameter接口。
		/// </summary>
		/// <param name="param">要创建参数的基础参数。</param>		
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		public override IDbDataParameter CreateParameter(IDbDataParameter param)
		{
			return CreateParameter(param.ParameterName,(int)((SqlParameter)param).SqlDbType,param.Size,param.Direction,param.IsNullable,param.Precision,param.Scale,param.SourceColumn,param.SourceVersion,param.Value);
		}
		#endregion

		#region SqlServer提供程序相关参数创建
		/// <summary>
		/// 用参数名称和数据提供程序类型初始化 IDbDataParameter接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType);
		}		
		/// <summary>
		/// 用参数名称、数据提供程序类型 和大小初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="size">参数的长度。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size);
		}		
		/// <summary>
		/// 用参数名、数据提供程序类型、大小及源列名初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="size">参数的长度。</param>
		/// <param name="sourceColumn">源列的名称。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size, string sourceColumn)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size,sourceColumn);
		}		
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
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size,direction,isNullable, precision, scale,sourceColumn, sourceVersion,value);
		}

		/// <summary>
		/// 用参数名称和数据类型初始化 IDbDataParameter 接口。
		/// </summary>
		/// <param name="parameterName">要映射的参数的名称。</param>
		/// <param name="providerType">数据提供程序支持的类型。</param>
		/// <param name="value">一个 Object，它是 IDbDataParameter 的值。</param>
		/// <returns>用指定参数初始化后的IDbDataParameter接口。</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.SqlDbType=(SqlDbType)providerType;	
			parameter.Value=GetParameterValue(value);
			return parameter;
		}
		#endregion
		
		#region 实现DeriveParameters和CreateAdapter接口

		/// <summary>
		/// 从在 IDbCommand 中指定的存储过程检索参数信息并填充指定 IDbCommand 对象的 Parameters 集合。
		/// </summary>
		/// <param name="cmd">引用将从其中导出参数信息的存储过程的 IDbCommand。派生参数会被添加到 IDbCommand 的 Parameters 集合中。</param>
		protected override void DeriveParameters(IDbCommand cmd)
		{
			SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
		}

		/// <summary>
		/// 提供Sql Server数据桥接器。
		/// </summary>
		/// <param name="command">生成桥接器的命令。</param>
		/// <returns>返回数据桥接器，用来填充DataSet。</returns>
		protected override IDbDataAdapter CreateAdapter(IDbCommand command)
		{
			return new SqlDataAdapter((SqlCommand)command);
		}

		/// <summary>
		/// 提供Sql Server数据桥接器。
		/// </summary>
		/// <returns>返回数据桥接器，用来填充DataSet。</returns>
		protected override IDbDataAdapter CreateAdapter()
		{
			return new SqlDataAdapter();
		}

		#endregion			
		
		#region 按照执行语句里参数顺序排序参数 
		/// <summary>
		/// 将数据库访问参数按照执行语句的顺序排序。		
		/// </summary>
		/// <param name="commandText">执行的带参数的语句。</param>
		/// <param name="paramCollection">需要调整的参数集合。</param>
		/// <returns>按照语句中的参数顺序排列的参数集合。</returns>
		public override DBParameterCollection SortParameterCollection(string commandText,DBParameterCollection paramCollection)
		{
			return paramCollection;			
		}
		#endregion
		
		#region ConvertToDBString 转化字符字段里的特殊字符
		/// <summary>
		/// 将字符里的特殊字符转化为数据库支持字符格式。
		/// </summary>
		/// <param name="context">需要转化的字符。</param>
		/// <returns>转化后的字符。</returns>
		public override string ConvertToDBString(string context)
		{
			if (context==null)
			{
				return null;
			}
			return (context.Replace("'","''"));
		}

		/// <summary>
		/// 将字符里的特殊字符转化为数据库支持字符格式。
		/// </summary>
		/// <param name="context">需要转化的字符。</param>
		/// <returns>转化后的字符。</returns>
		public static string ToDBString(string context)
		{
			if (context==null)
			{
				return null;
			}
			return (context.Replace("'","''"));
		}
		#endregion		

		#region ExecuteXmlReader
		/// <summary>
		/// 执行SQL语句或存储过程，返回查询所返回的结果集中第一行的第一列。忽略额外的列或行。
		/// </summary>
		/// <param name="commandType">命令类型。</param>
		/// <param name="commandText">命令字符串。</param>
		/// <param name="commandParameters">命令参数</param>
		/// <returns>XmlReader对象。</returns>
		private XmlReader ExecuteXmlReader(CommandType commandType, string commandText, IDbDataParameter[] commandParameters)
		{
			SqlCommand command=null;
			try
			{					
				DBParameterCollection spParam=null;
				if (commandType==CommandType.StoredProcedure)
				{
					spParam=this.GetSPParametersEx(commandText);
				}
				OpenConnection();
				command=new SqlCommand();
				command.Connection=(SqlConnection)m_dbConnection;
				if (m_TransCount>0 && m_dbTransaction!=null ) 
				{
					command.Transaction=(SqlTransaction)m_dbTransaction;					
				}	
				command.CommandType=commandType;
				command.CommandText=commandText;				
				AttachParameters(command,commandParameters,spParam);							
				return command.ExecuteXmlReader();
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

		/// <summary>
		/// 在通用连接上执行SQL语句。
		/// </summary>
		/// <param name="commandText">SQL语句。</param>
		/// <returns>XmlReader对象。</returns>
		public XmlReader ExecuteXmlReader(string commandText)
		{			
			return ExecuteXmlReader(CommandType.Text,commandText,null);		
		}

		/// <summary>
		/// 在通用连接上执行存储过程，返回XmlReader。
		/// </summary>
		/// <param name="spName">存储过程名称。</param>
		/// <param name="colParameters">存储过程参数集合。</param>
		/// <returns>XmlReader对象。</returns>
		public XmlReader ExecuteXmlReader(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteXmlReader(CommandType.StoredProcedure,spName,(IDbDataParameter[])colParameters);						
		}			
		#endregion			

	}
}
