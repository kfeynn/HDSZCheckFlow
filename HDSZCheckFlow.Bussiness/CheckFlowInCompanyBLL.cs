using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CheckFlowInCompanyBLL 的摘要说明。
	/// </summary>
	public class CheckFlowInCompanyBLL
	{
		public CheckFlowInCompanyBLL()
		{

		}
		/// <summary>
		/// 检测所有流程名的有效性
		/// </summary>
		/// <returns>返回table装载的错误信息</returns>
		public static  void CheckFlowHeadValid(out DataTable lblMessage)
		{
			//检测所有流程,更新其有效性字段. 不有效,返回原因. table 

			lblMessage=new  DataTable  ();
			lblMessage.Columns.Add("流程名");
			lblMessage.Columns.Add("错误信息");

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
							message="流程未关联相关流程信息";
						}
						else if(result==2)
						{
							message="流程不具有结束标识";
						}
						else if(result==3)
						{
							message="有重复的审批级";
						}
						else if(result==4)
						{
							message="流程具有多个结束标识";
						}

						DataRow dr=lblMessage.NewRow();
						dr["流程名"]=checkFlowHead.FlowName ;
						dr["错误信息"]=message;
						lblMessage.Rows.Add(dr);
						//更新流程的有效性 字段为 0
						checkFlowHead.IsValid=0;
						checkFlowHead.Update();
					}
					else
					{
						//更新流程的有效性 字段为 1
						checkFlowHead.IsValid=1;
						checkFlowHead.Update();
					}
				}
			}
		}
		/// <summary>
		/// 监测单个流程是否有效
		/// </summary>
		/// <param name="headPk"></param>
		/// <returns></returns>
		public static int CheckOneFlowHeadValid(int headPk)
		{
//			检测流程是否合法
//
//			有效                                       0 
//			流程名关联了相关流程信息                   1
//			查看是否有流程最高级的标识,				   2
//			审批级从小到大无重复                       3
//			流程最高级的标识只能有一个				   4

			return DataAccess.CheckFlow.CheckFlowInCompanyDAL.CheckOneFlowHeadValid(headPk);

		}

		/// <summary>
		/// 查询公司审批角色,人员
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
