using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CheckFlowInDeptBLL 的摘要说明。
	/// </summary>
	public class CheckFlowInDeptBLL
	{
		public CheckFlowInDeptBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		/// <summary>
		/// 检测部门内流程完整性信息
		/// </summary>
		/// <param name="dtMessage"></param>
		public static void CheckAllFlowInDept(out DataTable dtMessage)
		{
			dtMessage=new DataTable();
			dtMessage.Columns.Add("科组代码");
			dtMessage.Columns.Add("错误信息");

			//1.获取所有科组编码信息
			DataTable dt=DataAccess.CheckFlow.CheckFlowInDeptDAL.GetDeptCodeInfo();
			if(dt!=null && dt.Rows.Count>0)
			{
				for(int i=0 ;i<dt.Rows.Count ;i++)
				{
					//2.通过科组编码查询其完整性信息
					int result=DataAccess.CheckFlow.CheckFlowInDeptDAL.CheckFlowDeptCodeValid(dt.Rows[i][0].ToString());
					if(result!=0)
					{
						string message="";
						if(result==1)
						{
							message="流程不具有结束标识";
						}
						else if(result==2)
						{
							message="有重复的审批级";
						}
						else if(result==3)
						{
							message="流程具有多个结束标识";
						}

						DataRow dr=dtMessage.NewRow();
						dr["科组代码"]=dt.Rows[i][1].ToString() ;
						dr["错误信息"]=message;
						dtMessage.Rows.Add(dr);
					}
				}
			}
		}


		/// <summary>
		/// 根据用户申请单号,查询下一(当前)审批角色
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static string GetCheckRole(int ApplyHeadPk,out string Message)
		{
			Message="";
			//1.查询 所在的 科组 号,,查看 当前审批类别(公司内 || 部门内),,查看 当前审批角色.
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(applyHead==null)
			{
				Common.Log.Logger.Log("Bussiness.CheckAllFlowInDept","查询当前审批角色错误,找不到申请单表头!");
				Message="查询当前审批角色错误,找不到申请单表头!";
				return "" ;
			}
			else
			{
				if(applyHead.IsCheckInCompany == 0)         //目前审批在部门内
				{
					if(applyHead.CurrentCheckRole == null || "".Equals(applyHead.CurrentCheckRole)) //还未有审批角色
					{
						Entiy.CheckFlowInDept nextStep=Entiy.CheckFlowInDept.FindNextStep(applyHead.ApplyDeptCode,0);
						if(nextStep!=null)  
						{
							return nextStep.CheckRoleCode;
						}
						else
						{
							//没有找到相应部门内流程
							Message="没有找到相应部门内流程";
							return "";
						}
					}
					else
					{
						// 查看 审批记录表  1.标头 2. 部门内/外 3.审批角色. 查看已审批角色的Step 
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
								//没有找到相应部门内流程
								Message="没有找到相应部门内流程";
								return "";
							}
						}
						else
						{
							return applyHead.CurrentCheckRole; //返回原有角色
						}
					}
				}
				else if(applyHead.IsCheckInCompany == 1)  // 目前审批出了部门,在公司内
				{
					// 查看 审批记录表  1.标头 2. 部门内/外 3.审批角色. 查看已审批角色的Step 
					Entiy.ApplySheetCheckRecord applySheetCheckRecord=Entiy.ApplySheetCheckRecord.FindLastStep(ApplyHeadPk,applyHead.IsCheckInCompany);
					if(applySheetCheckRecord == null)
					{
						//公司审批部门还未开始
						Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,0);
						if(checkFlowInCompanyBody!=null)
						{
							return checkFlowInCompanyBody.CheckRoleCode;
						}
						else
						{
							Message="没有找到相应公司流程";
							return "";
						}
					}
					else
					{
						//公司审批部分已经开始
						Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,applySheetCheckRecord.CheckSetp);
						if(checkFlowInCompanyBody!=null)
						{
							return checkFlowInCompanyBody.CheckRoleCode;
						}
						else
						{
							Message="流程已经结束！";
							return "";
						}						
					}
				}
				return "";
			}
		}



		/// <summary>
		/// 根据用户申请单号,查询下一(当前)审批角色
		/// </summary>
		/// <param name="ApplyHeadPk">标头主键</param>
		/// <param name="CheckStep" >返审批级别</param>
		/// <param name="DeptToCompany">返是否公司内</param>
		/// <param name="Message" >返提示信息</param>
		/// <returns>返回角色名称</returns>
		public static string GetCheckRole2(int ApplyHeadPk,out int CheckStep,out int DeptToCompany,out string Message,out int IsGiveUp,out string NextCheckCode)
		{
			Message="";

			CheckStep=0;     


			DeptToCompany=0;          // 0 部门内 ,1 从部门内转到公司内 ! ,2 公司部门已经结束

			IsGiveUp = 0 ;    //用户是否放弃审批权限;
            NextCheckCode = "" ; 

			//1.查询所在的科组号,,查看 当前审批类别(公司内 || 部门内),,查看 当前审批角色.
			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplyHeadPk);
			if(applyHead==null)
			{
				Common.Log.Logger.Log("Bussiness.CheckAllFlowInDept","查询当前审批角色错误,找不到申请单表头!");
				return "" ;
			}
			else
			{
				if(applyHead.IsCheckInCompany == 0)         
				{
					#region 目前审批在部门内
					if(applyHead.CurrentCheckRole == null || "".Equals(applyHead.CurrentCheckRole)) //还未有审批角色
					{

						/////////////////////2014.03.24修改 //参数 ，部门内 ，实物、劳保 从 0 开始（0上设置采购员审批人员） 。其他从 1 开始   
						int flag = 0 ;
						Entiy.ApplyType applyTypes=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);   
						if(applyTypes !=null )
						{
							if("ApplySheetBody_Purchase".Equals(applyTypes.ApplySheetBodyTableName))
							{
								flag = -1 ;    //实物购买类从 0 开始查找审批人员，流程设置配合，设置 0 采购员  底层为 > -1 为 0 
							}

							 
							if ("102".Equals(applyTypes.ApplyTypeCode) && "001000".Equals(applyHead.ApplyDeptClassCode) )   //   102	劳保购买 \ 001000 总务 部门代码 
							{
								//2015-10-11 修改 ，若单据为  劳保、总务部 。 则从 -2 开始 。为了其他科室可用 总务副科长 审批 。 暂时。 缺点 ：顺序 ，先总务副科长  再 采购员
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
							//没有找到相应部门内流程
							Message="没有找到相应部门内流程";
							return "";
						}
					}
					else
					{
						//判断是否部门内结束还是部门内流程错误.
						Entiy.CheckFlowInDept flowInDept=Entiy.CheckFlowInDept.FindStep(applyHead.ApplyDeptCode,applyHead.CheckSetp);
						if(flowInDept != null)
						{
							if(flowInDept.IsLastStep == 0)     //未到部门内结束
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
									//没有找到相应部门内流程
									Message="没有找到相应部门内流程";
									return "";
								}
							}
							else   //部门内已经结束
							{
								Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,0);
								if(checkFlowInCompanyBody!=null)
								{
									DeptToCompany=1;                                //部门内结束,公司内开始
									CheckStep=checkFlowInCompanyBody.CheckStep;


									string myCode = "";
									string checkRole = checkFlowInCompanyBody.CheckRoleCode ;
									//根据角色找审批人员;判断此人是否放弃审批
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
									Message="没有找到相应公司流程";
									return "";
								}
							}
						}
					}
					#endregion 
				}
				else if(applyHead.IsCheckInCompany == 1)  
				{
					#region 目前审批出了部门,在公司内
					Entiy.CheckFlowInCompanyBody FlowSetp=Entiy.CheckFlowInCompanyBody.FindStep(applyHead.CheckFlowInCompanyHeadPk,applyHead.CheckSetp);
					if(FlowSetp!=null)
					{
						if(FlowSetp.IsLastStep == 1)
						{
							//公司审批已经完成
							DeptToCompany=2;
							Message="流程已经结束！";
							return "";
						}
						else
						{							
							//公司审批部分已经开始
							Entiy.CheckFlowInCompanyBody checkFlowInCompanyBody=Entiy.CheckFlowInCompanyBody.FindNextStep(applyHead.CheckFlowInCompanyHeadPk,applyHead.CheckSetp);
							if(checkFlowInCompanyBody!=null)
							{
								DeptToCompany=1;
								CheckStep=checkFlowInCompanyBody.CheckStep;

								string myCode = "";
								string checkRole = checkFlowInCompanyBody.CheckRoleCode ;
								//根据角色找审批人员;判断此人是否放弃审批
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
		/// 获取用户所在部门ID
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		public static DataTable  GetDeptForUserID(int UserID)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForUserID(UserID);
		}

		/// <summary>
		/// 根据部门查询科组
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClass(string DeptClassCode)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClass(DeptClassCode);
		}

		/// <summary>
		/// 根据部门查询科组
		/// </summary>
		/// <param name="DeptClassCode"></param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassForAdd(string DeptClassCode)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClassForAdd(DeptClassCode);
		} 


		//*******************************************************小额固定资产所用到的人事部门(2013-12-10 liyang)****************************************************
		/// <summary>
		/// 获取所有部门信息
		/// </summary>
		/// <returns></returns>
		public static DataTable GetAllDeptBySmallFixed()
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetAllDeptBySmallFixed();
		} 

		/// <summary>
		/// 根据部门查询科组信息(递归部门下的所有科和组信息)
		/// </summary>
		/// <param name="fbmbh">父节点编码</param>
		/// <returns></returns>
		public static DataTable GetDeptForDeptClassBySmallFixed(string fbmbh)
		{
			return DataAccess.UserInfo.BaseDeptDAL.GetDeptForDeptClassBySmallFixed(fbmbh);
		}

		//************************************************************************************************************************************************************



		/// <summary>
		/// 查询部门内角色,人员
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static DataTable GetFlowInDeptByQuery(string query)
		{
			return DataAccess.CheckFlow.CheckFlowInDeptDAL. GetFlowInDeptByQuery( query);
		}


	}
}
