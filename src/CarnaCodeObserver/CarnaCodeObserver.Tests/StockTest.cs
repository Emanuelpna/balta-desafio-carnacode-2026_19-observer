using System.Threading;
using CarnaCodeObserver;
using CarnaCodeObserver.Agents;
using Xunit;

namespace CarnaCodeObserver.Tests;

public class StockTest
{

    [Fact]
    public void ShouldNotifyObservers()
    {
        var petr4 = new Stock.Stock("PETR4", 35.50m);
        
        var investor1 = new Investor("João Silva", 3.0m);
        var investor2 = new Investor("Maria Santos", 5.0m);
        var mobileApp = new MobileApp("user123");
        var tradingBot = new TradingBot("AlgoTrader", 2.0m, 2.5m);

        var stockMonitor = new StockMonitor(petr4.Price);
        
        petr4.Subscribe(investor1);
        petr4.Subscribe(investor2);
        petr4.Subscribe(mobileApp);
        petr4.Subscribe(tradingBot);
        
        petr4.Subscribe(stockMonitor);
        
        petr4.UpdatePrice(36.20m); // +1.97%
        Thread.Sleep(500);
            
        petr4.UpdatePrice(37.50m); // +3.59%
        Thread.Sleep(500);
            
        petr4.UpdatePrice(35.00m); // -6.67%
        Thread.Sleep(500);
    }
}