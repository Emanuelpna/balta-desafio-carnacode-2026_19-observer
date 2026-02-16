using CarnaCodeObserver.Stock;

namespace CarnaCodeObserver.Agents;

public class TradingBot : IObserver<StockInformation>
{
    public string BotName { get; set; }
    public decimal BuyThreshold { get; set; }
    public decimal SellThreshold { get; set; }

    public TradingBot(string botName, decimal buyThreshold, decimal sellThreshold)
    {
        BotName = botName;
        BuyThreshold = buyThreshold;
        SellThreshold = sellThreshold;
    }

    public void AnalyzeAndTrade(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [Bot {BotName}] 🤖 Analisando {symbol}...");
            
        if (changePercent <= -BuyThreshold)
        {
            Console.WriteLine($"  → [Bot {BotName}] 💰 COMPRANDO {symbol} por R$ {price:N2}");
        }
        else if (changePercent >= SellThreshold)
        {
            Console.WriteLine($"  → [Bot {BotName}] 💸 VENDENDO {symbol} por R$ {price:N2}");
        }
    }

    public void OnCompleted()
    {
        throw new NotImplementedException();
    }

    public void OnError(Exception error)
    {
        throw new NotImplementedException();
    }

    public void OnNext(StockInformation value)
    {
        AnalyzeAndTrade(value.Symbol, value.Price, value.ChangePercent);
    }
}