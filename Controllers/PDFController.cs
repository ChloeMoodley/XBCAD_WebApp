using Microsoft.AspNetCore.Mvc;

namespace XBCAD_WebApp.Controllers
{
    public class PDFController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PDFDisplay()
        {
            return View();
        }

        public IActionResult PDFUpload()
        {
            return View();
        }


    }
}
