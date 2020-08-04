// ================================================================================
// 		File: GlobalConfiguration.cs
// 		Desc: 获取配置文件信息并做缓存。             
// 		Auth: 李选儒
// 		Date: 2007年4月23日
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
	/// GlobalConfiguration 的摘要说明。
	/// </summary>
	public class GlobalConfiguration
	{

		#region 生成静态文件文件目录
		/// <summary>
		/// 系统虚拟目录
		/// </summary>
		public const string System_HttpUrl="System_HttpUrl";
		/// <summary>
		/// 会员相关文件
		/// </summary>
		public const string System_MemberWeb="System_MemberWeb";
		/// <summary>
		/// 会员相册
		/// </summary>
		public const string System_MemberPhoto="System_MemberPhoto";
		/// <summary>
		/// 活动图片
		/// </summary>
		public const string System_ActivityPhoto="System_ActivityPhoto";
		/// <summary>
		/// HtmlFiles 目录
		/// </summary>
		public const string System_HtmlFiles="System_HtmlFiles";
		/// <summary>
		/// 活动详细页
		/// </summary>
		public const string System_ActivityDetail="System_ActivityDetail";		
		/// <summary>
		/// 会员日记
		/// </summary>
		public const string System_Diary="System_Diary";
		/// <summary>
		/// 礼物文件夹
		/// </summary>
		public const string System_Gift="System_Gift";
		/// <summary>
		/// 礼物图像文件夹
		/// </summary>
		public const string System_GiftImg="System_GiftImg";
		/// <summary>
		/// 成功故事图像文件夹
		/// </summary>
		public const string System_SucceedStoryImg="System_SucceedStoryImg";
		/// <summary>
		/// 成功故事内容文件夹
		/// </summary>
		public const string System_StoryFileUrl="System_StoryFileUrl";
		/// <summary>
		/// 成功故事静态页文件夹
		/// </summary>
		public const string System_SucceedStory="System_SucceedStory";
		/// <summary>
		/// 栏目文件夹
		/// </summary>
		public const string System_ChannelFiles="System_ChannelFiles";
		/// <summary>
		/// 栏目静态页文件夹
		/// </summary>
		public const string System_ChannelBlocks="System_ChannelBlocks";
		/// <summary>
		/// 文件存放目录 可以是另一台电脑 \192.168.0.35\Files\
		/// </summary>
		public const string System_Files="System_Files";
		/// <summary>
		/// 广告存放目录 ad
		/// </summary>
		public const string System_Ad="System_Ad";
		
		public const string VedioVerifyServer="VedioVerifyServer";

		/// <summary>
		/// 网站的网址
		/// </summary>
		public const string WebSite = "http.WebSite";
		#endregion

		#region 获取支付宝配置信息
		/// <summary>
		/// 支付接口
		/// </summary>
		public const string AliPay_gateway = "AliPay_gateway";
		/// <summary>
		/// 通知支付接口
		/// </summary>
		public const string AliPay_notify_gateway = "AliPay_notify_gateway";
		/// <summary>
		/// 接口名称
		/// </summary>
		public const string AliPay_service = "AliPay_service";
		/// <summary>
		/// 合作伙伴ID
		/// </summary>
		public const string AliPay_partner = "AliPay_partner";
		/// <summary>
		/// 签名类型
		/// </summary>
		public const string AliPay_sign_type = "AliPay_sign_type";
		/// <summary>
		/// 支付类型
		/// </summary>
		public const string AliPay_payment_type = "AliPay_payment_type";
		/// <summary>
		/// 展示地址
		/// </summary>
		public const string AliPay_show_url = "AliPay_show_url";
		/// <summary>
		/// 卖家账号
		/// </summary>
		public const string AliPay_seller_email = "AliPay_seller_email";
		/// <summary>
		/// 安全校验码
		/// </summary>
		public const string AliPay_key = "AliPay_key";
		/// <summary>
		/// 服务器通知返回接口
		/// </summary>
		public const string AliPay_return_url = "AliPay_return_url";
		/// <summary>
		/// 服务器通知返回接口
		/// </summary>
		public const string AliPay_notify_url = "AliPay_notify_url";
		#endregion

		#region 获取网银配置信息
		/// <summary>
		/// 商户ID参数
		/// </summary>
		public const string ChinaPay_MerId = "ChinaPay_MerId";
		/// <summary>
		/// 支付结果接收URL
		/// </summary>
		public const string ChinaPay_CallBackUrl = "ChinaPay_CallBackUrl";
		/// <summary>
		/// 支付结果返回方式(0-成功和失败支付结果均返回；1-仅返回成功支付结果)
		/// </summary>
		public const string ChinaPay_ResultMode = "ChinaPay_ResultMode";
		/// <summary>
		/// 保留域1
		/// </summary>
		public const string ChinaPay_Reserved01 = "ChinaPay_Reserved01";
		/// <summary>
		/// 保留域2
		/// </summary>
		public const string ChinaPay_Reserved02 = "ChinaPay_Reserved02";
		/// <summary>
		/// 发送方证书路径(商户证书)
		/// </summary>
		public const string ChinaPay_SendCertPath = "ChinaPay_SendCertPath";
		/// <summary>
		/// 接收方证书路径(银联证书)
		/// </summary>
		public const string ChinaPay_RcvCertPath = "ChinaPay_RcvCertPath";
		/// <summary>
		/// 发送方证书密码(商户证书)
		/// </summary>
		public const string ChinaPay_SendCertPWD = "ChinaPay_SendCertPWD";

		/// <summary>
		/// 好易联商户ID
		/// </summary>
		public const string ChinaPay_GetResult_MerId = "ChinaPay_GetResult_MerId";
		/// <summary>
		/// 好易联对帐用户ID
		/// </summary>
		public const string ChinaPay_GetResult_UserId = "ChinaPay_GetResult_UserId";
		/// <summary>
		/// 好易联对帐用户密码
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
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 获取用户名
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


		#region 数据库连接字符串。
		/// <summary>
		/// 获取数据库连接字符串，用来打开到数据库的连接。
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

		#region 获取管理员帐号。
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

		#region 获取栏目存储路径。
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

		#region 获取栏目预览路径。
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

		#region 获取配置节中的值。
		/// <summary>
		/// 获取配置文件中键对应的值。先读本模块，若无，则读系统配置（AppSettings）。
		/// </summary>
		/// <param name="key">配置键。</param>
		/// <returns>对应值。</returns>
		public static string GetConfigByKey(string key)
		{
			_cfg = new BaseConfiguration(); 
			return _cfg.GetConfigByKey(key);
		}

		/// <summary>
		/// 获得虚拟目录
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
