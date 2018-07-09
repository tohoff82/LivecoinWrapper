using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class Coins
    {
        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "minimalOrderBTC")]
        private readonly string minimalOrderBTC;

        [JsonProperty(PropertyName = "info")]
        public List<CoinInfo> CoinList { get; set; }


        public decimal MinimalOrderBTC
        {
            get
            {
                return (decimal)Convert.ToDouble(minimalOrderBTC.Replace(".", ","));
            }
        }
    }

    public class CoinInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "difficulty")]
        private readonly string difficulty;

        [JsonProperty(PropertyName = "walletStatus")]
        public WalletStatus WalletStatus { get; set; }

        [JsonProperty(PropertyName = "withdrawFee")]
        private readonly string withdrawFee;

        [JsonProperty(PropertyName = "minDepositAmount")]
        private readonly string minDepositAmount;

        [JsonProperty(PropertyName = "minWithdrawAmount")]
        private readonly string minWithdrawAmount;

        [JsonProperty(PropertyName = "minOrderAmount")]
        private readonly string minOrderAmount;



        public decimal Difficulty
        {
            get
            {
                if (difficulty != null) return (decimal)Convert.ToDouble(difficulty.Replace(".", ","));
                else return -1;
            }
        }

        public decimal WithdrawFee
        {
            get
            {
                if(withdrawFee != null) return (decimal)Convert.ToDouble(withdrawFee.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MinDepositAmount
        {
            get
            {
                if (minDepositAmount != null) return (decimal)Convert.ToDouble(minDepositAmount.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MinWithdrawAmount
        {
            get
            {
                if (minWithdrawAmount != null) return (decimal)Convert.ToDouble(minWithdrawAmount.Replace(".", ","));
                else return -1;
            }
        }

        public decimal MinOrderAmount
        {
            get
            {
                if (minOrderAmount != null) return (decimal)Convert.ToDouble(minOrderAmount.Replace(".", ","));
                else return -1;
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
