using Arnkels.OpenNexus.Application.Common.Models;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.CreateCompany;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.DeleteCompany;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Commands.UpdateCompany;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompaniesWithPagination;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompanyById;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;
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
    public async Task<ActionResult<PaginatedList<CompanyDto>>> GetCompaniesWithPaginationAsync(
        [FromQuery] GetCompaniesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
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

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteCompanyAsync(Guid id)
    {
        await Mediator.Send(new DeleteCompanyCommand(id));

        return NoContent();
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCompanyCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}