using FluentValidation;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Commands.CreateCompanyStatus;

public class CreateCompanyStatusCommandValidator : AbstractValidator<CreateCompanyStatusCommand>
{
    public CreateCompanyStatusCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(255);
    }
}