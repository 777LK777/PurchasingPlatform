using Microsoft.AspNetCore.Mvc;

using DTO.RestRequests;
using OrganizationService.Commands;

namespace OrganizationService.Controllers;

[ApiController]
[Route("[controller]")]
public class OrganizationController : ControllerBase
{
    private readonly ILogger<OrganizationController> _logger;

    public OrganizationController([FromServices] ILogger<OrganizationController> logger)
    {
        _logger = logger;
    }

    [Route("forRegistration")]
    [HttpPost]
    public async Task ReceiveApplicationForRegistration(
        [FromServices] IReceiveApplicationForRegistration command,
        [FromBody] ApplicationForRegistrationRequest request
    )
    {        
        _logger.LogInformation("Received application for registration from Client to OrganizationService");
        await command.ExecuteAsync(request);
    }
}