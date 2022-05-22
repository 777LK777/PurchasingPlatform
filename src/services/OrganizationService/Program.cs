using FluentValidation;

using DTO.RestRequests;
using Kernel.LoggingEngine;
using EventManagement.DI.Extensions;
using OrganizationService.Validators;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddTransient<IValidator<ApplicationForRegistrationRequest>, ApplicationForRegistrationRequestValidator>()
    .AddTransient<ILoggerProvider, LoggerProvider>()
    .AddEventManager(cfg =>
        cfg.AddEventPublisher()
    )
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
