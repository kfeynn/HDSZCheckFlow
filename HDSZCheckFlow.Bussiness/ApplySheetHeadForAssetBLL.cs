using System;
using System.Data;
using System.Text;


namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplySheetHeadForAssetBLL 的摘要说明。
	/// </summary>
	public class ApplySheetHeadForAssetBLL
	{
		public ApplySheetHeadForAssetBLL(){}

		/// <summary>
		/// 设置按钮可用状态（固定资产类）
		/// </summary>
		/// <param name="ApplyHeadKey">单据头</param>
		/// <returns></returns>
		public static int SetButtonEnableForAsset (int ApplyHeadKey)
		{
			//单据没有表体 ，不可提交。                  -- 1 ，预算内，预算外都不可提交 
			//计算剩余金额，剩余金额小于0 不可提交。     -- 2   预算内可提交
			//标示有预算外可提交的 ，预算外可提交。      -- 3   预算外可提交
			//预算标识为新增的 ，预算外可提交。          -- 3
			//已经提交的表单                             -- 1

			if(!IsHaveApplyBody(ApplyHeadKey))
			{
				return 1;
			}

			//检验单据是否已经提交 
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
				{
					// 已经提交返回 1 
					return 1 ; 
				}
			}

			decimal LeftMoney = 0 ; 

			LeftMoney = ApplyLeftMoney(ApplyHeadKey);

			if(LeftMoney < 0 )
			{
				//剩余金额小于0 
				return 1 ; 
			}
			else
			{
				//标识有预算外的预算外可提交否则预算内提交 //对应预算科目是否是新增标示，如果是则为预算外提交

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

		//单据是否有表体
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

		//单据是否标注可预算外提交
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

		//所提交项目是否标示为预算外项目
		public static bool IsOverBudgetItem(int ApplyHeadKey)
		{
			//找表单对应的预算表 信息;
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyBudget == null )
			{
				return false ; 
			}
			//找表头信息 ;
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null)
			{
				return false; 
			}
			//找预算部门信息
			Entiy.BaseDept BudgetDept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(BudgetDept == null)
			{
				return false ;
			}
			//项目预算信息BudgetDept.BudgetDeptCode
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

		//计算单据的剩余金额
		public static decimal ApplyLeftMoney(int ApplyHeadKey)
		{
			//--------------根据表头Id查询出其所在预算科目的值----------------------------//

			//找表单对应的预算表 信息;
			Entiy.AssetApplySheetBudget ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey);
			if(ApplyBudget == null )
			{
				return -1 ; 
			}
			//找表头信息 ;
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead == null)
			{
				return -1; 
			}
			//找预算部门信息
			Entiy.BaseDept BudgetDept=Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
			if(BudgetDept == null)
			{
				return -1 ;
			}
			//找预算值 BudgetDept.BudgetDeptCode
			DataSet DsBudget = Bussiness.BudgetAccountBLL.getAssetBudgetInfo(ApplyHead.ApplyDate.Year,BudgetDept.BudgetDeptCode ,ApplyBudget.ItemName);
			if(DsBudget == null ||  DsBudget.Tables.Count <=0 )
			{
				return -1 ; 
			}
			//找表单总金额
			decimal ApplyMoney = Bussiness.ApplySheetHeadBLL.GetCheckMoneyByHeadPK(ApplyHeadKey);

			decimal LeftMoney = decimal.Parse(DsBudget.Tables[0].Rows[0]["LeftMoney"].ToString())  - ApplyMoney  ;

			return LeftMoney ;

		}


		///////////////////////////////////////取回单据的可用状态//////////////////////////////////////////////////
		
		/// <summary>
		/// 固定资产取回单据可用按钮状态
		/// </summary>
		/// <param name="ApplyHeadKey">单据表头Id</param>
		/// <returns></returns>
		public static int  SetButtonEnableForAssetGetBack (int ApplyHeadKey)
		{
			// 1 都不可用  所有其他情况
			// 2 取回可用  单据已提交但未开始审批 / 单据为驳回状态
			// 3 封存可用  单据为已取回状态 && 有审批记录

			int flag = 1 ;

			if(!IsHaveApplyBody(ApplyHeadKey))
			{
				//没有表体
				return 1;
			}
			//检验单据是否已经提交 
			Entiy.ApplySheetHead ApplyHead  = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			if(ApplyHead != null )
			{
				#region ...
//				string submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
//				if(submit.IndexOf(ApplyHead.ApplyProcessCode ,0) == -1)
//				{
//					// 已经提交,检查是否有审批记录
//
//					Entiy.ApplySheetCheckRecord[] CheckRecords = Entiy.ApplySheetCheckRecord.FindByApplyHeadKey(ApplyHead.ApplySheetHeadPk );
//					if(CheckRecords == null)
//					{
//						flag = 2 ; 
//					}
//				}
//				else
//				{
//					//单据状态
//					Entiy.ApplySheetCheckRecord[] CheckRecords = Entiy.ApplySheetCheckRecord.FindByApplyHeadKey(ApplyHead.ApplySheetHeadPk );
//					if(CheckRecords != null)
//					{
//						flag = 3 ; 
//					}
//				}
				#endregion 

				Entiy.ApplyProcessType ApplyProcess=Entiy.ApplyProcessType.Find(ApplyHead.ApplyProcessCode); //查看申请单进程
			
				if(ApplyProcess!=null)
				{
					if((ApplyProcess.IsSubmit == 1 && ApplyProcess.IsCheck==0  ) || ApplyProcess.IsDisallow == 1)  //新建还未有人审批 or 驳回
					{
						flag=2;
					}
					if(ApplyProcess.IsSubmit == 0 && ApplyProcess.IsSubmitAgain==1 && ApplyHead.IsKeeping != 1)
					{
						flag=3;                          //封存可用
					}
				}
			}
	
			return flag;

		}
		







		///////////////////////////////////////////////////////////////////////////////////////////////////////////










	}
}
