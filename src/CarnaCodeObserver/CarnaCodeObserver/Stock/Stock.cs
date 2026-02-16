namespace CarnaCodeObserver.Stock;

public class Stock : IObservable<StockInformation>
{
    private readonly List<IObserver<StockInformation>> _observers = new();
    
    public string Symbol { get; set; }
    public decimal Price { get; private set; }
    public DateTime LastUpdate { get; private set; }

    public Stock(string symbol, decimal initialPrice)
    {
        Symbol = symbol;
        Price = initialPrice;
        LastUpdate = DateTime.Now;
    }

    public void UpdatePrice(decimal newPrice)
    {
        if (Price != newPrice)
        {
            decimal oldPrice = Price;
            Price = newPrice;
            LastUpdate = DateTime.Now;
            
            decimal changePercent = ((newPrice - oldPrice) / oldPrice) * 100;
            
            Console.WriteLine($"\n[{Symbol}] Preço atualizado: R$ {oldPrice:N2} → R$ {newPrice:N2} ({changePercent:+0.00;-0.00}%)");

            NotifyObservers(StockInformation.Create(Symbol, newPrice, changePercent));
        }
    }

    private void NotifyObservers(StockInformation stockInformation)
    {
        foreach (var observer in _observers)    
        {
            observer.OnNext(stockInformation);
        }
    }

    public IDisposable Subscribe(IObserver<StockInformation> observer)
    {
        if(!_observers.Contains(observer))
            _observers.Add(observer);
        
        return new Unsubscriber(_observers, observer);
    }
    
    private class Unsubscriber : IDisposable
    {
        private readonly List<IObserver<StockInformation>> _observers;
        private readonly IObserver<StockInformation> _observer;

        public Unsubscriber(List<IObserver<StockInformation>> observers, IObserver<StockInformation> observer)
        {
            _observers = observers;
            _observer = observer;
        }

        public void Dispose()
        {
            _observers.Remove(_observer);
        }
    }
}