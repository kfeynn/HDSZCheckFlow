using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
 


using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;



using System.Web.UI.HtmlControls;



namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// ApplyAuditingBLL 的摘要说明。
	/// </summary>
	public class ApplyAuditingBLL:System.Web.UI.Page 
	{
		public ApplyAuditingBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			// 
		}
		/// <summary>
		/// 获取实物类表体信息
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyInfo(int applyHeadPK)
		{
			DataSet ds = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyInfo(applyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}

		/// <summary>
		/// 查询实物购买审批单据的详细信息2 (包含已经有的数量)
		/// </summary>
		/// <param name="applyHeadPk"></param>
		/// <returns></returns>
		public static DataSet GetApplyPurchaseBodyInfo(int applyHeadPk)
		{
			//DataSet ds = new DataSet();//DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPurchaseBodyInfo(applyHeadPk); 
			DataSet ds =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPurchaseBodyInfo(applyHeadPk); 
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;

		}

		/// <summary>
		/// 获取报销类表体信息
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyPayInfo(int applyHeadPK)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyPayInfo(applyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}


		/// <summary>
		/// 获取新营类表体信息
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetInfo(int ApplyHeadPK)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyAssetInfo(ApplyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}

		/// <summary>
		/// 获取新营类表体信息
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetAndCheckInfo(int ApplyHeadPK,string Ids,string FId)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyAssetAndCheckInfo(ApplyHeadPK,Ids,FId);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}


		/// <summary>
		/// 查询新营类表体_价格裁决表体(根据表头主键)
		/// </summary>
		/// <param name="FinallyCheckId"></param>
		/// <returns></returns>
		public static DataSet GetFinallyBodyInfoByCheckId(int FinallyCheckId )
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetFinallyBodyInfoByCheckId(FinallyCheckId);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //序号
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// 如果币种是RMB则，汇率强行指定为 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;

		}

		/// <summary>
		/// 查询审批记录
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyRecord(int applyHeadPK)
		{
			DataSet ds= null;
			ds = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyRecord(applyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count > 0)
			{
				for(int i=0;i<ds.Tables[0].Rows.Count;i++)
				{
					if(!"".Equals(ds.Tables[0].Rows[i]["displaysName"].ToString()))
					{
						ds.Tables[0].Rows[i]["Name"]+= "(" + "代" + ds.Tables[0].Rows[i]["displaysName"].ToString()+"审批" +")";
					}
				}
			}

			return ds;
		}

		/// <summary>
		/// 查询审批记录价格裁决单 
		/// </summary>
		/// <param name="FinallyCheckId"></param>
		/// <returns></returns>
		public static DataSet GetApplyRecordForFinallyCheck(int FinallyCheckId)
		{
			DataSet ds= null;
			ds = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyRecordForFinallyCheck(FinallyCheckId);
			if(ds!=null && ds.Tables[0].Rows.Count > 0)
			{
				for(int i=0;i<ds.Tables[0].Rows.Count;i++)
				{
					if(!"".Equals(ds.Tables[0].Rows[i]["displaysName"].ToString()))
					{
						ds.Tables[0].Rows[i]["Name"]+= "(" + "代" + ds.Tables[0].Rows[i]["displaysName"].ToString()+"审批" +")";
					}
				}
			}

			return ds;
		}


		/// <summary>
		/// 添加审批记录
		/// </summary>
		public static void AddCheckRecord(int agreeType,string myCode,int ApplySheetHeadPk, Entiy.ApplySheetHead applyHead ,string disPlaysCode,string posital,int sign)
		{

			Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
			applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//单据主键
			applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//审批类别  部门内/公司内 
			if(sign == 2 )
			{
				applyRecord.CheckRole="" ;				//审批角色
			}
			else
			{
				applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//审批角色
				applyRecord.CheckSetp=applyHead.CheckSetp;						//审批级
			}
			applyRecord.CheckPersonCode=myCode;								//审批人Code
			applyRecord.CheckComment=posital;								//审批意见
			applyRecord.Checkdate=DateTime.Now;								//审批时间
			if(!"".Equals(disPlaysCode))                     
			{
				applyRecord.DisplaysPersonCode = disPlaysCode;				//被替代人Code
				applyRecord.IsDisplays=1;									//是否替代审批
			}
			applyRecord.IsPass=agreeType;									//是否同意

			applyRecord.Create();

		}


		/// <summary>
		/// 审批
		/// </summary>
		/// <param name="agreeType"></param>
		public   void Flow_AgreeApplySheet(int agreeType,string myCode,int ApplySheetHeadPk,string disPlaysCode,string posital,int sign)
		{
			try
			{
				//agreeType : 1同意 , 0 拒绝

				//1. 将审批日志记录到 记录表
				//string myCode=Bussiness.UserInfoBLL.GetUserName(UserID);

				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplySheetHeadPk);
				if(applyHead!=null)
				{

					#region 
					//					Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
					//					applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//单据主键
					//					applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//审批类别  部门内/公司内 
					//					if(sign == 2 )
					//					{
					//						applyRecord.CheckRole="" ;				//审批角色
					//					}
					//					else
					//					{
					//						applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//审批角色
					//						applyRecord.CheckSetp=applyHead.CheckSetp;						//审批级
					//					}
					//					applyRecord.CheckPersonCode=myCode;								//审批人Code
					//					applyRecord.CheckComment=posital;								//审批意见
					//					applyRecord.Checkdate=DateTime.Now;								//审批时间
					//					if(!"".Equals(disPlaysCode))                     
					//					{
					//						applyRecord.DisplaysPersonCode = disPlaysCode;				//被替代人Code
					//						applyRecord.IsDisplays=1;									//是否替代审批
					//					}
					//					applyRecord.IsPass=agreeType;									//是否同意
					//
					//					applyRecord.Create();
					#endregion 
					
					//添加审批记录
					AddCheckRecord(agreeType,myCode,ApplySheetHeadPk,applyHead,disPlaysCode,posital,sign);

					if(agreeType==1 || agreeType == 2 )
					{
						#region   同意或者越过


						//2.更新此单据的下一审批角色 
						string Message="",	NextCheckCode ="";
						
						int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
						
						//判断下一用户是否选择放弃权限,放弃,记录放弃审批记录,再找下一审批人员.
	

						if(DeptToCompany == 1 )                  //进程状态
						{
							applyHead.IsCheckInCompany=1;											//更新是否出部门. IsInCompany 
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;		//更新进程状态为公司内
						}
						else if(DeptToCompany == 0 )
						{
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DeptPross;		//更新进程状态为部门内开始审批了
						}
						else if(DeptToCompany ==2  )
						{
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		//更新进程状态为审批结束了
						}

						applyHead.CurrentCheckRole=checkRole ;   //审批角色
						applyHead.CheckSetp=CheckStep;           //步骤


						applyHead.Update();

						if(IsGiveUp ==1 )
						{
							//此用户放弃审批,循环调用方法本身;

							Bussiness.ApplyAuditingBLL Audi = new ApplyAuditingBLL();


							Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplySheetHeadPk,"","",1 );
						}
						else
						{
							//取消发送邮件
//							//发邮件
//							if(DeptToCompany == 0 || DeptToCompany == 1)          
//							{
//								//根据,角色,工号, 是否公司内 三个信息,找到工号(方法1) 
//
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
//								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//								mailBll.ThreadSendMail();
//							}
							if( DeptToCompany == 2 )
							{
								//审批结束。固定资产的单据。发邮件给资财人员 提醒做订单。
//								Bussiness.MailBLL1 mail = new Bussiness.MailBLL1(ApplySheetHeadPk);
//								mail.ThreadSendMail();
							}
						}
						#endregion  
					}
					else
					{
						#region  拒绝
						//3.更新进程状态为   驳回  ,审批角色置为空 ,步骤也为空 
							
						applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisPross ;		

						applyHead.Update();

//						//发送邮件给提交单据人员
//
//						Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(applyHead.ApplyMakerCode,myCode,posital,applyHead.ApplySheetNo);
//
//						mailBll.ThreadSendMailForUnAgree();

						#endregion 
					}
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AuditingForOneApply",ex.Message);
			}
		}


		/// <summary>
		/// 查找人员工号
		/// </summary>
		/// <param name="Role">角色</param>
		/// <param name="Step">审批级</param>
		/// <param name="InCompany">是否公司内</param>
		/// <param name="deptCode">部门Code</param>
		/// <returns></returns>
		public static string GetPersonCodeByRoleAndSetp(string Role,int Step, int InCompany,string deptCode)
		{
			try
			{
				string  returnValue="";
				//还要查看是否将权限转交给他人, 转交的话则只返回别人的工号
				if(InCompany==0)                   //部门内 ,主要查看 部门Code和审批级
				{
					if(!"".Equals(deptCode) && !"".Equals(Role))
					{
						Entiy.CheckFlowInDept FlowInDept=Entiy.CheckFlowInDept.FindStep(deptCode,Step);
						if(FlowInDept!=null && FlowInDept.CheckPersonCode!=null)
						{
							returnValue=Bussiness.UserInfoBLL.DisPersonCode(FlowInDept.CheckPersonCode);
						}
					}
				}
				else if(InCompany==1)              //公司内,主要靠角色
				{
					if(!"".Equals(Role))
					{
						Entiy.CheckPersonInRole[] personInRoles=Entiy.CheckPersonInRole.FindByRole(Role);
						if(personInRoles!=null && personInRoles.Length>0)
						{
							foreach (Entiy.CheckPersonInRole perInRole in personInRoles)
							{
								returnValue += Bussiness.UserInfoBLL.DisPersonCode(perInRole.PersonCode) + ",";
							}
						}
					}
				}
				return returnValue;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("Bussiness.ApplyAuditingBLL",ex.Message );
				return "";
			}
		}




		/// <summary>
		/// 发邮件提醒
		/// </summary>
		/// <param name="UserCode"></param>
		public static void SendEmailByUserCode(string UserCode,string applyType,string applyMoney,string applySheetNo)
		{
			// 目前只有一中邮件样式.

			try
			{
				string _email="";
				string nickName="";

				string []Users=UserCode.Split(',');
				foreach(string user in Users)
				{
					Entiy.BaseEmail emile=Entiy.BaseEmail.Find(user);
					if(emile!=null && emile.Email!=null)
					{
						// 1. 找此人的称呼

						nickName=emile.NickName ;
						_email  =emile.Email ;

						if(emile.NickName== null || "".Equals(emile.NickName ))
						{
							Entiy.BasePerson person=Entiy.BasePerson.Find(user);
							if(person!=null)
							{
								nickName=person.Name;
							}
						}
						
						string title="预算审批提醒" + applySheetNo;

//						string content="尊敬的$User:您有一份单据号为:$applyNo 类型为:$Type  金额为:$Money 的审批单据,请您上线审批.谢谢!";
//
//						content=content.Replace("$User",nickName);
//						content=content.Replace("$Type",applyType);
//						content=content.Replace("$Money",applyMoney);
//						content=content.Replace("$applyNo",applySheetNo);

						//测试html模版邮件
						string content = "";
						//读文件。
						string path = "E:\\Finance\\HDSZCheckFlow\\HDSZCheckFlow.UI\\EmailText.txt" ; 
						content = EmailStr(path);

						if(!"".Equals(_email))
						{
							Bussiness.MailBLL mailBll=new MailBLL();
							mailBll.SendMail(_email,title,content);
						}
					}
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.ApplyAuditingBLL.SendEmailByUserCode",ex.Message);
			}
		}

		//读取文件
		public static string  EmailStr(string Path)
		{
			string strLine = "";
			
			StreamReader sr = new StreamReader(Path, Encoding.GetEncoding("GB2312"));

			strLine= sr.ReadToEnd();
				
			sr.Close();
			
			return strLine ; 

		}

		/// <summary>
		/// 驳回时发送邮件
		/// </summary>
		/// <param name="ToCode"></param>
		/// <param name="FromCode"></param>
		/// <param name="postail">审批时,意见</param>
		public static void SendEmailForUnAgree(string ToCode,string FromCode,string postail,string applyNo)
		{
			try
			{
				string _email="";
				string nickName="";
				string nickFromName="";

				Entiy.BaseEmail emile=Entiy.BaseEmail.Find(ToCode);
				Entiy.BaseEmail emileFrom=Entiy.BaseEmail.Find(FromCode);
				if(emile!=null && emile.Email!=null)
				{
					// 1. 找此人的称呼

					nickName=emile.NickName ;
					_email  =emile.Email ;

					if(emile.NickName== null || "".Equals(emile.NickName ))
					{
						Entiy.BasePerson person=Entiy.BasePerson.Find(ToCode);
						if(person!=null)
						{
							nickName=person.Name;
						}
					}

					if(emileFrom!=null && emileFrom.NickName!=null)
					{
						nickFromName= emileFrom.NickName;
					}
					else
					{
						Entiy.BasePerson personFrom=Entiy.BasePerson.Find(FromCode);
						if(personFrom!=null)
						{
							nickFromName=personFrom.Name;
						}
					}
						
					string title="您的审批被驳回";

					string content="尊敬的{0}:您的单据号为 {1} 的申请被 {2} 驳回! 驳回理由是 : {3}";

					content = string.Format(content,nickName,applyNo,nickFromName,postail );

					if(!"".Equals(_email))
					{
						Bussiness.MailBLL mailBll=new MailBLL();
						mailBll.SendMail(_email,title,content);
					}
				}
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("CheckFlow.AuditingForOneApply",ex.Message);
			}
		}


		/// <summary>
		/// 获取我的已经审批的单据记录
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="ispass"></param>
		/// <returns></returns>
		public static DataSet GetMyAuditedApply(string query)
		{
			DataSet ds=  DataAccess.ApplySheet.ApplyAuditingDAL.GetMyAuditedApply(query); 
			//去除相同单据,只显示一条
			for(int i=ds.Tables[0].Rows.Count-1 ;i>0;i--)
			{
				if(ds.Tables[0].Rows[i]["ApplySheetHead_Pk"].ToString() == ds.Tables[0].Rows[i-1]["ApplySheetHead_Pk"].ToString())
				{
					ds.Tables[0].Rows.RemoveAt(i-1);
				}
			}
			return ds;
		}

		/// <summary>
		/// 查询将要打印的单据信息
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyPhuse(int applyHeadPK)
		{
			try
			{
				string view="",view2="";
				string query="",query2="";
				// 1. 取得要查询的视图 
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPK);
			
				Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);

				if("ReportForPurchase.rpt".Equals(applyType.Report))
				{
					view = "v_BaseApplyPurchase";  // 要查询两个表 v_BaseApplyPurchase , v_ApplyCheckRecord 表单基本信息,审批信息
					query = " where ApplySheetHead_pk= " + applyHeadPK + "  ";
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //完成的取已审批信息
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='拒绝'  ";

					}
					else
					{
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //实物类
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //非实物类
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}
					}			
					//组合一个符合报表的DataSet ,(1.装载两个表的DataSet BaseApplyPurchase,ApplyCheckRecord)
					DataSet ds1 = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view,query);
					ds1.Tables[0].TableName ="ds1";
					DataSet ds2 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view2,query2);
					ds2.Tables[0].TableName = "ds2";

					DataSet ds3 = GetBudgetInfoByApplyHeadPk(applyHeadPK) ;

					DataSet ds=new DataSet();
					ds.Tables.Add(ds1.Tables["ds1"].Copy());
					ds.Tables.Add(ds2.Tables["ds2"].Copy());
					ds.Tables.Add(ds3.Tables[0].Copy());//ApplyBugdetInfo

					ds.Tables[0].TableName = "BaseApplyPurchase";     
					ds.Tables[1].TableName = "ApplyCheckRecord";
					ds.Tables[2].TableName = "ApplyBudgetInfo";
				
					return ds;
				}
				else if("ReportForPay.rpt".Equals(applyType.Report))
				{
					view = "v_BaseApplyPay";  // 要查询两个表 v_BaseApplyPay , v_ApplyCheckRecord 表单基本信息,审批信息
					query = " where ApplySheetHead_pk= " + applyHeadPK    ;
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //完成的取已审批信息
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='拒绝'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";

						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}



					}			
					//组合一个符合报表的DataSet ,(1.装载两个表的DataSet BaseApplyPurchase,ApplyCheckRecord)
					DataSet ds1 = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view,query);
					ds1.Tables[0].TableName ="ds1";
					DataSet ds2 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view2,query2);
					ds2.Tables[0].TableName = "ds2";

					DataSet ds3 = GetBudgetInfoByApplyHeadPk(applyHeadPK) ;

					DataSet ds=new DataSet();
					ds.Tables.Add(ds1.Tables["ds1"].Copy());
					ds.Tables.Add(ds2.Tables["ds2"].Copy());
					ds.Tables.Add(ds3.Tables[0].Copy());

					ds.Tables[0].TableName = "BaseApplyPay";     
					ds.Tables[1].TableName = "ApplyCheckRecord";
					ds.Tables[2].TableName = "ApplyBudgetInfo";//ApplyBugdetInfo
				
					return ds;
				}
				else if("ReportForEvection.rpt".Equals(applyType.Report))
				{
					view = "v_BaseApplyEvection";  // 要查询两个表 v_BaseApplyPay , v_ApplyCheckRecord 表单基本信息,审批信息
					query = " where ApplySheetHead_pk= " + applyHeadPK + "  ";
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //完成的取已审批信息
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='拒绝'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}

					}		
					//组合一个符合报表的DataSet ,(1.装载两个表的DataSet BaseApplyPurchase,ApplyCheckRecord)
					DataSet ds1 = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view,query);
					ds1.Tables[0].TableName ="ds1";
					DataSet ds2 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view2,query2);
					ds2.Tables[0].TableName = "ds2";

					DataSet ds3 = GetBudgetInfoByApplyHeadPk(applyHeadPK) ;

					DataSet ds4 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplychange(applyHeadPK);
					ds4.Tables[0].TableName = "ds4";

					DataSet ds=new DataSet();
					ds.Tables.Add(ds1.Tables["ds1"].Copy());
					ds.Tables.Add(ds2.Tables["ds2"].Copy());
					ds.Tables.Add(ds3.Tables[0].Copy());
					ds.Tables.Add(ds4.Tables["ds4"].Copy());

					ds.Tables[0].TableName = "BaseApplyEvection";     
					ds.Tables[1].TableName = "ApplyCheckRecord";
					ds.Tables[2].TableName = "ApplyBudgetInfo";//ApplyBugdetInfo
					ds.Tables[3].TableName = "EvectionCharge";
				
					return ds;
				}
				else if("ReportForBanquet.rpt".Equals(applyType.Report))
				{
					view = "v_BaseApplyBanquet";  // 要查询两个表 v_BaseApplyPay , v_ApplyCheckRecord 表单基本信息,审批信息
					query = " where ApplySheetHead_pk= " + applyHeadPK     ;
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //完成的取已审批信息
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='拒绝'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //未完成的取理论流程信息
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='拒绝'  ";
						}

					}
					//组合一个符合报表的DataSet ,(1.装载两个表的DataSet BaseApplyPurchase,ApplyCheckRecord)
					DataSet ds1 = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view,query);
					ds1.Tables[0].TableName ="ds1";
					DataSet ds2 =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPhuse(view2,query2);
					ds2.Tables[0].TableName = "ds2";

					DataSet ds3 = GetBudgetInfoByApplyHeadPk(applyHeadPK) ;



					DataSet ds=new DataSet();
					ds.Tables.Add(ds1.Tables["ds1"].Copy());
					ds.Tables.Add(ds2.Tables["ds2"].Copy());
					ds.Tables.Add(ds3.Tables[0].Copy());

					ds.Tables[0].TableName = "BaseApplyBanquet";     
					ds.Tables[1].TableName = "ApplyCheckRecord";
					ds.Tables[2].TableName = "ApplyBudgetInfo";//ApplyBugdetInfo
				
					return ds;
				}
				else
				{
					//没有其他类型
					return null;
				}
			}
			catch(Exception ex)
			{
				ex.ToString();
				return null;
			}
		}

		public static DataSet GetBudgetInfoByApplyHeadPk(int applyHeadPk)
		{
			//预算情况
			DataTable dt=new DataTable("ApplyBudgetInfo");//ApplyBugdetInfo
			dt.Columns.Add(new DataColumn("BudgetType", typeof(System.String)));
			dt.Columns.Add(new DataColumn("BudgetMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("PlanMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ChangeMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("UsedMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ThisMoey", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("LeaveMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ApplySheetHead_Pk", typeof(System.Int32)));
			dt.Columns.Add(new DataColumn("ReadyPayMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("AllowOutMoney", typeof(System.Decimal)));

			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

			if(applyHead!=null && applyBudget!=null)
			{
				Entiy.BaseDept dept = Entiy.BaseDept.FindByDeptCode(applyHead.ApplyDeptCode);
				DataSet ds = Bussiness.BudgetAccountBLL.getQuarterBudgetInfo(applyHead.ApplyDate.Year ,applyHead.ApplyDate.Month ,dept.BudgetDeptCode,applyBudget.SheetSubject );
				if(ds != null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetAccountQuarterChange(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);

					//	decimal tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString()) + applyBudget.AllowOutMoney  + ChangeMoney  - decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()) -decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());  //剩余金额
					decimal UsedMoney = 0 ; 
					decimal TotalAllowOutMoney = 0 ; 

					DataRow  row=dt.NewRow();
					//新建状态下的已使用金额
					if(applyHead.ApplyProcessCode == "101")
					{
						row["UsedMoney"] = ds.Tables[0].Rows[0]["checkmoney"].ToString(); 
						UsedMoney = decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString());
						TotalAllowOutMoney = decimal.Parse(ds.Tables[0].Rows[0]["TotalAllowOutMoney"].ToString());
					}
					else
					{
						row["UsedMoney"] = applyBudget.SumCheckMoney.ToString();
						UsedMoney = decimal.Parse(applyBudget.SumCheckMoney.ToString());
						TotalAllowOutMoney = applyBudget.AllowOutMoney ; 
					}
					decimal tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString())  + ChangeMoney + TotalAllowOutMoney -applyBudget.SheetMoney - UsedMoney - decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString()) ;

					row["BudgetMoney"] = ds.Tables[0].Rows[0]["budgetmoney"].ToString();
					row["PlanMoney"] = ds.Tables[0].Rows[0]["planmoney"].ToString();
					row["ChangeMoney"] = ChangeMoney;
					row["ThisMoey"] = applyBudget.SheetMoney;
					row["LeaveMoney"] = tempLeft;
					row["ApplySheetHead_Pk"] = applyHeadPk;
					row["ReadyPayMoney"] = ds.Tables[0].Rows[0]["readypay"].ToString();
					row["AllowOutMoney"] = TotalAllowOutMoney;



					if(applyBudget.SubmitType == 1 )
					{
						row["BudgetType"] = "预算内" ;
					}
					else if (applyBudget.SubmitType == 2 )
					{
						row["BudgetType"] = "预算外" ;
					}
					dt.Rows.Add(row);
				}
			}
			DataSet dss=new DataSet();
			dss.Tables.Add(dt);
			return dss;
		}

		public static  DataSet  GetBudgetInfoByApplyHeadPk2(int applyHeadPk)
		{
			//预算情况

			
			DataTable dt=new DataTable("ApplyBudgetInfo");//ApplyBugdetInfo
			dt.Columns.Add(new DataColumn("BudgetType", typeof(System.String)));
			dt.Columns.Add(new DataColumn("BudgetMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("PlanMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ChangeMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("UsedMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ThisMoey", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("LeaveMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("ApplySheetHead_Pk", typeof(System.Int32)));
			dt.Columns.Add(new DataColumn("ReadyPayMoney", typeof(System.Decimal)));
			dt.Columns.Add(new DataColumn("AllowOutMoney", typeof(System.Decimal)));


			Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPk);
			Entiy.ApplySheetHeadBudget applyBudget=Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHeadPk);

			if(applyHead!=null && applyBudget!=null)
			{
				Entiy.Budgetaccount budgetAccount=Bussiness.BudgetAccountBLL.GetBudgetInfoByUserCode(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);
				if(budgetAccount!=null)
				{
					decimal ChangeMoney=Bussiness.BudgetAccountBLL.GetSubjectChangeMoney(applyHead.ApplyDate.Year,applyHead.ApplyDate.Month,applyHead.ApplyDeptCode,applyBudget.SheetSubject);

					#region 
//					this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");    //预算金额
//					this.lblPushMoney.Text=budgetAccount.PlanMoney.ToString("#,###.##");   //推算金额
//					this.lblChange.Text=ChangeMoney.ToString("#,###.##");                  //变更金额
//					this.lblSheetMoney.Text=applyBudget.SheetMoney.ToString("#,###.##");   //本次使用金额
//					this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");  //已经使用金额
					decimal tempLeft=budgetAccount.PlanMoney  + ChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;//剩余金额

					#endregion  

					DataRow  row=dt.NewRow();

					row["BudgetMoney"] = budgetAccount.BudgetMoney;
					row["PlanMoney"] = budgetAccount.PlanMoney;
					row["ChangeMoney"] = ChangeMoney;
					row["UsedMoney"] = applyBudget.SumCheckMoney;
					row["ThisMoey"] = applyBudget.SheetMoney;
					row["LeaveMoney"] = tempLeft;
					row["ApplySheetHead_Pk"] = applyHeadPk;


					if(applyBudget.SubmitType == 1 )
					{
						row["BudgetType"] = "预算内" ;
					}
					else if (applyBudget.SubmitType == 2 )
					{
						row["BudgetType"] = "预算外" ;
					}

					dt.Rows.Add(row);
				}
			}

			DataSet ds=new DataSet();
			ds.Tables.Add(dt);
			return ds;
		}

		/// <summary>
		/// 获取待审批个数
		/// </summary>
		/// <param name="personCode"></param>
		/// <returns></returns>
		public static int GetNaOfAuditing(string personCode)
		{
			return DataAccess.ApplySheet.ApplyAuditingDAL.GetNaAuditing(personCode);
		}





	}
}
