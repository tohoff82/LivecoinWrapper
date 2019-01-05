using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Transaction
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("type")]
        public string Type { get; private set; }

        [JsonProperty("date")]
        public ulong Date { get; private set; }

        private readonly decimal amount;
        public decimal Amount { get => amount; }

        private readonly decimal fee;
        public decimal Fee { get => fee; }

        [JsonProperty("fixedCurrency")]
        public string BaseCurrency { get; private set; }

        [JsonProperty("taxCurrency")]
        public string TaxCurrency { get; private set; }

        private readonly decimal variableAmount;
        public decimal QuoteAmount { get => variableAmount; }

        [JsonProperty("variableCurrency")]
        public string QuoteCurrency { get; private set; }

        [JsonProperty("external")]
        public string External { get; private set; }

        [JsonProperty("externalKey")]
        public string ExternalKey { get; private set; }

        [JsonProperty("login")]
        public string Login { get; private set; }

        [JsonProperty("documentId")]
        public ulong? DocumentId { get; private set; }

        [JsonConstructor]
        public Transaction(string amount, string fee, string variableAmount)
        {
            decimal.TryParse(fee,            Any, InvariantCulture, out this.fee);
            decimal.TryParse(amount,         Any, InvariantCulture, out this.amount);
            decimal.TryParse(variableAmount, Any, InvariantCulture, out this.variableAmount);
        }
    }
}
