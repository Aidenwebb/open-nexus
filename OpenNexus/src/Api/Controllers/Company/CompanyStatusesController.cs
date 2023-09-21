using Arnkels.OpenNexus.Application.Common.Models;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Commands.CreateCompanyStatus;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Commands.DeleteCompanyStatus;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Commands.UpdateCompanyStatus;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyStatuses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/statuses")]
public class CompanyStatusesController : ApiControllerBase
{
    // Get CompanyStatuses
    [HttpGet("")]
    public async Task<ActionResult<PaginatedList<CompanyStatusDto>>> GetCompanyStatusesWithPagination(
        [FromQuery] GetCompanyStatusesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    // Get CompanyStatusById
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CompanyStatusDto>> GetCompanyStatusById(Guid id)
    {
        var query = new GetCompanyStatusByIdQuery
        {
            Id = id
        };
        return await Mediator.Send(query);
    }

    // Create CompanyStatus

    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyStatusCommand command)
    {
        var responseId = await Mediator.Send(command);

        var response = "";

        return CreatedAtAction(nameof(GetCompanyStatusById), new { id = responseId }, response);
    }

    // Delete CompanyStatus
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteAsync(Guid id)
    {
        await Mediator.Send(new DeleteCompanyStatusCommand(id));

        return NoContent();
    }

    // Put CompanyStatus
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] UpdateCompanyStatusCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}