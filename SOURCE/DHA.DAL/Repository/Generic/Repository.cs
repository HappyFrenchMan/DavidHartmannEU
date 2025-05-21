using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DHA.DAL.Repository.Generic
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly Db_Context _myDBContext;
        public Repository(Db_Context pDBContext)
        {
            _myDBContext = pDBContext;
        }
        public void Add(TEntity entity)
        {
            _myDBContext.Set<TEntity>().Add(entity);
            _myDBContext.SaveChanges();
        }
        public void AddMany(IEnumerable<TEntity> entities)
        {
            _myDBContext.Set<TEntity>().AddRange(entities);
            _myDBContext.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            _myDBContext.Set<TEntity>().Remove(entity);
            _myDBContext.SaveChanges();
        }
        public void DeleteMany(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = Find(predicate);
            _myDBContext.Set<TEntity>().RemoveRange(entities);
            _myDBContext.SaveChanges();
        }
        public TEntity FindOne(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return Get(findOptions).FirstOrDefault(predicate)!;
        }
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, FindOptions? findOptions = null)
        {
            return Get(findOptions).Where(predicate);
        }
        public IQueryable<TEntity> GetAll(FindOptions? findOptions = null)
        {
            return Get(findOptions);
        }
        public void Update(TEntity entity)
        {
            _myDBContext.Set<TEntity>().Update(entity);
            _myDBContext.SaveChanges();
        }
        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _myDBContext.Set<TEntity>().Any(predicate);
        }
        public int Count(Expression<Func<TEntity, bool>> predicate)
        {
            return _myDBContext.Set<TEntity>().Count(predicate);
        }
        private DbSet<TEntity> Get(FindOptions? findOptions = null)
        {
            findOptions ??= new FindOptions();
            var entity = _myDBContext.Set<TEntity>();
            if (findOptions.IsAsNoTracking && findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes().AsNoTracking();
            }
            else if (findOptions.IsIgnoreAutoIncludes)
            {
                entity.IgnoreAutoIncludes();
            }
            else if (findOptions.IsAsNoTracking)
            {
                entity.AsNoTracking();
            }
            return entity;
        }
    }//class
}//namespace