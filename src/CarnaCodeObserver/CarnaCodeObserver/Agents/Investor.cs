using CarnaCodeObserver.Stock;

namespace CarnaCodeObserver.Agents;

public class Investor : IObserver<StockInformation>
{
    public string Name { get; set; }
    public decimal AlertThreshold { get; set; }

    public Investor(string name, decimal alertThreshold)
    {
        Name = name;
        AlertThreshold = alertThreshold;
    }

    public void OnPriceChanged(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [Investidor {Name}] Notificado sobre {symbol}");
            
        if (Math.Abs(changePercent) >= AlertThreshold)
        {
            Console.WriteLine($"  → [Investidor {Name}] ⚠️ ALERTA! Mudança de {changePercent:+0.00;-0.00}% excedeu limite de {AlertThreshold}%");
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
        OnPriceChanged(value.Symbol, value.Price, value.ChangePercent);
    }
}