using System.ComponentModel.DataAnnotations;
using Arnkels.OpenNexus.Domain.Common;

namespace Arnkels.OpenNexus.Domain.Entities;

public class CompanyType : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(255)] public string Description { get; set; }

    public virtual List<Company>? Companies { get; } = new();
}