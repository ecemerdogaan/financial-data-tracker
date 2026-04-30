using FinancialDataTracker.Data;
using FinancialDataTracker.Repositories;
using FinancialDataTracker.Services;
using Microsoft.EntityFrameworkCore;
using FinancialDataTracker.External;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=stocks.db"));

builder.Services.AddScoped<IStockPriceRepository, StockPriceRepository>();
builder.Services.AddScoped<IStockPriceService, StockPriceService>();
builder.Services.AddHttpClient<FinnhubClient>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
