using System.Collections.Generic;

using static LivecoinWrapper.DataLayer.OrderType;
using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class TradeHistoryRequest : RequestObject
    {
        public TradeHistoryRequest(string pairId, bool minOrHour, string orderType) : base()
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currencyPair"]  = pairId,
                ["minutesOrHour"] = minOrHour.ToString()
            };

            if (orderType != _false) arguments.Add("type", orderType);

            GenerateRequest(exchange_GET, "last_trades");
        }
        public TradeHistoryRequest(string apiSec, string pairId, bool orderDesc, ushort limit, ushort offset) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["orderDesc"] = orderDesc.ToString(),
                ["offset"]    = offset.ToString(),
                ["limit"]     = limit.ToString()
            };

            if (pairId != null) arguments.Add("currencyPair", pairId);

            GenerateRequest(exchangeAuth_GET, "trades");
        }
    }
}
