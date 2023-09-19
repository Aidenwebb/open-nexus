using System.ComponentModel.DataAnnotations;
using Arnkels.OpenNexus.Domain.Entities;
using AutoMapper;

namespace Arnkels.OpenNexus.Application.Companies.Models.Request;

public class CompanyRequestModel
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
    /// Unique identifier for the companies status. Maps to the CompanyStatus Entity
    /// </summary>
    // public Guid CompanyStatusId { get; set; }

    public CompanyStatusNestedRequestModel Status { get; set; }

    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? WebsiteUri { get; set; }
    public string? AccountNumber { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? YearEstablished { get; set; }

    public Company ToCompany()
    {
        return ToCompany(new Company());
    }

    public Company ToCompany(Company existingCompany)
    {
        existingCompany.Identifier = Identifier;
        existingCompany.Name = Name;
        existingCompany.CompanyStatusId = Status.Id;
        existingCompany.AddressLine1 = AddressLine1;
        existingCompany.AddressLine2 = AddressLine2;
        existingCompany.AddressLine3 = AddressLine3;
        existingCompany.City = City;
        existingCompany.Country = Country;
        existingCompany.State = State;
        existingCompany.Zip = Zip;
        existingCompany.PhoneNumber = PhoneNumber;
        existingCompany.FaxNumber = FaxNumber;
        existingCompany.MobileNumber = MobileNumber;
        existingCompany.WebsiteUri = WebsiteUri;
        existingCompany.AccountNumber = AccountNumber;
        existingCompany.NumberOfEmployees = NumberOfEmployees;
        existingCompany.AnnualRevenue = AnnualRevenue;
        existingCompany.YearEstablished = YearEstablished;
        return existingCompany;
    }
}

public class CompanyStatusNestedRequestModel
{
    [Required] public Guid Id { get; set; }
}