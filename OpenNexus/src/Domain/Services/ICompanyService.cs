using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Services;

public interface ICompanyService
{
    Task SaveAsync(Company company);
    Task DeleteAsync(Company company);
}