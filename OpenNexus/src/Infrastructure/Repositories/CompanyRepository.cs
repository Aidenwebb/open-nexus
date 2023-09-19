using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Infrastructure.Repositories;

public class CompanyRepository : Repository<Company, Guid>, ICompanyRepository
{
    public CompanyRepository(IServiceScopeFactory serviceScopeFactory) : base(serviceScopeFactory,
        (DatabaseContext context) => context.Companies)
    {
    }

    public async Task<ICollection<Company>> GetManyAsync()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var query = dbContext.Companies
                .Include(company => company.Status)
                .Include(company => company.ParentCompany);
            var companies = await query.ToListAsync();
            return companies;
        }
    }

    public async override Task<Company> GetByIdAsync(Guid id)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var company = await dbContext.Companies
                .Include(company => company.Status)
                .Include(company => company.ParentCompany)
                .FirstOrDefaultAsync(company => company.Id == id);
            return company;
        }
    }
}