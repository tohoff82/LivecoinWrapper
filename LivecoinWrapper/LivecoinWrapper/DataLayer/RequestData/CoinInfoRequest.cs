using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class CoinInfoRequest : RequestObject
    {
        public CoinInfoRequest() : base()
        {
            GenerateRequest(info, "coinInfo");
        }
    }
}
