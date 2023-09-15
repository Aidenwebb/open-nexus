using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Infrastructure.Repositories;

public class CompanyStatusRepository : Repository<CompanyStatus, Guid>, ICompanyStatusRepository
{
    public CompanyStatusRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory,
        (DatabaseContext context) => context.CompanyStatuses)
    {
    }

    public async Task<ICollection<CompanyStatus>> GetManyAsync()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var query = dbContext.CompanyStatuses;
            var companies = await query.ToListAsync();
            return companies;
        }
    }
}