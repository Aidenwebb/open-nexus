using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Domain.Services;

namespace Arnkels.OpenNexus.Application.Services;

public abstract class Service<T, TId> : IService<T, TId>
    where TId : IEquatable<TId>
    where T : class, ITableObject<TId>
{
    private readonly IRepository<T, TId> _repository;

    public Service(IRepository<T, TId> repository)
    {
        _repository = repository;
    }

    public async Task SaveAsync(T obj)
    {
        if (obj.Id.Equals(default(TId)))
        {
            await _repository.CreateAsync(obj);
        }
        else
        {
            await _repository.ReplaceAsync(obj);
        }
    }

    public async Task DeleteAsync(T obj)
    {
        await _repository.DeleteAsync(obj);
    }
}