using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Restrictions
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "minBtcVolume")]
        private readonly string minBtcVolume;

        [JsonProperty(PropertyName = "restrictions")]
        public List<Restriction> RestrictionList { get; set; }


        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal MinBtcVolume
        {
            get
            {
                return (decimal)Convert.ToDouble(minBtcVolume.Replace(".", ","));
            }
        }
    }

    public class Restriction
    {
        [JsonProperty(PropertyName = "currencyPair")]
        public string CurrencyPair { get; set; }

        [JsonProperty(PropertyName = "priceScale")]
        public byte PriceScale { get; set; }

        [JsonProperty(PropertyName = "minLimitQuantity")]
        private readonly string minLimitQuantity;



        public decimal MinLimitQuantity
        {
            get
            {
                return (decimal)Convert.ToDouble(minLimitQuantity.Replace(".", ","));
            }
        }
    }
}
