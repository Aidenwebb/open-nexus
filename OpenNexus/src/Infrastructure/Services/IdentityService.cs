using System.Diagnostics;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Domain.Entities.Systems;
using Microsoft.AspNetCore.Identity;

namespace Arnkels.OpenNexus.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly IUserEmailStore<User> _emailStore;
    private readonly UserManager<User> _userManager;
    private readonly IUserStore<User> _userStore;

    public IdentityService(UserManager<User> userManager, IUserStore<User> userStore)
    {
        _userManager = userManager;
        _userStore = userStore;
        _emailStore = (IUserEmailStore<User>)userStore;
    }

    public async Task<(bool Succeeded, string userId)> CreateUserAsync(string email, string password)
    {
        var user = new User();
        await _userStore.SetUserNameAsync(user, email, CancellationToken.None);
        await _emailStore.SetEmailAsync(user, email, CancellationToken.None);

        var result = await _userManager.CreateAsync(user, password);

        if (!result.Succeeded)
        {
            throw new ValidationException(result.Errors);
        }

        await SendConfirmationEmailAsync(user, email);

        return (result.Succeeded, user.Id);
    }

    public async Task SendConfirmationEmailAsync(User user, string email)
    {
        // TODO: Generate Confirmation Email
        Debug.WriteLine($"{nameof(SendConfirmationEmailAsync)} - NOT IMPLEMENTED");
    }
}