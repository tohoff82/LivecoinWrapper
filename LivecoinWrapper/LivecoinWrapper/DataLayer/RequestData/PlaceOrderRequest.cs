using System.Collections.Generic;

using static LivecoinWrapper.DataLayer.OrderType;
using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class PlaceOrderRequest : RequestObject
    {
        public PlaceOrderRequest(string apiSec, string type, string pairId, decimal quantity, decimal price) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currencyPair"] = pairId,
                ["quantity"]     = quantity.ToString()
            };

            if (type == _limit_buy)
            {
                arguments.Add("price", price.ToString());
                GenerateRequest(exchangeAuth_POST, "buylimit");
            }

            if (type == _limit_sell)
            {
                arguments.Add("price", price.ToString());
                GenerateRequest(exchangeAuth_POST, "selllimit");
            }

            if (type == _market_buy)  GenerateRequest(exchangeAuth_POST, "buymarket");
            if (type == _market_sell) GenerateRequest(exchangeAuth_POST, "sellmarket");
        }
    }
}
