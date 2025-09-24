using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Demo.BLL.DTOS;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService
        ,IWebHostEnvironment _env, ILogger<DepartmentController> _logger) : Controller
    {
        #region Index
        //Base URl/Department/Index
        public IActionResult Index()
        {
            var department = _departmentService.GetAllDepartments();
            return View(department);
        }
        #endregion

        #region Craete
        //Retrun View
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //submit form
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto DepartmentDto)
        {
            //ModelState.AddModelError("code", "code must be greater than 100");
            //ModelState.AddModelError(string.Empty,"Department can not be created"); //general error message
            if (ModelState.IsValid) //server side validation
            {
                try
                {
                    int result = _departmentService.AddDepartment(DepartmentDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be created");
                        return View(DepartmentDto);
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be created because : { ex.Message}");
                        return View(DepartmentDto);
                    }
                    else
                    {
                        _logger.LogError($"Department can not be created because {ex}");
                        return View("ErrorView");
                    }
                }
            }
            return View(DepartmentDto);
        }
        #endregion
    }
}
