using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AboutUsDisplay()
        {
            return View();
        }
    }
}
