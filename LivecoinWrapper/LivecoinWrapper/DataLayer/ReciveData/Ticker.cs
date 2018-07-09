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
                if (lastPrice != null) return (decimal)Convert.ToDouble(lastPrice.Replace(".", ","));
                else return -1;
            }
        }
        
        public decimal HighPrice
        {
            get
            {
                if (highPrice != null) return (decimal)Convert.ToDouble(highPrice.Replace(".", ","));
                else return -1;
            }
        }

        public decimal LowPrice
        {
            get
            {
                if (lowPrice != null) return (decimal)Convert.ToDouble(lowPrice.Replace(".", ","));
                else return -1;
            }
        }

        public decimal Volume
        {
            get
            {
                if(volume != null) return (decimal)Convert.ToDouble(volume.Replace(".", ","));
                else return -1;
            }
        }

        public decimal VolumeWap
        {
            get
            {
                if(volumeWap != null) return (decimal)Convert.ToDouble(volumeWap.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MaximumBid
        {
            get
            {
                if(maximumBid != null) return (decimal)Convert.ToDouble(maximumBid.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MinimumAsk
        {
            get
            {
                if(minimumAsk != null) return (decimal)Convert.ToDouble(minimumAsk.Replace(".", ","));
                else return -1;
            }
        }

        public decimal BestBid
        {
            get
            {
                if(bestBid != null) return (decimal)Convert.ToDouble(bestBid.Replace(".", ","));
                else return -1;
            }
        }

        public decimal BestAsk
        {
            get
            {
                if(bestAsk != null) return (decimal)Convert.ToDouble(bestAsk.Replace(".", ","));
                else return -1;
            }
        }
    }
}
