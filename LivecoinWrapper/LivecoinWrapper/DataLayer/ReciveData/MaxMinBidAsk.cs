using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class MaxMinBidAsk
    {
        [JsonProperty("currencyPairs")]
        public List<CurrencyPairs> Currencies { get; set; }
    }

    public class CurrencyPairs
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("maxBid")]
        private readonly string maxBid;

        [JsonProperty("minAsk")]
        private readonly string minAsk;


        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal MaxBid
        {
            get
            {
                return  maxBid != null ? (decimal)Convert.ToDouble(maxBid.Replace(".", ",")) : -1;
            }
        }

        public decimal MinAsk
        {
            get
            {
                return minAsk != null ? (decimal)Convert.ToDouble(minAsk.Replace(".", ",")) : -1;
            }
        }
    }
}
