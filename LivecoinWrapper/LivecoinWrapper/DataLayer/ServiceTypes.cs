namespace LivecoinWrapper.DataLayer
{
    public static class ServiceTypes
    {
        //----- Default Types ---------------------//
        public const byte _o             = 0;
        public const byte _min           = 100;
        public const uint _max           = 2147483646;

        public const string _false       = "false";
        public const string _all         = "ALL";

        //------ Order Types ----------------------//
        public const string _limit_buy   = "LIMIT_BUY";
        public const string _limit_sell  = "LIMIT_SELL";
        public const string _market_buy  = "MARKET_BUY";
        public const string _market_sell = "MARKET_SELL";

        //------ Order & Transaction Types -------//
        public const string _buy         = "BUY";
        public const string _sell        = "SELL";

        //------ Transaction Types --------------//
        public const string _deposit     = "DEPOSIT";
        public const string _withdrawal  = "WITHDRAWAL";

        //------ Balance Types -----------------//
        public const string _total      = "total";                             //total balance
        public const string _trade      = "trade";                             //funds available for trading
        public const string _available  = "available";                         //funds in open orders
        public const string _available_withdrawal = "available_withdrawal";    //funds available for withdrawal
    }
}
