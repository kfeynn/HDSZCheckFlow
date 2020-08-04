using System;

namespace HDSZCheckFlow.Common
{
	/// <summary>
	/// Const 的摘要说明。
	/// </summary>
	public class Const
	{
		public Const()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}






		//申请单进程

		public const string NewPross="101";             //新建
		public const string SubmitPross="102";			//提交
		public const string DeptPross="103";			//部门审批
		public const string CompanyPross="104";			//公司审批
		public const string DisPross="105";				//驳回
		public const string OverPross="106";			//完成审批
		public const string GetBackPross="201";			//取回
//		public const string SubmitAgain="202";			//重新提交
//		public const string DeptAgain="203";			//部门重审
//		public const string CompanyAgain="204";			//公司重审
//		public const string DisAgain="205";				//再次驳回
//		public const string OverAgain="206";			// 完成


		public const int InBudget=1;					//预算内标识 (审批)
		public const int OutBudget=2;					//预算外标识
		public const int PressBudget=3;					//紧急标识


		public const int PressMaxMoney=3000;            //紧急审批金额上限






	}
}
