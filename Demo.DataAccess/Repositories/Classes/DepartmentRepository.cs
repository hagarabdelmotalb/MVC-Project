using Demo.DataAccess.Data.Contexts;
using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.DataAccess.Repositories.Classes
{
    public class DepartmentRepository(ApplicationDbContext dbContext) : IDepartmentRepository
    {
        private readonly ApplicationDbContext _dbContext = dbContext;

        //Geting all departments
        public IEnumerable<Department> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Departments.ToList();
            }
            return _dbContext.Departments.AsNoTracking().ToList();
        }

        //Get department by id
        public Department? GetById(int id) => _dbContext.Departments.Find(id);

        //add department
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        //update department
        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }

        //delete department
        public int Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }
    }
}
