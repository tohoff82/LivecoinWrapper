using Newtonsoft.Json;
using System.Collections.Generic;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;
using static LivecoinWrapper.Helper.Enums;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Orders
    {
        [JsonProperty("totalRows")]
        public ushort TotalRows { get; private set; }

        [JsonProperty("startRow")]
        public ushort StartRow { get; private set; }

        [JsonProperty("endRow")]
        public ushort EndRow { get; private set; }

        [JsonProperty("data")]
        public List<Order> Data { get; private set; }
    }

    public class Order
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("currencyPair")]
        public string PairId { get; private set; }

        [JsonProperty("goodUntilTime")]
        public ulong GoodUntilTime { get; private set; }

        [JsonProperty("type")]
        public OrdType OrdType { get; private set; }

        [JsonProperty("orderStatus")]
        public OrdStatus OrdStatus { get; private set; }

        [JsonProperty("issueTime")]
        public ulong IssueTime { get; private set; }

        private readonly decimal price;
        public decimal Price { get => price; }

        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }

        private readonly decimal remainingQuantity;
        public decimal RemainingQuantity { get => remainingQuantity; }

        private readonly decimal commissionByTrade;
        public decimal CommissionByTrade { get => commissionByTrade; }

        private readonly decimal bonusByTrade;
        public decimal BonusByTrade { get => bonusByTrade; }

        private readonly decimal bonusRate;
        public decimal BonusRate { get => bonusRate; }

        private readonly decimal commissionRate;
        public decimal CommissionRate { get => commissionRate; }

        [JsonProperty("lastModificationTime")]
        public ulong LastModificationTime { get; private set; }


        [JsonConstructor]
        public Order(string price, string quantity, string remainingQuantity, string commissionByTrade,
                     string bonusByTrade, string bonusRate, string commissionRate)
        {
            decimal.TryParse(price,             Any, InvariantCulture, out this.price);
            decimal.TryParse(quantity,          Any, InvariantCulture, out this.quantity);
            decimal.TryParse(remainingQuantity, Any, InvariantCulture, out this.remainingQuantity);
            decimal.TryParse(commissionByTrade, Any, InvariantCulture, out this.commissionByTrade);
            decimal.TryParse(bonusByTrade,       Any, InvariantCulture, out this.bonusByTrade);
            decimal.TryParse(bonusRate,         Any, InvariantCulture, out this.bonusRate);
            decimal.TryParse(commissionRate,    Any, InvariantCulture, out this.commissionRate);
        }
    }
}
