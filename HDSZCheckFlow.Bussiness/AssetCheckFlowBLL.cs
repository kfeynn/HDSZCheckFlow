using System;
using System.Data;


namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetCheckFlowBLL ��ժҪ˵����
	/// </summary>
	public class AssetCheckFlowBLL
	{
		public AssetCheckFlowBLL(){}


		/// <summary>
		/// ��ѯ������ƥ�����������
		/// </summary>
		/// <param name="ApplyHeadKey">���ݱ�ͷId</param>
		/// <returns></returns>
		public static string TypeInFlow(int ApplyHeadKey)
		{
			return ""; 


		}

		/// <summary>
		/// ���ҵ�������Ԥ���漰���ĺ��鲿��
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static string FindDecisionDeptByApplyHeadPk(int ApplyHeadKey)
		{
			//ѭ�������ı��岿�֡�
			string DeptStr = "";
			//���ݱ�ͷ
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			
			if(ApplyHead != null )
			{
				//��ͷԤ��
				Entiy.AssetApplySheetBudget  ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey) ;
				if(ApplyBudget != null)
				{
					//���ݱ���
					Entiy.AssetApplySheetBody[] AssetBodys = Entiy.AssetApplySheetBody.FindByApplyHeadPk( ApplyHeadKey);
					if(AssetBodys!=null && AssetBodys.Length > 0 )
					{
						//Ԥ�㲿��
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
						if(BaseDept != null )
						{
							foreach (Entiy.AssetApplySheetBody AssetBody in AssetBodys)
							{
								//��Ŀ��Ŀ¼
								//���ұ���Ԥ�����
								Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.FindByYearAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDept.BudgetDeptCode ,AssetBody.SubjectName );
								if(AssetBudget !=null && AssetBudget.BaseDecisionDeptCode.Trim() != "")
								{
									//����������鲿���Ѿ�ͳ�ƣ����ټ�¼
									if(DeptStr.IndexOf(AssetBudget.BaseDecisionDeptCode.Trim()) < 0 )
									{
										//-------------Ŀǰ���鲿�������� 002300 001000--------------------
										//002300 һ����Ҫ����ǰ�档���������Ժ�˲�����Ҫ�޸ģ�
										if(DeptStr.Length > 0 )
										{
											if(DeptStr.Equals("002300"))
											{
												DeptStr = DeptStr + "," ;
												//�ϲ����к��鲿��
												DeptStr += AssetBudget.BaseDecisionDeptCode.Trim() ;
											}
											else
											{
												//�ϲ����к��鲿��
												DeptStr = AssetBudget.BaseDecisionDeptCode.Trim() + "," + DeptStr ;
											}
										}
										else
										{
											//�ϲ����к��鲿��
											DeptStr += AssetBudget.BaseDecisionDeptCode.Trim() ;
										}
										//----------------------------End---------------------------------
									}
								}
							}
						}
					}
				}
			}

			if(DeptStr =="0")
			{
				DeptStr = "";
			}

			return DeptStr;
		}



		/// <summary>
		/// ��ʼ�۸�þ�����������
		/// </summary>
		/// <param name="FinallyCheckKey">�۸�þ���ͷId</param>
		/// <returns></returns>
		public static int StartFinallyPriceCheckFlow(int FinallyCheckKey)
		{
			//����ֵ�� 1���� 2�Ѿ��ύ 3δ�ҵ����� ��4δ�ҵ����ݡ�5�Ѿ��ύ��
			//�۸�þ�������Ҫ������������������Թ̶�Ϊ ���� �� ���ܣ����� 
			int Flag = 1 ;
			//
			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);
			if(FinallyCheck == null )
			{
				return 4;
			}

			#region �Ƿ�Ϊ�ύ״̬
			
			string Submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
			
			if(Submit.IndexOf(FinallyCheck.ApplyProcessCode,0) == -1)
			{
				return 2;
			}

			#endregion

			//���õļ۸�þ���������
			string FlowId = System.Configuration.ConfigurationSettings.AppSettings["FinallyPriceCheckFlow"];

			//�������
			int CheckSetp = 0; int NextCheckStep = 0 ; int IsFinish = 1 ; int IsGiveUp = 0 ;  string NextCheckCode = "" ; 

			//��û��������ɫ
			if(FinallyCheck.CurrentCheckRole == null || "".Equals(FinallyCheck.CurrentCheckRole)) 
			{
				//�������
				CheckSetp = FinallyCheck.CheckSetp ;
			}
			//����һ������ɫ
			string NextCheckRole = PriceCheckFlow(int.Parse(FlowId),CheckSetp,out NextCheckStep,out IsFinish, out IsGiveUp, out NextCheckCode);
			//���õ���������
			FinallyCheck.CheckFlowInCompanyHeadPk = int.Parse(FlowId);
			//����������
			FinallyCheck.IsCheckInCompany         = 1 ;
			FinallyCheck.CheckSetp = NextCheckStep ;
			FinallyCheck.CurrentCheckRole = NextCheckRole ; 

			FinallyCheck.ApplyProcessCode = HDSZCheckFlow.Common.Const.SubmitPross ;

			FinallyCheck.Save ();
			

			if(IsGiveUp == 1 )
			{
				//���û���������,ѭ�����÷�������;
				//����������
				Flow_CheckAssetPriceApply(2,NextCheckCode,FinallyCheck.Id,"","",1);

			}
			else
			{
				//ȡ�������ʼ�
//				//���ݹ��ŷ��ʼ�            ���ʼ�(����2)
//				Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//				//Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHead.ApplySheetHeadPk );
//				Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(NextCheckRole,CheckStep,IsFinish,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//				mailBll.ThreadSendMail();
			}
			
			



			return Flag ;
		}



		
		/// <summary>
		/// �۸�þ�����
		/// </summary>
		/// <param name="agreeType">���� 1ͬ�� 2���� 0�ܾ�</param>
		/// <param name="myCode">�����˹���</param>
		/// <param name="AssetCheckApplyKey">�þ���Id</param>
		/// <param name="disPlaysCode">����˹���</param>
		/// <param name="posital">�������</param>
		/// <param name="sign"></param>
		public static void Flow_CheckAssetPriceApply(int AgreeType,string MyCode,int AssetCheckApplyKey,string DisPlaysCode,string Posital,int Sign)
		{
			try
			{
				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(AssetCheckApplyKey);
				if(FinallyCheck !=null)
				{
					//���������¼
					AddCheckPriceRecord(AgreeType,MyCode,AssetCheckApplyKey,FinallyCheck,DisPlaysCode,Posital,Sign);

					if(AgreeType == 1 || AgreeType == 2 )
					{
						#region ͬ�������

						//�������
						//int CheckSetp = 0;   IsFinish ��������������
						int NextCheckStep = 0 ; int IsFinish = 1 ; int IsGiveUp = 0 ;  string NextCheckCode = "" ; 

						//����һ������ɫ
						string NextCheckRole = PriceCheckFlow(FinallyCheck.CheckFlowInCompanyHeadPk,FinallyCheck.CheckSetp,out NextCheckStep,out IsFinish, out IsGiveUp, out NextCheckCode);

						if(IsFinish == 1  )
						{
							//����Ϊ��˾������
							FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;	
						}
						if(IsFinish == 2 )
						{
							//���½���״̬Ϊ����������
							FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		
						}

						//���µ�ǰ������ɫ
						FinallyCheck.CurrentCheckRole = NextCheckRole ;
						//���µ�ǰ��������
						FinallyCheck.CheckSetp        = NextCheckStep ;

						FinallyCheck.Save ();

						if(IsGiveUp == 1 )
						{
							//���û���������,ѭ�����÷�������;
							//����������
							Flow_CheckAssetPriceApply(2,NextCheckCode,FinallyCheck.Id,"","",1);
						}
						else
						{
							////���ݹ��ŷ��ʼ�            ���ʼ�(����2)
							//Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
							////Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHead.ApplySheetHeadPk );
							//Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(NextCheckRole,CheckStep,IsFinish,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
							//mailBll.ThreadSendMail();
						}
						#endregion 
					}
					else  //(AgreeType == 0 )
					{
						#region  �ܾ�
						//3.���½���״̬Ϊ   ����  ,������ɫ��Ϊ�� ,����ҲΪ�� 
													
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisPross ;
						
						FinallyCheck.Update();
						
//						//�����ʼ����ύ������Ա

						#endregion 
					}
				}
				
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("HDSZCheckFlow.Bussiness.AssetCheckFlowBLL",ex.Message);
			}
		}

		public static void AddCheckPriceRecord(int AgreeType,string MyCode,int AssetPriceCheckKey, Entiy.AssetFinallyPriceCheck  FinallyCheck ,string DisPlaysCode,string Posital,int Sign)
		{
			Entiy.ApplySheetCheckRecord ApplyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
			//applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//��������
			ApplyRecord.AssetCheckPriceHeadPk = AssetPriceCheckKey ;        //��������
			ApplyRecord.IsCheckInCompany=FinallyCheck.IsCheckInCompany;		//�������  ������/��˾�� 
			if(Sign == 2 )
			{
				ApplyRecord.CheckRole="" ;				//������ɫ
			}
			else
			{
				ApplyRecord.CheckRole=FinallyCheck.CurrentCheckRole ;				//������ɫ
				ApplyRecord.CheckSetp=FinallyCheck.CheckSetp;						//������
			}
			ApplyRecord.CheckPersonCode=MyCode;								//������Code
			ApplyRecord.CheckComment=Posital;								//�������
			ApplyRecord.Checkdate=DateTime.Now;								//����ʱ��
			if(!"".Equals(DisPlaysCode))                     
			{
				ApplyRecord.DisplaysPersonCode = DisPlaysCode;				//�������Code
				ApplyRecord.IsDisplays=1;									//�Ƿ��������
			}
			ApplyRecord.IsPass=AgreeType;									//�Ƿ�ͬ��

			ApplyRecord.Create();
		}


		/// <summary>
		/// �۸�þ���������
		/// </summary>
		/// <param name="FlowId">����Id</param>
		/// <param name="CheckSetp">��ǰ������</param>
		/// <param name="NextCheckStep">��һ�����������ز���</param>
		/// <param name="IsFinish">�Ƿ���������ز���</param>
		/// <param name="IsGiveUp">�Ƿ���������ز���</param>
		/// <returns>��һ������ɫ</returns>
		public static string PriceCheckFlow(int FlowId,int CheckSetp,out int NextCheckStep,out int IsFinish,out int IsGiveUp,out string NextCheckCode)
		{
			NextCheckStep = 0 ;
			IsFinish = 1 ;
			IsGiveUp = 0 ;
			NextCheckCode = "";

			Entiy.CheckFlowInCompanyBody FlowSetp=Entiy.CheckFlowInCompanyBody.FindStep(FlowId,CheckSetp);
			if(FlowSetp!=null)
			{
				if(FlowSetp.IsLastStep == 1)
				{
					//��˾�����Ѿ����
					IsFinish=2;
					//��һ������ɫ���
					return "";
				}
			}
			//��˾���������Ѿ���ʼ
			Entiy.CheckFlowInCompanyBody NextFlowSetp=Entiy.CheckFlowInCompanyBody.FindNextStep(FlowId,CheckSetp);
			if(NextFlowSetp!=null)
			{
				//��˾������δ���
				//IsFinish=1;
				//��һ��������
				NextCheckStep=NextFlowSetp.CheckStep;

				string MyCode = "";
				string CheckRole = NextFlowSetp.CheckRoleCode ;
				//���ݽ�ɫ��������Ա;�жϴ����Ƿ��������
				Entiy.CheckPersonInRole[] CheckPersons= Entiy.CheckPersonInRole.FindByRole(CheckRole);
				if(CheckPersons!=null && CheckPersons.Length>0)
				{
					Entiy.CheckPersonInRole CheckPerson = CheckPersons[0];
					MyCode = CheckPerson.PersonCode;
					NextCheckCode = CheckPerson.PersonCode;

					int GiveUp = Bussiness.UserInfoBLL.IsMyRoleGiveUp(MyCode);
					if(GiveUp > 0) {IsGiveUp = 1;}
					else           {IsGiveUp = 0;} 
				}
				//������һ������ɫ��Ϣ
				return NextFlowSetp.CheckRoleCode;
			}
			return "";

		}

		/// <summary>
		/// ��ѯ�����ҵ�����
		/// </summary>
		/// <param name="myCode">����</param>
		/// <returns></returns>
		public static DataSet GetMyAuditingForFinallyCheck(string myCode,string filter)
		{
			try
			{
				DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetMyAuditingForFinallyCheck(myCode,filter);
				if(ds!=null && ds.Tables.Count>0)
				{
					ds.Tables[0].Columns.Add("DisplaysPerson");
					for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
					{
						if(!myCode.Equals(ds.Tables[0].Rows[i]["PersonCode"].ToString()))
						{
							ds.Tables[0].Rows[i]["DisplaysPerson"]=ds.Tables[0].Rows[i]["PersonCode"].ToString();
							ds.Tables[0].Rows[i]["PersonCode"]=String.Empty;
						}
						else
						{
							ds.Tables[0].Rows[i]["Name"]=String.Empty;
						}
					}
				}
				return ds;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("ApplySheetHeadBLL.FGetMyAuditing",ex.Message );
				return null;
			}
		}

		//����Ѽ۸�þ�����
		public static void RemoveFinallyCheckNumber(int FinallyCheckId)
		{
			
			//�۸�þ�����
			Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheckId);
			if(FinallyCheckBodys !=null && FinallyCheckBodys.Length > 0 )
			{
				foreach(Entiy.AssetFinallyPriceCheckBody Finallybody in FinallyCheckBodys)
				{
					//�̶��ʲ����뵥����
					Entiy.AssetApplySheetBody AssetApplyBody = Entiy.AssetApplySheetBody.Find(Finallybody.AssetApplySheetBodyId );
					if(AssetApplyBody!= null)
					{
						if(AssetApplyBody.CheckNumber > 0 )
						{
							AssetApplyBody.CheckNumber = AssetApplyBody.CheckNumber - Finallybody.Number ;

							//����IsChecked
							if(AssetApplyBody.CheckNumber < AssetApplyBody.Number)
							{
								AssetApplyBody.IsChecked  = 0 ; 
							}
						}
						else
						{
							//AssetApplyBody.CheckNumber =  0 - Finallybody.Number ;
							AssetApplyBody.CheckNumber = 0 ;
							AssetApplyBody.IsChecked  = 0 ; 
						}

						AssetApplyBody.Update();
					}
				}
			}
		}

		//�ۼ��Ѽ۸�þ�����
		public static void AddFinallyCheckNumber(int FinallyCheckId)
		{
			//�۸�þ�����
			Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheckId);
			if(FinallyCheckBodys !=null && FinallyCheckBodys.Length > 0 )
			{
				foreach(Entiy.AssetFinallyPriceCheckBody Finallybody in FinallyCheckBodys)
				{
					int NowCheckedNumber = 0 ; 
					//�̶��ʲ����뵥����
					Entiy.AssetApplySheetBody AssetApplyBody = Entiy.AssetApplySheetBody.Find(Finallybody.AssetApplySheetBodyId );
					if(AssetApplyBody!= null)
					{
						if(AssetApplyBody.CheckNumber > 0 )
						{
							NowCheckedNumber = AssetApplyBody.CheckNumber + Finallybody.Number ;
						}
						else
						{
							NowCheckedNumber =   Finallybody.Number ;
						}

						AssetApplyBody.CheckNumber = NowCheckedNumber ; 

						AssetApplyBody.Update();

						//������Ӫ�������Ƿ��Ѽ۸�þ���Ϣ
						if(NowCheckedNumber >= AssetApplyBody.Number )
						{
							AssetApplyBody.IsChecked = 1 ;
							AssetApplyBody.Update();
						}

					}
				}
			}

		}



	}
}
