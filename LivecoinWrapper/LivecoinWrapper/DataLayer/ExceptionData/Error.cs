using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ExceptionData
{
    internal class Error
    {
        [JsonProperty("success")]
        public string Success { get; set; }

        [JsonProperty("errorCode")]
        public string Code { get; set; }

        [JsonProperty("errorMessage")]
        public string Message { get; set; }
    }
}
