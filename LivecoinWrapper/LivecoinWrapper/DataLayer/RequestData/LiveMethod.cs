using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public static class LiveMethod
    {
        public static string ExchengeTickers()
        {
            return "/exchange/ticker";
        }

        public static string ExchengeTicker(string pair)
        {
            return "/exchange/ticker?currencyPair=" + pair;
        }
    }
}
