using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;

namespace Arnkels.OpenNexus.Application.Services;

public class CompanyService : Service<Company, Guid>, ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository) : base(companyRepository)
    {
        _companyRepository = companyRepository;
    }
}