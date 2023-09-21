using Arnkels.OpenNexus.Domain.Common;
using Arnkels.OpenNexus.Domain.Entities;

namespace Arnkels.OpenNexus.Domain.Repositories;

/// <summary>
/// Define basic operations to be included on all repositories.
/// T = class.
/// Tid = Table Id column data type
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="Tid"></typeparam>
public interface IRepository<T, Tid> where Tid : IEquatable<Tid> where T : class, ITableObject<Tid>
{
    Task<T> GetByIdAsync(Tid id);
    Task<T> CreateAsync(T obj);
    Task ReplaceAsync(T obj);
    Task UpsertAsync(T obj);
    Task DeleteAsync(T obj);
}