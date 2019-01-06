using Newtonsoft.Json;

using static System.StringSplitOptions;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Wallet
    {
        [JsonProperty("fault")]
        public string Fault { get; private set; }

        [JsonProperty("userId")]
        public uint UserId { get; private set; }

        [JsonProperty("userName")]
        public string UserName { get; private set; }

        [JsonProperty("currency")]
        public string Currency { get; private set; }

        public string Address { get; private set; }
        public string Memo { get; private set; }

        [JsonConstructor]
        public Wallet(string wallet)
        {
            string[] spl = wallet.Split(new string[] { "::" }, RemoveEmptyEntries);
            if (spl.Length != 0 && spl.Length == 2) { Address = spl[0]; Memo = spl[1]; }
            else Address = wallet;
        }
    }
}
