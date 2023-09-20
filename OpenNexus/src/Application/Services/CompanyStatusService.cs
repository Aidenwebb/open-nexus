using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;

namespace Arnkels.OpenNexus.Application.Services;

public class CompanyStatusService : Service<CompanyStatus, Guid>, ICompanyStatusService
{
    private readonly ICompanyStatusRepository _companyStatusRepository;

    public CompanyStatusService(ICompanyStatusRepository companyStatusRepository) : base(companyStatusRepository)
    {
        _companyStatusRepository = companyStatusRepository;
    }
}