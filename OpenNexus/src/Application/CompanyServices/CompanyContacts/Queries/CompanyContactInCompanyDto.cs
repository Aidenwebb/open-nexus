using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Queries;

public class CompanyContactInCompanyDto : IMapFrom<CompanyContact>
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}