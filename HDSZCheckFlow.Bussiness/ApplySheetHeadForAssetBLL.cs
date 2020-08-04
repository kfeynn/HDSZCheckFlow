using System;
using System.Data;
using System.Text;


namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplySheetHeadForAssetBLL ��ժҪ˵����
	/// </summary>
	public class ApplySheetHeadForAssetBLL
	{
		public ApplySheetHeadForAssetBLL(){}

		/// <summary>
		/// ���ð�ť����״̬���̶��ʲ��ࣩ
		/// </summary>
		/// <param name="ApplyHeadKey">����ͷ</param>
		/// <returns></returns>
		public static int SetButtonEnableForAsset (int ApplyHeadKey)
		{
			//����û�б��� �������ύ��                  -- 1 ��Ԥ���ڣ�Ԥ���ⶼ�����ύ 
			//����ʣ���ʣ����С��0 �����ύ��     -- 2   Ԥ���ڿ��ύ
			//��ʾ��Ԥ������ύ�� ��Ԥ������ύ��      -- 3   Ԥ������ύ
			//Ԥ���ʶΪ������ ��Ԥ������ύ��          -- 3
			//�Ѿ��ύ�ı�                             -- 1

			if(!IsHaveApplyBody(ApplyHeadKey))
			{
				return 1;
			}

			//���鵥���Ƿ��Ѿ��ύ 
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
				{
					// �Ѿ��ύ���� 1 
					return 1 ; 
				}
			}

			decimal LeftMoney = 0 ; 

			LeftMoney = ApplyLeftMoney(ApplyHeadKey);

			if(LeftMoney < 0 )
			{
				//ʣ����С��0 
				return 1 ; 
			}
			else
			{
				//��ʶ��Ԥ�����Ԥ������ύ����Ԥ�����ύ //��ӦԤ���Ŀ�Ƿ���������ʾ���������ΪԤ�����ύ

				if(IsOverBudgetApply(ApplyHeadKey) || IsOverBudgetItem(ApplyHeadKey))
				{
					return 3;
				}
				else
				{
					return 2;
				}
			}
		}

		//�����Ƿ��б���
		public static bool IsHaveApplyBody(int ApplyHeadKey)
		{
			Entiy.AssetApplySheetBody[] ApplyBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey) ;
			if(ApplyBody != null && ApplyBody.Length > 0 )
			{
				return true;
			}
			else
			{
				return false ;
			}
		}

		//�����Ƿ��ע��Ԥ�����ύ
		public static bool IsOverBudgetApply(int ApplyHeadKey)
		{
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null)
			{
				if(ApplyHead.IsOverBudget == 1 ) 
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		//���ύ��Ŀ�Ƿ��ʾΪԤ������Ŀ
		public static bool IsOverBudgetItem(int ApplyHeadKey)
		{
			//�ұ���Ӧ��Ԥ��� ��Ϣ;
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyBudget == null )
			{
				return false ; 
			}
			//�ұ�ͷ��Ϣ ;
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null)
			{
				return false; 
			}
			//��Ԥ�㲿����Ϣ
			Entiy.BaseDept BudgetDept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(BudgetDept == null)
			{
				return false ;
			}
			//��ĿԤ����ϢBudgetDept.BudgetDeptCode
			Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.FindByYearAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName ,ApplyHead.ApplyDeptClassCode);
			if(AssetBudget != null && AssetBudget.IsNewAdd ==1 )
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		//���㵥�ݵ�ʣ����
		public static decimal ApplyLeftMoney(int ApplyHeadKey)
		{
			//--------------���ݱ�ͷId��ѯ��������Ԥ���Ŀ��ֵ----------------------------//

			//�ұ���Ӧ��Ԥ��� ��Ϣ;
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyBudget == null )
			{
				return -1 ; 
			}
			//�ұ�ͷ��Ϣ ;
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null)
			{
				return -1; 
			}
			//��Ԥ�㲿����Ϣ
			Entiy.BaseDept BudgetDept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(BudgetDept == null)
			{
				return -1 ;
			}
			//��Ԥ��ֵ BudgetDept.BudgetDeptCode
			DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BudgetDept.BudgetDeptCode ,ApplyBudget.ItemName);
			if(DsBudget == null ||  DsBudget.Tables.Count <=0 )
			{
				return -1 ; 
			}
			//�ұ��ܽ��
			decimal ApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

			decimal LeftMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["LeftMoney"].ToString())  - ApplyMoney  ;

			return LeftMoney ;

		}


		///////////////////////////////////////ȡ�ص��ݵĿ���״̬//////////////////////////////////////////////////
		
		/// <summary>
		/// �̶��ʲ�ȡ�ص��ݿ��ð�ť״̬
		/// </summary>
		/// <param name="ApplyHeadKey">���ݱ�ͷId</param>
		/// <returns></returns>
		public static int  SetButtonEnableForAssetGetBack (int ApplyHeadKey)
		{
			// 1 ��������  �����������
			// 2 ȡ�ؿ���  �������ύ��δ��ʼ���� / ����Ϊ����״̬
			// 3 ������  ����Ϊ��ȡ��״̬ && ��������¼

			int flag = 1 ;

			if(!IsHaveApplyBody(ApplyHeadKey))
			{
				//û�б���
				return 1;
			}
			//���鵥���Ƿ��Ѿ��ύ 
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				#region ...
//				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
//				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
//				{
//					// �Ѿ��ύ,����Ƿ���������¼
//
//					Entiy.ApplySheetCheckRecord[] CheckRecords = Entiy.ApplySheetCheckRecord.FindByApplyHeadKey(ApplyHead.ApplySheetHeadPk );
//					if(CheckRecords == null)
//					{
//						flag = 2 ; 
//					}
//				}
//				else
//				{
//					//����״̬
//					Entiy.ApplySheetCheckRecord[] CheckRecords = Entiy.ApplySheetCheckRecord.FindByApplyHeadKey(ApplyHead.ApplySheetHeadPk );
//					if(CheckRecords != null)
//					{
//						flag = 3 ; 
//					}
//				}
				#endregion 

				Entiy.ApplyProcessType ApplyProcess=Entiy.ApplyProcessType.Find(ApplyHead.ApplyProcessCode); //�鿴���뵥����
			
				if(ApplyProcess!=null)
				{
					if((ApplyProcess.IsSubmit == 1 && ApplyProcess.IsCheck==0  ) || ApplyProcess.IsDisallow == 1)  //�½���δ�������� or ����
					{
						flag=2;
					}
					if(ApplyProcess.IsSubmit == 0 && ApplyProcess.IsSubmitAgain==1 && ApplyHead.IsKeeping != 1)
					{
						flag=3;                          //������
					}
				}
			}
	
			return flag;

		}
		







		///////////////////////////////////////////////////////////////////////////////////////////////////////////










	}
}
