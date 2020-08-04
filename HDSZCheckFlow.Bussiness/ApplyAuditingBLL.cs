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
	/// ApplyAuditingBLL ��ժҪ˵����
	/// </summary>
	public class ApplyAuditingBLL:System.Web.UI.Page 
	{
		public ApplyAuditingBLL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			// 
		}
		/// <summary>
		/// ��ȡʵ���������Ϣ
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyInfo(int applyHeadPK)
		{
			DataSet ds = DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyInfo(applyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}

		/// <summary>
		/// ��ѯʵ�ﹺ���������ݵ���ϸ��Ϣ2 (�����Ѿ��е�����)
		/// </summary>
		/// <param name="applyHeadPk"></param>
		/// <returns></returns>
		public static DataSet GetApplyPurchaseBodyInfo(int applyHeadPk)
		{
			//DataSet ds = new DataSet();//DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPurchaseBodyInfo(applyHeadPk); 
			DataSet ds =  DataAccess.ApplySheet.ApplyAuditingDAL.GetApplyPurchaseBodyInfo(applyHeadPk); 
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;

		}

		/// <summary>
		/// ��ȡ�����������Ϣ
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyPayInfo(int applyHeadPK)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyPayInfo(applyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}


		/// <summary>
		/// ��ȡ��Ӫ�������Ϣ
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetInfo(int ApplyHeadPK)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyAssetInfo(ApplyHeadPK);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}

		/// <summary>
		/// ��ȡ��Ӫ�������Ϣ
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplySheetBodyAssetAndCheckInfo(int ApplyHeadPK,string Ids,string FId)
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetApplySheetBodyAssetAndCheckInfo(ApplyHeadPK,Ids,FId);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;
		}


		/// <summary>
		/// ��ѯ��Ӫ�����_�۸�þ�����(���ݱ�ͷ����)
		/// </summary>
		/// <param name="FinallyCheckId"></param>
		/// <returns></returns>
		public static DataSet GetFinallyBodyInfoByCheckId(int FinallyCheckId )
		{
			DataSet ds=DataAccess.ApplySheet.ApplyAuditingDAL.GetFinallyBodyInfoByCheckId(FinallyCheckId);
			if(ds!=null && ds.Tables[0].Rows.Count>0)
			{
				ds.Tables[0].Columns.Add("seqNum");        //���
				for (int i=0;i<ds.Tables[0].Rows.Count ;i++)
				{
					int Num=i+1;
					ds.Tables[0].Rows[i]["seqNum"]= Num.ToString() ;
					// ���������RMB�򣬻���ǿ��ָ��Ϊ 1 
					if(ds.Tables[0].Rows[i]["currTypeCode"].ToString() == "RMB")
					{
						ds.Tables[0].Rows[i]["ExchangeRate"] =  "1";
					}
				}
			}
			return ds;

		}

		/// <summary>
		/// ��ѯ������¼
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
						ds.Tables[0].Rows[i]["Name"]+= "(" + "��" + ds.Tables[0].Rows[i]["displaysName"].ToString()+"����" +")";
					}
				}
			}

			return ds;
		}

		/// <summary>
		/// ��ѯ������¼�۸�þ��� 
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
						ds.Tables[0].Rows[i]["Name"]+= "(" + "��" + ds.Tables[0].Rows[i]["displaysName"].ToString()+"����" +")";
					}
				}
			}

			return ds;
		}


		/// <summary>
		/// ���������¼
		/// </summary>
		public static void AddCheckRecord(int agreeType,string myCode,int ApplySheetHeadPk, Entiy.ApplySheetHead applyHead ,string disPlaysCode,string posital,int sign)
		{

			Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
			applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//��������
			applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//�������  ������/��˾�� 
			if(sign == 2 )
			{
				applyRecord.CheckRole="" ;				//������ɫ
			}
			else
			{
				applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//������ɫ
				applyRecord.CheckSetp=applyHead.CheckSetp;						//������
			}
			applyRecord.CheckPersonCode=myCode;								//������Code
			applyRecord.CheckComment=posital;								//�������
			applyRecord.Checkdate=DateTime.Now;								//����ʱ��
			if(!"".Equals(disPlaysCode))                     
			{
				applyRecord.DisplaysPersonCode = disPlaysCode;				//�������Code
				applyRecord.IsDisplays=1;									//�Ƿ��������
			}
			applyRecord.IsPass=agreeType;									//�Ƿ�ͬ��

			applyRecord.Create();

		}


		/// <summary>
		/// ����
		/// </summary>
		/// <param name="agreeType"></param>
		public   void Flow_AgreeApplySheet(int agreeType,string myCode,int ApplySheetHeadPk,string disPlaysCode,string posital,int sign)
		{
			try
			{
				//agreeType : 1ͬ�� , 0 �ܾ�

				//1. ��������־��¼�� ��¼��
				//string myCode=Bussiness.UserInfoBLL.GetUserName(UserID);

				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(ApplySheetHeadPk);
				if(applyHead!=null)
				{

					#region 
					//					Entiy.ApplySheetCheckRecord applyRecord=new  HDSZCheckFlow.Entiy.ApplySheetCheckRecord();
					//					applyRecord.ApplySheetHeadPk=ApplySheetHeadPk;					//��������
					//					applyRecord.IsCheckInCompany=applyHead.IsCheckInCompany;		//�������  ������/��˾�� 
					//					if(sign == 2 )
					//					{
					//						applyRecord.CheckRole="" ;				//������ɫ
					//					}
					//					else
					//					{
					//						applyRecord.CheckRole=applyHead.CurrentCheckRole ;				//������ɫ
					//						applyRecord.CheckSetp=applyHead.CheckSetp;						//������
					//					}
					//					applyRecord.CheckPersonCode=myCode;								//������Code
					//					applyRecord.CheckComment=posital;								//�������
					//					applyRecord.Checkdate=DateTime.Now;								//����ʱ��
					//					if(!"".Equals(disPlaysCode))                     
					//					{
					//						applyRecord.DisplaysPersonCode = disPlaysCode;				//�������Code
					//						applyRecord.IsDisplays=1;									//�Ƿ��������
					//					}
					//					applyRecord.IsPass=agreeType;									//�Ƿ�ͬ��
					//
					//					applyRecord.Create();
					#endregion 
					
					//���������¼
					AddCheckRecord(agreeType,myCode,ApplySheetHeadPk,applyHead,disPlaysCode,posital,sign);

					if(agreeType==1 || agreeType == 2 )
					{
						#region   ͬ�����Խ��


						//2.���´˵��ݵ���һ������ɫ 
						string Message="",	NextCheckCode ="";
						
						int CheckStep=0,DeptToCompany=0,IsGiveUp=0 ;
						string checkRole=Bussiness.CheckFlowInDeptBLL.GetCheckRole2(ApplySheetHeadPk,out CheckStep,out DeptToCompany,out Message,out IsGiveUp,out NextCheckCode );
						
						//�ж���һ�û��Ƿ�ѡ�����Ȩ��,����,��¼����������¼,������һ������Ա.
	

						if(DeptToCompany == 1 )                  //����״̬
						{
							applyHead.IsCheckInCompany=1;											//�����Ƿ������. IsInCompany 
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.CompanyPross;		//���½���״̬Ϊ��˾��
						}
						else if(DeptToCompany == 0 )
						{
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DeptPross;		//���½���״̬Ϊ�����ڿ�ʼ������
						}
						else if(DeptToCompany ==2  )
						{
							applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.OverPross;		//���½���״̬Ϊ����������
						}

						applyHead.CurrentCheckRole=checkRole ;   //������ɫ
						applyHead.CheckSetp=CheckStep;           //����


						applyHead.Update();

						if(IsGiveUp ==1 )
						{
							//���û���������,ѭ�����÷�������;

							Bussiness.ApplyAuditingBLL Audi = new ApplyAuditingBLL();


							Audi.Flow_AgreeApplySheet(2,NextCheckCode,ApplySheetHeadPk,"","",1 );
						}
						else
						{
							//ȡ�������ʼ�
//							//���ʼ�
//							if(DeptToCompany == 0 || DeptToCompany == 1)          
//							{
//								//����,��ɫ,����, �Ƿ�˾�� ������Ϣ,�ҵ�����(����1) 
//
//								Entiy.ApplyType  applyType = Entiy.ApplyType.Find(applyHead.ApplyTypeCode);
//								Entiy.ApplySheetHeadBudget appBud =  Entiy.ApplySheetHeadBudget.FindBySheetHeadPK(applyHead.ApplySheetHeadPk );
//								Bussiness.MailBLL mailBll=new HDSZCheckFlow.Bussiness.MailBLL(checkRole,CheckStep,DeptToCompany,applyHead.ApplyDeptCode,applyType.ApplyTypeName,appBud.SheetMoney.ToString("#,###.##"),applyHead.ApplySheetNo);
//								mailBll.ThreadSendMail();
//							}
							if( DeptToCompany == 2 )
							{
								//�����������̶��ʲ��ĵ��ݡ����ʼ����ʲ���Ա ������������
//								Bussiness.MailBLL1 mail = new Bussiness.MailBLL1(ApplySheetHeadPk);
//								mail.ThreadSendMail();
							}
						}
						#endregion  
					}
					else
					{
						#region  �ܾ�
						//3.���½���״̬Ϊ   ����  ,������ɫ��Ϊ�� ,����ҲΪ�� 
							
						applyHead.ApplyProcessCode=HDSZCheckFlow.Common.Const.DisPross ;		

						applyHead.Update();

//						//�����ʼ����ύ������Ա
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
		/// ������Ա����
		/// </summary>
		/// <param name="Role">��ɫ</param>
		/// <param name="Step">������</param>
		/// <param name="InCompany">�Ƿ�˾��</param>
		/// <param name="deptCode">����Code</param>
		/// <returns></returns>
		public static string GetPersonCodeByRoleAndSetp(string Role,int Step, int InCompany,string deptCode)
		{
			try
			{
				string  returnValue="";
				//��Ҫ�鿴�Ƿ�Ȩ��ת��������, ת���Ļ���ֻ���ر��˵Ĺ���
				if(InCompany==0)                   //������ ,��Ҫ�鿴 ����Code��������
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
				else if(InCompany==1)              //��˾��,��Ҫ����ɫ
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
		/// ���ʼ�����
		/// </summary>
		/// <param name="UserCode"></param>
		public static void SendEmailByUserCode(string UserCode,string applyType,string applyMoney,string applySheetNo)
		{
			// Ŀǰֻ��һ���ʼ���ʽ.

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
						// 1. �Ҵ��˵ĳƺ�

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
						
						string title="Ԥ����������" + applySheetNo;

//						string content="�𾴵�$User:����һ�ݵ��ݺ�Ϊ:$applyNo ����Ϊ:$Type  ���Ϊ:$Money ����������,������������.лл!";
//
//						content=content.Replace("$User",nickName);
//						content=content.Replace("$Type",applyType);
//						content=content.Replace("$Money",applyMoney);
//						content=content.Replace("$applyNo",applySheetNo);

						//����htmlģ���ʼ�
						string content = "";
						//���ļ���
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

		//��ȡ�ļ�
		public static string  EmailStr(string Path)
		{
			string strLine = "";
			
			StreamReader sr = new StreamReader(Path, Encoding.GetEncoding("GB2312"));

			strLine= sr.ReadToEnd();
				
			sr.Close();
			
			return strLine ; 

		}

		/// <summary>
		/// ����ʱ�����ʼ�
		/// </summary>
		/// <param name="ToCode"></param>
		/// <param name="FromCode"></param>
		/// <param name="postail">����ʱ,���</param>
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
					// 1. �Ҵ��˵ĳƺ�

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
						
					string title="��������������";

					string content="�𾴵�{0}:���ĵ��ݺ�Ϊ {1} �����뱻 {2} ����! ���������� : {3}";

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
		/// ��ȡ�ҵ��Ѿ������ĵ��ݼ�¼
		/// </summary>
		/// <param name="userCode"></param>
		/// <param name="ispass"></param>
		/// <returns></returns>
		public static DataSet GetMyAuditedApply(string query)
		{
			DataSet ds=  DataAccess.ApplySheet.ApplyAuditingDAL.GetMyAuditedApply(query); 
			//ȥ����ͬ����,ֻ��ʾһ��
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
		/// ��ѯ��Ҫ��ӡ�ĵ�����Ϣ
		/// </summary>
		/// <param name="applyHeadPK"></param>
		/// <returns></returns>
		public static DataSet GetApplyPhuse(int applyHeadPK)
		{
			try
			{
				string view="",view2="";
				string query="",query2="";
				// 1. ȡ��Ҫ��ѯ����ͼ 
				Entiy.ApplySheetHead applyHead=Entiy.ApplySheetHead.Find(applyHeadPK);
			
				Entiy.ApplyType applyType=Entiy.ApplyType.Find(applyHead.ApplyTypeCode);

				if("ReportForPurchase.rpt".Equals(applyType.Report))
				{
					view = "v_BaseApplyPurchase";  // Ҫ��ѯ������ v_BaseApplyPurchase , v_ApplyCheckRecord ��������Ϣ,������Ϣ
					query = " where ApplySheetHead_pk= " + applyHeadPK + "  ";
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //��ɵ�ȡ��������Ϣ
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='�ܾ�'  ";

					}
					else
					{
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //ʵ����
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //��ʵ����
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}
					}			
					//���һ�����ϱ����DataSet ,(1.װ���������DataSet BaseApplyPurchase,ApplyCheckRecord)
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
					view = "v_BaseApplyPay";  // Ҫ��ѯ������ v_BaseApplyPay , v_ApplyCheckRecord ��������Ϣ,������Ϣ
					query = " where ApplySheetHead_pk= " + applyHeadPK    ;
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //��ɵ�ȡ��������Ϣ
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='�ܾ�'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";

						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}



					}			
					//���һ�����ϱ����DataSet ,(1.װ���������DataSet BaseApplyPurchase,ApplyCheckRecord)
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
					view = "v_BaseApplyEvection";  // Ҫ��ѯ������ v_BaseApplyPay , v_ApplyCheckRecord ��������Ϣ,������Ϣ
					query = " where ApplySheetHead_pk= " + applyHeadPK + "  ";
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //��ɵ�ȡ��������Ϣ
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='�ܾ�'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}

					}		
					//���һ�����ϱ����DataSet ,(1.װ���������DataSet BaseApplyPurchase,ApplyCheckRecord)
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
					view = "v_BaseApplyBanquet";  // Ҫ��ѯ������ v_BaseApplyPay , v_ApplyCheckRecord ��������Ϣ,������Ϣ
					query = " where ApplySheetHead_pk= " + applyHeadPK     ;
					if(applyHead.ApplyProcessCode == "106")
					{
						view2 = "v_ApplyCheckRecord1";             //��ɵ�ȡ��������Ϣ
						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by checkdate  "  ;//+ "  and  ispass!='�ܾ�'  ";

					}
					else
					{
//						view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
//						query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						if(applyType.ApplyTypeCode == "101" || applyType.ApplyTypeCode == "102")
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}
						else
						{
							view2 = "v_ApplyCheckRecord";              //δ��ɵ�ȡ����������Ϣ
							query2 = "  where ApplySheetHead_pk= " + applyHeadPK  + "  and checksetp > 0    order by ischeckincompany,checksetp "  ;//+ "  and  ispass!='�ܾ�'  ";
						}

					}
					//���һ�����ϱ����DataSet ,(1.װ���������DataSet BaseApplyPurchase,ApplyCheckRecord)
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
					//û����������
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
			//Ԥ�����
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

					//	decimal tempLeft=decimal.Parse(ds.Tables[0].Rows[0]["budgetmoney"].ToString()) + applyBudget.AllowOutMoney  + ChangeMoney  - decimal.Parse(ds.Tables[0].Rows[0]["checkmoney"].ToString()) -decimal.Parse(ds.Tables[0].Rows[0]["readypay"].ToString());  //ʣ����
					decimal UsedMoney = 0 ; 
					decimal TotalAllowOutMoney = 0 ; 

					DataRow  row=dt.NewRow();
					//�½�״̬�µ���ʹ�ý��
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
						row["BudgetType"] = "Ԥ����" ;
					}
					else if (applyBudget.SubmitType == 2 )
					{
						row["BudgetType"] = "Ԥ����" ;
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
			//Ԥ�����

			
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
//					this.lblBudget.Text=budgetAccount.BudgetMoney.ToString("#,###.##");    //Ԥ����
//					this.lblPushMoney.Text=budgetAccount.PlanMoney.ToString("#,###.##");   //������
//					this.lblChange.Text=ChangeMoney.ToString("#,###.##");                  //������
//					this.lblSheetMoney.Text=applyBudget.SheetMoney.ToString("#,###.##");   //����ʹ�ý��
//					this.lblSumCheck.Text=applyBudget.SumCheckMoney.ToString("#,###.##");  //�Ѿ�ʹ�ý��
					decimal tempLeft=budgetAccount.PlanMoney  + ChangeMoney  -applyBudget.SheetMoney -applyBudget.SumCheckMoney ;//ʣ����

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
						row["BudgetType"] = "Ԥ����" ;
					}
					else if (applyBudget.SubmitType == 2 )
					{
						row["BudgetType"] = "Ԥ����" ;
					}

					dt.Rows.Add(row);
				}
			}

			DataSet ds=new DataSet();
			ds.Tables.Add(dt);
			return ds;
		}

		/// <summary>
		/// ��ȡ����������
		/// </summary>
		/// <param name="personCode"></param>
		/// <returns></returns>
		public static int GetNaOfAuditing(string personCode)
		{
			return DataAccess.ApplySheet.ApplyAuditingDAL.GetNaAuditing(personCode);
		}





	}
}
