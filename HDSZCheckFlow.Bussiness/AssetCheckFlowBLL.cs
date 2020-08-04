using System;
using System.Data;


namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetCheckFlowBLL 的摘要说明。
	/// </summary>
	public class AssetCheckFlowBLL
	{
		public AssetCheckFlowBLL(){}


		/// <summary>
		/// 查询单据所匹配的审批流程
		/// </summary>
		/// <param name="ApplyHeadKey">单据表头Id</param>
		/// <returns></returns>
		public static string TypeInFlow(int ApplyHeadKey)
		{
			return ""; 


		}

		/// <summary>
		/// 查找单据所用预算涉及到的合议部门
		/// </summary>
		/// <param name="ApplyHeadKey"></param>
		/// <returns></returns>
		public static string FindDecisionDeptByApplyHeadPk(int ApplyHeadKey)
		{
			//循环本表单的表体部分。
			string DeptStr = "";
			//单据表头
			Entiy.ApplySheetHead ApplyHead = Entiy.ApplySheetHead.Find(ApplyHeadKey);
			
			if(ApplyHead != null )
			{
				//表头预算
				Entiy.AssetApplySheetBudget  ApplyBudget = Entiy.AssetApplySheetBudget.FindByApplyHeadPk(ApplyHeadKey) ;
				if(ApplyBudget != null)
				{
					//单据表体
					Entiy.AssetApplySheetBody[] AssetBodys = Entiy.AssetApplySheetBody.FindByApplyHeadPk( ApplyHeadKey);
					if(AssetBodys!=null && AssetBodys.Length > 0 )
					{
						//预算部门
						Entiy.BaseDept BaseDept = Entiy.BaseDept.FindByDeptCode(ApplyHead.ApplyDeptCode);
						if(BaseDept != null )
						{
							foreach (Entiy.AssetApplySheetBody AssetBody in AssetBodys)
							{
								//项目子目录
								//查找本单预算情况
								Entiy.AssetBudget AssetBudget = Entiy.AssetBudget.FindByYearAndItem(ApplyHead.ApplyDate.Year,ApplyBudget.ItemName,BaseDept.BudgetDeptCode ,AssetBody.SubjectName );
								if(AssetBudget !=null && AssetBudget.BaseDecisionDeptCode.Trim() != "")
								{
									//如果此条合议部门已经统计，则不再记录
									if(DeptStr.IndexOf(AssetBudget.BaseDecisionDeptCode.Trim()) < 0 )
									{
										//-------------目前合议部门有两个 002300 001000--------------------
										//002300 一定需要排再前面。。。。（以后此部分需要修改）
										if(DeptStr.Length > 0 )
										{
											if(DeptStr.Equals("002300"))
											{
												DeptStr = DeptStr + "," ;
												//合并所有合议部门
												DeptStr += AssetBudget.BaseDecisionDeptCode.Trim() ;
											}
											else
											{
												//合并所有合议部门
												DeptStr = AssetBudget.BaseDecisionDeptCode.Trim() + "," + DeptStr ;
											}
										}
										else
										{
											//合并所有合议部门
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
		/// 开始价格裁决单审批流程
		/// </summary>
		/// <param name="FinallyCheckKey">价格裁决表头Id</param>
		/// <returns></returns>
		public static int StartFinallyPriceCheckFlow(int FinallyCheckKey)
		{
			//返回值： 1正常 2已经提交 3未找到流程 。4未找到单据。5已经提交。
			//价格裁决：不需要部门内审批，流程相对固定为 财务 ＋ （总）经理 
			int Flag = 1 ;
			//
			Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyCheckKey);
			if(FinallyCheck == null )
			{
				return 4;
			}

			#region 是否为提交状态
			
			string Submit = System.Configuration.ConfigurationSettings.AppSettings["SubmitType"];
			
			if(Submit.IndexOf(FinallyCheck.ApplyProcessCode,0) == -1)
			{
				return 2;
			}

			#endregion

			//配置的价格裁决审批流程
			string FlowId = System.Configuration.ConfigurationSettings.AppSettings["FinallyPriceCheckFlow"];

			//输出参数
			int CheckSetp = 0; int NextCheckStep = 0 ; int IsFinish = 1 ; int IsGiveUp = 0 ;  string NextCheckCode = "" ; 

			//还没有审批角色
			if(FinallyCheck.CurrentCheckRole == null || "".Equals(FinallyCheck.CurrentCheckRole)) 
			{
				//输出参数
				CheckSetp = FinallyCheck.CheckSetp ;
			}
			//找下一审批角色
			string NextCheckRole = PriceCheckFlow(int.Parse(FlowId),CheckSetp,out NextCheckStep,out IsFinish, out IsGiveUp, out NextCheckCode);
			//采用的审批流程
			FinallyCheck.CheckFlowInCompanyHeadPk = int.Parse(FlowId);
			//部门外审批
			FinallyCheck.IsCheckInCompany         = 1 ;
			FinallyCheck.CheckSetp = NextCheckStep ;
			FinallyCheck.CurrentCheckRole = NextCheckRole ; 

			FinallyCheck.ApplyProcessCode = HDSZCheckFlow.Common.Const.SubmitPross ;

			FinallyCheck.Save ();
			

			if(IsGiveUp == 1 )
			{
				//此用户放弃审批,循环调用方法本身;
				//放弃审批。
				Flow_CheckAssetPriceApply(2,NextCheckCode,FinallyCheck.Id,"","",1);

			}
			else
			{
				//取消发送邮件
//				//根据工号发邮件            发邮件(方法2)
//				Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
//				//Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHead.ApplySheetHeadPk );
//				Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(NextCheckRole,CheckStep,IsFinish,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
//				mailBll.ThreadSendMail();
			}
			
			



			return Flag ;
		}



		
		/// <summary>
		/// 价格裁决审批
		/// </summary>
		/// <param name="agreeType">类型 1同意 2弃审 0拒绝</param>
		/// <param name="myCode">审批人工号</param>
		/// <param name="AssetCheckApplyKey">裁决单Id</param>
		/// <param name="disPlaysCode">替代人工号</param>
		/// <param name="posital">审批意见</param>
		/// <param name="sign"></param>
		public static void Flow_CheckAssetPriceApply(int AgreeType,string MyCode,int AssetCheckApplyKey,string DisPlaysCode,string Posital,int Sign)
		{
			try
			{
				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(AssetCheckApplyKey);
				if(FinallyCheck !=null)
				{
					//添加审批记录
					AddCheckPriceRecord(AgreeType,MyCode,AssetCheckApplyKey,FinallyCheck,DisPlaysCode,Posital,Sign);

					if(AgreeType == 1 || AgreeType == 2 )
					{
						#region 同意或弃审

						//输出参数
						//int CheckSetp = 0;   IsFinish 结束部门内审批
						int NextCheckStep = 0 ; int IsFinish = 1 ; int IsGiveUp = 0 ;  string NextCheckCode = "" ; 

						//找下一审批角色
						string NextCheckRole = PriceCheckFlow(FinallyCheck.CheckFlowInCompanyHeadPk,FinallyCheck.CheckSetp,out NextCheckStep,out IsFinish, out IsGiveUp, out NextCheckCode);

						if(IsFinish == 1  )
						{
							//根新为公司内审批
							FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;	
						}
						if(IsFinish == 2 )
						{
							//更新进程状态为审批结束了
							FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		
						}

						//更新当前审批角色
						FinallyCheck.CurrentCheckRole = NextCheckRole ;
						//更新当前审批步骤
						FinallyCheck.CheckSetp        = NextCheckStep ;

						FinallyCheck.Save ();

						if(IsGiveUp == 1 )
						{
							//此用户放弃审批,循环调用方法本身;
							//放弃审批。
							Flow_CheckAssetPriceApply(2,NextCheckCode,FinallyCheck.Id,"","",1);
						}
						else
						{
							////根据工号发邮件            发邮件(方法2)
							//Entiy.ApplyType  applyType = Entiy.ApplyType.Find(ApplyHead.ApplyTypeCode);
							////Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(ApplyHead.ApplySheetHeadPk );
							//Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(NextCheckRole,CheckStep,IsFinish,ApplyHead.ApplyDeptCode,applyType.ApplyTypeName,AssetBudget.SheetRmbMoney.ToString(),ApplyHead.ApplySheetNo);
							//mailBll.ThreadSendMail();
						}
						#endregion 
					}
					else  //(AgreeType == 0 )
					{
						#region  拒绝
						//3.更新进程状态为   驳回  ,审批角色置为空 ,步骤也为空 
													
						FinallyCheck.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisPross ;
						
						FinallyCheck.Update();
						
//						//发送邮件给提交单据人员

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
			//applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//单据主键
			ApplyRecord.AssetCheckPriceHeadPk = AssetPriceCheckKey ;        //单据主键
			ApplyRecord.IsCheckInCompany=FinallyCheck.IsCheckInCompany;		//审批类别  部门内/公司内 
			if(Sign == 2 )
			{
				ApplyRecord.CheckRole="" ;				//审批角色
			}
			else
			{
				ApplyRecord.CheckRole=FinallyCheck.CurrentCheckRole ;				//审批角色
				ApplyRecord.CheckSetp=FinallyCheck.CheckSetp;						//审批级
			}
			ApplyRecord.CheckPersonCode=MyCode;								//审批人Code
			ApplyRecord.CheckComment=Posital;								//审批意见
			ApplyRecord.Checkdate=DateTime.Now;								//审批时间
			if(!"".Equals(DisPlaysCode))                     
			{
				ApplyRecord.DisplaysPersonCode = DisPlaysCode;				//被替代人Code
				ApplyRecord.IsDisplays=1;									//是否替代审批
			}
			ApplyRecord.IsPass=AgreeType;									//是否同意

			ApplyRecord.Create();
		}


		/// <summary>
		/// 价格裁决审批步骤
		/// </summary>
		/// <param name="FlowId">流程Id</param>
		/// <param name="CheckSetp">当前审批级</param>
		/// <param name="NextCheckStep">下一审批级，返回参数</param>
		/// <param name="IsFinish">是否结束，返回参数</param>
		/// <param name="IsGiveUp">是否放弃，返回参数</param>
		/// <returns>下一审批角色</returns>
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
					//公司审批已经完成
					IsFinish=2;
					//下一审批角色清空
					return "";
				}
			}
			//公司审批部分已经开始
			Entiy.CheckFlowInCompanyBody NextFlowSetp=Entiy.CheckFlowInCompanyBody.FindNextStep(FlowId,CheckSetp);
			if(NextFlowSetp!=null)
			{
				//公司内审批未完成
				//IsFinish=1;
				//下一审批级数
				NextCheckStep=NextFlowSetp.CheckStep;

				string MyCode = "";
				string CheckRole = NextFlowSetp.CheckRoleCode ;
				//根据角色找审批人员;判断此人是否放弃审批
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
				//返回下一审批角色信息
				return NextFlowSetp.CheckRoleCode;
			}
			return "";

		}

		/// <summary>
		/// 查询属于我的审批
		/// </summary>
		/// <param name="myCode">工号</param>
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

		//冲减已价格裁决数量
		public static void RemoveFinallyCheckNumber(int FinallyCheckId)
		{
			
			//价格裁决表体
			Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheckId);
			if(FinallyCheckBodys !=null && FinallyCheckBodys.Length > 0 )
			{
				foreach(Entiy.AssetFinallyPriceCheckBody Finallybody in FinallyCheckBodys)
				{
					//固定资产申请单表体
					Entiy.AssetApplySheetBody AssetApplyBody = Entiy.AssetApplySheetBody.Find(Finallybody.AssetApplySheetBodyId );
					if(AssetApplyBody!= null)
					{
						if(AssetApplyBody.CheckNumber > 0 )
						{
							AssetApplyBody.CheckNumber = AssetApplyBody.CheckNumber - Finallybody.Number ;

							//设置IsChecked
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

		//累计已价格裁决数量
		public static void AddFinallyCheckNumber(int FinallyCheckId)
		{
			//价格裁决表体
			Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheckId);
			if(FinallyCheckBodys !=null && FinallyCheckBodys.Length > 0 )
			{
				foreach(Entiy.AssetFinallyPriceCheckBody Finallybody in FinallyCheckBodys)
				{
					int NowCheckedNumber = 0 ; 
					//固定资产申请单表体
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

						//更新新营单表体是否已价格裁决信息
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
