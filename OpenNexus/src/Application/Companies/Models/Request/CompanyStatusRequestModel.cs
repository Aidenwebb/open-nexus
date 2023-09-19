using Arnkels.OpenNexus.Domain.Entities;
using AutoMapper;

namespace Arnkels.OpenNexus.Application.Companies.Models.Request;

public class CompanyStatusRequestModel
{
    public string Name { get; set; }
    public string? Description { get; set; }

    public CompanyStatus ToCompanyStatus()
    {
        return ToCompanyStatus(new CompanyStatus());
    }

    public CompanyStatus ToCompanyStatus(CompanyStatus existingCompanyStatus)
    {
        existingCompanyStatus.Name = Name;
        existingCompanyStatus.Description = Description;
        return existingCompanyStatus;
    }
}