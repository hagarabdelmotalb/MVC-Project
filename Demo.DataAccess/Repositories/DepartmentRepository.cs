
using Demo.DataAccess.Data.Contexts;

namespace Demo.DataAccess.Repositories
{
    internal class DepartmentRepository(ApplicationDbContext dbContext)
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        public Department? GetById(int id)
        {
            var department = _dbContext.Departments.Find(id);
            return department;
        }
    }
}
