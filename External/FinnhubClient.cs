using System.Text.Json;

namespace FinancialDataTracker.External;

public class FinnhubClient
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public FinnhubClient(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<decimal?> GetCurrentPriceAsync(string symbol)
    {
        var baseUrl = _configuration["Finnhub:BaseUrl"];
        var apiKey = _configuration["Finnhub:ApiKey"];

        var url = $"{baseUrl}/quote?symbol={symbol.ToUpper()}&token={apiKey}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(json);

        var currentPrice = document.RootElement.GetProperty("c").GetDecimal();

        if (currentPrice <= 0)
            return null;

        return currentPrice;
    }
}
