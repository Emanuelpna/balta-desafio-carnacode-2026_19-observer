namespace CarnaCodeObserver.Stock;

public sealed record StockInformation
{
    public string Symbol { get; }
    public decimal Price { get; }
    public decimal ChangePercent { get; }
    
    private StockInformation(string symbol, decimal price, decimal changePercent) {
        Symbol = symbol;
        Price = price;
        ChangePercent = changePercent;
    }

    public static StockInformation Create(string symbol, decimal price, decimal changePercent)
    {
        return new StockInformation(symbol, price, changePercent);
    }
}