using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;

namespace HDSZCheckFlow.UI.CheckFlow.CheckFlow
{
    /// <summary>
    /// AJAX 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    [System.Web.Script.Services.ScriptService]
    public class AJAX : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string GetUserNameByCode(string useCode)
        {
            try
            {
                Entiy.BasePerson person = Entiy.BasePerson.Find(useCode);
                if (person != null)
                {
                    return person.Name;
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                HDSZCheckFlow.Common.Log.Logger.Log("Ajax.GetUserNameByCode", ex.Message);
                return "";
            }
        }

        /// <summary>
        /// 价格裁决 保存表题
        /// </summary>
        /// <param name="FBId"></param>
        /// <param name="Value"></param>
        /// <param name="Flag"></param>

        [WebMethod]
        public void SaveFBodyInfo(string FBId, string Value, int Flag)
        {
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
                    case 13:

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
                    case 14:
                        FinallyCheckBody.Number = int.Parse(BValue.ToString());
                        break;
                    case 15:
                        FinallyCheckBody.FinallyPrice = BValue;
                        break;
                    case 16:
                        FinallyCheckBody.Offer = Value;
                        break;
                }
                FinallyCheckBody.Save();
            }
            catch (Exception ex)
            {
                HDSZCheckFlow.Common.Log.Logger.Log("UI.Asset.PriceCheck.AddPriceCheckApply_Setp2.SaveFBodyInfo", ex.Message);
            }
        }


    }
}
