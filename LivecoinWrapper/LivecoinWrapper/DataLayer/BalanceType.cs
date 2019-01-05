using System;
using System.Collections.Generic;
using System.Text;

namespace LivecoinWrapper.DataLayer
{
    public static class BalanceType
    {
        public const string _total     = "total";                              //total balance
        public const string _trade     = "trade";                              //funds available for trading
        public const string _available = "available";                          //funds in open orders
        public const string _available_withdrawal = "available_withdrawal";    //funds available for withdrawal
    }
}
