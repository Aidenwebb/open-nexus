using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Queries;

public class CompanyContactDto : IMapFrom<CompanyContact>
{
    public Guid Id { get; init; }
    public Guid CompanyId { get; init; }
    public ParentCompanyDto Company { get; init; } = null!;
    public string FirstName { get; init; }
    public string LastName { get; init; }
}