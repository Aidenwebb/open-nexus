namespace Arnkels.OpenNexus.Domain.Entities;

public class BaseAuditableEntity : BaseEntity
{
    public DateTime Created { get; set; }
    public DateTime LastModified { get; set; }
}