using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompaniesWithPagination;

public class GetCompaniesWithPaginationQuery : IRequest<PaginatedList<CompanyDto>>
{
    public bool InactiveFlag { get; init; } = false;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetCompaniesWithPaginationHandler : IRequestHandler<GetCompaniesWithPaginationQuery, PaginatedList<CompanyDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCompaniesWithPaginationHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CompanyDto>> Handle(GetCompaniesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.Companies
            .Where(x => x.InactiveFlag == request.InactiveFlag)
            .OrderBy(x => x.Identifier)
            .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}