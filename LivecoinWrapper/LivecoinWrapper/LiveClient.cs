using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LivecoinWrapper.DataLayer.RequestData;

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

        public void Dispose() => httpClient.Dispose();
    }
}
