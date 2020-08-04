using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace HDSZCheckFlow.UI.Asset.PriceCheck
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class AddPriceCheckApply_Setp21 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            //获取请求的参数
            string FBId = context.Request.Params["FBId"];
            string Value = context.Request.Params["Value"];
            int Flag = int.Parse(context.Request.Params["Flag"]);


            try
            {
                //三个参数意义 
                //FBId：价格裁决表体ID.Value：修改后的值.Flag：标记修改的字段（目前有4个  12 代表币种 13代表数量 14代表价格 15代表供应商）
                int BId = int.Parse(FBId);
                decimal BValue = 0;
                int BFlag = 0;
                if (Common.Util.CommonUtil.IsNumeric(Value))
                {
                    BValue = decimal.Parse(Value);
                }
                BFlag = Flag;
                Entiy.AssetFinallyPriceCheckBody FinallyCheckBody = Entiy.AssetFinallyPriceCheckBody.Find(BId);
                switch (BFlag)
                {
                    case 12:

                        //记录裁决币种
                        FinallyCheckBody.CurrTypeCode = Value;
                        //记录币种的基准利率
                        //Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.FindByYearAndMonth(Value,DateTime.Today.Year,1);

                        Entiy.BasecurrencyType CurrType = Entiy.BasecurrencyType.Find(Value);

                        if (CurrType != null)
                        {
                            FinallyCheckBody.ExchangeRate = CurrType.ExchangeRate;
                        }

                        break;
                    case 13:
                        FinallyCheckBody.Number = int.Parse(BValue.ToString());
                        break;
                    case 14:
                        FinallyCheckBody.FinallyPrice = BValue;
                        break;
                    case 15:
                        FinallyCheckBody.Offer = Value;
                        break;
                }
                FinallyCheckBody.Save();
            }
            catch (Exception ex)
            {
                HDSZCheckFlow.Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2.SaveFBodyInfo", ex.Message);
            }
            
            
            
            
            //context.Response.Write("Hello World");

            //context.Response.Write(result);
            //context.Response.End();







        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
