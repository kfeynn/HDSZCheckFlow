using System;
using DBHandler; 

	public class MyScalar 
	{ 
		public MyScalar(){}
		public object ExcuteScalar(string strSqlCommand)
		{ 
			object Result; 
			DBHandler.OleDBHandler MyScalardbHand = new DBHandler.OleDBHandler(); 
			Result = MyScalardbHand.ExecuteScalar(strSqlCommand); 
			MyScalardbHand.Close(); 
			return Result; 
		} 
		public bool ExcuteNonQuery(string strSqlCommand)
		{ 
			bool Result; 
			DBHandler.OleDBHandler MyNonQuery = new DBHandler.OleDBHandler(); 
			Result = MyNonQuery.ExecuteNonQuery(strSqlCommand); 
			MyNonQuery.Close(); 
			return Result; 
		} 
		public System.Data.OleDb.OleDbDataReader ExcuteReader(string strSqlCommand)
		{ 
			System.Data.OleDb.OleDbDataReader Result; 
			DBHandler.OleDBHandler MyScalardbHand = new DBHandler.OleDBHandler(); 
			Result = MyScalardbHand.ExecuteReader(strSqlCommand); 
			MyScalardbHand.Close(); 
			return Result; 
		} 

	}
