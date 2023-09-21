using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Queries.GetCompanyContactById;

public record GetCompanyContactByIdCommand : IRequest<CompanyContactDto>
{
    public Guid Id { get; set; }
}

public class GetCompanyContactByIdCommandHandler : IRequestHandler<GetCompanyContactByIdCommand, CompanyContactDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCompanyContactByIdCommandHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CompanyContactDto> Handle(GetCompanyContactByIdCommand request,
        CancellationToken cancellationToken)
    {
        var result = await _dbContext.CompanyContacts
            .Include(contact => contact.Company)
            .Include(contact => contact.Company.Status)
            .FirstOrDefaultAsync(contact => contact.Id == request.Id, cancellationToken: cancellationToken);

        return _mapper.Map<CompanyContactDto>(result);
    }
}