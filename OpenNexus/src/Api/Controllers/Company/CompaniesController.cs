using Arnkels.OpenNexus.Application.Companies.Models.Response;
using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyStatusRepository _companyStatusRepository;
    private readonly IMapper _mapper;

    public CompaniesController(ICompanyStatusRepository companyStatusRepository, ICompanyRepository companyRepository,
        IMapper mapper)
    {
        _companyStatusRepository = companyStatusRepository;
        _companyRepository = companyRepository;
        _mapper = mapper;
    }


    [HttpGet("")]
    public async Task<List<CompanyResponseModel>> GetCompanies()
    {
        var companies = await _companyRepository.GetManyAsync();

        List<CompanyResponseModel> responses = _mapper.Map<List<CompanyResponseModel>>(companies);

        return responses;
    }
}