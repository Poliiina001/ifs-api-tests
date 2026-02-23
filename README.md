# IFS QA Automation Engineer – API Tests

Automated API test suite for JSONPlaceholder using .NET 8, NUnit and HttpClient.

## Prerequisites
- .NET SDK 8+ installed

## Configuration
Base URL is configured in:
`Config/appsettings.json`

## Run tests
From the project root:

```bash
dotnet restore
dotnet test
