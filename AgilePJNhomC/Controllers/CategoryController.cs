using AgilePJNhomC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgilePJNhomC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Category1()
        {
            return View();
        }
        public IActionResult Category2()
        {
            return View();
        }
        public IActionResult Category3()
        {
            return View();
        }
    }
}
