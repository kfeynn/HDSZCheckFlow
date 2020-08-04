using System;
using System.Data;
using  entiy=HDSZCheckFlow.Entiy;

namespace HDSZCheckFlow.DataAccess.FixedAssets
{
	/// <summary>
	/// AssetAdvanceRemarksDAL ��ժҪ˵����
	/// </summary>
	public class AssetAdvanceRemarksDAL
	{
		public AssetAdvanceRemarksDAL()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
				
		}

		/// <summary>
		/// ��ѯ���еĹ��������ǵ���Ԥ��������� 
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectFinallyPriceOrBody()
		{
			string cmdStr= @"select b.Id ,a.ApplySheetHead_Pk,a.PriceCheckSheetNo,a.,a.ApplyDeptClassCode,a.ApplyDeptCode"
+" ,a.ApplyPersonCode,a.RequestDate,a.BargainNo,b.FinallyPriceCheck_Id,b.SubjectName,b.InventoryName"
+" ,b.Offer,b.Article,b.Remark,b.Base_Unit_id,b.Number,b.originalcurrPrice,b.currTypeCode,b.FinallyPrice,b.Earnest,b.EarnestSigner,b.EarnestDatetime,b.EarnestRemark"
+"  from dbo.Asset_FinallyPriceCheck  as a inner join dbo.Asset_FinallyPriceCheck_Body as b"
+" on  a.ApplySheetHead_Pk = b.FinallyPriceCheck_Id  and b.Earnest = 1";
			DBAccess dbAccess=new SQLAccess();
			return dbAccess.ExecuteDataset(cmdStr).Tables[0];
		}
		

		/// <summary>
		/// ��ѯ����Ԥ�㱨���� 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetPageDataPagination(entiy.PageViewState view)
		{

			
			try
			{
			    	
				string cmdStr="[dbo].[proc_DataPagination]";
				DBAccess dbAccess=new SQLAccess();

				DBParameterCollection Params=new DBParameterCollection();
				Params.Add(Parameter.GetDBParameter("@tblName",view.TblName));
				Params.Add(Parameter.GetDBParameter("@fldName",view.FldName));
				Params.Add(Parameter.GetDBParameter("@pageSize",view.PageSize));
				Params.Add(Parameter.GetDBParameter("@page",view.Page));
				Params.Add(Parameter.GetDBParameter("@fldSort",view.FldSort));
				Params.Add(Parameter.GetDBParameter("@Sort",view.Sort));
				Params.Add(Parameter.GetDBParameter("@strCondition",view.StrCondition));
				Params.Add(Parameter.GetDBParameter("@ID",view.ID));
				Params.Add(Parameter.GetDBParameter("@Dist",view.Dist));
				Params.Add(Parameter.GetDBParameter("@pageCount",view.PageCount,ParameterDirection.Output));
				Params.Add(Parameter.GetDBParameter("@Counts",view.Counts,ParameterDirection.Output));

				
				DataSet ds = dbAccess.ExecuteDataset(cmdStr,CommandType.StoredProcedure,Params);
				
				view.PageCount = Convert.ToInt32(Params[Params.Count-2].Value);
				view.Counts = Convert.ToInt32(Params[Params.Count-1].Value);
				
				return ds;
			}
			catch(Exception ex)
			{
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.GetPageDataPagination",ex.Message);
				return null;
			}
			
		}
		/// <summary>
		/// ͨ����ʶ�� ����ȡ�û�������
		/// </summary>
		/// <returns></returns>
		public  static string getUserName(int UID)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrUser = "select UserName from xpGrid_User where UserID = @UserID";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@UserID",UID));
			
			try
			{
				string PersonCode = (string)dbAccess.ExecuteScalar(cmdStrUser,CommandType.Text,Params1);
				return PersonCode;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.getUserName",ex.ToString());		
				return null;
			}		
			
		}
		
		/// <summary>
		/// ��עԤ������Ϣ ����
		/// </summary>
		/// <param name="EarnestSigner">Ԥ�����ע��Ա</param>
		/// <param name="txtDateTo">Ԥ����ʱ��</param>
		/// <param name="PayForRemark">Ԥ���ע˵��</param>
		/// <returns></returns>
		public static int UadateAssetAdvanceRemarks(int Earnest, string EarnestSigner,string txtDateTo,string PayForRemark,int ID )
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrUser = "update dbo.Asset_FinallyPriceCheck_Body "+
				" set Earnest = @Earnest,EarnestSigner =@EarnestSigner ,EarnestDatetime = @EarnestDatetime,EarnestRemark = @EarnestRemark "+
				" where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@Earnest",Earnest));
			Params1.Add(Parameter.GetDBParameter("@EarnestSigner",EarnestSigner));
			Params1.Add(Parameter.GetDBParameter("@EarnestDatetime",txtDateTo));
			Params1.Add(Parameter.GetDBParameter("@EarnestRemark",PayForRemark));
			Params1.Add(Parameter.GetDBParameter("@Id",ID));
			
			try
			{
				return dbAccess.ExecuteNonQuery(cmdStrUser,CommandType.Text,Params1);
				 
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetAdvanceRemarks",ex.ToString());		
				return 0;
			}		
		}

		/// <summary>
		/// ������ע�޸� ��ע���� �ֿ�
		/// </summary>
		/// <param name="EarnestSigner">������ע��Ա </param>
		/// <param name="txtDateTo">ArriveDatetime ������עʱ��</param>
		/// <param name="ID">�۸�þ����ݱ���  id</param>
		/// <returns></returns>
		public static int UadateAssetArrivalRemarks(int IsArrived , string EarnestSigner,string txtDateTo,int ID)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrUser = "update dbo.Asset_FinallyPriceCheck_Body "+
				" set IsArrived = @IsArrived,ArriveSigner =@ArriveSigner ,ArriveDatetime = @ArriveDatetime "+
				" where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@IsArrived",IsArrived));
			Params1.Add(Parameter.GetDBParameter("@ArriveSigner",EarnestSigner));
			Params1.Add(Parameter.GetDBParameter("@ArriveDatetime",txtDateTo));
			Params1.Add(Parameter.GetDBParameter("@Id",ID));
			
			try
			{
				return dbAccess.ExecuteNonQuery(cmdStrUser,CommandType.Text,Params1);
				 
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetArrivalRemarks",ex.ToString());		
				return 0;
			}		
		}
		
		/// <summary>
		/// ���ע ��ע����  ����
		/// </summary>
		/// <param name="PayForSigner">�����ע��Ա</param>
		/// <param name="txtDateTo">PayForDatetime</param>
		/// <param name="PayForRemark">PayForRemark</param>
		/// <param name="ID">�۸�þ����ݱ���  id</param>
		/// <returns></returns>
		public static int UadateAssetPaymentRemarks(int IsPayFor,string PayForSigner,string txtDateTo,string PayForRemark,decimal ReallyPayMoney,int ID)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrUser = "update dbo.Asset_FinallyPriceCheck_Body "+
				" set IsPayFor = @IsPayFor,PayForSigner =@PayForSigner ,PayForDatetime = @PayForDatetime,PayForRemark =@PayForRemark ,ReallyPayMoney = @ReallyPayMoney"+
				" where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@IsPayFor",IsPayFor));
			Params1.Add(Parameter.GetDBParameter("@PayForSigner",PayForSigner));
			Params1.Add(Parameter.GetDBParameter("@PayForDatetime",txtDateTo));
			Params1.Add(Parameter.GetDBParameter("@PayForRemark",PayForRemark));
			Params1.Add(Parameter.GetDBParameter("@ReallyPayMoney",ReallyPayMoney));
			Params1.Add(Parameter.GetDBParameter("@Id",ID));
			
			try
			{
				return dbAccess.ExecuteNonQuery(cmdStrUser,CommandType.Text,Params1);
				 
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetPaymentRemarks",ex.ToString());		
				return 0;
			}		
		}

		/// <summary>
		/// ��ⱸע ��ע��� 
		/// </summary>
		/// <param name="InStoreSigner">����ע��Ա</param>
		/// <param name="InStoreDatetime">����עʱ��</param>
		/// <param name="ID">�۸�þ����ݱ���  id</param>
		/// <returns></returns>
		public static int UadateAssetStorageRemarks(int IsInStore,string InStoreSigner,string txtDateTo , int ID)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrUser =  "update dbo.Asset_FinallyPriceCheck_Body "+
				" set IsInStore = @IsInStore,InStoreSigner =@InStoreSigner ,InStoreDatetime = @InStoreDatetime "+
				" where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@IsInStore",IsInStore));
			Params1.Add(Parameter.GetDBParameter("@InStoreSigner",InStoreSigner));
			Params1.Add(Parameter.GetDBParameter("@InStoreDatetime",txtDateTo));
			Params1.Add(Parameter.GetDBParameter("@Id",ID));
			
			try
			{
				return dbAccess.ExecuteNonQuery(cmdStrUser,CommandType.Text,Params1);
				 
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks",ex.ToString());		
				return 0;
			}		
		}
		/// <summary>
		///  ͨ��ApplySheetHead_Pk �����ұ�ע����Ա����
		/// </summary>
		/// <param name="ApplySheetHead_Pk"></param>
		/// <returns></returns>
		public static string SelectNameByApplySheetHead_Pk(string ApplySheetHead_Pk)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrApplySheetHead_Pk = "select name from dbo.Base_Person where personCode = "
				+" (SELECT ApplyPersonCode FROM dbo.ApplySheetHead  where ApplySheetHead_Pk = @ApplySheetHead_Pk)";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@ApplySheetHead_Pk",ApplySheetHead_Pk));
			try
			{
				string NAME =Convert.ToString( dbAccess.ExecuteScalar(cmdStrApplySheetHead_Pk,CommandType.Text,Params1));
				 return NAME;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectNameByApplySheetHead_Pk",ex.ToString());		
				return null;
			}		
		}

		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ����� �������
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsArrivedByOS(int Rownum)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrIsArrived = "select IsArrived from dbo.Asset_FinallyPriceCheck_Body where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@Id",Rownum));
			try
			{
				int IsArrived =Convert.ToInt32( dbAccess.ExecuteScalar(cmdStrIsArrived,CommandType.Text,Params1));
				return IsArrived;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectIsArrivedByOS",ex.ToString());		
				return 0;
			}		
		}

		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ���� ���ܸ���
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsPayForByOS(int Rownum)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrIsInStore = "select IsInStore from dbo.Asset_FinallyPriceCheck_Body where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@Id",Rownum));
			try
			{
				int IsInStore =Convert.ToInt32( dbAccess.ExecuteScalar(cmdStrIsInStore,CommandType.Text,Params1));
				return IsInStore;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectIsPayForByOS",ex.ToString());		
				return 0;
			}		
		}
		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ����� �����������޸��Ƿ��Ѿ����
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectBycmdStrIsPayForP(int Rownum)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrIsPayForP = "select IsPayFor from dbo.Asset_FinallyPriceCheck_Body where Id = @Id";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@Id",Rownum));
			try
			{
				int IsPayForP =Convert.ToInt32( dbAccess.ExecuteScalar(cmdStrIsPayForP,CommandType.Text,Params1));
				return IsPayForP;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectIsPayForByOS",ex.ToString());		
				return 0;
			}		
		}
		
		/// <summary>
		///ͨ�� Asset_ApplySheet_Body_Id  ����ѯ��Ŀ������
		/// </summary>
		/// <returns></returns>
		public static string SelectAsset_ApplySheet_Body_Id(string Asset_ApplySheet_Body_Id)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrBody_Id = "select InventoryName from dbo.Asset_ApplySheet_Body where ID = @ID";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@ID",Convert.ToInt32(Asset_ApplySheet_Body_Id)));
			try
			{
				string InventoryName =Convert.ToString( dbAccess.ExecuteScalar(cmdStrBody_Id,CommandType.Text,Params1));
				return InventoryName;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectByInventoryName",ex.ToString());		
				return null;
			}		
		}

		/// <summary>
		///ͨ�� Asset_ApplySheet_Body_Id  ����ѯ�þ����
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectAsset_ApplySheet_Body_Table(string Asset_ApplySheet_Body_Id)
		{
			DBAccess dbAccess=new SQLAccess();
			string cmdStrBody_Id = "select Number,ExchangeRate,FinallyPrice from dbo.Asset_FinallyPriceCheck_Body   where ID =@ID";
			DBParameterCollection Params1=new DBParameterCollection();
			Params1.Add(Parameter.GetDBParameter("@ID",Convert.ToInt32(Asset_ApplySheet_Body_Id)));
			try
			{
				DataTable InventoryName =dbAccess.ExecuteDataset(cmdStrBody_Id,CommandType.Text,Params1).Tables[0];
				return InventoryName;
			}			
			catch(Exception ex)			
			{			
				Common.Log.Logger.Log("AssetAdvanceRemarksDAL.UadateAssetStorageRemarks.SelectByInventoryName",ex.ToString());		
				return null;
			}		
		}

	}
}
