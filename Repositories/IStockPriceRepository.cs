using FinancialDataTracker.Models;

namespace FinancialDataTracker.Repositories;

public interface IStockPriceRepository
{
    Task<List<StockPrice>> GetAllAsync();
    Task<StockPrice?> GetByIdAsync(int id);
    Task<List<StockPrice>> GetBySymbolAsync(string symbol);
    Task AddAsync(StockPrice stockPrice);
    Task DeleteAsync(int id);
}
