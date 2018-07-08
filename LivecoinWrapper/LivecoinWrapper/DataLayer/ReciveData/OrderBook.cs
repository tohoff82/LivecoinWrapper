using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    class OrderBook
    {
        [JsonProperty(PropertyName = "timestamp")]
        public int Timestamp { get; set; }

        [JsonProperty(PropertyName = "asks")]
        public List<List<decimal>> Asks { get; set; }

        [JsonProperty(PropertyName = "bids")]
        public List<List<decimal>> Bids { get; set; }

    }
}
