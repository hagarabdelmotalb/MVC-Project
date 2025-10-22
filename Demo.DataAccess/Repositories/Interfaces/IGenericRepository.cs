using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Models.Shared;
using System.Linq.Expressions;

namespace Demo.DataAccess.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll(bool withTracking = false);
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool> > predicate);

        TEntity? GetById(int id);
        void Update(TEntity entity);
    }
}
