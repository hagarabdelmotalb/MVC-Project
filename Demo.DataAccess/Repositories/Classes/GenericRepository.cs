using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.Shared;
using Demo.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Classes
{
    public class GenericRepository<TEntity>(ApplicationDbContext _dbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
    {

        //Get All
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).ToList();
            }
            return _dbContext.Set<TEntity>().Where(entity => entity.IsDeleted == false).AsNoTracking().ToList();
        }

        //Get department by id
        public TEntity? GetById(int id) => _dbContext.Set<TEntity>().Find(id);

        //add department
        public void Add(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
        }

        //update department
        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
        }

        //delete department
        public void Delete(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();
        }
    }
}
