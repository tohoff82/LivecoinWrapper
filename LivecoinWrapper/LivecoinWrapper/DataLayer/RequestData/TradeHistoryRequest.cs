using System.Collections.Generic;

using static LivecoinWrapper.DataLayer.OrderType;
using static LivecoinWrapper.Helper.Enums.RequestType;


namespace LivecoinWrapper.DataLayer.RequestData
{
    public class TradeHistoryRequest : RequestObject
    {
        public TradeHistoryRequest(string pairId, bool minOrHour, string orderType) : base()
        {
            arguments = new Dictionary<string, string>
            {
                ["currencyPair"]  = pairId,
                ["minutesOrHour"] = minOrHour.ToString()
            };

            if (orderType != defoult) arguments.Add("type", orderType);

            GenerateRequest(exchange, "last_trades");
        }
    }
}
