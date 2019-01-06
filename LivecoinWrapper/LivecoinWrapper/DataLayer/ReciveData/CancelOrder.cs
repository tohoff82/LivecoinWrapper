using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class CancelOrder
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        [JsonProperty("cancelled")]
        public bool Cancelled { get; private set; }

        [JsonProperty("exception")]
        public string Exception { get; private set; }

        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }

        private readonly decimal tradeQuantity;
        public decimal TradeQuantity { get => tradeQuantity; }

        [JsonConstructor]
        public CancelOrder(string quantity, string tradeQuantity)
        {
            decimal.TryParse(quantity,      Any, InvariantCulture, out this.quantity);
            decimal.TryParse(tradeQuantity, Any, InvariantCulture, out this.tradeQuantity);
        }
    }
}
