using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class WalletAddressRequest : RequestObject
    {
        public WalletAddressRequest(string apiSec, string currencyId) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currency"] = currencyId
            };

            GenerateRequest(payment_GET, "get/address");
        }
    }
}
