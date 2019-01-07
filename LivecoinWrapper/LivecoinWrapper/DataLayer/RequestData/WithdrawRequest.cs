using System.Collections.Generic;
using System.Text;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class WithdrawRequest : RequestObject
    {
        public WithdrawRequest(string apiSec, string currencyId, decimal amount, string address, string memo) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currency"] = currencyId,
                ["amount"]   = amount.ToString(),
                ["wallet"]   = memo == null ? address : new StringBuilder(address).AppendFormat("{0}::{1}", address, memo).ToString()
            };

            GenerateRequest(payment_POST, "out/coin");
        }
    }
}
