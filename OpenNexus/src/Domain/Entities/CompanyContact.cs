using Arnkels.OpenNexus.Domain.Common;

namespace Arnkels.OpenNexus.Domain.Entities;

public class CompanyContact : BaseEntity
{
    public Guid CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public string FirstName { get; set; }
    public string LastName { get; set; }
}