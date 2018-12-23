using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LivecoinWrapper.Helper;
using LivecoinWrapper.DataLayer.RequestData;
using LivecoinWrapper.DataLayer.ExceptionData;

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

            CheckException(response);

            return await UnpackingResponseAsync<T>(response);
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(),
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            CheckException(response);

            return await UnpackingResponseAsync<T>(response);
        }

        private  async Task<T> UnpackingResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        private void CheckException(HttpResponseMessage responseMessage)
        {
            if (!responseMessage.IsSuccessStatusCode)
            {
                var error = UnpackingResponseAsync<Error>(responseMessage).Result;
                throw new LiveException(error.Message);
            }
        }

        public void Dispose() => httpClient.Dispose();
    }
}
