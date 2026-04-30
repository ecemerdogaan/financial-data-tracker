using FinancialDataTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace FinancialDataTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockPricesController : ControllerBase
{
    private readonly IStockPriceService _service;

    public StockPricesController(IStockPriceService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var stockPrices = await _service.GetAllAsync();
        return Ok(stockPrices);
    }

    [HttpGet("{symbol}")]
    public async Task<IActionResult> GetBySymbol(string symbol)
    {
        var stockPrices = await _service.GetBySymbolAsync(symbol);
        return Ok(stockPrices);
    }

    [HttpPost("manual")]
    public async Task<IActionResult> AddManual(string symbol, decimal price, string currency = "USD")
    {
        await _service.AddManualAsync(symbol, price, currency);
        return Ok(new { message = "Stock price added successfully." });
    }

    [HttpPost("fetch/{symbol}")]
    public async Task<IActionResult> FetchAndSave(string symbol)
    {
        var stockPrice = await _service.FetchAndSaveAsync(symbol);

        if (stockPrice is null)
            return BadRequest(new { message = "Price could not be fetched. Please check the symbol or API key." });

        return Ok(stockPrice);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return Ok(new { message = "Stock price deleted successfully." });
    }
}
