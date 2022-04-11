using Microsoft.AspNetCore.Mvc;

using FluentValidation;

using EventManagement;
using DTO.Events;
using DTO.RestRequests;

namespace OrganizationService.Commands.Implementation;

public class ReceiveApplicationForRegistration : IReceiveApplicationForRegistration
{
    private readonly ILogger<ReceiveApplicationForRegistration> _logger;
    private readonly IValidator<ApplicationForRegistrationRequest> _validator;
    private readonly IEventPublisher _eventPublisher;

    public ReceiveApplicationForRegistration(
        [FromServices] IValidator<ApplicationForRegistrationRequest> validator,
        [FromServices] ILogger<ReceiveApplicationForRegistration>  logger,
        [FromServices] IEventPublisher eventPublisher)
    {
        _validator = validator;
        _logger = logger;
        _eventPublisher = eventPublisher;
    }
    public async Task ExecuteAsync(ApplicationForRegistrationRequest request)
    {
        _validator.ValidateAndThrow(request);

        var applicationForRegistrationReceived = new ApplicationForRegistrationReceived
        {
            Email = request.EMail
        };

        await _eventPublisher.PublishAsync(applicationForRegistrationReceived);
    }
}