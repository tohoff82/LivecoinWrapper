using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class TransactionsRequest : RequestObject
    {
        public TransactionsRequest(string apiSec, ulong startTime, ulong endTime, string transType, ushort resLimit, ushort offset):base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["start"]  = startTime.ToString(),
                ["end"]    = endTime.ToString(),
                ["limit"]  = resLimit.ToString(),
                ["offset"] = offset.ToString()
            };

            if (transType != "all") arguments.Add("types", transType);

            GenerateRequest(payment_GET, "history/transactions");
        }
    }
}
