using FinancialDataTracker.Data;
using FinancialDataTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialDataTracker.Repositories;

// Repository Pattern: Database işlemlerini controller'dan ayırmak için kullanıldı.
public class StockPriceRepository : IStockPriceRepository
{
    private readonly AppDbContext _context;

    public StockPriceRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<StockPrice>> GetAllAsync()
    {
        return await _context.StockPrices
            .OrderByDescending(x => x.RecordedAt)
            .ToListAsync();
    }

    public async Task<StockPrice?> GetByIdAsync(int id)
    {
        return await _context.StockPrices.FindAsync(id);
    }

    public async Task<List<StockPrice>> GetBySymbolAsync(string symbol)
    {
        return await _context.StockPrices
            .Where(x => x.Symbol.ToUpper() == symbol.ToUpper())
            .OrderByDescending(x => x.RecordedAt)
            .ToListAsync();
    }

    public async Task AddAsync(StockPrice stockPrice)
    {
        await _context.StockPrices.AddAsync(stockPrice);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var stockPrice = await _context.StockPrices.FindAsync(id);

        if (stockPrice is null)
            return;

        _context.StockPrices.Remove(stockPrice);
        await _context.SaveChangesAsync();
    }
}
