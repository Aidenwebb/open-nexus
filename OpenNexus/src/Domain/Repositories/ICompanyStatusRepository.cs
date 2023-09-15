using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Repositories;

public interface ICompanyStatusRepository : IRepository<CompanyStatus, Guid>
{
    public Task<ICollection<CompanyStatus>> GetManyAsync();
}