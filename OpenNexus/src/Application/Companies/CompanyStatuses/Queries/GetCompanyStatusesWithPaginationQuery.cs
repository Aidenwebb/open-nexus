using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;

namespace Arnkels.OpenNexus.Application.Companies.CompanyStatuses.Queries;

public class GetCompanyStatusesWithPaginationQuery : IRequest<PaginatedList<CompanyStatusDto>>
{
    public bool InactiveFlag { get; init; } = false;
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class
    GetCompanyStatusItemsWithPaginationHandler : IRequestHandler<GetCompanyStatusesWithPaginationQuery,
        PaginatedList<CompanyStatusDto>>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCompanyStatusItemsWithPaginationHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }


    public async Task<PaginatedList<CompanyStatusDto>> Handle(GetCompanyStatusesWithPaginationQuery request,
        CancellationToken cancellationToken)
    {
        return await _dbContext.CompanyStatuses
            .Where(x => x.InactiveFlag == request.InactiveFlag)
            .OrderBy(x => x.Name)
            .ProjectTo<CompanyStatusDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}