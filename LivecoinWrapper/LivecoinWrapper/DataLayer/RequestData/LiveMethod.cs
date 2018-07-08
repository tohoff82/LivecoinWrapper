using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public static class LiveMethod
    {
        public static string GetTickers()
        {
            return "/exchange/ticker";
        }

        public static string GetTicker(string pair)
        {
            return "/exchange/ticker?currencyPair=" + pair;
        }
    }
}
