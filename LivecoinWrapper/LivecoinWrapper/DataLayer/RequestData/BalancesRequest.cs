using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class BalancesRequest : RequestObject
    {
        public BalancesRequest(string apiSec, string pairIds) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currency"] = pairIds
            };

            GenerateRequest(exchangeAuth_GET, "balances");
        }
    }
}
