using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.Common.Mappings;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Queries;

public record GetCompanyStatusByIdQuery : IRequest<CompanyStatusDto>
{
    public Guid Id { get; set; }
}

public class GetCompanyStatusByIdQueryHandler : IRequestHandler<GetCompanyStatusByIdQuery, CompanyStatusDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCompanyStatusByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CompanyStatusDto> Handle(GetCompanyStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.CompanyStatuses.FindAsync(request.Id);

        return _mapper.Map<CompanyStatusDto>(result);
    }
}