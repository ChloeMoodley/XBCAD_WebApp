using Microsoft.AspNetCore.Mvc;
using XBCAD_WebApp.Models;

namespace XBCAD_WebApp.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            //Get All Employees
            List<FAQModel> FAQList = new List<FAQModel>();
            FAQList.Add(new FAQModel("How do I go about getting a contract?", "Contact us."));
            return View(FAQList);
        }



    }
}
