using System;
using System.Web;

using Dal=HDSZCheckFlow.Entiy  ;
using da=HDSZCheckFlow.DataAccess;
using System.Threading;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// GetCostBll ��ȡ���¿��߳�
	/// </summary>
	public class GetCostBll
	{
		public GetCostBll()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		public GetCostBll(int  _iyear,int  _imonth )
		{
			iYear=_iyear;
			iMonth=_imonth;
		}

		//���洫����
		private  int iYear;
		private  int iMonth;

		public  void ThreadGetCostl() //string checkRole,int CheckStep,int  DeptToCompany,string ApplyDeptCode)
		{
			try
			{
				//�����ʼ�����

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
