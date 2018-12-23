using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer.ExceptionData
{
    internal class Error
    {
        [JsonProperty("success")]
        public ushort Success { get; set; }

        [JsonProperty("errorCode")]
        public ushort Code { get; set; }

        [JsonProperty("errorMessage")]
        public string Message { get; set; }
    }
}
