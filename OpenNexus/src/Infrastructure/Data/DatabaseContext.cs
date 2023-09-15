using Arnkels.OpenNexus.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Infrastructure.Data;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
    {
    }

    public DbSet<Company> Companies { get; set; }
    public DbSet<CompanyStatus> CompanyStatuses { get; set; }
    public DbSet<CompanyType> CompanyTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // CompanyStatuses
        modelBuilder.Entity<CompanyStatus>().HasData(new CompanyStatus
        {
            Id = Guid.Parse("68449c3e-1139-44f7-ab90-f5e7ef3a1963"),
            Description = "Company is a Lead",
            InactiveFlag = false,
            Name = "Lead"
        });

        modelBuilder.Entity<CompanyStatus>().HasData(new CompanyStatus
        {
            Id = Guid.Parse("e1c19b6a-5e68-4d0e-b4d7-2d3c7645124a"),
            Description = "Company is a Prospect",
            InactiveFlag = false,
            Name = "Prospect"
        });

        modelBuilder.Entity<CompanyStatus>().HasData(new CompanyStatus
        {
            Id = Guid.Parse("e558b52c-4a4d-439f-9773-12288307a367"),
            Description = "Company is a Customer",
            InactiveFlag = false,
            Name = "Customer"
        });

        // CompanyTypes

        modelBuilder.Entity<CompanyType>().HasData(new CompanyType
        {
            Id = Guid.Parse("51875687-c7be-4dfb-96ea-0899b48922da"),
            Description = "Limited Liability Company",
            Name = "Ltd"
        });

        modelBuilder.Entity<CompanyType>().HasData(new CompanyType
        {
            Id = Guid.Parse("fa6901f6-3a8e-4c23-86a8-1709473ea441"),
            Description = "Company is a Customer",
            Name = "Customer"
        });

        modelBuilder.Entity<CompanyType>().HasData(new CompanyType
        {
            Id = Guid.Parse("a2197c40-f01a-49d8-bd1b-3e5954617ff2"),
            Description = "Company is a Vendor",
            Name = "Vendor"
        });

        // Companies

        modelBuilder.Entity<Company>().HasData(new Company
        {
            Id = Guid.Parse("43acb1cd-bae8-4503-aa4a-c21e97459c02"),
            CompanyStatusId = Guid.Parse("68449c3e-1139-44f7-ab90-f5e7ef3a1963"),
            Name = "Acme",
            AccountNumber = "ACME001",
            NumberOfEmployees = 100
        });

        modelBuilder.Entity<Company>().HasData(new Company
        {
            Id = Guid.Parse("d5c2a80f-6bd4-49a8-80e4-d9230d1112ec"),
            CompanyStatusId = Guid.Parse("e558b52c-4a4d-439f-9773-12288307a367"),
            Name = "Contoso",
            AccountNumber = "CONT001",
            NumberOfEmployees = 50,
        });

        modelBuilder.Entity<Company>().HasData(new Company
        {
            Id = Guid.Parse("6b5e768a-7fc8-40ea-a087-84553c85f021"),
            CompanyStatusId = Guid.Parse("e1c19b6a-5e68-4d0e-b4d7-2d3c7645124a"),
            Name = "Greg Addams",
            AccountNumber = "GREG001",
            NumberOfEmployees = 1
        });
    }
}