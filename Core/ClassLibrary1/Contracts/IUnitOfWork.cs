using Domain.Entities;


namespace Domain.Contracts
{
    public interface IUnitOfWork
    {
        // Complete / Save ChangesAsync

        Task<int> SaveChangeAsync();

        IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;











    }




}
