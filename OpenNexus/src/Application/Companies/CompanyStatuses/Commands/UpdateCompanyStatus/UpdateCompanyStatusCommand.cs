using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Commands.UpdateCompanyStatus;

public record UpdateCompanyStatusCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class UpdateCompanyStatusCommandHandler : IRequestHandler<UpdateCompanyStatusCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateCompanyStatusCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(UpdateCompanyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.CompanyStatuses
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(CompanyStatus), request.Id);
        }

        entity.Name = request.Name;
        entity.Description = request.Description;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}