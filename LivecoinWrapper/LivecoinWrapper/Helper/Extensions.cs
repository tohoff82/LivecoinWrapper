using System.Linq;
using System.Collections.Generic;

using static System.Web.HttpUtility;

namespace LivecoinWrapper.Helper
{
    public static class Extensions
    {
        public static string ToKeyValueString(this IDictionary<string, string> dict, bool escape = true) =>
                      string.Join("&", dict.Select(kvp => string.Format("{0}={1}", kvp.Key, escape ? UrlEncode(kvp.Value) : kvp.Value)));
    }
}
