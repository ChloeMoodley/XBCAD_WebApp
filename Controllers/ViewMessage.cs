using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class ViewMessage : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
