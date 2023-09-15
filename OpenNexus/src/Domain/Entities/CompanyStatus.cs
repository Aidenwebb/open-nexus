using System.ComponentModel.DataAnnotations;

namespace Arnkels.OpenNexus.Domain.Entities;

public class CompanyStatus : BaseEntity
{
    [MaxLength(50)] public string Name { get; set; }

    [MaxLength(255)] public string Description { get; set; }
}