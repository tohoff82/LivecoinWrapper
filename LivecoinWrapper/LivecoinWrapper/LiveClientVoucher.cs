using System.Threading.Tasks;
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
        /// 
        /// </summary>
        /// <param name="amount"></param>
        /// <param name="currId"></param>
        /// <param name="description"></param>
        /// <param name="forUser"></param>
        /// <returns></returns>
        public async Task<string> CreateVaucher(decimal amount, string currId, string description = null, string forUser = null) =>
            await VoucherPostAsync(new VoucherMakeRequest(apiSec, amount, currId, description, forUser));
    }
}
