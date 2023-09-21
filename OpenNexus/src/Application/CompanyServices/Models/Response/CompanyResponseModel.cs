using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Models.Api;

namespace Arnkels.OpenNexus.Application.CompanyServices.Models.Response;

public class CompanyResponseModel : ResponseModel
{
    public CompanyResponseModel(Company company) : base("company")
    {
        if (company == null)
        {
            throw new ArgumentNullException(nameof(company));
        }

        Id = company.Id;
        Identifier = company.Identifier;
        Name = company.Name;
        Status = new CompanyStatusResponseModel(company.Status);
        Types = new List<CompanyType>(company.Types);
        AddressLine1 = company.AddressLine1;
        AddressLine2 = company.AddressLine2;
        AddressLine3 = company.AddressLine3;
        City = company.City;
        State = company.State;
        Country = company.Country;
        Zip = company.Zip;
        PhoneNumber = company.PhoneNumber;
        FaxNumber = company.FaxNumber;
        MobileNumber = company.MobileNumber;
        WebsiteUri = company.WebsiteUri;
        AccountNumber = company.AccountNumber;
        ParentCompany = company.ParentCompanyId == null ? null : new CompanyResponseModelMinimal(company.ParentCompany);
        AnnualRevenue = company.AnnualRevenue;
        NumberOfEmployees = company.NumberOfEmployees;
        YearEstablished = company.YearEstablished;
    }

    /// <summary>
    /// Internal Company Id
    /// </summary>
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
    public virtual CompanyStatusResponseModel Status { get; set; }

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
    public CompanyResponseModelMinimal? ParentCompany { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? YearEstablished { get; set; }
}

public class CompanyResponseModelMinimal : ResponseModel
{
    public CompanyResponseModelMinimal(Company company) : base("company")
    {
        Id = company.Id;
        Name = company.Name;
        Identifier = company.Identifier;
        Status = new CompanyStatusResponseModel(company.Status);
        ParentCompany = company.ParentCompanyId == null ? null : new CompanyResponseModelMinimal(company.ParentCompany);
    }

    /// <summary>
    /// Internal Company Id
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Company's Name
    /// </summary>
    public string Name { get; set; }

    public string Identifier { get; set; }

    /// <summary>
    /// Navigation Property for the companies status
    /// </summary>
    public virtual CompanyStatusResponseModel Status { get; set; }

    public CompanyResponseModelMinimal? ParentCompany { get; set; }
}