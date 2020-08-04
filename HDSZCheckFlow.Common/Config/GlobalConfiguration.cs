// ================================================================================
// 		File: GlobalConfiguration.cs
// 		Desc: ��ȡ�����ļ���Ϣ�������档             
// 		Auth: ��ѡ��
// 		Date: 2007��4��23��
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

namespace HDSZCheckFlow.Common.Config
{
	/// <summary>
	/// GlobalConfiguration ��ժҪ˵����
	/// </summary>
	public class GlobalConfiguration
	{

		#region ���ɾ�̬�ļ��ļ�Ŀ¼
		/// <summary>
		/// ϵͳ����Ŀ¼
		/// </summary>
		public const string System_HttpUrl="System_HttpUrl";
		/// <summary>
		/// ��Ա����ļ�
		/// </summary>
		public const string System_MemberWeb="System_MemberWeb";
		/// <summary>
		/// ��Ա���
		/// </summary>
		public const string System_MemberPhoto="System_MemberPhoto";
		/// <summary>
		/// �ͼƬ
		/// </summary>
		public const string System_ActivityPhoto="System_ActivityPhoto";
		/// <summary>
		/// HtmlFiles Ŀ¼
		/// </summary>
		public const string System_HtmlFiles="System_HtmlFiles";
		/// <summary>
		/// ���ϸҳ
		/// </summary>
		public const string System_ActivityDetail="System_ActivityDetail";		
		/// <summary>
		/// ��Ա�ռ�
		/// </summary>
		public const string System_Diary="System_Diary";
		/// <summary>
		/// �����ļ���
		/// </summary>
		public const string System_Gift="System_Gift";
		/// <summary>
		/// ����ͼ���ļ���
		/// </summary>
		public const string System_GiftImg="System_GiftImg";
		/// <summary>
		/// �ɹ�����ͼ���ļ���
		/// </summary>
		public const string System_SucceedStoryImg="System_SucceedStoryImg";
		/// <summary>
		/// �ɹ����������ļ���
		/// </summary>
		public const string System_StoryFileUrl="System_StoryFileUrl";
		/// <summary>
		/// �ɹ����¾�̬ҳ�ļ���
		/// </summary>
		public const string System_SucceedStory="System_SucceedStory";
		/// <summary>
		/// ��Ŀ�ļ���
		/// </summary>
		public const string System_ChannelFiles="System_ChannelFiles";
		/// <summary>
		/// ��Ŀ��̬ҳ�ļ���
		/// </summary>
		public const string System_ChannelBlocks="System_ChannelBlocks";
		/// <summary>
		/// �ļ����Ŀ¼ ��������һ̨���� \192.168.0.35\Files\
		/// </summary>
		public const string System_Files="System_Files";
		/// <summary>
		/// �����Ŀ¼ ad
		/// </summary>
		public const string System_Ad="System_Ad";
		
		public const string VedioVerifyServer="VedioVerifyServer";

		/// <summary>
		/// ��վ����ַ
		/// </summary>
		public const string WebSite = "http.WebSite";
		#endregion

		#region ��ȡ֧����������Ϣ
		/// <summary>
		/// ֧���ӿ�
		/// </summary>
		public const string AliPay_gateway = "AliPay_gateway";
		/// <summary>
		/// ֪֧ͨ���ӿ�
		/// </summary>
		public const string AliPay_notify_gateway = "AliPay_notify_gateway";
		/// <summary>
		/// �ӿ�����
		/// </summary>
		public const string AliPay_service = "AliPay_service";
		/// <summary>
		/// �������ID
		/// </summary>
		public const string AliPay_partner = "AliPay_partner";
		/// <summary>
		/// ǩ������
		/// </summary>
		public const string AliPay_sign_type = "AliPay_sign_type";
		/// <summary>
		/// ֧������
		/// </summary>
		public const string AliPay_payment_type = "AliPay_payment_type";
		/// <summary>
		/// չʾ��ַ
		/// </summary>
		public const string AliPay_show_url = "AliPay_show_url";
		/// <summary>
		/// �����˺�
		/// </summary>
		public const string AliPay_seller_email = "AliPay_seller_email";
		/// <summary>
		/// ��ȫУ����
		/// </summary>
		public const string AliPay_key = "AliPay_key";
		/// <summary>
		/// ������֪ͨ���ؽӿ�
		/// </summary>
		public const string AliPay_return_url = "AliPay_return_url";
		/// <summary>
		/// ������֪ͨ���ؽӿ�
		/// </summary>
		public const string AliPay_notify_url = "AliPay_notify_url";
		#endregion

		#region ��ȡ����������Ϣ
		/// <summary>
		/// �̻�ID����
		/// </summary>
		public const string ChinaPay_MerId = "ChinaPay_MerId";
		/// <summary>
		/// ֧���������URL
		/// </summary>
		public const string ChinaPay_CallBackUrl = "ChinaPay_CallBackUrl";
		/// <summary>
		/// ֧��������ط�ʽ(0-�ɹ���ʧ��֧����������أ�1-�����سɹ�֧�����)
		/// </summary>
		public const string ChinaPay_ResultMode = "ChinaPay_ResultMode";
		/// <summary>
		/// ������1
		/// </summary>
		public const string ChinaPay_Reserved01 = "ChinaPay_Reserved01";
		/// <summary>
		/// ������2
		/// </summary>
		public const string ChinaPay_Reserved02 = "ChinaPay_Reserved02";
		/// <summary>
		/// ���ͷ�֤��·��(�̻�֤��)
		/// </summary>
		public const string ChinaPay_SendCertPath = "ChinaPay_SendCertPath";
		/// <summary>
		/// ���շ�֤��·��(����֤��)
		/// </summary>
		public const string ChinaPay_RcvCertPath = "ChinaPay_RcvCertPath";
		/// <summary>
		/// ���ͷ�֤������(�̻�֤��)
		/// </summary>
		public const string ChinaPay_SendCertPWD = "ChinaPay_SendCertPWD";

		/// <summary>
		/// �������̻�ID
		/// </summary>
		public const string ChinaPay_GetResult_MerId = "ChinaPay_GetResult_MerId";
		/// <summary>
		/// �����������û�ID
		/// </summary>
		public const string ChinaPay_GetResult_UserId = "ChinaPay_GetResult_UserId";
		/// <summary>
		/// �����������û�����
		/// </summary>
		public const string ChinaPay_GetResult_Pwd = "ChinaPay_GetResult_Pwd";
		#endregion 

		private static BaseConfiguration _cfg = null;
		private static readonly object lockObj = new object(); 
		private static string _ConnectionString ;
		private static string _Administrator;
		private static string _PathChannelImage;
		private static string _HttpChannelImage;
		private const string _username = "Username";
		private const string _password = "Password";

		public GlobalConfiguration()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region ��ȡ�û���
		public static string Username
		{
			get
			{
				_cfg = new BaseConfiguration(); 
				return _cfg.GetConfigByKey(_username);
			}
		}	
		#endregion

		#region 
		public static string Password
		{
			get
			{
				_cfg = new BaseConfiguration(); 
				return _cfg.GetConfigByKey(_password);
			}
		}
		#endregion


		#region ���ݿ������ַ�����
		/// <summary>
		/// ��ȡ���ݿ������ַ����������򿪵����ݿ�����ӡ�
		/// </summary>
		public static string ConnectionString
		{
			get 
			{ 
				_cfg = new BaseConfiguration("activerecord");
				if (_ConnectionString == null || _ConnectionString == "") 
				{
					lock (lockObj) 
					{
						_ConnectionString = _cfg.ConnectionString; 
					} 
				}
				return _ConnectionString;
			}
		}	
		#endregion	

		#region ��ȡ����Ա�ʺš�
		public static string Administrator
		{
			get
			{
				_cfg = new BaseConfiguration(); 
				if (_Administrator == null || _Administrator == "") 
				{
					lock (lockObj) 
					{
						_Administrator = _cfg.Administrator; 
					} 
				}
				return _Administrator;
			}
		}	
		#endregion

		#region ��ȡ��Ŀ�洢·����
		public static string PathChannelImage
		{
			get
			{
				_cfg = new BaseConfiguration(); 
				if (_PathChannelImage == null || _PathChannelImage == "") 
				{
					lock (lockObj) 
					{
						_PathChannelImage= _cfg.GetPathChannelImage; 
					} 
				}
				return _PathChannelImage;
			}
		}	
		#endregion

		#region ��ȡ��ĿԤ��·����
		public static string HttpChannelImage
		{
			get
			{
				_cfg = new BaseConfiguration(); 
				if (_HttpChannelImage== null || _HttpChannelImage == "") 
				{
					lock (lockObj) 
					{
						_HttpChannelImage = _cfg.GetHttpChannelImage; 
					} 
				}
				return _HttpChannelImage;
			}
		}	
		#endregion

		#region ��ȡ���ý��е�ֵ��
		/// <summary>
		/// ��ȡ�����ļ��м���Ӧ��ֵ���ȶ���ģ�飬���ޣ����ϵͳ���ã�AppSettings����
		/// </summary>
		/// <param name="key">���ü���</param>
		/// <returns>��Ӧֵ��</returns>
		public static string GetConfigByKey(string key)
		{
			_cfg = new BaseConfiguration(); 
			return _cfg.GetConfigByKey(key);
		}

		/// <summary>
		/// �������Ŀ¼
		/// </summary>
		/// <returns></returns>
		public static string GetHttpUrl()
		{
			_cfg = new BaseConfiguration(); 
			return _cfg.GetConfigByKey(GlobalConfiguration.System_HttpUrl);
		}
		#endregion
	}
}
