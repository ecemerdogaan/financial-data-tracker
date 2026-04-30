using FinancialDataTracker.Models;

namespace FinancialDataTracker.Services;

public interface IStockPriceService
{
    Task<List<StockPrice>> GetAllAsync();
    Task<List<StockPrice>> GetBySymbolAsync(string symbol);
    Task AddManualAsync(string symbol, decimal price, string currency);
    Task<StockPrice?> FetchAndSaveAsync(string symbol);
    Task DeleteAsync(int id);
}
