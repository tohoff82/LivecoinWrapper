using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class FeeRequest : RequestObject
    {
        public FeeRequest(string apiSec, bool info) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>();

            if (info) GenerateRequest(exchangeAuth_GET, "commissionCommonInfo");
            else GenerateRequest(exchangeAuth_GET, "commission");
        }
    }
}
