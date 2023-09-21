using System.ComponentModel.DataAnnotations;
using Arnkels.OpenNexus.Domain.Common;

namespace Arnkels.OpenNexus.Domain.Entities;

public class Company : BaseEntity
{
    /// <summary>
    /// A Human Readable Identifier
    /// </summary>
    [MaxLength(50)]
    [Required]
    public string Identifier { get; set; }

    /// <summary>
    /// The Company's Name
    /// </summary>
    [MaxLength(100)]
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Navigation Property for the companies types
    /// </summary>
    public virtual List<CompanyType>? Types { get; } = new();

    /// <summary>
    /// Unique identifier for the companies status. Maps to the CompanyStatus Entity
    /// </summary>
    [Required]
    public Guid CompanyStatusId { get; set; }

    /// <summary>
    /// Navigation Property for the companies status
    /// </summary>
    public virtual CompanyStatus Status { get; set; }

    /// <summary>
    /// UUID for Companies parent company
    /// </summary>
    public Guid? ParentCompanyId { get; set; }

    /// <summary>
    /// Navigation Property for companies parent company
    /// </summary>
    public virtual Company? ParentCompany { get; set; }

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    public string? Zip { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? WebsiteUri { get; set; }
    public string? AccountNumber { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? YearEstablished { get; set; }
}