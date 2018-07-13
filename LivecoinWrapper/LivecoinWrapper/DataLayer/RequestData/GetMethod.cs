using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public static class GetMethod
    {
        #region Request Uri for public methods

        public static string TickerUri(string pair = "allpair")
        {
            var sb = new StringBuilder("/exchange/ticker");

            if (pair == "allpair") return sb.ToString();
            else return sb.AppendFormat("?currencyPair={0}",pair).ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string LasttradeUri(string pair, string ordType, string minOrHour)
        {
            var sb = new StringBuilder("/exchange/last_trades?");

            sb.AppendFormat("currencyPair={0}", pair);
            if (ordType != "false") sb.AppendFormat("&type={0}", ordType);
            if (minOrHour != "false") sb.AppendFormat("&minutesOrHour={0}", minOrHour);

            return sb.ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string AllOrdebookUri(int depth = 10)
        {
            var sb = new StringBuilder("/exchange/all/order_book");

            if (depth < 10) sb.AppendFormat("?depth={0}", depth.ToString());

            return sb.ToString();
        }

        public static string OrderbookUri(string pair, int depth)
        {
            var sb = new StringBuilder("/exchange/order_book?");

            sb.AppendFormat("currencyPair={0}", pair);
            if (depth < 100) sb.AppendFormat("&depth={0}", depth.ToString());

            return sb.ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string MaxMinBidAskUri(string pair)
        {
            var sb = new StringBuilder("/exchange/maxbid_minask");

            if (pair == "allPairs") return sb.ToString();
            else return sb.AppendFormat("?currencyPair={0}", pair).ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string RestrictionsUri()
        {
            return new StringBuilder("/exchange/restrictions").ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string CoinInfoUri()
        {
            return new StringBuilder("/info/coinInfo").ToString();
        }

        #endregion
    }
}
