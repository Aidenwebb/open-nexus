using Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.CreateCompany;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompanyById;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Request;
using Arnkels.OpenNexus.Application.CompanyServices.Models.Response;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/[controller]")]
public class CompaniesController : ApiControllerBase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICompanyService _companyService;

    public CompaniesController(ICompanyRepository companyRepository,
        ICompanyService companyService)
    {
        _companyRepository = companyRepository;
        _companyService = companyService;
    }


    [HttpGet("")]
    public async Task<IActionResult> GetCompaniesAsync()
    {
        ICollection<Domain.Entities.Company> companies = await _companyRepository.GetManyAsync();

        var responses = companies.Select(company => new CompanyResponseModel(company));

        return Ok(new ListResponseModel<CompanyResponseModel>(responses));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CompanyDto>> GetCompanyById(Guid id)
    {
        var query = new GetCompanyByIdQuery
        {
            Id = id
        };
        return await Mediator.Send(query);
    }

    [ProducesResponseType(201)]
    [HttpPost("")]
    public async Task<ActionResult> CreateCompanyAsync([FromBody] CreateCompanyCommand command)
    {
        var responseId = await Mediator.Send(command);

        var response = "";

        return CreatedAtAction(nameof(GetCompanyById), new { id = responseId }, response);
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