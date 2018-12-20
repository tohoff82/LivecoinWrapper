using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;
using LivecoinWrapper.DataLayer;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using System.Collections.Generic;
using System.Net;
using System.IO;
using LivecoinWrapper.DataLayer.ExceptionData;

namespace LivecoinWrapper
{
    public class LiveClientPrivate :LiveClient
    {
        private readonly string apiSec;

        public LiveClientPrivate(string apiKey, string apiSec) : base(apiKey)
        {
            this.apiSec = apiSec;
        }

        /// <summary>
        /// Get information about his recent transactions, the result can be limited by the relevant parameters
        /// </summary>
        /// <param name="pairId">The currency pair identifier. If not specified, all pairs will be returned.</param>
        /// <param name="orderDesc">The sort order. If true, then new orders will be the first, if false, then old orders will be the first.</param>
        /// <param name="limit">Number of elements per page</param>
        /// <param name="offset">Position of the first element on the page in the selection</param>
        /// <returns>List PrivateTrade</returns>
        public async Task<List<PrivateTrade>> ReturnTradeHistoryAsync(string pairId = null, bool orderDesc = true, ushort limit = 100, ushort offset = 0) =>
                await HttpGetAsync<List<PrivateTrade>>(new TradeHistoryRequest(apiSec, pairId, orderDesc, limit, offset));
    }
}
