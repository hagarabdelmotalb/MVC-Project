using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Demo.Presentation.ViewModels;
using Demo.BLL.DTOS.DepartmentDTOS;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController(IDepartmentService _departmentService
        , IWebHostEnvironment _env, ILogger<DepartmentController> _logger) : Controller
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
        public IActionResult Create(DepartmentViewModel departmentViewModel)
        {
            //ModelState.AddModelError("code", "code must be greater than 100");
            //ModelState.AddModelError(string.Empty,"Department can not be created"); //general error message
            if (ModelState.IsValid) //server side validation
            {
                try
                {
                    int result = _departmentService.AddDepartment(new CreateDepartmentDto()
                    { 
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        Description = departmentViewModel.Description,
                        DateOfCreation = departmentViewModel.CreatedAt,
                    });
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be created");
                        return View(departmentViewModel);
                    }
                }
                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                    {
                        _logger.LogError($"Department can not be created because : {ex.Message}");
                        //return View(DepartmentDto);
                    }
                    else
                    {
                        _logger.LogError($"Department can not be created because {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(departmentViewModel);
        }
        #endregion

        #region Details
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }
        #endregion

        #region Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            var departmentVM = new DepartmentViewModel()
            {
                Code = department.Code,
                Description = department.Description,
                Name = department.Name,
                CreatedAt = department.CreatedAt.HasValue ? department.CreatedAt.Value : default,
            };
            return View(departmentVM);
        }

        [HttpPost]
        public IActionResult Edit([FromRoute] int? id, DepartmentViewModel departmentVM)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!id.HasValue) return NotFound();
                    var updateDeptDto = new UpdatedDepartmentDto()
                    {
                        Id = id.Value,
                        Code = departmentVM.Code,
                        Description = departmentVM.Description,
                        Name = departmentVM.Name,
                        DateOfCreation = departmentVM.CreatedAt
                    };
                    int result = _departmentService.UpdateDepartment(updateDeptDto);
                    if (result > 0)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Department can not be updated");

                    }
                }

                catch (Exception ex)
                {
                    if (_env.IsDevelopment())
                        _logger.LogError($"Department can not be created because : {ex.Message}");

                    else
                    {
                        _logger.LogError($"Department can not be created because {ex}");
                        return View("ErrorView", ex);
                    }
                }
            }
            return View(departmentVM);
        }
        #endregion

        #region Delete

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (!id.HasValue) return BadRequest();
            var department = _departmentService.GetDepartmentById(id.Value);
            if (department == null) return NotFound();
            return View(department);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                    return RedirectToAction(nameof(Index));

                else
                {
                    ModelState.AddModelError(string.Empty, "Department can not be deleted");
                    
                }
            }
            catch (Exception ex)
            {
                if (_env.IsDevelopment())
                {
                    _logger.LogError($"Department can not be created because : {ex.Message}");

                }
                else
                {
                    _logger.LogError($"Department can not be created because {ex}");
                    return View("ErrorView", ex);
                }
            }
            return RedirectToAction(nameof(Delete), new { id });

            #endregion
        }
    }
}
