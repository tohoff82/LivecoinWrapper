using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class FeeRequest : RequestObject
    {
        public FeeRequest(string apiSec) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>();

            GenerateRequest(exchangeAuth_GET, "commission");
        }
    }
}
