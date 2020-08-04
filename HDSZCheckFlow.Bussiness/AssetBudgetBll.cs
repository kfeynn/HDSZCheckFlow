using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetBudgetBll ��ժҪ˵����
	/// </summary>
	public class AssetBudgetBll
	{
		public AssetBudgetBll()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		public static DataSet SelectFirstClassSubjectByYearAndDept(int iYear,string DeptCode )
		{
			return DataAccess.Budget.AssetBudgetDAL.SelectFirstClassSubjectByYearAndDept(iYear,DeptCode); 
			
		}

		public static DataSet SelectSubItemByYearAndFirstItem(int iYear,string DeptCode,string ItemName)
		{
			return DataAccess.Budget.AssetBudgetDAL.SelectSubItemByYearAndFirstItem(iYear,DeptCode,ItemName); 

		}

		/// <summary>
		/// (��Ӫ)���ݵ��ݱ�ͷ��ѯԤ����Ϣ (�˷����ѱ�Bussiness.ApplyAuditingBLL.GetBudgetInfoByApplyHeadPk(applyHeadPK)���������� 2012-03-12 liyang)
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static DataSet SelectAssetBudgetByApplyHeadKey(int ApplyHeadKey)
		{
			//����DataSet ���� �� Ԥ����  Ԥ������  �Ѿ�ʹ��  ��̯���  ����ʹ��  ʣ��

			// 

			//Ԥ�����
			/*DataTable dt=new DataTable("ApplyBudgetInfo");//ApplyBugdetInfo
			dt.Columns.Add(new DataColumn("BudgetType", typeof(System.String)));//Ԥ������
			dt.Columns.Add(new DataColumn("BudgetMoney", typeof(System.Decimal)));//Ԥ����
			dt.Columns.Add(new DataColumn("PlanMoney", typeof(System.Decimal)));//������
			dt.Columns.Add(new DataColumn("ChangeMoney", typeof(System.Decimal)));//�������
			dt.Columns.Add(new DataColumn("UsedMoney", typeof(System.Decimal)));//ʹ�ý��
			dt.Columns.Add(new DataColumn("ThisMoey", typeof(System.Decimal)));//����ʹ�ý��
			dt.Columns.Add(new DataColumn("LeaveMoney", typeof(System.Decimal)));//���
			//dt.Columns.Add(new DataColumn("ApplySheetHead_Pk", typeof(System.Int32)));
			dt.Columns.Add(new DataColumn("ReadyPayMoney", typeof(System.Decimal)));//��̯���
			dt.Columns.Add(new DataColumn("AllowOutMoney", typeof(System.Decimal)));//Ԥ������
			*/

			Entiy.AssetApplySheetBudget budget=Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			
			if(budget == null )
			{
				return null;
			}


			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null )
			{
				//û�ҵ���ͷ
				return null;
			}
			Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(Dept == null || Dept.BudgetDeptCode.Length <=0)
			{
				//û�ҵ���Ӧ���� �����ӦԤ�㲿��Ϊ��
				return null;
			}
			Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(AssetBudget == null )
			{
				//û���ҵ���Ӧ��ͷԤ����Ϣ
				return null;
			}
			
			DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,AssetBudget.ItemName );
			if(ds!=null)
			{
				//myDs.Tables["table_hntky"].Rows[i]["SJCYMJ"] = 10000;
				ds.Tables[0].Columns.Add("ApplyMoney");

				//************************2011-11-08 liyang********************
				ds.Tables[0].Columns.Add("BudgetType");
				//Ԥ�����
				if(AssetBudget.SubmitType == 2 )
				{
					ds.Tables[0].Rows[0]["BudgetType"] = "Ԥ����";
					
				}
				else
				{
					ds.Tables[0].Rows[0]["BudgetType"] = "Ԥ����";
				}
				//**************************************************************

				//���ŵ���� 
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

				ds.Tables[0].Rows[0]["ApplyMoney"] = ThisMoney.ToString(); 

				//ʣ���� 2011-11-22 liyang
				decimal LeftMoney=decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString());

				//�����������ǰ�� (��ʣ��������ŵ���� ��ɴ�ӡ���ܵ������˸���) 2011-11-22 liyang
				//ds.Tables[0].Rows[0]["LeftMoney"] = decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()) - ThisMoney ;
				//ds.Tables[0].Rows[0]["BudgetMoney"]=budget.SheetRmbMoney.ToString();//Ԥ����(����ȡ�����ΪԤ�����)
				ds.Tables[0].Rows[0]["LeftMoney"] = LeftMoney.ToString(); //ʣ����
				ds.Tables[0].Rows[0]["TotalOutMoney"] = budget.AllowOutMoney.ToString();//Ԥ������
				ds.Tables[0].Rows[0]["CheckMoney"] = budget.SumCheckMoney.ToString();// ��ʹ�ý��

			}

			return ds;



		}

		/// <summary>
		/// ����Ԥ���������������Ϣ
		/// </summary>
		/// <param name="ApplyAssetHeadPk">���ݱ�ͷId</param>
		/// <returns></returns>
		public static bool UpdateAssetBudgetCheckMoneyByApply(int ApplyAssetHeadPk)
		{
			bool Flag = false;
			try
			{
				//���뵥��ͷ
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyAssetHeadPk);
				//���벿����Ϣ
				Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
				if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
				{
					Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyAssetHeadPk);
					//Ԥ����Ϣ
					Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
					//������Ϣ
					Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyAssetHeadPk);

					//�������
					using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
					{
						try
						{
							if(AssetBudget != null && AssetBudget.Length > 0 )
							{
								foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
								{
									decimal SubjectMoney = 0 ;
									//ѭ��Ԥ����Ϣ���塣 ��ѭ�������������Ŀ������Ԥ����Ϣ���� ��
									if(AssetBody != null && AssetBody.Length>0 )
									{
										foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
										{
											//AssetBodyInto.
											//��ͬ��Ŀ������
											if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
											{
												SubjectMoney += AssetBodyInto.RmbMoney;
											}
										}
									}
									AssetBudgetInfo.CheckMoney += SubjectMoney ; 
									AssetBudgetInfo.Update();
								}
							}
							//�����ύ
							tran.VoteCommit();
							Flag = true;
						}
						catch(Exception Ex)
						{
							//������
							tran.VoteRollBack();
							Common.Log.Logger.Log("AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply",Ex.Message);
							return false;
						}
					}

				}

			}
			catch(Exception Ex)
			{
				Common.Log.Logger.Log("AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply",Ex.Message);
				return false;
			}
		



			return Flag ;

		}


		/// <summary>
		/// ����Ԥ���������������Ϣ(ȡ�ص��ݣ��ۼ����������)
		/// </summary>
		/// <param name="ApplyAssetHeadPk">���ݱ�ͷId</param>
		/// <returns></returns>
		public static bool UpdateAssetBudgetCheckMoneyByApplyForGetBack(int ApplyAssetHeadPk)
		{
			bool Flag = false;
			try
			{
				//���뵥��ͷ
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyAssetHeadPk);
				//���벿����Ϣ
				Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
				if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
				{
					Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyAssetHeadPk);
					//Ԥ����Ϣ
					Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
					//������Ϣ
					Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyAssetHeadPk);

					//�������
					using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
					{
						try
						{
							if(AssetBudget != null && AssetBudget.Length > 0 )
							{
								foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
								{
									decimal SubjectMoney = 0 ;
									//ѭ��Ԥ����Ϣ���塣 ��ѭ�������������Ŀ������Ԥ����Ϣ���� ��
									if(AssetBody != null && AssetBody.Length>0 )
									{
										foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
										{
											//AssetBodyInto.
											//��ͬ��Ŀ������
											if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
											{
												SubjectMoney += AssetBodyInto.RmbMoney;
											}
										}
									}
									AssetBudgetInfo.CheckMoney -= SubjectMoney ; 
									AssetBudgetInfo.Update();
								}
							}
							//�����ύ
							tran.VoteCommit();
							Flag = true;
						}
						catch(Exception Ex)
						{
							//������
							tran.VoteRollBack();
							Common.Log.Logger.Log("AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply",Ex.Message);
							return false;
						}
					}

				}

			}
			catch(Exception Ex)
			{
				Common.Log.Logger.Log("AssetBudgetBll.UpdateAssetBudgetCheckMoneyByApply",Ex.Message);
				return false;
			}
		



			return Flag ;

		}

		/// <summary>
		/// ������Ӫ���뵥�ݿ�Ԥ�����ύ
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		public static void SetAssetApplyOverBudget(int ApplyHeadKey)
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					//��������Ѿ���Ԥ����״̬ �����ز����κζ���
					Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead != null)
					{
						if(ApplyHead.IsOverBudget == 1 )
						{
							return ;
						}
					}
					//���µ���Ϊ��Ԥ�����ύ ��Ԥ���ڲ����ύ��
					ApplyHead.IsOverBudget = 1 ; 
					ApplyHead.Save();

					///////////////����Ԥ��������Ϣ////////////////////////
					//���벿����Ϣ
					Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
					{
						Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						//Ԥ����Ϣ
						Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
						//������Ϣ
						Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);

						if(AssetBudget != null && AssetBudget.Length > 0)
						{
							foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
							{
								decimal SubjectMoney = 0 ;
								//ѭ��Ԥ����Ϣ���塣 ��ѭ�������������Ŀ������Ԥ����Ϣ���� ��
								if(AssetBody != null && AssetBody.Length>0 )
								{
									foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
									{
										//��ͬ��Ŀ������
										if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
										{
											SubjectMoney += AssetBodyInto.RmbMoney;
										}
									}
								}

//								//�۳���� ��Ԥ��
//
//								decimal OverMoney = SubjectMoney - (AssetBudgetInfo.BudgetMoney + AssetBudgetInfo.TotalAllowOutMoney - AssetBudgetInfo.CheckMoney - AssetBudgetInfo.ReadyPay) ;
//
//								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney + OverMoney ; 

								//������Ԥ��
								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney + SubjectMoney  ; 

								AssetBudgetInfo.Update();

							}
						}
					}

					//�ύ����
					tran.VoteCommit();
				}
				catch(Exception ex)
				{
					//��������
					tran.VoteRollBack();
					Common.Log.Logger.Log("Bussiness.AssetBudgetBll.SetAssetApplyOverBudget",ex.Message);

				}
			}

		}

		/// <summary>
		/// ȡ������Ԥ����ĵ���(�������)
		/// </summary>CancelAssetApplyOverBudget
		/// <param name="ApplyHeadKey"></param>
		public static void CancelAssetApplyOverBudget(int ApplyHeadKey)
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					//��������Ѿ�����Ԥ����״̬ �����ز����κζ���
					Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead != null)
					{
						if(ApplyHead.IsOverBudget != 1 )
						{
							return ;
						}
					}
					//���µ���Ϊ��Ԥ�����ύ
					ApplyHead.IsOverBudget = 0;
					ApplyHead.Save();

					///////////////����Ԥ��������Ϣ////////////////////////
					//���벿����Ϣ
					Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
					{
						Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						//Ԥ����Ϣ
						Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
						//������Ϣ
						Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);

						if(AssetBudget != null && AssetBudget.Length > 0)
						{
							foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
							{
								decimal SubjectMoney = 0 ;
								//ѭ��Ԥ����Ϣ���塣 ��ѭ�������������Ŀ������Ԥ����Ϣ���� ��
								if(AssetBody != null && AssetBody.Length>0 )
								{
									foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
									{
										//��ͬ��Ŀ������
										if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
										{
											SubjectMoney += AssetBodyInto.RmbMoney;
										}
									}
								}
//								// ��Ԥ��
//								decimal OverMoney = SubjectMoney - (AssetBudgetInfo.BudgetMoney  - AssetBudgetInfo.CheckMoney - AssetBudgetInfo.ReadyPay) ;
//								AssetBudgetInfo.TotalAllowOutMoney =   OverMoney - AssetBudgetInfo.TotalAllowOutMoney ; 

								//������Ԥ��
								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney - SubjectMoney  ; 

								AssetBudgetInfo.Update();
							}
						}
					}
					//�ύ����
					tran.VoteCommit();
				}
				catch(Exception ex)
				{
					//��������
					tran.VoteRollBack();
					Common.Log.Logger.Log("Bussiness.AssetBudgetBll.CancelAssetApplyOverBudget",ex.Message);
				}
			}
		}


		/// <summary>
		/// һ��ά���ύ���
		/// </summary>
		/// <param name="Iyear"></param>
		/// <param name="DeptCode"></param>
		/// <param name="ItemName"></param>
		/// <param name="SubjectName"></param>
		public static void ConsistencyCheckMoney(string Iyear,string DeptCode,string ItemName,string SubjectName)
		{
			DataAccess.Budget.AssetBudgetDAL.ConsistencyCheckMoney(Iyear,DeptCode,ItemName,SubjectName); 
		}

	}
}
