# Coure Assessment - Phone Country Detector API

A simple ASP.NET Core 10 API that answers two programming questions:
1. Score Calculator - Algorithm for calculating scores based on even/odd numbers and a special rule for 8
2. Phone Country Detector - Maps phone numbers to countries and their mobile operators

## Running the Project

```sh
dotnet run
```

The API will start on `https://localhost:7166` (or `http://localhost:5188` for HTTP)

## Endpoints

### Score Calculator

```
POST /api/score
Content-Type: application/json

{
  "numbers": [1, 2, 3, 4, 5]
}
```

Response: `{"score":11}`

### Phone Country Lookup

```
GET /api/phone/{phoneNumber}
```

Example: `GET /api/phone/2348012345678`

Response:

```json
{
  "number": "2348012345678",
  "country": {
    "countryCode": "234",
    "name": "Nigeria",
    "countryIso": "NG",
    "countryDetails": [
      { "operator": "MTN Nigeria", "operatorCode": "MTN NG" },
      { "operator": "Airtel Nigeria", "operatorCode": "ANG" },
      { "operator": "9Mobile Nigeria", "operatorCode": "ETN" },
      { "operator": "Globacom Nigeria", "operatorCode": "GLO NG" }
    ]
  }
}
```

## Architecture

The API uses a simple middleware pipeline:

1. **InputValidationMiddleware** - Validates phone number input using FluentValidation before the controller runs
2. **Controllers** - Thin controllers that route to services
3. **Services** - Business logic (country lookup)

Validation is centralized in middleware rather than scattered across controllers. The phone service focuses only on business logic.

## Key Features

- Input validation with FluentValidation
- Thin controller pattern (2-3 lines of logic)
- Clean separation of concerns
- OpenAPI/Swagger documentation at `/swagger`

## API Documentation

Visit `https://localhost:7166/swagger` for interactive API documentation where you can test both endpoints.
# CoureAssessment
