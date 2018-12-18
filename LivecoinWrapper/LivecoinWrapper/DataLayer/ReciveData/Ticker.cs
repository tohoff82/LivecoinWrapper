using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Ticker
    {
        [JsonProperty("cur")]
        public string Currency { get; private set; }

        [JsonProperty("symbol")]
        public string CurSymbol { get; private set; }
        
        private readonly decimal last;
        public decimal LastPrice { get => last; }
        
        private readonly decimal high;
        public decimal High24Price { get => high; }

        private readonly decimal low;
        public decimal Low24Price { get => low; }

        private readonly decimal volume;
        public decimal Volume24 { get => volume; }

        private readonly decimal vwap;
        public decimal VolumeWap { get => vwap; }

        private readonly decimal max_bid;
        public decimal Max24Bid { get => max_bid; }

        private readonly decimal min_ask;
        public decimal Min24Ask { get => min_ask; }

        private readonly decimal best_bid;
        public decimal Best24Bid { get => best_bid; }

        private readonly decimal best_ask;
        public decimal Best24Ask { get => best_ask; }

        [JsonConstructor]
        public Ticker(string last,    string high,    string low,      string volume, string vwap, 
                      string max_bid, string min_ask, string best_bid, string best_ask)
        {
            decimal.TryParse(last, Any, InvariantCulture, out this.last);
            decimal.TryParse(high, Any, InvariantCulture, out this.high);
            decimal.TryParse(low, Any, InvariantCulture, out this.low);
            decimal.TryParse(volume, Any, InvariantCulture, out this.volume);
            decimal.TryParse(vwap, Any, InvariantCulture, out this.vwap);
            decimal.TryParse(max_bid, Any, InvariantCulture, out this.max_bid);
            decimal.TryParse(min_ask, Any, InvariantCulture, out this.min_ask);
            decimal.TryParse(best_bid, Any, InvariantCulture, out this.best_bid);
            decimal.TryParse(best_ask, Any, InvariantCulture, out this.best_ask);
        }
    }
}
