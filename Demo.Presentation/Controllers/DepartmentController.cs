using Demo.BLL.Services.Classes;
using Demo.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Presentation.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService departmentService;
        public DepartmentController(IDepartmentService departmentService) {
            this.departmentService = departmentService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
