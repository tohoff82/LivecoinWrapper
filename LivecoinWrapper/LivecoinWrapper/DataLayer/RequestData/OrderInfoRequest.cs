using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class OrderInfoRequest : RequestObject
    {
        public OrderInfoRequest(string apiSec, ulong orderId) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["orderId"] = orderId.ToString()
            };

            GenerateRequest(exchangeAuth_GET, "order");
        }
    }
}
