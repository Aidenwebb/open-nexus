using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Commands.CreateCompanyContact;

public record CreateCompanyContactCommand : IRequest<Guid>
{
    public Guid CompanyId { get; set; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
}

public class CreateCompanyContactCommandHandler : IRequestHandler<CreateCompanyContactCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateCompanyContactCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateCompanyContactCommand request, CancellationToken cancellationToken)
    {
        var entity = new CompanyContact
        {
            CompanyId = request.CompanyId,
            FirstName = request.FirstName,
            LastName = request.LastName
        };

        entity.SetNewId();

        _dbContext.CompanyContacts.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}