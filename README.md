# Financial Data Tracker

A simple .NET Web API project developed for the Rasyonet Internship assignment.

The application fetches stock price data from the Finnhub API, stores it in a SQLite database, and provides basic CRUD and analytics endpoints.

## Technologies Used

- .NET Web API
- Entity Framework Core
- SQLite
- Swagger
- Finnhub API
- Repository Pattern

## Features

- Add stock price manually
- Fetch current stock price from Finnhub API
- Store stock price records in SQLite
- List all stock price records
- Filter records by stock symbol
- Delete stock price records
- Calculate average price by symbol
- Get highest price by symbol
- Get lowest price by symbol

## Project Structure

```text
Controllers/
Data/
DTOs/
External/
Models/
Repositories/
Services/
