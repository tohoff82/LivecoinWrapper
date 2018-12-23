using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Fee
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        private readonly decimal fee;
        public decimal CurrentFee { get => fee; }

        [JsonConstructor]
        public Fee(string fee)
        {
            decimal.TryParse(fee, Any, InvariantCulture, out this.fee);
        }
    }
}
