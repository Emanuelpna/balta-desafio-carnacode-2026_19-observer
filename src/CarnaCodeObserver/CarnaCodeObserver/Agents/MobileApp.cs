using CarnaCodeObserver.Stock;

namespace CarnaCodeObserver.Agents;

public class MobileApp : IObserver<StockInformation>
{
    public string UserId { get; set; }

    public MobileApp(string userId)
    {
        UserId = userId;
    }

    public void SendPushNotification(string symbol, decimal price, decimal changePercent)
    {
        Console.WriteLine($"  → [App Mobile {UserId}] 📱 Push: {symbol} agora em R$ {price:N2} ({changePercent:+0.00;-0.00}%)");
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
        SendPushNotification(value.Symbol, value.Price, value.ChangePercent);
    }
}