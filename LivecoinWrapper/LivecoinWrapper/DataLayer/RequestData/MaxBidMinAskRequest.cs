using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class MaxBidMinAskRequest : RequestObject
    {
        public MaxBidMinAskRequest(string pairId) : base()
        {
            arguments = new Dictionary<string, string>();

            if (pairId != null) arguments.Add("currencyPair", pairId);

            GenerateRequest(exchange, "maxbid_minask");
        }
    }
}
