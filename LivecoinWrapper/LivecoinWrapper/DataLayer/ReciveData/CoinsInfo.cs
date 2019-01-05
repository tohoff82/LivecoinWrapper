using System.Collections.Generic;
using Newtonsoft.Json;

using static System.Globalization.CultureInfo;
using static System.Globalization.NumberStyles;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class CoinsInfo
    {
        [JsonProperty("success")]
        public bool Success { get; private set; }

        private readonly decimal minimalOrderBTC;
        public decimal MinimalOrderBTC { get => minimalOrderBTC; }

        [JsonProperty("info")]
        public List<Info> CoinList { get; private set; }

        [JsonConstructor]
        public CoinsInfo(string minimalOrderBTC)
        {
            decimal.TryParse(minimalOrderBTC, Any, InvariantCulture, out this.minimalOrderBTC);
        }
    }

    public class Info
    {
        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("symbol")]
        public string Symbol { get; private set; }

        [JsonProperty("walletStatus")]
        public string WalletStatus { get; private set; }
        
        private readonly decimal difficulty;
        public decimal Difficulty { get => difficulty; }
        
        private readonly decimal withdrawFee;
        public decimal WithdrawFee { get => withdrawFee; }
        
        private readonly decimal minDepositAmount;
        public decimal MinDepositAmount { get => minDepositAmount; }

        private readonly decimal minWithdrawAmount;
        public decimal MinWithdrawAmount { get => minWithdrawAmount; }

        private readonly decimal minOrderAmount;
        public decimal MinOrderAmount { get => minOrderAmount; }

        [JsonConstructor]
        public Info(string difficulty, string withdrawFee, string minDepositAmount, string minWithdrawAmount, string minOrderAmount)
        {
            decimal.TryParse(difficulty, Any, InvariantCulture, out this.difficulty);
            decimal.TryParse(withdrawFee, Any, InvariantCulture, out this.withdrawFee);
            decimal.TryParse(minDepositAmount, Any, InvariantCulture, out this.minDepositAmount);
            decimal.TryParse(minWithdrawAmount, Any, InvariantCulture, out this.minWithdrawAmount);
            decimal.TryParse(minOrderAmount, Any, InvariantCulture, out this.minOrderAmount);
        }
    }
}
