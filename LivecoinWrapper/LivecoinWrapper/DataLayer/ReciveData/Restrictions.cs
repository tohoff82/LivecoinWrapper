using Newtonsoft.Json;
using System.Collections.Generic;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Restrictions
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        private readonly decimal minBtcVolume;
        public decimal MinBtcVolume { get => minBtcVolume; }

        [JsonProperty("restrictions")]
        public List<Restriction> RestrictionList { get; private set; }

        [JsonConstructor]
        public Restrictions(string minBtcVolume)
        {
            decimal.TryParse(minBtcVolume, Any, InvariantCulture, out this.minBtcVolume);
        }
    }

    public class Restriction
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; private set; }

        [JsonProperty("priceScale")]
        public byte PriceScale { get; private set; }
        
        private readonly decimal minLimitQuantity;
        public decimal MinLimitQuantity { get => minLimitQuantity; }

        [JsonConstructor]
        public Restriction(string minLimitQuantity)
        {
            decimal.TryParse(minLimitQuantity, Any, InvariantCulture, out this.minLimitQuantity);
        }
    }
}
