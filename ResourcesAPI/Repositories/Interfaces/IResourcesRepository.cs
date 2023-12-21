namespace ResourcesAPI.Repositories.Interfaces;
public interface IResourcesRepository<T> where T : class
{
    Task<IQueryable<T>> GetAll();
    Task Add(T model);
    Task SaveChanges();
}
