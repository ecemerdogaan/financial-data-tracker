using FinancialDataTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialDataTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly IStockPriceService _service;

    public AnalyticsController(IStockPriceService service)
    {
        _service = service;
    }

    [HttpGet("average/{symbol}")]
    public async Task<IActionResult> GetAveragePrice(string symbol)
    {
        var prices = await _service.GetBySymbolAsync(symbol);

        if (!prices.Any())
            return NotFound(new { message = "No price data found for this symbol." });

        return Ok(new
        {
            symbol = symbol.ToUpper(),
            averagePrice = prices.Average(x => x.Price),
            recordCount = prices.Count
        });
    }

    [HttpGet("highest/{symbol}")]
    public async Task<IActionResult> GetHighestPrice(string symbol)
    {
        var prices = await _service.GetBySymbolAsync(symbol);

        if (!prices.Any())
            return NotFound(new { message = "No price data found for this symbol." });

        var highest = prices.OrderByDescending(x => x.Price).First();

        return Ok(highest);
    }

    [HttpGet("lowest/{symbol}")]
    public async Task<IActionResult> GetLowestPrice(string symbol)
    {
        var prices = await _service.GetBySymbolAsync(symbol);

        if (!prices.Any())
            return NotFound(new { message = "No price data found for this symbol." });

        var lowest = prices.OrderBy(x => x.Price).First();

        return Ok(lowest);
    }
}
