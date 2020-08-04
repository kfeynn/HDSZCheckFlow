using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CheckFlowInCompanyBLL ��ժҪ˵����
	/// </summary>
	public class CheckFlowInCompanyBLL
	{
		public CheckFlowInCompanyBLL()
		{

		}
		/// <summary>
		/// �����������������Ч��
		/// </summary>
		/// <returns>����tableװ�صĴ�����Ϣ</returns>
		public static  void CheckFlowHeadValid(out DataTable lblMessage)
		{
			//�����������,��������Ч���ֶ�. ����Ч,����ԭ��. table 

			lblMessage=new  DataTable  ();
			lblMessage.Columns.Add("������");
			lblMessage.Columns.Add("������Ϣ");

			Entiy.CheckFlowInCompanyhead[] checkFlowHeads = Entiy.CheckFlowInCompanyhead.FindAll();
			if(checkFlowHeads != null && checkFlowHeads.Length>0)
			{
				foreach(Entiy.CheckFlowInCompanyhead checkFlowHead in checkFlowHeads)
				{
					int result=CheckOneFlowHeadValid(checkFlowHead.CheckFlowInCompanyHeadPk);
					if(result!=0)
					{
						string message="";
						if(result==1)
						{
							message="����δ�������������Ϣ";
						}
						else if(result==2)
						{
							message="���̲����н�����ʶ";
						}
						else if(result==3)
						{
							message="���ظ���������";
						}
						else if(result==4)
						{
							message="���̾��ж��������ʶ";
						}

						DataRow dr=lblMessage.NewRow();
						dr["������"]=checkFlowHead.FlowName ;
						dr["������Ϣ"]=message;
						lblMessage.Rows.Add(dr);
						//�������̵���Ч�� �ֶ�Ϊ 0
						checkFlowHead.IsValid=0;
						checkFlowHead.Update();
					}
					else
					{
						//�������̵���Ч�� �ֶ�Ϊ 1
						checkFlowHead.IsValid=1;
						checkFlowHead.Update();
					}
				}
			}
		}
		/// <summary>
		/// ��ⵥ�������Ƿ���Ч
		/// </summary>
		/// <param name="headPk"></param>
		/// <returns></returns>
		public static int CheckOneFlowHeadValid(int headPk)
		{
//			��������Ƿ�Ϸ�
//
//			��Ч                                       0 
//			���������������������Ϣ                   1
//			�鿴�Ƿ���������߼��ı�ʶ,				   2
//			��������С�������ظ�                       3
//			������߼��ı�ʶֻ����һ��				   4

			return DataAccess.CheckFlow.CheckFlowInCompanyDAL.CheckOneFlowHeadValid(headPk);

		}

		/// <summary>
		/// ��ѯ��˾������ɫ,��Ա
		/// </summary>
		/// <param name="query"></param>
		/// <returns></returns>
		public static DataTable GetFlowCheckInfoByQuery(int CompanyFlowPK,string DeptCode)
		{
			//return 	DataAccess.CheckFlow.CheckFlowInCompanyDAL.GetFlowCheckInfoByQuery(query);
			return 	DataAccess.CheckFlow.CheckFlowInCompanyDAL.GetFlowCheckInfoByCompanyFlowPkAndDeptCode(CompanyFlowPK,DeptCode);
		}


	}
}
