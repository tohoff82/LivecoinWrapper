using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LivecoinWrapper.DataLayer.RequestData;

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
        public async Task<T> GetTickerAsync<T>(string pairId) =>
                await HttpGetAsync<T>(new TickerRequest(pairId));
    }
}
