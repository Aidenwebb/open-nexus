using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities;
using MediatR;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Commands.DeleteCompanyStatus;

public record DeleteCompanyStatusCommand(Guid Id) : IRequest;

public class DeleteCompanyStatusCommandHandler : IRequestHandler<DeleteCompanyStatusCommand>

{
    private readonly IApplicationDbContext _dbContext;

    public DeleteCompanyStatusCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task Handle(DeleteCompanyStatusCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.CompanyStatuses.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(CompanyStatus), request.Id);
        }

        _dbContext.CompanyStatuses.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}