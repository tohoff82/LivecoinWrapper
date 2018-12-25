using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using LivecoinWrapper.Helper;
using LivecoinWrapper.DataLayer.RequestData;
using LivecoinWrapper.DataLayer.ExceptionData;

using static System.Environment;

namespace LivecoinWrapper
{
    public abstract class LiveClient : IDisposable
    {
        private HttpClient httpClient;
        private delegate Task Action(HttpResponseMessage response);
        private Action EnsureSuccessStatusCodeAsync;

        public LiveClient() { Initialize(); }
        public LiveClient(string apiKey)
        {
            Initialize();
            httpClient.DefaultRequestHeaders.Add("Api-key", apiKey);
        }

        private void Initialize()
        {
            httpClient = new HttpClient { BaseAddress = new Uri("https://api.livecoin.net") };
            EnsureSuccessStatusCodeAsync = CheckExceptionAsync;
        }

        protected async Task<T> HttpGetAsync<T>(RequestObject requestObj)
        {
            if (requestObj.Sign != null) httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.GetAsync(requestObj.Url).ConfigureAwait(false);

            await EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        protected async Task<T> HttpPostAsync<T>(RequestObject requestObj)
        {
            httpClient.DefaultRequestHeaders.Add("Sign", requestObj.Sign);

            var response = await httpClient.PostAsync(requestObj.Url,
                new StringContent(requestObj.arguments.ToKeyValueString(),
                    Encoding.UTF8, "application/x-www-form-urlencoded")).ConfigureAwait(false);

            await EnsureSuccessStatusCodeAsync(response);

            return await UnpackingResponseAsync<T>(response);
        }

        private  async Task<T> UnpackingResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();
            return await Task.Run(() => JsonConvert.DeserializeObject<T>(json));
        }

        private async Task CheckExceptionAsync(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();

                if (response.Content != null)  response.Content.Dispose();

                throw new LiveException($"{NewLine} StatusCode:   {(ushort)response.StatusCode},  {response.StatusCode.ToString()}" +
                                        $"{NewLine} ErrorMessage: {content}");
            }
        }

        public void Dispose() => httpClient.Dispose();
    }
}
