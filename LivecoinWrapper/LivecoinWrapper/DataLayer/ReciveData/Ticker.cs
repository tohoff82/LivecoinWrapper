using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Ticker
    {
        [JsonProperty(PropertyName = "last")]
        public decimal LastPrice { get; set; }

        [JsonProperty(PropertyName = "high")]
        public decimal HighPrice { get; set; }

        [JsonProperty(PropertyName = "low")]
        public decimal LowPrice { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public decimal Volume { get; set; }

        [JsonProperty(PropertyName = "vwap")]
        public decimal VolumeWap { get; set; }

        [JsonProperty(PropertyName = "max_bid")]
        public decimal MaximumBid { get; set; }

        [JsonProperty(PropertyName = "min_ask")]
        public decimal MinimumAsk { get; set; }

        [JsonProperty(PropertyName = "best_bid")]
        public decimal BestBid { get; set; }

        [JsonProperty(PropertyName = "best_ask")]
        public decimal BestAsk { get; set; }
    }
}
