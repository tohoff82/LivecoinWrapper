using System;
using System.Collections.Generic;
using System.Text;
using static LivecoinWrapper.Helper.Enums.RequestType;
using static LivecoinWrapper.DataLayer.MarketPair;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class TickerRequest : RequestObject
    {
        public TickerRequest(string pairId): base()
        {
            if (pairId != allPair)
                arguments = new Dictionary<string, string>
                {
                    ["currencyPair"] = pairId
                };
            else arguments = new Dictionary<string, string>();

            GenerateRequest(exchange, "ticker");
        }
    }
}
