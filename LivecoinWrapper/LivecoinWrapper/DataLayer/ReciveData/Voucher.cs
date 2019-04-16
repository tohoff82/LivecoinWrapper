using Newtonsoft.Json;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Voucher
    {
        [JsonProperty("exchange_marker")]
        public string ExchangeMarker { get; set; }

        [JsonProperty("voucher_code")]
        public string Code { get; set; }

        [JsonProperty("currency")]
        public string CurrencyId { get; set; }

        [JsonProperty("amount")]
        public float Amount { get; set; }

        [JsonProperty("created_date")]
        public long CreatedDate { get; set; }

        [JsonProperty("redeem_date")]
        public long RedeemDate { get; set; }

        [JsonProperty("cashout")]
        public bool Cashout { get; set; }

        [JsonProperty("description")]
        public string Desription { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("private_comment")]
        public string PrivateComment { get; set; }

        [JsonProperty("user_from")]
        public string UserFrom { get; set; }

        [JsonProperty("user_for")]
        public string UserFor { get; set; }


    }
}
