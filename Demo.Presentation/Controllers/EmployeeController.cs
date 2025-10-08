using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService) : Controller
    {
        #region index
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployee();
            return View(employees);
        }
        #endregion

        #region create
        [HttpGet]
        public IActionResult Create() 
        { 
            return View();
        }
        #endregion
    }
}
