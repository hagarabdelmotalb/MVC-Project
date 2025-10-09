using Demo.BLL.DTOS.EmployeeDTOS;
using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class EmployeeController(IEmployeeService _employeeService
        , IWebHostEnvironment _env, ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployee();
            return View(employees);
        }
        #endregion

        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreatedEmployeeDto employeeDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _employeeService.CreateEmployee(employeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Employee can not be created");
                        return View(employeeDto);
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Employee can not be created because : {ex.Message}");
                        //return View(DepartmentDto);
                    }
                    else
                    {
                        _logger.LogError($"Employee can not be created because {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(employeeDto);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee == null) return NotFound();
            return View(employee);
        }
        #endregion
    }
}
