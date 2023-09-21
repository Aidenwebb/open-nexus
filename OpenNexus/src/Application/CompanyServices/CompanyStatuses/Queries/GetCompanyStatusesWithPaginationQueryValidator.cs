using FluentValidation;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;

public class GetCompanyStatusesWithPaginationQueryValidator : AbstractValidator<GetCompanyStatusesWithPaginationQuery>
{
    public GetCompanyStatusesWithPaginationQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}