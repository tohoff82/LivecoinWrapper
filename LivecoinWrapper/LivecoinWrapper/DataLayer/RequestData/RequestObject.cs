using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using LivecoinWrapper.Helper;
using static LivecoinWrapper.Helper.Enums;
using static LivecoinWrapper.Helper.Enums.RequestType;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public abstract class RequestObject
    {
        protected const string urlSegmentExchange = "/exchange/";
        protected const string urlSegmentPayment  = "/payment/";
        protected const string urlSegmentInfo     = "/info/";

        internal Dictionary<string, string> arguments;

        internal string Url { get; private set; }

        protected void GenerateRequest(RequestType type, string method)
        {
            switch (type)
            {
                case exchange: Url = new StringBuilder(urlSegmentExchange)
                        .AppendFormat("{0}?{1}", method, arguments.ToKeyValueString())
                        .ToString(); break;
                case exchangeAuth:
                    break;
                case payment:
                    break;
                case info:
                    break;
                //default:
                //    break;
            }
        }


    }
}
