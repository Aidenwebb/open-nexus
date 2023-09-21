using Arnkels.OpenNexus.Application.Common.Interfaces;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.CreateCompany;

// Request Model
public record CreateCompanyCommand : IRequest<Guid>
{
    public string Identifier { get; set; }
    public string Name { get; set; }
    public Guid CompanyStatusId { get; set; }
    public string? AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? AddressLine3 { get; set; }
    public string? City { get; set; }
    public string? Country { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? PhoneNumber { get; set; }
    public string? FaxNumber { get; set; }
    public string? MobileNumber { get; set; }
    public string? WebsiteUri { get; set; }
    public string? AccountNumber { get; set; }
    public Guid? ParentCompanyId { get; set; }
    public int? NumberOfEmployees { get; set; }
    public int? AnnualRevenue { get; set; }
    public int? YearEstablished { get; set; }
}

public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, Guid>
{
    private readonly IApplicationDbContext _context;

    public CreateCompanyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }


    public async Task<Guid> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = new Domain.Entities.Company
        {
            Identifier = request.Identifier,
            Name = request.Name,
            CompanyStatusId = request.CompanyStatusId,
            AddressLine1 = request.AddressLine1,
            AddressLine2 = request.AddressLine2,
            AddressLine3 = request.AddressLine3,
            City = request.City,
            Country = request.Country,
            State = request.State,
            Zip = request.Zip,
            PhoneNumber = request.PhoneNumber,
            FaxNumber = request.FaxNumber,
            MobileNumber = request.MobileNumber,
            WebsiteUri = request.WebsiteUri,
            AccountNumber = request.AccountNumber,
            ParentCompanyId = request.ParentCompanyId,
            NumberOfEmployees = request.NumberOfEmployees,
            AnnualRevenue = request.AnnualRevenue,
            YearEstablished = request.YearEstablished
        };

        entity.SetNewId();

        _context.Companies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}