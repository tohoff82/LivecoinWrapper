using System;
using LivecoinWrapper;
using LivecoinWrapper.DataLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivecoinWrapper.DataLayer.ReciveData;

using static System.Console;
using static LivecoinWrapper.DataLayer.MarketPair;
using static LivecoinWrapper.DataLayer.OrderType;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new LiveClientPublic();

            //TestTicker(client, emc_usd);
            //TestTradeHistoryPub(client, emc_usd, true, sell);
            //TestOrderBook(client, emc_usd, true, 10000);
            //TestAllOrderBook(client, true, 10);
            //TestMaxBidMinAsk(client, wgr_btc);
            //TestRestrictions(client);
            //TestCoinInfo(client);
            
        }

        private static void TestTicker(LiveClientPublic client, string pairId)
        {
            if (pairId != allPair)
            {
                var ticker = client.ReturnTickerAsync<Ticker>(pairId).Result;

                WriteLine("Currency --> " + ticker.Currency);
                WriteLine("CurSymbol --> " + ticker.CurSymbol);
                WriteLine("LastPrice --> " + ticker.LastPrice);
                WriteLine("HighPrice --> " + ticker.High24Price);
                WriteLine("LowPrice --> " + ticker.Low24Price);
                WriteLine("Volume --> " + ticker.Volume24);
                WriteLine("VolumeWap --> " + ticker.VolumeWap);
                WriteLine("MaximumBid --> " + ticker.Max24Bid);
                WriteLine("MinimumAsk --> " + ticker.Min24Ask);
                WriteLine("BestBid --> " + ticker.Best24Bid);
                WriteLine("BestAsk --> " + ticker.Best24Ask);
                WriteLine("--------------------------");
            }
            else
            {
                var tickerLst = client.ReturnTickerAsync<List<Ticker>>(pairId).Result;

                foreach (var ticker in tickerLst)
                {
                    WriteLine("Currency --> " + ticker.Currency);
                    WriteLine("CurSymbol --> " + ticker.CurSymbol);
                    WriteLine("LastPrice --> " + ticker.LastPrice);
                    WriteLine("HighPrice --> " + ticker.High24Price);
                    WriteLine("LowPrice --> " + ticker.Low24Price);
                    WriteLine("Volume --> " + ticker.Volume24);
                    WriteLine("VolumeWap --> " + ticker.VolumeWap);
                    WriteLine("MaximumBid --> " + ticker.Max24Bid);
                    WriteLine("MinimumAsk --> " + ticker.Min24Ask);
                    WriteLine("BestBid --> " + ticker.Best24Bid);
                    WriteLine("BestAsk --> " + ticker.Best24Ask);
                    WriteLine("--------------------------");
                }
            }

        }
        private static void TestTradeHistoryPub(LiveClientPublic client, string pairId, bool mOh, string ordType)
        {
            var th = client.ReturnTradeHistoryAsync(pairId/*, orderType:sell*/).Result;

            foreach (var trade in th)
            {
                WriteLine("Id --> " + trade.Id);
                WriteLine("OrderBuyId --> " + trade.OrderBuyId);
                WriteLine("OrderSellId --> " + trade.OrderSellId);
                WriteLine("OrderType --> " + trade.OrderType);
                WriteLine("Price --> " + trade.Price);
                WriteLine("Quantity --> " + trade.Quantity);
                WriteLine("Time --> " + trade.Time);
                WriteLine("*********************************");
            }
        }
        private static void TestOrderBook(LiveClientPublic client, string pairId, bool sortFlag, ushort depth)
        {
            var ob = client.ReturnOrderBookAsync(pairId/*, sortFlag, depth*/).Result;

            WriteLine("Timestamp -->" + ob.Timestamp);
            foreach (var item in ob.Asks)
            {
                WriteLine("rate -- " + item.rate);
                WriteLine("amount -- " + item.amount);
                WriteLine("depthItemTime -- " + item.depthItemTime);
                WriteLine("***************************");
            }
            WriteLine("------------------------------");
            foreach (var item in ob.Bids)
            {
                WriteLine("rate -- " + item.rate);
                WriteLine("amount -- " + item.amount);
                WriteLine("depthItemTime -- " + item.depthItemTime);
                WriteLine("***************************");
            }
        }
        private static void TestAllOrderBook(LiveClientPublic client, bool sortFlag, byte depth)
        {
            var ob = client.ReturnOrderBookAsync().Result;

            WriteLine("Answer count --> " + ob.Count);
        }
        private static void TestMaxBidMinAsk(LiveClientPublic client, string pairId)
        {
            var mbma = client.ReturnMaxBidMinAskAsync(/*pairId*/).Result;

            WriteLine("Symbol --> " + mbma.Currencies.FirstOrDefault(p => p.Symbol == "EMC/USD").Symbol);
            WriteLine("MaxBid --> " + mbma.Currencies.FirstOrDefault(p => p.Symbol == "EMC/USD").MaxBid);
            WriteLine("MinAsk --> " + mbma.Currencies.FirstOrDefault(p => p.Symbol == "EMC/USD").MinAsk);
        }
        private static void TestRestrictions(LiveClientPublic client)
        {
            var r = client.ReturnRestrictionsAsync().Result;            

            WriteLine("Success --> " + r.Success);
            WriteLine("MinBtcVolume --> " + r.MinBtcVolume);
            WriteLine("--------------------------");

            var lst = r.RestrictionList;

            foreach (var item in lst)
            {
                WriteLine("CurrencyPair --> " + item.CurrencyPair);
                WriteLine("MinLimitQuantity --> " + item.MinLimitQuantity);
                WriteLine("PriceScale --> " + item.PriceScale);
                WriteLine("***********************************");
            }
        }
        private static void TestCoinInfo(LiveClientPublic client)
        {
            var ci = client.ReturnCoinsInfoAsync().Result;

            WriteLine("Success --> " + ci.Success);
            WriteLine("MinimalOrderBTC --> " + ci.MinimalOrderBTC);
            WriteLine("------------------------------------------");

            var info = ci.CoinList;
            foreach (var item in info)
            {
                WriteLine("Name --> " + item.Name);
                WriteLine("Symbol --> " + item.Symbol);
                WriteLine("Difficulty --> " + item.Difficulty);
                WriteLine("MinDepositAmount --> " + item.MinDepositAmount);
                WriteLine("MinOrderAmount --> " + item.MinOrderAmount);
                WriteLine("MinWithdrawAmount --> " + item.MinWithdrawAmount);
                WriteLine("WalletStatus --> " + item.WalletStatus);
                WriteLine("WithdrawFee --> " + item.WithdrawFee);
                WriteLine("***************************************");
            }
        }
    }
}
