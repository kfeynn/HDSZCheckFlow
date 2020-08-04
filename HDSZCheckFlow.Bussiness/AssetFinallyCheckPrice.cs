using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetFinallyCheckPrice ��ժҪ˵����
	/// </summary>
	public class AssetFinallyCheckPrice
	{
		public AssetFinallyCheckPrice(){}
		/// <summary>
		/// ����þ����Ƿ��д�
		/// </summary>
		/// <param name="FinallyApplyKey">�۸�þ���ͷId</param>
		/// <returns>1���� 2 �۸񳬳� 3 �������� 4 ����</returns>
		public static int CheckFinallyApplyAndBody(int FinallyApplyKey)
		{
			int Flag = 1 ; 

			try
			{
				//�۸�þ���ͷ
				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyApplyKey);
				//�۸�þ�����
				Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheck.Id);

				if(FinallyCheckBodys!=null && FinallyCheckBodys.Length > 0 )
				{
					//ѭ������䵥���Ƿ񳬹����뵥
					foreach(Entiy.AssetFinallyPriceCheckBody FinallyCheckBody in FinallyCheckBodys)
					{
						Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(FinallyCheckBody.AssetApplySheetBodyId );
						if(FinallyCheckBody.FinallyPrice * FinallyCheckBody.ExchangeRate  > AssetBody.OriginalcurrPrice * AssetBody.ExchangeRate)
						{
							//rmb�۸񳬳����鿴���ҵ��� �Ƿ񳬳�   ... 
							if(FinallyCheckBody.CurrTypeCode == AssetBody.CurrTypeCode)    //ͬ������Ƚ�ԭ�ҵ���
							{
								if(FinallyCheckBody.FinallyPrice   > AssetBody.OriginalcurrPrice )
								{
									Flag = 2 ;
								}
							}
							else    //��ͬ���֣����϶�rmb���۱ȶ�
							{
								Flag = 2 ;
							}
						}
						int NowCheckNumber = FinallyCheckBody.Number + AssetBody.CheckNumber;
						if(NowCheckNumber > AssetBody.Number )
						{
							Flag = 3 ;
						}
					}
				}
			}
			catch
			{
				Flag = 4 ;
			}


			return Flag;

		}



	}
}
