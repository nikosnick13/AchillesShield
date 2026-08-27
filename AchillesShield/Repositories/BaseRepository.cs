using System.Threading.Tasks;
using AchillesShield.Repositories.Interfaces;

namespace AchillesShield.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    public abstract Task AddAsync(T entity);
}       
