namespace AchillesShield.Repositories.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}