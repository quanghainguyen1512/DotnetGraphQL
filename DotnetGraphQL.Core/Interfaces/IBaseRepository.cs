using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetGraphQL.Core.Interfaces
{
    public interface IBaseRepository<TEntity, in TKey> where TEntity : class
    {
        Task<List<TEntity>> GetAll();
        Task<List<TEntity>> GetAll(string include);
        Task<List<TEntity>> GetAll(IEnumerable<string> includes);

        Task<TEntity> Get(TKey id);
        Task<TEntity> Get(TKey id, string include);
        Task<TEntity> Get(TKey id, IEnumerable<string> includes);

        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Delete(TKey id);
        void Update(TEntity entity);
        Task<bool> SaveChangesAsync();
    }
}