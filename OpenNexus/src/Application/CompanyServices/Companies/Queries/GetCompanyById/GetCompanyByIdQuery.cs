using Arnkels.OpenNexus.Application.Common.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompanyById;

public record GetCompanyByIdQuery : IRequest<CompanyDto>
{
    public Guid Id { get; set; }
}

public class GetCompanybyIdHandler : IRequestHandler<GetCompanyByIdQuery, CompanyDto>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetCompanybyIdHandler(IApplicationDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(GetCompanyByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await _dbContext.Companies
            .Include(company => company.Status)
            .Include(company => company.ParentCompany)
            .FirstOrDefaultAsync(company => company.Id == request.Id);

        return _mapper.Map<CompanyDto>(result);
    }
}