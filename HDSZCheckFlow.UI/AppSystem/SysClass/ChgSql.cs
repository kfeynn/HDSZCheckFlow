using System;

	public class ChgSql
	{
		public  string ReturnString="";
		public ChgSql()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public bool ChgResultSql(ref string ResultSql,string strFieldName,string strValue)
		{
			//函数作用：为完成系统默认值及程序动态数据输入功
			//		    能，对XPGrid中已生成的SQL指令进行动态
			//			更改。

			string strSql; //函数内用变量
			strSql=ResultSql;

			if (strSql.IndexOf("insert",0,strSql.Length)>=0) //如果为插入指令
			{
				int intAddPosition=0;
				intAddPosition=strSql.IndexOf("(",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+1)+strFieldName+","+strSql.Substring(intAddPosition+1,strSql.Length-intAddPosition-1);
				
				intAddPosition=strSql.IndexOf("values(",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+7)+strValue+","+strSql.Substring(intAddPosition+7,strSql.Length-intAddPosition-7);
				ResultSql=strSql;
				return true;
			}
			if(strSql.IndexOf("Update",0,strSql.Length)>=0) //如果为修改指令
			{
				int intAddPosition=0;
				intAddPosition=strSql.IndexOf("set",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+4)+strFieldName+"="+strValue+","+strSql.Substring(intAddPosition+4,strSql.Length-intAddPosition-4);
				ResultSql=strSql;
				return true;
			}
			if(strSql.IndexOf("delete",0,strSql.Length)>=0) //如果为删除指令
			{
				//Nothing;
				return true;
			}
			return false;
		}

		// 将原来的sql 替换成现在的sql 
		public bool ChgResultSqlTihuan(ref string ResultSql,string cmdStr)
		{

			ResultSql = cmdStr ; 
			return true;
		}

		public bool ChgQueryDisplay(ref string ResultSql,string strTableName,string strIDFieldName,string strValueFieldName)
		{
			//函数作用：让系统能够识别的查询语句变成人认识的查询条件
			//			请注意：此函数仅能转变下拉列表框，否则不准确

			string strSql; //函数内用变量
			strSql=ResultSql.Trim();

			//第一步：ID字段变成大写
			string strTmpIDFieldName=strIDFieldName.Trim().ToUpper();

			//第二步：确定字段在SQL语句中的起始位置
			int intFieldStartPosition=strSql.IndexOf(strTmpIDFieldName,0,strSql.Length-1);
			if (intFieldStartPosition<0) //找不到
			{
				return false;
			}

			//第三步：确定字段名起始位置后第一个"and"的位置
			int intNextAndPosition=strSql.IndexOf("and",intFieldStartPosition,strSql.Length-intFieldStartPosition-strTmpIDFieldName.Length);

			if(intNextAndPosition<0)
			{
				intNextAndPosition=strSql.Length;
			}

			//第四步：获得ID字段的显示ID及显示值
			string strGetTheIdValue=strSql.Substring(intFieldStartPosition+strTmpIDFieldName.Length+2,intNextAndPosition-intFieldStartPosition-strTmpIDFieldName.Length-3);
			string strSelect="Select "+strValueFieldName+ " From "+strTableName + " Where "+strIDFieldName+" = "+strGetTheIdValue;
			ReturnString=strSelect;

			string strGetTheFieldValue="";
			MyScalar MyScalar=new MyScalar();
			try
			{
				strGetTheFieldValue=Convert.ToString(MyScalar.ExcuteScalar(strSelect)).Trim();
			}
			catch
			{
				return false;
			}
			ResultSql=strSql.Substring(0,intFieldStartPosition+strTmpIDFieldName.Length+2)+strGetTheFieldValue+strSql.Substring(intNextAndPosition-1,strSql.Length-intNextAndPosition+1);
			return true;
		}
		public bool ChgSqlChkerCodeAndToOr(ref string ResultSql)
		{
			
			//函数功能把CheckerCode1与CheckerCode2的关系从And转为Or
			string strSql;
			strSql=ResultSql.Trim();

			if (strSql.Length==0)
			{
				return false;
			}

			//第一步：把CheckerCoode1变成"(CheckerCode1"
			strSql=strSql.Replace("CHECKERCODE1","(CHECKERCODE1");
            
			//第二步：获得CheckerCode1的位置，并获得CheckerCode1之后的and位置
			int intCode1Position=strSql.IndexOf("CHECKERCODE1",0,strSql.Length-1);
			if (intCode1Position<0)
			{
				return false;
			}
			int intAndPosition=strSql.IndexOf("and",intCode1Position,strSql.Length-intCode1Position);

			if(intAndPosition<0)
			{
				return false;
			}
			//第三步：把and去掉加上Or,再加上")"
			strSql=strSql.Substring(0,intAndPosition)+" or "+strSql.Substring(intAndPosition+3,strSql.Length-intAndPosition-3)+")";
			ResultSql=strSql;
			return true;
		}
	}

