using DTO.Events;
using EventManagement.DI.Extensions;
using Kernel.OperationResultUtils.DI;

using EmailManagementService.EventHandlers;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOperationResultWrapper()
    .AddEventManager(cfg => {
        cfg.AddEventConsumer<ApplicationForRegistrationReceivedHandler, ApplicationForRegistrationReceived>();
    });

var app = builder.Build();

app.Run();
