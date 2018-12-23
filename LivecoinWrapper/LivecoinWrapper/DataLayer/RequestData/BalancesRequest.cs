using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class BalancesRequest : RequestObject
    {
        public BalancesRequest(string apiSec, string currencyIds) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currency"] = currencyIds
            };

            GenerateRequest(exchangeAuth_GET, "balances");
        }
    }
}
