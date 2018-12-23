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
using static LivecoinWrapper.Helper.Enums;
using static LivecoinWrapper.Helper.Enums.OrdStatus;

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

        /// <summary>
        /// For a specific client and for a specific currency pair, to obtain complete information about its orders, 
        /// information can be limited: either only open or only closed orders.
        /// Sampling in pairs should be done on your side
        /// </summary>
        /// <param name="pairId">The currency pair identifier. If not specified, all pairs will be returned.(Not working for a specific pair,  for API side)</param>
        /// <param name="status">Order type (see enum OrdType)</param>
        /// <param name="issuedFrom">Sample start date (in UNIX Time format in milliseconds) -- not working for API side</param>
        /// <param name="issuedTo">Final sampling date (in UNIX Time format in milliseconds) -- not working for API side</param>
        /// <param name="startRow">The sequence number of the first entry Default value: 0</param>
        /// <param name="endRow">Sequence number of the last entry. The default value is 2147483646</param>
        /// <returns>Orders</returns>
        public async Task<Orders> ReturnOrdersAsync(string pairId   = null, OrdStatus status = ALL, ulong? issuedFrom = null,
                                                    ulong? issuedTo = null, uint startRow = 0,        uint endRow = 2147483646) =>
                await HttpGetAsync<Orders>(new OrdersRequest(apiSec, pairId, status.ToString(), issuedFrom, issuedTo, startRow, endRow));

        /// <summary>
        /// Get information about the order by its ID
        /// </summary>
        /// <param name="orderId">The currency pair identifier</param>
        /// <returns>OrderInfo</returns>
        public async Task<OrderInfo> ReturnOrderInfoById(ulong orderId) =>
                await HttpGetAsync<OrderInfo>(new OrderInfoRequest(apiSec, orderId));

        /// <summary>
        /// Returns an array with user balances
        /// </summary>
        /// <param name="currencyId">The currency identifier, comma separated</param>
        /// <returns>List of Balance</returns>
        public async Task<List<Balance>> ReturnBalancesAsync(string currencyId) =>
                await HttpGetAsync<List<Balance>>(new BalancesRequest(apiSec, currencyId));
    }
}
