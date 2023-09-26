using System.ComponentModel.DataAnnotations;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Domain.Entities.Systems;
using MediatR;

namespace Arnkels.OpenNexus.Application.SystemServices.SystemUsers.Commands.CreateUser;

public record CreateUserCommand : IRequest<string>
{
    public required string Email { get; set; }
    public required string Password { get; set; }
}

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
{
    private readonly IIdentityService _identityService;

    public CreateUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }


    public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var result = await _identityService.CreateUserAsync(request.Email, request.Password);

        return result.userId;
    }
}