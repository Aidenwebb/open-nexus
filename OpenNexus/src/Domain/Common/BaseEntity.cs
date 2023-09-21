using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Common;

public abstract class BaseEntity : ITableObject<Guid>
{
    public bool InactiveFlag { get; set; }
    public Guid Id { get; set; }

    public void SetNewId()
    {
        Id = RT.Comb.Provider.PostgreSql.Create();
    }
}