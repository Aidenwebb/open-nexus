using Arnkels.OpenNexus.Application.Common.Interfaces;
using AutoMapper;
using MediatR;

namespace Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;

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