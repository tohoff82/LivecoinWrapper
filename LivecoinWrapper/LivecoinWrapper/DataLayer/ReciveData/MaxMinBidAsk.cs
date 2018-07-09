using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class MaxMinBidAsk
    {
        [JsonProperty(PropertyName = "currencyPairs")]
        public List<CurrencyPairs> Currencies { get; set; }
    }

    public class CurrencyPairs
    {
        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "maxBid")]
        private readonly string maxBid;

        [JsonProperty(PropertyName = "minAsk")]
        private readonly string minAsk;


        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal MaxBid
        {
            get
            {
                if (maxBid != null) return (decimal)Convert.ToDouble(maxBid.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MinAsk
        {
            get
            {
                if (minAsk != null) return (decimal)Convert.ToDouble(minAsk.Replace(".", ","));
                else return -1;
            }
        }
    }
}
