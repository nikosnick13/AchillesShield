namespace AchillesShield.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {

        Task AddAsync(T entity);
    }
}
