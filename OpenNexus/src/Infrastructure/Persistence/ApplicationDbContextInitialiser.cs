using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Arnkels.OpenNexus.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger,
        ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_dbContext.Database.IsNpgsql())
            {
                await _dbContext.Database.MigrateAsync();
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occurred while seeding the database");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary

        // CompanyStatuses
        if (!_dbContext.CompanyStatuses.Any())
        {
            _dbContext.CompanyStatuses.Add(new CompanyStatus
            {
                Id = Guid.Parse("018ab325-8686-4373-b458-031ac61139ed"),
                Description = "Company is a Lead",
                InactiveFlag = false,
                Name = "Lead"
            });
            _dbContext.CompanyStatuses.Add(new CompanyStatus
            {
                Id = Guid.Parse("018ab325-db68-441d-be32-84435167f043"),
                Description = "Company is a Prospect",
                InactiveFlag = false,
                Name = "Prospect"
            });
            _dbContext.CompanyStatuses.Add(new CompanyStatus
            {
                Id = Guid.Parse("018ab326-1aa9-40da-8da8-81f0ac2d6aa5"),
                Description = "Company is a Customer",
                InactiveFlag = false,
                Name = "Customer"
            });
        }

        // Companies
        if (!_dbContext.Companies.Any())
        {
            _dbContext.Companies.Add(new Company
            {
                Id = Guid.Parse("43acb1cd-bae8-4503-aa4a-c21e97459c02"),
                CompanyStatusId = Guid.Parse("018ab325-8686-4373-b458-031ac61139ed"),
                Name = "Acme",
                Identifier = "acme",
                AccountNumber = "ACME001",
                NumberOfEmployees = 100
            });

            _dbContext.Companies.Add(new Company
            {
                Id = Guid.Parse("d5c2a80f-6bd4-49a8-80e4-d9230d1112ec"),
                CompanyStatusId = Guid.Parse("018ab325-db68-441d-be32-84435167f043"),
                Name = "Contoso",
                Identifier = "contoso",
                AccountNumber = "CONT001",
                ParentCompanyId = Guid.Parse("43acb1cd-bae8-4503-aa4a-c21e97459c02"),
                NumberOfEmployees = 50,
            });

            _dbContext.Companies.Add(new Company
            {
                Id = Guid.Parse("6b5e768a-7fc8-40ea-a087-84553c85f021"),
                CompanyStatusId = Guid.Parse("018ab326-1aa9-40da-8da8-81f0ac2d6aa5"),
                Name = "Greg Addams",
                Identifier = "greg_addams",
                AccountNumber = "GREG001",
                ParentCompanyId = Guid.Parse("d5c2a80f-6bd4-49a8-80e4-d9230d1112ec"),
                NumberOfEmployees = 1
            });
        }

        await _dbContext.SaveChangesAsync();
    }
}