using System.Threading.Tasks;
using System.Collections.Generic;
using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;

using static LivecoinWrapper.DataLayer.ServiceTypes;
using static LivecoinWrapper.DataLayer.ServiceStatuses;

namespace LivecoinWrapper
{
    public sealed class LiveClientPrivate :LiveClient
    {
        private readonly string apiSec;

        public LiveClientPrivate(string apiKey, string apiSec) : base(apiKey)
        {
            this.apiSec = apiSec;
        }

        #region User Private Data Methods
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
        /// <param name="status">Order status. Possible values: _open, _closed, _cancel, _partial, _not_cancel</param>
        /// <param name="issuedFrom">Sample start date (in UNIX Time format in milliseconds) -- not working for API side</param>
        /// <param name="issuedTo">Final sampling date (in UNIX Time format in milliseconds) -- not working for API side</param>
        /// <param name="startRow">The sequence number of the first entry Default value: 0</param>
        /// <param name="endRow">Sequence number of the last entry. The default value is 2147483646</param>
        /// <returns>Orders</returns>
        public async Task<Orders> ReturnOrdersAsync(string pairId = null, string status = _all, ulong? issuedFrom = null, ulong? issuedTo = null, uint startRow = 0, uint endRow = 2147483646) =>
                await HttpGetAsync<Orders>(new OrdersRequest(apiSec, pairId, status, issuedFrom, issuedTo, startRow, endRow));

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

        /// <summary>
        /// Returns a list of user transactions
        /// </summary>
        /// <param name="startTime">Required, sample start date (in UNIX Time format in milliseconds)</param>
        /// <param name="endTime">Required, sample end date (in UNIX Time format in milliseconds)</param>
        /// <param name="type">Types of transactions Possible values: _all, _buy, _sell, _deposit, _withdrawal</param>
        /// <param name="resLimit">Maximum number of results</param>
        /// <param name="offset">First record index</param>
        /// <returns>List of Transaction</returns>
        public async Task<List<Transaction>> ReturnTransactionsAsync(ulong startTime, ulong endTime, string type = _all, ushort resLimit = 100, ushort offset = 0) =>
                await HttpGetAsync<List<Transaction>>(new TransactionsRequest(apiSec, startTime, endTime, type.ToString(), resLimit, offset));

        /// <summary>
        /// Returns the current user commission
        /// </summary>
        /// <param name="info">if true answer add MonthlyUSDVolume field</param>
        /// <returns>FeeInfo</returns>
        public async Task<FeeInfo> ReturnFeeInfoAsync(bool info = true) =>
                await HttpGetAsync<FeeInfo>(new FeeRequest(apiSec, info));
        #endregion

        #region Privae Create & Cancel Orders Methods

        /// <summary>
        /// Creating orders (buy, sell for limit & market)
        /// </summary>
        /// <param name="type">LIMIT_BUY, LIMIT_SELL, MARKET_BUY, MARKET_SELL</param>
        /// <param name="pairId">The currency pair identifier</param>
        /// <param name="quantity">quantity of base carrencie</param>
        /// <param name="price">if OrdType - Market, price = 0</param>
        /// <returns>PlaceOrder</returns>
        public async Task<PlaceOrder> PlaceOrderAsync(string type, string pairId, decimal quantity, decimal price) =>
                await HttpPostAsync<PlaceOrder>(new PlaceOrderRequest(apiSec, type, pairId, quantity, price));
        #endregion
    }
}
