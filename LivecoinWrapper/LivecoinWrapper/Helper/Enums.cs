namespace LivecoinWrapper.Helper
{
    public class Enums
    {
        public enum RequestType
        {
            exchange_GET,
            exchangeAuth_GET,
            exchangeAuth_POST,
            payment_GET,
            payment_POST,
            info_GET
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

        public enum OrdStatus
        {
            ALL,                //all orders
            OPEN,               //open orders
            CLOSED,             //closed orders
            CANCELLED,          //cancelled orders
            NOT_CANCELLED,      //all orders except canceled
            PARTIALLY,          //partially executed orders
            EXECUTED
        }

        public enum OrdType
        {
            LIMIT_BUY,
            LIMIT_SELL,
            MARKET_BUY,
            MARKET_SELL
        }

        public enum BalanceType
        {
            total,                  //total balance
            available,              //funds available for trading
            trade,                  //funds in open orders
            available_withdrawal    //funds available for withdrawal
        }

        public enum TransactionsType
        {
            all,
            BUY,
            SELL,
            DEPOSIT,
            WITHDRAWAL
        }
    }
}
