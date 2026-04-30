# Financial Data Tracker

## Overview

Financial Data Tracker is a .NET Web API project developed for the Rasyonet Internship case study.

The application fetches current stock price data from Finnhub, stores the results in a local SQLite database, and provides basic CRUD and analytics endpoints through Swagger.

## Technologies

- .NET Web API
- Entity Framework Core
- SQLite
- Swagger
- Finnhub API
- Repository Pattern

## Features

- Add stock price records manually
- Fetch current stock prices from Finnhub
- Store price history in SQLite
- List all stock price records
- Filter stock prices by symbol
- Delete stock price records
- Calculate average price by symbol
- Get highest and lowest price by symbol

## Project Structure

```text
Controllers/     API endpoints
Data/            Database context
External/        Finnhub API client
Models/          Entity models
Repositories/    Database access layer
Services/        Business logic layer
