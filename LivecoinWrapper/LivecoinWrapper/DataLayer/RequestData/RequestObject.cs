using System;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using LivecoinWrapper.Helper;

using static LivecoinWrapper.Helper.Enums;
using static LivecoinWrapper.Helper.Enums.RequestType;
using static LivecoinWrapper.Helper.Enums.HttpType;

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

        protected void GenerateRequest(RequestType type, string apiMethod)
        {
            if (type == exchange_GET)      Request(GET,  urlSegmentExchange, apiMethod, false);
            if (type == exchangeAuth_GET)  Request(GET,  urlSegmentExchange, apiMethod, true);
            if (type == exchangeAuth_POST) Request(POST, urlSegmentExchange, apiMethod, true);

            if (type == payment_GET)  Request(GET,  urlSegmentPayment, apiMethod, true);
            if (type == payment_POST) Request(POST, urlSegmentPayment, apiMethod, true);

            if (type == info_GET) Url = new StringBuilder(urlSegmentInfo).Append(apiMethod).ToString();            
        }

        private void Request(HttpType type, string urlSegment, string method, bool signature)
        {
            if (signature) CreateSignature();
            if (type == POST) Url = new StringBuilder(urlSegment).Append(method).ToString();
            if (type == GET)  Url = new StringBuilder(urlSegment).AppendFormat("{0}?{1}", method, arguments.ToKeyValueString()).ToString();
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
