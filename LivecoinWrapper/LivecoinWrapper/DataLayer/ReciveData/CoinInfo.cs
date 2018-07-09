using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ReciveData
{
    public class CoinInfo
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "symbol")]
        public string Symbol { get; set; }

        [JsonProperty(PropertyName = "walletStatus")]
        public WalletStatus WalletStatus { get; set; }

        [JsonProperty(PropertyName = "withdrawFee")]
        private readonly string withdrawFee;

        [JsonProperty(PropertyName = "minDepositAmount ")]
        private readonly string minDepositAmount;

        [JsonProperty(PropertyName = "minWithdrawAmount  ")]
        private readonly string minWithdrawAmount;


        public decimal WithdrawFee
        {
            get
            {
                return (decimal)Convert.ToDouble(withdrawFee.Replace(".", ","));
            }
        }

        public decimal MinDepositAmount
        {
            get
            {
                return (decimal)Convert.ToDouble(minDepositAmount.Replace(".", ","));
            }
        }

        public decimal MinWithdrawAmount
        {
            get
            {
                return (decimal)Convert.ToDouble(minWithdrawAmount.Replace(".", ","));
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
