using System;

namespace HDSZCheckFlow.Common
{
	#region ValidateType
	/// <summary>
	/// ��֤���͡�
	/// </summary>
	public enum ValidateType
	{
		/// <summary>
		/// ��֤ͨ����
		/// </summary>
		Passed			= 0x01,
		/// <summary>
		/// ��֤δͨ����
		/// </summary>
		NotPassed		= 0x02,
		/// <summary>
		/// Ĭ��ͨ����
		/// </summary>
		NeverValidate	= 0x00,
		/// <summary>
		/// ��ɾ����
		/// </summary>
		Deleted			= 0x03,
		/// <summary>
		/// ����֤ͨ����
		/// </summary>
		ApprovedIsOK	= 0x05,
		/// <summary>
		/// ��֤δͨ����
		/// </summary>
		ApprovedIsNotOK	= 0x08,
		/// <summary>
		/// δ�ϴ�
		/// </summary>
		NotUpLoad        = 0x06,
		/// <summary>
		/// ����δ��
		/// </summary>
		UpdateNeverValidate  = 0x07
	}
	#endregion

	#region MemberLevel ��Ա�ļ���
	/// <summary>
	/// ��Ա�ļ���0.δ��������.1.��ͨ��Ա��2.�߼���Ա��3.���ƻ�Ա��4.��ʯ��Ա
	/// </summary>
	public enum MemberLevel
	{
		/// <summary>
		/// δ�������䡣
		/// </summary>
		NotActivedMember = 0,
		/// <summary>
		/// ��ͨ��Ա��
		/// </summary>
		GeneralMember = 1,
		/// <summary>
		/// �߼���Ա��
		/// </summary>
		AdvancedMember = 2,
		/// <summary>
		/// ���ƻ�Ա��
		/// </summary>
		GoldMember	= 3,
		/// <summary>
		/// ��ʯ��Ա
		/// </summary>
		DiamondMember = 4
	}
	#endregion

	#region MemberType ��Ŀ���
	/// <summary>
	/// ��Ŀ��� 1 .���Ѵ�Ӫ����.������ֲ�����.�ṩ��Ƶ����.�ṩ����
	/// </summary>
	public enum MemberType
	{
		/// <summary>
		/// ���Ѵ�Ӫ
		/// </summary>
		AddFriend = 1 ,
		/// <summary>
		/// ������ֲ�
		/// </summary>
		MarryClup = 2,
		/// <summary>
		/// �ṩ��Ƶ
		/// </summary>
		VideoView = 3,
		/// <summary>
		/// �ṩ����
		/// </summary>
		TripSipply = 4

	}
	#endregion

	#region ��֤��������
	/// <summary>
	/// ��֤��������ID
	/// </summary>
	public enum ValidateDataTypeID
	{
		/// <summary>
		/// ͼƬ����
		/// </summary>
		MemberPicture = 0,
		/// <summary>
		/// �ռǻظ�����
		/// </summary>
		MemberDiaryReturn = 1,
		/// <summary>
		/// ���Ķ�������
		/// </summary>
		MemberHeartSentence = 2,
		/// <summary>
		/// ���ۻظ� 
		/// </summary>
		ArgueTopicType = 3,
		/// <summary>
		/// �ɹ�����
		/// </summary>
		MemberSucceedStory = 4,
		/// <summary>
		/// �ɹ�����ף��
		/// </summary>
		MemberSucceedStoryTopic = 5,
		/// <summary>
		/// ����� 
		/// </summary>
		ActivityTopic = 6,
		/// <summary>
		/// ������ 
		/// </summary>
		MemberMainPic = 7,
		/// <summary>
		/// ֤�� 
		/// </summary>
		CredentialsValidateFile = 8,
		/// <summary>
		/// ��Ƶ 
		/// </summary>
		VideoFile = 9,
		/// <summary>
		/// �����ռ�����
		/// </summary>
		MemberDiary = 10,
		/// <summary>
		/// ���������
		/// </summary>
		HelpQuestion = 11,
		/// <summary>
		/// ����һظ�����
		/// </summary>
		HelpAnwer = 12,
		/// <summary>
		/// �ͼƬ����
		/// </summary>
		ActivityImg = 13,
		/// <summary>
		/// �ɹ�����ͼƬ����
		/// </summary>
		MemberSucceedStoryPhoto = 14,
		/// <summary>
		/// �����
		/// </summary>
		Activity = 15,
		/// <summary>
		/// ��Ŀ�е�TA����
		/// </summary>
		MemberCondictions = 16,
		/// <summary>
		/// ��Ա������������
		/// </summary>
		MemberBaseInfo = 17,
		/// <summary>
		/// ����������
		/// </summary>
		MemberFamilyInfo = 18,
		/// <summary>
		/// ��Ա�����޸��������
		/// </summary>
		MemberInfoTemp = 19,
		/// <summary>
		/// һ��������Ϣ
		/// </summary>
		FirstApprovedMemberMessage = 20,
		/// <summary>
		/// ����������Ϣ
		/// </summary>
		SecondApprovedMemberMessage = 21,
		/// <summary>
		/// SCS���
		/// </summary>
		SCSApproved = 22
	}
	#endregion

	#region �״̬
	/// <summary>
	/// �״̬��1�δ��ʼ��2���ֹ������3�������4�ȡ����
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
		/// ���֤����
		/// </summary>
		certificate_degree = 0,
		/// <summary>
		/// ����֤����
		/// </summary>
		certificate_earning = 1,
		/// <summary>
		/// ѧ��֤����
		/// </summary>
		certificate_edu = 2,
		/// <summary>
		/// ����֤����
		/// </summary>
		certificate_marriage = 3,
		/// <summary>
		/// ����֤��
		/// </summary>
		certificate_single = 4,
		/// <summary>
		/// ����֤��
		/// </summary>
		certificate_work = 5,

	}
	#endregion

	#region ��Ա��ʱ��������:1.�ǳ� 2.������ 3.���Ķ��� 4.����״�� 5.���� 6.��Ŀ�е�TA
	public enum MemberInfoTempType
	{
		/// <summary>
		/// �ǳơ�
		/// </summary>
		MemberInfoTempType_UserName = 1,
		/// <summary>
		/// �����ա�
		/// </summary>
		MemberInfoTempType_MainPic = 2,
		/// <summary>
		/// ���Ķ��ס�
		/// </summary>
		MemberInfoTempType_HeartSentence = 3,
		/// <summary>
		/// ����״��
		/// </summary>
		MemberInfoTempType_Marriage = 4,
		/// <summary>
		/// ����
		/// </summary>
		MemberInfoTempType_Income = 5,
		/// <summary>
		/// ��Ŀ�е�TA
		/// </summary>
		MemberInfoTempType_MyTA = 6,
		/// <summary>
		/// ��Ƶ
		/// </summary>
		MemberInfoType_MVideo = 7 ,

		/// <summary>
		/// ����
		/// </summary>
		MemberInfoTempType_MTripContent = 8 

	}
	#endregion

	#region BackUserType
	/// <summary>
	/// ��̨�û����ͣ�1��̨����2��Ӫ�û�,3��̨�û�
	/// </summary>
	public enum BackUserType
	{
		/// <summary>
		/// ��̨����
		/// </summary>
		AdminUserType = 1,
		/// <summary>
		/// ��Ӫ�û�
		/// </summary>
		SaleUserType = 2,
		/// <summary>
		/// ��̨�û�
		/// </summary>
		GeneralUserType = 3
	}
	#endregion

	#region ��Ʒ��� ProductType
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
		
		TripDemand = 13,//13 ��������
		MemberPlaza = 14 ,
		MessageBothSides=15, //˫���շ����Բ�Ʒ
		ChristmasNight = 16,  //2008��ʥ���ڻ
		TripMemberSendMessage=17, //�����λ�Ա������
		TripMemberLink=18,//�����λ�Ա��ϵ��ʽ
		TripDemandLink=19, //��������Ƹ��ƻ���Ա��ϵ��ʽ = 19
		TripDemandMessage=20, //��������Ƹ��ƻ���Ա���� 20 
	}
	#endregion

}
