using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper
{
    class LiveClientVoucher : LiveClient
    {
        private readonly string apiSec;

        public LiveClientVoucher(string apiKey, string apiSec) : base(apiKey)
        {
            this.apiSec = apiSec;
        }
    }
}
