using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class VoucherAmountRequest : RequestObject
    {
        public VoucherAmountRequest(string apiSec, string voucherCode):base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["voucher_code"] = voucherCode
            };

            GenerateRequest(payment_POST, "voucher/amount");
        }
    }
}
