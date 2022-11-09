using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class ContactUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
