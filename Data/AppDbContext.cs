using FinancialDataTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FinancialDataTracker.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<StockPrice> StockPrices => Set<StockPrice>();
}
