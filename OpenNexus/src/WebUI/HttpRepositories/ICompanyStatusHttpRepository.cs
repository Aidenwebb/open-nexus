using Arnkels.OpenNexus.Application;
using Arnkels.OpenNexus.Application.CompanyServices.Models.ClientDto;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Request;

namespace Arnkels.OpenNexus.WebUI.HttpRepositories;

public interface ICompanyStatusHttpRepository
{
    Task<ListResponseDto<CompanyStatusDto>> GetCompanyStatuses();
    Task<CompanyStatusDto> GetCompanyStatusById(Guid id);
    Task DeleteCompanyStatusById(Guid id);
    Task SaveCompanyStatus(Guid id, CompanyStatusRequestModel model);
    Task<CompanyStatusDto> CreateCompanyStatus(CompanyStatusRequestModel model);
}