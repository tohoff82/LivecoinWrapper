using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class VoucherMakeRequest : RequestObject
    {
        public VoucherMakeRequest(string apiSec, decimal amount, string currId, string description = null, string forUser = null) : base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["amount"] = amount.ToString(culture),
                ["currency"] = currId,
                ["description"] = description
            };

            if (forUser != null) arguments["forUser"] = forUser;

            GenerateRequest(payment_POST, "voucher/make");
        }
    }
}
