using System;
using System.Data;
using System.Web.UI.WebControls;
using entiy=HDSZCheckFlow.Entiy;
using HDSZCheckFlow.DataAccess.FixedAssets;
namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetAdvanceRemarksBLL ��ժҪ˵����
	/// </summary>
	public class AssetAdvanceRemarksBLL
	{
		public AssetAdvanceRemarksBLL()
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
			return  AssetAdvanceRemarksDAL.SelectFinallyPriceOrBody();
		}

		/// <summary>
		/// ��ѯ����Ԥ�㱨���� 
		/// </summary>
		/// <returns></returns>
		public static DataSet GetPageDataPagination( entiy.PageViewState view)
		{
			return  AssetAdvanceRemarksDAL.GetPageDataPagination(view);
		}


		/// <summary>
		/// ͨ����ʶ�� ����ȡ�û�������
		/// </summary>
		/// <returns></returns>
		public static string getUserName(int UID)
		{
				return  AssetAdvanceRemarksDAL.getUserName(UID);
		}

		/// <summary>
		/// ��עԤ������Ϣ
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
		/// ������ע�޸� ��ע����
		/// </summary>
		/// <param name="EarnestSigner">������ע��Ա </param>
		/// <param name="txtDateTo">ArriveDatetime ������עʱ��</param>
		/// <param name="ID">�۸�þ����ݱ���  id</param>
		/// <returns></returns>
		public static int UadateAssetArrivalRemarks(int IsArrived ,string EarnestSigner,string txtDateTo,int ID)
		{
			return AssetAdvanceRemarksDAL.UadateAssetArrivalRemarks(IsArrived,EarnestSigner,txtDateTo,ID);
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
			return AssetAdvanceRemarksDAL.UadateAssetPaymentRemarks(IsPayFor,PayForSigner,txtDateTo,PayForRemark,ReallyPayMoney,ID);
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
			return AssetAdvanceRemarksDAL.UadateAssetStorageRemarks(IsInStore,InStoreSigner,txtDateTo , ID);
		}

		/// <summary>
		///  ͨ��ApplySheetHead_Pk �����ұ�ע����Ա����
		/// </summary>
		/// <param name="ApplySheetHead_Pk"></param>
		/// <returns></returns>
		public static string SelectNameByApplySheetHead_Pk(string ApplySheetHead_Pk)
		{
			return AssetAdvanceRemarksDAL.SelectNameByApplySheetHead_Pk(ApplySheetHead_Pk);
		}

		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ�����  �������
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsArrivedByOS(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectIsArrivedByOS(Rownum);
		}

		
		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ���� ���ܸ���
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectIsPayForByOS(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectIsPayForByOS(Rownum);
		}


		/// <summary>
		/// ͨ������ID ����ѯ�Ƿ��Ѿ����� �����������޸��Ƿ��Ѿ����
		/// </summary>
		/// <param name="Rownum"></param>
		/// <returns></returns>
		public static int SelectBycmdStrIsPayForP(int Rownum)
		{
			return AssetAdvanceRemarksDAL.SelectBycmdStrIsPayForP(Rownum);
		}

		/// <summary>
		///ͨ�� Asset_ApplySheet_Body_Id  ����ѯ��Ŀ������
		/// </summary>
		/// <returns></returns>
		public static string SelectAsset_ApplySheet_Body_Id(string Asset_ApplySheet_Body_Id)
		{
			return AssetAdvanceRemarksDAL.SelectAsset_ApplySheet_Body_Id(Asset_ApplySheet_Body_Id);
		}

		/// <summary>
		///ͨ�� Asset_ApplySheet_Body_Id  ����ѯ�þ����
		/// </summary>
		/// <returns></returns>
		public static DataTable SelectAsset_ApplySheet_Body_Table(string Asset_ApplySheet_Body_Id)
		{
			return AssetAdvanceRemarksDAL.SelectAsset_ApplySheet_Body_Table(Asset_ApplySheet_Body_Id);
		}
	}
}
