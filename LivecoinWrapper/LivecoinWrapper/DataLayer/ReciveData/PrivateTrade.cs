using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class PrivateTrade
    {
        [JsonProperty("datetime")]
        public ulong Time { get; private set; }

        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("type")]
        public string OrderType;

        [JsonProperty("symbol")]
        public string Symbol;
        
        private readonly decimal price;
        public decimal Price { get => price; }
        
        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }
        
        private readonly decimal commission;
        public decimal Commission { get => commission; }

        [JsonProperty("clientorderid")]
        public ulong ClientOrderId;

        private readonly decimal bonus;
        public decimal Bonus { get => bonus; }

        [JsonConstructor]
        public PrivateTrade(string price, string quantity, string commission, string bonus)
        {
            decimal.TryParse(price, Any, InvariantCulture, out this.price);
            decimal.TryParse(quantity, Any, InvariantCulture, out this.quantity);
            decimal.TryParse(commission, Any, InvariantCulture, out this.commission);
            decimal.TryParse(bonus, Any, InvariantCulture, out this.bonus);
        }
    }
}
