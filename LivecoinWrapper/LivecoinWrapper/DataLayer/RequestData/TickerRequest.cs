using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;
using static LivecoinWrapper.DataLayer.MarketPair;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class TickerRequest : RequestObject
    {
        public TickerRequest(string pairId): base()
        {
            arguments = new Dictionary<string, string>();

            if (pairId != allPair) arguments.Add("currencyPair", pairId);

            GenerateRequest(exchange, "ticker");
        }
    }
}
