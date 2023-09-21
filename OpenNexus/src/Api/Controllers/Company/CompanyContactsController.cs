using Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Commands.CreateCompanyContact;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Queries;
using Arnkels.OpenNexus.Application.CompanyServices.CompanyContacts.Queries.GetCompanyContactById;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.Company;

[Route("/company/contacts")]
public class CompanyContactsController : ApiControllerBase
{
    [HttpPost("")]
    public async Task<IActionResult> CreateAsync([FromBody] CreateCompanyContactCommand command)
    {
        var responseId = await Mediator.Send(command);

        var response = "";

        return CreatedAtAction(nameof(GetCompanyContactById), new { id = responseId }, response);
    }

    // Get CompanyStatusById
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CompanyContactDto>> GetCompanyContactById(Guid id)
    {
        var query = new GetCompanyContactByIdCommand
        {
            Id = id
        };
        return await Mediator.Send(query);

        return Ok(new CompanyContactDto());
    }
}