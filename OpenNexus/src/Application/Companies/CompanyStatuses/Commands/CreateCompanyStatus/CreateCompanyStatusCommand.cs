using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Commands.CreateCompanyStatus;

// Request Model
public record CreateCompanyStatusCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class CreateCompanyStatusCommandHandler : IRequestHandler<CreateCompanyStatusCommand, Guid>

{
    private readonly IApplicationDbContext _dbContext;

    public CreateCompanyStatusCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateCompanyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = new CompanyStatus
        {
            Name = request.Name,
            Description = request.Description
        };

        _dbContext.CompanyStatuses.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}