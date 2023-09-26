using Arnkels.OpenNexus.Domain.Entities.Systems;

namespace Arnkels.OpenNexus.Application.Common.Interfaces;

public interface IIdentityService
{
    // User section
    Task<(bool Succeeded, string userId)> CreateUserAsync(string email, string password);
    Task SendConfirmationEmailAsync(User user, string email);

    // Auth section
    Task<bool> SignInUserAsync(string userName, string password, string? twoFactorCode, string? twoFactorRecoveryCode,
        bool? useCookies, bool? useSessionCookies);
}