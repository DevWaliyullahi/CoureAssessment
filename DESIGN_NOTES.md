# Design Approach

## Middleware for Validation

I put validation logic in middleware rather than in the controller. This keeps validation centralized and happens before the controller even runs. If validation fails, the request gets rejected with a 400 error before the controller is invoked.

With middleware, validation happens once - not scattered across multiple controllers or endpoints.

## FluentValidation

FluentValidation defines the validation rules declaratively:

```csharp
RuleFor(phone => phone)
    .NotEmpty()
    .MaximumLength(20)
    .Matches(@"^\d+$")
    .WithMessage("Phone number must contain only digits");
```

It's cleaner and more maintainable than multiple if statements in a controller.

## Thin Controllers

The controllers just route to services - no validation logic, no business logic:

```csharp
[HttpGet("{phoneNumber}")]
public IActionResult Get(string phoneNumber)
{
    var result = _service.GetCountryByPhone(phoneNumber);
    return result == null ? NotFound(...) : Ok(result);
}
```

Two lines of code. That's it. The controller's job is routing, not validation or business logic.

## Service Layer

The `PhoneService` has one responsibility: look up a country by phone number. It doesn't validate input (middleware does that), doesn't format responses (controller does that). Just business logic.

## Why This Design

- **Single responsibility** - Each class does one thing
- **Testable** - Components are independent
- **Maintainable** - Changes to one layer don't affect others


