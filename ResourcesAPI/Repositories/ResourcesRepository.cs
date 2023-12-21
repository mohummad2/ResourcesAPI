using Microsoft.EntityFrameworkCore;
using ResourcesAPI.Data;
using ResourcesAPI.Repositories.Interfaces;

namespace ResourcesAPI.Repositories;
public class ResourcesRepository<T>: IResourcesRepository<T> where T : class
{
    private readonly ResourcesContext _dbContext;
    private readonly DbSet<T> _dbSet;

    public ResourcesRepository(ResourcesContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IQueryable<T>> GetAll()
    {
        return _dbSet.AsQueryable();
    }

    public async Task Add(T model)
    {
        _ = await _dbSet.AddAsync(model);
    }

    public async Task SaveChanges()
    {
        _ = await _dbContext.SaveChangesAsync();
    }
}
