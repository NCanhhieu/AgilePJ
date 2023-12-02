using Microsoft.AspNetCore.Mvc;

namespace AgilePJNhomC.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILogger<VideoController> _logger;

        public VideoController(ILogger<VideoController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
