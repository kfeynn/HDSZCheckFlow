using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CheckFlowInDeptBLL ��ժҪ˵����
	/// </summary>
	public class CheckFlowInDeptBLL
	{
		public CheckFlowInDeptBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		/// <summary>
		/// ��ⲿ����������������Ϣ
		/// </summary>
		/// <param name="dtMessage"></param>
		public static void CheckAllFlowInDept(out DataTable dtMessage)
		{
			dtMessage=new DataTable();
			dtMessage.Columns.Add("�������");
			dtMessage.Columns.Add("������Ϣ");

			//1.��ȡ���п��������Ϣ
			DataTable dt=DataAccess.CheckFlow.CheckFlowInDeptDAL.GetDeptCodeInfo();
			if(dt!=null && dt.Rows.Count>0)
			{
				for(int i=0 ;i<dt.Rows.Count ;i++)
				{
					//2.ͨ����������ѯ����������Ϣ
					int result=DataAccess.CheckFlow.CheckFlowInDeptDAL.CheckFlowDeptCodeValid(dt.Rows[i][0].ToString());
					if(result!=0)
					{
						string message="";
						if(result==1)
						{
							message="���̲����н�����ʶ";
						}
						else if(result==2)
						{
							message="���ظ���������";
						}
						else if(result==3)
						{
							message="���̾��ж��������ʶ";
						}

						DataRow dr=dtMessage.NewRow();
						dr["�������"]=dt.Rows[i][1].ToString() ;
						dr["������Ϣ"]=message;
						dtMessage.Rows.Add(dr);
					}
				}
			}
		}


		/// <summary>
		/// �����û����뵥��,��ѯ��һ(��ǰ)������ɫ
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static string GetCheckRole(int ApplyHeadPk,out string Message)
		{
			Message="";
			//1.��ѯ ���ڵ� ���� ��,,�鿴 ��ǰ�������(��˾�� || ������),,�鿴 ��ǰ������ɫ.
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(applyHead==null)
			{
				Common.Log.Logger.Log("Bussiness.CheckAllFlowInDept","��ѯ��ǰ������ɫ����,�Ҳ������뵥��ͷ!");
				Message="��ѯ��ǰ������ɫ����,�Ҳ������뵥��ͷ!";
				return "" ;
			}
			else
			{
				if(applyHead.IsCheckInCompany == 0)         //Ŀǰ�����ڲ�����
				{
					if(applyHead.CurrentCheckRole == null || "".Equals(applyHead.CurrentCheckRole)) //��δ��������ɫ
					{
						Entiy.CheckFlowInDept nextStep=Entiy.CheckFlowInDept.FindNextStep(applyHead.ApplyDeptCode,0);
						if(nextStep!=null)  
						{
							return nextStep.CheckRoleCode;
						}
						else
						{
							//û���ҵ���Ӧ����������
							Message="û���ҵ���Ӧ����������";
							return "";
						}
					}
					else
					{
						// �鿴 ������¼��  1.��ͷ 2. ������/�� 3.������ɫ. �鿴��������ɫ��Step 
						Entiy.ApplySheetCheckRecord applySheetCheckRecord=Entiy.ApplySheetCheckRecord.FindLastStep(ApplyHeadPk,applyHead.IsCheckInCompany);
						if(applySheetCheckRecord!=null)
						{
							Entiy.CheckFlowInDept nextStep=Entiy.CheckFlowInDept.FindNextStep(applyHead.ApplyDeptCode,applySheetCheckRecord.CheckSetp);
							if(nextStep!=null)  
							{
								return nextStep.CheckRoleCode;
							}
							else
							{
								//û���ҵ���Ӧ����������
								Message="û���ҵ���Ӧ����������";
								return "";
							}
						}
						else
						{
							return applyHead.CurrentCheckRole; //����ԭ�н�ɫ
						}
					}
				}
				else if(applyHead.IsCheckInCompany == 1)  // Ŀǰ�������˲���,�ڹ�˾��
				{
					// �鿴 ������¼��  1.��ͷ 2. ������/�� 3.������ɫ. �鿴��������ɫ��Step 
					Entiy.ApplySheetCheckRecord applySheetCheckRecord=Entiy.ApplySheetCheckRecord.FindLastStep(ApplyHeadPk,applyHead.IsCheckInCompany);
					if(applySheetCheckRecord == null)
					{
						//��˾�������Ż�δ��ʼ
						Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,0);
						if(checkFlowInCompanyBody!=null)
						{
							return checkFlowInCompanyBody.CheckRoleCode;
						}
						else
						{
							Message="û���ҵ���Ӧ��˾����";
							return "";
						}
					}
					else
					{
						//��˾���������Ѿ���ʼ
						Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,applySheetCheckRecord.CheckSetp);
						if(checkFlowInCompanyBody!=null)
						{
							return checkFlowInCompanyBody.CheckRoleCode;
						}
						else
						{
							Message="�����Ѿ�������";
							return "";
						}						
					}
				}
				return "";
			}
		}



		/// <summary>
		/// �����û����뵥��,��ѯ��һ(��ǰ)������ɫ
		/// </summary>
		/// <param name="ApplyHeadPk">��ͷ����</param>
		/// <param name="CheckStep" >����������</param>
		/// <param name="DeptToCompany">���Ƿ�˾��</param>
		/// <param name="Message" >����ʾ��Ϣ</param>
		/// <returns>���ؽ�ɫ����</returns>
		public static string GetCheckRole2(int ApplyHeadPk,out int CheckStep,out int DeptToCompany,out string Message,out int IsGiveUp,out string NextCheckCode)
		{
			Message="";

			CheckStep=0;     


			DeptToCompany=0;          // 0 ������ ,1 �Ӳ�����ת����˾�� ! ,2 ��˾�����Ѿ�����

			IsGiveUp = 0 ;    //�û��Ƿ��������Ȩ��;
            NextCheckCode = "" ; 

			//1.��ѯ���ڵĿ����,,�鿴 ��ǰ�������(��˾�� || ������),,�鿴 ��ǰ������ɫ.
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(applyHead==null)
			{
				Common.Log.Logger.Log("Bussiness.CheckAllFlowInDept","��ѯ��ǰ������ɫ����,�Ҳ������뵥��ͷ!");
				return "" ;
			}
			else
			{
				if(applyHead.IsCheckInCompany == 0)         
				{
					#region Ŀǰ�����ڲ�����
					if(applyHead.CurrentCheckRole == null || "".Equals(applyHead.CurrentCheckRole)) //��δ��������ɫ
					{

						/////////////////////2014.03.24�޸� //���� �������� ��ʵ��ͱ� �� 0 ��ʼ��0�����òɹ�Ա������Ա�� �������� 1 ��ʼ   
						int flag = 0 ;
						Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   
						if(applyTypes !=null )
						{
							if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
							{
								flag = -1 ;    //ʵ�ﹺ����� 0 ��ʼ����������Ա������������ϣ����� 0 �ɹ�Ա  �ײ�Ϊ > -1 Ϊ 0 
							}

							 
							if ("102".Equals(applyTypes.ApplyTypeCode) && "001000".Equals(applyHead.ApplyDeptClassCode) )   //   102	�ͱ����� \ 001000 ���� ���Ŵ��� 
							{
								//2015-10-11 �޸� ��������Ϊ  �ͱ������� �� ��� -2 ��ʼ ��Ϊ���������ҿ��� ���񸱿Ƴ� ���� �� ��ʱ�� ȱ�� ��˳�� �������񸱿Ƴ�  �� �ɹ�Ա
								flag = -2 ;
							}
						}

						
						///
						
						




						 
						Entiy.CheckFlowInDept nextStep=Entiy.CheckFlowInDept.FindNextStep(applyHead.ApplyDeptCode,flag);  
						if(nextStep!=null)  
						{
							CheckStep=nextStep.CheckSetp;
							NextCheckCode = nextStep.CheckPersonCode ;

							string checkCode = nextStep.CheckPersonCode ;

							int GiveUp = Bussiness.UserInfoBLL.IsMyRoleGiveUp(checkCode);
							if(GiveUp > 0) {IsGiveUp = 1;}
							else           {IsGiveUp = 0;} 

							 
							
							return nextStep.CheckRoleCode;
						}
						else
						{
							//û���ҵ���Ӧ����������
							Message="û���ҵ���Ӧ����������";
							return "";
						}
					}
					else
					{
						//�ж��Ƿ����ڽ������ǲ��������̴���.
						Entiy.CheckFlowInDept flowInDept=Entiy.CheckFlowInDept.FindStep(applyHead.ApplyDeptCode,applyHead.CheckSetp);
						if(flowInDept != null)
						{
							if(flowInDept.IsLastStep == 0)     //δ�������ڽ���
							{
								Entiy.CheckFlowInDept nextStep=Entiy.CheckFlowInDept.FindNextStep(applyHead.ApplyDeptCode,applyHead.CheckSetp);
								if(nextStep!=null)  
								{
									CheckStep=nextStep.CheckSetp ;
									NextCheckCode = nextStep.CheckPersonCode ;

									string checkCode = nextStep.CheckPersonCode ;

									int GiveUp = Bussiness.UserInfoBLL.IsMyRoleGiveUp(checkCode);
									if(GiveUp > 0) {IsGiveUp = 1;}
									else           {IsGiveUp = 0;} 


									return nextStep.CheckRoleCode;
								}
								else
								{
									//û���ҵ���Ӧ����������
									Message="û���ҵ���Ӧ����������";
									return "";
								}
							}
							else   //�������Ѿ�����
							{
								Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,0);
								if(checkFlowInCompanyBody!=null)
								{
									DeptToCompany=1;                                //�����ڽ���,��˾�ڿ�ʼ
									CheckStep=checkFlowInCompanyBody.CheckStep;


									string myCode = "";
									string checkRole = checkFlowInCompanyBody.CheckRoleCode ;
									//���ݽ�ɫ��������Ա;�жϴ����Ƿ��������
									Entiy.CheckPersonInRole[] checkPersons= Entiy.CheckPersonInRole.FindByRole(checkRole);
									if(checkPersons!=null && checkPersons.Length>0)
									{
										Entiy.CheckPersonInRole CheckPerson = checkPersons[0];
										myCode = CheckPerson.PersonCode;

										NextCheckCode = CheckPerson.PersonCode;

										int GiveUp = Bussiness.UserInfoBLL.IsMyRoleGiveUp(myCode);
										if(GiveUp > 0) {IsGiveUp = 1;}
										else           {IsGiveUp = 0;} 
									}


									return checkFlowInCompanyBody.CheckRoleCode;
								}
								else
								{
									Message="û���ҵ���Ӧ��˾����";
									return "";
								}
							}
						}
					}
					#endregion 
				}
				else if(applyHead.IsCheckInCompany == 1)  
				{
					#region Ŀǰ�������˲���,�ڹ�˾��
					Entiy.CheckFlowInCompanyBody FlowSetp=Entiy.CheckFlowInCompanyBody.FindStep(applyHead.CheckFlowInCompanyHeadPk,applyHead.CheckSetp);
					if(FlowSetp!=null)
					{
						if(FlowSetp.IsLastStep == 1)
						{
							//��˾�����Ѿ����
							DeptToCompany=2;
							Message="�����Ѿ�������";
							return "";
						}
						else
						{							
							//��˾���������Ѿ���ʼ
							Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,applyHead.CheckSetp);
							if(checkFlowInCompanyBody!=null)
							{
								DeptToCompany=1;
								CheckStep=checkFlowInCompanyBody.CheckStep;

								string myCode = "";
								string checkRole = checkFlowInCompanyBody.CheckRoleCode ;
								//���ݽ�ɫ��������Ա;�жϴ����Ƿ��������
								Entiy.CheckPersonInRole[] checkPersons= Entiy.CheckPersonInRole.FindByRole(checkRole);
								if(checkPersons!=null && checkPersons.Length>0)
								{
									Entiy.CheckPersonInRole CheckPerson = checkPersons[0];
									myCode = CheckPerson.PersonCode;

									NextCheckCode = CheckPerson.PersonCode;


									int GiveUp = Bussiness.UserInfoBLL.IsMyRoleGiveUp(myCode);
									if(GiveUp > 0) {IsGiveUp = 1;}
									else           {IsGiveUp = 0;} 
								}


								return checkFlowInCompanyBody.CheckRoleCode;
							}
						}
					}
					#endregion  
				}
//				else
//				{
//					return "";
//				}
				return "";
			}
		}


		/// <summary>
		/// ��ȡ�û����ڲ���ID
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static DataTable  GetDeptForUserID(int UserID)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForUserID(UserID);
		}

		/// <summary>
		/// ���ݲ��Ų�ѯ����
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClass(string DeptClassCode)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClass(DeptClassCode);
		}

		/// <summary>
		/// ���ݲ��Ų�ѯ����
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassForAdd(string DeptClassCode)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClassForAdd(DeptClassCode);
		} 


		//*******************************************************С��̶��ʲ����õ������²���(2013-12-10 liyang)****************************************************
		/// <summary>
		/// ��ȡ���в�����Ϣ
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAllDeptBySmallFixed()
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetAllDeptBySmallFixed();
		} 

		/// <summary>
		/// ���ݲ��Ų�ѯ������Ϣ(�ݹ鲿���µ����пƺ�����Ϣ)
		/// </summary>
		/// <param name="fbmbh">���ڵ����</param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassBySmallFixed(string fbmbh)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClassBySmallFixed(fbmbh);
		}

		//************************************************************************************************************************************************************



		/// <summary>
		/// ��ѯ�����ڽ�ɫ,��Ա
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static DataTable GetFlowInDeptByQuery(string query)
		{
			return DataAccess.CheckFlow.CheckFlowInDeptDAL. GetFlowInDeptByQuery( query);
		}


	}
}
