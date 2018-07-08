using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public static class LiveMethod
    {
        public static string GetTickers()
        {
            return new StringBuilder("/exchange/ticker").ToString();
        }

        public static string GetTicker(string pair)
        {
            var sb = new StringBuilder("/exchange/ticker?");

            return sb.AppendFormat("currencyPair={0}",pair).ToString();
        }

        public static string GetTradeline(string pair, string ordType = "false", string minOrHour = "false")
        {
            var sb = new StringBuilder("/exchange/last_trades?");
            sb.AppendFormat("currencyPair={0}", pair);
            if (ordType != "false") sb.AppendFormat("&type={0}", ordType);
            if (minOrHour != "false") sb.AppendFormat("&minutesOrHour={0}", minOrHour);

            return sb.ToString();
        }
    }
}
