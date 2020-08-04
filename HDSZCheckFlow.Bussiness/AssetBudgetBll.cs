using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetBudgetBll 的摘要说明。
	/// </summary>
	public class AssetBudgetBll
	{
		public AssetBudgetBll()
		{
			//
			// TODO: 在此处添加构造函数逻辑
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
		/// (新营)根据单据表头查询预算信息 (此方法已被Bussiness.ApplyAuditingBLL.GetBudgetInfoByApplyHeadPk(applyHeadPK)方法所代替 2012-03-12 liyang)
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static DataSet SelectAssetBudgetByApplyHeadKey(int ApplyHeadKey)
		{
			//返回DataSet 包含 ： 预算金额  预算外金额  已经使用  待摊金额  本次使用  剩余

			// 

			//预算情况
			/*DataTable dt=new DataTable("ApplyBudgetInfo");//ApplyBugdetInfo
			dt.Columns.Add(new DataColumn("BudgetType", typeof(System.String)));//预算类型
			dt.Columns.Add(new DataColumn("BudgetMoney", typeof(System.Decimal)));//预算金额
			dt.Columns.Add(new DataColumn("PlanMoney", typeof(System.Decimal)));//推算金额
			dt.Columns.Add(new DataColumn("ChangeMoney", typeof(System.Decimal)));//调整金额
			dt.Columns.Add(new DataColumn("UsedMoney", typeof(System.Decimal)));//使用金额
			dt.Columns.Add(new DataColumn("ThisMoey", typeof(System.Decimal)));//本次使用金额
			dt.Columns.Add(new DataColumn("LeaveMoney", typeof(System.Decimal)));//余额
			//dt.Columns.Add(new DataColumn("ApplySheetHead_Pk", typeof(System.Int32)));
			dt.Columns.Add(new DataColumn("ReadyPayMoney", typeof(System.Decimal)));//待摊金额
			dt.Columns.Add(new DataColumn("AllowOutMoney", typeof(System.Decimal)));//预算外金额
			*/

			Entiy.AssetApplySheetBudget budget=Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			
			if(budget == null )
			{
				return null;
			}


			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null )
			{
				//没找到表头
				return null;
			}
			Entiy.BaseDept Dept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(Dept == null || Dept.BudgetDeptCode.Length <=0)
			{
				//没找到对应部门 或其对应预算部门为空
				return null;
			}
			Entiy.AssetApplySheetBudget AssetBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(AssetBudget == null )
			{
				//没有找到对应表头预算信息
				return null;
			}
			
			DataSet ds = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year ,Dept.BudgetDeptCode,AssetBudget.ItemName );
			if(ds!=null)
			{
				//myDs.Tables["table_hntky"].Rows[i]["SJCYMJ"] = 10000;
				ds.Tables[0].Columns.Add("ApplyMoney");

				//************************2011-11-08 liyang********************
				ds.Tables[0].Columns.Add("BudgetType");
				//预算类别
				if(AssetBudget.SubmitType == 2 )
				{
					ds.Tables[0].Rows[0]["BudgetType"] = "预算外";
					
				}
				else
				{
					ds.Tables[0].Rows[0]["BudgetType"] = "预算内";
				}
				//**************************************************************

				//本张单金额 
				decimal ThisMoney=Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

				ds.Tables[0].Rows[0]["ApplyMoney"] = ThisMoney.ToString(); 

				//剩余金额 2011-11-22 liyang
				decimal LeftMoney=decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString());

				//以下这个是以前的 (用剩余金额减本张单金额 造成打印功能的余额成了负数) 2011-11-22 liyang
				//ds.Tables[0].Rows[0]["LeftMoney"] = decimal.Parse(ds.Tables[0].Rows[0]["LeftMoney"].ToString()) - ThisMoney ;
				//ds.Tables[0].Rows[0]["BudgetMoney"]=budget.SheetRmbMoney.ToString();//预算金额(发现取这个做为预算金额不对)
				ds.Tables[0].Rows[0]["LeftMoney"] = LeftMoney.ToString(); //剩余金额
				ds.Tables[0].Rows[0]["TotalOutMoney"] = budget.AllowOutMoney.ToString();//预算外金额
				ds.Tables[0].Rows[0]["CheckMoney"] = budget.SumCheckMoney.ToString();// 已使用金额

			}

			return ds;



		}

		/// <summary>
		/// 更新预算表的已审批金额信息
		/// </summary>
		/// <param name="ApplyAssetHeadPk">单据表头Id</param>
		/// <returns></returns>
		public static bool UpdateAssetBudgetCheckMoneyByApply(int ApplyAssetHeadPk)
		{
			bool Flag = false;
			try
			{
				//申请单表头
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyAssetHeadPk);
				//申请部门信息
				Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
				if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
				{
					Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyAssetHeadPk);
					//预算信息
					Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
					//表体信息
					Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyAssetHeadPk);

					//事务管理
					using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
					{
						try
						{
							if(AssetBudget != null && AssetBudget.Length > 0 )
							{
								foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
								{
									decimal SubjectMoney = 0 ;
									//循环预算信息表体。 套循环表单表体计算项目金额，更新预算信息表体 。
									if(AssetBody != null && AssetBody.Length>0 )
									{
										foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
										{
											//AssetBodyInto.
											//相同项目金额相加
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
							//事务提交
							tran.VoteCommit();
							Flag = true;
						}
						catch(Exception Ex)
						{
							//事务会滚
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
		/// 更新预算表的已审批金额信息(取回单据，扣减金额。反向操作)
		/// </summary>
		/// <param name="ApplyAssetHeadPk">单据表头Id</param>
		/// <returns></returns>
		public static bool UpdateAssetBudgetCheckMoneyByApplyForGetBack(int ApplyAssetHeadPk)
		{
			bool Flag = false;
			try
			{
				//申请单表头
				Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyAssetHeadPk);
				//申请部门信息
				Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
				if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
				{
					Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyAssetHeadPk);
					//预算信息
					Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
					//表体信息
					Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyAssetHeadPk);

					//事务管理
					using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
					{
						try
						{
							if(AssetBudget != null && AssetBudget.Length > 0 )
							{
								foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
								{
									decimal SubjectMoney = 0 ;
									//循环预算信息表体。 套循环表单表体计算项目金额，更新预算信息表体 。
									if(AssetBody != null && AssetBody.Length>0 )
									{
										foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
										{
											//AssetBodyInto.
											//相同项目金额相加
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
							//事务提交
							tran.VoteCommit();
							Flag = true;
						}
						catch(Exception Ex)
						{
							//事务会滚
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
		/// 设置新营申请单据可预算外提交
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		public static void SetAssetApplyOverBudget(int ApplyHeadKey)
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					//如果单据已经是预算外状态 ，返回不做任何动作
					Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead != null)
					{
						if(ApplyHead.IsOverBudget == 1 )
						{
							return ;
						}
					}
					//更新单据为可预算外提交 （预算内不可提交）
					ApplyHead.IsOverBudget = 1 ; 
					ApplyHead.Save();

					///////////////更新预算外金额信息////////////////////////
					//申请部门信息
					Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
					{
						Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						//预算信息
						Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
						//表体信息
						Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);

						if(AssetBudget != null && AssetBudget.Length > 0)
						{
							foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
							{
								decimal SubjectMoney = 0 ;
								//循环预算信息表体。 套循环表单表体计算项目金额，更新预算信息表体 。
								if(AssetBody != null && AssetBody.Length>0 )
								{
									foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
									{
										//相同项目金额相加
										if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
										{
											SubjectMoney += AssetBodyInto.RmbMoney;
										}
									}
								}

//								//扣除余额 超预算
//
//								decimal OverMoney = SubjectMoney - (AssetBudgetInfo.BudgetMoney + AssetBudgetInfo.TotalAllowOutMoney - AssetBudgetInfo.CheckMoney - AssetBudgetInfo.ReadyPay) ;
//
//								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney + OverMoney ; 

								//按单超预算
								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney + SubjectMoney  ; 

								AssetBudgetInfo.Update();

							}
						}
					}

					//提交更新
					tran.VoteCommit();
				}
				catch(Exception ex)
				{
					//撤销更新
					tran.VoteRollBack();
					Common.Log.Logger.Log("Bussiness.AssetBudgetBll.SetAssetApplyOverBudget",ex.Message);

				}
			}

		}

		/// <summary>
		/// 取消设置预算外的单据(反向操作)
		/// </summary>CancelAssetApplyOverBudget
		/// <param name="ApplyHeadKey"></param>
		public static void CancelAssetApplyOverBudget(int ApplyHeadKey)
		{
			using(Castle.ActiveRecord.TransactionScope tran = new Castle.ActiveRecord.TransactionScope())
			{
				try
				{
					//如果单据已经不是预算外状态 ，返回不做任何动作
					Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
					if(ApplyHead != null)
					{
						if(ApplyHead.IsOverBudget != 1 )
						{
							return ;
						}
					}
					//更新单据为非预算外提交
					ApplyHead.IsOverBudget = 0;
					ApplyHead.Save();

					///////////////更新预算外金额信息////////////////////////
					//申请部门信息
					Entiy.BaseDept BaseDetp = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode );
					if(BaseDetp !=null && BaseDetp.BudgetDeptCode.Length > 0 )
					{
						Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
						//预算信息
						Entiy.AssetBudget[] AssetBudget = Entiy.AssetBudget.FindByYearBudgetDeptAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDetp.BudgetDeptCode );
						//表体信息
						Entiy.AssetApplySheetBody[] AssetBody = Entiy.AssetApplySheetBody.FindByApplyHeadPk(ApplyHeadKey);

						if(AssetBudget != null && AssetBudget.Length > 0)
						{
							foreach(Entiy.AssetBudget AssetBudgetInfo in AssetBudget)
							{
								decimal SubjectMoney = 0 ;
								//循环预算信息表体。 套循环表单表体计算项目金额，更新预算信息表体 。
								if(AssetBody != null && AssetBody.Length>0 )
								{
									foreach(Entiy.AssetApplySheetBody AssetBodyInto in AssetBody)
									{
										//相同项目金额相加
										if(AssetBudgetInfo.SubjectName.Equals(AssetBodyInto.SubjectName))
										{
											SubjectMoney += AssetBodyInto.RmbMoney;
										}
									}
								}
//								// 超预算
//								decimal OverMoney = SubjectMoney - (AssetBudgetInfo.BudgetMoney  - AssetBudgetInfo.CheckMoney - AssetBudgetInfo.ReadyPay) ;
//								AssetBudgetInfo.TotalAllowOutMoney =   OverMoney - AssetBudgetInfo.TotalAllowOutMoney ; 

								//按单超预算
								AssetBudgetInfo.TotalAllowOutMoney = AssetBudgetInfo.TotalAllowOutMoney - SubjectMoney  ; 

								AssetBudgetInfo.Update();
							}
						}
					}
					//提交更新
					tran.VoteCommit();
				}
				catch(Exception ex)
				{
					//撤销更新
					tran.VoteRollBack();
					Common.Log.Logger.Log("Bussiness.AssetBudgetBll.CancelAssetApplyOverBudget",ex.Message);
				}
			}
		}


		/// <summary>
		/// 一键维护提交金额
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
