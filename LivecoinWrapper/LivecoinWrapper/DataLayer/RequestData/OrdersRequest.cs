using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class OrdersRequest : RequestObject
    {
        public OrdersRequest(string apiSec,   string pairId, string orderStatus, ulong? issuedFrom,
                             ulong? issuedTo, uint startRow, uint endRow) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["openClosed"] = orderStatus,
                ["startRow"]   = startRow.ToString(),
                ["endRow"]     = endRow.ToString()
            };

            if (pairId != null)     arguments.Add("currencyPair", pairId);
            if (issuedFrom != null) arguments.Add("issuedFrom", issuedFrom.ToString());
            if (issuedTo != null)   arguments.Add("issuedTo", issuedTo.ToString());

            GenerateRequest(exchangeAuthGET, "client_orders");
        }
    }
}
