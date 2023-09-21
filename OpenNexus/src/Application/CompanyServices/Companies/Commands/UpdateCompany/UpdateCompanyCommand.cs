using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.UpdateCompany;

public record UpdateCompanyCommand : IRequest
{
    public Guid Id { get; init; }
    public string Identifier { get; init; }
    public string Name { get; init; }
    public Guid CompanyStatusId { get; init; }
    public string? AddressLine1 { get; init; }
    public string? AddressLine2 { get; init; }
    public string? AddressLine3 { get; init; }
    public string? City { get; init; }
    public string? Country { get; init; }
    public string? State { get; init; }
    public string? Zip { get; init; }
    public string? PhoneNumber { get; init; }
    public string? FaxNumber { get; init; }
    public string? MobileNumber { get; init; }
    public string? WebsiteUri { get; init; }
    public string? AccountNumber { get; init; }
    public Guid? ParentCompanyId { get; init; }
    public int? NumberOfEmployees { get; init; }
    public int? AnnualRevenue { get; init; }
    public int? YearEstablished { get; init; }
}

public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateCompanyCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Companies.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Company), request.Id);
        }

        entity.Identifier = request.Identifier;
        entity.Name = request.Name;
        entity.CompanyStatusId = request.CompanyStatusId;
        entity.AddressLine1 = request.AddressLine1;
        entity.AddressLine2 = request.AddressLine2;
        entity.AddressLine3 = request.AddressLine3;
        entity.City = request.City;
        entity.Country = request.Country;
        entity.State = request.State;
        entity.Zip = request.Zip;
        entity.PhoneNumber = request.PhoneNumber;
        entity.FaxNumber = request.FaxNumber;
        entity.MobileNumber = request.MobileNumber;
        entity.WebsiteUri = request.WebsiteUri;
        entity.AccountNumber = request.AccountNumber;
        entity.ParentCompanyId = request.ParentCompanyId;
        entity.NumberOfEmployees = request.NumberOfEmployees;
        entity.AnnualRevenue = request.AnnualRevenue;
        entity.YearEstablished = request.YearEstablished;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}