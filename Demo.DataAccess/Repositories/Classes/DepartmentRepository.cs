using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Models.DepartmentModule;
using Demo.DataAccess.Models.EmployeeModule;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext _dbContext)
        : GenericRepository<Department>(_dbContext), IDepartmentRepository
    {
    }
}
