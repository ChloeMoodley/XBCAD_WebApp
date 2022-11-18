using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
