using System;

	public class ChgSql
	{
		public  string ReturnString="";
		public ChgSql()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public bool ChgResultSql(ref string ResultSql,string strFieldName,string strValue)
		{
			//�������ã�Ϊ���ϵͳĬ��ֵ������̬�������빦
			//		    �ܣ���XPGrid�������ɵ�SQLָ����ж�̬
			//			���ġ�

			string strSql; //�������ñ���
			strSql=ResultSql;

			if (strSql.IndexOf("insert",0,strSql.Length)>=0) //���Ϊ����ָ��
			{
				int intAddPosition=0;
				intAddPosition=strSql.IndexOf("(",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+1)+strFieldName+","+strSql.Substring(intAddPosition+1,strSql.Length-intAddPosition-1);
				
				intAddPosition=strSql.IndexOf("values(",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+7)+strValue+","+strSql.Substring(intAddPosition+7,strSql.Length-intAddPosition-7);
				ResultSql=strSql;
				return true;
			}
			if(strSql.IndexOf("Update",0,strSql.Length)>=0) //���Ϊ�޸�ָ��
			{
				int intAddPosition=0;
				intAddPosition=strSql.IndexOf("set",0,strSql.Length-1);
				strSql=strSql.Substring(0,intAddPosition+4)+strFieldName+"="+strValue+","+strSql.Substring(intAddPosition+4,strSql.Length-intAddPosition-4);
				ResultSql=strSql;
				return true;
			}
			if(strSql.IndexOf("delete",0,strSql.Length)>=0) //���Ϊɾ��ָ��
			{
				//Nothing;
				return true;
			}
			return false;
		}

		// ��ԭ����sql �滻�����ڵ�sql 
		public bool ChgResultSqlTihuan(ref string ResultSql,string cmdStr)
		{

			ResultSql = cmdStr ; 
			return true;
		}

		public bool ChgQueryDisplay(ref string ResultSql,string strTableName,string strIDFieldName,string strValueFieldName)
		{
			//�������ã���ϵͳ�ܹ�ʶ��Ĳ�ѯ���������ʶ�Ĳ�ѯ����
			//			��ע�⣺�˺�������ת�������б�򣬷���׼ȷ

			string strSql; //�������ñ���
			strSql=ResultSql.Trim();

			//��һ����ID�ֶα�ɴ�д
			string strTmpIDFieldName=strIDFieldName.Trim().ToUpper();

			//�ڶ�����ȷ���ֶ���SQL����е���ʼλ��
			int intFieldStartPosition=strSql.IndexOf(strTmpIDFieldName,0,strSql.Length-1);
			if (intFieldStartPosition<0) //�Ҳ���
			{
				return false;
			}

			//��������ȷ���ֶ�����ʼλ�ú��һ��"and"��λ��
			int intNextAndPosition=strSql.IndexOf("and",intFieldStartPosition,strSql.Length-intFieldStartPosition-strTmpIDFieldName.Length);

			if(intNextAndPosition<0)
			{
				intNextAndPosition=strSql.Length;
			}

			//���Ĳ������ID�ֶε���ʾID����ʾֵ
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
			
			//�������ܰ�CheckerCode1��CheckerCode2�Ĺ�ϵ��AndתΪOr
			string strSql;
			strSql=ResultSql.Trim();

			if (strSql.Length==0)
			{
				return false;
			}

			//��һ������CheckerCoode1���"(CheckerCode1"
			strSql=strSql.Replace("CHECKERCODE1","(CHECKERCODE1");
            
			//�ڶ��������CheckerCode1��λ�ã������CheckerCode1֮���andλ��
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
			//����������andȥ������Or,�ټ���")"
			strSql=strSql.Substring(0,intAndPosition)+" or "+strSql.Substring(intAndPosition+3,strSql.Length-intAndPosition-3)+")";
			ResultSql=strSql;
			return true;
		}
	}

