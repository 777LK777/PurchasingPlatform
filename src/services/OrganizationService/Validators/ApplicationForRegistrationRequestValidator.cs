using FluentValidation;

using DTO.RestRequests;

namespace OrganizationService.Validators;

public class ApplicationForRegistrationRequestValidator : AbstractValidator<ApplicationForRegistrationRequest>
{
    public ApplicationForRegistrationRequestValidator()
    {
        // TODO: добавить проверку на мэйл паттерн
        RuleFor(x => x.EMail).NotEmpty();
    }
}