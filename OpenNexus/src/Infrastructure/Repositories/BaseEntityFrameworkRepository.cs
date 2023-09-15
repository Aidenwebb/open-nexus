using Arnkels.OpenNexus.Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Infrastructure.Repositories;

public abstract class BaseEntityFrameworkRepository
{
    public BaseEntityFrameworkRepository(IServiceScopeFactory serviceScopeFactory)
    {
    }

    protected IServiceScopeFactory _serviceScopeFactory { get; private set; }

    public DatabaseContext GetDatabaseContext(IServiceScope serviceScope)
    {
        return serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
    }
}