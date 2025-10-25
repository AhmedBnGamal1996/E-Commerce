
using Presistence.Data;
using System.Collections.Concurrent;

namespace Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork

    {
        private readonly StoreDbContext _dbContext;
        private readonly ConcurrentDictionary<string , object > _repository;


        public UnitOfWork(StoreDbContext dbContext)
        {
            _dbContext = dbContext;
            _repository = new ();

        }



        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        => (IGenericRepository<TEntity, TKey>)_repository.GetOrAdd(typeof(TEntity).Name,(_)
        => new GenericRepository<TEntity, TKey>(_dbContext)) ;




        #region Old Code 

        // return new GenericRepository<TEntity, TKey>(_dbContext);

        //var key = typeof(TEntity).Name;
        //if (!_repository.ContainsKey(key))

        //    _repository[key] = new GenericRepository<TEntity, TKey>(_dbContext);

        //return (IGenericRepository<TEntity, TKey>)_repository[key];


        #endregion






        public async Task<int> SaveChangeAsync()
       => await _dbContext.SaveChangesAsync();






    }

}
