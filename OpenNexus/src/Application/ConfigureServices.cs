using System.Reflection;
using Arnkels.OpenNexus.Application.Common.Behaviours;
using Arnkels.OpenNexus.Application.Services;
using Arnkels.OpenNexus.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;


namespace Arnkels.OpenNexus.Application;

public static class ConfigureServices
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        });
        services.AddScoped<ICompanyService, CompanyService>();
        services.AddScoped<ICompanyStatusService, CompanyStatusService>();

        return services;
    }
}