using System.Collections.Generic;

using static LivecoinWrapper.DataLayer.ServiceTypes;
using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class PlaceOrderRequest : RequestObject
    {
        public PlaceOrderRequest(string apiSec, string type, string pairId, decimal quantity, decimal? price) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currencyPair"] = pairId,
                ["quantity"]     = quantity.ToString()
            };

            if (type == _limit_buy)  Generate(price, "buylimit");
            if (type == _limit_sell) Generate(price, "selllimit");

            if (type == _market_buy)  Generate(price, "buymarket");
            if (type == _market_sell) Generate(price, "sellmarket");
        }

        private void Generate(decimal? price, string apiMethod)
        {
            if(price != null) arguments.Add("price", price.ToString());
            GenerateRequest(exchangeAuth_POST, apiMethod);
        }
    }
}
