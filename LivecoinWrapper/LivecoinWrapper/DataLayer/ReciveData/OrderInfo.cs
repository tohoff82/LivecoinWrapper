using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;
using static LivecoinWrapper.Helper.Enums;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class OrderInfo
    {
        [JsonProperty("id")]
        public ulong Id { get; private set; }

        [JsonProperty("client_id")]
        public uint ClientId { get; private set; }

        [JsonProperty("symbol")]
        public string PairId { get; private set; }

        [JsonProperty("status")]
        public OrdStatus OrdStatus { get; private set; }

        [JsonProperty("type")]
        public string OrdType { get; private set; }

        private readonly decimal price;
        public decimal Price { get => price; }

        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }

        private readonly decimal remaining_quantity;
        public decimal RemainingQuantity { get => remaining_quantity; }

        private readonly decimal blocked;
        public decimal Blocked { get => blocked; }

        private readonly decimal blocked_remain;
        public decimal BlockedRemain { get => blocked_remain; }

        private readonly decimal commission_rate;
        public decimal CommissionRate { get => commission_rate; }

        [JsonProperty("trades")]
        public Trades TradesPerOrder { get; private set; }


        [JsonConstructor]
        public OrderInfo(string price, string quantity, string remaining_quantity, string blocked, string blocked_remain, string commission_rate)
        {
            decimal.TryParse(price,              Any, InvariantCulture, out this.price);
            decimal.TryParse(quantity,           Any, InvariantCulture, out this.quantity);
            decimal.TryParse(remaining_quantity, Any, InvariantCulture, out this.remaining_quantity);
            decimal.TryParse(blocked,            Any, InvariantCulture, out this.blocked);
            decimal.TryParse(blocked_remain,     Any, InvariantCulture, out this.blocked_remain);
            decimal.TryParse(commission_rate,    Any, InvariantCulture, out this.commission_rate);
        }
    }

    public class Trades
    {
        [JsonProperty("trades")]
        public ushort Count { get; private set; }

        private readonly decimal amount;
        public decimal Amount { get => amount; }

        private readonly decimal quantity;
        public decimal Quantity { get => quantity; }

        private readonly decimal avg_price;
        public decimal AvgPrice { get => avg_price; }

        private readonly decimal commission;
        public decimal Commission { get => commission; }

        private readonly decimal bonus;
        public decimal Bonus { get => bonus; }

        [JsonConstructor]
        public Trades(string amount, string quantity, string avg_price, string commission, string bonus)
        {
            decimal.TryParse(amount,     Any, InvariantCulture, out this.amount);
            decimal.TryParse(quantity,   Any, InvariantCulture, out this.quantity);
            decimal.TryParse(avg_price,  Any, InvariantCulture, out this.avg_price);
            decimal.TryParse(commission, Any, InvariantCulture, out this.commission);
            decimal.TryParse(bonus,      Any, InvariantCulture, out this.bonus);
        }
    }
}
