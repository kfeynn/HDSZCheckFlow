using System;
using System.Web;

using Dal=HDSZCheckFlow.Entiy  ;
using da=HDSZCheckFlow.DataAccess;
using System.Threading;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// GetCostBll 获取金额，新开线程
	/// </summary>
	public class GetCostBll
	{
		public GetCostBll()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public GetCostBll(int  _iyear,int  _imonth )
		{
			iYear=_iyear;
			iMonth=_imonth;
		}

		//外面传进来
		private  int iYear;
		private  int iMonth;

		public  void ThreadGetCostl() //string checkRole,int CheckStep,int  DeptToCompany,string ApplyDeptCode)
		{
			try
			{
				//加载邮件主体

				ThreadStart myThreadDelegate = new ThreadStart(DoWork);
				Thread myThread = null;	

				myThread = new Thread(myThreadDelegate);
				myThread.Start();

			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("GetCost",ex.Message );
			}
		}

		private void DoWork()
		{
			try
			{
				 
				DataAccess.CostAssay.CostDAL.UpdateGl_NC_Cost(iYear,iMonth);
				 
			}
			catch(Exception ex)
			{
				HDSZCheckFlow.Common.Log.Logger.Log("ThreadGetCostl",ex.Message );
			}
		}




	}
}
