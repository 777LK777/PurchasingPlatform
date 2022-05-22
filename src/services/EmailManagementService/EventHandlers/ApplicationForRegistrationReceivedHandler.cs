using Microsoft.AspNetCore.Mvc;

using EmailManagementService.Commands;

namespace EmailManagementService.EventHandlers;
public class ApplicationForRegistrationReceivedHandler : EventManagement.EventHandler
{
    private readonly ISendEmailCommand _sendEmailCommand;

    public ApplicationForRegistrationReceivedHandler(
        [FromServices] ISendEmailCommand sendEmailCommand)
    {
        _sendEmailCommand = sendEmailCommand;
    }

    public override async Task HandleAsync()
    {

    }
}