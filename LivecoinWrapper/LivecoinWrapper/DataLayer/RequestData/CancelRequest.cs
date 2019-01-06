using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class CancelRequest : RequestObject
    {
        public CancelRequest(string apiSec, string pairId, ulong orderId) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currencyPair"] = pairId,
                ["orderId"] = orderId.ToString()
            };

            GenerateRequest(exchangeAuth_GET, "cancellimit");
        }
    }
}
