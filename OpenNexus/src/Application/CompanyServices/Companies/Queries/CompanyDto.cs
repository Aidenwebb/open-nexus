using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;

public class CompanyDto : IMapFrom<Company>
{
    public Guid Id { get; set; }

    /// <summary>
    /// A Human Readable Identifier
    /// </summary>
    public string Identifier { get; set; }

    /// <summary>
    /// The Company's Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Navigation Property for the companies status
    /// </summary>
    public virtual CompanyStatusDto Status { get; set; }

    /// <summary>
    /// Navigation Property for the companies types
    /// </summary>
    public virtual List<CompanyType>? Types { get; set; }

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
    public virtual ParentCompanyDto? ParentCompany { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? YearEstablished { get; set; }
}