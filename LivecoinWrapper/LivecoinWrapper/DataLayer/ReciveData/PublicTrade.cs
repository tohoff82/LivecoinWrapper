using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class PublicTrade
    {
        [JsonProperty("time")]
        public ulong Time { get; private set; }

        [JsonProperty("id")]
        public ulong Id { get; private set; }
        
        private readonly decimal price;
        public  decimal Price { get => price; }
        
        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }

        [JsonProperty("type")]
        public string OrderType { get; private set; }

        [JsonProperty("orderBuyId")]
        public ulong OrderBuyId { get; private set; }

        [JsonProperty("orderSellId")]
        public ulong OrderSellId { get; private set; }

        [JsonConstructor]
        public PublicTrade(string price, string quantity)
        {
            decimal.TryParse(price, Any, InvariantCulture, out this.price);
            decimal.TryParse(quantity, Any, InvariantCulture, out this.quantity);
        }
    }
}
