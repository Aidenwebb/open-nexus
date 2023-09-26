using System.Diagnostics;
using Arnkels.OpenNexus.Application.Common.Interfaces;
using Arnkels.OpenNexus.Application.Common.Exceptions;
using Arnkels.OpenNexus.Application.SystemServices.Auth.Commands.Login;
using Arnkels.OpenNexus.Domain.Entities.Systems;
using Microsoft.AspNetCore.Identity;

namespace Arnkels.OpenNexus.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly IUserEmailStore<User> _emailStore;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;
    private readonly IUserStore<User> _userStore;

    public IdentityService(UserManager<User> userManager, IUserStore<User> userStore, SignInManager<User> signInManager)
    {
        _userManager = userManager;
        _userStore = userStore;
        _signInManager = signInManager;
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

    public async Task<bool> SignInUserAsync(string userName, string password, string? twoFactorCode,
        string? twoFactorRecoveryCode, bool? useCookies, bool? useSessionCookies)
    {
        var useCookieScheme = (useCookies == true) || (useSessionCookies == true);
        var isPersistent = (useCookies == true) && (useSessionCookies != true);

        var result = await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure: true);

        if (result.RequiresTwoFactor)
        {
            if (!string.IsNullOrEmpty(twoFactorCode))
            {
                result = await _signInManager.TwoFactorAuthenticatorSignInAsync(twoFactorCode, isPersistent,
                    rememberClient: isPersistent);
            }
            else if (!string.IsNullOrEmpty(twoFactorRecoveryCode))
            {
                result = await _signInManager.TwoFactorRecoveryCodeSignInAsync(twoFactorRecoveryCode);
            }
        }

        return result.Succeeded;
    }

    public async Task SendConfirmationEmailAsync(User user, string email)
    {
        // TODO: Generate Confirmation Email
        Debug.WriteLine($"{nameof(SendConfirmationEmailAsync)} - NOT IMPLEMENTED");
    }
}