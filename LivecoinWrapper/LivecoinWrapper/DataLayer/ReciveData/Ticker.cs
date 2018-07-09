using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Ticker
    {
        [JsonProperty(PropertyName = "cur")]
        public string Currency { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string CurSymbol { get; set; }

        [JsonProperty(PropertyName = "last")]
        private readonly string lastPrice;

        [JsonProperty(PropertyName = "high")]
        private readonly string highPrice;

        [JsonProperty(PropertyName = "low")]
        private readonly string lowPrice;

        [JsonProperty(PropertyName = "volume")]
        private readonly string volume;

        [JsonProperty(PropertyName = "vwap")]
        private readonly string volumeWap;

        [JsonProperty(PropertyName = "max_bid")]
        private readonly string maximumBid;

        [JsonProperty(PropertyName = "min_ask")]
        private readonly string minimumAsk;

        [JsonProperty(PropertyName = "best_bid")]
        private readonly string bestBid;

        [JsonProperty(PropertyName = "best_ask")]
        private readonly string bestAsk;

        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal LastPrice
        {
            get
            {
                return (decimal)Convert.ToDouble(lastPrice.Replace(".", ","));
            }
        }
        
        public decimal HighPrice
        {
            get
            {
                return (decimal)Convert.ToDouble(highPrice.Replace(".", ","));
            }
        }

        public decimal LowPrice
        {
            get
            {
                return (decimal)Convert.ToDouble(lowPrice.Replace(".", ","));
            }
        }

        public decimal Volume
        {
            get
            {
                return (decimal)Convert.ToDouble(volume.Replace(".", ","));
            }
        }

        public decimal VolumeWap
        {
            get
            {
                return (decimal)Convert.ToDouble(volumeWap.Replace(".", ","));
            }
        }

        public decimal MaximumBid
        {
            get
            {
                return (decimal)Convert.ToDouble(maximumBid.Replace(".", ","));
            }
        }

        public decimal MinimumAsk
        {
            get
            {
                return (decimal)Convert.ToDouble(minimumAsk.Replace(".", ","));
            }
        }

        public decimal BestBid
        {
            get
            {
                return (decimal)Convert.ToDouble(bestBid.Replace(".", ","));
            }
        }

        public decimal BestAsk
        {
            get
            {
                return (decimal)Convert.ToDouble(bestAsk.Replace(".", ","));
            }
        }
    }
}
