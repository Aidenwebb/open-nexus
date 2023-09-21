using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Infrastructure.Data;
using Arnkels.OpenNexus.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<DatabaseContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("DefaultConnectionString");
            options.UseNpgsql(connectionString,
                    builder => builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName))
                // For Dev
                // .ConfigureWarnings(b =>
                // {
                //     b.Throw(CoreEventId.NavigationLazyLoading);
                //     b.Throw(CoreEventId.DetachedLazyLoadingWarning);
                //     b.Throw(CoreEventId.LazyLoadOnDisposedContextWarning);
                // })
                ;
        });

        services.AddScoped<ICompanyStatusRepository, CompanyStatusRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();

        return services;
    }
}