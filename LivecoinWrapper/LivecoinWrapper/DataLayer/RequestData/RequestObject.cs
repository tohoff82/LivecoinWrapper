using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using LivecoinWrapper.Helper;

using static LivecoinWrapper.Helper.Enums;
using static LivecoinWrapper.Helper.Enums.RequestType;
using System.Linq;

namespace LivecoinWrapper.DataLayer.RequestData
{
    public abstract class RequestObject
    {
        private readonly string apiSec;

        private const string urlSegmentExchange = "/exchange/";
        private const string urlSegmentPayment  = "/payment/";
        private const string urlSegmentInfo     = "/info/";

        internal SortedDictionary<string, string> arguments;

        internal string Url { get; private set; }
        internal string Sign { get; private set; }

        public RequestObject() { }
        public RequestObject(string apiSec) { this.apiSec = apiSec; }

        protected void GenerateRequest(RequestType type, string method)
        {
            if (type == exchange_GET)      Request_GET(urlSegmentExchange, method, false);
            if (type == exchangeAuth_GET)  Request_GET(urlSegmentExchange, method, true);
            if (type == exchangeAuth_POST) Request_POST(urlSegmentExchange, method, true);

            if (type == payment_GET)  Request_GET(urlSegmentPayment, method, true);
            if (type == payment_POST) Request_POST(urlSegmentPayment, method, true);

            if (type == info_GET) Url = new StringBuilder(urlSegmentInfo).Append(method).ToString();            
        }

        private void Request_GET(string urlSegment, string method, bool signature)
        {
            Url = new StringBuilder(urlSegment).AppendFormat("{0}?{1}", method, arguments.ToKeyValueString()).ToString();
            if (signature) CreateSignature();
        }
        private void Request_POST(string urlSegment, string method, bool signature)
        {
            Url = new StringBuilder(urlSegment).Append(method).ToString();
            if (signature) CreateSignature();
        }

        private void CreateSignature()
        {
            using (var encryptor = new HMACSHA256(Encoding.UTF8.GetBytes(apiSec)))
            {
                byte[] postBytes = Encoding.UTF8.GetBytes(arguments.ToKeyValueString());
                
                Sign = BitConverter.ToString(encryptor.ComputeHash(postBytes)).Replace("-", "");
            }
        }
    }
}
