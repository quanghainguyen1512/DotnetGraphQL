using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetGraphQL.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DotnetGraphQL.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class, IEntity<TKey>, new()
    {
        protected Context _ctx;
        protected readonly ILogger _logger;

        protected BaseRepository() { }
        
        protected BaseRepository(Context ctx, ILogger logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public TEntity Add(TEntity entity)
        {
            _ctx.Set<TEntity>().Add(entity);
            return entity;
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _ctx.Set<TEntity>().AddRange(entities);
        }

        public void Delete(TKey id)
        {
            var entity = new TEntity { Id = id };
            _ctx.Set<TEntity>().Attach(entity);
            _ctx.Set<TEntity>().Remove(entity);
        }

        public virtual Task<TEntity> Get(TKey id)
        {
            _logger.LogInformation("Get {type} with id = {id}", typeof(TEntity).Name, id);
            return _ctx.Set<TEntity>().SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, string include)
        {
            _logger.LogInformation("Get {type} with id = {id} (including {include})", typeof(TEntity).Name, id, include);
            return _ctx.Set<TEntity>().Include(include).SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public Task<TEntity> Get(TKey id, IEnumerable<string> includes)
        {
            _logger.LogInformation("Get {type} with id = {id} (including [{include}])", typeof(TEntity).Name, id, string.Join(",", includes));
            var query = _ctx.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.SingleOrDefaultAsync(c => c.Id.Equals(id));
        }

        public virtual Task<List<TEntity>> GetAll()
        {
            _logger.LogInformation("Get all {type}s", typeof(TEntity).Name);
            return _ctx.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAll(string include)
        {
            _logger.LogInformation("Get all {type}s (including {include})", typeof(TEntity).Name, include);
            return _ctx.Set<TEntity>().Include(include).ToListAsync();
        }

        public Task<List<TEntity>> GetAll(IEnumerable<string> includes)
        {
            _logger.LogInformation("Get all {type}s (including [{includes}])", typeof(TEntity).Name, string.Join(",", includes));
            var query = _ctx.Set<TEntity>().AsQueryable();
            query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.ToListAsync();
        }

        public async virtual Task<bool> SaveChangesAsync()
        {
            return (await _ctx.SaveChangesAsync()) > 0;
        }

        public void Update(TEntity entity)
        {
            _ctx.Set<TEntity>().Attach(entity);
            _ctx.Entry(entity).State = EntityState.Modified;
        }
    }
}