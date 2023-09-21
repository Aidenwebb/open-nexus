using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;

public class ParentCompanyDto : IMapFrom<Company>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Identifier { get; set; }
    public virtual CompanyStatusDto Status { get; set; }
}