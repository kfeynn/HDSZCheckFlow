using System;
using System.Data;

namespace HDSZCheckFlow.DataAccess.SmallFixed
{
	/// <summary>
	/// SmallFixedDAL 的摘要说明。
	/// </summary>
	public class SmallFixedDAL
	{
		public SmallFixedDAL()
		{ 
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
 
		/// <summary>
		/// 根据OrderId查找  OrderBody信息
		/// </summary>
		/// <param name="OrderId"></param>
		/// <returns></returns>
		public static DataTable   GetNCTypeInfo( )
		{

			string cmdStr = " select * from dbo.Base_InvClass where invClassCode like 'E%' ";
			DBAccess dbAccess = new SQLAccess();
			return  dbAccess.ExecuteDataset (cmdStr).Tables[0];

		}


		public static DataTable   GetNCDeptInfo( )
		{
			string cmdStr = " select *, Nc_DeptCode + '-' + NC_DeptName as DeptCode_DeptName  from dbo.Base_NC_Dept ";  
			DBAccess dbAccess = new SQLAccess();
			return  dbAccess.ExecuteDataset (cmdStr).Tables[0];

		} 

		/// <summary>
		/// 检查是否存在管理编码
		/// </summary>
		/// <param name="InvManageCode"></param>
		/// <returns></returns>
		public static bool CheckExistsInvManageCode(string invManageCode)
		{
			bool flag=false;
			string cmdStr = " select count(1) from SmallFixedAssets where InvManageCode='"+invManageCode+"' ";  
			DBAccess dbAccess = new SQLAccess();
			object obj= dbAccess.ExecuteScalar( cmdStr);
			if(obj.ToString()=="1")
			{
				flag=true;
			}
			else
			{
				flag=false;
			}
			return  flag;
		}

		//物料信息
		public static DataTable   GetInvInfo( )
		{
			string cmdStr = " select [inv_pk], [invCode] + '-' + [invName] as InvCode_InvName  FROM [Base_inventory] order by invCode "; 
			DBAccess dbAccess = new SQLAccess();
			return  dbAccess.ExecuteDataset (cmdStr).Tables[0];
		}

		public static int Save(Entiy.SmallFixedAsset sfa)
		{
			string sql=" insert into SmallFixedAssets  (InvSheetId,Vbillcode,Cinventoryid,Dbizdate,Noutnum,Ninnum,Cwarehouseid,Cdispatcherid,Cdptid,Price,CurrTypeCode,InvManageCode,DeptClassCode,DeptCode,RetireDate,IsRetire,ReMark,iNum,KeeperCode,storage) "+ 
								" values(@InvSheetId,@Vbillcode,@Cinventoryid,@Dbizdate,@Noutnum,@Ninnum,@Cwarehouseid,@Cdispatcherid,@Cdptid,@Price,@CurrTypeCode,@InvManageCode,@DeptClassCode,@DeptCode,@RetireDate,@IsRetire,@ReMark,@iNum,@KeeperCode,@storage) ";


			DBAccess dbAccess = new SQLAccess();
			DBParameterCollection param=new DBParameterCollection();

			//param.Add(Parameter.GetDBParameter("@ID",sfa.ID));
			param.Add(Parameter.GetDBParameter("@InvSheetId",sfa.InvSheetId));
			param.Add(Parameter.GetDBParameter("@Vbillcode",sfa.Vbillcode));
			param.Add(Parameter.GetDBParameter("@Cinventoryid",sfa.Cinventoryid));
			param.Add(Parameter.GetDBParameter("@Dbizdate",sfa.Dbizdate));
			param.Add(Parameter.GetDBParameter("@Noutnum",sfa.Noutnum));
			param.Add(Parameter.GetDBParameter("@Ninnum",sfa.Ninnum));
			param.Add(Parameter.GetDBParameter("@Cwarehouseid",sfa.Cwarehouseid));
			param.Add(Parameter.GetDBParameter("@Cdispatcherid",sfa.Cdispatcherid));
			param.Add(Parameter.GetDBParameter("@Cdptid",sfa.Cdptid));
			param.Add(Parameter.GetDBParameter("@Price",sfa.Price));
			param.Add(Parameter.GetDBParameter("@CurrTypeCode",sfa.CurrTypeCode));

			param.Add(Parameter.GetDBParameter("@InvManageCode",sfa.InvManageCode));
			param.Add(Parameter.GetDBParameter("@DeptClassCode",sfa.DeptClassCode));
			param.Add(Parameter.GetDBParameter("@DeptCode",sfa.DeptCode));

			param.Add(Parameter.GetDBParameter("@RetireDate",sfa.RetireDate));//报废日期--
			param.Add(Parameter.GetDBParameter("@IsRetire",sfa.IsRetire));//是否报废 --
			param.Add(Parameter.GetDBParameter("@ReMark",sfa.ReMark));//备注 --

			//@iNum,@KeeperCode,@storage(2014-07-10 liyang)
			param.Add(Parameter.GetDBParameter("@iNum",sfa.INum));//数量--
			param.Add(Parameter.GetDBParameter("@KeeperCode",sfa.KeeperCode));//责任人工号 --
			param.Add(Parameter.GetDBParameter("@storage",sfa.Storage));//存放位置 --


 
			return dbAccess.ExecuteNonQuery(sql,CommandType.Text,param);

			/*
			 * sfa.InvSheetId=ID;
						sfa.Vbillcode=ds.Tables[0].Rows[0]["vbillcode"].ToString();
						sfa.Cinventoryid=ds.Tables[0].Rows[0]["cinventoryid"].ToString();
						sfa.Dbizdate=DateTime.Parse(ds .Tables[0].Rows[0]["dbizdate"].ToString());
						sfa.Noutnum=ds.Tables[0].Rows[0]["noutnum"].ToString();
						sfa.Ninnum=ds.Tables[0].Rows[0]["ninnum"].ToString();
						sfa.Cwarehouseid=ds.Tables[0].Rows[0]["cwarehouseid"].ToString();
						sfa.Cdispatcherid=ds.Tables[0].Rows[0]["cdispatcherid"].ToString();
						sfa.Cdptid=ds.Tables[0].Rows[0]["cdptid"].ToString();
						sfa.RetireDate=(DateTime)System.Data.SqlTypes.SqlDateTime.Null;
			 * */
		}


		public static int Update(Entiy.SmallFixedAsset sfa)
		{
			string sql=" update  SmallFixedAssets set   "+
				" Cinventoryid=@Cinventoryid, "+
				" InvManageCode=@InvManageCode, "+
				" Dbizdate=@Dbizdate, "+
				" Price=@Price, "+
				" CurrTypeCode=@CurrTypeCode, "+
				" DeptClassCode=@DeptClassCode, "+
				" DeptCode=@DeptCode, "+					
				" ReMark=@ReMark, "+
				" iNum=@iNum, "+
				" KeeperCode=@KeeperCode, "+
				" storage=@storage "+ 
				" where ID=@ID ";


			DBAccess dbAccess = new SQLAccess();
			DBParameterCollection param=new DBParameterCollection();

			param.Add(Parameter.GetDBParameter("@ID",sfa.ID));
			param.Add(Parameter.GetDBParameter("@Cinventoryid",sfa.Cinventoryid));
			param.Add(Parameter.GetDBParameter("@Dbizdate",sfa.Dbizdate));
			param.Add(Parameter.GetDBParameter("@Price",sfa.Price));
			param.Add(Parameter.GetDBParameter("@CurrTypeCode",sfa.CurrTypeCode));
			param.Add(Parameter.GetDBParameter("@InvManageCode",sfa.InvManageCode));
			param.Add(Parameter.GetDBParameter("@DeptClassCode",sfa.DeptClassCode));
			param.Add(Parameter.GetDBParameter("@DeptCode",sfa.DeptCode));
			param.Add(Parameter.GetDBParameter("@ReMark",sfa.ReMark));//备注 --
			//@iNum,@KeeperCode,@storage(2014-07-10 liyang)
			param.Add(Parameter.GetDBParameter("@iNum",sfa.INum));//数量--
			param.Add(Parameter.GetDBParameter("@KeeperCode",sfa.KeeperCode));//责任人工号 --
			param.Add(Parameter.GetDBParameter("@storage",sfa.Storage));//存放位置 --

			return dbAccess.ExecuteNonQuery(sql,CommandType.Text,param);
		}
 






	}
}
