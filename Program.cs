using CoureAssessment.Middleware;
using CoureAssessment.Services;
using CoureAssessment.Validators;
using FluentValidation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddScoped<IPhoneService, PhoneService>();

// Add Swagger
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Coure Assessment API",
        Version = "v1",
        Description = "Phone country detector and score calculator API"
    });
});

// Register Fluent Validation
builder.Services.AddValidatorsFromAssemblyContaining<PhoneNumberValidator>();

var app = builder.Build();

// Add input validation middleware
app.UseMiddleware<InputValidationMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Coure Assessment API v1");
        options.RoutePrefix = "swagger";
    });
}

app.MapGet("/", () => Results.Redirect("/swagger"))
   .ExcludeFromDescription();

app.MapControllers();

app.Run();