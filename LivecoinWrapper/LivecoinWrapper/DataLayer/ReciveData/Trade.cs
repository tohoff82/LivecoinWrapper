using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Trade
    {
        [JsonProperty(PropertyName = "time")]
        public ulong Time { get; set; }

        [JsonProperty(PropertyName = "id")]
        public ulong Id { get; set; }

        [JsonProperty(PropertyName = "price")]
        private readonly string price;

        [JsonProperty(PropertyName = "quantity")]
        private readonly string quantity;

        [JsonProperty(PropertyName = "type")]
        public string OrderType { get; set; }

       
        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal Price
        {
            get
            {
                if(price != null) return (decimal)Convert.ToDouble(price.Replace(".",","));
                else return -1;
            }
        }

        public decimal Quantity
        {
            get
            {
                if(quantity != null) return (decimal)Convert.ToDouble(quantity.Replace(".", ","));
                else return -1;
            }
        }
    }
}
