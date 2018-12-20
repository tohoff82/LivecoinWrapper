namespace LivecoinWrapper.Helper
{
    public class Enums
    {
        public enum RequestType
        {
            exchangeGET,
            exchangeAuthGET,
            exchangeAuthPOST,
            paymentGET,
            paymentPOST,
            infoGET
        }

        public enum WalletStatus
        {
            normal,             //Wallet works fine
            delayed,            //Wallet is delayed (no new unit 1-2 hours)
            blocked,            //Wallet is not synchronized (there is no new unit for at least 2 hours)
            blocked_long,       //Last block received more than 24 hours ago
            down,               //Wallet is temporarily off
            delisted,           //The coin will be removed from the exchange, withdraw your funds.
            closed_cashin,      //Only output allowed
            closed_cashout      //Only input is allowed
        }
    }
}
