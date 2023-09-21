using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Models.Api;

namespace Arnkels.OpenNexus.Application.CompanyServices.Models.Response;

public class CompanyStatusResponseModel : ResponseModel
{
    public CompanyStatusResponseModel(CompanyStatus companyStatus) : base("companyStatus")
    {
        Id = companyStatus.Id;
        Name = companyStatus.Name;
        Description = companyStatus.Description;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}