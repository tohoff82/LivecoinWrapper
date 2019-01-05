namespace LivecoinWrapper.DataLayer
{
    public static class ServiceStatuses
    {
        //--------- Order Statuses ------------//
        public const string _open       = "OPEN";
        public const string _closed     = "CLOSED";
        public const string _cancel     = "CANCELLED";
        public const string _partial    = "PARTIALLY";
        public const string _not_cancel = "NOT_CANCELLED";
        public const string _executed   = "EXECUTED";

        //--------- Wallet Statuses ------------//
        public const string _down           = "down";              //Wallet is temporarily off
        public const string _normal         = "normal";            //Wallet works fine 
        public const string _delayed        = "delayed";           //Wallet is delayed (no new unit 1-2 hours) 
        public const string _blocked        = "blocked";           //Wallet is not synchronized (there is no new unit for at least 2 hours) 
        public const string _blocked_long   = "blocked_long";      //Last block received more than 24 hours ago 
        public const string _delisted       = "delisted";          //The coin will be removed from the exchange, withdraw your funds.  
        public const string _closed_cashin  = "closed_cashin";     //Only output allowed 
        public const string _closed_cashout = "closed_cashout";    //Only input is allowed
    }                                                              
}
