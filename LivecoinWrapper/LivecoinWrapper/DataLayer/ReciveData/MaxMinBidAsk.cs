using Newtonsoft.Json;
using System.Collections.Generic;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class MaxBidMinAsk
    {
        [JsonProperty("currencyPairs")]
        public List<PairInfo> Currencies { get; set; }
    }

    public class PairInfo
    {
        [JsonProperty("symbol")]
        public string Symbol { get; private set; }
        
        private readonly decimal maxBid;
        public decimal MaxBid { get => maxBid; }
        
        private readonly decimal minAsk;
        public decimal MinAsk { get => minAsk; }

        [JsonConstructor]
        public PairInfo(string maxBid, string minAsk)
        {
            decimal.TryParse(maxBid, Any, InvariantCulture, out this.maxBid);
            decimal.TryParse(minAsk, Any, InvariantCulture, out this.minAsk);
        }
    }
}
