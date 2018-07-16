using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Restrictions
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("minBtcVolume")]
        private readonly string minBtcVolume;

        [JsonProperty("restrictions")]
        public List<Restriction> RestrictionList { get; set; }


        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal MinBtcVolume
        {
            get
            {
                return minBtcVolume != null ? (decimal)Convert.ToDouble(minBtcVolume.Replace(".", ",")) : -1;
            }
        }
    }

    public class Restriction
    {
        [JsonProperty("currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty("priceScale")]
        public byte PriceScale { get; set; }

        [JsonProperty("minLimitQuantity")]
        private readonly string minLimitQuantity;

        public decimal MinLimitQuantity
        {
            get
            {
                return minLimitQuantity != null ? (decimal)Convert.ToDouble(minLimitQuantity.Replace(".", ",")) : -1;
            }
        }
    }
}
