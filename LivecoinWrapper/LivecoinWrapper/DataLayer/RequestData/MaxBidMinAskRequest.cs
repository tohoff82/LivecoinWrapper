using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class MaxBidMinAskRequest : RequestObject
    {
        public MaxBidMinAskRequest(string pairId) : base()
        {
            arguments = new SortedDictionary<string, string>();

            if (pairId != null) arguments.Add("currencyPair", pairId);

            GenerateRequest(exchangeGET, "maxbid_minask");
        }
    }
}
