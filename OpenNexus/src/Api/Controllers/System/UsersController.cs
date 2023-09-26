using Arnkels.OpenNexus.Application.Common.Models;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompaniesWithPagination;
using Arnkels.OpenNexus.Application.CompanyServices.Companies.Queries.GetCompanyById;
using Arnkels.OpenNexus.Application.SystemServices.SystemUsers.Commands.CreateUser;
using Arnkels.OpenNexus.Application.SystemServices.SystemUsers.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.System;

[Route("/system/[controller]")]
public class UsersController : ApiControllerBase
{
    [HttpGet("")]
    public async Task<ActionResult<PaginatedList<UserDto>>> GetUsersWithPaginationAsync(
        [FromQuery] GetCompaniesWithPaginationQuery query)
    {
        // return await Mediator.Send(query);
        return null;
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CompanyDto>> GetUserById(string id)
    {
        // var query = new GetUserByIdQuery
        // {
        //     Id = id
        // };
        // return await Mediator.Send(query);
        return null;
    }

    [ProducesResponseType(201)]
    [HttpPost("")]
    public async Task<ActionResult> CreateCompanyAsync([FromBody] CreateUserCommand command)
    {
        var responseId = await Mediator.Send(command);

        var response = "";

        return CreatedAtAction(nameof(GetUserById), new { id = responseId }, response);
    }
}