using System;
using System.Data;
using System.Web.UI.WebControls;
using entiy=HDSZCheckFlow.Entiy;
using HDSZCheckFlow.DataAccess.FixedAssets;
namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetAdvanceRemarksBLL 的摘要说明。
	/// </summary>
	public class AssetAdvanceRemarksBLL
	{
		public AssetAdvanceRemarksBLL()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 查询所有的工程所涵盖的有预付款的内容 
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectFinallyPriceOrBody()
		{
			return  AssetAdvanceRemarksDAL.SelectFinallyPriceOrBody();
		}

		/// <summary>
		/// 查询所有预算报表部门 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetPageDataPagination( entiy.PageViewState view)
		{
			return  AssetAdvanceRemarksDAL.GetPageDataPagination(view);
		}


		/// <summary>
		/// 通过标识列 来获取用户的名称
		/// </summary>
		/// <returns></returns>
		public static string getUserName(int UID)
		{
				return  AssetAdvanceRemarksDAL.getUserName(UID);
		}

		/// <summary>
		/// 标注预付款信息
		/// </summary>
		/// <param name="EarnestSigner"></param>
		/// <param name="txtDateTo"></param>
		/// <param name="PayForRemark"></param>
		/// <returns></returns>
		public static int UadateAssetAdvanceRemarks(int Earnest,string EarnestSigner,string txtDateTo,string PayForRemark ,int ID)
		{
			return AssetAdvanceRemarksDAL.UadateAssetAdvanceRemarks( Earnest,EarnestSigner, txtDateTo, PayForRemark,ID);
		}


		/// <summary>
		/// 到货备注修改 标注到货
		/// </summary>
		/// <param name="EarnestSigner">到货标注人员 </param>
		/// <param name="txtDateTo">ArriveDatetime 到货标注时间</param>
		/// <param name="ID">价格裁决单据表体  id</param>
		/// <returns></returns>
		public static int UadateAssetArrivalRemarks(int IsArrived ,string EarnestSigner,string txtDateTo,int ID)
		{
			return AssetAdvanceRemarksDAL.UadateAssetArrivalRemarks(IsArrived,EarnestSigner,txtDateTo,ID);
		}

		/// <summary>
		/// 付款备注 标注付款  财务
		/// </summary>
		/// <param name="PayForSigner">付款标注人员</param>
		/// <param name="txtDateTo">PayForDatetime</param>
		/// <param name="PayForRemark">PayForRemark</param>
		/// <param name="ID">价格裁决单据表体  id</param>
		/// <returns></returns>
		public static int UadateAssetPaymentRemarks(int IsPayFor,string PayForSigner,string txtDateTo,string PayForRemark,decimal ReallyPayMoney,int ID)
		{
			return AssetAdvanceRemarksDAL.UadateAssetPaymentRemarks(IsPayFor,PayForSigner,txtDateTo,PayForRemark,ReallyPayMoney,ID);
		}

		
		/// <summary>
		/// 入库备注 标注入库 
		/// </summary>
		/// <param name="InStoreSigner">入库标注人员</param>
		/// <param name="InStoreDatetime">入库标注时间</param>
		/// <param name="ID">价格裁决单据表体  id</param>
		/// <returns></returns>
		public static int UadateAssetStorageRemarks(int IsInStore,string InStoreSigner,string txtDateTo , int ID)
		{
			return AssetAdvanceRemarksDAL.UadateAssetStorageRemarks(IsInStore,InStoreSigner,txtDateTo , ID);
		}

		/// <summary>
		///  通过ApplySheetHead_Pk 来查找标注的人员姓名
		/// </summary>
		/// <param name="ApplySheetHead_Pk"></param>
		/// <returns></returns>
		public static string SelectNameByApplySheetHead_Pk(string ApplySheetHead_Pk)
		{
			return AssetAdvanceRemarksDAL.SelectNameByApplySheetHead_Pk(ApplySheetHead_Pk);
		}

		/// <summary>
		/// 通过主键ID 来查询是否已经验收  才能入库
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsArrivedByOS(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectIsArrivedByOS(Rownum);
		}

		
		/// <summary>
		/// 通过主键ID 来查询是否已经入库 才能付款
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsPayForByOS(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectIsPayForByOS(Rownum);
		}


		/// <summary>
		/// 通过主键ID 来查询是否已经付款 付款了则不能修改是否已经入库
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectBycmdStrIsPayForP(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectBycmdStrIsPayForP(Rownum);
		}

		/// <summary>
		///通过 Asset_ApplySheet_Body_Id  来查询项目的名称
		/// </summary>
		/// <returns></returns>
		public static string SelectAsset_ApplySheet_Body_Id(string Asset_ApplySheet_Body_Id)
		{
			return AssetAdvanceRemarksDAL.SelectAsset_ApplySheet_Body_Id(Asset_ApplySheet_Body_Id);
		}

		/// <summary>
		///通过 Asset_ApplySheet_Body_Id  来查询裁决金额
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectAsset_ApplySheet_Body_Table(string Asset_ApplySheet_Body_Id)
		{
			return AssetAdvanceRemarksDAL.SelectAsset_ApplySheet_Body_Table(Asset_ApplySheet_Body_Id);
		}
	}
}
