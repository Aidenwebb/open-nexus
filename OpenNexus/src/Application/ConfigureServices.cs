using System.Reflection;
using Arnkels.OpenNexus.Application.Services;
using Arnkels.OpenNexus.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyStatusService, CompanyStatusService>();

        return services;
    }
}