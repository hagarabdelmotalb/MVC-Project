using Demo.DataAccess.Repositories.Interfaces;

namespace Demo.BLL.Services.Interfaces
{
    public interface IUnitOfWork
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }
        public int SaveChanges();
    }
}
