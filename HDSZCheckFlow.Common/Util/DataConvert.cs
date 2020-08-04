// ================================================================================
// 		File: DataConvert.cs
// 		Desc: ����ת���ࡣ
//  
// 		Called by:   
//               
// 		Auth: Andy Lee
// 		Date: 2007-04-29
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

namespace HDSZCheckFlow.Common.Util
{
	/// <summary>
	/// Convert ��ժҪ˵����
	/// </summary>
	public class DataConvert
	{
		public DataConvert()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
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

		/// <summary>
		/// ��ö�����
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string ToDBTimeString(string dateString)
		{
			try
			{
				return DateTime.Parse(dateString).ToString("yyyy-MM-dd");
			}
			catch(Exception)
			{
				return "";
			}


		}

		public static string CutStringByLength(string _source , int _len)
		{
			if(_source.Length>(_len+1))
			{
				return _source.Substring(0,_len)+"...";
			}
			return _source;
		}
		public static string GetLevelNameByLevel(object level)
		{
			int l=Convert.ToInt32(level);
			return l==4?"<img src=\"../../Style/images/Detail/vip.gif\" align=absMiddle>VIP�����Ա":(l==3?"<img src=\"../../Style/images/Detail/vip.gif\" align=absMiddle>VIP�����Ա":(l==2?"��ͨ�����Ա":"��ͨ�����Ա"));
		}
		public static string GetMemberSexSmallPic(object msex)
		{
			int l=Convert.ToInt32(msex);
			return l==1?"<img src=\"../../Style/images/other/nan.gif\" align=\"absMiddle\">":"<img src=\"../../Style/images/other/nv.gif\" align=\"absMiddle\">";
		}

		public static int ConvertToInt(string values)
		{
			int Return_value = 0;
			bool flag = false;
			for(int i=0;i<values.Length;i++)
			{
				short cn = (short)values[i];
				if(cn< 48 || cn>57)
				{
					flag = true;
					break;
				}
			}
			if(flag == false && values.Length>0)
			{
				Return_value = Convert.ToInt32(values);
			}

			return Return_value;
		}
	}
}
