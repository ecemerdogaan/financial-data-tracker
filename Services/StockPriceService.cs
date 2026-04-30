using FinancialDataTracker.External;
using FinancialDataTracker.Models;
using FinancialDataTracker.Repositories;

namespace FinancialDataTracker.Services;

public class StockPriceService : IStockPriceService
{
    private readonly IStockPriceRepository _repository;
    private readonly FinnhubClient _finnhubClient;

    public StockPriceService(IStockPriceRepository repository, FinnhubClient finnhubClient)
    {
        _repository = repository;
        _finnhubClient = finnhubClient;
    }

    public async Task<List<StockPrice>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<List<StockPrice>> GetBySymbolAsync(string symbol)
    {
        return await _repository.GetBySymbolAsync(symbol);
    }

    public async Task AddManualAsync(string symbol, decimal price, string currency)
    {
        var stockPrice = new StockPrice
        {
            Symbol = symbol.ToUpper(),
            Price = price,
            Currency = currency.ToUpper(),
            RecordedAt = DateTime.UtcNow,
            Source = "Manual"
        };

        await _repository.AddAsync(stockPrice);
    }

    public async Task<StockPrice?> FetchAndSaveAsync(string symbol)
    {
        var price = await _finnhubClient.GetCurrentPriceAsync(symbol);

        if (price is null)
            return null;

        var stockPrice = new StockPrice
        {
            Symbol = symbol.ToUpper(),
            Price = price.Value,
            Currency = "USD",
            RecordedAt = DateTime.UtcNow,
            Source = "Finnhub"
        };

        await _repository.AddAsync(stockPrice);

        return stockPrice;
    }

    public async Task DeleteAsync(int id)
    {
        await _repository.DeleteAsync(id);
    }
}
