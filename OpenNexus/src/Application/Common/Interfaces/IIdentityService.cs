using Arnkels.OpenNexus.Domain.Entities.Systems;

namespace Arnkels.OpenNexus.Application.Common.Interfaces;

public interface IIdentityService
{
    // User section
    Task<(bool Succeeded, string userId)> CreateUserAsync(string email, string password);
    Task SendConfirmationEmailAsync(User user, string email);
}