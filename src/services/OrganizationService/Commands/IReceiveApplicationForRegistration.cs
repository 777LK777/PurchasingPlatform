using System;
using DTO.RestRequests;

namespace OrganizationService.Commands;

public interface IReceiveApplicationForRegistration
{
    Task ExecuteAsync(ApplicationForRegistrationRequest applicationForRegistration);
}