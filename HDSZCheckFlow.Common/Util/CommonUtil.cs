using System;
using System.IO ;
using System.Text;
using System.Threading;
using HDSZCheckFlow.Common.Log;
using System.Text.RegularExpressions;

namespace HDSZCheckFlow.Common.Util
{
	/// <summary>
	/// CommonUtil ��ժҪ˵����
	/// </summary>
	public class CommonUtil
	{
		public CommonUtil()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static void GetYearAndMonth(DateTime _regsiterTime,ref int _year,ref int _month)
		{
			TimeSpan timeSpan=DateTime.Now.Subtract(_regsiterTime);
			_year=Convert.ToInt32( timeSpan.TotalDays / 365 );
			_month=Convert.ToInt32( timeSpan.TotalDays / 30 );
		}
		public static string GetLoginTimeString(DateTime _lastLoginDateTime)
		{
			string rtnStr="<img src='../../images/outline.gif'>1���ڵ�¼��";
			
			TimeSpan timeSpan=DateTime.Now.Subtract(_lastLoginDateTime);
			if(timeSpan.TotalMinutes<=120)
			{
				rtnStr="<img src='../../Style/images/home/zx.gif' align=\"absmiddle\">��ǰ����";
			}
//			else if(timeSpan.TotalMinutes>30 && timeSpan.TotalMinutes<=60)
//			{
//				rtnStr="<img src='../../images/outline.gif'>1Сʱ�ڵ�¼��";
//			}
			else if(timeSpan.TotalHours>2 && timeSpan.TotalHours<=24)
			{
				rtnStr="<img src='../../images/outline.gif'>"+Convert.ToInt32( timeSpan.TotalHours ) +"Сʱ�ڵ�¼��";
			}
			else if(timeSpan.TotalDays>1 && timeSpan.TotalDays<=6)
			{
				rtnStr="<img src='../../images/outline.gif'>"+Convert.ToInt32( timeSpan.TotalDays ) +"���ڵ�¼��";
			}
			
			return rtnStr;

		}
	
		public static string GetStartForMemberInfo(object _onumber)
		{
			int _number=0;
			if(_onumber!=DBNull.Value)
			{
				_number=Convert.ToInt32(_onumber);
			}

			string starth = @"<img height='13' src='../../../" + HDSZCheckFlow.Common.Config.GlobalConfiguration.GetHttpUrl() + @"/images/xin.gif' width='11'/>";
			string startb = @"<img height='13' src='../../../" + HDSZCheckFlow.Common.Config.GlobalConfiguration.GetHttpUrl()+ @"/images/xin_h.gif' width='11'/>";
			string rtnstart = "";

			for(int i=1;i<6;i++)
			{
				if(i <= _number)
				{
					rtnstart += starth;
				}
				else
				{
					rtnstart += startb;
				}
			}
			 
			return rtnstart;
		}

		#region ȫ��ID
		private static string keyID=DateTime.Now.ToString("yyyyMMddHHmmssffff");
		//ȫ��ID
		public static string NewID()
		{
			return NewID( DateTime.Now.ToString("yyyyMMddHHmmssffff") );				
		}
		private static string NewID(string _id)
		{
			if(keyID==_id)
			{
				Thread.Sleep(10);
				_id = NewID(DateTime.Now.ToString("yyyyMMddHHmmssffff"));
			}
			keyID=_id;
			return _id;
		}
		#endregion

	
		public static string MySubString(string str)
		{
		/*	string temp="";
			if(str==null ||str=="")
			{
				return str;
			}
			else
			{
				if(str.IndexOf(".")!=-1)
				{
					temp=str.Substring(0,str.IndexOf("."));
				}
			}

			return temp;
*/


			//-----------------------

			if(str==null ||str=="")return str;
			if(str.IndexOf(".")!=-1)return str.Substring(0,str.IndexOf("."));
			return "";

		}



		/// <summary>
		/// ͨ��Dropdownlist��valueȡindex
		/// </summary>
		/// <param name="a_ddl"></param>
		/// <param name="a_strValue"></param>
		/// <returns></returns>
		public static int GetDropDownListIndexByValue(System.Web.UI.WebControls.DropDownList a_ddl, string a_strValue)
		{
			int intReturnIndex = -1;
			for (int i=0;i<a_ddl.Items.Count;i++)
			{
				if (a_ddl.Items[i].Value == a_strValue)
				{
					intReturnIndex = i;
				}
			}

			return intReturnIndex;
		}
		public static string GetSRSState(int iSRS,int memberid)
		{
			return iSRS==1?"<a href='../../My/Lone/SCSCert.aspx?type=browse&memberID="+memberid.ToString()+"' target=_blank class=cRedF><img src=\"../../Style/images/other/scs.gif\" align=absMiddle></a>":(iSRS==5?"<img src=\"../../Style/images/other/scs.gif\" align=absMiddle><a href='../../My/Lone/SCSCert.aspx?type=browse&memberID="+memberid.ToString()+"' target=_blank class=cRedF></a>":(iSRS==0?"δ���":"δ��֤"));
		}
		public static string GetIDCheckState(int isValidate)
		{
			return isValidate==1?"���ͨ��":(isValidate==5?"<img src=\"../../Style/images/other/idCheck.gif\" align=absMiddle>":"δ��֤");
		}

		#region �����ַ�����һ�������ַ�
		/// <summary>
		/// �����ַ�����һ�������ַ�
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <param name="num">����</param>
		/// <returns></returns>
		public static string GetStrByNumber(string str,int num)
		{
			if(str.Length <= num)
			{
				return str;
			}
			else
			{
				return str.Substring(0,num-1)+"...";
			}
		}


		/// <summary>
		/// �����ַ�����һ�������ַ�
		/// </summary>
		/// <param name="str">�ַ���</param>
		/// <param name="num">����</param>
		/// <returns></returns>
		public static string GetStrByNumber(object obj,int num)
		{
			string str=obj.ToString ();
			if(str.Length <= num)
			{
				return str;
			}
			else
			{
				return str.Substring(0,num-1)+"...";
			}
		}
		#endregion

		#region WriteFile

		/// <summary>
		/// д�ļ�
		/// </summary>
		/// <param name="a_strFileContent">����</param>
		/// <param name="a_strPath">·��</param>
		/// <param name="a_strFileName">�ļ���</param>
		/// <returns></returns>
		public static bool WriteFile(string a_strFileContent,string a_strPath, string a_strFileName)
		{
			bool blReturn = false;

			if (HDSZCheckFlow.Common.Util.CommonUtil.IsExistPhyPath(a_strPath))
			{
				System.IO.StreamWriter sw = new System.IO.StreamWriter(a_strPath + a_strFileName, false, Encoding.Default);

				try
				{
					sw.Write(a_strFileContent);
					sw.Flush();

					blReturn = true;
				}
				catch(System.Exception ex)
				{
					Logger.Log("HDSZCheckFlow.Common.Util.CommonUtil.WriteFile",ex.Message);  
				}
				finally
				{
					sw.Close();
				}
			}

			return blReturn;
		}
		#endregion 

		#region ReadFile
		/// <summary>
		/// ���ļ�
		/// </summary>
		/// <param name="a_strPath">·��</param>
		/// <returns></returns>
		public static string ReadFile(string a_strPath)
		{
			string fileSource="";
			System.IO.StreamReader sr =null;
			try
			{
				sr = new System.IO.StreamReader(a_strPath, Encoding.Default);
				fileSource=sr.ReadToEnd();
			}
			catch(Exception ex)
			{
				Logger.Log("Dialog.Common.Util.CommonUtil.ReadFile",ex.Message);  
			}
			finally
			{
				if(sr!=null)
				{
					sr.Close();
					sr=null;
				}
			}
			return fileSource;
		}
		#endregion 
		
		#region �ж�URL�Ƿ����,���������,�½��󷵻�True,�������.ֱ�ӷ��ش���True,�������,�򷵻�false
		/// <summary>
		/// �ж�URL�Ƿ����,���������,�½��󷵻�True,�������.ֱ�ӷ��ش���True,�������,�򷵻�false
		/// </summary>
		/// <param name="strUrl"></param>
		/// <returns>�������,true</returns>
		public static bool IsExistUrl(string strUrl,System.Web.UI.Page page)
		{
			try
			{
				string Path = page.Server.MapPath(strUrl); 
				FileInfo info = new FileInfo(Path);
				string path = info.DirectoryName;
				if(!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);  
					return true;
				}
				else
				{
					return true;
				}
			}
			catch
			{
				return false;
				
			}
		}


		public static bool IsExistPhyPath(string a_strPhyPath)
		{
			bool blReturn = false;

			try
			{
				if(!Directory.Exists(a_strPhyPath))
				{
					Directory.CreateDirectory(a_strPhyPath);  
					blReturn = true;
				}
				else
				{
					blReturn = true;
				}
			}
			catch(Exception  ex)
			{
				blReturn = false;
				Logger.Log("Dialog.Common.Util.CommonUtil.IsExistPhyPath",ex.Message);  
			}

			return blReturn;
		}


		public static bool IsExistByFileAndPath(string a_strPhyPath)
		{
			bool blReturn = false;
			try
			{
				FileInfo info = new FileInfo(a_strPhyPath);
				string path = info.DirectoryName;

				if(!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);  
					blReturn = true;
				}
				else
				{
					blReturn = true;
				}
			}
			catch(Exception  ex)
			{
				blReturn = false;
				Logger.Log("Dialog.Common.Util.CommonUtil.IsExistByFileAndPath",ex.Message);  
			}

			return blReturn;
		}
		#endregion


		#region �ַ����Ӽ��˳�
		public static int StringToInt(string Str)
		{
			try
			{
				int returnValue=0;
				if(!"".Equals(Str))
				{
					returnValue=int.Parse(Str);
				}
				return returnValue;
			}
			catch(Exception)
			{
				return 1;
			}
		}

		public static float StringToFloat(string Str)
		{
			try
			{
				float returnValue=0;      //Ϊ��ת��Ϊ 0
				if(!"".Equals(Str))
				{
					returnValue=float.Parse(Str);
				}
				return returnValue;
			}
			catch(Exception)
			{
				return 1;    //�ַ������Ͳ���ת��
			}		
		}
		
		//�ַ���ת�����
		public static int StringToIntAdd(string Str1,string Str2,string Str3)   
		{
			try
			{
				int tempInt1=0;
				int tempInt2=0;
				int tempInt3=0;
				if(!"".Equals(Str1.Trim()))
				{
					tempInt1=int.Parse(Str1);
				}
				if(!"".Equals(Str2.Trim()))
				{
					tempInt2=int.Parse(Str2);
				}
				if(!"".Equals(Str3.Trim()))
				{
					tempInt3=int.Parse(Str3);
				}
				return tempInt1+tempInt2+tempInt3;
			}
			catch(Exception)
			{
				return 0;
			}
		}
		public static int StringToIntJian(string Str1,string Str2)
		{
			try
			{
				int tempInt1=0;
				int tempInt2=0;
				if(!"".Equals(Str1.Trim()))
				{
					tempInt1=int.Parse(Str1);
				}
				if(!"".Equals(Str2.Trim()))
				{
					tempInt2=int.Parse(Str2);
				}
				return tempInt1-tempInt2;
			}
			catch(Exception)
			{
				return 0;
			}
		}

		public static string  StringToIntChu(string Str1,string Str2)
		{
			try
			{
				decimal tempInt1=0;
				decimal tempInt2=0;
				if(!"".Equals(Str1.Trim()))
				{
					tempInt1=decimal.Parse(Str1);
				}
				if(!"".Equals(Str2.Trim()))
				{
					tempInt2=decimal.Parse(Str2);
					decimal temp=tempInt1/tempInt2;
					decimal temp2=Math.Round(temp,2) * 100;
					decimal temp3=Math.Round(temp2,0);
					return temp3.ToString() + "%";
				}
				else
				{
					return "100%";
				}
			}
			catch(Exception )
			{
				//if("".Equals(Str2))
				//{
				return "100%";
				//}
				//else

			}
		}
		#endregion 


		#region ���������Ƿ�Ϊ����

		/// <summary>
		/// ���������Ƿ�Ϊ����
		/// </summary>
		/// <param name="Mail_One">�����ַ���</param>
		/// <returns>bool</returns>
		public static   bool IsNumeric(string num)
		{

			string a = "^(-?[0-9]*[.]*[0-9]{0,3})$" ;  //������ 

			string b = "^(([0-9]+\\.[0-9]*[1-9][0-9]*)|([0-9]*[1-9][0-9]*\\.[0-9]+)|([0-9]*[1-9][0-9]*))$"  ;  //��������

			if(Regex.IsMatch(num.Trim(), @a) || Regex.IsMatch(num.Trim(), @b))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		#endregion

	}
}
