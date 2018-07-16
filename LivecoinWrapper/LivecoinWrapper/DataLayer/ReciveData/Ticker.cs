using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Ticker
    {
        [JsonProperty("cur")]
        public string Currency { get; set; }

        [JsonProperty("symbol")]
        public string CurSymbol { get; set; }

        [JsonProperty("last")]
        private readonly string lastPrice;

        [JsonProperty("high")]
        private readonly string highPrice;

        [JsonProperty("low")]
        private readonly string lowPrice;

        [JsonProperty("volume")]
        private readonly string volume;

        [JsonProperty("vwap")]
        private readonly string volumeWap;

        [JsonProperty("max_bid")]
        private readonly string maximumBid;

        [JsonProperty("min_ask")]
        private readonly string minimumAsk;

        [JsonProperty("best_bid")]
        private readonly string bestBid;

        [JsonProperty("best_ask")]
        private readonly string bestAsk;

        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал
        //еслиприходит null в параметр помещается -1

        public decimal LastPrice
        {
            get
            {
                return lastPrice != null ? (decimal)Convert.ToDouble(lastPrice.Replace(".", ",")) : -1;
            }
        }
        
        public decimal HighPrice
        {
            get
            {
                return highPrice != null ? (decimal)Convert.ToDouble(highPrice.Replace(".", ",")) : -1;
            }
        }

        public decimal LowPrice
        {
            get
            {
                return lowPrice != null ? (decimal)Convert.ToDouble(lowPrice.Replace(".", ",")) : -1;
            }
        }

        public decimal Volume
        {
            get
            {
                return volume != null ? (decimal)Convert.ToDouble(volume.Replace(".", ",")) : -1;
            }
        }

        public decimal VolumeWap
        {
            get
            {
                return volumeWap != null ? (decimal)Convert.ToDouble(volumeWap.Replace(".", ",")) : -1;
            }
        }

        public decimal MaximumBid
        {
            get
            {
                return maximumBid != null ? (decimal)Convert.ToDouble(maximumBid.Replace(".", ",")) : -1;
            }
        }

        public decimal MinimumAsk
        {
            get
            {
                return minimumAsk != null ? (decimal)Convert.ToDouble(minimumAsk.Replace(".", ",")) : -1;
            }
        }

        public decimal BestBid
        {
            get
            {
                return bestBid != null ? (decimal)Convert.ToDouble(bestBid.Replace(".", ",")) : -1;
            }
        }

        public decimal BestAsk
        {
            get
            {
                return bestAsk != null ? (decimal)Convert.ToDouble(bestAsk.Replace(".", ",")) : -1;
            }
        }
    }
}
