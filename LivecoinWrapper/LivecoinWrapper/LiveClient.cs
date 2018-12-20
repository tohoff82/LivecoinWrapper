using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LivecoinWrapper.DataLayer.RequestData;
using LivecoinWrapper.Helper;
using System.Text;

namespace LivecoinWrapper
{
    public abstract class LiveClient : IDisposable
    {
        private readonly HttpClient httpClient;

        private const string baseAddress = "https://api.livecoin.net";

        public LiveClient()
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
        }

        public LiveClient(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(baseAddress) };
            httpClient.DefaultRequestHeaders.Add("Api-key", apiKey);
        }

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            if (requestObj.Sign != null) httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            //response.EnsureSuccessStatusCode();         // throw if web request failed

            string json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(),
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            //response.EnsureSuccessStatusCode();         // throw if web request failed

            string json = await response.Content.ReadAsStringAsync();

            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        public void Dispose() => httpClient.Dispose();
    }
}
