using System;
using System.Threading.Tasks;
using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;

namespace LivecoinWrapper
{
    public class LiveClientVoucher : LiveClient
    {
        private readonly string apiSec;

        public LiveClientVoucher(string apiKey, string apiSec) : base(apiKey)
        {
            this.apiSec = apiSec;
        }

        /// <summary>
        /// Issues a voucher
        /// </summary>
        /// <param name="amount">quantity</param>
        /// <param name="currId">name of currency</param>
        /// <param name="description">description</param>
        /// <param name="forUser">livecoin reciver</param>
        /// <returns>voucher ode string</returns>
        public async Task<Voucher> CreateVaucherAsync(decimal amount, string currId, string description = null, string forUser = null)
        {
            return new Voucher
            {
                Cashout  = false,
                UserFor = forUser,
                CurrencyId = currId,
                ExchangeMarker = "lvc",
                Amount = (float)amount,
                Desription = description,
                CreatedDate = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                Code = await VoucherPostAsync(new VoucherMakeRequest(apiSec, amount, currId, description, forUser))
            };
        }
            

        /// <summary>
        /// Returns the amount of the voucher by its code
        /// </summary>
        /// <param name="voucherCode">voucher code string</param>
        /// <returns>amount</returns>
        public async Task<string> GetVoucherAmountAsync(string voucherCode) =>
            await HttpPostAsync<string>(new VoucherAmountRequest(apiSec, voucherCode, isRedeem : false));

        /// <summary>
        /// Voucher redemption
        /// </summary>
        /// <param name="voucherCode">voucher code string</param>
        /// <returns>Withdraw</returns>
        public async Task<Withdraw> RedeemVaucherAsync(string voucherCode) =>
            await HttpPostAsync<Withdraw>(new VoucherAmountRequest(apiSec, voucherCode, isRedeem : true));
    }
}
