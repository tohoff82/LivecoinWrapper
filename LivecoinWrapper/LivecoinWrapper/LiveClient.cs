using LivecoinWrapper.DataLayer;
using LivecoinWrapper.DataLayer.ReciveData;
using LivecoinWrapper.DataLayer.RequestData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace LivecoinWrapper
{
    public class LiveClient
    {
        private HttpClient httpClient;

        private readonly string publicKey;
        private readonly string secretKey;

        private const string baseAddress = "https://api.livecoin.net";

        public LiveClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public LiveClient(string pubKey, string secKey)
        {
            publicKey = pubKey;
            secretKey = secKey;

            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        protected async Task<T> JsonGetAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }



        #region Private Methods



        #endregion

        #region Public Methods

        public async Task<List<Ticker>> GetTickerAsync()
        {
            return await JsonGetAsync<List<Ticker>>(GetMethod.TickerUri());
        }

        public async Task<Ticker> GetTickerAsync(string marketPair)
        {
            return await JsonGetAsync<Ticker>(GetMethod.TickerUri(marketPair));
        }


        public async Task<List<Trade>> GetLastTradesAsync(string marketPair, string ordType = "false", string minOrHour = "false")
        {
            // ordType = "BUY" or "SELL", "false"(по умолчанию)
            // minOrHour = "true" - данные за последнюю минуту, "false"(по умолчанию) - данные за час
            return await JsonGetAsync<List<Trade>>(GetMethod.LasttradeUri(marketPair, ordType, minOrHour));
        }


        public async Task<object> GetAllOrderBookAsync()
        {
            return await JsonGetAsync<object>(GetMethod.AllOrdebookUri());
        }

        public async Task<OrderBook> GetOrderBookAsync(string marketPair, int depth = 100)
        {
            return await JsonGetAsync<OrderBook>(GetMethod.OrderbookUri(marketPair, depth));
        }


        public async Task<MaxMinBidAsk> GetMaxMinBidAskAsync(string marketPair = "allPairs")
        {
            return await JsonGetAsync<MaxMinBidAsk>(GetMethod.MaxMinBidAskUri(marketPair));
        }

        public async Task<Restrictions> GetRestrictionsAsync()
        {
            return await JsonGetAsync<Restrictions>(GetMethod.RestrictionsUri());
        }

        public async Task<Coins> GetCoinInfoAsync()
        {
            return await JsonGetAsync<Coins>(GetMethod.CoinInfoUri());
        }

        #endregion
    }
}
