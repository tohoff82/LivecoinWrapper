using Newtonsoft.Json;

using static LivecoinWrapper.Helper.Enums;
using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Balance
    {
        [JsonProperty("type")]
        public string BalanceType { get; private set; }

        [JsonProperty("currency")]
        public string CurrencyId { get; private set; }

        private readonly decimal value;
        public decimal Value { get => value; }

        [JsonConstructor]
        public Balance(string value)
        {
            decimal.TryParse(value, Any, InvariantCulture, out this.value);
        }
    }
}
