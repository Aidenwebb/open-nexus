using System.Collections;
using Arnkels.OpenNexus.Application.Companies.Models.Request;
using Arnkels.OpenNexus.Application.Companies.Models.Response;
using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/[controller]")]
[ApiController]
public class CompaniesController : ControllerBase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyService _companyService;
    private readonly ICompanyStatusRepository _companyStatusRepository;
    private readonly IMapper _mapper;

    public CompaniesController(ICompanyStatusRepository companyStatusRepository, ICompanyRepository companyRepository,
        ICompanyService companyService,
        IMapper mapper)
    {
        _companyStatusRepository = companyStatusRepository;
        _companyRepository = companyRepository;
        _companyService = companyService;
        _mapper = mapper;
    }


    [HttpGet("")]
    public async Task<IActionResult> GetCompaniesAsync()
    {
        ICollection<Domain.Entities.Company> companies = await _companyRepository.GetManyAsync();

        var responses = companies.Select(company => new CompanyResponseModel(company));

        return Ok(new ListResponseModel<CompanyResponseModel>(responses));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetCompanyById(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);

        if (company == null)
        {
            return NotFound();
        }

        CompanyResponseModel response = new CompanyResponseModel(company);

        return Ok(response);
    }

    [ProducesResponseType(201)]
    [HttpPost("")]
    public async Task<IActionResult> CreateCompanyAsync([FromBody] CompanyRequestModel model)
    {
        var company = model.ToCompany();
        await _companyService.SaveAsync(company);

        var companySaved = await _companyRepository.GetByIdAsync(company.Id);
        var response = new CompanyResponseModel(companySaved);
        return CreatedAtAction(nameof(GetCompanyById), new { id = response.Id }, response);
    }

    [ProducesResponseType(204)]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCompanyAsync(Guid id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        if (company == null)
        {
            return NotFound();
        }

        await _companyService.DeleteAsync(company);

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> ReplaceCompanyAsync(Guid id, [FromBody] CompanyRequestModel model)
    {
        var existingCompany = await _companyRepository.GetByIdAsync(id);
        if (existingCompany == null)
        {
            return NotFound();
        }

        var company = model.ToCompany();
        company.Id = existingCompany.Id;
        await _companyService.SaveAsync(company);

        var response = new CompanyResponseModel(await _companyRepository.GetByIdAsync(id));

        return Ok(response);
    }
}