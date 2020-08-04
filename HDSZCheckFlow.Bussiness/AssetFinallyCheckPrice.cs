using System;
using System.Data;

namespace HDSZCheckFlow.Bussiness
{
	/// <summary>
	/// AssetFinallyCheckPrice 的摘要说明。
	/// </summary>
	public class AssetFinallyCheckPrice
	{
		public AssetFinallyCheckPrice(){}
		/// <summary>
		/// 检验裁决表是否有错
		/// </summary>
		/// <param name="FinallyApplyKey">价格裁决表头Id</param>
		/// <returns>1正常 2 价格超出 3 数量超出 4 出错</returns>
		public static int CheckFinallyApplyAndBody(int FinallyApplyKey)
		{
			int Flag = 1 ; 

			try
			{
				//价格裁决表头
				Entiy.AssetFinallyPriceCheck FinallyCheck = Entiy.AssetFinallyPriceCheck.Find(FinallyApplyKey);
				//价格裁决表体
				Entiy.AssetFinallyPriceCheckBody[] FinallyCheckBodys = Entiy.AssetFinallyPriceCheckBody.FindByCheckApplyHeadKey(FinallyCheck.Id);

				if(FinallyCheckBodys!=null && FinallyCheckBodys.Length > 0 )
				{
					//循环检查其单价是否超过申请单
					foreach(Entiy.AssetFinallyPriceCheckBody FinallyCheckBody in FinallyCheckBodys)
					{
						Entiy.AssetApplySheetBody AssetBody = Entiy.AssetApplySheetBody.Find(FinallyCheckBody.AssetApplySheetBodyId );
						if(FinallyCheckBody.FinallyPrice * FinallyCheckBody.ExchangeRate  > AssetBody.OriginalcurrPrice * AssetBody.ExchangeRate)
						{
							//rmb价格超出。查看本币单价 是否超出   ... 
							if(FinallyCheckBody.CurrTypeCode == AssetBody.CurrTypeCode)    //同币种则比较原币单价
							{
								if(FinallyCheckBody.FinallyPrice   > AssetBody.OriginalcurrPrice )
								{
									Flag = 2 ;
								}
							}
							else    //不同币种，则认定rmb单价比对
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
