using Newtonsoft.Json;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class PlaceOrder
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        [JsonProperty("added")]
        public bool Added { get; private set; }

        [JsonProperty("orderId")]
        public ulong? OrderId { get; private set; }

        [JsonProperty("exception")]
        public string Exception { get; private set; }
    }
}
