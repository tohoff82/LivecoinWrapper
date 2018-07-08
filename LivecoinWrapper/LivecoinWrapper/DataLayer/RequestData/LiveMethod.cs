using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public static class LiveMethod
    {
        public static string GetTickersUri()
        {
            return new StringBuilder("/exchange/ticker").ToString();
        }

        public static string GetTickerUri(string pair)
        {
            var sb = new StringBuilder("/exchange/ticker?");

            return sb.AppendFormat("currencyPair={0}",pair).ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string GetLasttradeUri(string pair, string ordType = "false", string minOrHour = "false")
        {
            var sb = new StringBuilder("/exchange/last_trades?");

            sb.AppendFormat("currencyPair={0}", pair);
            if (ordType != "false") sb.AppendFormat("&type={0}", ordType);
            if (minOrHour != "false") sb.AppendFormat("&minutesOrHour={0}", minOrHour);

            return sb.ToString();
        }
        //------------------------------------------------------------------------------------------//

        public static string GetOllOrdebook(int depth = 10)
        {
            var sb = new StringBuilder("/exchange/all/order_book");

            if (depth < 10) sb.AppendFormat("?depth={0}", depth.ToString());

            return sb.ToString();
        }

    }
}
