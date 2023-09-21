using Arnkels.OpenNexus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Company> Companies { get; }
    DbSet<CompanyStatus> CompanyStatuses { get; }
    DbSet<CompanyType> CompanyTypes { get; }

    Task<Guid> SaveChangesAsync(CancellationToken cancellationToken);
}