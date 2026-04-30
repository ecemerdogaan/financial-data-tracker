namespace FinancialDataTracker.Models;

public class StockPrice
{
    public int Id { get; set; }

    public string Symbol { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public string Currency { get; set; } = "USD";

    public DateTime RecordedAt { get; set; } = DateTime.UtcNow;

    public string Source { get; set; } = string.Empty;
}
