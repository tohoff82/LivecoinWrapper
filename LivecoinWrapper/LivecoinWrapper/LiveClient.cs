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

        private string publicKey;
        private string secretKey;

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

        protected async Task<T> GetJsonAsync<T>(string requestUri)
        {
            var response = await httpClient.GetAsync(requestUri).ConfigureAwait(false);

            response.EnsureSuccessStatusCode();         // throw if web request failed

            var json = await response.Content.ReadAsStringAsync();

            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        #region Public Methods
        public async Task<List<Ticker>> GetTickerAsync()
        {
            return await GetJsonAsync<List<Ticker>>(LiveMethod.ExchengeTickers());
        }

        public async Task<Ticker> GetTickerAsync(string marketPair)
        {
            return await GetJsonAsync<Ticker>(LiveMethod.ExchengeTicker(marketPair));
        }

        #endregion


    }
}
