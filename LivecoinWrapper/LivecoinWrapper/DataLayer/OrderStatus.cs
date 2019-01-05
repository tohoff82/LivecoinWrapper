using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer
{
    public static class OrderStatus
    {
        public const string _all        = "ALL";      
        public const string _open       = "OPEN";     
        public const string _closed     = "CLOSED";   
        public const string _cancel     = "CANCELLED";
        public const string _partial    = "PARTIALLY";
        public const string _not_cancel = "NOT_CANCELLED";
        public const string _execute    = "EXECUTED";
    }
}
