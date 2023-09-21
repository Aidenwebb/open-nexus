using FluentValidation;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Commands.UpdateCompanyStatus;

public class UpdateCompanyStatusCommandValidator : AbstractValidator<UpdateCompanyStatusCommand>
{
    public UpdateCompanyStatusCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(50)
            .NotEmpty();
        RuleFor(v => v.Description)
            .MaximumLength(255);
    }
}