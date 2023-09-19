using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;

namespace Arnkels.OpenNexus.Application.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task SaveAsync(Company company)
    {
        if (company.Id == default(Guid))
        {
            await _companyRepository.CreateAsync(company);
        }
        else
        {
            await _companyRepository.ReplaceAsync(company);
        }
    }

    public async Task DeleteAsync(Company company)
    {
        await _companyRepository.DeleteAsync(company);
    }
}