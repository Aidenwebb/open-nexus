using Arnkels.OpenNexus.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.CreateCompany;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateCompanyCommandValidator(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        RuleFor(v => v.Identifier)
            .NotEmpty().WithMessage("Identifier is Required")
            .Matches("^[^£# “”]*$")
            .WithMessage("'{PropertyName}' must not contain the following characters £ # “” or spaces.")
            .MustAsync(BeUniqueIdentifier).WithMessage("The specified Identifier already exists.");

        RuleForEach(v => v.Name)
            .NotEmpty().WithMessage("'{PropertyName} is Required");
    }

    public async Task<bool> BeUniqueIdentifier(string identifier, CancellationToken cancellationToken)
    {
        return await _dbContext.Companies
            .AllAsync(l => l.Identifier != identifier, cancellationToken);
    }
}