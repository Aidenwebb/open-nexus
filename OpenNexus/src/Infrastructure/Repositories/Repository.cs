using Arnkels.OpenNexus.Domain.Common;
using Arnkels.OpenNexus.Domain.Entities;
using Arnkels.OpenNexus.Domain.Repositories;
using Arnkels.OpenNexus.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Arnkels.OpenNexus.Infrastructure.Repositories;

public abstract class Repository<T, TId> : BaseEntityFrameworkRepository, IRepository<T, TId>
    where TId : IEquatable<TId>
    where T : class, ITableObject<TId>
{
    public Repository(IServiceScopeFactory serviceScopeFactory, Func<DatabaseContext, DbSet<T>> getDbSet)
        : base(serviceScopeFactory)
    {
        GetDbSet = getDbSet;
    }

    protected Func<DatabaseContext, DbSet<T>> GetDbSet { get; private set; }


    public virtual async Task<T> GetByIdAsync(TId id)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var entity = await GetDbSet(dbContext).FindAsync(id);
            return entity;
        }
    }

    public virtual async Task<T> CreateAsync(T obj)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            obj.SetNewId();
            await dbContext.AddAsync(obj);
            await dbContext.SaveChangesAsync();
            return obj;
        }
    }

    public virtual async Task ReplaceAsync(T obj)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            var entity = await GetDbSet(dbContext).FindAsync(obj.Id);
            if (entity != null)
            {
                dbContext.Entry(entity).CurrentValues.SetValues(obj);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    public virtual async Task UpsertAsync(T obj)
    {
        if (obj.Id.Equals(default(TId)))
        {
            await CreateAsync(obj);
        }
        else
        {
            await ReplaceAsync(obj);
        }
    }

    public virtual async Task DeleteAsync(T obj)
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var dbContext = GetDatabaseContext(scope);
            dbContext.Remove(obj);
            await dbContext.SaveChangesAsync();
        }
    }
}