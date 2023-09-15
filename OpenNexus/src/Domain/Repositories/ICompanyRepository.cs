using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Repositories;

public interface ICompanyRepository : IRepository<Company, Guid>
{
    public Task<ICollection<Company>> GetManyAsync();
}