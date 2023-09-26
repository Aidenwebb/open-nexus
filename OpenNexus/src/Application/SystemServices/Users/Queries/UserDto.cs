using Arnkels.OpenNexus.Application.Common.Mappings;
using Arnkels.OpenNexus.Domain.Entities.Systems;

namespace Arnkels.OpenNexus.Application.SystemServices.Users.Queries;

public class UserDto : IMapFrom<User>
{
    public string Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}