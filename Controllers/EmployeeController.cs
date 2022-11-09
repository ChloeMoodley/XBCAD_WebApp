using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Login view ()
        public IActionResult Employee_Login()
        {
            return View();
        }
    }
}
