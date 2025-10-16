using Domain.Entities;


namespace Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {

        // Get All 
        Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false);



        // Get By Id
        Task<TEntity?> GetByIdAsync(TKey id);


        // Add

        Task AddAsync(TEntity entity);


        // Update
        void Update(TEntity entity);



        // Delete
        void Delete(TEntity entity);










    }






}
