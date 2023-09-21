using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;

public class CompanyStatusDto : IMapFrom<CompanyStatus>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}