using AgilePJNhomC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgilePJNhomC.Controllers
{
    public class VideoListController : Controller
    {
        private readonly ILogger<VideoListController> _logger;

        public VideoListController(ILogger<VideoListController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
