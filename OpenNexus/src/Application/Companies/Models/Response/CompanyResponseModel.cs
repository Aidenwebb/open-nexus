using AutoMapper;
using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Models.Api;

namespace Arnkels.OpenNexus.Application.Companies.Models.Response;

public class CompanyResponseModel : ResponseModel
{
    public CompanyResponseModel() : base("company")
    {
    }

    /// <summary>
    /// The Company's Name
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Navigation Property for the companies types
    /// </summary>
    public virtual List<CompanyType>? Types { get; } = new();

    /// <summary>
    /// Unique identifier for the companies status. Maps to the CompanyStatus Entity
    /// </summary>
    public Guid CompanyStatusId { get; set; }

    /// <summary>
    /// Navigation Property for the companies status
    /// </summary>
    public virtual CompanyStatus Status { get; set; }

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? PostCode { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? WebsiteUri { get; set; }
    public string? AccountNumber { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? YearEstablished { get; set; }
}

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<Company, CompanyResponseModel>().ReverseMap();
    }
}