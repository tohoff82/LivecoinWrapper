using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Coins
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("minimalOrderBTC")]
        private readonly string minimalOrderBTC;
        public decimal MinimalOrderBTC
        {
            get
            {
                return minimalOrderBTC != null ? (decimal)Convert.ToDouble(minimalOrderBTC.Replace(".", ",")) : -1;
            }
        }

        [JsonProperty("info")]
        public List<CoinInfo> CoinList { get; set; }
    }

    public class CoinInfo
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("difficulty")]
        private readonly string difficulty;
        public decimal Difficulty
        {
            get
            {
                return difficulty != null ? (decimal)Convert.ToDouble(difficulty.Replace(".", ",")) : -1;
            }
        }

        [JsonProperty("walletStatus")]
        public WalletStatus WalletStatus { get; set; }

        [JsonProperty("withdrawFee")]
        private readonly string withdrawFee;
        public decimal WithdrawFee
        {
            get
            {
                return withdrawFee != null ? (decimal)Convert.ToDouble(withdrawFee.Replace(".", ",")) : -1;
            }
        }

        [JsonProperty("minDepositAmount")]
        private readonly string minDepositAmount;
        public decimal MinDepositAmount
        {
            get
            {
                return minDepositAmount != null ? (decimal)Convert.ToDouble(minDepositAmount.Replace(".", ",")) : -1;
            }
        }

        [JsonProperty("minWithdrawAmount")]
        private readonly string minWithdrawAmount;
        public decimal MinWithdrawAmount
        {
            get
            {
                return minWithdrawAmount != null ? (decimal)Convert.ToDouble(minWithdrawAmount.Replace(".", ",")) : -1;
            }
        }

        [JsonProperty("minOrderAmount")]
        private readonly string minOrderAmount;
        public decimal MinOrderAmount
        {
            get
            {
                return minOrderAmount != null ? (decimal)Convert.ToDouble(minOrderAmount.Replace(".", ",")) : -1;
            }
        }
    }

    public enum WalletStatus
    {
        normal,
        delayed,
        blocked,
        blocked_long,
        down,
        delisted,
        closed_cashin,
        closed_cashout
    }
}
