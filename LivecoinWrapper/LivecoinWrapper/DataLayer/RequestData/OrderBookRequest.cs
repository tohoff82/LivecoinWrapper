using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class OrderBookRequest : RequestObject
    {
        public OrderBookRequest(string pairId, bool groupByPrice, ushort? depth) : base()
        {
            arguments = new SortedDictionary<string, string>
            {
                ["currencyPair"] = pairId,
                ["groupByPrice"] = groupByPrice.ToString()
            };

            if (depth != null) arguments.Add("depth", depth.ToString());

            GenerateRequest(exchangeGET, "order_book");
        }

        public OrderBookRequest(bool groupByPrice, byte depth) : base()
        {
            arguments = new SortedDictionary<string, string>
            {
                ["groupByPrice"] = groupByPrice.ToString(),
                ["depth"] = depth.ToString()
            };

            GenerateRequest(exchangeGET, "all/order_book");
        }
    }
}
