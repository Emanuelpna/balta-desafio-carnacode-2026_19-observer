using CarnaCodeObserver.Stock;

namespace CarnaCodeObserver.Agents;

public class StockMonitor :  IObserver<StockInformation>
{
    private decimal _lastKnownPrice;

    public StockMonitor(decimal price)
    {
        _lastKnownPrice = price;
    }

    public void RegisterNewPrice(decimal price)
    {
        if (price == _lastKnownPrice) return;
        
        Console.WriteLine($"Mudança detectada por notificação!");
        _lastKnownPrice = price;
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
        RegisterNewPrice(value.Price);
    }
}