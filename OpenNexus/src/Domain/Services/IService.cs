using Arnkels.OpenNexus.Domain.Common;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Services;

public interface IService<T, TId>
    where TId : IEquatable<TId>
    where T : class, ITableObject<TId>
{
    Task SaveAsync(T obj);
    Task DeleteAsync(T obj);
}