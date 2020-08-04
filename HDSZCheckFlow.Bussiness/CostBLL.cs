using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// CostBLL 的摘要说明。
	/// </summary>
	public class CostBLL
	{
		public CostBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		public static DataSet getCost(int iYear,int iMonth)
		{
			return DataAccess.CostAssay.CostDAL.getCost(iYear,iMonth);
		}

		/// <summary>
		/// 查询所有预算报表部门 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetAllBudgetDept()
		{
			string filter = "   group by tablecode,tablename order by  tablecode,tablename";
			return DataAccess.CostAssay.CostDAL.GetBudgetDept(filter);
		}



		public static DataSet BindAccBook(string key)

		{

			return DataAccess.CostAssay.CostDAL.BindAccBook(key);
		}





		/// <summary>
		/// 查询所有预算报表部门 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetBudgetDept()
		{
			string filter = " where  classtype='budget' and type='dept'  group by tablecode,tablename ";
			return DataAccess.CostAssay.CostDAL.GetBudgetDept(filter);
		}


		/// <summary>
		/// 查询预算报表部门 (大类 )
		/// </summary>
		/// <returns></returns>
		public static DataSet GetBudgetClassDept()
		{
			string filter = " where  classtype='budget' and type='Classdept' group by tablecode,tablename";
			return DataAccess.CostAssay.CostDAL.GetBudgetDept(filter);
		}


		/// <summary>
		/// 查询所有预算部门
		/// </summary>
		/// <returns></returns>
		public static DataSet GetAllBudgetDeptInfo()
		{
			return DataAccess.CostAssay.CostDAL.GetAllBudgetDeptInfo();
		}




		/// <summary>
		/// 根据预算报表部门 查询其预实算信息
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByDept(int iYear,int iMonth,string budGetDept ,string subject)
		{
			DataSet ds= DataAccess.CostAssay.CostDAL.GetBudgetCostByDept( iYear, iMonth, budGetDept , subject) ;

			//处理ds ,添加，实/预 比例， 实/推 比例
			ds.Tables[0].Columns.Add("costPY");         //实/预 比
			ds.Tables[0].Columns.Add("costPP");         //实/推 比
			for(int i=0;i<ds.Tables[0].Rows.Count; i++)
			{
				if(iMonth <= 3 || (iMonth>6 && iMonth<=9))  //用 1 q的比较
				{
					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),ds.Tables[0].Rows[i]["oneQ"].ToString());
				}
				else
				{
					//用 2 q的比较
					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),ds.Tables[0].Rows[i]["twoQ"].ToString());
				}
				ds.Tables[0].Rows[i]["costPP"] = Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),ds.Tables[0].Rows[i]["PlanMoney"].ToString());
			}
			return ds;
		}


		/// <summary>
		/// 根据预算报表部门 查询其预实算信息,原样输出
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByClassDept2(int iYear,int iMonth,string tableCode,string AccBook)
		{
			DataSet ds =  DataAccess.CostAssay.CostDAL.GetBudgetCostByClassDept( iYear, iMonth, tableCode,AccBook) ;

			
			//添加超支金额
			DataColumn myColumn = new DataColumn("OverSpend",System.Type.GetType("System.Decimal")); 
			ds.Tables[0].Columns.Add(myColumn);

			//处理ds ,添加，实/预 
			ds.Tables[0].Columns.Add("costPY"); 

			for(int i=0;i<ds.Tables[0].Rows.Count; i++)
			{
				decimal change= decimal.Parse(ds.Tables[0].Rows[i]["changemoney"].ToString());
				decimal real  = decimal.Parse(ds.Tables[0].Rows[i]["localrealcost"].ToString());
				decimal budget= decimal.Parse(ds.Tables[0].Rows[i]["budgetmoney"].ToString());
				//超支金额 = 发生金额 - 预算 - 调整(1/3 yue ???) 
				decimal overspend = real - budget - change ; 

			
				if( overspend < 0 )
				{
					overspend = 0 ;
				}
				
				ds.Tables[0].Rows[i]["OverSpend"] = overspend;

				decimal test = budget + change + overspend ; 

				ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),test.ToString());

			}

			return ds;


		}

		/// <summary>
		/// 根据预算报表部门 查询其预实算信息
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByClassDept(int iYear,int iMonth,string tableCode,string AccBook)
		{
			DataSet ds= DataAccess.CostAssay.CostDAL.GetBudgetCostByClassDept( iYear, iMonth, tableCode,AccBook) ;

			//添加超支金额
			DataColumn myColumn = new DataColumn("OverSpend",System.Type.GetType("System.Decimal")); 
			ds.Tables[0].Columns.Add(myColumn);

			//处理ds ,添加，实/预 
			ds.Tables[0].Columns.Add("costPY");        

			for(int i=0;i<ds.Tables[0].Rows.Count; i++)
			{
				decimal change= decimal.Parse(ds.Tables[0].Rows[i]["changemoney"].ToString());
				decimal real  = decimal.Parse(ds.Tables[0].Rows[i]["localrealcost"].ToString());
				decimal oneq  = decimal.Parse(ds.Tables[0].Rows[i]["oneq"].ToString());
				decimal twoq  = decimal.Parse(ds.Tables[0].Rows[i]["twoq"].ToString());


				if(iMonth <= 3 || (iMonth>6 && iMonth<=9))  //用 1 q的比较
				{
					//超支金额 = 发生金额 - 预算 - 调整 
					decimal overspend = real - oneq - change ; 

					ds.Tables[0].Rows[i]["OverSpend"] = overspend;


					if( overspend < 0 )
					{
						overspend = 0 ;
					}


					decimal test = oneq + change + overspend ; 


					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),test.ToString());
				}
				else   //用 2 q的比较
				{
					//超支金额 = 发生金额 - 预算 - 调整 
					decimal overspend = real - twoq - change ; 

					ds.Tables[0].Rows[i]["OverSpend"] = overspend;


					if( overspend < 0 )
					{
						overspend = 0 ;
					}

					decimal test = twoq + change + overspend ; 
					
					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),test.ToString());
				}
			}
			return ds;
		}

		/// <summary>
		/// 根据预算报表部门 查询其预实算信息
		/// </summary>
		/// <param name="iYear"></param>
		/// <param name="iMonth"></param>
		/// <param name="budGetDept"></param>
		/// <param name="subject"></param>
		/// <returns></returns>
		public static DataSet GetBudgetCostByCompanyDept(int iYear,int iMonth)
		{
			DataSet ds= DataAccess.CostAssay.CostDAL.GetBudgetCostByCompanyDept( iYear, iMonth) ;


//			Dim   MyColumn   As   DataColumn   
//                          MyColumn   =   New   DataColumn   
//                          MyColumn.DataType   =   System.Type.GetType("System.String")   
//                          MyColumn.AllowDBNull   =   False   
//                          MyColumn.Caption   =   "COURSE_NO"   
//                          MyColumn.ColumnName   =   "COURSE_NO"   
//                          MyColumn.DefaultValue   =   ""   
//                          ds.Tables(0).Columns.Add(MyColumn)   
			
			//添加超支金额
			DataColumn myColumn = new DataColumn("OverSpend",System.Type.GetType("System.Decimal")); 
			ds.Tables[0].Columns.Add(myColumn);    
			//ds.Tables[0].Columns["OverSpend"].DataType =  System.Type.GetType("System.Decimal")     ; 


			//处理ds ,添加，实/预 比例， 实/推 比例
			ds.Tables[0].Columns.Add("costPY");         //实/预 比

			for(int i=0;i<ds.Tables[0].Rows.Count; i++)
			{
				decimal change= decimal.Parse(ds.Tables[0].Rows[i]["changemoney"].ToString());
				decimal real  = decimal.Parse(ds.Tables[0].Rows[i]["localrealcost"].ToString());
				decimal oneq  = decimal.Parse(ds.Tables[0].Rows[i]["oneq"].ToString());
				decimal twoq  = decimal.Parse(ds.Tables[0].Rows[i]["twoq"].ToString());

				if(iMonth <= 3 || (iMonth>6 && iMonth<=9))  //用 1 q的比较
				{
					//超支金额 = 发生金额 - 预算 - 调整 
					decimal overspend = real - oneq - change ; 

					ds.Tables[0].Rows[i]["OverSpend"] = overspend.ToString();


					if( overspend < 0 )
					{
						overspend = 0 ;
					}


					decimal test = oneq + change + overspend ; 


					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),test.ToString());
				}
				else
				{
					//超支金额 = 发生金额 - 预算 - 调整 
					decimal overspend = real - twoq - change ; 

					ds.Tables[0].Rows[i]["OverSpend"] = overspend.ToString();


					if( overspend < 0 )
					{
						overspend = 0 ;
					}


					decimal test = twoq + change + overspend ; 

					//用 2 q的比较
					ds.Tables[0].Rows[i]["costPY"]=Common.Util.CommonUtil.StringToIntChu(ds.Tables[0].Rows[i]["localRealCost"].ToString(),test.ToString());
				}
			}
			return ds;
		}


		/// <summary>
		/// 查询预推差异
		/// </summary>
		/// <param name="iYear">年份</param>
		/// <param name="Quarter">季度</param>
		/// <param name="type">类别,0 有差异, 1 所有</param>
		/// <returns></returns>
		public static DataSet GetBudgetCostCompare(int iYear , int Quarter, int type )
		{
			return DataAccess.CostAssay.CostDAL.GetBudgetCostCompare(iYear,Quarter,type);
		}

		public static DataSet GetBudgetCostCompare2(int iYear , int Quarter, int type,string budgetDept)
		{
			return DataAccess.CostAssay.CostDAL.GetBudgetCostCompare2(iYear,Quarter,type,budgetDept);
		}

		public static void UpdateGl_NC_Cost(int iYear,int iMonth )
		{
			DataAccess.CostAssay.CostDAL.UpdateGl_NC_Cost(iYear,iMonth);
		}


		//
		public static DataSet GetProcInfo(string ProcName,int iYear,int iMonth,string AccBook)
		{
			return DataAccess.CostAssay.CostDAL.GetProcInfo(ProcName,iYear,iMonth,AccBook);
		}

		public static DataSet GetProcInfo(string ProcName,string tablename,int iYear,int StMonth,int EdMonth,string AccBook)
		{
			return DataAccess.CostAssay.CostDAL.GetProcInfo(ProcName,tablename,iYear,StMonth,EdMonth,AccBook);
		}


		/// <summary>
		/// 计算固定资产折旧信息
		/// </summary>
		/// <returns></returns>
		public static DataSet RunFaCardbyDate(int iYear ,int iMonth)
		{
			//1.取得查询字符串 
			return DataAccess.CostAssay.CostDAL.RunFaCardbyDate(iYear,iMonth);

		}





	}
}
