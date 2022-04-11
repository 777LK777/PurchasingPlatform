using FluentValidation;

using DTO.RestRequests;
using EventManagement.DI;
using Kernel.LoggingEngine;
using OrganizationService.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddTransient<IValidator<ApplicationForRegistrationRequest>, ApplicationForRegistrationRequestValidator>()
    .AddTransient<ILoggerProvider, LoggerProvider>()
    .AddEventPublisher()
    .AddLogging(log =>
    {
        log.ClearProviders();
    })
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
