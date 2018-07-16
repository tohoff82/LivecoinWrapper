using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class PrivateTrade
    {
        [JsonProperty("time")]
        public ulong Time { get; set; }

        [JsonProperty("id")]
        public ulong Id { get; set; }

        [JsonProperty("type")]
        public string OrderType;

        [JsonProperty("symbol")]
        public string MarketPair;

        [JsonProperty("price")]
        private readonly string price;

        [JsonProperty("quantity")]
        private readonly string quantity;

        [JsonProperty("commission")]
        private readonly string commission;

        [JsonProperty("clientorderid")]
        public ulong ClientOrderId;


        //Сделал эти костыли по причине того, что иногда в ответе цена равна нулл или представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public decimal Price
        {
            get
            {
                return price != null ? (decimal)Convert.ToDouble(price.Replace(".", ",")) : -1;
            }
        }

        public decimal Quantity
        {
            get
            {
                return quantity != null ? (decimal)Convert.ToDouble(quantity.Replace(".", ",")) : -1;
            }
        }

        public decimal Commission
        {
            get
            {
                return quantity != null ? (decimal)Convert.ToDouble(commission.Replace(".", ",")) : -1;
            }
        }
    }
}
