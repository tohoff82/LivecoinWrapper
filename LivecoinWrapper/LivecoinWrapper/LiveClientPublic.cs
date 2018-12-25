using System.Threading.Tasks;
using System.Collections.Generic;
using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;

using static LivecoinWrapper.DataLayer.OrderType;

namespace LivecoinWrapper
{
    public class LiveClientPublic : LiveClient
    {
        public LiveClientPublic() : base() { }

        /// <summary>
        /// Get information for the last 24 hours on a specific currency pair.
        /// </summary>
        /// <typeparam name="T"> Ticker or List(Ticker) </typeparam>
        /// <param name="pairId">allPair or concret pair </param>
        /// <returns>Ticker or List(Ticker)</returns>
        public async Task<T> ReturnTickerAsync<T>(string pairId) =>
                await HttpGetAsync<T>(new TickerRequest(pairId));

        /// <summary>
        /// Get information about the latest transactions (transactions) for a given currency pair.
        /// Information can be obtained either in the last hour or in the last minute.
        /// </summary>
        /// <param name="pairId">Required currency pair identifier</param>
        /// <param name="minOrHour">Optional, if true - information is returned in the last minute, if false - last hour</param>
        /// <param name="orderType">Defoult - false, Possible values: BUY or SELL</param>
        /// <returns>List PublicTrade </returns>
        public async Task<List<PublicTrade>> ReturnTradeHistoryAsync(string pairId, bool minOrHour = false, string orderType = _defoult) =>
                await HttpGetAsync<List<PublicTrade>>(new TradeHistoryRequest(pairId, minOrHour, orderType));

        /// <summary>
        /// Get orders for the selected pair (you can set a sign of grouping orders by price)
        /// </summary>
        /// <param name="pairId">Required currency pair identifier</param>
        /// <param name="groupByPrice">true - grouping orders by price</param>
        /// <param name="depth">The maximum number of bids (ask) in the answer. If null - maxValue</param>
        /// <returns>OrderBook object</returns>
        public async Task<OrderBook> ReturnOrderBookAsync(string pairId, bool groupByPrice = false, ushort? depth = null) =>
                await HttpGetAsync<OrderBook>(new OrderBookRequest(pairId, groupByPrice, depth));

        /// <summary>
        /// Returns an orderbook for each currency pair
        /// </summary>
        /// <param name="groupByPrice">true - grouping orders by price</param>
        /// <param name="depth">The maximum number of bids (ask) in the answer. 10 - maxValue</param>
        /// <returns>Dictionary(string, OrderBook)</returns>
        public async Task<Dictionary<string, OrderBook>> ReturnOrderBookAsync(bool groupByPrice = false, byte depth = 10) =>
                await HttpGetAsync<Dictionary<string, OrderBook>>(new OrderBookRequest(groupByPrice, depth));

        /// <summary>
        /// Returns the maximum bid and minimum ask in the current(optional) glass
        /// </summary>
        /// <param name="pairId">Optional, currency pair identifier</param>
        /// <returns>MaxBidMinAsk object</returns>
        public async Task<MaxBidMinAsk> ReturnMaxBidMinAskAsync(string pairId = null) =>
                await HttpGetAsync<MaxBidMinAsk>(new MaxBidMinAskRequest(pairId));

        /// <summary>
        /// Returns restrictions for each pair of min. order size and the maximum number of decimal places in the price
        /// </summary>
        /// <returns>Restrictions object</returns>
        public async Task<Restrictions> ReturnRestrictionsAsync() =>
                await HttpGetAsync<Restrictions>(new RestrictionRequest());

        /// <summary>
        /// returns general cryptocurrency information
        /// </summary>
        /// <returns>CoinsInfo</returns>
        public async Task<CoinsInfo> ReturnCoinsInfoAsync() =>
                await HttpGetAsync<CoinsInfo>(new CoinInfoRequest());
    }
}
