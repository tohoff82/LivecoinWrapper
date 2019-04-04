using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class VoucherAmountRequest : RequestObject
    {
        public VoucherAmountRequest(string apiSec, string voucherCode, bool isRedeem):base(apiSec)
        {
            arguments = new SortedDictionary<string, string>
            {
                ["voucher_code"] = voucherCode
            };

            if (isRedeem) GenerateRequest(payment_POST, "voucher/redeem");
            else GenerateRequest(payment_POST, "voucher/amount");
        }
    }
}
