using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.DeleteCompany;

public record DeleteCompanyCommand(Guid Id) : IRequest
{
}

public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteCompanyCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Companies.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Company), request.Id);
        }

        _dbContext.Companies.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}