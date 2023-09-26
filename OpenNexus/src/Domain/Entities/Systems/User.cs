using Arnkels.OpenNexus.Domain.Common;
using Microsoft.AspNetCore.Identity;

namespace Arnkels.OpenNexus.Domain.Entities.Systems;

public class User : IdentityUser, ITableObject<string>
{
    public void SetNewId()
    {
        return;
    }
}