using System;

namespace HDSZCheckFlow.Common
{
	#region ValidateType
	/// <summary>
	/// 验证类型。
	/// </summary>
	public enum ValidateType
	{
		/// <summary>
		/// 验证通过。
		/// </summary>
		Passed			= 0x01,
		/// <summary>
		/// 验证未通过。
		/// </summary>
		NotPassed		= 0x02,
		/// <summary>
		/// 默认通过。
		/// </summary>
		NeverValidate	= 0x00,
		/// <summary>
		/// 已删除。
		/// </summary>
		Deleted			= 0x03,
		/// <summary>
		/// 已验证通过。
		/// </summary>
		ApprovedIsOK	= 0x05,
		/// <summary>
		/// 验证未通过。
		/// </summary>
		ApprovedIsNotOK	= 0x08,
		/// <summary>
		/// 未上传
		/// </summary>
		NotUpLoad        = 0x06,
		/// <summary>
		/// 更改未审
		/// </summary>
		UpdateNeverValidate  = 0x07
	}
	#endregion

	#region MemberLevel 会员的级别
	/// <summary>
	/// 会员的级别，0.未激活邮箱.1.普通会员，2.高级会员，3.金牌会员，4.钻石会员
	/// </summary>
	public enum MemberLevel
	{
		/// <summary>
		/// 未激活邮箱。
		/// </summary>
		NotActivedMember = 0,
		/// <summary>
		/// 普通会员。
		/// </summary>
		GeneralMember = 1,
		/// <summary>
		/// 高级会员。
		/// </summary>
		AdvancedMember = 2,
		/// <summary>
		/// 金牌会员。
		/// </summary>
		GoldMember	= 3,
		/// <summary>
		/// 钻石会员
		/// </summary>
		DiamondMember = 4
	}
	#endregion

	#region MemberType 栏目类别
	/// <summary>
	/// 栏目类别 1 .交友大本营　２.征婚俱乐部　３.提供视频　４.提供伴游
	/// </summary>
	public enum MemberType
	{
		/// <summary>
		/// 交友大本营
		/// </summary>
		AddFriend = 1 ,
		/// <summary>
		/// 征婚俱乐部
		/// </summary>
		MarryClup = 2,
		/// <summary>
		/// 提供视频
		/// </summary>
		VideoView = 3,
		/// <summary>
		/// 提供伴游
		/// </summary>
		TripSipply = 4

	}
	#endregion

	#region 验证数据类型
	/// <summary>
	/// 验证数据类型ID
	/// </summary>
	public enum ValidateDataTypeID
	{
		/// <summary>
		/// 图片类型
		/// </summary>
		MemberPicture = 0,
		/// <summary>
		/// 日记回复类型
		/// </summary>
		MemberDiaryReturn = 1,
		/// <summary>
		/// 内心独白类型
		/// </summary>
		MemberHeartSentence = 2,
		/// <summary>
		/// 辩论回复 
		/// </summary>
		ArgueTopicType = 3,
		/// <summary>
		/// 成功故事
		/// </summary>
		MemberSucceedStory = 4,
		/// <summary>
		/// 成功故事祝福
		/// </summary>
		MemberSucceedStoryTopic = 5,
		/// <summary>
		/// 活动评论 
		/// </summary>
		ActivityTopic = 6,
		/// <summary>
		/// 形象照 
		/// </summary>
		MemberMainPic = 7,
		/// <summary>
		/// 证件 
		/// </summary>
		CredentialsValidateFile = 8,
		/// <summary>
		/// 视频 
		/// </summary>
		VideoFile = 9,
		/// <summary>
		/// 心情日记类型
		/// </summary>
		MemberDiary = 10,
		/// <summary>
		/// 帮帮我类型
		/// </summary>
		HelpQuestion = 11,
		/// <summary>
		/// 帮帮我回复类型
		/// </summary>
		HelpAnwer = 12,
		/// <summary>
		/// 活动图片类型
		/// </summary>
		ActivityImg = 13,
		/// <summary>
		/// 成功故事图片类型
		/// </summary>
		MemberSucceedStoryPhoto = 14,
		/// <summary>
		/// 活动类型
		/// </summary>
		Activity = 15,
		/// <summary>
		/// 心目中的TA类型
		/// </summary>
		MemberCondictions = 16,
		/// <summary>
		/// 会员基本资料类型
		/// </summary>
		MemberBaseInfo = 17,
		/// <summary>
		/// 亲友团类型
		/// </summary>
		MemberFamilyInfo = 18,
		/// <summary>
		/// 会员资料修改审核类型
		/// </summary>
		MemberInfoTemp = 19,
		/// <summary>
		/// 一审留言信息
		/// </summary>
		FirstApprovedMemberMessage = 20,
		/// <summary>
		/// 二审留言信息
		/// </summary>
		SecondApprovedMemberMessage = 21,
		/// <summary>
		/// SCS审核
		/// </summary>
		SCSApproved = 22
	}
	#endregion

	#region 活动状态
	/// <summary>
	/// 活动状态（1活动未开始，2活动截止报名，3活动结束，4活动取消）
	/// </summary>
	public enum ActivityState
	{
		ActivityStateNotBegin = 0x01,
		ActivityStateSignUpTimeEnd = 0x02,
		ActivityStateEnd = 0x03,
		ActivityStateCancel = 0x04
	}
	#endregion

	#region CertificateType
	public enum CertificateType
	{
		/// <summary>
		/// 身份证明。
		/// </summary>
		certificate_degree = 0,
		/// <summary>
		/// 收入证明。
		/// </summary>
		certificate_earning = 1,
		/// <summary>
		/// 学历证明。
		/// </summary>
		certificate_edu = 2,
		/// <summary>
		/// 婚育证明。
		/// </summary>
		certificate_marriage = 3,
		/// <summary>
		/// 单身证明
		/// </summary>
		certificate_single = 4,
		/// <summary>
		/// 工作证明
		/// </summary>
		certificate_work = 5,

	}
	#endregion

	#region 会员临时资料类型:1.昵称 2.形象照 3.内心独白 4.婚姻状况 5.收入 6.心目中的TA
	public enum MemberInfoTempType
	{
		/// <summary>
		/// 昵称。
		/// </summary>
		MemberInfoTempType_UserName = 1,
		/// <summary>
		/// 形象照。
		/// </summary>
		MemberInfoTempType_MainPic = 2,
		/// <summary>
		/// 内心独白。
		/// </summary>
		MemberInfoTempType_HeartSentence = 3,
		/// <summary>
		/// 婚姻状况
		/// </summary>
		MemberInfoTempType_Marriage = 4,
		/// <summary>
		/// 收入
		/// </summary>
		MemberInfoTempType_Income = 5,
		/// <summary>
		/// 心目中的TA
		/// </summary>
		MemberInfoTempType_MyTA = 6,
		/// <summary>
		/// 视频
		/// </summary>
		MemberInfoType_MVideo = 7 ,

		/// <summary>
		/// 伴游
		/// </summary>
		MemberInfoTempType_MTripContent = 8 

	}
	#endregion

	#region BackUserType
	/// <summary>
	/// 后台用户类型，1后台管理，2运营用户,3后台用户
	/// </summary>
	public enum BackUserType
	{
		/// <summary>
		/// 后台管理
		/// </summary>
		AdminUserType = 1,
		/// <summary>
		/// 运营用户
		/// </summary>
		SaleUserType = 2,
		/// <summary>
		/// 后台用户
		/// </summary>
		GeneralUserType = 3
	}
	#endregion

	#region 产品类别 ProductType
	public enum ProductType
	{
		Gold = 1,
		Diamond = 2,
		ContestPrice = 3,
		SCS = 4,
		IDCheck = 5,
		Gift = 6,
		SendMessage = 7,
		ReceviceMessage = 8,
		BrowseImages = 9,
		Match = 10,
		Link = 11,
		BrowseVideo=12,
		
		TripDemand = 13,//13 发布伴游
		MemberPlaza = 14 ,
		MessageBothSides=15, //双向收费留言产品
		ChristmasNight = 16,  //2008年圣诞节活动
		TripMemberSendMessage=17, //给伴游会员发留言
		TripMemberLink=18,//看伴游会员联系方式
		TripDemandLink=19, //看发布过聘请计划会员联系方式 = 19
		TripDemandMessage=20, //给发布过聘请计划会员留言 20 
	}
	#endregion

}
