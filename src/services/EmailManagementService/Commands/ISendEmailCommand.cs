using DTO.Events;

namespace EmailManagementService.Commands;

public interface ISendEmailCommand
{
    Task Execute(ApplicationForRegistrationReceived mailAddress);
}