// ================================================================================
// 		File: SQLAccess.cs
// 		Desc: SQL Server���ݿ������
//			���ڶ����ݿ�ĵ��ã������װ�����ݿ�ķ��ʡ�
//			�ṩһ������ݿ���������ݲ�ѯ���������ݶ�ȡ������             
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
		#region ��Ա�����͹��캯��

		#endregion

		#region ��֧�ֲ�������
		/// <summary>
		/// �����ǲ�������
		/// </summary>
		/// <returns>��������ɹ��򷵻�true�����򷵻�false��</returns>
		public override bool BeginTransaction()
		{
			if (this.HasTransaction())
			{
				return false;
			}
			return base.BeginTransaction ();
		}

		#endregion

		#region ��ȡ���е����ݵ�SQL
		/// <summary>
		/// ��ȡ��ȡ�����е�SQL��䡣
		/// </summary>
		/// <param name="tableName">Ҫ��ȡ��¼�ı����ơ�</param>
		/// <returns>�û���ȡ��һ����¼��SQL��䡣</returns>
		protected override string GetFirstRowSQL(string tableName)
		{
			return "select top 0 * from "+tableName;
		}	
		#endregion

		#region ��Ա���������캯������������		

		/// <summary>
		/// Ĭ�Ϲ��캯������Web.Config���������Ϊ�����ַ�����ʼ�����ӡ�
		/// </summary>
		public SQLAccess():this(GlobalConfiguration.ConnectionString){}
		
		/// <summary>
		/// �ô���ķ��������ƣ����ݿ����ƣ��û����ƣ���������֯�����ַ�����ʼ�����ӡ�
		/// </summary>
		/// <param name="server">��������ַ�������ƣ���</param>
		/// <param name="database">���ݿ����ơ�</param>
		/// <param name="user">�û�ID��</param>
		/// <param name="password">���롣</param>
		public SQLAccess(string server,string database,string user,string password)
			:this("user id="+user+";password="+password+";data source="+server+";initial catalog="+database)
		{					
		}

		/// <summary>
		/// ֱ�Ӵ�����֯�õ������ַ�����ʼ�����ӡ�
		/// </summary>
		/// <param name="connectionString">�����ַ�����</param>
		public SQLAccess(string connectionString):this(new SqlConnection(connectionString))
		{						
		}	

		/// <summary>
		/// ֱ�Ӵ������ݿ����ӳ�ʼ�����ӡ�
		/// </summary>
		/// <param name="connection">���ݿ����ӡ�</param>
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
		/// ��������ͷ����ӣ��ع����񣩡�
		/// </summary>
		~SQLAccess()
		{
			CloseConnection();				
		}		
		#endregion

		#region ����SQL�����洢���̲���
		/// <summary>
		/// �½��洢���̻��ѯ����еĲ��� IDbDataParameter �ӿڡ�
		/// </summary>
		public override IDbDataParameter CreateParameter()
		{
			return new SqlParameter();
		}
		/// <summary>
		/// �ò������ƺͶ�Ӧ��ʼ��ֵ��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public override IDbDataParameter CreateParameter(string parameterName,object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.Value=GetParameterValue(value);		
			return parameter;
		}
		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;			
			return parameter;
		}

		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;	
			parameter.Value=GetParameterValue(value);
			return parameter;
		}

		/// <summary>
		/// �ò������ơ�DbType �ʹ�С��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public override IDbDataParameter CreateParameter(string parameterName,DbType dbType,int size)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.DbType=dbType;
			parameter.Size=size;
			return parameter;
		}
		/// <summary>
		/// �ò�������DbType����С��Դ������ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="dbType">DbType ֵ֮һ��</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
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
		/// ��ָ��������ʼ�� IDbDataParameter�ӿڡ�
		/// </summary>
		/// <param name="param">Ҫ���������Ļ���������</param>		
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		public override IDbDataParameter CreateParameter(IDbDataParameter param)
		{
			return CreateParameter(param.ParameterName,(int)((SqlParameter)param).SqlDbType,param.Size,param.Direction,param.IsNullable,param.Precision,param.Scale,param.SourceColumn,param.SourceVersion,param.Value);
		}
		#endregion

		#region SqlServer�ṩ������ز�������
		/// <summary>
		/// �ò������ƺ������ṩ�������ͳ�ʼ�� IDbDataParameter�ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType);
		}		
		/// <summary>
		/// �ò������ơ������ṩ�������� �ʹ�С��ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size);
		}		
		/// <summary>
		/// �ò������������ṩ�������͡���С��Դ������ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="size">�����ĳ��ȡ�</param>
		/// <param name="sourceColumn">Դ�е����ơ�</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size, string sourceColumn)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size,sourceColumn);
		}		
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
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, int size, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion sourceVersion, object value)
		{
			return new SqlParameter(parameterName,(SqlDbType)providerType,size,direction,isNullable, precision, scale,sourceColumn, sourceVersion,value);
		}

		/// <summary>
		/// �ò������ƺ��������ͳ�ʼ�� IDbDataParameter �ӿڡ�
		/// </summary>
		/// <param name="parameterName">Ҫӳ��Ĳ��������ơ�</param>
		/// <param name="providerType">�����ṩ����֧�ֵ����͡�</param>
		/// <param name="value">һ�� Object������ IDbDataParameter ��ֵ��</param>
		/// <returns>��ָ��������ʼ�����IDbDataParameter�ӿڡ�</returns>
		protected override IDbDataParameter CreateParameter(string parameterName, int providerType, object value)
		{
			SqlParameter parameter=new SqlParameter();
			parameter.ParameterName=parameterName;
			parameter.SqlDbType=(SqlDbType)providerType;	
			parameter.Value=GetParameterValue(value);
			return parameter;
		}
		#endregion
		
		#region ʵ��DeriveParameters��CreateAdapter�ӿ�

		/// <summary>
		/// ���� IDbCommand ��ָ���Ĵ洢���̼���������Ϣ�����ָ�� IDbCommand ����� Parameters ���ϡ�
		/// </summary>
		/// <param name="cmd">���ý������е���������Ϣ�Ĵ洢���̵� IDbCommand�����������ᱻ��ӵ� IDbCommand �� Parameters �����С�</param>
		protected override void DeriveParameters(IDbCommand cmd)
		{
			SqlCommandBuilder.DeriveParameters((SqlCommand)cmd);
		}

		/// <summary>
		/// �ṩSql Server�����Ž�����
		/// </summary>
		/// <param name="command">�����Ž��������</param>
		/// <returns>���������Ž������������DataSet��</returns>
		protected override IDbDataAdapter CreateAdapter(IDbCommand command)
		{
			return new SqlDataAdapter((SqlCommand)command);
		}

		/// <summary>
		/// �ṩSql Server�����Ž�����
		/// </summary>
		/// <returns>���������Ž������������DataSet��</returns>
		protected override IDbDataAdapter CreateAdapter()
		{
			return new SqlDataAdapter();
		}

		#endregion			
		
		#region ����ִ����������˳��������� 
		/// <summary>
		/// �����ݿ���ʲ�������ִ������˳������		
		/// </summary>
		/// <param name="commandText">ִ�еĴ���������䡣</param>
		/// <param name="paramCollection">��Ҫ�����Ĳ������ϡ�</param>
		/// <returns>��������еĲ���˳�����еĲ������ϡ�</returns>
		public override DBParameterCollection SortParameterCollection(string commandText,DBParameterCollection paramCollection)
		{
			return paramCollection;			
		}
		#endregion
		
		#region ConvertToDBString ת���ַ��ֶ���������ַ�
		/// <summary>
		/// ���ַ���������ַ�ת��Ϊ���ݿ�֧���ַ���ʽ��
		/// </summary>
		/// <param name="context">��Ҫת�����ַ���</param>
		/// <returns>ת������ַ���</returns>
		public override string ConvertToDBString(string context)
		{
			if (context==null)
			{
				return null;
			}
			return (context.Replace("'","''"));
		}

		/// <summary>
		/// ���ַ���������ַ�ת��Ϊ���ݿ�֧���ַ���ʽ��
		/// </summary>
		/// <param name="context">��Ҫת�����ַ���</param>
		/// <returns>ת������ַ���</returns>
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
		/// ִ��SQL����洢���̣����ز�ѯ�����صĽ�����е�һ�еĵ�һ�С����Զ�����л��С�
		/// </summary>
		/// <param name="commandType">�������͡�</param>
		/// <param name="commandText">�����ַ�����</param>
		/// <param name="commandParameters">�������</param>
		/// <returns>XmlReader����</returns>
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
		/// ��ͨ��������ִ��SQL��䡣
		/// </summary>
		/// <param name="commandText">SQL��䡣</param>
		/// <returns>XmlReader����</returns>
		public XmlReader ExecuteXmlReader(string commandText)
		{			
			return ExecuteXmlReader(CommandType.Text,commandText,null);		
		}

		/// <summary>
		/// ��ͨ��������ִ�д洢���̣�����XmlReader��
		/// </summary>
		/// <param name="spName">�洢�������ơ�</param>
		/// <param name="colParameters">�洢���̲������ϡ�</param>
		/// <returns>XmlReader����</returns>
		public XmlReader ExecuteXmlReader(string spName, DBParameterCollection colParameters)
		{			
			return ExecuteXmlReader(CommandType.StoredProcedure,spName,(IDbDataParameter[])colParameters);						
		}			
		#endregion			

	}
}
