using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class FeeInfo
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        public Dictionary<string, decimal> Info { get; private set; } = new Dictionary<string, decimal>();

        private readonly decimal fee;
        private readonly decimal last30DaysAmountAsUSD;

        [JsonConstructor]
        public FeeInfo(string fee, string commission, string last30DaysAmountAsUSD)
        {
            if (fee != null)
            {
                decimal.TryParse(fee, Any, InvariantCulture, out this.fee);
                Info.Add("Fee", this.fee);
            }
            else
            {
                decimal.TryParse(commission,            Any, InvariantCulture, out this.fee);
                decimal.TryParse(last30DaysAmountAsUSD, Any, InvariantCulture, out this.last30DaysAmountAsUSD);
                Info.Add("Fee", this.fee);
                Info.Add("MonthlyUSDVolume", this.last30DaysAmountAsUSD);
            }
        }
    }
}
