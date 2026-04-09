using FluentValidation;
using System.Net;

namespace CoureAssessment.Middleware
{
    public class InputValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public InputValidationMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task InvokeAsync(HttpContext context, IValidator<string> phoneValidator)
        {
            if (context.Request.Path.StartsWithSegments("/api/phone"))
            {
                var phoneNumber = context.Request.RouteValues["phoneNumber"]?.ToString();

                if (phoneNumber != null)
                {
                    var validationResult = await phoneValidator.ValidateAsync(phoneNumber);

                    if (!validationResult.IsValid)
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        context.Response.ContentType = "application/json";

                        var errorResponse = new
                        {
                            error = "Validation failed",
                            details = validationResult.Errors
                                .Select(e => new { message = e.ErrorMessage })
                                .ToList()
                        };

                        await context.Response.WriteAsJsonAsync(errorResponse);
                        return;
                    }
                }
            }

            await _next(context);
        }
    }
}
