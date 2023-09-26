using Arnkels.OpenNexus.Application.Common.Models;
using Arnkels.OpenNexus.Application.SystemServices.Users.Commands.CreateUser;
using Arnkels.OpenNexus.Application.SystemServices.Users.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Arnkels.OpenNexus.Api.Controllers.System;

[Route("/system/[controller]")]
public class UsersController : ApiControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<UserDto>> GetUserById(string id)
    {
        // TODO: Add GetUserById
        // var query = new GetUserByIdQuery
        // {
        //     Id = id
        // };
        // return await Mediator.Send(query);
        return null;
    }

    [ProducesResponseType(201)]
    [HttpPost("")]
    public async Task<ActionResult> CreateUserAsync([FromBody] CreateUserCommand command)
    {
        var responseId = await Mediator.Send(command);

        var response = "";

        return CreatedAtAction(nameof(GetUserById), new { id = responseId }, response);
    }
}