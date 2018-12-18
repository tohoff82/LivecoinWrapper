using System.Collections.Generic;

using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public class RestrictionRequest : RequestObject
    {
        public RestrictionRequest() : base()
        {
            arguments = new Dictionary<string, string>();

            GenerateRequest(exchange, "restrictions");
        }
    }
}
