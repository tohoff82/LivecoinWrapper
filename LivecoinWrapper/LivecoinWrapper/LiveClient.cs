using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LivecoinWrapper
{
    public abstract class LiveClient : IDisposable
    {
        protected HttpClient httpClient;

        private const string baseAddress = "https://api.livecoin.net";

        public LiveClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public LiveClient(string apiKey, string apiSec)
        {
            // todo
        }

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            string json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        //protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        //{
        //    //todo

        //    return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        //}


        #region Public Methods

        //public async Task<Ticker> GetTickerAsync(string marketPair)
        //{
        //    return await HttpGetAsync<Ticker>(GetMethod.TickerUri(marketPair));
        //}


        //public async Task<List<PublicTrade>> GetLastTradesAsync(string marketPair, string ordType = "false", string minOrHour = "false")
        //{
        //    // ordType = "BUY" or "SELL", "false"(по умолчанию)
        //    // minOrHour = "true" - данные за последнюю минуту, "false"(по умолчанию) - данные за час
        //    return await HttpGetAsync<List<PublicTrade>>(GetMethod.LasttradeUri(marketPair, ordType, minOrHour));
        //}


        //public async Task<object> GetAllOrderBookAsync()
        //{
        //    return await HttpGetAsync<object>(GetMethod.AllOrdebookUri());
        //}

        //public async Task<OrderBook> GetOrderBookAsync(string marketPair, int depth = 100)
        //{
        //    return await HttpGetAsync<OrderBook>(GetMethod.OrderbookUri(marketPair, depth));
        //}


        //public async Task<MaxMinBidAsk> GetMaxMinBidAskAsync(string marketPair = "allPairs")
        //{
        //    return await HttpGetAsync<MaxMinBidAsk>(GetMethod.MaxMinBidAskUri(marketPair));
        //}

        //public async Task<Restrictions> GetRestrictionsAsync()
        //{
        //    return await HttpGetAsync<Restrictions>(GetMethod.RestrictionsUri());
        //}

        //public async Task<Coins> GetCoinInfoAsync()
        //{
        //    return await HttpGetAsync<Coins>(GetMethod.CoinInfoUri());
        //}

        public void Dispose() => httpClient.Dispose();

        #endregion
    }
}
