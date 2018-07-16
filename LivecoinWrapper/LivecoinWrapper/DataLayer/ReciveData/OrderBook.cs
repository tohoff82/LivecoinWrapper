using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class OrderBook
    {
        [JsonProperty("timestamp")]
        public ulong Timestamp { get; set; }

        [JsonProperty("asks")]
        private readonly List<List<string>> asks;

        [JsonProperty(PropertyName = "bids")]
        private readonly List<List<string>> bids;


        //Сделал эти костыли по причине того, что иногда в ответе цена представлена
        //строкой в таком виде -->  1.4E-4 по другому как распарсить пока не придумал

        public List<List<decimal>> Asks
        {
            get
            {
                return ConvertToDecimal(asks);
            }
        }
        
        public List<List<decimal>> Bids
        {
            get
            {
                return ConvertToDecimal(bids);
            }
        }

        private List<List<decimal>> ConvertToDecimal(List<List<string>> askList)
        {
            var list = new List<List<decimal>>();

            foreach (var ask in askList)
            {
                for (int i = 0; i < ask.Count; i++)
                {
                    list.Add(new List<decimal>
                    {
                        ask[0] != null ? (decimal)Convert.ToDouble(ask[0].Replace('.', ',')) : -1,
                        ask[1] != null ? (decimal)Convert.ToDouble(ask[1].Replace('.', ',')) : -1
                    });
                }
            }

            return list;
        }

    }
}
