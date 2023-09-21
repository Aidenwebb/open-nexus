using Arnkels.OpenNexus.Application;
using Arnkels.OpenNexus.Application.Companies.Models.ClientDto;
using Arnkels.OpenNexus.Application.Companies.Models.Request;
using Arnkels.OpenNexus.Application.Companies.Models.Response;

namespace Arnkels.OpenNexus.WebUI.HttpRepositories;

public interface ICompanyStatusHttpRepository
{
    Task<ListResponseDto<CompanyStatusDto>> GetCompanyStatuses();
    Task<CompanyStatusDto> GetCompanyStatusById(Guid id);
    Task DeleteCompanyStatusById(Guid id);
    Task SaveCompanyStatus(Guid id, CompanyStatusRequestModel model);
    Task<CompanyStatusDto> CreateCompanyStatus(CompanyStatusRequestModel model);
}